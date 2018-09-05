namespace PWMS.ModuleForm
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAlter = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPower = new System.Windows.Forms.ToolStripButton();
            this.tsbtnQuit = new System.Windows.Forms.ToolStripButton();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dgvUser);
            this.groupBox.Location = new System.Drawing.Point(12, 50);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(275, 199);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "用户信息表";
            // 
            // dgvUser
            // 
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(6, 20);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.Size = new System.Drawing.Size(263, 173);
            this.dgvUser.TabIndex = 0;
            this.dgvUser.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellEnter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnAlter,
            this.tsbtnDelete,
            this.tsbtnPower,
            this.tsbtnQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(299, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbtnAdd.Text = "添加";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // tsbtnAlter
            // 
            this.tsbtnAlter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAlter.Image")));
            this.tsbtnAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAlter.Name = "tsbtnAlter";
            this.tsbtnAlter.Size = new System.Drawing.Size(52, 22);
            this.tsbtnAlter.Text = "修改";
            this.tsbtnAlter.Click += new System.EventHandler(this.tsbtnAlter_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(52, 22);
            this.tsbtnDelete.Text = "删除";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // tsbtnPower
            // 
            this.tsbtnPower.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPower.Image")));
            this.tsbtnPower.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPower.Name = "tsbtnPower";
            this.tsbtnPower.Size = new System.Drawing.Size(52, 22);
            this.tsbtnPower.Text = "权限";
            this.tsbtnPower.Click += new System.EventHandler(this.tsbtnPower_Click);
            // 
            // tsbtnQuit
            // 
            this.tsbtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnQuit.Image")));
            this.tsbtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnQuit.Name = "tsbtnQuit";
            this.tsbtnQuit.Size = new System.Drawing.Size(52, 22);
            this.tsbtnQuit.Text = "退出";
            this.tsbtnQuit.Click += new System.EventHandler(this.tsbtnQuit_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 261);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Activated += new System.EventHandler(this.UserForm_Activated);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripButton tsbtnAlter;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.ToolStripButton tsbtnPower;
        private System.Windows.Forms.ToolStripButton tsbtnQuit;
        private System.Windows.Forms.DataGridView dgvUser;
    }
}