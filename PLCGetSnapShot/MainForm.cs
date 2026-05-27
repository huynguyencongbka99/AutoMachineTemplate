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
        private readonly Queue<LogItem> _runtimeLogs = new Queue<LogItem>();
        public MainForm()
        {
            InitializeComponent();
            Logger.OnLogReceived += Logger_OnLogReceived;

        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            
            //_iplcService = new PlcServiceDelta("192.168.0.11", 502);
            _iplcService = new PlcServiceFX5U("192.168.0.10", 502);
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

        private void Logger_OnLogReceived(LogItem item)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    AddLogToUI(item);
                }));
                
                return;
            }
            AddLogToUI(item);
        }

        private void AddLogToUI(LogItem item)
        {
            // giữ tối đa 100 dòng
            if (_runtimeLogs.Count >= 100)
            {
                _runtimeLogs.Dequeue();
            }

            _runtimeLogs.Enqueue(item);


            string line = item.ToString();


            // scroll xuống cuối
            
            lstLogs.Items.Add(line);
            lstLogs.TopIndex = lstLogs.Items.Count - 1;

            // TextBox
            txtLogs.AppendText(line + Environment.NewLine);
            // scroll xuống cuối
            txtLogs.SelectionStart = txtLogs.Text.Length;
            txtLogs.ScrollToCaret();
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
