namespace PWMS.ModuleForm
{
    partial class RecordForm
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
            this.chkSelectType = new System.Windows.Forms.CheckBox();
            this.chkSelectTime = new System.Windows.Forms.CheckBox();
            this.cmbSelectType = new System.Windows.Forms.ComboBox();
            this.dtpSelectTime = new System.Windows.Forms.DateTimePicker();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.grpRecord = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.re_Content = new System.Windows.Forms.TextBox();
            this.re_Theme = new System.Windows.Forms.TextBox();
            this.no_Record = new System.Windows.Forms.ComboBox();
            this.re_RecordDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAlter = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.grpRecord.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSelectType);
            this.groupBox1.Controls.Add(this.chkSelectTime);
            this.groupBox1.Controls.Add(this.cmbSelectType);
            this.groupBox1.Controls.Add(this.dtpSelectTime);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // chkSelectType
            // 
            this.chkSelectType.AutoSize = true;
            this.chkSelectType.Location = new System.Drawing.Point(283, 20);
            this.chkSelectType.Name = "chkSelectType";
            this.chkSelectType.Size = new System.Drawing.Size(72, 16);
            this.chkSelectType.TabIndex = 4;
            this.chkSelectType.Text = "记事类别";
            this.chkSelectType.UseVisualStyleBackColor = true;
            // 
            // chkSelectTime
            // 
            this.chkSelectTime.AutoSize = true;
            this.chkSelectTime.Location = new System.Drawing.Point(1, 24);
            this.chkSelectTime.Name = "chkSelectTime";
            this.chkSelectTime.Size = new System.Drawing.Size(72, 16);
            this.chkSelectTime.TabIndex = 3;
            this.chkSelectTime.Text = "记事时间";
            this.chkSelectTime.UseVisualStyleBackColor = true;
            // 
            // cmbSelectType
            // 
            this.cmbSelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectType.FormattingEnabled = true;
            this.cmbSelectType.Location = new System.Drawing.Point(361, 18);
            this.cmbSelectType.Name = "cmbSelectType";
            this.cmbSelectType.Size = new System.Drawing.Size(121, 20);
            this.cmbSelectType.TabIndex = 2;
            // 
            // dtpSelectTime
            // 
            this.dtpSelectTime.Location = new System.Drawing.Point(84, 19);
            this.dtpSelectTime.Name = "dtpSelectTime";
            this.dtpSelectTime.Size = new System.Drawing.Size(137, 21);
            this.dtpSelectTime.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(527, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAll);
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Location = new System.Drawing.Point(13, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 347);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息表";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(7, 21);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(307, 23);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "全部";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(7, 52);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(307, 289);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            // 
            // grpRecord
            // 
            this.grpRecord.Controls.Add(this.label4);
            this.grpRecord.Controls.Add(this.label3);
            this.grpRecord.Controls.Add(this.label2);
            this.grpRecord.Controls.Add(this.label1);
            this.grpRecord.Controls.Add(this.re_Content);
            this.grpRecord.Controls.Add(this.re_Theme);
            this.grpRecord.Controls.Add(this.no_Record);
            this.grpRecord.Controls.Add(this.re_RecordDate);
            this.grpRecord.Location = new System.Drawing.Point(344, 83);
            this.grpRecord.Name = "grpRecord";
            this.grpRecord.Size = new System.Drawing.Size(302, 283);
            this.grpRecord.TabIndex = 2;
            this.grpRecord.TabStop = false;
            this.grpRecord.Text = "记事本内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "内容：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "主题：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "时间：";
            // 
            // re_Content
            // 
            this.re_Content.Location = new System.Drawing.Point(7, 148);
            this.re_Content.Multiline = true;
            this.re_Content.Name = "re_Content";
            this.re_Content.Size = new System.Drawing.Size(279, 129);
            this.re_Content.TabIndex = 3;
            // 
            // re_Theme
            // 
            this.re_Theme.Location = new System.Drawing.Point(53, 84);
            this.re_Theme.Name = "re_Theme";
            this.re_Theme.Size = new System.Drawing.Size(233, 21);
            this.re_Theme.TabIndex = 2;
            // 
            // no_Record
            // 
            this.no_Record.FormattingEnabled = true;
            this.no_Record.Location = new System.Drawing.Point(53, 58);
            this.no_Record.Name = "no_Record";
            this.no_Record.Size = new System.Drawing.Size(145, 20);
            this.no_Record.TabIndex = 1;
            this.no_Record.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.re_NORecordType_KeyPress);
            // 
            // re_RecordDate
            // 
            this.re_RecordDate.Location = new System.Drawing.Point(53, 31);
            this.re_RecordDate.Name = "re_RecordDate";
            this.re_RecordDate.Size = new System.Drawing.Size(145, 21);
            this.re_RecordDate.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.btnQuit);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnAlter);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Location = new System.Drawing.Point(344, 372);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 58);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(248, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(196, 21);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(43, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(135, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAlter
            // 
            this.btnAlter.Location = new System.Drawing.Point(73, 21);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(47, 23);
            this.btnAlter.TabIndex = 1;
            this.btnAlter.Text = "修改";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 442);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpRecord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecordForm";
            this.Activated += new System.EventHandler(this.RecordForm_Activated);
            this.Load += new System.EventHandler(this.RecordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.grpRecord.ResumeLayout(false);
            this.grpRecord.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSelectType;
        private System.Windows.Forms.CheckBox chkSelectTime;
        private System.Windows.Forms.ComboBox cmbSelectType;
        private System.Windows.Forms.DateTimePicker dtpSelectTime;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox grpRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox re_Content;
        private System.Windows.Forms.TextBox re_Theme;
        private System.Windows.Forms.ComboBox no_Record;
        private System.Windows.Forms.DateTimePicker re_RecordDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAll;
    }
}