namespace AutoMachine.Presentation.Winforms
{
    partial class FormIO
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
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.tmrIO = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Location = new System.Drawing.Point(268, 180);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(50, 16);
            this.lblSensor.TabIndex = 3;
            this.lblSensor.Text = "Sensor";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(268, 110);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(34, 16);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start";
            // 
            // tmrIO
            // 
            this.tmrIO.Tick += new System.EventHandler(this.tmrIO_Tick_1);
            // 
            // FormIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 416);
            this.Controls.Add(this.lblSensor);
            this.Controls.Add(this.lblStart);
            this.Name = "FormIO";
            this.Text = "FormIO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Timer tmrIO;
    }
}