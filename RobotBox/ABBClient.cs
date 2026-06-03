using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ABBSocket
{
    private string _ip;
    private int _port;

    private readonly object _socketLock = new object();
    public bool IsConnected =>_client != null &&_client.Connected;

    private TcpClient _client;
    private NetworkStream _stream;


    public async Task StartAsync(string ip, int port)
    {
        _ip = ip;
        _port = port;
        await Connect();
        _ = Task.Run(ConnectionMonitorLoop);
    }

    public async Task Connect()
    {
        try
        {
            TcpClient client = new TcpClient();

            client.ReceiveTimeout = 3000;
            client.SendTimeout = 3000;

            await client.ConnectAsync(_ip, _port);

            lock (_socketLock)
            {
                _client?.Dispose();

                _client = client;
                _stream = _client.GetStream();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task ConnectionMonitorLoop()
    {
        while (true)
        {
            if (!IsConnected)
            {
                Console.WriteLine("Reconnect...");
                await Connect();
            }

            await Task.Delay(2000);
        }
    }


    public void SendCommand_Aux(string cmd)
    {
        lock (_socketLock)
        {
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            _stream.Write(data, 0, data.Length);
        }
    }

    private async Task ReceiveLoopAux()
    {
        byte[] buffer = new byte[1024];

        while (_connected)
        {
            int len = await _stream.ReadAsync(buffer, 0, buffer.Length);

            if (len == 0)
                throw new Exception("Robot disconnected");

            string msg = Encoding.ASCII.GetString(buffer, 0, len);

            OnRobotMessage(msg);
        }
    }

    public string SendCommand(string command)
    {
        lock(_socketLock)
        {
            if (_stream == null)
                throw new Exception("Robot Offline");

            try
            {
                byte[] data = Encoding.ASCII.GetBytes(command);

                _stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];

                int len = _stream.Read(buffer, 0, buffer.Length);

                return Encoding.ASCII.GetString(buffer, 0, len);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Robot Comm Error: {ex.Message}");

                Disconnect();

                return "";
            }
        }
    }

    public void Disconnect()
    {
        lock (_socketLock)
        {
            try
            {
                _stream?.Close();
                _client?.Close();
            }
            catch
            {
            }

            _stream = null;
            _client = null;
        }
    }
}