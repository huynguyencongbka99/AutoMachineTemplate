using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Modbus.Device;
using System.IO;
using System.IO.Ports;

namespace RobotBox
{
    /// <summary>
    /// Dùng để chứa những thông tin đọc về Form hiển thị hoặc sử dụng ở trong Thread Auto
    /// </summary>
    public class PlcSnapshot
    {
        public bool[] X { get; set; }

        public bool[] Y { get; set; }

        public bool[] M { get; set; }

        public ushort[] D { get; set; }
    }

    /// <summary>
    /// IPlcService dùng cho những PLC có cổng mạng giao tiếp ModbusTCP/IP
    /// </summary>
    public interface IPlcService
    {

        PlcSnapshot GetSnapshot();   // đọc an toàn
        void Start();                // bắt đầu polling
        
        void WriteD(int address, ushort value);
    }

    /// <summary>
    /// Dùng với PLC Delta có cổng mạng
    /// </summary>
    public class PlcServiceDelta : IPlcService
    {
        private string _ip = "192.168.20.11";
        private int _port = 5000;
        ModbusIpMaster _master;

        public PlcServiceDelta (string ip, int port)
        {
            this._ip = ip;
            this._port = port;
            Connect();
        }

        public void Connect()
        {
            var _tcpClient = new TcpClient();
            _tcpClient.Connect(_ip, _port);
             _master = ModbusIpMaster.CreateIp(_tcpClient);
        }

        private readonly object _lock = new object();

        // snapshot nội bộ (KHÔNG expose trực tiếp)
        private readonly PlcSnapshot _snapshot = new PlcSnapshot();

        public void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    //đọc PLC thật


                    bool[] x = ReadX(1024, 8);

                    bool[] y = ReadY(1280, 4);

                    bool[] m = ReadM(2048, 4);

                    //bool[] x = ReadX(0, 8);

                    //bool[] y = ReadY(0, 4);

