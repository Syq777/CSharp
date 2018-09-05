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
    /// 备份/还原数据库窗体
    /// </summary>
    public partial class BackupRestoreDataForm : Form
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

        #region BackupRestoreDataForm构造函数
        /// <summary>
        /// BackupRestoreDataForm构造函数
        /// </summary>
        public BackupRestoreDataForm()
        {
            InitializeComponent();
        }
        #endregion

        #region btnBackupPath点击事件
        /// <summary>
        /// btnBackupPath点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog()==DialogResult.OK)
            {
                //获取选择的路径
                txtOther.Text = folderBrowserDialog.SelectedPath;
                //选中其他路径选项
                rdoOther.Checked = true;
            }
        }
        #endregion

        #region btnBackup点击事件
        /// <summary>
        /// btnBackup点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            string strPath = "";//保存路径
            if(rdoDefault.Checked==true)
            {
                strPath = System.Environment.CurrentDirectory + "\\bar\\";//默认路径
            }
            else if(rdoOther.Checked==true)
            {
                if(txtOther.Text=="")
                {
                    MessageBox.Show("请选择自定义路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                strPath = txtOther.Text + "\\";//自定义路径
            }
            try
            {
                //备份数据库
                myDataClass.BackupDataBase(strPath +"数据库PWMS日期"+ myFunctionClass.FormatData(System.DateTime.Now.ToString()) +"时间"+myFunctionClass.FormatTime2(System.DateTime.Now.ToString()) + ".bak");
                MessageBox.Show("数据备份成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("备份出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnRestorePath点击事件
        /// <summary>
        /// btnRestorePath点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnRestorePath_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "*.bak|*.bak";//设置文件筛选
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                //获取文件名称
                txtDataPath.Text = openFileDialog.FileName;
            }
        }
        #endregion

        #region btnRestore点击事件
        /// <summary>
        /// btnRestore点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if(txtDataPath.Text=="")
            {
                MessageBox.Show("请选择路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("是否还原数据，为了避免数据丢失，数据库还原后将关闭整个系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                //try
                //{
                    //还原数据库
                    myDataClass.RestoreDataBase(txtDataPath.Text.Trim());
                    MessageBox.Show("数据还原成功！即将关闭系统", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Application.Exit();
                //}
                //catch
                //{
                //    MessageBox.Show("还原出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
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

        #region TextBox输入字符事件
        /// <summary>
        /// TextBox输入字符事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//设置输入无效
        }
        #endregion
    }
}
