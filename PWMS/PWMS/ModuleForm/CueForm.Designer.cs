namespace PWMS.ModuleForm
{
    partial class CueForm
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCue = new System.Windows.Forms.CheckBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.nud);
            this.grp.Controls.Add(this.label1);
            this.grp.Location = new System.Drawing.Point(12, 12);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(260, 136);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            this.grp.Text = "设置提示时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "天";
            // 
            // nud
            // 
            this.nud.Location = new System.Drawing.Point(86, 56);
            this.nud.Name = "nud";
            this.nud.Size = new System.Drawing.Size(120, 21);
            this.nud.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "提前：";
            // 
            // chkCue
            // 
            this.chkCue.AutoSize = true;
            this.chkCue.Location = new System.Drawing.Point(12, 184);
            this.chkCue.Name = "chkCue";
            this.chkCue.Size = new System.Drawing.Size(84, 16);
            this.chkCue.TabIndex = 1;
            this.chkCue.Text = "信息提示框";
            this.chkCue.UseVisualStyleBackColor = true;
            this.chkCue.CheckedChanged += new System.EventHandler(this.chkCue_CheckedChanged);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(102, 180);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(197, 180);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // CueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 226);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.chkCue);
            this.Controls.Add(this.grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CueForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CueForm";
            this.Load += new System.EventHandler(this.CueForm_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCue;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnQuit;
    }
}