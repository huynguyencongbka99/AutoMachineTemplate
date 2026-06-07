
namespace TaoFileINI_RECIPE
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.cbRecipe = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.listBoxRecipe = new System.Windows.Forms.ListBox();
            this.btnSelectRecipe = new System.Windows.Forms.Button();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtScore);
            this.groupBox1.Controls.Add(this.txtExposure);
            this.groupBox1.Controls.Add(this.cbRecipe);
            this.groupBox1.Location = new System.Drawing.Point(687, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(364, 183);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model Follow Combobox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Exposure";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(125, 127);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(176, 22);
            this.txtScore.TabIndex = 4;
            // 
            // txtExposure
            // 
            this.txtExposure.Location = new System.Drawing.Point(125, 75);
            this.txtExposure.Margin = new System.Windows.Forms.Padding(4);
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(176, 22);
            this.txtExposure.TabIndex = 5;
            // 
            // cbRecipe
            // 
            this.cbRecipe.FormattingEnabled = true;
            this.cbRecipe.Location = new System.Drawing.Point(125, 27);
            this.cbRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.cbRecipe.Name = "cbRecipe";
            this.cbRecipe.Size = new System.Drawing.Size(176, 24);
            this.cbRecipe.TabIndex = 3;
            this.cbRecipe.SelectedIndexChanged += new System.EventHandler(this.cbRecipe_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddRecipe);
            this.groupBox2.Controls.Add(this.listBoxRecipe);
            this.groupBox2.Controls.Add(this.btnSelectRecipe);
            this.groupBox2.Controls.Add(this.txtRecipeName);
            this.groupBox2.Controls.Add(this.lblModel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(687, 233);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(364, 351);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model Follow ListBox";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(244, 80);
            this.btnAddRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(112, 31);
            this.btnAddRecipe.TabIndex = 4;
            this.btnAddRecipe.Text = "Add Recipe";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // listBoxRecipe
            // 
            this.listBoxRecipe.FormattingEnabled = true;
            this.listBoxRecipe.ItemHeight = 16;
            this.listBoxRecipe.Location = new System.Drawing.Point(8, 135);
            this.listBoxRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxRecipe.Name = "listBoxRecipe";
            this.listBoxRecipe.Size = new System.Drawing.Size(347, 196);
            this.listBoxRecipe.TabIndex = 3;
            // 
            // btnSelectRecipe
            // 
            this.btnSelectRecipe.Location = new System.Drawing.Point(244, 27);
            this.btnSelectRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectRecipe.Name = "btnSelectRecipe";
            this.btnSelectRecipe.Size = new System.Drawing.Size(112, 31);
            this.btnSelectRecipe.TabIndex = 2;
            this.btnSelectRecipe.Text = "Select";
            this.btnSelectRecipe.UseVisualStyleBackColor = true;
            this.btnSelectRecipe.Click += new System.EventHandler(this.btnSelectRecipe_Click);
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Location = new System.Drawing.Point(11, 83);
            this.txtRecipeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(193, 22);
            this.txtRecipeName.TabIndex = 4;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(135, 39);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(48, 17);
            this.lblModel.TabIndex = 1;
            this.lblModel.Text = "_____";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Current Model:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(555, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.ComboBox cbRecipe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectRecipe;
        private System.Windows.Forms.ListBox listBoxRecipe;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Button btnSave;
    }
}

