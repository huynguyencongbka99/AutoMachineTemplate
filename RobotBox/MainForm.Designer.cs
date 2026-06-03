
namespace RobotBox
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
            this.pnManu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnIO = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.rtb上位机和机械手 = new System.Windows.Forms.RichTextBox();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.pnManu.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnManu
            // 
            this.pnManu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnManu.Controls.Add(this.btnAuto);
            this.pnManu.Controls.Add(this.btnManual);
            this.pnManu.Controls.Add(this.btnSetting);
            this.pnManu.Controls.Add(this.btnIO);
            this.pnManu.Controls.Add(this.button1);
            this.pnManu.Location = new System.Drawing.Point(0, 100);
            this.pnManu.Margin = new System.Windows.Forms.Padding(0);
            this.pnManu.Name = "pnManu";
            this.pnManu.Size = new System.Drawing.Size(200, 600);
            this.pnManu.TabIndex = 1;
            // 
            // btnIO
            // 
            this.btnIO.Location = new System.Drawing.Point(0, 243);
            this.btnIO.Margin = new System.Windows.Forms.Padding(0);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(198, 81);
            this.btnIO.TabIndex = 0;
            this.btnIO.Text = "IO";
            this.btnIO.UseVisualStyleBackColor = true;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(0, 0);
            this.btnAuto.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(198, 81);
            this.btnAuto.TabIndex = 0;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(0, 81);
            this.btnManual.Margin = new System.Windows.Forms.Padding(0);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(198, 81);
            this.btnManual.TabIndex = 0;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(0, 162);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(198, 81);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 324);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 274);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.rtb上位机和机械手);
            this.pnHeader.Controls.Add(this.btnSend);
            this.pnHeader.Location = new System.Drawing.Point(2, -1);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1203, 100);
            this.pnHeader.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(236, 32);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(101, 30);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send Command";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnMain
            // 
            this.pnMain.Location = new System.Drawing.Point(203, 100);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1002, 607);
            this.pnMain.TabIndex = 7;
            // 
            // rtb上位机和机械手
            // 
            this.rtb上位机和机械手.Location = new System.Drawing.Point(367, 3);
            this.rtb上位机和机械手.Name = "rtb上位机和机械手";
            this.rtb上位机和机械手.Size = new System.Drawing.Size(226, 92);
            this.rtb上位机和机械手.TabIndex = 0;
            this.rtb上位机和机械手.Text = "";
            // 
            // pnFooter
            // 
            this.pnFooter.Location = new System.Drawing.Point(2, 703);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1203, 91);
            this.pnFooter.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1204, 796);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.pnManu);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Robot Box";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnManu.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pnManu;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnIO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtb上位机和机械手;
    }
}

