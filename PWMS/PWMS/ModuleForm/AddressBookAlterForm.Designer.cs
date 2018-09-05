namespace PWMS.ModuleForm
{
    partial class AddressBookAlterForm
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.address_Mailbox = new System.Windows.Forms.TextBox();
            this.address_QQ = new System.Windows.Forms.TextBox();
            this.address_Phone = new System.Windows.Forms.TextBox();
            this.address_Sex = new System.Windows.Forms.ComboBox();
            this.address_Name = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.address_Mailbox);
            this.groupBox.Controls.Add(this.address_QQ);
            this.groupBox.Controls.Add(this.address_Phone);
            this.groupBox.Controls.Add(this.address_Sex);
            this.groupBox.Controls.Add(this.address_Name);
            this.groupBox.Location = new System.Drawing.Point(13, 13);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(373, 110);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "通讯录信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "QQ号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "性别";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "邮箱地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "手机号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "姓名";
            // 
            // address_Mailbox
            // 
            this.address_Mailbox.Location = new System.Drawing.Point(71, 76);
            this.address_Mailbox.Name = "address_Mailbox";
            this.address_Mailbox.Size = new System.Drawing.Size(283, 21);
            this.address_Mailbox.TabIndex = 4;
            // 
            // address_QQ
            // 
            this.address_QQ.Location = new System.Drawing.Point(229, 47);
            this.address_QQ.Name = "address_QQ";
            this.address_QQ.Size = new System.Drawing.Size(125, 21);
            this.address_QQ.TabIndex = 3;
            this.address_QQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Int_KeyPress);
            // 
            // address_Phone
            // 
            this.address_Phone.Location = new System.Drawing.Point(71, 48);
            this.address_Phone.Name = "address_Phone";
            this.address_Phone.Size = new System.Drawing.Size(100, 21);
            this.address_Phone.TabIndex = 2;
            this.address_Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Int_KeyPress);
            // 
            // address_Sex
            // 
            this.address_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.address_Sex.FormattingEnabled = true;
            this.address_Sex.Location = new System.Drawing.Point(229, 20);
            this.address_Sex.Name = "address_Sex";
            this.address_Sex.Size = new System.Drawing.Size(125, 20);
            this.address_Sex.TabIndex = 1;
            // 
            // address_Name
            // 
            this.address_Name.Location = new System.Drawing.Point(71, 20);
            this.address_Name.Name = "address_Name";
            this.address_Name.Size = new System.Drawing.Size(100, 21);
            this.address_Name.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuit);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(13, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(279, 32);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(171, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddressBookAlterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 214);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddressBookAlterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddressBookAlterForm";
            this.Load += new System.EventHandler(this.AddressBookAlterForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox address_Mailbox;
        private System.Windows.Forms.TextBox address_QQ;
        private System.Windows.Forms.TextBox address_Phone;
        private System.Windows.Forms.ComboBox address_Sex;
        private System.Windows.Forms.TextBox address_Name;
    }
}