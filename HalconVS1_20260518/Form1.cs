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


namespace HalconVS1_20260518
{
    public partial class Form1 : Form
    {
        private HTuple _acqHandle;
        private HObject _image;
        public Form1()
        {
            InitializeComponent();

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            OpenCamera();
            try
            {
                await GrabLoop();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void OpenCamera()
        {
            HOperatorSet.OpenFramegrabber(
            "GigEVision2",
            0,
            0,
            0,
            0,
            0,
            0,
            "default",
            -1,
            "default",
            -1,
            "false",
            "default",
            "default",
            0,
            -1,
            out _acqHandle);
        }

        private bool _running = true;

        private async Task GrabLoop()
        {
            while (_running)
            {
                HOperatorSet.GrabImageAsync(
                    out _image,
                    _acqHandle,
                    -1);

                Invoke(new Action(() =>
                {
                    hSmartWindowControl1.HalconWindow.ClearWindow();

                    hSmartWindowControl1.HalconWindow.DispObj(_image);
                }));

                await Task.Delay(10);
            }
        }
    }
}
