using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMachine.Infrastructure.PLC
{
    public class PlcSnapshot
    {
        public bool Start { get; set; }
        public bool SensorIn { get; set; }
        public bool SensorOut { get; set; }
    }

    public interface IPlcService
    {
        PlcSnapshot GetSnapshot();   // đọc an toàn
        void Start();                // bắt đầu polling
        void Write(string key, bool value);
    }

    public class PlcService : IPlcService
    {
        private readonly object _lock = new object();

        // snapshot nội bộ (KHÔNG expose trực tiếp)
        private readonly PlcSnapshot _snapshot = new PlcSnapshot();
        bool start = false;
        bool inSen = false;
        //bool outSen = false;
        public void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    //đọc PLC thật
                    //var start = Read("X0");
                    // var inSen = Read("X1");
                    var outSen = Read("X2");

                    if (start == false) start = true;
                    else start = false;

                    if (inSen == false) inSen = true;
                    else inSen = false;

                    // 🔒 ghi dữ liệu (critical section NGẮN)
                    lock (_lock)
                    {
                        _snapshot.Start = start;
                        _snapshot.SensorIn = inSen;
                        _snapshot.SensorOut = outSen;
                    }


                    await Task.Delay(10);
                }
            });
        }

        // 🔒 đọc snapshot an toàn (copy ra ngoài)
        public PlcSnapshot GetSnapshot()
        {
            lock (_lock)
            {
                return new PlcSnapshot
                {
                    Start = _snapshot.Start,
                    SensorIn = _snapshot.SensorIn,
                    SensorOut = _snapshot.SensorOut
                };
            }
        }

        public void Write(string key, bool value)
        {
            // tùy driver PLC
        }

        private bool Read(string key)
        {
            // đọc PLC thật (MX Component/Modbus/MC…)
            return false;
        }
    }
}
