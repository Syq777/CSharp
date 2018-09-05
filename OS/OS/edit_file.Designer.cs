namespace OS
{
    partial class edit_file
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
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.radioButton_exe = new System.Windows.Forms.RadioButton();
            this.radioButton_txt = new System.Windows.Forms.RadioButton();
            this.panel_type = new System.Windows.Forms.Panel();
            this.checkBox_readonly = new System.Windows.Forms.CheckBox();
            this.panel_type.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(41, 89);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(475, 289);
            this.textBox_content.TabIndex = 0;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(324, 409);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(101, 409);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 2;
            this.button_clear.Text = "清除内容";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "名称：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(61, 27);
            this.textBox_name.MaxLength = 3;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(139, 21);
            this.textBox_name.TabIndex = 4;
            this.textBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_name_KeyPress);
            // 
            // radioButton_exe
            // 
            this.radioButton_exe.AutoSize = true;
            this.radioButton_exe.Location = new System.Drawing.Point(3, 50);
            this.radioButton_exe.Name = "radioButton_exe";
            this.radioButton_exe.Size = new System.Drawing.Size(83, 16);
            this.radioButton_exe.TabIndex = 5;
            this.radioButton_exe.TabStop = true;
            this.radioButton_exe.Text = "可执行文件";
            this.radioButton_exe.UseVisualStyleBackColor = true;
            // 
            // radioButton_txt
            // 
            this.radioButton_txt.AutoSize = true;
            this.radioButton_txt.Location = new System.Drawing.Point(3, 19);
            this.radioButton_txt.Name = "radioButton_txt";
            this.radioButton_txt.Size = new System.Drawing.Size(71, 16);
            this.radioButton_txt.TabIndex = 6;
            this.radioButton_txt.TabStop = true;
            this.radioButton_txt.Text = "文本文档";
            this.radioButton_txt.UseVisualStyleBackColor = true;
            // 
            // panel_type
            // 
            this.panel_type.Controls.Add(this.radioButton_exe);
            this.panel_type.Controls.Add(this.radioButton_txt);
            this.panel_type.Location = new System.Drawing.Point(227, 8);
            this.panel_type.Name = "panel_type";
            this.panel_type.Size = new System.Drawing.Size(99, 73);
            this.panel_type.TabIndex = 7;
            // 
            // checkBox_readonly
            // 
            this.checkBox_readonly.AutoSize = true;
            this.checkBox_readonly.Location = new System.Drawing.Point(411, 29);
            this.checkBox_readonly.Name = "checkBox_readonly";
            this.checkBox_readonly.Size = new System.Drawing.Size(48, 16);
            this.checkBox_readonly.TabIndex = 8;
            this.checkBox_readonly.Text = "只读";
            this.checkBox_readonly.UseVisualStyleBackColor = true;
            this.checkBox_readonly.CheckedChanged += new System.EventHandler(this.checkBox_readonly_CheckedChanged);
            // 
            // edit_file
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 471);
            this.Controls.Add(this.checkBox_readonly);
            this.Controls.Add(this.panel_type);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_content);
            this.MaximizeBox = false;
            this.Name = "edit_file";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑文件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.edit_file_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.edit_file_FormClosed);
            this.panel_type.ResumeLayout(false);
            this.panel_type.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.RadioButton radioButton_exe;
        private System.Windows.Forms.RadioButton radioButton_txt;
        private System.Windows.Forms.Panel panel_type;
        private System.Windows.Forms.CheckBox checkBox_readonly;
    }
}