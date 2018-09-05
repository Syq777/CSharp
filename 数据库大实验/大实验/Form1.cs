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
    public partial class  Form1 : Form
    {
        public Form1()
        {
                      
            InitializeComponent();
        }


        private void button_login_Click(object sender, EventArgs e)//登录事件
        {
            string sign = "";
            if (comboBox.Text == "学生") sign = "STUDENT";
            else if (comboBox.Text == "教师") sign = "TEACHER";
            else if (comboBox.Text == "管理员") sign = "ROOT";//判断用户类型
            if (textName.Text != "" && textPass.Text != ""&&comboBox.Text!="")
            {
               // SqlConnection conn = new SqlConnection("server=.;database=COURSE;Trusted_Connection=Yes;Connect Timeout=90");//Connection对象:连接数据库
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Database=COURSE;Trusted_Connection=Yes;Connect Timeout=3");//Connection对象:连接数据库
                conn.Open();//打开数据库连接
                SqlCommand com = conn.CreateCommand();//Command对象:执行sql语句
                com.CommandText = "SELECT* FROM " + sign + " WHERE " + sign[0] + "NO=\'" + textName.Text.Trim() + "\' AND " + sign[0] + "PASSWORD=\'" + textPass.Text.Trim() + "\';";//查询密码
                SqlDataReader read = com.ExecuteReader();//DataReader对象:读取数据
                if (read.HasRows)//判断查询结果是否有值
                {
                    conn.Dispose();//关闭数据库连接并释放占用资源
                    this.Hide();//隐藏当前窗体
                    Program.loginNo = textName.Text.Trim();//记录登录人员编号
                    if (comboBox.Text == "学生")
                    {
                        Form2 form = new Form2();
                        form.Show();//显示学生窗体
                    }
                    else if (comboBox.Text == "教师")
                    {
                        Form3 form = new Form3();
                        form.Show();//显示教师窗体
                    }
                    else if (comboBox.Text == "管理员")
                    {
                        Form4 form = new Form4();
                        form.Show();//显示管理员窗体
                    }                                
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");//密码不对弹出提示
                    textName.Text = "";
                    textPass.Text = "";
                }
                read.Close();
            }
            else
                MessageBox.Show("账号,密码,用户类型不能为空");//信息不全弹出提示

        }

        private void button_close_Click(object sender, EventArgs e)//取消登录事件
        {
            textName.Text = "";
            textPass.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);//关闭所有窗体
        }
    }
}
