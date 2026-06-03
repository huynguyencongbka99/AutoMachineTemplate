using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotBox
{
    public partial class MainForm : Form
    {
        public static string user = "user";
        UserControl userform = new UserControl( user);
        
        ABBSocket _abbSocket = new ABBSocket();
        public MainForm()
        {
            InitializeComponent();

        }




        private async void MainForm_Load(object sender, EventArgs e)
        {
            //await _abbSocket.StartAsync("192.168.192.1", 5000);
            await _abbSocket.StartAsync("localhost", 5000);

        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            var line = _abbSocket.SendCommand("Send to Server\n");
            rtb上位机和机械手.AppendText(line + Environment.NewLine);
            // scroll xuống cuối
            rtb上位机和机械手.SelectionStart = rtb上位机和机械手.Text.Length;
            rtb上位机和机械手.ScrollToCaret();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {

        }

        private void btnManual_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnIO_Click(object sender, EventArgs e)
        {

        }
    }
}
