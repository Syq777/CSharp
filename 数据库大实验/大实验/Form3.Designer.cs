namespace 大实验
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_no = new System.Windows.Forms.TabPage();
            this.textBox_position = new System.Windows.Forms.TextBox();
            this.textBox_sex = new System.Windows.Forms.TextBox();
            this.textBox_no = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_position = new System.Windows.Forms.Label();
            this.label_sex = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_no = new System.Windows.Forms.Label();
            this.tabPage_course = new System.Windows.Forms.TabPage();
            this.button_course_serach = new System.Windows.Forms.Button();
            this.textBox_course = new System.Windows.Forms.TextBox();
            this.comboBox_course = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_course_update = new System.Windows.Forms.Button();
            this.dataGridView_course = new System.Windows.Forms.DataGridView();
            this.tabPage_student = new System.Windows.Forms.TabPage();
            this.button_student_search = new System.Windows.Forms.Button();
            this.textBox_student = new System.Windows.Forms.TextBox();
            this.comboBox_student = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_grade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_student_update = new System.Windows.Forms.Button();
            this.button_student_write = new System.Windows.Forms.Button();
            this.dataGridView_student = new System.Windows.Forms.DataGridView();
            this.tabPage_password = new System.Windows.Forms.TabPage();
            this.textBox_new_password2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_new_password = new System.Windows.Forms.TextBox();
            this.textBox_old_password = new System.Windows.Forms.TextBox();
            this.label_new_password = new System.Windows.Forms.Label();
            this.label_old_password = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.button_sure = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_no.SuspendLayout();
            this.tabPage_course.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_course)).BeginInit();
            this.tabPage_student.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).BeginInit();
            this.tabPage_password.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage_no);
            this.tabControl1.Controls.Add(this.tabPage_course);
            this.tabControl1.Controls.Add(this.tabPage_student);
            this.tabControl1.Controls.Add(this.tabPage_password);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_no
            // 
            this.tabPage_no.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage_no.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage_no.BackgroundImage")));
            this.tabPage_no.Controls.Add(this.textBox_position);
            this.tabPage_no.Controls.Add(this.textBox_sex);
            this.tabPage_no.Controls.Add(this.textBox_no);
            this.tabPage_no.Controls.Add(this.textBox_name);
            this.tabPage_no.Controls.Add(this.label_position);
            this.tabPage_no.Controls.Add(this.label_sex);
            this.tabPage_no.Controls.Add(this.label_name);
            this.tabPage_no.Controls.Add(this.label_no);
            this.tabPage_no.Location = new System.Drawing.Point(4, 27);
            this.tabPage_no.Name = "tabPage_no";
            this.tabPage_no.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_no.Size = new System.Drawing.Size(976, 480);
            this.tabPage_no.TabIndex = 0;
            this.tabPage_no.Text = "个人信息";
            // 
            // textBox_position
            // 
            this.textBox_position.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox_position.Location = new System.Drawing.Point(92, 116);
            this.textBox_position.Name = "textBox_position";
            this.textBox_position.ReadOnly = true;
            this.textBox_position.Size = new System.Drawing.Size(100, 23);
            this.textBox_position.TabIndex = 7;
            // 
            // textBox_sex
            // 
            this.textBox_sex.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox_sex.Location = new System.Drawing.Point(92, 85);
            this.textBox_sex.Name = "textBox_sex";
            this.textBox_sex.ReadOnly = true;
            this.textBox_sex.Size = new System.Drawing.Size(100, 23);
            this.textBox_sex.TabIndex = 6;
            // 
            // textBox_no
            // 
            this.textBox_no.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox_no.Location = new System.Drawing.Point(92, 24);
            this.textBox_no.Name = "textBox_no";
            this.textBox_no.ReadOnly = true;
            this.textBox_no.Size = new System.Drawing.Size(100, 23);
            this.textBox_no.TabIndex = 5;
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox_name.Location = new System.Drawing.Point(92, 52);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(100, 23);
            this.textBox_name.TabIndex = 4;
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.BackColor = System.Drawing.Color.Transparent;
            this.label_position.Location = new System.Drawing.Point(12, 116);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(49, 14);
            this.label_position.TabIndex = 3;
            this.label_position.Text = "职称：";
            // 
            // label_sex
            // 
            this.label_sex.AutoSize = true;
            this.label_sex.BackColor = System.Drawing.Color.Transparent;
            this.label_sex.Location = new System.Drawing.Point(12, 85);
            this.label_sex.Name = "label_sex";
            this.label_sex.Size = new System.Drawing.Size(49, 14);
            this.label_sex.TabIndex = 2;
            this.label_sex.Text = "性别：";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Location = new System.Drawing.Point(12, 52);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(49, 14);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "姓名：";
            // 
            // label_no
            // 
            this.label_no.AutoSize = true;
            this.label_no.BackColor = System.Drawing.Color.Transparent;
            this.label_no.Location = new System.Drawing.Point(12, 24);
            this.label_no.Name = "label_no";
            this.label_no.Size = new System.Drawing.Size(49, 14);
            this.label_no.TabIndex = 0;
            this.label_no.Text = "编号：";
            // 
            // tabPage_course
            // 
            this.tabPage_course.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage_course.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage_course.BackgroundImage")));
            this.tabPage_course.Controls.Add(this.button_course_serach);
            this.tabPage_course.Controls.Add(this.textBox_course);
            this.tabPage_course.Controls.Add(this.comboBox_course);
            this.tabPage_course.Controls.Add(this.label5);
            this.tabPage_course.Controls.Add(this.label4);
            this.tabPage_course.Controls.Add(this.button_course_update);
            this.tabPage_course.Controls.Add(this.dataGridView_course);
            this.tabPage_course.Location = new System.Drawing.Point(4, 27);
            this.tabPage_course.Name = "tabPage_course";
            this.tabPage_course.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_course.Size = new System.Drawing.Size(976, 480);
            this.tabPage_course.TabIndex = 1;
            this.tabPage_course.Text = "授课信息";
            // 
            // button_course_serach
            // 
            this.button_course_serach.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_course_serach.Location = new System.Drawing.Point(521, 25);
            this.button_course_serach.Name = "button_course_serach";
            this.button_course_serach.Size = new System.Drawing.Size(75, 23);
            this.button_course_serach.TabIndex = 7;
            this.button_course_serach.Text = "查询";
            this.button_course_serach.UseVisualStyleBackColor = false;
            this.button_course_serach.Click += new System.EventHandler(this.button_course_serach_Click);
            // 
            // textBox_course
            // 
            this.textBox_course.Location = new System.Drawing.Point(296, 25);
            this.textBox_course.Name = "textBox_course";
            this.textBox_course.Size = new System.Drawing.Size(100, 23);
            this.textBox_course.TabIndex = 6;
            // 
            // comboBox_course
            // 
            this.comboBox_course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_course.FormattingEnabled = true;
            this.comboBox_course.Items.AddRange(new object[] {
            "课程号",
            "课程名",
            "学分",
            "课时",
            "上课时间",
            "上课地点"});
            this.comboBox_course.Location = new System.Drawing.Point(80, 25);
            this.comboBox_course.Name = "comboBox_course";
            this.comboBox_course.Size = new System.Drawing.Size(121, 22);
            this.comboBox_course.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(225, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "查询条件：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "查询类型：";
            // 
            // button_course_update
            // 
            this.button_course_update.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_course_update.Location = new System.Drawing.Point(670, 25);
            this.button_course_update.Name = "button_course_update";
            this.button_course_update.Size = new System.Drawing.Size(75, 23);
            this.button_course_update.TabIndex = 2;
            this.button_course_update.Text = "全部";
            this.button_course_update.UseVisualStyleBackColor = false;
            this.button_course_update.Click += new System.EventHandler(this.button_course_update_Click);
            // 
            // dataGridView_course
            // 
            this.dataGridView_course.AllowUserToAddRows = false;
            this.dataGridView_course.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_course.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_course.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_course.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_course.Location = new System.Drawing.Point(0, 69);
            this.dataGridView_course.MultiSelect = false;
            this.dataGridView_course.Name = "dataGridView_course";
            this.dataGridView_course.RowHeadersVisible = false;
            this.dataGridView_course.RowTemplate.Height = 23;
            this.dataGridView_course.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_course.Size = new System.Drawing.Size(976, 413);
            this.dataGridView_course.TabIndex = 0;
            // 
            // tabPage_student
            // 
            this.tabPage_student.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage_student.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage_student.BackgroundImage")));
            this.tabPage_student.Controls.Add(this.button_student_search);
            this.tabPage_student.Controls.Add(this.textBox_student);
            this.tabPage_student.Controls.Add(this.comboBox_student);
            this.tabPage_student.Controls.Add(this.label3);
            this.tabPage_student.Controls.Add(this.label2);
            this.tabPage_student.Controls.Add(this.textBox_grade);
            this.tabPage_student.Controls.Add(this.label1);
            this.tabPage_student.Controls.Add(this.button_student_update);
            this.tabPage_student.Controls.Add(this.button_student_write);
            this.tabPage_student.Controls.Add(this.dataGridView_student);
            this.tabPage_student.Location = new System.Drawing.Point(4, 27);
            this.tabPage_student.Name = "tabPage_student";
            this.tabPage_student.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_student.Size = new System.Drawing.Size(976, 480);
            this.tabPage_student.TabIndex = 2;
            this.tabPage_student.Text = "学生信息";
            // 
            // button_student_search
            // 
            this.button_student_search.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_student_search.Location = new System.Drawing.Point(418, 25);
            this.button_student_search.Name = "button_student_search";
            this.button_student_search.Size = new System.Drawing.Size(75, 23);
            this.button_student_search.TabIndex = 9;
            this.button_student_search.Text = "查询";
            this.button_student_search.UseVisualStyleBackColor = false;
            this.button_student_search.Click += new System.EventHandler(this.button_student_search_Click);
            // 
            // textBox_student
            // 
            this.textBox_student.Location = new System.Drawing.Point(277, 25);
            this.textBox_student.Name = "textBox_student";
            this.textBox_student.Size = new System.Drawing.Size(100, 23);
            this.textBox_student.TabIndex = 8;
            // 
            // comboBox_student
            // 
            this.comboBox_student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_student.FormattingEnabled = true;
            this.comboBox_student.Items.AddRange(new object[] {
            "课程号",
            "课程名",
            "学号",
            "姓名",
            "性别",
            "专业"});
            this.comboBox_student.Location = new System.Drawing.Point(91, 25);
            this.comboBox_student.Name = "comboBox_student";
            this.comboBox_student.Size = new System.Drawing.Size(121, 22);
            this.comboBox_student.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(218, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "查询条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "查询类型";
            // 
            // textBox_grade
            // 
            this.textBox_grade.Location = new System.Drawing.Point(819, 25);
            this.textBox_grade.Name = "textBox_grade";
            this.textBox_grade.Size = new System.Drawing.Size(41, 23);
            this.textBox_grade.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(748, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "修改分数：";
            // 
            // button_student_update
            // 
            this.button_student_update.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_student_update.Location = new System.Drawing.Point(525, 25);
            this.button_student_update.Name = "button_student_update";
            this.button_student_update.Size = new System.Drawing.Size(75, 23);
            this.button_student_update.TabIndex = 2;
            this.button_student_update.Text = "全部";
            this.button_student_update.UseVisualStyleBackColor = false;
            this.button_student_update.Click += new System.EventHandler(this.button_student_update_Click);
            // 
            // button_student_write
            // 
            this.button_student_write.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_student_write.Location = new System.Drawing.Point(881, 25);
            this.button_student_write.Name = "button_student_write";
            this.button_student_write.Size = new System.Drawing.Size(75, 23);
            this.button_student_write.TabIndex = 1;
            this.button_student_write.Text = "确定";
            this.button_student_write.UseVisualStyleBackColor = false;
            this.button_student_write.Click += new System.EventHandler(this.button_student_write_Click);
            // 
            // dataGridView_student
            // 
            this.dataGridView_student.AllowUserToAddRows = false;
            this.dataGridView_student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_student.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_student.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_student.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_student.Location = new System.Drawing.Point(0, 69);
            this.dataGridView_student.MultiSelect = false;
            this.dataGridView_student.Name = "dataGridView_student";
            this.dataGridView_student.RowHeadersVisible = false;
            this.dataGridView_student.RowTemplate.Height = 23;
            this.dataGridView_student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_student.Size = new System.Drawing.Size(976, 413);
            this.dataGridView_student.TabIndex = 0;
            // 
            // tabPage_password
            // 
            this.tabPage_password.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage_password.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage_password.BackgroundImage")));
            this.tabPage_password.Controls.Add(this.textBox_new_password2);
            this.tabPage_password.Controls.Add(this.label6);
            this.tabPage_password.Controls.Add(this.textBox_new_password);
            this.tabPage_password.Controls.Add(this.textBox_old_password);
            this.tabPage_password.Controls.Add(this.label_new_password);
            this.tabPage_password.Controls.Add(this.label_old_password);
            this.tabPage_password.Controls.Add(this.button_close);
            this.tabPage_password.Controls.Add(this.button_sure);
            this.tabPage_password.Location = new System.Drawing.Point(4, 27);
            this.tabPage_password.Name = "tabPage_password";
            this.tabPage_password.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_password.Size = new System.Drawing.Size(976, 480);
            this.tabPage_password.TabIndex = 3;
            this.tabPage_password.Text = "修改密码";
            // 
            // textBox_new_password2
            // 
            this.textBox_new_password2.Location = new System.Drawing.Point(489, 262);
            this.textBox_new_password2.Name = "textBox_new_password2";
            this.textBox_new_password2.PasswordChar = '*';
            this.textBox_new_password2.Size = new System.Drawing.Size(100, 23);
            this.textBox_new_password2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "确认密码";
            // 
            // textBox_new_password
            // 
            this.textBox_new_password.Location = new System.Drawing.Point(489, 173);
            this.textBox_new_password.Name = "textBox_new_password";
            this.textBox_new_password.PasswordChar = '*';
            this.textBox_new_password.Size = new System.Drawing.Size(100, 23);
            this.textBox_new_password.TabIndex = 5;
            // 
            // textBox_old_password
            // 
            this.textBox_old_password.Location = new System.Drawing.Point(489, 90);
            this.textBox_old_password.Name = "textBox_old_password";
            this.textBox_old_password.PasswordChar = '*';
            this.textBox_old_password.Size = new System.Drawing.Size(100, 23);
            this.textBox_old_password.TabIndex = 4;
            // 
            // label_new_password
            // 
            this.label_new_password.AutoSize = true;
            this.label_new_password.BackColor = System.Drawing.Color.Transparent;
            this.label_new_password.Location = new System.Drawing.Point(337, 173);
            this.label_new_password.Name = "label_new_password";
            this.label_new_password.Size = new System.Drawing.Size(49, 14);
            this.label_new_password.TabIndex = 3;
            this.label_new_password.Text = "新密码";
            // 
            // label_old_password
            // 
            this.label_old_password.AutoSize = true;
            this.label_old_password.BackColor = System.Drawing.Color.Transparent;
            this.label_old_password.Location = new System.Drawing.Point(337, 90);
            this.label_old_password.Name = "label_old_password";
            this.label_old_password.Size = new System.Drawing.Size(49, 14);
            this.label_old_password.TabIndex = 2;
            this.label_old_password.Text = "原密码";
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_close.Location = new System.Drawing.Point(489, 342);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "取消";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_sure
            // 
            this.button_sure.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_sure.Location = new System.Drawing.Point(340, 342);
            this.button_sure.Name = "button_sure";
            this.button_sure.Size = new System.Drawing.Size(75, 23);
            this.button_sure.TabIndex = 0;
            this.button_sure.Text = "确定";
            this.button_sure.UseVisualStyleBackColor = false;
            this.button_sure.Click += new System.EventHandler(this.button_sure_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教师";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_no.ResumeLayout(false);
            this.tabPage_no.PerformLayout();
            this.tabPage_course.ResumeLayout(false);
            this.tabPage_course.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_course)).EndInit();
            this.tabPage_student.ResumeLayout(false);
            this.tabPage_student.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).EndInit();
            this.tabPage_password.ResumeLayout(false);
            this.tabPage_password.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_no;
        private System.Windows.Forms.TabPage tabPage_course;
        private System.Windows.Forms.DataGridView dataGridView_course;
        private System.Windows.Forms.TabPage tabPage_student;
        private System.Windows.Forms.DataGridView dataGridView_student;
        private System.Windows.Forms.TabPage tabPage_password;
        private System.Windows.Forms.TextBox textBox_new_password;
        private System.Windows.Forms.TextBox textBox_old_password;
        private System.Windows.Forms.Label label_new_password;
        private System.Windows.Forms.Label label_old_password;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_sure;
        private System.Windows.Forms.TextBox textBox_position;
        private System.Windows.Forms.TextBox textBox_sex;
        private System.Windows.Forms.TextBox textBox_no;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_position;
        private System.Windows.Forms.Label label_sex;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_no;
        private System.Windows.Forms.Button button_course_update;
        private System.Windows.Forms.TextBox textBox_grade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_student_update;
        private System.Windows.Forms.Button button_student_write;
        private System.Windows.Forms.Button button_student_search;
        private System.Windows.Forms.TextBox textBox_student;
        private System.Windows.Forms.ComboBox comboBox_student;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_course;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_course_serach;
        private System.Windows.Forms.TextBox textBox_course;
        private System.Windows.Forms.TextBox textBox_new_password2;
        private System.Windows.Forms.Label label6;
    }
}