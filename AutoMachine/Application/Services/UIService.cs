using System;
using System.Threading.Tasks;
using AutoMachine.Core.Enums;

namespace AutoMachine.Application.Services
{
    public class UIService
    {
        public Func<string, int, Task<MachineAction>> OnShowErrorAsync;

        public async Task<MachineAction> ShowErrorAsync(string message, int timeoutMs)
        {
            if (OnShowErrorAsync != null)
                return await OnShowErrorAsync.Invoke(message, timeoutMs);

            return MachineAction.Stop;
        }
    }
}
