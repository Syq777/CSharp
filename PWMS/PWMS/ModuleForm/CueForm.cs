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
    /// 员工提示信息窗体
    /// </summary>
    public partial class CueForm : Form
    {
        #region 公共变量
        /// <summary>
        /// 数据库类
        /// </summary>
        DataClass.MyData myDataClass = new DataClass.MyData();
        #endregion

        #region CueForm构造函数
        /// <summary>
        /// CueForm构造函数
        /// </summary>
        public CueForm()
        {
            InitializeComponent();
        }
        #endregion

        #region CueForm加载事件
        /// <summary>
        /// CueForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void CueForm_Load(object sender, EventArgs e)
        {
            try
            {
                //查找数据
                DataTable dataTable = myDataClass.SelectData("CueDate,CueUnlock","tb_MessageCue", "CueKind = " + this.Tag);
                if ((int)dataTable.Rows[0][1] == 0)//是否设置显示提示框
                {
                    chkCue.Checked = false;
                    grp.Enabled = false;
                }
                else
                {
                    chkCue.Checked = true;
                    grp.Enabled = true;
                }
                nud.Value = (int)dataTable.Rows[0][0];//提示时间
            }
            catch
            {
                MessageBox.Show("打开窗体出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }           
        }
        #endregion

        #region btnSure点击事件
        /// <summary>
        /// btnSure点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            int bl = 0;
            if(chkCue.Checked == true)//显示框选中
            {
                bl = 1;
            }
            try
            {
                //更新数据
                myDataClass.ExecuteUpdateSql("tb_MessageCue", "CueDate=" + nud.Value.ToString() + ",CueUnlock=" + bl.ToString(), "CueKind = " + this.Tag);
                MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("更新过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region chkCue控件Checked改变事件
        /// <summary>
        /// chkCue控件Checked改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void chkCue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCue.Checked == false)//控制groupBox可用性
            {
                grp.Enabled = false;
            }
            else
            {
                grp.Enabled = true;
            }
        }
        #endregion
    }
}
