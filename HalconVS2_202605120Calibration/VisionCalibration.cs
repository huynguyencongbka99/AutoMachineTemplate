using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace HalconVS2_202605120Calibration
{
    public class VisionCalibration
    {
        //-----------------------------------
        // POINTS
        //-----------------------------------

        public List<CalibPoint> Points =
            new List<CalibPoint>();

        //-----------------------------------
        // MATRIX
        //-----------------------------------

        public HTuple HomMat2D;

        //-----------------------------------
        // THETA
        //-----------------------------------

        public double ThetaOffset = 0;

        //-----------------------------------
        // CLEAR
        //-----------------------------------

        public void Clear()
        {
            Points.Clear();
        }

        //-----------------------------------
        // ADD POINT
        //-----------------------------------

        public void AddPoint(
            double imageX,
            double imageY,
            double imageTheta,

            double robotX,
            double robotY,
            double robotTheta)
        {
            Points.Add(new CalibPoint()
            {
                ImageX = imageX,
                ImageY = imageY,
                ImageTheta = imageTheta,

                RobotX = robotX,
                RobotY = robotY,
                RobotTheta = robotTheta
            });
        }

        //-----------------------------------
        // CALCULATE
        //-----------------------------------

        public bool Calculate()
        {
            try
            {
                int n = Points.Count;

                //-----------------------------------
                // ARRAY
                //-----------------------------------

                double[] imgX = new double[n];
                double[] imgY = new double[n];

                double[] robX = new double[n];
                double[] robY = new double[n];

                //-----------------------------------
                // COPY
                //-----------------------------------

                for (int i = 0; i < n; i++)
                {
                    imgX[i] =
                        Points[i].ImageX;

                    imgY[i] =
                        Points[i].ImageY;

                    robX[i] =
                        Points[i].RobotX;

                    robY[i] =
                        Points[i].RobotY;
                }

                //-----------------------------------
                // HTUPLE
                //-----------------------------------

                HTuple imageX =
                    new HTuple(imgX);

                HTuple imageY =
                    new HTuple(imgY);

                HTuple robotX =
                    new HTuple(robX);

                HTuple robotY =
                    new HTuple(robY);

                //-----------------------------------
                // CALIBRATION
                //-----------------------------------

                HOperatorSet.VectorToHomMat2d(
                    imageX,
                    imageY,
                    robotX,
                    robotY,
                    out HomMat2D);

                //-----------------------------------
                // THETA
                //-----------------------------------

                double total = 0;

                foreach (var p in Points)
                {
                    total +=
                        p.RobotTheta
                        + p.ImageTheta;
                }

                ThetaOffset =
                    total / n;

                return true;
            }
            catch
            {
                return false;
            }
        }



        //-----------------------------------
        // IMAGE -> ROBOT
        //-----------------------------------

        public bool ImageToRobot(
            double imageX,
            double imageY,

            out double robotX,
            out double robotY)
        {
            robotX = 0;
            robotY = 0;

            try
            {
                HTuple x;
                HTuple y;

                HOperatorSet.AffineTransPoint2d(
                    HomMat2D,
                    imageX,
                    imageY,
                    out x,
                    out y);

                robotX = x.D;
                robotY = y.D;

                return true;
            }
            catch
            {
                return false;
            }
        }

        //-----------------------------------
        // THETA
        //-----------------------------------

        public double ImageThetaToRobotTheta(
            double imageTheta)
        {
            return
                -imageTheta
                + ThetaOffset;
        }
    }
}
