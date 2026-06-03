using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace TaoFileINI
{
    public static class ConfigManager
    {
        public static PlcConfig Plc { get; private set; }

        public static RobotConfig Robot { get; private set; }

        public static CameraConfig Camera { get; private set; }

        public static VisionConfig Vision { get; private set; }

        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Initialize.ini");

        public static void Load(string path = "Initialize.ini")
        {

            Plc = new PlcConfig
            {
                IP = INI.Read("PLC CONFIG", "IP", path),
                Port = int.Parse(INI.Read("PLC CONFIG", "Port", path)),
                Timeout = int.Parse(INI.Read("PLC CONFIG", "Timeout", path))
            };

            Robot = new RobotConfig
            {
                IP = INI.Read("ROBOT CONFIG", "IP", path),
                Port =int.Parse( INI.Read("ROBOT CONFIG", "Port", path)),
                Speed = double.Parse(INI.Read("ROBOT CONFIG", "Speed", path)),
                Accel = double.Parse(INI.Read("ROBOT CONFIG", "Accel", path)),
            };

            Camera = new CameraConfig
            {
                Exposure = double.Parse(INI.Read("CAMERA CONFIG", "Exposure", path)),
                Gain = double.Parse(INI.Read("CAMERA CONFIG", "Gain", path)),
                TriggerMode =  (INI.Read("CAMERA CONFIG", "TriggerMode", path)),
            };

            Vision = new VisionConfig
            {
                Score = double.Parse(INI.Read("VISION CONFIG", "Score", path)),
                AngleStart = double.Parse(INI.Read("VISION CONFIG", "AngleStart", path)),
                AngleEnd = double.Parse(INI.Read("VISION CONFIG", "AngleEnd", path)),

            };
        }

        public static void Save()
        {

            INI.Write("PLC CONFIG", "IP", Plc.IP, path);
            INI.Write("PLC CONFIG", "Port", Plc.Port.ToString(), path);
            INI.Write("PLC CONFIG", "Timeout", Plc.Timeout.ToString(), path);

            INI.Write("ROBOT CONFIG", "IP", Robot.IP, path);
            INI.Write("ROBOT CONFIG", "Port", Robot.Port.ToString(), path);
            INI.Write("ROBOT CONFIG", "Speed", Robot.Speed.ToString(), path);
            INI.Write("ROBOT CONFIG", "Accel", Robot.Accel.ToString(), path);
        }
    }
}
