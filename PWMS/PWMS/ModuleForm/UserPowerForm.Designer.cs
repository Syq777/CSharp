namespace PWMS.ModuleForm
{
    partial class UserPowerForm
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
            this.grpPower = new System.Windows.Forms.GroupBox();
            this.chk_Set = new System.Windows.Forms.CheckBox();
            this.chk_ReEntry = new System.Windows.Forms.CheckBox();
            this.chk_Notepad = new System.Windows.Forms.CheckBox();
            this.chk_Calculator = new System.Windows.Forms.CheckBox();
            this.chk_DeleteData = new System.Windows.Forms.CheckBox();
            this.chk_BackupRestoreData = new System.Windows.Forms.CheckBox();
            this.chk_AddressBook = new System.Windows.Forms.CheckBox();
            this.chk_Record = new System.Windows.Forms.CheckBox();
            this.chk_Statistics = new System.Windows.Forms.CheckBox();
            this.chk_Lookup = new System.Windows.Forms.CheckBox();
            this.chk_Manager = new System.Windows.Forms.CheckBox();
            this.chk_ContractCue = new System.Windows.Forms.CheckBox();
            this.chk_BirthdayCue = new System.Windows.Forms.CheckBox();
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.grpPower.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPower
            // 
            this.grpPower.Controls.Add(this.chk_Set);
            this.grpPower.Controls.Add(this.chk_ReEntry);
            this.grpPower.Controls.Add(this.chk_Notepad);
            this.grpPower.Controls.Add(this.chk_Calculator);
            this.grpPower.Controls.Add(this.chk_DeleteData);
            this.grpPower.Controls.Add(this.chk_BackupRestoreData);
            this.grpPower.Controls.Add(this.chk_AddressBook);
            this.grpPower.Controls.Add(this.chk_Record);
            this.grpPower.Controls.Add(this.chk_Statistics);
            this.grpPower.Controls.Add(this.chk_Lookup);
            this.grpPower.Controls.Add(this.chk_Manager);
            this.grpPower.Controls.Add(this.chk_ContractCue);
            this.grpPower.Controls.Add(this.chk_BirthdayCue);
            this.grpPower.Controls.Add(this.chk_RecordType);
            this.grpPower.Controls.Add(this.chk_RPType);
            this.grpPower.Controls.Add(this.chk_TitleType);
            this.grpPower.Controls.Add(this.chk_DepartmentType);
            this.grpPower.Controls.Add(this.chk_SalaryType);
            this.grpPower.Controls.Add(this.chk_PositionType);
            this.grpPower.Controls.Add(this.chk_StaffType);
            this.grpPower.Controls.Add(this.chk_PoliticalStatusType);
            this.grpPower.Controls.Add(this.chk_EducationType);
            this.grpPower.Controls.Add(this.chk_NationType);
            this.grpPower.Location = new System.Drawing.Point(13, 13);
            this.grpPower.Name = "grpPower";
            this.grpPower.Size = new System.Drawing.Size(318, 210);
            this.grpPower.TabIndex = 0;
            this.grpPower.TabStop = false;
            this.grpPower.Text = "权限";
            // 
            // chk_Set
            // 
            this.chk_Set.AutoSize = true;
            this.chk_Set.Location = new System.Drawing.Point(108, 179);
            this.chk_Set.Name = "chk_Set";
            this.chk_Set.Size = new System.Drawing.Size(72, 16);
            this.chk_Set.TabIndex = 22;
            this.chk_Set.Text = "用户设置";
            this.chk_Set.UseVisualStyleBackColor = true;
            this.chk_Set.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_ReEntry
            // 
            this.chk_ReEntry.AutoSize = true;
            this.chk_ReEntry.Location = new System.Drawing.Point(6, 179);
            this.chk_ReEntry.Name = "chk_ReEntry";
            this.chk_ReEntry.Size = new System.Drawing.Size(72, 16);
            this.chk_ReEntry.TabIndex = 21;
            this.chk_ReEntry.Text = "重新登录";
            this.chk_ReEntry.UseVisualStyleBackColor = true;
            this.chk_ReEntry.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Notepad
            // 
            this.chk_Notepad.AutoSize = true;
            this.chk_Notepad.Location = new System.Drawing.Point(203, 156);
            this.chk_Notepad.Name = "chk_Notepad";
            this.chk_Notepad.Size = new System.Drawing.Size(60, 16);
            this.chk_Notepad.TabIndex = 20;
            this.chk_Notepad.Text = "记事本";
            this.chk_Notepad.UseVisualStyleBackColor = true;
            this.chk_Notepad.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Calculator
            // 
            this.chk_Calculator.AutoSize = true;
            this.chk_Calculator.Location = new System.Drawing.Point(108, 154);
            this.chk_Calculator.Name = "chk_Calculator";
            this.chk_Calculator.Size = new System.Drawing.Size(60, 16);
            this.chk_Calculator.TabIndex = 19;
            this.chk_Calculator.Text = "计算器";
            this.chk_Calculator.UseVisualStyleBackColor = true;
            this.chk_Calculator.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_DeleteData
            // 
            this.chk_DeleteData.AutoSize = true;
            this.chk_DeleteData.Location = new System.Drawing.Point(6, 156);
            this.chk_DeleteData.Name = "chk_DeleteData";
            this.chk_DeleteData.Size = new System.Drawing.Size(84, 16);
            this.chk_DeleteData.TabIndex = 18;
            this.chk_DeleteData.Text = "清空数据库";
            this.chk_DeleteData.UseVisualStyleBackColor = true;
            this.chk_DeleteData.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_BackupRestoreData
            // 
            this.chk_BackupRestoreData.AutoSize = true;
            this.chk_BackupRestoreData.Location = new System.Drawing.Point(203, 132);
            this.chk_BackupRestoreData.Name = "chk_BackupRestoreData";
            this.chk_BackupRestoreData.Size = new System.Drawing.Size(114, 16);
            this.chk_BackupRestoreData.TabIndex = 17;
            this.chk_BackupRestoreData.Text = "备份/还原数据库";
            this.chk_BackupRestoreData.UseVisualStyleBackColor = true;
            this.chk_BackupRestoreData.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_AddressBook
            // 
            this.chk_AddressBook.AutoSize = true;
            this.chk_AddressBook.Location = new System.Drawing.Point(108, 132);
            this.chk_AddressBook.Name = "chk_AddressBook";
            this.chk_AddressBook.Size = new System.Drawing.Size(60, 16);
            this.chk_AddressBook.TabIndex = 16;
            this.chk_AddressBook.Text = "通讯录";
            this.chk_AddressBook.UseVisualStyleBackColor = true;
            this.chk_AddressBook.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Record
            // 
            this.chk_Record.AutoSize = true;
            this.chk_Record.Location = new System.Drawing.Point(7, 133);
            this.chk_Record.Name = "chk_Record";
            this.chk_Record.Size = new System.Drawing.Size(72, 16);
            this.chk_Record.TabIndex = 15;
            this.chk_Record.Text = "日常记事";
            this.chk_Record.UseVisualStyleBackColor = true;
            this.chk_Record.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Statistics
            // 
            this.chk_Statistics.AutoSize = true;
            this.chk_Statistics.Location = new System.Drawing.Point(203, 111);
            this.chk_Statistics.Name = "chk_Statistics";
            this.chk_Statistics.Size = new System.Drawing.Size(96, 16);
            this.chk_Statistics.TabIndex = 14;
            this.chk_Statistics.Text = "人事档案统计";
            this.chk_Statistics.UseVisualStyleBackColor = true;
            this.chk_Statistics.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Lookup
            // 
            this.chk_Lookup.AutoSize = true;
            this.chk_Lookup.Location = new System.Drawing.Point(108, 110);
            this.chk_Lookup.Name = "chk_Lookup";
            this.chk_Lookup.Size = new System.Drawing.Size(96, 16);
            this.chk_Lookup.TabIndex = 13;
            this.chk_Lookup.Text = "人事档案查询";
            this.chk_Lookup.UseVisualStyleBackColor = true;
            this.chk_Lookup.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_Manager
            // 
            this.chk_Manager.AutoSize = true;
            this.chk_Manager.Location = new System.Drawing.Point(6, 110);
            this.chk_Manager.Name = "chk_Manager";
            this.chk_Manager.Size = new System.Drawing.Size(96, 16);
            this.chk_Manager.TabIndex = 12;
            this.chk_Manager.Text = "人事档案管理";
            this.chk_Manager.UseVisualStyleBackColor = true;
            this.chk_Manager.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_ContractCue
            // 
            this.chk_ContractCue.AutoSize = true;
            this.chk_ContractCue.Location = new System.Drawing.Point(203, 88);
            this.chk_ContractCue.Name = "chk_ContractCue";
            this.chk_ContractCue.Size = new System.Drawing.Size(96, 16);
            this.chk_ContractCue.TabIndex = 11;
            this.chk_ContractCue.Text = "员工合同提示";
            this.chk_ContractCue.UseVisualStyleBackColor = true;
            this.chk_ContractCue.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_BirthdayCue
            // 
            this.chk_BirthdayCue.AutoSize = true;
            this.chk_BirthdayCue.Location = new System.Drawing.Point(108, 88);
            this.chk_BirthdayCue.Name = "chk_BirthdayCue";
            this.chk_BirthdayCue.Size = new System.Drawing.Size(96, 16);
            this.chk_BirthdayCue.TabIndex = 10;
            this.chk_BirthdayCue.Text = "员工生日提示";
            this.chk_BirthdayCue.UseVisualStyleBackColor = true;
            this.chk_BirthdayCue.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_RecordType
            // 
            this.chk_RecordType.AutoSize = true;
            this.chk_RecordType.Location = new System.Drawing.Point(6, 88);
            this.chk_RecordType.Name = "chk_RecordType";
            this.chk_RecordType.Size = new System.Drawing.Size(72, 16);
            this.chk_RecordType.TabIndex = 9;
            this.chk_RecordType.Text = "记事类别";
            this.chk_RecordType.UseVisualStyleBackColor = true;
            this.chk_RecordType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_RPType
            // 
            this.chk_RPType.AutoSize = true;
            this.chk_RPType.Location = new System.Drawing.Point(203, 66);
            this.chk_RPType.Name = "chk_RPType";
            this.chk_RPType.Size = new System.Drawing.Size(72, 16);
            this.chk_RPType.TabIndex = 8;
            this.chk_RPType.Text = "奖惩类别";
            this.chk_RPType.UseVisualStyleBackColor = true;
            this.chk_RPType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_TitleType
            // 
            this.chk_TitleType.AutoSize = true;
            this.chk_TitleType.Location = new System.Drawing.Point(108, 65);
            this.chk_TitleType.Name = "chk_TitleType";
            this.chk_TitleType.Size = new System.Drawing.Size(72, 16);
            this.chk_TitleType.TabIndex = 7;
            this.chk_TitleType.Text = "职称类别";
            this.chk_TitleType.UseVisualStyleBackColor = true;
            this.chk_TitleType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_DepartmentType
            // 
            this.chk_DepartmentType.AutoSize = true;
            this.chk_DepartmentType.Location = new System.Drawing.Point(6, 66);
            this.chk_DepartmentType.Name = "chk_DepartmentType";
            this.chk_DepartmentType.Size = new System.Drawing.Size(72, 16);
            this.chk_DepartmentType.TabIndex = 6;
            this.chk_DepartmentType.Text = "部门类别";
            this.chk_DepartmentType.UseVisualStyleBackColor = true;
            this.chk_DepartmentType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_SalaryType
            // 
            this.chk_SalaryType.AutoSize = true;
            this.chk_SalaryType.Location = new System.Drawing.Point(203, 44);
            this.chk_SalaryType.Name = "chk_SalaryType";
            this.chk_SalaryType.Size = new System.Drawing.Size(72, 16);
            this.chk_SalaryType.TabIndex = 5;
            this.chk_SalaryType.Text = "工资类别";
            this.chk_SalaryType.UseVisualStyleBackColor = true;
            this.chk_SalaryType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_PositionType
            // 
            this.chk_PositionType.AutoSize = true;
            this.chk_PositionType.Location = new System.Drawing.Point(108, 43);
            this.chk_PositionType.Name = "chk_PositionType";
            this.chk_PositionType.Size = new System.Drawing.Size(72, 16);
            this.chk_PositionType.TabIndex = 4;
            this.chk_PositionType.Text = "职务类型";
            this.chk_PositionType.UseVisualStyleBackColor = true;
            this.chk_PositionType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_StaffType
            // 
            this.chk_StaffType.AutoSize = true;
            this.chk_StaffType.Location = new System.Drawing.Point(7, 44);
            this.chk_StaffType.Name = "chk_StaffType";
            this.chk_StaffType.Size = new System.Drawing.Size(72, 16);
            this.chk_StaffType.TabIndex = 3;
            this.chk_StaffType.Text = "职工类型";
            this.chk_StaffType.UseVisualStyleBackColor = true;
            this.chk_StaffType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_PoliticalStatusType
            // 
            this.chk_PoliticalStatusType.AutoSize = true;
            this.chk_PoliticalStatusType.Location = new System.Drawing.Point(203, 20);
            this.chk_PoliticalStatusType.Name = "chk_PoliticalStatusType";
            this.chk_PoliticalStatusType.Size = new System.Drawing.Size(72, 16);
            this.chk_PoliticalStatusType.TabIndex = 2;
            this.chk_PoliticalStatusType.Text = "政治面貌";
            this.chk_PoliticalStatusType.UseVisualStyleBackColor = true;
            this.chk_PoliticalStatusType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_EducationType
            // 
            this.chk_EducationType.AutoSize = true;
            this.chk_EducationType.Location = new System.Drawing.Point(108, 21);
            this.chk_EducationType.Name = "chk_EducationType";
            this.chk_EducationType.Size = new System.Drawing.Size(72, 16);
            this.chk_EducationType.TabIndex = 1;
            this.chk_EducationType.Text = "文化程度";
            this.chk_EducationType.UseVisualStyleBackColor = true;
            this.chk_EducationType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chk_NationType
            // 
            this.chk_NationType.AutoSize = true;
            this.chk_NationType.Location = new System.Drawing.Point(7, 21);
            this.chk_NationType.Name = "chk_NationType";
            this.chk_NationType.Size = new System.Drawing.Size(72, 16);
            this.chk_NationType.TabIndex = 0;
            this.chk_NationType.Text = "民族类别";
            this.chk_NationType.UseVisualStyleBackColor = true;
            this.chk_NationType.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(33, 233);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(142, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(237, 226);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // UserPowerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 265);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.grpPower);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserPowerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserPowerForm";
            this.Load += new System.EventHandler(this.UserPowerForm_Load);
            this.grpPower.ResumeLayout(false);
            this.grpPower.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPower;
        private System.Windows.Forms.CheckBox chk_Set;
        private System.Windows.Forms.CheckBox chk_ReEntry;
        private System.Windows.Forms.CheckBox chk_Notepad;
        private System.Windows.Forms.CheckBox chk_Calculator;
        private System.Windows.Forms.CheckBox chk_DeleteData;
        private System.Windows.Forms.CheckBox chk_BackupRestoreData;
        private System.Windows.Forms.CheckBox chk_AddressBook;
        private System.Windows.Forms.CheckBox chk_Record;
        private System.Windows.Forms.CheckBox chk_Statistics;
        private System.Windows.Forms.CheckBox chk_Lookup;
        private System.Windows.Forms.CheckBox chk_Manager;
        private System.Windows.Forms.CheckBox chk_ContractCue;
        private System.Windows.Forms.CheckBox chk_BirthdayCue;
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
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnQuit;
    }
}