using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PLCGetSnapShot
{
    public class AutoController
    {
        private readonly IPlcService _plc;
        private Step _step = Step.WaitTrigger;

        public AutoController(IPlcService plc)
        {
            _plc = plc;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                var input = _plc.GetSnapshot();

                switch (_step)
                {
                    case Step.WaitTrigger:
                        if(input.X != null && input.X.Length >0)
                            if (input.X[0] == false)
                            {
                                _step = Step.inner;
                            }
                        break;

                    case Step.inner:
                        if (input.X != null && input.X.Length > 0)
                            _step = Step.WaitTrigger;
                        break;
                }

                await Task.Delay(10);
            }
        }
    }
}
