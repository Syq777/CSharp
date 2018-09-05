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
    /// 人事资料查询窗体
    /// </summary>
    public partial class LookupForm : Form
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
        /// 逻辑符号
        /// </summary>
        private string sign= " AND "; 
        #endregion

        #region LookupForm构造函数
        /// <summary>
        /// LookupForm构造函数
        /// </summary>
        public LookupForm()
        {
            InitializeComponent();
        }
        #endregion

        #region LookupForm加载事件
        /// <summary>
        /// LookupForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void LookupForm_Load(object sender, EventArgs e)
        {
            //设置输入框长度限制
            Birthday.MaxLength = 4;//出生日期
            ContractY.MaxLength = 3;//合同年限
            Salary.MaxLength = 7;//月工资
            //清空数据
            myFunctionClass.ClearControl(grpBase.Controls);
            myFunctionClass.ClearControl(grpPersonal.Controls);            
            try
            {
                //填充下拉框数据
                myFunctionClass.SetControlsData(grpBase.Controls, "no_");
                myFunctionClass.SetControlsData(grpPersonal.Controls, "no_");
                myFunctionClass.SetCmbData(da_Major, "tb_Staff", "Major");
                myFunctionClass.SetCmbData(da_School, "tb_Staff", "School");
            }
            catch
            {
                MessageBox.Show("条件填充出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            myFunctionClass.SetMtxData(mtx_Start);//设置MaskedTextBox控件属性
            myFunctionClass.SetMtxData(mtx_End);
            myFunctionClass.SetDgv(dgvData);//设置DataGridView属性
            btnAll_Click(sender, e);//显示数据
        }
        #endregion

        #region btnAll点击事件
        /// <summary>
        /// btnAll点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            try
            {
                //填充用户数据
                dataSet = myFunctionClass.GetStaffData("");
            }
            catch
            {
                MessageBox.Show("显示数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //设置DataGridView数据
            dgvData.DataSource = dataSet.Tables[0];
        }
        #endregion

        #region butSelect点击事件
        /// <summary>
        /// butSelect点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void butSelect_Click(object sender, EventArgs e)
        {
            string condition = "";                
            condition=myFunctionClass.GetSelectCondition(grpBase.Controls, sign,condition);//组合查询条件
            condition = myFunctionClass.GetSelectCondition(grpPersonal.Controls, sign, condition);//组合查询条件
            DataSet dataSet = new DataSet();
            try
            {
                //填充用户数据
                dataSet = myFunctionClass.GetStaffData(condition); ;
            }
            catch
            {
                MessageBox.Show("查找数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //设置DataGridView数据
            dgvData.DataSource = dataSet.Tables[0];            
        }
        #endregion

        #region butClear点击事件
        /// <summary>
        /// butClear点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void butClear_Click(object sender, EventArgs e)
        {
            myFunctionClass.ClearControl(grpBase.Controls);//清空基本信息栏
            myFunctionClass.ClearControl(grpPersonal.Controls);//清空个人信息栏
        }
        #endregion

        #region butQuit点击事件
        /// <summary>
        /// butQuit点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void butQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region rdoAnd控件Checked改变事件
        /// <summary>
        /// rdoAnd控件Checked改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void rdoAnd_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnd.Checked==true)//逻辑符号为AND
            {
                sign = " AND ";
            }
        }
        #endregion

        #region rdoOr控件Checked改变事件
        /// <summary>
        /// rdoOr控件Checked改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void rdoOr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOr.Checked == true)//逻辑符号为OR
            {
                sign = " OR ";
            }
        }
        #endregion

        #region  no_Province选项更改事件
        /// <summary>
        /// no_Province选项更改事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void no_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                myFunctionClass.SetCityData(no_City, no_Province.Text);//填充城市数据
            }
            catch
            {
                MessageBox.Show("条件填充出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        #endregion

        #region mtx_Start失去焦点事件
        /// <summary>
        /// mtx_Start失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void mtx_Start_Leave(object sender, EventArgs e)
        {
            if(myFunctionClass.IsDataTime(mtx_Start)==false)
            {
                MessageBox.Show("日期输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region mtx_End失去焦点事件
        /// <summary>
        /// mtx_End失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void mtx_End_Leave(object sender, EventArgs e)
        {
            if (myFunctionClass.IsDataTime(mtx_End) == true)
            {
                if(myFunctionClass.FormatData(mtx_Start.Text)!=""&&myFunctionClass.FormatData(mtx_End.Text)!="")
                {
                    if(Convert.ToDateTime(mtx_Start.Text)>= Convert.ToDateTime(mtx_End.Text))
                    {
                        MessageBox.Show("当前日期必须大于它前一个日期。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mtx_End.Text = "";
                    }                    
                }                
            }
            else
            {
                MessageBox.Show("日期输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region 字符输入限制浮点数事件
        /// <summary>
        /// 字符输入限制浮点数事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void Float_KeyPress(object sender, KeyPressEventArgs e)
        {
            myFunctionClass.LimitFloatKey(e,((Control)sender).Text);//限制只可输入浮点型字符
        }
        #endregion

        #region 字符输入限制整数数事件
        /// <summary>
        /// 字符输入限制整数数事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void Int_KeyPress(object sender, KeyPressEventArgs e)
        {
            myFunctionClass.LimitIntKey(e);//限制只可输入整形字符
        }
        #endregion
    }
}
