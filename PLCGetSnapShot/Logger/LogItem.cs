using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCGetSnapShot
{
    public class LogItem
    {
        public DateTime Time { get; set; }

        public LogCategory Category { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return
                $"{Time:HH:mm:ss.fff} " +
                $"[{Category}] " +
                $"{Message}";
        }
    }

}
