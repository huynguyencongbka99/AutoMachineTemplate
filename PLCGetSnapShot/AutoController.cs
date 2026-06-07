using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PLCGetSnapShot
{
    public class AutoController
    {
        public Func<string, string> ShowError;
        private readonly IPlcService _plc;
        private Step _step = Step._0_WaitTrigger;
        private ABBSocket _rbAbb;
        RobotSnapshot snap;
        public AutoController(IPlcService plc, ABBSocket rbAbb)
        {
            _plc = plc;
            _rbAbb = rbAbb;
        }

        public async Task Initialize()
        {

        }

        public async Task RunAsync()
        {
            while (true)
            {
                var input = _plc.GetSnapshot();

                switch (_step)
                {
                    case Step._0_WaitTrigger:
                        ShowError.Invoke("Have something Wrong! Confirm!");
                        if (input.X != null && input.X.Length >0)
                            if (input.X[0] == false)
                            {
                                _step = Step._5_inner;
                                Logger.Log(LogCategory.PLC, "I am in PLC Wait Trigger!");

                            }
                        _step = Step._5_inner;
                        break;

                    case Step._5_inner:
                        ShowError.Invoke("Have something Wrong! Confirm!");
                        if (input.X != null && input.X.Length > 0)
                            _step = Step._15_TinhToan;
                        _step = Step._15_TinhToan;
                        Logger.Log(LogCategory.PLC, "I am in PLC Inner!");
                        break;
                    case Step._15_TinhToan:
                        {
                            snap = _rbAbb.GetSnapshot();

                            if (snap.AlarmCode != 0)
                            {
                                ShowError.Invoke("Have something Wrong! Confirm!");
                                _step = Step._0_WaitTrigger;
                            }
                            _step = Step._0_WaitTrigger;
                        }
                        break;

                }

                await Task.Delay(1000);
            }
        }
    }
}
