namespace OS
{
    partial class create_menu
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
            this.button_sure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_sure
            // 
            this.button_sure.Location = new System.Drawing.Point(325, 37);
            this.button_sure.Name = "button_sure";
            this.button_sure.Size = new System.Drawing.Size(75, 23);
            this.button_sure.TabIndex = 0;
            this.button_sure.Text = "创建";
            this.button_sure.UseVisualStyleBackColor = true;
            this.button_sure.Click += new System.EventHandler(this.button_sure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目录名称：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(92, 37);
            this.textBox_name.MaxLength = 3;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(138, 21);
            this.textBox_name.TabIndex = 2;
            this.textBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_name_KeyPress);
            this.textBox_name.Leave += new System.EventHandler(this.textBox_name_Leave);
            // 
            // create_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 97);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_sure);
            this.MaximizeBox = false;
            this.Name = "create_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建文件夹";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.create_menu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.create_menu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_sure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
    }
}