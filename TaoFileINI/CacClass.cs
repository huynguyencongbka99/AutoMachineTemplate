using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoFileINI
{
    public class SystemConfig
    {
        public string Language { get; set; } 
        public string Theme { get; set; }
        public bool AutoLogin { get; set; }
    }

    public class PlcConfig
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
    }

    public class RobotConfig
    {
        public string IP { get; set; }
        public int Port { get; set; }
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

    public class Recipe
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public PlcConfig Plc { get; set; } = new PlcConfig();
        public RobotConfig Robot { get; set; } = new RobotConfig();
        public CameraConfig Camera { get; set; } = new CameraConfig();
        public VisionConfig Vision { get; set; } = new VisionConfig();
    }
}
