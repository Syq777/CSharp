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
    /// 用户设置权限界面
    /// </summary>
    public partial class UserPowerForm : Form
    {
        #region 公共变量
        /// <summary>
        /// 模块函数类
        /// </summary>
        FunctionClass.MyFunction myFunctionClass = new FunctionClass.MyFunction();
        #endregion

        #region UserPowerForm构造函数
        /// <summary>
        /// UserPowerForm构造函数
        /// </summary>
        public UserPowerForm()
        {
            InitializeComponent();
        }
        #endregion

        #region UserPowerForm加载事件
        /// <summary>
        /// UserPowerForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void UserPowerForm_Load(object sender, EventArgs e)
        {
            try
            {
                //显示用户权限
                myFunctionClass.ShowPower(grpPower.Controls, UserForm.userID);
            }
            catch
            {
                MessageBox.Show("显示窗体失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
            try
            {
                //设置用户权限
                myFunctionClass.SetPower(grpPower.Controls, UserForm.userID);
                if(UserForm.userID.Trim()==FunctionClass.MyFunction.loginID.Trim())
                {
                    MessageBox.Show("保存成功，下次登录生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("设置权限失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region chkAll点击事件
        /// <summary>
        /// chkAll点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void chkAll_Click(object sender, EventArgs e)
        {
            bool bl = chkAll.Checked;
            foreach (Control c in grpPower.Controls)//遍历权限控件
            {
                if (c.Name.IndexOf("chk_")==0)
                {
                    ((CheckBox)c).Checked = bl;//全选或全不选中权限
                }
            }
        }
        #endregion

        #region CheckBox控件Checked改变事件
        /// <summary>
        /// CheckBox控件Checked改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked==false)
            {
                chkAll.Checked = false;//更改chkAll
            }
        }
        #endregion

        
    }
}
