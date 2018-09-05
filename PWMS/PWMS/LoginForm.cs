using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWMS
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        #region 公共函数
        /// <summary>
        /// 数据库类
        /// </summary>
        DataClass.MyData myDataClass = new DataClass.MyData();
        /// <summary>
        /// 模块函数类
        /// </summary>
        FunctionClass.MyFunction myFunctionClass = new FunctionClass.MyFunction();
        #endregion

        #region LoginForm构造函数
        /// <summary>
        /// LoginForm构造函数
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            txtName.Focus();//登录名输入框获得焦点
        }
        #endregion

        #region LoginForm加载事件
        /// <summary>
        /// LoginForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //设置输入框限制输入字符长度
            txtName.MaxLength = 5;//用户名
            txtPassword.MaxLength = 10;//用户密码
            try
            {
                //检查数据库是否可连接
                myDataClass.CloseSqlConnection(myDataClass.OpenSqlConnection());
            }
            catch
            {
                MessageBox.Show("数据库连接失败","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (MessageBox.Show("是否还原默认数据库", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                     try
                     {
                        //还原默认数据库
                        myDataClass.RestoreDataBase(System.Environment.CurrentDirectory + "\\PWMS默认数据库.bak");
                        MessageBox.Show("数据还原成功！请重启系统", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("还原出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Close();//关闭程序
                Application.Exit();
                return;          
            }
            txtName.Text = "root";
            txtPassword.Text = "root";
           btnLogin_Click(sender, e);
        }
        #endregion

        #region btnLogin点击事件
        /// <summary>
        /// btnLogin点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtName.Text!=""&&txtPassword.Text!="")
            {
                bool bl=false;
                try
                {
                    //查找登录名和密码是否正确
                    bl = myFunctionClass.UserLogin(txtName.Text, txtPassword.Text);
                }
                catch
                {
                    MessageBox.Show("密码对比过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    Application.Exit();
                }                
                if(bl==true)
                {
                    FunctionClass.MyFunction.loginID = txtName.Text.Trim();//记录登录ID
                    FunctionClass.MyFunction.loginFlag = (int)this.Tag;//记录登录标志
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Text = "";
                    txtPassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请将登录信息添写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region btnClose点击事件
        /// <summary>
        /// btnClose按钮点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }
        #endregion

        #region txtName输入事件
        /// <summary>
        /// txtName输入事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')//焦点转换为密码框
            {
                txtPassword.Focus();
            }
        }
        #endregion

        #region txtPassword输入事件
        /// <summary>
        /// txtPassword输入事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')//焦点转换为登录按钮
            {
                btnLogin.Focus();
            }
        }
        #endregion
    }
}
