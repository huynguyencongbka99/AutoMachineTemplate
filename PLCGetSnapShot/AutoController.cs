using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PLCGetSnapShot
{
    public class AutoController
    {
        string str = "";
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
                        str = ShowError.Invoke("Have something Wrong! Confirm!");
                        Logger.Log(LogCategory.PLC, "I am in PLC Wait Trigger!" + " click " + str);
                        _step = Step._5_inner;
                        break;

                    case Step._5_inner:
                        str = ShowError.Invoke("Have something Wrong! Confirm!  ");
                        Logger.Log(LogCategory.PLC, "I am in PLC Inner!"+ " click " + str);
                        _step = Step._15_TinhToan;
                        break;

                    case Step._15_TinhToan:
                        snap = _rbAbb.GetSnapshot();
                        
                        str = ShowError.Invoke("Have something Wrong! Confirm!");
                        Logger.Log(LogCategory.PLC, "I am in Tinh Toan! " + " click " + str);
                        if (str == "OK")
                            _step = Step._0_WaitTrigger;
                        else _step = Step._10_Capture;
                        break;
                    case Step._10_Capture:
                        break;
                }

                await Task.Delay(1000);
            }
        }
    }
}
