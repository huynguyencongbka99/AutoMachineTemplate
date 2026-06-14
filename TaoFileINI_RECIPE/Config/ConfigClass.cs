using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoFileINI_RECIPE
{
    public class SystemConfig
    {
        public string LastRecipe { get; set; }
    }

    public class PlcConfig
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
    }

    public class RobotConfig
    {
        public string IP { set; get; }
        public int Port { set; get; }
        public double Speed { get; set; }
        public double Accel { get; set; }
    }

    public class CameraConfig
    {
        public double Exposure { get; set; }
        public double Gain { get; set; }
        public string TriggerMode { get; set; }
    }

    public class VisionConfig
    {
        public double Score { get; set; }
        public double AngleStart { get; set; }
        public double AngleEnd { get; set; }
    }


}
