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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //conn = new SqlConnection("server=.;database=COURSE;Trusted_Connection=Yes;Connect Timeout=90");//Connection对象:连接数据库
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Database=COURSE;Trusted_Connection=Yes;Connect Timeout=3");//Connection对象:连接数据库
            conn.Open();//打开连接
        }

        SqlConnection conn;//
        //string loginNo = "1001";
        string loginNo = Program.loginNo;//当前用户编号
        string sql = "";//存储sql语句

        private void Form3_Load(object sender, EventArgs e)
        {
            //个人信息
            
            sql = "SELECT TNO,TNAME,TSEX,TPOSITION  FROM TEACHER WHERE TNO=\'" + loginNo + "\';";//查询个人信息
            SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句;
            com.CommandText = sql;
            SqlDataReader sdr = com.ExecuteReader();//DataReader对象:读取数据
            sdr.Read();//读取数据
            textBox_no.Text = sdr[0].ToString();//编号
            textBox_name.Text = sdr[1].ToString();//姓名
            if (sdr[2].ToString() == "M")
                textBox_sex.Text = "男";
            else if (sdr[2].ToString() == "F")
                textBox_sex.Text = "女";//性别
            textBox_position.Text= sdr[3].ToString();//职称
            sdr.Close();//关闭DataReader对象

            button_course_update_Click(null, null);//课程刷新
            student();//刷新学生信息
        }


        //课程模块
        private void button_course_update_Click(object sender, EventArgs e)//课程刷新
        {
            //查询授课信息
            sql = "SELECT CNO 课程号,CNAME 课程名, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
            sql += "FROM COURSE ";
            sql += "WHERE TNO = \'" + loginNo + "\';";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "course");//填充数据
            dataGridView_course.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView_course.ReadOnly = true;//设置dataGridView控件只读
        }
        private void button_course_serach_Click(object sender, EventArgs e)//查询课程
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
                sql = "SELECT CNO 课程号,CNAME 课程名, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
                sql += "FROM COURSE ";
                sql += "WHERE TNO = \'" + loginNo + "\' AND ";
                sql += sign + " LIKE '%" + textBox_course.Text.Trim() + "%';";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "course");//填充数据
                dataGridView_course.DataSource = ds.Tables[0];//dataGridView控件数据源
                dataGridView_course.ReadOnly = true;//设置dataGridView控件只读
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }

        /*private void button_course_delete_Click(object sender, EventArgs e)//课程删除
        {
            if (dataGridView_course.RowCount == 0)//课程为空
            {
                MessageBox.Show("当前无选课");
            }
            else
            {
                string str = (string)dataGridView_course.Rows[dataGridView_course.CurrentCell.RowIndex].Cells[0].Value; //选中的单元格对应的CNO
                 MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除", messButton);//删除确定框
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "DELETE FROM COURSE  WHERE TNO=\'" + loginNo + "\' AND CNO=\'" + str + "\';";//删除数据
                    com.CommandText = sql;
                    if (com.ExecuteNonQuery() >= 1)//执行sql语句
                        MessageBox.Show("删除成功");
                    else
                        MessageBox.Show("删除失败");

                }
            }
        }*/

        //学生模块
        private void student()//显示学生信息
        {
            //查询选此老师课的学生信息
            sql = "SELECT CNAME 课程名,SC.CNO 课程号,STUDENT.SNO 学生学号,SNAME 学生姓名,SSEX 学生性别,SMAJOR 学生专业,GRADE 分数 ";
            sql += "FROM COURSE,SC,STUDENT ";
            sql += "WHERE TNO = \'" + loginNo + "\' AND COURSE.CNO=SC.CNO AND  SC.SNO=STUDENT.SNO;";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "student");//填充数据
            dataGridView_student.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView_student.ReadOnly = true;//设置dataGridView控件只读
            if (dataGridView_student.RowCount == 0)//如果无学生,修改成绩按钮失效
                button_student_write.Enabled = false;
        }

        private void button_student_update_Click(object sender, EventArgs e)//刷新学生信息
        {
            int i=0;
            if(dataGridView_student.RowCount != 0)//如果学生信息不为空
            {
                i = dataGridView_student.CurrentCell.RowIndex;
                //string str = dataGridView_student.Rows[i].Cells[3].Value.ToString();//获得分数信息
                //textBox_grade.Text = str;               
            }
            student();
            if(dataGridView_student.RowCount != 0)
            {
                dataGridView_student.Rows[0].Selected = false;//设置不选定首行
                dataGridView_student.Rows[i].Selected = true;//刷新前后选定行不变
                
            }
        }
        private void button_student_search_Click(object sender, EventArgs e)//查询学生
        {
            string sign = "";
            if (comboBox_student.Text == "课程号") sign = "COURSE.CNO";
            else if (comboBox_student.Text == "课程名") sign = "CNAME";
            else if (comboBox_student.Text == "学号") sign = "STUDENT.SNO";
            else if (comboBox_student.Text == "姓名") sign = "SNAME";
            else if (comboBox_student.Text == "性别") sign = "SSEX";
            else if (comboBox_student.Text == "专业") sign = "SMAJOR";//判断用户类型
            if (comboBox_student.Text != "" && textBox_student.Text != "")
            {
                sql = "SELECT CNAME 课程名,SC.CNO 课程号,STUDENT.SNO 学生学号,SNAME 学生姓名,SSEX 学生性别,SMAJOR 学生专业,GRADE 分数 ";
                sql += "FROM COURSE,SC,STUDENT ";
                sql += "WHERE TNO = \'" + loginNo + "\' AND COURSE.CNO=SC.CNO AND SC.SNO=STUDENT.SNO AND ";
                sql += sign + " LIKE '%" + textBox_student.Text.Trim() + "%';";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "student");//填充数据
                dataGridView_student.DataSource = ds.Tables[0];//dataGridView控件数据源
                dataGridView_student.ReadOnly = true;//设置dataGridView控件只读
                if (dataGridView_student.RowCount == 0)//如果无学生,修改成绩按钮失效
                    button_student_write.Enabled = false;
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }
        private void button_student_write_Click(object sender, EventArgs e)//修改成绩
        {
            
            string str1 = dataGridView_student.Rows[dataGridView_student.CurrentCell.RowIndex].Cells[2].Value.ToString();//选定单元行对应的SNO
            string str2 = dataGridView_student.Rows[dataGridView_student.CurrentCell.RowIndex].Cells[1].Value.ToString(); //选定单元行对应的CNO           
            try
            {
                int i = int.Parse(textBox_grade.Text.ToString());//要更改的分数
                if (i >= 0 && i <= 100)//分数约束
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "UPDATE SC SET GRADE=\'" + i + "\' WHERE SNO =\'" + str1 + "\' AND CNO=\'" + str2 + "\';";//sql语句:修改分数
                    com.CommandText = sql;
                    if (com.ExecuteNonQuery() >= 1)//执行sql语句
                        MessageBox.Show("修改成功");
                    else
                        MessageBox.Show("修改失败,请重新修改");
                    textBox_grade.Text = "";

                }
                else
                {
                    MessageBox.Show("请输入正确的成绩");//分数超出范围
                    textBox_grade.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("请输入正确的数字");//修改出现错误
            }
            student();//刷新学生信息
        }
            


        //密码模块
        private void button_sure_Click(object sender, EventArgs e)//修改密码确定按钮
        {
            if (textBox_new_password.Text.ToString().Length <= 8 && textBox_new_password.Text.ToString().Length >= 1)//密码长度判断
            {
                if (textBox_new_password.Text.ToString() == textBox_new_password2.Text.ToString())
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "SELECT* FROM TEACHER  WHERE TNO=\'" + loginNo + "\' AND TPASSWORD=\'" + textBox_old_password.Text.Trim() + "\';";//查询密码
                    com.CommandText = sql;
                    SqlDataReader read = com.ExecuteReader();//DataReader对象:读取数据
                    if (read.HasRows)////判断查询结果是否有值
                    {
                        read.Close();
                        sql = "UPDATE TEACHER SET TPASSWORD=\'" + textBox_new_password.Text + "\' WHERE  TNO =\'" + loginNo + "\';";//sql语句:修改密码
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
                    read.Close();//关闭SqlDataReader对象 
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



        //关闭模块
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();//关闭数据库连接并释放占用资源
            Form1 form = new Form1();
            form.Show();//显示登录窗体
            // System.Environment.Exit(0);//关闭所有窗体
        }

    }
}
