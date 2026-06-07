using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PLCGetSnapShot
{
    #region ABB Socket
    public class ABBSocket
    {
        private readonly object _snapshotLock = new object();

        private RobotSnapshot _snapshot =new RobotSnapshot();

        #region Fields

        private string _ip;
        private int _port;

        private TcpClient _client;
        private NetworkStream _stream;

        private readonly object _socketLock = new object();

        private CancellationTokenSource _cts;

        //private TaskCompletionSource<bool> _ackWaiter;

        private bool _ackReceived = false;

        #endregion

        #region Properties

        public bool IsConnected =>_client != null &&_client.Connected;

        public RobotState State { get; private set; } = RobotState.Offline;

        #endregion

        #region Events
        /// <summary>
        /// Action dùng để Invoke và gọi một function đăng ký nó làm việc. 
        /// Action là một delegate có tham số và không trả về giá trị nên nó chỉ phát lệnh cho đối tượng function
        /// đăng ký nó làm việc
        /// </summary>
        public event Action<string> MessageReceived; //Khi action này Invoke thì nó sẽ truyền một string cho hàm đăng ký nó làm việc

        public event Action RobotDone;

        public event Action RobotBusy;

        public event Action RobotError;

        public event Action<bool> ConnectionChanged; // Dùng để trigger một hàm khai báo tình trạng thay đổi connection

        #endregion

        #region Start
        /// <summary>
        /// Hàm này nhận để kích hoạt function monitor loop tình trạng connection
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task StartAsync(string ip, int port)
        {
            _ip = ip;
            _port = port;

            _cts = new CancellationTokenSource();
            // Khi chạy hàm StartAsync thì phải đợi chạy xong ConnectAsync thì mới được phép chạy lệnh Task.Run()
            await ConnectAsync();

            _ = Task.Run(() => ConnectionMonitorLoop(_cts.Token));
            _ = Task.Run(() => RegisterPollingLoop(_cts.Token));
        }

        #endregion

        #region Connect

        private async Task ConnectAsync()
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

                State = RobotState.Idle;

                ConnectionChanged?.Invoke(true);

                _ = Task.Run(() => ReceiveLoop(_cts.Token));

                Console.WriteLine("Robot Connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connect Fail : {ex.Message}");

                Disconnect();
            }
        }

        #endregion

        #region Reconnect

        private async Task ConnectionMonitorLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (!IsConnected)
                {
                    Console.WriteLine("Reconnect...");

                    await ConnectAsync();
                }

                await Task.Delay(2000, token);
            }
        }

        #endregion

        #region Receive

        private async Task ReceiveLoop(CancellationToken token)
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (!token.IsCancellationRequested)
                {
                    int len =
                        await _stream.ReadAsync(
                            buffer,
                            0,
                            buffer.Length,
                            token);

                    if (len == 0) throw new Exception("Robot Disconnected");

                    string msg =
                        Encoding.ASCII.GetString(
                            buffer,
                            0,
                            len);

                    ProcessMessage(msg.Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Receive Error : {ex.Message}");

                Disconnect();
            }
        }

        #endregion

        #region Process Message

        private void ProcessMessage(string msg)
        {
            Console.WriteLine($"RX => {msg}");

            MessageReceived?.Invoke(msg);

            switch (msg)
            {
                //case "RSP:ACK":

                //    _ackWaiter?.
                //        TrySetResult(true);

                //    break;

                case "RSP:ACK":

                    _ackReceived = true;

                    break;


                case "EVT:BUSY":

                    State = RobotState.Busy;

                    RobotBusy?.Invoke();

                    break;

                case "EVT:DONE":

                    State = RobotState.Idle;

                    RobotDone?.Invoke();

                    break;

                case "EVT:ERROR":

                    State = RobotState.Error;

                    RobotError?.Invoke();

                    break;
            }
        }

        #endregion

        #region Send

        private void SendRaw(string command)
        {
            lock (_socketLock)
            {
                if (_stream == null)
                    throw new Exception(
                        "Robot Offline");

                byte[] data = Encoding.ASCII.GetBytes(command);

                _stream.Write(data, 0, data.Length);
            }
        }

        public async Task<bool> SendCommandAsync(string command)
        {
            _ackReceived = false;

            SendRaw(command);

            int timeout = 3000;
            int elapsed = 0;

            while (!_ackReceived)
            {
                await Task.Delay(10);

                elapsed += 10;

                if (elapsed >= timeout)
                    return false;
            }

            return true;
        }

        //public async Task<bool> SendCommandAsync(
        //    string command,
        //    int timeout = 3000)
        //{
        //    if (!IsConnected)
        //        return false;

        //    _ackWaiter = new TaskCompletionSource<bool>();

        //    try
        //    {
        //        SendRaw(command);

        //        Task completed =
        //            await Task.WhenAny(
        //                _ackWaiter.Task,
        //                Task.Delay(timeout));

        //        return completed ==
        //               _ackWaiter.Task;
        //    }
        //    catch
        //    {
        //        Disconnect();

        //        return false;
        //    }
        //}

        #endregion

        #region Stop

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

            State = RobotState.Offline;

            ConnectionChanged?.Invoke(false);
        }

        public void Stop()
        {
            _cts?.Cancel();

            Disconnect();
        }

        #endregion


        #region SnapShot ABB Logic
        public RobotSnapshot GetSnapshot()
        {
            lock (_snapshotLock)
            {
                return new RobotSnapshot
                {
                    TimeStamp = _snapshot.TimeStamp,
                    IsConnected = _snapshot.IsConnected,
                    State = _snapshot.State,

                    PartCount = _snapshot.PartCount,
                    AlarmCode = _snapshot.AlarmCode,
                    ProgramStep = _snapshot.ProgramStep,

                    PosX = _snapshot.PosX,
                    PosY = _snapshot.PosY,
                    PosZ = _snapshot.PosZ
                };
            }
        }

        private async Task RegisterPollingLoop(
    CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (IsConnected)
                {
                    try
                    {
                        SendRaw("GET_STATUS\n");
                    }
                    catch
                    {
                    }
                }

                await Task.Delay(200, token);
            }
        }

        private void ParseStatus(string msg)
        {
            string[] arr = msg.Split(',');

            lock (_snapshotLock)
            {
                _snapshot.TimeStamp = DateTime.Now;

                _snapshot.PartCount =
                    int.Parse(arr[1]);

                _snapshot.AlarmCode =
                    int.Parse(arr[2]);

                _snapshot.ProgramStep =
                    int.Parse(arr[3]);

                _snapshot.PosX =
                    double.Parse(arr[4]);

                _snapshot.PosY =
                    double.Parse(arr[5]);

                _snapshot.PosZ =
                    double.Parse(arr[6]);
            }
        }
        #endregion
    }
    #endregion
    #region Robot Enumstate
    public enum RobotState
    {
        Offline,
        Idle,
        Busy,
        Error
    }
    #endregion
    #region RobotSnapShot
    public class RobotSnapshot
    {
        public DateTime TimeStamp { get; set; }

        public bool IsConnected { get; set; }

        public RobotState State { get; set; }

        public int PartCount { get; set; }

        public int AlarmCode { get; set; }

        public int ProgramStep { get; set; }

        public double PosX { get; set; }

        public double PosY { get; set; }

        public double PosZ { get; set; }



    }
    #endregion
}
