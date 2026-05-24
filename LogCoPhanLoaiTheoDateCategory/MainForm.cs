using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogCoPhanLoaiTheoDateCategory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Log(LogCategory.Vision,"Pattern Match OK");
            Logger.Log(LogCategory.Robot,"Move P1 -> P2");
            Logger.Log(LogCategory.PLC,"Read M100 = TRUE");
            Logger.Log(LogCategory.Alarm,"Emergency Stop");
        }
    }
}
