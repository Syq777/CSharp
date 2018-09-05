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
    /// 用户设置界面
    /// </summary>
    public partial class UserForm : Form
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
        /// <summary>
        /// 当前选择用户
        /// </summary>
        public static string userID = "";
        #endregion

        #region  UserForm构造函数
        /// <summary>
        /// UserForm构造函数
        /// </summary>
        public UserForm()
        {
            InitializeComponent();
        }
        #endregion

        #region  UserForm加载事件
        /// <summary>
        /// UserForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void UserForm_Load(object sender, EventArgs e)
        {
            myFunctionClass.SetDgv(dgvUser);//设置DataGridView控件
        }
        #endregion

        #region  UserForm激活事件
        /// <summary>
        /// UserForm激活事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void UserForm_Activated(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = myDataClass.GetDataSet("UserID AS 用户名称", "tb_Login");//填充用户数据
            }
            catch
            {
                MessageBox.Show("查找数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            dgvUser.DataSource = dataSet.Tables[0];//绑定数据
        }
        #endregion

        #region tsbtnAdd点击事件
        /// <summary>
        /// tsbtnAdd点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            UserAlterForm frmUserAlterForm = new UserAlterForm();//打开添加窗体
            frmUserAlterForm.Tag = 1;//窗体标记为添加
            frmUserAlterForm.Text = "添加用户";
            frmUserAlterForm.ShowDialog();
            frmUserAlterForm.Dispose();
        }
        #endregion

        #region tsbtnAlter点击事件
        /// <summary>
        /// tsbtnAlter点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtnAlter_Click(object sender, EventArgs e)
        {
            if(userID=="")
            {
                MessageBox.Show("当前未选中用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(userID=="root")//root用户不可更改
            {
                MessageBox.Show("不可更改root用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            UserAlterForm frmUserAlterForm = new UserAlterForm();//打开修改窗体
            frmUserAlterForm.Tag = 2;//窗体标记是修改
            frmUserAlterForm.Text = "修改用户";
            frmUserAlterForm.ShowDialog();
            frmUserAlterForm.Dispose();
        }
        #endregion

        #region tsbtnDelete点击事件
        /// <summary>
        /// tsbtnDelete点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (userID == "")
            {
                MessageBox.Show("当前未选中用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (userID == "root")//root用户不可删除
            {
                MessageBox.Show("不可删除root用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(userID==FunctionClass.MyFunction.loginID)//当前登录用户
            {
                MessageBox.Show("不可删除当前登录用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }          
            if (MessageBox.Show("是否删除此用户", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    //删除用户权限
                    myDataClass.ExecuteDeleteSql("tb_UserPower", "UserID='" + userID+"'");
                    //删除用户记录
                    myDataClass.ExecuteDeleteSql("tb_Login", "UserID='" + userID+"'");
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("删除过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }               
            }

        }
        #endregion

        #region tsbtnPower点击事件
        /// <summary>
        /// tsbtnPower点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtnPower_Click(object sender, EventArgs e)
        {
            if (userID == "")
            {
                MessageBox.Show("当前未选中用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (userID == "root")//root不可更改
            {
                MessageBox.Show("不可更改root用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            UserPowerForm frmUserPowerForm = new UserPowerForm();//显示权限窗体
            frmUserPowerForm.Text = "用户："+ userID + "权限设置";
            frmUserPowerForm.ShowDialog();
            frmUserPowerForm.Dispose();
        }
        #endregion

        #region tsbtnQuit点击事件
        /// <summary>
        /// tsbtnQuit点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region dgvUser单元格选中事件
        /// <summary>
        /// dgvUser单元格选中事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvUser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //记录当前所选单元格
            userID = dgvUser[0, dgvUser.CurrentCell.RowIndex].Value.ToString();
        }
        #endregion
    }
}
