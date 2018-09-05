namespace PWMS.ModuleForm
{
    partial class AddressBookForm
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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.grpSelect = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtConditon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.grpOperate = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAlter = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.grpSelect.SuspendLayout();
            this.grpOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvData);
            this.grpData.Location = new System.Drawing.Point(12, 114);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(516, 208);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            this.grpData.Text = "数据表";
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(7, 31);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(497, 171);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            // 
            // grpSelect
            // 
            this.grpSelect.Controls.Add(this.cmbType);
            this.grpSelect.Controls.Add(this.txtConditon);
            this.grpSelect.Controls.Add(this.label2);
            this.grpSelect.Controls.Add(this.label1);
            this.grpSelect.Controls.Add(this.btnAll);
            this.grpSelect.Controls.Add(this.btnSelect);
            this.grpSelect.Location = new System.Drawing.Point(12, 12);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Size = new System.Drawing.Size(516, 86);
            this.grpSelect.TabIndex = 1;
            this.grpSelect.TabStop = false;
            this.grpSelect.Text = "查询";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(59, 38);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 20);
            this.cmbType.TabIndex = 5;
            this.cmbType.TextChanged += new System.EventHandler(this.cmbType_TextChanged);
            // 
            // txtConditon
            // 
            this.txtConditon.Location = new System.Drawing.Point(242, 37);
            this.txtConditon.Name = "txtConditon";
            this.txtConditon.Size = new System.Drawing.Size(100, 21);
            this.txtConditon.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "查询条件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询类型：";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(429, 37);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "全部";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(348, 36);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // grpOperate
            // 
            this.grpOperate.Controls.Add(this.btnQuit);
            this.grpOperate.Controls.Add(this.btnDelete);
            this.grpOperate.Controls.Add(this.btnAlter);
            this.grpOperate.Controls.Add(this.btnAdd);
            this.grpOperate.Location = new System.Drawing.Point(12, 349);
            this.grpOperate.Name = "grpOperate";
            this.grpOperate.Size = new System.Drawing.Size(516, 53);
            this.grpOperate.TabIndex = 2;
            this.grpOperate.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(393, 20);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(276, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAlter
            // 
            this.btnAlter.Location = new System.Drawing.Point(149, 20);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(75, 23);
            this.btnAlter.TabIndex = 1;
            this.btnAlter.Text = "修改";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddressBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 436);
            this.Controls.Add(this.grpOperate);
            this.Controls.Add(this.grpSelect);
            this.Controls.Add(this.grpData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddressBookForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddressBookForm";
            this.Activated += new System.EventHandler(this.AddressBookForm_Activated);
            this.Load += new System.EventHandler(this.AddressBookForm_Load);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.grpSelect.ResumeLayout(false);
            this.grpSelect.PerformLayout();
            this.grpOperate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox grpSelect;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtConditon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox grpOperate;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.Button btnAdd;
    }
}