namespace PLCGetSnapShot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrUI = new System.Windows.Forms.Timer(this.components);
            this.frmIO = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.txtLogs = new System.Windows.Forms.RichTextBox();
            this.btnSendRobot = new System.Windows.Forms.Button();
            this.lstReceiveFromRobot = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // frmIO
            // 
            this.frmIO.Location = new System.Drawing.Point(264, 12);
            this.frmIO.Name = "frmIO";
            this.frmIO.Size = new System.Drawing.Size(127, 56);
            this.frmIO.TabIndex = 2;
            this.frmIO.Text = "IO Form";
            this.frmIO.UseVisualStyleBackColor = true;
            this.frmIO.Click += new System.EventHandler(this.frmIO_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            this.serialPort1.PortName = "COM5";
            // 
            // lstLogs
            // 
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.ItemHeight = 16;
            this.lstLogs.Location = new System.Drawing.Point(397, 12);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(391, 196);
            this.lstLogs.TabIndex = 4;
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(397, 215);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(391, 223);
            this.txtLogs.TabIndex = 5;
            this.txtLogs.Text = "";
            // 
            // btnSendRobot
            // 
            this.btnSendRobot.Location = new System.Drawing.Point(12, 182);
            this.btnSendRobot.Name = "btnSendRobot";
            this.btnSendRobot.Size = new System.Drawing.Size(93, 37);
            this.btnSendRobot.TabIndex = 6;
            this.btnSendRobot.Text = "Send Robot";
            this.btnSendRobot.UseVisualStyleBackColor = true;
            this.btnSendRobot.Click += new System.EventHandler(this.btnSendRobot_Click);
            // 
            // lstReceiveFromRobot
            // 
            this.lstReceiveFromRobot.FormattingEnabled = true;
            this.lstReceiveFromRobot.ItemHeight = 16;
            this.lstReceiveFromRobot.Location = new System.Drawing.Point(12, 242);
            this.lstReceiveFromRobot.Name = "lstReceiveFromRobot";
            this.lstReceiveFromRobot.Size = new System.Drawing.Size(379, 164);
            this.lstReceiveFromRobot.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstReceiveFromRobot);
            this.Controls.Add(this.btnSendRobot);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.lstLogs);
            this.Controls.Add(this.frmIO);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrUI;
        private System.Windows.Forms.Button frmIO;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.RichTextBox txtLogs;
        private System.Windows.Forms.Button btnSendRobot;
        private System.Windows.Forms.ListBox lstReceiveFromRobot;
    }
}

