namespace PWMS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuBase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNationType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEducationType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPoliticalStatusType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStaffType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPositionType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalaryType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartmentType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTitleType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRPType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecordType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBirthdayCue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContractCue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLookup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddressBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackupRestoreData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspLblUserID = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbtnManager = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLookup = new System.Windows.Forms.ToolStripButton();
            this.tsbtnStatistics = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnAddressBook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnQuit = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBase,
            this.menuManager,
            this.menuMemo,
            this.menuDatabase,
            this.menuTool,
            this.menuSystem,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(742, 25);
            this.menuStrip.TabIndex = 0;
            // 
            // menuBase
            // 
            this.menuBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuData,
            this.menuCue});
            this.menuBase.Name = "menuBase";
            this.menuBase.Size = new System.Drawing.Size(92, 21);
            this.menuBase.Text = "基础信息管理";
            // 
            // menuData
            // 
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNationType,
            this.tsmiEducationType,
            this.tsmiPoliticalStatusType,
            this.tsmiStaffType,
            this.tsmiPositionType,
            this.tsmiSalaryType,
            this.tsmiDepartmentType,
            this.tsmiTitleType,
            this.tsmiRPType,
            this.tsmiRecordType});
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(148, 22);
            this.menuData.Text = "基础数据";
            // 
            // tsmiNationType
            // 
            this.tsmiNationType.Name = "tsmiNationType";
            this.tsmiNationType.Size = new System.Drawing.Size(148, 22);
            this.tsmiNationType.Text = "民族类别设置";
            this.tsmiNationType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiEducationType
            // 
            this.tsmiEducationType.Name = "tsmiEducationType";
            this.tsmiEducationType.Size = new System.Drawing.Size(148, 22);
            this.tsmiEducationType.Text = "文化程度设置";
            this.tsmiEducationType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiPoliticalStatusType
            // 
            this.tsmiPoliticalStatusType.Name = "tsmiPoliticalStatusType";
            this.tsmiPoliticalStatusType.Size = new System.Drawing.Size(148, 22);
            this.tsmiPoliticalStatusType.Text = "政治面貌设置";
            this.tsmiPoliticalStatusType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiStaffType
            // 
            this.tsmiStaffType.Name = "tsmiStaffType";
            this.tsmiStaffType.Size = new System.Drawing.Size(148, 22);
            this.tsmiStaffType.Text = "职工类别设置";
            this.tsmiStaffType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiPositionType
            // 
            this.tsmiPositionType.Name = "tsmiPositionType";
            this.tsmiPositionType.Size = new System.Drawing.Size(148, 22);
            this.tsmiPositionType.Text = "职务类别设置";
            this.tsmiPositionType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiSalaryType
            // 
            this.tsmiSalaryType.Name = "tsmiSalaryType";
            this.tsmiSalaryType.Size = new System.Drawing.Size(148, 22);
            this.tsmiSalaryType.Text = "工资类别设置";
            this.tsmiSalaryType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiDepartmentType
            // 
            this.tsmiDepartmentType.Name = "tsmiDepartmentType";
            this.tsmiDepartmentType.Size = new System.Drawing.Size(148, 22);
            this.tsmiDepartmentType.Text = "部门类别设置";
            this.tsmiDepartmentType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiTitleType
            // 
            this.tsmiTitleType.Name = "tsmiTitleType";
            this.tsmiTitleType.Size = new System.Drawing.Size(148, 22);
            this.tsmiTitleType.Text = "职称类别设置";
            this.tsmiTitleType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiRPType
            // 
            this.tsmiRPType.Name = "tsmiRPType";
            this.tsmiRPType.Size = new System.Drawing.Size(148, 22);
            this.tsmiRPType.Text = "奖惩类别设置";
            this.tsmiRPType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiRecordType
            // 
            this.tsmiRecordType.Name = "tsmiRecordType";
            this.tsmiRecordType.Size = new System.Drawing.Size(148, 22);
            this.tsmiRecordType.Text = "记事类别设置";
            this.tsmiRecordType.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuCue
            // 
            this.menuCue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBirthdayCue,
            this.tsmiContractCue});
            this.menuCue.Name = "menuCue";
            this.menuCue.Size = new System.Drawing.Size(148, 22);
            this.menuCue.Text = "员工提示信息";
            // 
            // tsmiBirthdayCue
            // 
            this.tsmiBirthdayCue.Name = "tsmiBirthdayCue";
            this.tsmiBirthdayCue.Size = new System.Drawing.Size(148, 22);
            this.tsmiBirthdayCue.Text = "员工生日提示";
            this.tsmiBirthdayCue.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiContractCue
            // 
            this.tsmiContractCue.Name = "tsmiContractCue";
            this.tsmiContractCue.Size = new System.Drawing.Size(148, 22);
            this.tsmiContractCue.Text = "员工合同提示";
            this.tsmiContractCue.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuManager
            // 
            this.menuManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManager,
            this.tsmiLookup,
            this.tsmiStatistics});
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(68, 21);
            this.menuManager.Text = "人事管理";
            // 
            // tsmiManager
            // 
            this.tsmiManager.Name = "tsmiManager";
            this.tsmiManager.Size = new System.Drawing.Size(148, 22);
            this.tsmiManager.Text = "人事档案管理";
            this.tsmiManager.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiLookup
            // 
            this.tsmiLookup.Name = "tsmiLookup";
            this.tsmiLookup.Size = new System.Drawing.Size(148, 22);
            this.tsmiLookup.Text = "人事资料查询";
            this.tsmiLookup.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.Size = new System.Drawing.Size(148, 22);
            this.tsmiStatistics.Text = "人事资料统计";
            this.tsmiStatistics.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuMemo
            // 
            this.menuMemo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRecord,
            this.tsmiAddressBook});
            this.menuMemo.Name = "menuMemo";
            this.menuMemo.Size = new System.Drawing.Size(68, 21);
            this.menuMemo.Text = "备忘记录";
            // 
            // tsmiRecord
            // 
            this.tsmiRecord.Name = "tsmiRecord";
            this.tsmiRecord.Size = new System.Drawing.Size(124, 22);
            this.tsmiRecord.Text = "日常记事";
            this.tsmiRecord.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiAddressBook
            // 
            this.tsmiAddressBook.Name = "tsmiAddressBook";
            this.tsmiAddressBook.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddressBook.Text = "通讯录";
            this.tsmiAddressBook.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuDatabase
            // 
            this.menuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBackupRestoreData,
            this.tsmiDeleteData});
            this.menuDatabase.Name = "menuDatabase";
            this.menuDatabase.Size = new System.Drawing.Size(80, 21);
            this.menuDatabase.Text = "数据库维护";
            // 
            // tsmiBackupRestoreData
            // 
            this.tsmiBackupRestoreData.Name = "tsmiBackupRestoreData";
            this.tsmiBackupRestoreData.Size = new System.Drawing.Size(165, 22);
            this.tsmiBackupRestoreData.Text = "备份/还原数据库";
            this.tsmiBackupRestoreData.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiDeleteData
            // 
            this.tsmiDeleteData.Name = "tsmiDeleteData";
            this.tsmiDeleteData.Size = new System.Drawing.Size(165, 22);
            this.tsmiDeleteData.Text = "清空数据库";
            this.tsmiDeleteData.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuTool
            // 
            this.menuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCalculator,
            this.tsmiNotepad});
            this.menuTool.Name = "menuTool";
            this.menuTool.Size = new System.Drawing.Size(68, 21);
            this.menuTool.Text = "工具管理";
            // 
            // tsmiCalculator
            // 
            this.tsmiCalculator.Name = "tsmiCalculator";
            this.tsmiCalculator.Size = new System.Drawing.Size(112, 22);
            this.tsmiCalculator.Text = "计算器";
            this.tsmiCalculator.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiNotepad
            // 
            this.tsmiNotepad.Name = "tsmiNotepad";
            this.tsmiNotepad.Size = new System.Drawing.Size(112, 22);
            this.tsmiNotepad.Text = "记事本";
            this.tsmiNotepad.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReEntry,
            this.tsmiSet,
            this.tsmiQuit});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(68, 21);
            this.menuSystem.Text = "系统管理";
            // 
            // tsmiReEntry
            // 
            this.tsmiReEntry.Name = "tsmiReEntry";
            this.tsmiReEntry.Size = new System.Drawing.Size(124, 22);
            this.tsmiReEntry.Text = "重新登录";
            this.tsmiReEntry.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiSet
            // 
            this.tsmiSet.Name = "tsmiSet";
            this.tsmiSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiSet.Text = "用户设置";
            this.tsmiSet.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(124, 22);
            this.tsmiQuit.Text = "系统退出";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 21);
            this.menuHelp.Text = "帮助";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(124, 22);
            this.tsmiHelp.Text = "系统帮助";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tspLblUserID});
            this.statusStrip.Location = new System.Drawing.Point(0, 378);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(742, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(164, 17);
            this.toolStripStatusLabel1.Text = "||欢迎使用企业人事管理系统||";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel2.Text = "当前登录用户：　　";
            // 
            // tspLblUserID
            // 
            this.tspLblUserID.Name = "tspLblUserID";
            this.tspLblUserID.Size = new System.Drawing.Size(48, 17);
            this.tspLblUserID.Text = "UserID";
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 50);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(177, 328);
            this.treeView.TabIndex = 2;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnManager,
            this.tsbtnLookup,
            this.tsbtnStatistics,
            this.tsbtnRecord,
            this.toolStripSeparator1,
            this.tsbtnAddressBook,
            this.toolStripSeparator2,
            this.tsbtnQuit});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(742, 25);
            this.toolStrip.TabIndex = 3;
            // 
            // tsbtnManager
            // 
            this.tsbtnManager.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnManager.Image")));
            this.tsbtnManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnManager.Name = "tsbtnManager";
            this.tsbtnManager.Size = new System.Drawing.Size(100, 22);
            this.tsbtnManager.Text = "人事档案管理";
            this.tsbtnManager.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // tsbtnLookup
            // 
            this.tsbtnLookup.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLookup.Image")));
            this.tsbtnLookup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLookup.Name = "tsbtnLookup";
            this.tsbtnLookup.Size = new System.Drawing.Size(100, 22);
            this.tsbtnLookup.Text = "人事资料查询";
            this.tsbtnLookup.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // tsbtnStatistics
            // 
            this.tsbtnStatistics.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStatistics.Image")));
            this.tsbtnStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStatistics.Name = "tsbtnStatistics";
            this.tsbtnStatistics.Size = new System.Drawing.Size(100, 22);
            this.tsbtnStatistics.Text = "人事资料统计";
            this.tsbtnStatistics.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // tsbtnRecord
            // 
            this.tsbtnRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRecord.Image")));
            this.tsbtnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRecord.Name = "tsbtnRecord";
            this.tsbtnRecord.Size = new System.Drawing.Size(76, 22);
            this.tsbtnRecord.Text = "日常记事";
            this.tsbtnRecord.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnAddressBook
            // 
            this.tsbtnAddressBook.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddressBook.Image")));
            this.tsbtnAddressBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddressBook.Name = "tsbtnAddressBook";
            this.tsbtnAddressBook.Size = new System.Drawing.Size(64, 22);
            this.tsbtnAddressBook.Text = "通讯录";
            this.tsbtnAddressBook.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnQuit
            // 
            this.tsbtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnQuit.Image")));
            this.tsbtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnQuit.Name = "tsbtnQuit";
            this.tsbtnQuit.Size = new System.Drawing.Size(76, 22);
            this.tsbtnQuit.Text = "系统退出";
            this.tsbtnQuit.Click += new System.EventHandler(this.tsbtnQuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 400);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "企业人事管理系统";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Tsmi_EducationType_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuBase;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.ToolStripMenuItem tsmiNationType;
        private System.Windows.Forms.ToolStripMenuItem tsmiStaffType;
        private System.Windows.Forms.ToolStripMenuItem tsmiEducationType;
        private System.Windows.Forms.ToolStripMenuItem tsmiPoliticalStatusType;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalaryType;
        private System.Windows.Forms.ToolStripMenuItem tsmiPositionType;
        private System.Windows.Forms.ToolStripMenuItem tsmiTitleType;
        private System.Windows.Forms.ToolStripMenuItem tsmiRPType;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecordType;
        private System.Windows.Forms.ToolStripMenuItem menuCue;
        private System.Windows.Forms.ToolStripMenuItem tsmiBirthdayCue;
        private System.Windows.Forms.ToolStripMenuItem tsmiContractCue;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiLookup;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics;
        private System.Windows.Forms.ToolStripMenuItem menuMemo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecord;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddressBook;
        private System.Windows.Forms.ToolStripMenuItem menuDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackupRestoreData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteData;
        private System.Windows.Forms.ToolStripMenuItem menuTool;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalculator;
        private System.Windows.Forms.ToolStripMenuItem tsmiNotepad;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartmentType;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tspLblUserID;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripMenuItem tsmiReEntry;
        private System.Windows.Forms.ToolStripMenuItem tsmiSet;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbtnManager;
        private System.Windows.Forms.ToolStripButton tsbtnLookup;
        private System.Windows.Forms.ToolStripButton tsbtnStatistics;
        private System.Windows.Forms.ToolStripButton tsbtnAddressBook;
        private System.Windows.Forms.ToolStripButton tsbtnRecord;
        private System.Windows.Forms.ToolStripButton tsbtnQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}