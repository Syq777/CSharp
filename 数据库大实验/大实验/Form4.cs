using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 大实验
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            conn = new SqlConnection("server=.;database=COURSE;Trusted_Connection=Yes;Connect Timeout=90");//Connection对象:连接数据库

            conn.Open();//打开连接
        }

        SqlConnection conn;
        //string loginNo = "root";
        string loginNo = Program.loginNo;//当前用户编号
        string sql = "";//存储sql语句

        private void Form4_Load(object sender, EventArgs e)
        {
            button_student_update_Click(null, null);//学生信息刷新
            button_teacher__update_Click(null, null);//教师信息刷新
            button_course_update_Click(null, null);//课程信息刷新
            button_sc_Click(null, null);//考试信息刷新
        }


        //学生模块
        private void button_student_update_Click(object sender, EventArgs e)//学生信息刷新
        {
            //查询所有学生信息
            sql = "SELECT  SNO 学号,SNAME 姓名,SSEX 性别,SBIRTH 出生年月,SNATION 民族,SMAJOR 专业,SYEAR 入学年份,SCLASS 班级 ";
            sql += "FROM STUDENT";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "student");//填充数据
            dataGridView_student.DataSource = ds.Tables[0];//dataGridView控件数据源
        }
        private void button_student_sure_Click(object sender, EventArgs e)//保存修改
        {
            //查询所有学生信息
            sql = "SELECT  SNO 学号,SNAME 姓名,SSEX 性别,SBIRTH 出生年月,SNATION 民族,SMAJOR 专业,SYEAR 入学年份,SCLASS 班级 ";
            sql += "FROM STUDENT";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataTable dt1 = new DataTable();//更新表
            sda.Fill(dt1);//填充数据
            dt1.Rows.Clear();//清除数据
            
            DataTable dt2 = new DataTable();
            dt2 = (DataTable)dataGridView_student.DataSource;//dataGridView控件中修改过后的表
            for (int i=0;i<dt2.Rows.Count;i++)
            {
                dt1.ImportRow(dt2.Rows[i]);//复制表
            }

           try
           {
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);// CommandBuilder对象
                sda.Update(dt1);//更新数据
                dt1.AcceptChanges();//提交更改
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败");//错误提示
            }
            button_student_update_Click(null, null);//学生信息刷新

        }
        private void button_stdent_delete_Click(object sender, EventArgs e)//学生信息删除
        {
            if (dataGridView_student.RowCount == 0)//学生为空
            {
                MessageBox.Show("当前无学生");
            }
            else
            {
                string str = (string)dataGridView_student.Rows[dataGridView_student.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的SNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除", messButton);//删除提示
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "DELETE FROM   STUDENT  WHERE SNO=\'" + str + "\';";//删除数据
                    com.CommandText = sql;
                    try
                    {
                        com.ExecuteNonQuery();//执行删除语句
                        MessageBox.Show("删除成功");
                    }
                    catch
                    {
                        MessageBox.Show("删除失败");
                    }                 
                }
                button_student_update_Click(null, null);//学生信息刷新
            }
        }
        

        private void button_student_search_Click(object sender, EventArgs e)//学生查询
        {
            string sign = "";           
            if (comboBox_student.Text == "学号") sign = "STUDENT.SNO";
            else if (comboBox_student.Text == "姓名") sign = "SNAME";
            else if (comboBox_student.Text == "性别") sign = "SSEX";
            else if (comboBox_student.Text == "专业") sign = "SMAJOR";//判断用户类型
            if (comboBox_student.Text != "" && textBox_student.Text != "")
            {
                sql = "SELECT  SNO 学号,SNAME 姓名,SSEX 性别,SBIRTH 出生年月,SNATION 民族,SMAJOR 专业,SYEAR 入学年份,SCLASS 班级 ";
                sql += "FROM STUDENT ";
                sql += "WHERE "+sign + " LIKE '%" + textBox_student.Text.Trim() + "%';";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "student");//填充数据
                dataGridView_student.DataSource = ds.Tables[0];//dataGridView控件数据源               
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }
        private void button_student_recovery_Click(object sender, EventArgs e)//学生密码初始化
        {
            if (dataGridView_student.RowCount == 0)//学生为空
            {
                MessageBox.Show("当前无学生");
            }
            else
            {
                string str = (string)dataGridView_student.Rows[dataGridView_student.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的SNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要密码初始化吗?", "初始化密码", messButton);//删除提示
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "UPDATE STUDENT SET SPASSWORD=SNO  WHERE SNO=\'" + str + "\';";//删除数据
                    com.CommandText = sql;
                    try
                    {
                        com.ExecuteNonQuery();//执行语句
                        MessageBox.Show("初始化成功");
                    }
                    catch
                    {
                        MessageBox.Show("初始化失败");
                    }
                }
            }


        }

       


        //教师模块
        private void button_teacher__update_Click(object sender, EventArgs e)//教师信息刷新
        {
            //查询所有教师信息
            sql = "SELECT TNO 教师编号,TNAME 姓名,TSEX 性别,TPOSITION 职称 ";
            sql += "FROM TEACHER";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn); //DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "teacher");//填充数据
            dataGridView_teacher.DataSource = ds.Tables[0];//dataGridView控件数据源
        }
        private void button_teacher_sure_Click(object sender, EventArgs e)//保存修改
        {
            //查询所有教师信息
            sql = "SELECT TNO 教师编号,TNAME 姓名,TSEX 性别,TPOSITION 职称 ";
            sql += "FROM TEACHER";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataTable dt1 = new DataTable();//更新表
            sda.Fill(dt1);//填充数据
            dt1.Rows.Clear();//清除数据

            DataTable dt2 = new DataTable();
            dt2 = (DataTable)dataGridView_teacher.DataSource;//dataGridView控件中修改过后的表
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dt1.ImportRow(dt2.Rows[i]);//复制表
            }

            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);// CommandBuilder对象
                sda.Update(dt1);//更新数据
                dt1.AcceptChanges();//提交更改
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败");//错误提示
            }
            button_teacher__update_Click(null, null);//教师信息刷新
        }
        private void button_teacher_delete_Click(object sender, EventArgs e)//教师信息删除
        {
            if (dataGridView_teacher.RowCount == 0)//教师为空
            {
                MessageBox.Show("当前无教师");
            }
            else
            {
                string str = (string)dataGridView_teacher.Rows[dataGridView_teacher.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的TNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除", messButton);//删除提示
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "DELETE FROM   TEACHER  WHERE TNO=\'" + str + "\';";//删除数据
                    com.CommandText = sql;
                    try
                    {
                        com.ExecuteNonQuery();//执行删除语句
                        MessageBox.Show("删除成功");
                    }
                    catch
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                button_teacher__update_Click(null, null);//教师信息刷新
            }
        }
        private void button_teacher_search_Click(object sender, EventArgs e)//教师查询
        {
            string sign = "";
            if (comboBox_teacher.Text == "教师编号") sign = "TNO";
            else if (comboBox_teacher.Text == "姓名") sign = "TNAME";
            else if (comboBox_teacher.Text == "性别") sign = "TSEX";
            else if (comboBox_teacher.Text == "职称") sign = "TPOSITION";//判断用户类型
            if (comboBox_teacher.Text != "" && textBox_teacher.Text != "")
            {
                sql = "SELECT TNO 教师编号,TNAME 姓名,TSEX 性别,TPOSITION 职称 ";
                sql += "FROM TEACHER ";
                sql += "WHERE " + sign + " LIKE '%" + textBox_teacher.Text.Trim() + "%';";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn); //DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "teacher");//填充数据
                dataGridView_teacher.DataSource = ds.Tables[0];//dataGridView控件数据源
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }
        private void button_teacher_recovery_Click(object sender, EventArgs e)//教师密码初始化
        {
            if (dataGridView_teacher.RowCount == 0)//教师为空
            {
                MessageBox.Show("当前无教师");
            }
            else
            {
                string str = (string)dataGridView_teacher.Rows[dataGridView_teacher.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的TNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要初始化密码吗?", "初始化密码", messButton);
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "UPDATE TEACHER SET TPASSWORD=TNO  WHERE TNO=\'" + str + "\';";//
                    com.CommandText = sql;
                    try
                    {
                        com.ExecuteNonQuery();//执行语句
                        MessageBox.Show("初始化成功");
                    }
                    catch
                    {
                        MessageBox.Show("初始化失败");
                    }
                }
            }
        }


        //课程模块
        private void button_course_update_Click(object sender, EventArgs e)//课程信息刷新
        {
            //查询所有课程信息
            sql = "SELECT CNO 课程号,CNAME 课程名,TNO 授课老师编号, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
            sql += "FROM COURSE";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "course");//填充数据
            dataGridView_course.DataSource = ds.Tables[0];//dataGridView控件数据源
        }
        private void button_course_sure_Click(object sender, EventArgs e)//保存修改
        {
            //查询所有课程信息
            sql = "SELECT CNO 课程号,CNAME 课程名,TNO 授课老师编号, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
            sql += "FROM COURSE";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataTable dt1 = new DataTable();//更新表
            sda.Fill(dt1);//填充数据
            dt1.Rows.Clear();//清除数据

            DataTable dt2 = new DataTable();
            dt2 = (DataTable)dataGridView_course.DataSource;//dataGridView控件中修改过后的表
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dt1.ImportRow(dt2.Rows[i]);//复制表
            }

            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);// CommandBuilder对象
                sda.Update(dt1);//更新数据
                dt1.AcceptChanges();//提交更改
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败");//错误提示
            }
            button_course_update_Click(null, null);//课程信息刷新
        }
        private void button_course_delete_Click(object sender, EventArgs e)//课程信息删除
        {
            if (dataGridView_course.RowCount == 0)//课程为空
            {
                MessageBox.Show("当前无课程");
            }
            else
            {
                string str = (string)dataGridView_course.Rows[dataGridView_course.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的CNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除", messButton);//删除提示
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "DELETE FROM   COURSE WHERE CNO=\'" + str + "\';";//删除数据
                    com.CommandText = sql;
                    try
                    {
                        com.ExecuteNonQuery();//执行删除语句
                        MessageBox.Show("删除成功");
                    }
                    catch
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                button_course_update_Click(null, null);//课程信息刷新
            }
        }
        private void button_course_search_Click(object sender, EventArgs e)//课程查询
        {
            string sign = "";
            if (comboBox_course.Text == "课程号") sign = "CNO";
            else if (comboBox_course.Text == "课程名") sign = "CNAME";
            else if (comboBox_course.Text == "学分") sign = "CCREDIT";
            else if (comboBox_course.Text == "课时") sign = "CHOUR";
            else if (comboBox_course.Text == "上课时间") sign = "CTIME";
            else if (comboBox_course.Text == "上课地点") sign = "CPLACE";//判断用户类型
            if (comboBox_course.Text != "" && textBox_course.Text != "")
            {
                sql = "SELECT CNO 课程号,CNAME 课程名,TNO 授课老师编号, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
                sql += "FROM COURSE ";
                sql += "WHERE " + sign + " LIKE '%" + textBox_course.Text.Trim() + "%';";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "course");//填充数据
                dataGridView_course.DataSource = ds.Tables[0];//dataGridView控件数据源
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }

        




        //考试模块
        private void button_sc_Click(object sender, EventArgs e)//考试信息刷新
        {
            //查询所有考试及选课信息
            sql = "SELECT SNO 学号, CNO 课程号,GRADE 分数 ";
            sql += "FROM SC";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "sc");//填充数据
            dataGridView_sc.DataSource = ds.Tables[0];//dataGridView控件数据源
        }
        private void button_sc_sure_Click(object sender, EventArgs e)//保存修改
        {
            //查询所有考试及选课信息
            sql = "SELECT SNO 学号, CNO 课程号,GRADE 分数 ";
            sql += "FROM SC";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataTable dt1 = new DataTable();//更新表
            sda.Fill(dt1);//填充数据
            dt1.Rows.Clear();//清除数据

            DataTable dt2 = new DataTable();
            dt2 = (DataTable)dataGridView_sc.DataSource;//dataGridView控件中修改过后的表
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dt1.ImportRow(dt2.Rows[i]);//复制表
            }

            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);// CommandBuilder对象
                sda.Update(dt1);//更新数据
                dt1.AcceptChanges();//提交更改
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败");//错误提示
            }
            button_sc_Click(null, null);//考试信息刷新
        }
        private void button_sc_delete_Click(object sender, EventArgs e)//考试信息删除
        {
            if (dataGridView_sc.RowCount == 0)//考试为空
            {
                MessageBox.Show("当前无考试信息");
            }
            else
            {
                string str1 = (string)dataGridView_sc.Rows[dataGridView_sc.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的SNO
                string str2 = (string)dataGridView_sc.Rows[dataGridView_sc.CurrentCell.RowIndex].Cells[1].Value;//选中的单元格对应的CNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除", messButton);//删除提示
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "DELETE FROM   SC  WHERE SNO=\'" + str1 + "\' AND CNO=\'"+str2+"\';";//删除数据
                    com.CommandText = sql;
                    try
                    {
                        com.ExecuteNonQuery();//执行删除语句
                        MessageBox.Show("删除成功");
                    }
                    catch
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                button_sc_Click(null, null);//考试信息刷新
            }
        }
        private void button_sc_search_Click(object sender, EventArgs e)//考试查询
        {
            if (textBox_sc1.Text != "" && textBox_sc2.Text != "")
            {
                sql = "SELECT SNO 学号, CNO 课程号,GRADE 分数 ";
                sql += "FROM SC ";
                sql += "WHERE SNO=" + textBox_sc1.Text + " AND CNO=" + textBox_sc2.Text + ";";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "sc");//填充数据
                dataGridView_sc.DataSource = ds.Tables[0];//dataGridView控件数据源
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }



        //修改密码模块
        private void button_sure_Click(object sender, EventArgs e)//修改密码确定按钮
        {
            if (textBox_new_password.Text.ToString().Length <= 8&& textBox_new_password.Text.ToString().Length>=1)
            {
                if (textBox_new_password.Text.ToString() == textBox_new_password2.Text.ToString())
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "SELECT* FROM ROOT  WHERE RNO=\'" + loginNo + "\' AND RPASSWORD=\'" + textBox_old_password.Text.Trim() + "\';";//查询密码
                    com.CommandText = sql;
                    SqlDataReader read = com.ExecuteReader();//执行sql语句
                    if (read.HasRows)//判断查询结果是否有值
                    {
                        read.Close();
                        sql = "UPDATE ROOT SET RPASSWORD=\'" + textBox_new_password.Text + "\' WHERE RNO =\'" + loginNo + "\';";//sql语句:修改密码
                        com.CommandText = sql;
                        if (com.ExecuteNonQuery() >= 1)//执行sql语句
                            MessageBox.Show("修改成功");
                        else
                            MessageBox.Show("修改失败,请重新修改");
                        textBox_old_password.Text = "";
                        textBox_new_password.Text = "";
                        textBox_new_password2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("原密码错误");//密码错误提示
                        textBox_old_password.Text = "";
                        textBox_new_password.Text = "";
                        textBox_new_password2.Text = "";
                    }
                    read.Close();
                }
                else
                {
                    MessageBox.Show("新密码不一致");//密码不一致错误提示
                    textBox_new_password2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请输入1-8位密码");//密码长度错误提示
                textBox_new_password.Text = "";
                textBox_new_password2.Text = "";
            }

        }
        private void button_close_Click(object sender, EventArgs e)//修改密码取消按钮
        {
            textBox_old_password.Text = "";
            textBox_new_password.Text = "";
            textBox_new_password2.Text = "";
        }

  

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();//关闭数据库连接并释放占用资源
            Form1 form = new Form1();
            form.Show();//显示登录窗体
            // System.Environment.Exit(0);//关闭所有窗体
        }
    }
}
