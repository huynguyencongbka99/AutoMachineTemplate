using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDialogue
{
    public partial class MainForm : Form
    {
        FormDialogue frmdia = new FormDialogue();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            frmdia.ShowDialog();
            if (frmdia.DialogResult == DialogResult.OK)
                MessageBox.Show("Very OK");
            else if (frmdia.DialogResult == DialogResult.Retry)
                MessageBox.Show("Very Retry");
            else if (frmdia.DialogResult == DialogResult.Cancel)
                MessageBox.Show("Very Cancel");
        }
    }
}
