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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            conn = new SqlConnection("server=.;database=COURSE;Trusted_Connection=Yes;Connect Timeout=90");//Connection对象:连接数据库
            conn.Open();//打开连接
        }
        SqlConnection conn;
        //string loginNo = "201501";
        string loginNo = Program.loginNo;//当前用户编号
        string sql = "";//存储sql语句


        private void Form2_Load(object sender, EventArgs e)//打开窗体事件
        {
            


            //个人信息
            sql = "SELECT SNO,SNAME,SSEX,SBIRTH,SNATION,SMAJOR,SYEAR,SCLASS  FROM STUDENT WHERE SNO=\'" + loginNo + "\';";//查询学号为loginNo个人信息
            SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句;
            com.CommandText = sql;
            SqlDataReader sdr = com.ExecuteReader();// DataReader对象: 读取数据
            sdr.Read();//读取数据
            textBox_no.Text = sdr[0].ToString();//学号
            textBox_name.Text = sdr[1].ToString();//姓名
            if(sdr[2].ToString()=="M")
                    textBox_sex.Text ="男" ;
            else if(sdr[2].ToString() == "F")
                    textBox_sex.Text = "女";//性别
            string date=sdr[3].ToString();
            DateTime dt = Convert.ToDateTime(date);//将日期转化为规定格式
            textBox_birth.Text = dt.ToLongDateString().ToString();//出生日期
            textBox_nation.Text = sdr[4].ToString();//民族
            textBox_major.Text = sdr[5].ToString();//专业
            textBox_year.Text = sdr[6].ToString();//入学年份
            textBox_class.Text = sdr[7].ToString();//班级
            sdr.Close();//关闭DataReader对象

            button_sc_update_Click(null, null);//更新考试信息
            button_update_Click(null,null);//更新选课信息
            button_course_update_Click(null, null);//更新课程信息
        }



        //考试模块
        private void button_sc_update_Click(object sender, EventArgs e)//考试信息更新
        {
            //查询考试信息
            sql = "SELECT SC.CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点,GRADE 分数 ";
            sql += "FROM SC,COURSE,TEACHER ";
            sql += "WHERE SC.CNO=COURSE.CNO AND GRADE is not NULL AND SC.SNO= \'" + loginNo + "\' AND COURSE.TNO=TEACHER.TNO;";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "sc");//填充数据
            dataGridView_sc.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView_sc.ReadOnly = true;//设置dataGridView控件只读
        }
        private void button_sc_serach1_Click(object sender, EventArgs e)//及格成绩
        {
            sql = "SELECT SC.CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点,GRADE 分数 ";
            sql += "FROM SC,COURSE,TEACHER ";
            sql += "WHERE SC.CNO=COURSE.CNO AND GRADE is not NULL AND SC.SNO= \'" + loginNo + "\' AND COURSE.TNO=TEACHER.TNO AND GRADE >= 60;";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "sc");//填充数据
            dataGridView_sc.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView_sc.ReadOnly = true;//设置dataGridView控件只读
        }

        private void button_sc_serach2_Click(object sender, EventArgs e)//不及格成绩
        {
            sql = "SELECT SC.CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点,GRADE 分数 ";
            sql += "FROM SC,COURSE,TEACHER ";
            sql += "WHERE SC.CNO=COURSE.CNO AND GRADE is not NULL AND SC.SNO= \'" + loginNo + "\' AND COURSE.TNO=TEACHER.TNO AND GRADE < 60;";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "sc");//填充数据
            dataGridView_sc.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView_sc.ReadOnly = true;//设置dataGridView控件只读
        }

        //选课模块
        private void button_delete_Click(object sender, EventArgs e)//删除已选课程
        {
            if (dataGridView1.RowCount==0)//已选课程为空
            {
                MessageBox.Show("当前无选课");
            }
            else
            {
                string str = (string)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的CNO
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除", messButton);//删除提示
                if (dr == DialogResult.OK)
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "DELETE FROM SC  WHERE SNO=\'" + loginNo + "\' AND CNO=\'" + str + "\';";//删除数据
                    com.CommandText = sql;
                    if (com.ExecuteNonQuery() >= 1)//执行sql语句
                        MessageBox.Show("删除成功");
                    else
                        MessageBox.Show("删除失败");

                }
                button_update_Click(null, null);//更新选课信息
            }
        }
        private void button_update_Click(object sender, EventArgs e)//选课信息更新
        {
            //查询选课信息
            sql = "SELECT CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
            sql += "FROM COURSE,TEACHER ";
            sql += "WHERE COURSE.TNO=TEACHER.TNO AND CNO  IN(";
            sql += "  SELECT CNO  FROM SC  WHERE SC.SNO= \'" + loginNo + "\' AND GRADE IS NULL); ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "1");//填充数据
            dataGridView1.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView1.ReadOnly = true;//设置dataGridView控件只读
        }
        private void button1_Click(object sender, EventArgs e)//查询选课信息
        {
            string sign = "";
            if (comboBox1.Text == "课程号") sign = "CNO";
            else if (comboBox1.Text == "课程名") sign = "CNAME";
            else if (comboBox1.Text == "授课老师编号") sign = "COURSE.TNO";
            else if (comboBox1.Text == "授课老师") sign = "TNAME";
            else if (comboBox1.Text == "学分") sign = "CCREDIT";
            else if (comboBox1.Text == "课时") sign = "CHOUR";
            else if (comboBox1.Text == "上课时间") sign = "CTIME";
            else if (comboBox1.Text == "上课地点") sign = "CPLACE";//判断用户类型
            if (comboBox1.Text != "" && textBox1.Text != "")
            {
                sql = "SELECT CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
                sql += "FROM COURSE,TEACHER ";
                sql += "WHERE COURSE.TNO=TEACHER.TNO AND CNO  IN(";
                sql += "  SELECT CNO  FROM SC  WHERE SC.SNO= \'" + loginNo + "\' AND GRADE IS NULL) AND ";
                sql += sign + " LIKE '%" + textBox1.Text.Trim() + "%';";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "1");//填充数据
                dataGridView1.DataSource = ds.Tables[0];//dataGridView控件数据源
                dataGridView1.ReadOnly = true;//设置dataGridView控件只读
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }

        //课程模块
        private void button_add_Click(object sender, EventArgs e)//添加课程
        {
            string str = (string)dataGridView_course.Rows[dataGridView_course.CurrentCell.RowIndex].Cells[0].Value;//选中的单元格对应的CNO
            sql = "SELECT *  FROM SC WHERE SNO=\'" + loginNo + "\' AND CNO=\'"+str+"\';";//查询数据
            SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句;
            com.CommandText = sql;
            SqlDataReader sdr = com.ExecuteReader();//DataReader对象:读取数据
            if (sdr.Read())//课程已存在于课程
            {
                sdr.Close();//关闭DataReader对象
                MessageBox.Show("此课程已选,不可重复选");
            }  
                          
            else
            {
                sdr.Close();//关闭DataReader对象
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要加入课程吗?", "添加", messButton);//确定框
                if (dr == DialogResult.OK)
                {
                    sql = "INSERT INTO SC(SNO,CNO) VALUES(\'" + loginNo + "\',\'" + str + "\');";//插入数据
                    com.CommandText = sql;
                    if (com.ExecuteNonQuery() >= 1)//执行sql语句
                        MessageBox.Show("添加成功");
                    else
                        MessageBox.Show("添加失败");
                }
                button_update_Click(null, null);//更新选课信息
            }

        }
        private void button_course_update_Click(object sender, EventArgs e)//课程信息更新
        {
           //查询所有课程信息
            sql = "SELECT CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
            sql += "FROM COURSE,TEACHER ";
            sql += "WHERE COURSE.TNO=TEACHER.TNO;";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
            DataSet ds = new DataSet();//DataSet对象:数据集
            sda.Fill(ds, "course");//填充数据
            dataGridView_course.DataSource = ds.Tables[0];//dataGridView控件数据源
            dataGridView_course.ReadOnly = true;//设置dataGridView控件只读
        }
        private void button_course_search_Click(object sender, EventArgs e)//查询课程
        {
            string sign = "";
            if (comboBox_course.Text == "课程号") sign = "CNO";
            else if (comboBox_course.Text == "课程名") sign = "CNAME";
            else if (comboBox_course.Text == "授课老师编号") sign = "COURSE.TNO";
            else if (comboBox_course.Text == "授课老师") sign = "TNAME";
            else if (comboBox_course.Text == "学分") sign = "CCREDIT";
            else if (comboBox_course.Text == "课时") sign = "CHOUR";
            else if (comboBox_course.Text == "上课时间") sign = "CTIME";
            else if (comboBox_course.Text == "上课地点") sign = "CPLACE";//判断用户类型
            if (comboBox_course.Text != "" && textBox_course.Text != "")
            {
                sql = "SELECT CNO 课程号,CNAME 课程名,COURSE.TNO 授课老师编号,TNAME 授课老师, CHOUR 课时,CCREDIT 学分,CSTART 开始周数,CEND 结束周数,CTIME 上课时间,CNS 开始节数, CNE 结束节数,CPLACE 上课地点 ";
                sql += "FROM COURSE,TEACHER ";
                sql += "WHERE COURSE.TNO=TEACHER.TNO AND " + sign + " LIKE '%" + textBox_course.Text.Trim() + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);//DataAdapter对象:数据适配器
                DataSet ds = new DataSet();//DataSet对象:数据集
                sda.Fill(ds, "course");//填充数据
                dataGridView_course.DataSource = ds.Tables[0];//dataGridView控件数据源
                dataGridView_course.ReadOnly = true;//设置dataGridView控件只读
            }
            else
                MessageBox.Show("查询类型和条件不能为空");//信息不全弹出提示
        }
       
        //密码模块
        private void button_sure_Click(object sender, EventArgs e)//修改密码确定按钮
        {
            if (textBox_new_password.Text.ToString().Length<=8 && textBox_new_password.Text.ToString().Length >= 1)//判断密码位数
            {
                if(textBox_new_password.Text.ToString()== textBox_new_password2.Text.ToString())
                {
                    SqlCommand com = conn.CreateCommand();//SqlCommand对象:执行sql语句
                    sql = "SELECT* FROM STUDENT  WHERE SNO=\'" + loginNo + "\' AND SPASSWORD=\'" + textBox_old_password.Text.Trim() + "\';";//查询密码是否正确
                    com.CommandText = sql;
                    SqlDataReader sdr = com.ExecuteReader();//DataReader对象:读取数据
                    if (sdr.HasRows)//判断查询结果是否有值
                    {
                        sdr.Close();
                        sql = "UPDATE STUDENT SET SPASSWORD=\'" + textBox_new_password.Text + "\' WHERE SNO =\'" + loginNo + "\';";//修改密码
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
                    sdr.Close();//关闭SqlDataReader对象 
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
        private void button_close_Click(object sender, EventArgs e)//取消修改密码
        {
            textBox_old_password.Text = "";
            textBox_new_password.Text = "";
            textBox_new_password2.Text = "";
        }




        //关闭模块
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)//关闭窗体事件
        {
            conn.Dispose();//关闭数据库连接并释放占用资源
            Form1 form = new Form1();
            form.Show();//显示登录窗体
            // System.Environment.Exit(0);//关闭所有窗体
        }

        
    } 
}
