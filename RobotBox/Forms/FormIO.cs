using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotBox
{
    public partial class frmIO : Form
    {
        //IPlcService plcService;
        PLCServiceXinjie plcXinjie;
        Button[] _btnX;
        Button[] _btnY;
        Button[] _btnM;

        Button[] _btnXjjX;
        Button[] _btnXjjY;
        Button[] _btnXjjM;
        public frmIO(PLCServiceXinjie _plcXinjie)
        {
            InitializeComponent();
            this.plcXinjie = _plcXinjie;
            
        }
        private void frmIO_Load(object sender, EventArgs e)
        {
            InitializeButton();
            tmrIO.Enabled = true;
        }

        private void tmrIO_Tick(object sender, EventArgs e)
        {
            
            var snapshotXinjie = plcXinjie.GetSnapshot(); 
            UpdateButtonsXjjX(snapshotXinjie.X);
            UpdateButtonsXjjY(snapshotXinjie.Y);
            UpdateButtonsXjjM(snapshotXinjie.M);
        }

        private void frmIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void InitializeButton()
        {
            _btnX = new Button[]{btnX0, btnX1, btnX2, btnX3, btnX4, btnX5, btnX6, btnX7};
            _btnY = new Button[] { btnY0, btnY1, btnY2, btnY3 };
            _btnM = new Button[] { btnM0, btnM1, btnM2, btnM3 };

            _btnXjjX = new Button[] { btnXjjX0, btnXjjX1, btnXjjX2, btnXjjX3, btnXjjX4, btnXjjX5, btnXjjX6, btnXjjX7 };
            _btnXjjY = new Button[] { btnXjjY0, btnXjjY1, btnXjjY2, btnXjjY3, btnXjjY4, btnXjjY5, btnXjjY6, btnXjjY7 };
            _btnXjjM = new Button[] { btnXjjM0, btnXjjM1, btnXjjM2, btnXjjM3 };
        }

        private void UpdateButtonsX(bool[] mData)
        {
            if (_btnX == null || mData == null)
                return;
            for (int i = 0; i < _btnX.Length; i++)
            {
                _btnX[i].BackColor =
                    mData[i]
                    ? Color.LimeGreen
                    : Color.DarkGray;
            }
        }
        private void UpdateButtonsY(bool[] mData)
        {
            if (_btnY == null || mData == null)
                return;
            for (int i = 0; i < _btnY.Length; i++)
            {
                _btnY[i].BackColor =
                    mData[i]
                    ? Color.LimeGreen
                    : Color.DarkGray;
            }
        }
        private void UpdateButtonsM(bool[] mData)
        {
            if (_btnM == null || mData == null)
                return;
            for (int i = 0; i < _btnM.Length; i++)
            {
                _btnM[i].BackColor =
                    mData[i]
                    ? Color.LimeGreen
                    : Color.DarkGray;
            }
        }
        private void UpdateButtonsXjjX(bool[] mData)
        {
            if (_btnXjjX == null || mData == null)
                return;
            for (int i = 0; i < _btnXjjX.Length; i++)
            {
                _btnXjjX[i].BackColor =
                    mData[i]
                    ? Color.LimeGreen
                    : Color.DarkGray;
            }
        }
        private void UpdateButtonsXjjY(bool[] mData)
        {
            if (_btnXjjY == null || mData == null)
                return;
            for (int i = 0; i < _btnXjjY.Length; i++)
            {
                _btnXjjY[i].BackColor =
                    mData[i]
                    ? Color.LimeGreen
                    : Color.DarkGray;
            }
        }
        private void UpdateButtonsXjjM(bool[] mData)
        {
            if (_btnXjjM == null || mData == null)
                return;
            for (int i = 0; i < _btnXjjM.Length; i++)
            {
                _btnXjjM[i].BackColor =
                    mData[i]
                    ? Color.LimeGreen
                    : Color.DarkGray;
            }
        }

        private void btnY0_Click(object sender, EventArgs e)
        {

        }

        private void btnY1_Click(object sender, EventArgs e)
        {

        }

        private void btnY2_Click(object sender, EventArgs e)
        {

        }

        private void btnY3_Click(object sender, EventArgs e)
        {

        }

        private void txtXjjD0_TextChanged(object sender, EventArgs e)
        {
            ushort.TryParse(txtD0.Text.ToString(), out ushort d0);
            plcXinjie.WriteD(0x00, d0);
        }

        private void txtXjjD1_TextChanged(object sender, EventArgs e)
        {
            ushort.TryParse(txtD1.Text.ToString(), out ushort d1);
            plcXinjie.WriteD(0x01, d1);
        }
    }
}
