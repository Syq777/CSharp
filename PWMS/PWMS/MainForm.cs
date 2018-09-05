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
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
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

        #region 自定义函数
        #region MainForm初始化函数
        /// <summary>
        /// MainForm初始化函数
        /// </summary>
        public void LoadFunction()
        {
            tspLblUserID.Text = FunctionClass.MyFunction.loginID.Trim();//显示当前登录用户
            treeView.Nodes.Clear();//清空树
            myFunctionClass.CreateTv(treeView, menuStrip);//创建TreeView
            myFunctionClass.SetMsDisable(menuStrip);//清空权限
            myFunctionClass.SetMsEnable(menuStrip);//赋予用户权限
        }
        #endregion
        #endregion

        #region MainForm构造函数
        /// <summary>
        /// MainForm构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //this.Show();
            //myFunctionClass.ShowForm("人事档案管理");
        }
        #endregion

        #region MainForm加载函数
        /// <summary>
        /// MainForm加载函数
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm frmLoginForm = new LoginForm();//登录窗体
            frmLoginForm.Tag = 1;//设置登录标志
            frmLoginForm.ShowDialog();//显示窗体
            frmLoginForm.Dispose();//释放资源
            if(FunctionClass.MyFunction.loginID=="")//用户取消登录
            {
                this.Close();
                Application.Exit();//关闭程序
                return;
            }
            LoadFunction();//初始化窗体
            try
            {
                myFunctionClass.MessageCue(1);//查找相应生日提示信息
                myFunctionClass.MessageCue(2);//查找相应合同提示信息
            }
            catch
            {
                MessageBox.Show("查找提示信息出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region MainForm激活函数
        /// <summary>
        /// MainForm激活函数
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if(FunctionClass.MyFunction.loginFlag==2)//重新登录
            {
                LoadFunction();//初始化数据
                FunctionClass.MyFunction.loginFlag = 1;//重置用户登录标志
            }
        }
        #endregion

        #region  TreeNode点击事件
        /// <summary>
        /// TreeNode点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Text=="系统退出")
            {
                tsbtnQuit_Click(sender, e);//退出功能
            }
            myFunctionClass.ClickTv(menuStrip, e);//点击事件
        }
        #endregion

        #region ToolStripMenuItem事件
        /// <summary>
        /// ToolStripMenuItem事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsmi_Click(object sender, EventArgs e)
        {
           ToolStripMenuItem tsmi=(ToolStripMenuItem)sender;
           if(tsmi.Text=="系统退出")
            {
                tsbtnQuit_Click(sender, e);//退出功能
            }
           else
            {
                myFunctionClass.ShowForm(tsmi.Text);//打开相应界面
            }           
        }
        #endregion

        #region ToolStripButton点击事件
        /// <summary>
        /// ToolStripButton点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtn_Click(object sender,EventArgs e)
        {
            ToolStripButton tsbtn=(ToolStripButton)sender;
            if(tsbtn.Name== "tsbtnManager"&& tsmiManager.Enabled == true)//当前有权限打开相应界面
            {
                myFunctionClass.ShowForm(tsbtn.Text);
            }
            else if(tsbtn.Name == "tsbtnLookup"&& tsmiLookup.Enabled == true)//当前有权限打开相应界面
            {
                myFunctionClass.ShowForm(tsbtn.Text);
            }
            else if (tsbtn.Name == "tsbtnStatistics"&& tsmiStatistics.Enabled == true)//当前有权限打开相应界面
            { 
                myFunctionClass.ShowForm(tsbtn.Text);
            }
            else if (tsbtn.Name == "tsbtnAddressBook"&& tsmiAddressBook.Enabled == true)//当前有权限打开相应界面
            {
                myFunctionClass.ShowForm(tsbtn.Text);
            }
            else if (tsbtn.Name == "tsbtnRecord"&& tsmiRecord.Enabled == true)//当前有权限打开相应界面
            {
                myFunctionClass.ShowForm(tsbtn.Text);
            }
            else//无权限
            {
                MessageBox.Show("当前用户无权限调用" + "\"" + tsbtn.Text + "\"" + "窗体", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region 系统退出事件
        /// <summary>
        /// 系统退出事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tsbtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
            Application.Exit();//结束程序
        }
        #endregion

    }
}
