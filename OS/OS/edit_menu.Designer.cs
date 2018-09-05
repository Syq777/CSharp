namespace OS
{
    partial class edit_menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_old = new System.Windows.Forms.TextBox();
            this.textBox_new = new System.Windows.Forms.TextBox();
            this.button_sure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原目录名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新目录名称：";
            // 
            // textBox_old
            // 
            this.textBox_old.Location = new System.Drawing.Point(121, 43);
            this.textBox_old.Name = "textBox_old";
            this.textBox_old.ReadOnly = true;
            this.textBox_old.Size = new System.Drawing.Size(130, 21);
            this.textBox_old.TabIndex = 2;
            this.textBox_old.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_new
            // 
            this.textBox_new.Location = new System.Drawing.Point(121, 84);
            this.textBox_new.MaxLength = 3;
            this.textBox_new.Name = "textBox_new";
            this.textBox_new.Size = new System.Drawing.Size(130, 21);
            this.textBox_new.TabIndex = 3;
            this.textBox_new.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_new.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_new_KeyPress);
            this.textBox_new.Leave += new System.EventHandler(this.textBox_new_Leave);
            // 
            // button_sure
            // 
            this.button_sure.Location = new System.Drawing.Point(344, 56);
            this.button_sure.Name = "button_sure";
            this.button_sure.Size = new System.Drawing.Size(75, 23);
            this.button_sure.TabIndex = 4;
            this.button_sure.Text = "保存";
            this.button_sure.UseVisualStyleBackColor = true;
            this.button_sure.Click += new System.EventHandler(this.button_sure_Click);
            // 
            // edit_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 146);
            this.Controls.Add(this.button_sure);
            this.Controls.Add(this.textBox_new);
            this.Controls.Add(this.textBox_old);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "edit_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改目录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.edit_menu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.edit_menu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_old;
        private System.Windows.Forms.TextBox textBox_new;
        private System.Windows.Forms.Button button_sure;
    }
}