namespace OS
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("本地磁盘C", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("本地磁盘D", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("计算机", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.contextMenuStrip_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建文件夹ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.文件夹ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tXT文件ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.可执行文件ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_file = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_file = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_harddisk1 = new System.Windows.Forms.Panel();
            this.panel_harddisk2 = new System.Windows.Forms.Panel();
            this.button_format = new System.Windows.Forms.Button();
            this.panel_file = new System.Windows.Forms.Panel();
            this.button_command = new System.Windows.Forms.Button();
            this.textBox_command = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_harddisk = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.contextMenuStrip_menu.SuspendLayout();
            this.contextMenuStrip_file.SuspendLayout();
            this.panel_file.SuspendLayout();
            this.panel_harddisk.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_menu
            // 
            this.contextMenuStrip_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建文件夹ToolStripMenuItem_menu,
            this.剪切ToolStripMenuItem_menu,
            this.复制ToolStripMenuItem_menu,
            this.粘贴ToolStripMenuItem_menu,
            this.重命名ToolStripMenuItem_menu,
            this.删除ToolStripMenuItem_menu,
            this.属性ToolStripMenuItem_menu});
            this.contextMenuStrip_menu.Name = "contextMenuStrip1";
            this.contextMenuStrip_menu.Size = new System.Drawing.Size(113, 158);
            // 
            // 新建文件夹ToolStripMenuItem_menu
            // 
            this.新建文件夹ToolStripMenuItem_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件夹ToolStripMenuItem_menu,
            this.tXT文件ToolStripMenuItem_menu,
            this.可执行文件ToolStripMenuItem_menu});
            this.新建文件夹ToolStripMenuItem_menu.Name = "新建文件夹ToolStripMenuItem_menu";
            this.新建文件夹ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.新建文件夹ToolStripMenuItem_menu.Text = "新建";
            // 
            // 文件夹ToolStripMenuItem_menu
            // 
            this.文件夹ToolStripMenuItem_menu.Name = "文件夹ToolStripMenuItem_menu";
            this.文件夹ToolStripMenuItem_menu.Size = new System.Drawing.Size(136, 22);
            this.文件夹ToolStripMenuItem_menu.Text = "文件夹";
            this.文件夹ToolStripMenuItem_menu.Click += new System.EventHandler(this.文件夹ToolStripMenuItem_menu_Click);
            // 
            // tXT文件ToolStripMenuItem_menu
            // 
            this.tXT文件ToolStripMenuItem_menu.Name = "tXT文件ToolStripMenuItem_menu";
            this.tXT文件ToolStripMenuItem_menu.Size = new System.Drawing.Size(136, 22);
            this.tXT文件ToolStripMenuItem_menu.Text = "文本文件";
            this.tXT文件ToolStripMenuItem_menu.Click += new System.EventHandler(this.TXT文件ToolStripMenuItem_menu_Click);
            // 
            // 可执行文件ToolStripMenuItem_menu
            // 
            this.可执行文件ToolStripMenuItem_menu.Name = "可执行文件ToolStripMenuItem_menu";
            this.可执行文件ToolStripMenuItem_menu.Size = new System.Drawing.Size(136, 22);
            this.可执行文件ToolStripMenuItem_menu.Text = "可执行文件";
            this.可执行文件ToolStripMenuItem_menu.Click += new System.EventHandler(this.可执行文件ToolStripMenuItem_menu_Click);
            // 
            // 剪切ToolStripMenuItem_menu
            // 
            this.剪切ToolStripMenuItem_menu.Name = "剪切ToolStripMenuItem_menu";
            this.剪切ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.剪切ToolStripMenuItem_menu.Text = "剪切";
            this.剪切ToolStripMenuItem_menu.Click += new System.EventHandler(this.剪切ToolStripMenuItem_menu_Click);
            // 
            // 复制ToolStripMenuItem_menu
            // 
            this.复制ToolStripMenuItem_menu.Name = "复制ToolStripMenuItem_menu";
            this.复制ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.复制ToolStripMenuItem_menu.Text = "复制";
            this.复制ToolStripMenuItem_menu.Click += new System.EventHandler(this.复制ToolStripMenuItem_menu_Click);
            // 
            // 粘贴ToolStripMenuItem_menu
            // 
            this.粘贴ToolStripMenuItem_menu.Enabled = false;
            this.粘贴ToolStripMenuItem_menu.Name = "粘贴ToolStripMenuItem_menu";
            this.粘贴ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.粘贴ToolStripMenuItem_menu.Text = "粘贴";
            this.粘贴ToolStripMenuItem_menu.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_menu_Click);
            // 
            // 重命名ToolStripMenuItem_menu
            // 
            this.重命名ToolStripMenuItem_menu.Name = "重命名ToolStripMenuItem_menu";
            this.重命名ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.重命名ToolStripMenuItem_menu.Text = "重命名";
            this.重命名ToolStripMenuItem_menu.Click += new System.EventHandler(this.重命名ToolStripMenuItem_menu_Click);
            // 
            // 删除ToolStripMenuItem_menu
            // 
            this.删除ToolStripMenuItem_menu.Name = "删除ToolStripMenuItem_menu";
            this.删除ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.删除ToolStripMenuItem_menu.Text = "删除";
            this.删除ToolStripMenuItem_menu.Click += new System.EventHandler(this.删除ToolStripMenuItem_menu_Click);
            // 
            // 属性ToolStripMenuItem_menu
            // 
            this.属性ToolStripMenuItem_menu.Name = "属性ToolStripMenuItem_menu";
            this.属性ToolStripMenuItem_menu.Size = new System.Drawing.Size(112, 22);
            this.属性ToolStripMenuItem_menu.Text = "属性";
            this.属性ToolStripMenuItem_menu.Click += new System.EventHandler(this.属性ToolStripMenuItem_menu_Click);
            // 
            // treeView_file
            // 
            this.treeView_file.ImageIndex = 0;
            this.treeView_file.ImageList = this.imageList;
            this.treeView_file.Location = new System.Drawing.Point(0, 0);
            this.treeView_file.Name = "treeView_file";
            treeNode1.ContextMenuStrip = this.contextMenuStrip_menu;
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "本地磁盘C";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "本地磁盘C";
            treeNode2.ContextMenuStrip = this.contextMenuStrip_menu;
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "本地磁盘D";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "本地磁盘D";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "计算机";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "计算机";
            this.treeView_file.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView_file.SelectedImageIndex = 0;
            this.treeView_file.ShowPlusMinus = false;
            this.treeView_file.ShowRootLines = false;
            this.treeView_file.Size = new System.Drawing.Size(333, 187);
            this.treeView_file.TabIndex = 1;
            this.treeView_file.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_file_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "我的电脑.png");
            this.imageList.Images.SetKeyName(1, "磁盘");
            this.imageList.Images.SetKeyName(2, "文件夹");
            this.imageList.Images.SetKeyName(3, "可执行文件");
            this.imageList.Images.SetKeyName(4, "文本文档");
            // 
            // contextMenuStrip_file
            // 
            this.contextMenuStrip_file.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行ToolStripMenuItem,
            this.打开ToolStripMenuItem_file,
            this.剪切ToolStripMenuItem_file,
            this.复制ToolStripMenuItem_file,
            this.删除ToolStripMenuItem_file,
            this.属性ToolStripMenuItem_file});
            this.contextMenuStrip_file.Name = "contextMenuStrip_file";
            this.contextMenuStrip_file.Size = new System.Drawing.Size(101, 136);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.运行ToolStripMenuItem.Text = "运行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.运行ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem_file
            // 
            this.打开ToolStripMenuItem_file.Name = "打开ToolStripMenuItem_file";
            this.打开ToolStripMenuItem_file.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem_file.Text = "编辑";
            this.打开ToolStripMenuItem_file.Click += new System.EventHandler(this.打开ToolStripMenuItem_file_Click);
            // 
            // 剪切ToolStripMenuItem_file
            // 
            this.剪切ToolStripMenuItem_file.Name = "剪切ToolStripMenuItem_file";
            this.剪切ToolStripMenuItem_file.Size = new System.Drawing.Size(100, 22);
            this.剪切ToolStripMenuItem_file.Text = "剪切";
            this.剪切ToolStripMenuItem_file.Click += new System.EventHandler(this.剪切ToolStripMenuItem_file_Click);
            // 
            // 复制ToolStripMenuItem_file
            // 
            this.复制ToolStripMenuItem_file.Name = "复制ToolStripMenuItem_file";
            this.复制ToolStripMenuItem_file.Size = new System.Drawing.Size(100, 22);
            this.复制ToolStripMenuItem_file.Text = "复制";
            this.复制ToolStripMenuItem_file.Click += new System.EventHandler(this.复制ToolStripMenuItem_file_Click);
            // 
            // 删除ToolStripMenuItem_file
            // 
            this.删除ToolStripMenuItem_file.Name = "删除ToolStripMenuItem_file";
            this.删除ToolStripMenuItem_file.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem_file.Text = "删除";
            this.删除ToolStripMenuItem_file.Click += new System.EventHandler(this.删除ToolStripMenuItem_file_Click);
            // 
            // 属性ToolStripMenuItem_file
            // 
            this.属性ToolStripMenuItem_file.Name = "属性ToolStripMenuItem_file";
            this.属性ToolStripMenuItem_file.Size = new System.Drawing.Size(100, 22);
            this.属性ToolStripMenuItem_file.Text = "属性";
            this.属性ToolStripMenuItem_file.Click += new System.EventHandler(this.属性ToolStripMenuItem_file_Click);
            // 
            // panel_harddisk1
            // 
            this.panel_harddisk1.Location = new System.Drawing.Point(3, 18);
            this.panel_harddisk1.Name = "panel_harddisk1";
            this.panel_harddisk1.Size = new System.Drawing.Size(240, 120);
            this.panel_harddisk1.TabIndex = 4;
            // 
            // panel_harddisk2
            // 
            this.panel_harddisk2.Location = new System.Drawing.Point(3, 156);
            this.panel_harddisk2.Name = "panel_harddisk2";
            this.panel_harddisk2.Size = new System.Drawing.Size(240, 120);
            this.panel_harddisk2.TabIndex = 5;
            // 
            // button_format
            // 
            this.button_format.Location = new System.Drawing.Point(258, 250);
            this.button_format.Name = "button_format";
            this.button_format.Size = new System.Drawing.Size(75, 23);
            this.button_format.TabIndex = 6;
            this.button_format.Text = "格式化";
            this.button_format.UseVisualStyleBackColor = true;
            this.button_format.Click += new System.EventHandler(this.button_format_Click);
            // 
            // panel_file
            // 
            this.panel_file.Controls.Add(this.button_command);
            this.panel_file.Controls.Add(this.textBox_command);
            this.panel_file.Controls.Add(this.label3);
            this.panel_file.Controls.Add(this.panel_harddisk);
            this.panel_file.Controls.Add(this.treeView_file);
            this.panel_file.Controls.Add(this.update);
            this.panel_file.Controls.Add(this.button_format);
            this.panel_file.Location = new System.Drawing.Point(504, 12);
            this.panel_file.Name = "panel_file";
            this.panel_file.Size = new System.Drawing.Size(333, 516);
            this.panel_file.TabIndex = 7;
            // 
            // button_command
            // 
            this.button_command.Location = new System.Drawing.Point(258, 194);
            this.button_command.Name = "button_command";
            this.button_command.Size = new System.Drawing.Size(75, 23);
            this.button_command.TabIndex = 11;
            this.button_command.Text = "执行";
            this.button_command.UseVisualStyleBackColor = true;
            this.button_command.Click += new System.EventHandler(this.button_command_Click);
            // 
            // textBox_command
            // 
            this.textBox_command.Location = new System.Drawing.Point(53, 197);
            this.textBox_command.Name = "textBox_command";
            this.textBox_command.Size = new System.Drawing.Size(193, 21);
            this.textBox_command.TabIndex = 10;
            this.textBox_command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_command_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "命令：";
            // 
            // panel_harddisk
            // 
            this.panel_harddisk.Controls.Add(this.label1);
            this.panel_harddisk.Controls.Add(this.label2);
            this.panel_harddisk.Controls.Add(this.panel_harddisk2);
            this.panel_harddisk.Controls.Add(this.panel_harddisk1);
            this.panel_harddisk.Location = new System.Drawing.Point(3, 232);
            this.panel_harddisk.Name = "panel_harddisk";
            this.panel_harddisk.Size = new System.Drawing.Size(249, 280);
            this.panel_harddisk.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "本地磁盘D";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "本地磁盘C";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(258, 388);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 8;
            this.update.Text = "刷新";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 534);
            this.Controls.Add(this.panel_file);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模拟操作系统";
            this.contextMenuStrip_menu.ResumeLayout(false);
            this.contextMenuStrip_file.ResumeLayout(false);
            this.panel_file.ResumeLayout(false);
            this.panel_file.PerformLayout();
            this.panel_harddisk.ResumeLayout(false);
            this.panel_harddisk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_file;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_menu;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 文件夹ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem tXT文件ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 可执行文件ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem_menu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_file;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem_file;
        private System.Windows.Forms.Panel panel_harddisk1;
        private System.Windows.Forms.Panel panel_harddisk2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button button_format;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_file;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_harddisk;
        private System.Windows.Forms.Button button_command;
        private System.Windows.Forms.TextBox textBox_command;
        private System.Windows.Forms.Label label3;
    }
}

