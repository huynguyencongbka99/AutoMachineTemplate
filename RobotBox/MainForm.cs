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
    public partial class MainForm : Form
    {
        public static string user = "user";
        UserControl userform = new UserControl( user);

        ABBSocket robot = new ABBSocket();
        public MainForm()
        {
            InitializeComponent();

        }


        /// <summary>
        /// Điểm cần chú ý: giao thức TCP không đảm bảo mỗi lần ReadAsync() nhận đúng 1 message. 
        /// Trong thực tế ABB thường nên gửi ký tự kết thúc (\n) cho mỗi bản tin (RSP:ACK\n, EVT:DONE\n). Khi đó ReceiveLoop cần tách theo dòng (StreamReader.ReadLineAsync) để tránh trường hợp nhận "RSP:ACKEVT:DONE" trong cùng một gói tin. 
        /// Đây là phần mình sẽ bổ sung nếu bạn muốn xây dựng giao thức sản xuất thực tế.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void MainForm_Load(object sender, EventArgs e)
        {
            ABBSocket robot = new ABBSocket();

        }

        /*
                     * robot.RobotDone += () =>
            {
                Console.WriteLine("Robot Done");
            };

            robot.RobotBusy += () =>
            {
                Console.WriteLine("Robot Busy");
            };

            robot.RobotError += () =>
            {
                Console.WriteLine("Robot Error");
            };

            robot.ConnectionChanged += connected =>
            {
                Console.WriteLine(
                    $"Connected = {connected}");
            };

            --> SocketSend "RSP:ACK"
            (thực hiện gắp)
            --> SocketSend "EVT:BUSY"

            (chạy xong)

            --> SocketSend "EVT:DONE"
            */

        private async void btnSend_Click(object sender, EventArgs e)
        {
            bool ok =
                await robot.SendCommandAsync(
                    "CMD:MOVE_PICK");

            if (!ok)
            {
                Console.WriteLine("ACK Timeout");
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {

        }

        private void btnManual_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnIO_Click(object sender, EventArgs e)
        {

        }
    }
}
