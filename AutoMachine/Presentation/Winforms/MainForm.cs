using AutoMachine.Application.Models;
using AutoMachine.Application.Services;
using AutoMachine.Core.Controllers;
using AutoMachine.Core.Enums;
using AutoMachine.Infrastructure.PLC;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AutoMachine.Presentation.Winforms
{
    public partial class MainForm : Form
    {
        private UIService _uiService;
        private AutoController _controller;
        private readonly Queue<LogItem> _runtimeLogs = new Queue<LogItem>();
        private static bool _isAutoRunning = false;
        private IPlcService _iplcService;
        FormIO _frmIO;
        public MainForm()
        {
            InitializeComponent();
            Logger.OnLogReceived += Logger_OnLogReceived;

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

            // filter example
            var lines = _runtimeLogs
                .Select(x => x.ToString())
                .ToArray();

            txtLogs.Lines = lines;

            // scroll xuống cuối
            txtLogs.SelectionStart = txtLogs.Text.Length;
            txtLogs.ScrollToCaret();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_isAutoRunning == false)
            {
                _isAutoRunning = true;
                await _controller.Start();
                Logger.Log(
                    LogCategory.UI,
                    "Operator Click START");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_isAutoRunning == true)
            {
                _isAutoRunning = false;
                _controller?.Stop();
            }
            Logger.Log(
                LogCategory.PLC,
                "Operator Click STOP");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Logger.Log(
                LogCategory.PLC,
                "Operator Click RESET");
        }

        private Task<MachineAction> ShowErrorAsync(string message, int timeoutMs)
        {
            var tcs = new TaskCompletionSource<MachineAction>();

            this.BeginInvoke(new Action(() =>
            {
                var form = new ErrorForm(message);

                //  bật buzzer + tower
                PLC.Write("BUZZER", true);
                PLC.Write("RED_LIGHT", true);

                var timer = new System.Windows.Forms.Timer();
                timer.Interval = timeoutMs;

                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    form.Close();

                    PLC.Write("BUZZER", false);
                    PLC.Write("RED_LIGHT", false);

                    tcs.TrySetResult(MachineAction.Timeout);
                };

                timer.Start();

                form.OnResult = (result) =>
                {
                    timer.Stop();
                    form.Close();

                    PLC.Write("BUZZER", false);
                    PLC.Write("RED_LIGHT", false);

                    tcs.TrySetResult(result);
                };

                form.Show(); // non-modal
            }));

            return tcs.Task;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _uiService = new UIService();
            _iplcService = new PlcService();

            _uiService.OnShowErrorAsync += ShowErrorAsync;
            _controller = new AutoController(_uiService);

            _frmIO = new FormIO(_iplcService);
            _iplcService.Start();
        }

        private void btnIO_Click(object sender, EventArgs e)
        {
            _frmIO.Show();
        }
    }
}
