using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;

namespace TaoFileINI
{
    public partial class MainForm : Form
    {
        string path;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cấu hình config này không truyền được tham số
            // Do vậy không thể làm đổi model được
            // Phải thêm tham số truyền vào thì mới có thể làm các thao tác đọc, ghi được
            ConfigManager.Load();

            txtPlcIp.Text = ConfigManager.Plc.IP;
            txtPlcPort.Text = ConfigManager.Plc.Port.ToString();
        }

        private void cbRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRecipe.SelectedItem == null)
                return;

            string modelName = cbRecipe.SelectedItem.ToString();

            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelName +".ini");    // hoặc Application.StartupPath
           // string iniPath = Path.Combine(baseDir, modelName, modelName + ".ini");

            if (!File.Exists(baseDir))
            {
                MessageBox.Show("Không tìm thấy file model:\n" + baseDir, "Lỗi");
                return;
            }

            ConfigManager.Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigManager.Plc.IP = txtPlcIp.Text;
            ConfigManager.Plc.Port = int.Parse(txtPlcPort.Text);

            ConfigManager.Save();
        }
    }
}
