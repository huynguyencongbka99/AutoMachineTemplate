using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCGetSnapShot
{
    public partial class MainForm : Form
    {
        AutoController _controller;
        IPlcService _iplcService;
        PLCServiceXinjie serviceXinjie;
        frmIO _frmIO;
        public MainForm()
        {
            InitializeComponent();

        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            
            _iplcService = new PlcServiceDelta("192.168.0.11", 502);
            _iplcService.Start();

            serviceXinjie = new PLCServiceXinjie(serialPort1);
            serviceXinjie.Start();

            _frmIO = new frmIO(_iplcService, serviceXinjie);
            
            _controller = new AutoController(_iplcService);
            try
            {
                await _controller.RunAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrUI.Stop(); 
        }

        private void frmIO_Click(object sender, EventArgs e)
        {
            if (_frmIO != null)
            { 
                _frmIO.Show();
                _frmIO.BringToFront();
            }
        }
    }
}
