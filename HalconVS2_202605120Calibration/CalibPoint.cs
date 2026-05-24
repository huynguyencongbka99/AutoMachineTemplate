using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconVS2_202605120Calibration
{
    public class CalibPoint
    {
        //-----------------------------------
        // IMAGE
        //-----------------------------------

        public double ImageX { get; set; }
        public double ImageY { get; set; }

        // RADIAN
        public double ImageTheta { get; set; }

        //-----------------------------------
        // ROBOT
        //-----------------------------------

        public double RobotX { get; set; }
        public double RobotY { get; set; }

        // DEGREE
        public double RobotTheta { get; set; }

        public override string ToString()
        {
            return
                $"Img({ImageX:F2}," +
                $"{ImageY:F2}," +
                $"{ImageTheta:F3}) -> " +

                $"Robot({RobotX:F2}," +
                $"{RobotY:F2}," +
                $"{RobotTheta:F2})";
        }
    }
}