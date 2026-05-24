
namespace HalconVS2_202605120Calibration
{
    partial class Form1
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
            this.btnAddCalibrationPoint = new System.Windows.Forms.Button();
            this.txtRobotX = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageTheta = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtImageY = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtImageX = new System.Windows.Forms.TextBox();
            this.btnAddManual = new System.Windows.Forms.Button();
            this.txtRobotTheta = new System.Windows.Forms.TextBox();
            this.txtRobotY = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResultY = new System.Windows.Forms.TextBox();
            this.txtResultX = new System.Windows.Forms.TextBox();
            this.txtResultTheta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCalibrationPoint
            // 
            this.btnAddCalibrationPoint.Location = new System.Drawing.Point(26, 119);
            this.btnAddCalibrationPoint.Name = "btnAddCalibrationPoint";
            this.btnAddCalibrationPoint.Size = new System.Drawing.Size(132, 61);
            this.btnAddCalibrationPoint.TabIndex = 0;
            this.btnAddCalibrationPoint.Text = "Add CaliPoint";
            this.btnAddCalibrationPoint.UseVisualStyleBackColor = true;
            this.btnAddCalibrationPoint.Click += new System.EventHandler(this.btnAddCalibrationPoint_Click);
            // 
            // txtRobotX
            // 
            this.txtRobotX.Location = new System.Drawing.Point(335, 13);
            this.txtRobotX.Name = "txtRobotX";
            this.txtRobotX.Size = new System.Drawing.Size(95, 22);
            this.txtRobotX.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtImageTheta);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.txtImageY);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCalculate);
            this.panel1.Controls.Add(this.txtImageX);
            this.panel1.Controls.Add(this.btnAddManual);
            this.panel1.Controls.Add(this.txtRobotTheta);
            this.panel1.Controls.Add(this.btnAddCalibrationPoint);
            this.panel1.Controls.Add(this.txtRobotY);
            this.panel1.Controls.Add(this.txtRobotX);
            this.panel1.Location = new System.Drawing.Point(381, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 426);
            this.panel1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Angle Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Image Y";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(3, 203);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(495, 212);
            this.listBox1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Robot Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Robot Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Image X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Robot X";
            // 
            // txtImageTheta
            // 
            this.txtImageTheta.Location = new System.Drawing.Point(100, 72);
            this.txtImageTheta.Name = "txtImageTheta";
            this.txtImageTheta.Size = new System.Drawing.Size(95, 22);
            this.txtImageTheta.TabIndex = 4;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(436, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(62, 61);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtImageY
            // 
            this.txtImageY.Location = new System.Drawing.Point(100, 41);
            this.txtImageY.Name = "txtImageY";
            this.txtImageY.Size = new System.Drawing.Size(95, 22);
            this.txtImageY.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(436, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 61);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(164, 119);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(132, 61);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtImageX
            // 
            this.txtImageX.Location = new System.Drawing.Point(100, 13);
            this.txtImageX.Name = "txtImageX";
            this.txtImageX.Size = new System.Drawing.Size(95, 22);
            this.txtImageX.TabIndex = 5;
            // 
            // btnAddManual
            // 
            this.btnAddManual.Location = new System.Drawing.Point(298, 119);
            this.btnAddManual.Name = "btnAddManual";
            this.btnAddManual.Size = new System.Drawing.Size(132, 61);
            this.btnAddManual.TabIndex = 0;
            this.btnAddManual.Text = "Add Manual";
            this.btnAddManual.UseVisualStyleBackColor = true;
            this.btnAddManual.Click += new System.EventHandler(this.btnAddManual_Click);
            // 
            // txtRobotTheta
            // 
            this.txtRobotTheta.Location = new System.Drawing.Point(335, 72);
            this.txtRobotTheta.Name = "txtRobotTheta";
            this.txtRobotTheta.Size = new System.Drawing.Size(95, 22);
            this.txtRobotTheta.TabIndex = 1;
            // 
            // txtRobotY
            // 
            this.txtRobotY.Location = new System.Drawing.Point(335, 41);
            this.txtRobotY.Name = "txtRobotY";
            this.txtRobotY.Size = new System.Drawing.Size(95, 22);
            this.txtRobotY.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(233, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(87, 35);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Result X";
            // 
            // txtResultY
            // 
            this.txtResultY.Location = new System.Drawing.Point(220, 94);
            this.txtResultY.Name = "txtResultY";
            this.txtResultY.Size = new System.Drawing.Size(142, 22);
            this.txtResultY.TabIndex = 4;
            // 
            // txtResultX
            // 
            this.txtResultX.Location = new System.Drawing.Point(220, 66);
            this.txtResultX.Name = "txtResultX";
            this.txtResultX.Size = new System.Drawing.Size(142, 22);
            this.txtResultX.TabIndex = 5;
            // 
            // txtResultTheta
            // 
            this.txtResultTheta.Location = new System.Drawing.Point(220, 122);
            this.txtResultTheta.Name = "txtResultTheta";
            this.txtResultTheta.Size = new System.Drawing.Size(142, 22);
            this.txtResultTheta.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Theta";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(177, 215);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(87, 35);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResultTheta);
            this.Controls.Add(this.txtResultY);
            this.Controls.Add(this.txtResultX);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddCalibrationPoint;
        private System.Windows.Forms.TextBox txtRobotX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRobotY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResultY;
        private System.Windows.Forms.TextBox txtResultX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImageY;
        private System.Windows.Forms.TextBox txtImageX;
        private System.Windows.Forms.Button btnAddManual;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImageTheta;
        private System.Windows.Forms.TextBox txtRobotTheta;
        private System.Windows.Forms.TextBox txtResultTheta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnVerify;
    }
}

