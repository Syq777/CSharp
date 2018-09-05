namespace PWMS.ModuleForm
{
    partial class DeleteDataForm
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
            this.grpTable = new System.Windows.Forms.GroupBox();
            this.chk_MessageCue = new System.Windows.Forms.CheckBox();
            this.chk_AddressBook = new System.Windows.Forms.CheckBox();
            this.chk_Record = new System.Windows.Forms.CheckBox();
            this.chk_RecordType = new System.Windows.Forms.CheckBox();
            this.chk_RPType = new System.Windows.Forms.CheckBox();
            this.chk_TitleType = new System.Windows.Forms.CheckBox();
            this.chk_DepartmentType = new System.Windows.Forms.CheckBox();
            this.chk_SalaryType = new System.Windows.Forms.CheckBox();
            this.chk_PositionType = new System.Windows.Forms.CheckBox();
            this.chk_StaffType = new System.Windows.Forms.CheckBox();
            this.chk_PoliticalStatusType = new System.Windows.Forms.CheckBox();
            this.chk_EducationType = new System.Windows.Forms.CheckBox();
            this.chk_NationType = new System.Windows.Forms.CheckBox();
            this.chk_RP = new System.Windows.Forms.CheckBox();
            this.chk_Train = new System.Windows.Forms.CheckBox();
            this.chk_WorkResume = new System.Windows.Forms.CheckBox();
            this.chk_Family = new System.Windows.Forms.CheckBox();
            this.chk_Resume = new System.Windows.Forms.CheckBox();
            this.chk_Staff = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.grpTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTable
            // 
            this.grpTable.Controls.Add(this.chk_MessageCue);
            this.grpTable.Controls.Add(this.chk_AddressBook);
            this.grpTable.Controls.Add(this.chk_Record);
            this.grpTable.Controls.Add(this.chk_RecordType);
            this.grpTable.Controls.Add(this.chk_RPType);
            this.grpTable.Controls.Add(this.chk_TitleType);
            this.grpTable.Controls.Add(this.chk_DepartmentType);
            this.grpTable.Controls.Add(this.chk_SalaryType);
            this.grpTable.Controls.Add(this.chk_PositionType);
            this.grpTable.Controls.Add(this.chk_StaffType);
            this.grpTable.Controls.Add(this.chk_PoliticalStatusType);
            this.grpTable.Controls.Add(this.chk_EducationType);
            this.grpTable.Controls.Add(this.chk_NationType);
            this.grpTable.Controls.Add(this.chk_RP);
            this.grpTable.Controls.Add(this.chk_Train);
            this.grpTable.Controls.Add(this.chk_WorkResume);
            this.grpTable.Controls.Add(this.chk_Family);
            this.grpTable.Controls.Add(this.chk_Resume);
            this.grpTable.Controls.Add(this.chk_Staff);
            this.grpTable.Location = new System.Drawing.Point(12, 12);
            this.grpTable.Name = "grpTable";
            this.grpTable.Size = new System.Drawing.Size(335, 181);
            this.grpTable.TabIndex = 1;
            this.grpTable.TabStop = false;
            this.grpTable.Text = "数据表";
            // 
            // chk_MessageCue
            // 
            this.chk_MessageCue.AutoSize = true;
            this.chk_MessageCue.Location = new System.Drawing.Point(221, 66);
            this.chk_MessageCue.Name = "chk_MessageCue";
            this.chk_MessageCue.Size = new System.Drawing.Size(108, 16);
            this.chk_MessageCue.TabIndex = 18;
            this.chk_MessageCue.Text = "员工提示信息表";
            this.chk_MessageCue.UseVisualStyleBackColor = true;
            this.chk_MessageCue.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_AddressBook
            // 
            this.chk_AddressBook.AutoSize = true;
            this.chk_AddressBook.Location = new System.Drawing.Point(6, 66);
            this.chk_AddressBook.Name = "chk_AddressBook";
            this.chk_AddressBook.Size = new System.Drawing.Size(72, 16);
            this.chk_AddressBook.TabIndex = 17;
            this.chk_AddressBook.Text = "通讯录表";
            this.chk_AddressBook.UseVisualStyleBackColor = true;
            this.chk_AddressBook.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Record
            // 
            this.chk_Record.AutoSize = true;
            this.chk_Record.Location = new System.Drawing.Point(108, 66);
            this.chk_Record.Name = "chk_Record";
            this.chk_Record.Size = new System.Drawing.Size(84, 16);
            this.chk_Record.TabIndex = 16;
            this.chk_Record.Text = "日常记事表";
            this.chk_Record.UseVisualStyleBackColor = true;
            this.chk_Record.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_RecordType
            // 
            this.chk_RecordType.AutoSize = true;
            this.chk_RecordType.Location = new System.Drawing.Point(221, 132);
            this.chk_RecordType.Name = "chk_RecordType";
            this.chk_RecordType.Size = new System.Drawing.Size(84, 16);
            this.chk_RecordType.TabIndex = 15;
            this.chk_RecordType.Text = "记事类别表";
            this.chk_RecordType.UseVisualStyleBackColor = true;
            this.chk_RecordType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_RPType
            // 
            this.chk_RPType.AutoSize = true;
            this.chk_RPType.Location = new System.Drawing.Point(7, 154);
            this.chk_RPType.Name = "chk_RPType";
            this.chk_RPType.Size = new System.Drawing.Size(72, 16);
            this.chk_RPType.TabIndex = 14;
            this.chk_RPType.Text = "奖惩类别";
            this.chk_RPType.UseVisualStyleBackColor = true;
            this.chk_RPType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_TitleType
            // 
            this.chk_TitleType.AutoSize = true;
            this.chk_TitleType.Location = new System.Drawing.Point(7, 132);
            this.chk_TitleType.Name = "chk_TitleType";
            this.chk_TitleType.Size = new System.Drawing.Size(84, 16);
            this.chk_TitleType.TabIndex = 13;
            this.chk_TitleType.Text = "职称类别表";
            this.chk_TitleType.UseVisualStyleBackColor = true;
            this.chk_TitleType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_DepartmentType
            // 
            this.chk_DepartmentType.AutoSize = true;
            this.chk_DepartmentType.Location = new System.Drawing.Point(221, 110);
            this.chk_DepartmentType.Name = "chk_DepartmentType";
            this.chk_DepartmentType.Size = new System.Drawing.Size(84, 16);
            this.chk_DepartmentType.TabIndex = 12;
            this.chk_DepartmentType.Text = "部门类别表";
            this.chk_DepartmentType.UseVisualStyleBackColor = true;
            this.chk_DepartmentType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_SalaryType
            // 
            this.chk_SalaryType.AutoSize = true;
            this.chk_SalaryType.Location = new System.Drawing.Point(221, 88);
            this.chk_SalaryType.Name = "chk_SalaryType";
            this.chk_SalaryType.Size = new System.Drawing.Size(84, 16);
            this.chk_SalaryType.TabIndex = 11;
            this.chk_SalaryType.Text = "工资类别表";
            this.chk_SalaryType.UseVisualStyleBackColor = true;
            this.chk_SalaryType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_PositionType
            // 
            this.chk_PositionType.AutoSize = true;
            this.chk_PositionType.Location = new System.Drawing.Point(108, 110);
            this.chk_PositionType.Name = "chk_PositionType";
            this.chk_PositionType.Size = new System.Drawing.Size(84, 16);
            this.chk_PositionType.TabIndex = 10;
            this.chk_PositionType.Text = "职务类别表";
            this.chk_PositionType.UseVisualStyleBackColor = true;
            this.chk_PositionType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_StaffType
            // 
            this.chk_StaffType.AutoSize = true;
            this.chk_StaffType.Location = new System.Drawing.Point(7, 110);
            this.chk_StaffType.Name = "chk_StaffType";
            this.chk_StaffType.Size = new System.Drawing.Size(84, 16);
            this.chk_StaffType.TabIndex = 9;
            this.chk_StaffType.Text = "职工类别表";
            this.chk_StaffType.UseVisualStyleBackColor = true;
            this.chk_StaffType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_PoliticalStatusType
            // 
            this.chk_PoliticalStatusType.AutoSize = true;
            this.chk_PoliticalStatusType.Location = new System.Drawing.Point(108, 132);
            this.chk_PoliticalStatusType.Name = "chk_PoliticalStatusType";
            this.chk_PoliticalStatusType.Size = new System.Drawing.Size(84, 16);
            this.chk_PoliticalStatusType.TabIndex = 8;
            this.chk_PoliticalStatusType.Text = "政治面貌表";
            this.chk_PoliticalStatusType.UseVisualStyleBackColor = true;
            this.chk_PoliticalStatusType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_EducationType
            // 
            this.chk_EducationType.AutoSize = true;
            this.chk_EducationType.Location = new System.Drawing.Point(108, 88);
            this.chk_EducationType.Name = "chk_EducationType";
            this.chk_EducationType.Size = new System.Drawing.Size(84, 16);
            this.chk_EducationType.TabIndex = 7;
            this.chk_EducationType.Text = "文化类别表";
            this.chk_EducationType.UseVisualStyleBackColor = true;
            this.chk_EducationType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_NationType
            // 
            this.chk_NationType.AutoSize = true;
            this.chk_NationType.Location = new System.Drawing.Point(7, 88);
            this.chk_NationType.Name = "chk_NationType";
            this.chk_NationType.Size = new System.Drawing.Size(84, 16);
            this.chk_NationType.TabIndex = 6;
            this.chk_NationType.Text = "民族类别表";
            this.chk_NationType.UseVisualStyleBackColor = true;
            this.chk_NationType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_RP
            // 
            this.chk_RP.AutoSize = true;
            this.chk_RP.Location = new System.Drawing.Point(221, 44);
            this.chk_RP.Name = "chk_RP";
            this.chk_RP.Size = new System.Drawing.Size(60, 16);
            this.chk_RP.TabIndex = 5;
            this.chk_RP.Text = "奖惩表";
            this.chk_RP.UseVisualStyleBackColor = true;
            this.chk_RP.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Train
            // 
            this.chk_Train.AutoSize = true;
            this.chk_Train.Location = new System.Drawing.Point(108, 43);
            this.chk_Train.Name = "chk_Train";
            this.chk_Train.Size = new System.Drawing.Size(60, 16);
            this.chk_Train.TabIndex = 4;
            this.chk_Train.Text = "培训表";
            this.chk_Train.UseVisualStyleBackColor = true;
            this.chk_Train.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_WorkResume
            // 
            this.chk_WorkResume.AutoSize = true;
            this.chk_WorkResume.Location = new System.Drawing.Point(7, 44);
            this.chk_WorkResume.Name = "chk_WorkResume";
            this.chk_WorkResume.Size = new System.Drawing.Size(84, 16);
            this.chk_WorkResume.TabIndex = 3;
            this.chk_WorkResume.Text = "工作简介表";
            this.chk_WorkResume.UseVisualStyleBackColor = true;
            this.chk_WorkResume.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Family
            // 
            this.chk_Family.AutoSize = true;
            this.chk_Family.Location = new System.Drawing.Point(221, 20);
            this.chk_Family.Name = "chk_Family";
            this.chk_Family.Size = new System.Drawing.Size(84, 16);
            this.chk_Family.TabIndex = 2;
            this.chk_Family.Text = "家庭关系表";
            this.chk_Family.UseVisualStyleBackColor = true;
            this.chk_Family.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Resume
            // 
            this.chk_Resume.AutoSize = true;
            this.chk_Resume.Location = new System.Drawing.Point(108, 21);
            this.chk_Resume.Name = "chk_Resume";
            this.chk_Resume.Size = new System.Drawing.Size(84, 16);
            this.chk_Resume.TabIndex = 1;
            this.chk_Resume.Text = "个人简介表";
            this.chk_Resume.UseVisualStyleBackColor = true;
            this.chk_Resume.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Staff
            // 
            this.chk_Staff.AutoSize = true;
            this.chk_Staff.Location = new System.Drawing.Point(7, 21);
            this.chk_Staff.Name = "chk_Staff";
            this.chk_Staff.Size = new System.Drawing.Size(84, 16);
            this.chk_Staff.TabIndex = 0;
            this.chk_Staff.Text = "职工信息表";
            this.chk_Staff.UseVisualStyleBackColor = true;
            this.chk_Staff.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(19, 218);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 214);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(233, 214);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // DeleteDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 252);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.grpTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DeleteDataForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteDataForm";
            this.grpTable.ResumeLayout(false);
            this.grpTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTable;
        private System.Windows.Forms.CheckBox chk_MessageCue;
        private System.Windows.Forms.CheckBox chk_AddressBook;
        private System.Windows.Forms.CheckBox chk_Record;
        private System.Windows.Forms.CheckBox chk_RecordType;
        private System.Windows.Forms.CheckBox chk_RPType;
        private System.Windows.Forms.CheckBox chk_TitleType;
        private System.Windows.Forms.CheckBox chk_DepartmentType;
        private System.Windows.Forms.CheckBox chk_SalaryType;
        private System.Windows.Forms.CheckBox chk_PositionType;
        private System.Windows.Forms.CheckBox chk_StaffType;
        private System.Windows.Forms.CheckBox chk_PoliticalStatusType;
        private System.Windows.Forms.CheckBox chk_EducationType;
        private System.Windows.Forms.CheckBox chk_NationType;
        private System.Windows.Forms.CheckBox chk_RP;
        private System.Windows.Forms.CheckBox chk_Train;
        private System.Windows.Forms.CheckBox chk_WorkResume;
        private System.Windows.Forms.CheckBox chk_Family;
        private System.Windows.Forms.CheckBox chk_Resume;
        private System.Windows.Forms.CheckBox chk_Staff;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQuit;
    }
}