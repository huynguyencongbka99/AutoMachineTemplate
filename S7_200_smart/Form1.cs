using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using S7.Net;
namespace S7_200_smart
{
    public partial class Form1 : Form
    {
        Plc plc = new Plc(CpuType.S7200Smart, "192.168.2.1", 0, 1);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                plc.Open();
            }
            catch(Exception ex) {
                MessageBox.Show($"{ex.Message}");
            }

            timer1.Enabled = true;

        }



        public void ReadDataBlock()
        {
            var dwords = plc.Read(DataType.DataBlock, 1, 0, VarType.DWord, 20);
            uint[] arr = (uint[])dwords;

            textBox1.Text = arr[0].ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            plc.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadDataBlock();
        }
    }
}
