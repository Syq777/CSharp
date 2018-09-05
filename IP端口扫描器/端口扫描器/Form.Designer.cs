namespace 端口扫描器
{
    partial class Form
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
            this.button_start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.button_end = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label_tip = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_startport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_endport = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(523, 33);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 10;
            this.button_start.TabStop = false;
            this.button_start.Text = "扫描";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 9);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(121, 9);
            this.textBox2.MaxLength = 3;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(174, 9);
            this.textBox3.MaxLength = 3;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 21);
            this.textBox3.TabIndex = 2;
            this.textBox3.TabStop = false;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(226, 9);
            this.textBox4.MaxLength = 3;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 21);
            this.textBox4.TabIndex = 3;
            this.textBox4.TabStop = false;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP地址：";
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 14;
            this.listBox.Location = new System.Drawing.Point(12, 78);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(459, 172);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 7;
            this.listBox.TabStop = false;
            // 
            // button_end
            // 
            this.button_end.Location = new System.Drawing.Point(523, 173);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(75, 23);
            this.button_end.TabIndex = 8;
            this.button_end.TabStop = false;
            this.button_end.Text = "取消";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // label_tip
            // 
            this.label_tip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_tip.AutoSize = true;
            this.label_tip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tip.Location = new System.Drawing.Point(159, 338);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(0, 16);
            this.label_tip.TabIndex = 9;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 291);
            this.progressBar.Maximum = 65535;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(641, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 10;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(302, 7);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 11;
            this.button_clear.TabStop = false;
            this.button_clear.Text = "清空";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(523, 103);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 12;
            this.button_stop.TabStop = false;
            this.button_stop.Text = "暂停";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "开始端口：";
            // 
            // textBox_startport
            // 
            this.textBox_startport.Location = new System.Drawing.Point(71, 51);
            this.textBox_startport.MaxLength = 5;
            this.textBox_startport.Name = "textBox_startport";
            this.textBox_startport.Size = new System.Drawing.Size(40, 21);
            this.textBox_startport.TabIndex = 4;
            this.textBox_startport.TabStop = false;
            this.textBox_startport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_startport.TextChanged += new System.EventHandler(this.textBox_startport_TextChanged);
            this.textBox_startport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_startport_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "结束端口：";
            // 
            // textBox_endport
            // 
            this.textBox_endport.Location = new System.Drawing.Point(226, 51);
            this.textBox_endport.MaxLength = 5;
            this.textBox_endport.Name = "textBox_endport";
            this.textBox_endport.Size = new System.Drawing.Size(40, 21);
            this.textBox_endport.TabIndex = 5;
            this.textBox_endport.TabStop = false;
            this.textBox_endport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_endport.TextChanged += new System.EventHandler(this.textBox_endport_TextChanged);
            this.textBox_endport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_endport_KeyPress);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(679, 363);
            this.Controls.Add(this.textBox_endport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_startport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label_tip);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "端口扫描器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button_end;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_startport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_endport;
    }
}

