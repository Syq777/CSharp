namespace PWMS.ModuleForm
{
    partial class StatisticsForm
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
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.lstCondition = new System.Windows.Forms.ListBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.grpCondition.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCondition
            // 
            this.grpCondition.Controls.Add(this.lstCondition);
            this.grpCondition.Location = new System.Drawing.Point(12, 12);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(159, 297);
            this.grpCondition.TabIndex = 0;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "统计条件";
            // 
            // lstCondition
            // 
            this.lstCondition.FormattingEnabled = true;
            this.lstCondition.ItemHeight = 12;
            this.lstCondition.Location = new System.Drawing.Point(6, 20);
            this.lstCondition.Name = "lstCondition";
            this.lstCondition.Size = new System.Drawing.Size(147, 268);
            this.lstCondition.TabIndex = 0;
            this.lstCondition.SelectedIndexChanged += new System.EventHandler(this.lstCondition_SelectedIndexChanged);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvData);
            this.grpData.Location = new System.Drawing.Point(190, 12);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(288, 297);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "统计结果";
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(6, 20);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(276, 268);
            this.dgvData.TabIndex = 0;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 329);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpCondition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.grpCondition.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.ListBox lstCondition;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvData;
    }
}