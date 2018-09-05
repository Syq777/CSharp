namespace PWMS.ModuleForm
{
    partial class BackupRestoreDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupRestoreDataForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageBackup = new System.Windows.Forms.TabPage();
            this.btnQuit1 = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.txtDefault = new System.Windows.Forms.TextBox();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.rdoDefault = new System.Windows.Forms.RadioButton();
            this.pageRestore = new System.Windows.Forms.TabPage();
            this.btnQuit2 = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRestorePath = new System.Windows.Forms.Button();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.pageBackup.SuspendLayout();
            this.pageRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageBackup);
            this.tabControl.Controls.Add(this.pageRestore);
            this.tabControl.Location = new System.Drawing.Point(12, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(285, 160);
            this.tabControl.TabIndex = 0;
            // 
            // pageBackup
            // 
            this.pageBackup.Controls.Add(this.btnQuit1);
            this.pageBackup.Controls.Add(this.btnBackup);
            this.pageBackup.Controls.Add(this.btnBackupPath);
            this.pageBackup.Controls.Add(this.txtOther);
            this.pageBackup.Controls.Add(this.txtDefault);
            this.pageBackup.Controls.Add(this.rdoOther);
            this.pageBackup.Controls.Add(this.rdoDefault);
            this.pageBackup.Location = new System.Drawing.Point(4, 22);
            this.pageBackup.Name = "pageBackup";
            this.pageBackup.Padding = new System.Windows.Forms.Padding(3);
            this.pageBackup.Size = new System.Drawing.Size(277, 134);
            this.pageBackup.TabIndex = 0;
            this.pageBackup.Text = "备份数据库";
            this.pageBackup.UseVisualStyleBackColor = true;
            // 
            // btnQuit1
            // 
            this.btnQuit1.Location = new System.Drawing.Point(186, 105);
            this.btnQuit1.Name = "btnQuit1";
            this.btnQuit1.Size = new System.Drawing.Size(75, 23);
            this.btnQuit1.TabIndex = 6;
            this.btnQuit1.Text = "取消";
            this.btnQuit1.UseVisualStyleBackColor = true;
            this.btnQuit1.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(95, 105);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBackupPath.BackgroundImage")));
            this.btnBackupPath.Location = new System.Drawing.Point(221, 59);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(25, 23);
            this.btnBackupPath.TabIndex = 4;
            this.btnBackupPath.UseVisualStyleBackColor = true;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(95, 61);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(120, 21);
            this.txtOther.TabIndex = 3;
            this.txtOther.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtDefault
            // 
            this.txtDefault.Location = new System.Drawing.Point(95, 16);
            this.txtDefault.Name = "txtDefault";
            this.txtDefault.ReadOnly = true;
            this.txtDefault.Size = new System.Drawing.Size(151, 21);
            this.txtDefault.TabIndex = 2;
            this.txtDefault.Text = "\\bar";
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(17, 61);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(71, 16);
            this.rdoOther.TabIndex = 1;
            this.rdoOther.Text = "其他路径";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // rdoDefault
            // 
            this.rdoDefault.AutoSize = true;
            this.rdoDefault.Checked = true;
            this.rdoDefault.Location = new System.Drawing.Point(17, 16);
            this.rdoDefault.Name = "rdoDefault";
            this.rdoDefault.Size = new System.Drawing.Size(71, 16);
            this.rdoDefault.TabIndex = 0;
            this.rdoDefault.TabStop = true;
            this.rdoDefault.Text = "默认路径";
            this.rdoDefault.UseVisualStyleBackColor = true;
            // 
            // pageRestore
            // 
            this.pageRestore.Controls.Add(this.btnQuit2);
            this.pageRestore.Controls.Add(this.btnRestore);
            this.pageRestore.Controls.Add(this.btnRestorePath);
            this.pageRestore.Controls.Add(this.txtDataPath);
            this.pageRestore.Controls.Add(this.label1);
            this.pageRestore.Location = new System.Drawing.Point(4, 22);
            this.pageRestore.Name = "pageRestore";
            this.pageRestore.Padding = new System.Windows.Forms.Padding(3);
            this.pageRestore.Size = new System.Drawing.Size(277, 134);
            this.pageRestore.TabIndex = 1;
            this.pageRestore.Text = "还原数据库";
            this.pageRestore.UseVisualStyleBackColor = true;
            // 
            // btnQuit2
            // 
            this.btnQuit2.Location = new System.Drawing.Point(176, 92);
            this.btnQuit2.Name = "btnQuit2";
            this.btnQuit2.Size = new System.Drawing.Size(75, 23);
            this.btnQuit2.TabIndex = 4;
            this.btnQuit2.Text = "取消";
            this.btnQuit2.UseVisualStyleBackColor = true;
            this.btnQuit2.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(80, 92);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "还原";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRestorePath
            // 
            this.btnRestorePath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRestorePath.BackgroundImage")));
            this.btnRestorePath.Location = new System.Drawing.Point(229, 51);
            this.btnRestorePath.Name = "btnRestorePath";
            this.btnRestorePath.Size = new System.Drawing.Size(22, 23);
            this.btnRestorePath.TabIndex = 2;
            this.btnRestorePath.UseVisualStyleBackColor = true;
            this.btnRestorePath.Click += new System.EventHandler(this.btnRestorePath_Click);
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(20, 51);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(202, 21);
            this.txtDataPath.TabIndex = 1;
            this.txtDataPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库文件路径：";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // BackupRestoreDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 185);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BackupRestoreDataForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackupRestoreDataForm";
            this.tabControl.ResumeLayout(false);
            this.pageBackup.ResumeLayout(false);
            this.pageBackup.PerformLayout();
            this.pageRestore.ResumeLayout(false);
            this.pageRestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageBackup;
        private System.Windows.Forms.Button btnQuit1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.TextBox txtDefault;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoDefault;
        private System.Windows.Forms.TabPage pageRestore;
        private System.Windows.Forms.Button btnQuit2;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRestorePath;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}