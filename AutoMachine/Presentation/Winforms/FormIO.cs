using AutoMachine.Application.Services;
using AutoMachine.Infrastructure.PLC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMachine.Presentation.Winforms
{
    public partial class FormIO : Form
    {
        IPlcService plc;

        public static int i = 0;
        public FormIO(IPlcService _plc)
        {
            InitializeComponent();
            this.plc = _plc;
            tmrIO.Enabled = true;
        }

        private void tmrIO_Tick_1(object sender, EventArgs e)
        {
            var input = plc.GetSnapshot();

            lblStart.Text = input.Start.ToString() + $"{i}";
            lblSensor.Text = input.SensorIn.ToString() + $"{i}";
            i++;
        }
    }
}
