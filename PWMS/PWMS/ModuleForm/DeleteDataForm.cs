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
    /// 清空数据库窗体
    /// </summary>
    public partial class DeleteDataForm : Form
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

        #region DeleteDataForm构造函数
        /// <summary>
        /// DeleteDataForm构造函数
        /// </summary>
        public DeleteDataForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义函数
        #region 判断是否选中类别表
        /// <summary>
        /// 判断是否选中类别表
        /// </summary>
        /// <returns>是否选中类别表</returns>
        private bool IsTypeTableChecked()
        {
            bool bl = false;
            foreach (Control c in grpTable.Controls)//遍历控件
            {
                if(c.Name=="chk_RecordType"|| c.Name== "chk_RPType")//是记事类别表或奖惩类别表
                {
                    continue;
                }
                if (c is CheckBox && c.Name.IndexOf("chk_") ==0 && c.Name.IndexOf("Type") > -1)//是否为类别表
                {
                    if (((CheckBox)c).Checked == true)//是否选中
                    {
                        bl = true;
                        break;
                    }
                }
            }
            return bl;
        }
        #endregion
        #endregion

        #region btnDelete点击事件
        /// <summary>
        /// btnDelete点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">点击</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定清空所选数据表", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
            {
                try
                {
                    if (myDataClass.IsExistData("tb_Record") == true && chk_RecordType.Checked == true )
                    {
                        MessageBox.Show("删除记事类别表前请先清空日常记事表", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chk_RecordType.Checked = false;
                        return;
                    }
                    if (myDataClass.IsExistData("tb_RP") == true && chk_RPType.Checked == true )
                    {
                        MessageBox.Show("删除奖惩类别表前请先清空奖惩表", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chk_RPType.Checked = false;
                        return;
                    }
                    if (myDataClass.IsExistData("tb_Staff") == true && IsTypeTableChecked() == true)
                    {
                        MessageBox.Show("删除相关类别表前请先清空职工信息表", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chk_NationType.Checked = false;//类别选项不选中
                        chk_EducationType.Checked = false;
                        chk_PoliticalStatusType.Checked = false;
                        chk_StaffType.Checked = false;
                        chk_PositionType.Checked = false;
                        chk_SalaryType.Checked = false;
                        chk_DepartmentType.Checked = false;
                        chk_TitleType.Checked = false;
                        return;
                    }
                    
                }
                catch
                {
                    MessageBox.Show("查找对比数据出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    //清空数据表
                    myFunctionClass.ClearDataBase(grpTable.Controls);
                    MessageBox.Show("清空成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("删除过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
            foreach (Control c in grpTable.Controls)//遍历权限控件
            {
                if (c.Name.IndexOf("chk_")== 0)
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
            if (((CheckBox)sender).Checked == false)
            {
                chkAll.Checked = false;//更改chkAll
            }
        }
        #endregion

        
    }
}
