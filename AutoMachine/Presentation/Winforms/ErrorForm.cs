using AutoMachine.Core.Enums;
using System;
using System.Windows.Forms;

namespace AutoMachine.Presentation.Winforms
{
    public partial class ErrorForm : Form
    {
        public Action<MachineAction> OnResult;
        public ErrorForm(string message)
        {

            InitializeComponent();
            lblMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OnResult?.Invoke(MachineAction.Continue);
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            OnResult?.Invoke(MachineAction.Retry);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnResult?.Invoke(MachineAction.Stop);
        }
    }
}