                    //bool[] m = ReadM(8192, 4);
                    // 🔒 ghi dữ liệu (critical section NGẮN)
                    lock (_lock)
                    {
                        _snapshot.X = x;

                        _snapshot.Y = y;

                        _snapshot.M = m;

                    }
                    await Task.Delay(50);
                }
            });
        }

        // 🔒 đọc snapshot an toàn (copy ra ngoài)
        public PlcSnapshot GetSnapshot()
        {
            lock (_lock)
            {
                //Vì sao phải Clone() ? thì UI và PLC thread dùng chung object.
                return new PlcSnapshot
                {
                    X = (bool[])_snapshot.X?.Clone(),

                    Y = (bool[])_snapshot.Y?.Clone(),

                    M = (bool[])_snapshot.M?.Clone()
                };
            }
        }

        public bool[] ReadX(int start, int count)
        {
            return _master.ReadInputs((ushort)start, (ushort)count);
        }

        public bool[] ReadY(int start, int count)
        {
            return _master.ReadCoils((ushort)start, (ushort)count);
        }

        public bool[] ReadM(int start, int count)
        {
            return _master.ReadCoils((ushort)start, (ushort)count);
        }

        public void WriteM(int address, bool value)
        {
            _master.WriteSingleCoil((ushort)address, value);
        }

        public ushort[] ReadD(int start, int count)
        {
            return _master.ReadHoldingRegisters((ushort)start, (ushort)count);
        }

        public void WriteD(int address, ushort value)
        {
            _master.WriteSingleRegister((ushort)address, value);
        }
    }

    /// <summary>
    /// Dùng với PLC Fx5U
    /// </summary>
    public class PlcServiceFX5U : IPlcService
    {
        private string _ip = "192.168.20.11";
        private int _port = 5000;
        ModbusIpMaster _master;

        public PlcServiceFX5U(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
            Connect();
        }

        public void Connect()
        {
            var _tcpClient = new TcpClient();
            _tcpClient.Connect(_ip, _port);
            _master = ModbusIpMaster.CreateIp(_tcpClient);
        }

        private readonly object _lock = new object();

        // snapshot nội bộ (KHÔNG expose trực tiếp)
        private readonly PlcSnapshot _snapshot = new PlcSnapshot();

        public void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    //đọc PLC thật

                    bool[] x = ReadX(0, 8);

                    bool[] y = ReadY(0, 4);

                    bool[] m = ReadM(8192, 4);

                    // 🔒 ghi dữ liệu (critical section NGẮN)
                    lock (_lock)
                    {
                        _snapshot.X = x;

                        _snapshot.Y = y;

                        _snapshot.M = m;

                    }
                    await Task.Delay(50);
                }
            });
        }

        // 🔒 đọc snapshot an toàn (copy ra ngoài)
        public PlcSnapshot GetSnapshot()
        {
            lock (_lock)
            {
                //Vì sao phải Clone() ? thì UI và PLC thread dùng chung object.
                return new PlcSnapshot
                {
                    X = (bool[])_snapshot.X?.Clone(),

                    Y = (bool[])_snapshot.Y?.Clone(),

                    M = (bool[])_snapshot.M?.Clone()
                };
            }
        }

        public bool[] ReadX(int start, int count)
        {
            return _master.ReadInputs((ushort)start, (ushort)count);
        }

        public bool[] ReadY(int start, int count)
        {
            return _master.ReadCoils((ushort)start, (ushort)count);
        }

        public bool[] ReadM(int start, int count)
        {
            return _master.ReadCoils((ushort)start, (ushort)count);
        }

        public void WriteM(int address, bool value)
        {
            _master.WriteSingleCoil((ushort)address, value);
        }

        public ushort[] ReadD(int start, int count)
        {
            return _master.ReadHoldingRegisters((ushort)start, (ushort)count);
        }

        public void WriteD(int address, ushort value)
        {
            _master.WriteSingleRegister((ushort)address, value);
        }
    }
    

    /// <summary>
    /// For PLC Xinjie Serial Only
    /// </summary>
    public class PLCServiceXinjie
    {
        private ModbusSerialMaster _master;
        private readonly byte slaveId = 1;
        private SerialPort serialPort;

        private readonly object _lock = new object();

        public PLCServiceXinjie(SerialPort serialPort)
        {
            this.serialPort = serialPort;
            //this.serialPort = _serialPort;
            ModbusConfig();
            OpenSerialPort();
        }
        // snapshot nội bộ (KHÔNG expose trực tiếp)
        private readonly PlcSnapshot _snapshot = new PlcSnapshot();

        public void OpenSerialPort()
        {
            try
            {
                if (!serialPort.IsOpen)
                    serialPort.Open();
            }
            catch { }

        }

        public void ModbusConfig()
        {
            _master = ModbusSerialMaster.CreateRtu(serialPort);
        }

        public void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {

                    bool[] x = ReadX(0x5000, 8);

                    bool[] y = ReadY(0x6000, 8);

                    bool[] m = ReadM(0x00, 4);
                    // 🔒 ghi dữ liệu (critical section NGẮN)
                    lock (_lock)
                    {
                        _snapshot.X = x;

                        _snapshot.Y = y;

                        _snapshot.M = m;

                    }
                    await Task.Delay(100);
                }
            });
        }

        public PlcSnapshot GetSnapshot()
        {
            lock (_lock)
            {
                //Vì sao phải Clone() ? thì UI và PLC thread dùng chung object.
                return new PlcSnapshot
                {
                    X = (bool[])_snapshot.X?.Clone(),

                    Y = (bool[])_snapshot.Y?.Clone(),

                    M = (bool[])_snapshot.M?.Clone()
                };
            }
        }

        public ushort[] ChangeStringDataToUShort(string text)
        {
            ushort[] result = { 0, 0 };
            ushort tempD0;
            ushort tempD1;
            int x;
            int.TryParse(text, out x);
            tempD0 = (ushort)(x & 0xFFFF);
            tempD1 = (ushort)((x >> 16) & 0xFFFF);
            try
            {
                result[0] = tempD0;
                result[1] = tempD1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public int ChangeUShortToInt(ushort[] data)
        {
            int result = 0;
            try
            {
                result = data[0] + (data[1] << 16);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public ushort[] ReadD(int start, int count)
        {
            return _master.ReadHoldingRegisters(slaveId, (ushort)(start), (ushort)count);
        }

        public void WriteD(int address, ushort value)
        {
            _master.WriteSingleRegister(slaveId,(ushort)(address),value);
        }
        // Đọc 1 bit từ vùng Coil (Y hoặc M)
        public bool ReadCoil(byte slaveId, ushort startAddress)
        {
            bool[] result = _master.ReadCoils(slaveId, startAddress, 1);
            return result[0];
        }

        

        /// Đọc nhiều bit (mảng bool) từ vùng Coil
        public bool[] ReadY(ushort startAddress, ushort numberOfPoints)
        {
            return _master.ReadCoils(slaveId, startAddress, numberOfPoints);
        }

        public bool[] ReadX(ushort startAddress, ushort numberOfPoints)
        {
            return _master.ReadInputs(slaveId, startAddress, numberOfPoints);
        }

        public bool[] ReadM(ushort startAddress, ushort numberOfPoints)
        {
            return _master.ReadCoils(slaveId, startAddress, numberOfPoints);
        }

        // Ghi 1 bit duy nhất xuống Coil (sử dụng mã lệnh 05)
        public void WriteSingleCoil(byte slaveId, ushort startAddress, bool value)
        {
            _master.WriteSingleCoil(slaveId, startAddress, value);
        }

        // Ghi nhiều bit (một mảng) xuống Coil (sử dụng mã lệnh 15)
        public void WriteMultipleCoils(byte slaveId, ushort startAddress, bool[] data)
        {
            _master.WriteMultipleCoils(slaveId, startAddress, data);
        }
    }
}
