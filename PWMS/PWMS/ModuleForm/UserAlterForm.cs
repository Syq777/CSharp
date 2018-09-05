using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWMS.ModuleForm
{
    /// <summary>
    /// 用户设置添加/修改界面
    /// </summary>
    public partial class UserAlterForm : Form
    {
        #region 公共变量
        /// <summary>
        /// 数据库类
        /// </summary>
        DataClass.MyData myDataClass = new DataClass.MyData();
        /// <summary>
        /// 模块函数类
        /// </summary>
        FunctionClass.MyFunction myFunctionClass = new FunctionClass.MyFunction();
        #endregion

        #region UserAlterForm构造函数
        /// <summary>
        /// UserAlterForm构造函数
        /// </summary>
        public UserAlterForm()
        {
            InitializeComponent();
        }
        #endregion

        #region  UserAlterForm加载事件
        /// <summary>
        /// UserAlterForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void UserAlterForm_Load(object sender, EventArgs e)
        {
            //设置输入框输入长度限制
            txtName.MaxLength = 5;//用户名称
            txtPassword.MaxLength = 10;//用户密码
            if((int)this.Tag==1)//窗体属性为添加
            {
                txtName.Text = "";
                txtPassword.Text = "";
            }
            else if((int)this.Tag == 2)//窗体属性为修改
            {
                try
                {
                    //查找相应用户名和密码
                    DataTable dataTable = myDataClass.SelectData("UserID,UserPassword", "tb_Login", "UserID='" + UserForm.userID + "'");
                    if (dataTable.Rows.Count > 0)
                    {
                        //显示相关用户名和密码
                        txtName.Text = dataTable.Rows[0][0].ToString();
                        txtPassword.Text = dataTable.Rows[0][1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("用户不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("打开窗体出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }                                
            }
        }
        #endregion

        #region btnSave点击事件
        /// <summary>
        /// btnSave点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text ==""||txtPassword.Text=="")//用户名和密码不可为空
            {
                MessageBox.Show("用户名和密码不可为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if ((int)this.Tag == 1)//窗体属性为添加
                {
                    //是否存在同名数据
                    bool bl = myDataClass.IsExistData("*", "tb_Login", "UserID='" + txtName.Text.Trim() + "'");
                    if (bl == true)
                    {
                        MessageBox.Show("用户名已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtName.Text = "";
                        return;
                    }
                    else
                    {
                        //插入新数据
                        myDataClass.ExecuteInsertSql("tb_Login", "UserID,UserPassword", "'" + txtName.Text.Trim() + "','" + txtPassword.Text.Trim() + "'");
                        MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
                else if ((int)this.Tag == 2)//窗体属性为修改
                {
                    if(UserForm.userID.Trim()==FunctionClass.MyFunction.loginID.Trim())
                    {
                        if (txtName.Text.Trim() != UserForm.userID.Trim())//当前登录用户只可更改密码
                        {
                            MessageBox.Show("此用户为当前登录用户，不可更改登录名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtName.Text = UserForm.userID.Trim();
                            return;
                        }
                    }
                    if (txtName.Text.Trim() != UserForm.userID.Trim())//用户名改动
                    {
                        //是否存在同名数据
                        bool bl = myDataClass.IsExistData("*", "tb_Login", "UserID='" + txtName.Text.Trim() + "'");
                        if (bl == true)
                        {
                            MessageBox.Show("用户名已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtName.Text = "";
                            return;
                        }
                    }
                    //更新数据
                    myDataClass.ExecuteUpdateSql("tb_Login", "UserID='" + txtName.Text.Trim() + "',UserPassword=" + txtPassword.Text.Trim(), "UserID='" + UserForm.userID + "'");
                    MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("保存过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtPassword.Text = "";
            }            
        }
        #endregion

        #region btnQuit点击事件
        /// <summary>
        /// btnQuit点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
