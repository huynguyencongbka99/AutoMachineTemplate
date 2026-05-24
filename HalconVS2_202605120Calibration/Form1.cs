using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
namespace HalconVS2_202605120Calibration
{


    public partial class Form1 : Form
    {

        private VisionCalibration calib = new VisionCalibration();

        private HTuple modelID;

        //private HFramegrabber camera;


        public Form1()
        {
            InitializeComponent();

        }

        private bool FindMark(HImage image,out double imageX,out double imageY,out double imageTheta)
        {
            imageX = 0;
            imageY = 0;
            imageTheta = 0;

            try
            {
                HTuple rows;
                HTuple cols;
                HTuple angles;
                HTuple scores;

                HOperatorSet.FindShapeModel(
                    image,
                    modelID,
                    -0.39,
                    0.78,
                    0.5,
                    1,
                    0.5,
                    "least_squares",
                    0,
                    0.8,
                    out rows,
                    out cols,
                    out angles,
                    out scores);

                if (scores.Length <= 0)
                {
                    MessageBox.Show(
                        "Find NG");

                    return false;
                }

                //-----------------------------------
                // HALCON
                //-----------------------------------

                imageX = cols[0].D;
                imageY = rows[0].D;

                //-----------------------------------
                // RADIAN
                //-----------------------------------

                imageTheta = angles[0].D;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString());

                return false;
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool ok = calib.Calculate();

            if (ok)
            {
                MessageBox.Show(
                    "Calibration OK");
            }
            else
            {
                MessageBox.Show(
                    "Calibration Fail");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //-----------------------------------
            // IMAGE
            //-----------------------------------

            double imageX =
                double.Parse(txtImageX.Text);

            double imageY =
                double.Parse(txtImageY.Text);

            double imageTheta =
                double.Parse(txtImageTheta.Text);

            //-----------------------------------
            // XY
            //-----------------------------------

            double robotX;
            double robotY;

            bool ok =
                calib.ImageToRobot(
                    imageX,
                    imageY,
                    out robotX,
                    out robotY);

            if (!ok)
            {
                MessageBox.Show(
                    "Transform NG");

                return;
            }

            //-----------------------------------
            // THETA
            //-----------------------------------

            double robotTheta =
                calib.ImageThetaToRobotTheta(
                    imageTheta);

            //-----------------------------------
            // RESULT
            //-----------------------------------

            txtResultX.Text =
                robotX.ToString("F3");

            txtResultY.Text =
                robotY.ToString("F3");

            txtResultTheta.Text =
                robotTheta.ToString("F3");
        }

        private void btnAddCalibrationPoint_Click(object sender, EventArgs e)
        {
            double imageX =
                double.Parse(txtImageX.Text);

            double imageY =
                double.Parse(txtImageY.Text);

            double imageTheta =
                double.Parse(txtImageTheta.Text);

            double robotX =
                double.Parse(txtRobotX.Text);

            double robotY =
                double.Parse(txtRobotY.Text);

            double robotTheta =
                double.Parse(txtRobotTheta.Text);

            //-----------------------------------
            // ADD
            //-----------------------------------

            calib.AddPoint(
                imageX,
                imageY,
                imageTheta,

                robotX,
                robotY,
                robotTheta);

            //-----------------------------------
            // UI
            //-----------------------------------

            listBox1.Items.Add(
                calib.Points[
                    calib.Points.Count - 1]);

        }

        private void btnAddManual_Click(object sender, EventArgs e)
        {
            // Row 1
            calib.AddPoint(153.2, 118.7, 0, 0, 0, 0);
            calib.AddPoint(251.8, 116.2, 0, 10, 0, 0);
            calib.AddPoint(351.1, 114.8, 0, 20, 0, 0);
            calib.AddPoint(450.9, 115.6, 0, 30, 0, 0);

            // Row 2
            calib.AddPoint(452.1, 215.3, 0, 30, 10, 0);
            calib.AddPoint(353.5, 217.2, 0, 20, 10, 0);
            calib.AddPoint(254.7, 218.9, 0, 10, 10, 0);
            calib.AddPoint(155.6, 220.8, 0, 0, 10, 0);

            // Row 3
            calib.AddPoint(158.1, 320.5, 0, 0, 20, 0);
            calib.AddPoint(257.0, 318.2, 0, 10, 20, 0);
            calib.AddPoint(355.9, 316.4, 0, 20, 20, 0);
            calib.AddPoint(454.6, 314.7, 0, 30, 20, 0);

            // Row 4
            calib.AddPoint(456.2, 416.8, 0, 30, 30, 0);
            calib.AddPoint(356.8, 417.9, 0, 20, 30, 0);
            calib.AddPoint(255.1, 418.4, 0, 10, 30, 0);
            calib.AddPoint(153.4, 416.9, 0, 0, 30, 0);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                //-----------------------------------
                // HTUPLE
                //-----------------------------------

                HTuple imageX = new HTuple();
                HTuple imageY = new HTuple();

                HTuple robotX = new HTuple();
                HTuple robotY = new HTuple();

                //-----------------------------------
                // IMAGE POINTS
                //-----------------------------------

                imageX[0] = 100.0;
                imageY[0] = 100.0;

                imageX[1] = 200.0;
                imageY[1] = 100.0;

                imageX[2] = 100.0;
                imageY[2] = 200.0;

                imageX[3] = 200.0;
                imageY[3] = 200.0;

                //-----------------------------------
                // ROBOT POINTS
                //-----------------------------------

                robotX[0] = 0.0;
                robotY[0] = 0.0;

                robotX[1] = 100.0;
                robotY[1] = 0.0;

                robotX[2] = 0.0;
                robotY[2] = 100.0;

                robotX[3] = 100.0;
                robotY[3] = 100.0;

                //-----------------------------------
                // CALIBRATION
                //-----------------------------------

                HTuple homMat2D;

                HOperatorSet.VectorToHomMat2d(
                    imageX,
                    imageY,
                    robotX,
                    robotY,
                    out homMat2D);

                //-----------------------------------
                // TEST POINT
                //-----------------------------------

                HTuple rx;
                HTuple ry;

                HOperatorSet.AffineTransPoint2d(
                    homMat2D,

                    150.0,
                    150.0,

                    out rx,
                    out ry);

                //-----------------------------------
                // SHOW
                //-----------------------------------

                MessageBox.Show(
                    $"RobotX = {rx.D:F3}\n" +
                    $"RobotY = {ry.D:F3}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString());
            }
        }
    }
}
