using AutoMachine.Application.Models;
using AutoMachine.Application.Services;
using AutoMachine.Core.Enums;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AutoMachine.Core.Controllers
{
    public class AutoController
    {
        private readonly UIService _ui;
        //private Thread _thread;
        private bool _running;
        private int _step = 0;
        //private Task _task;

        public AutoController(UIService ui)
        {
            _ui = ui;
        }

        public async Task Start()
        {
            _running = true;
            //_thread = new Thread(async () => await Run());
            //_thread.IsBackground = true;
            //_thread.Start();
             await Task.Run(Run);
        }

        public void Stop()
        {
            _running = false;
        }

        private async Task Run()
        {
            while (_running)
            {
                switch (_step)
                {
                    case 0:
                        var action = await _ui.ShowErrorAsync("Scan barcode failed!", 10000);

                        switch (action)
                        {
                            case MachineAction.Continue:
                                _step = 1;
                                Logger.Log(LogCategory.Alarm, "Continue Click!");
                                break;

                            case MachineAction.Retry:
                                Logger.Log(LogCategory.Alarm, "Retry Click!");
                                break;

                            case MachineAction.Stop:
                                Logger.Log(LogCategory.Alarm, "Stop Click!");
                                _running = false;
                                break;

                            case MachineAction.Timeout:
                                Logger.Log(LogCategory.Alarm, "Timeout!");
                                _running = false;
                                break;
                        }
                        break;

                    case 1:
                        // normal run
                        _step = 0;
                        Logger.Log(LogCategory.PLC,"Waitting Sensor...");
                        break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
