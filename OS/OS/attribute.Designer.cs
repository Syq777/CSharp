namespace OS
{
    partial class attribute
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
            this.label2 = new System.Windows.Forms.Label();
            this.label_length = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.textBox_disknum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label_attribute = new System.Windows.Forms.Label();
            this.checkBox_readonly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "类型：";
            // 
            // label_length
            // 
            this.label_length.AutoSize = true;
            this.label_length.Location = new System.Drawing.Point(12, 203);
            this.label_length.Name = "label_length";
            this.label_length.Size = new System.Drawing.Size(65, 12);
            this.label_length.TabIndex = 2;
            this.label_length.Text = "占用空间：";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(12, 154);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(77, 12);
            this.label_address.TabIndex = 3;
            this.label_address.Text = "起始盘块号：";
            this.label_address.Leave += new System.EventHandler(this.label_address_Leave);
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_name.Location = new System.Drawing.Point(84, 33);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(100, 14);
            this.textBox_name.TabIndex = 4;
            // 
            // textBox_type
            // 
            this.textBox_type.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_type.Location = new System.Drawing.Point(136, 72);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.ReadOnly = true;
            this.textBox_type.Size = new System.Drawing.Size(100, 14);
            this.textBox_type.TabIndex = 5;
            // 
            // textBox_length
            // 
            this.textBox_length.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_length.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_length.Location = new System.Drawing.Point(136, 203);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.ReadOnly = true;
            this.textBox_length.Size = new System.Drawing.Size(100, 14);
            this.textBox_length.TabIndex = 6;
            // 
            // textBox_address
            // 
            this.textBox_address.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_address.Location = new System.Drawing.Point(136, 154);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.ReadOnly = true;
            this.textBox_address.Size = new System.Drawing.Size(100, 14);
            this.textBox_address.TabIndex = 7;
            // 
            // textBox_disknum
            // 
            this.textBox_disknum.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_disknum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_disknum.Location = new System.Drawing.Point(83, 353);
            this.textBox_disknum.Name = "textBox_disknum";
            this.textBox_disknum.ReadOnly = true;
            this.textBox_disknum.Size = new System.Drawing.Size(100, 14);
            this.textBox_disknum.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "目录项盘块：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "位置：";
            // 
            // textBox_path
            // 
            this.textBox_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_path.Location = new System.Drawing.Point(136, 107);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(317, 14);
            this.textBox_path.TabIndex = 11;
            // 
            // label_attribute
            // 
            this.label_attribute.AutoSize = true;
            this.label_attribute.Location = new System.Drawing.Point(13, 252);
            this.label_attribute.Name = "label_attribute";
            this.label_attribute.Size = new System.Drawing.Size(41, 12);
            this.label_attribute.TabIndex = 12;
            this.label_attribute.Text = "属性：";
            // 
            // checkBox_readonly
            // 
            this.checkBox_readonly.AutoCheck = false;
            this.checkBox_readonly.AutoSize = true;
            this.checkBox_readonly.Location = new System.Drawing.Point(136, 248);
            this.checkBox_readonly.Name = "checkBox_readonly";
            this.checkBox_readonly.Size = new System.Drawing.Size(48, 16);
            this.checkBox_readonly.TabIndex = 14;
            this.checkBox_readonly.Text = "只读";
            this.checkBox_readonly.UseVisualStyleBackColor = true;
            // 
            // attribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(452, 371);
            this.Controls.Add(this.checkBox_readonly);
            this.Controls.Add(this.label_attribute);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_disknum);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.textBox_length);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.label_length);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "attribute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "属性";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.attribute_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_length;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.TextBox textBox_length;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.TextBox textBox_disknum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label_attribute;
        private System.Windows.Forms.CheckBox checkBox_readonly;
    }
}