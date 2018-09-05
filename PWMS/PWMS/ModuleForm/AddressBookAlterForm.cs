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
    /// 通讯录添加/修改窗体
    /// </summary>
    public partial class AddressBookAlterForm : Form
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
        /// 记录当前数据编号
        /// </summary>
        private int ENO = -1;
        #endregion

        #region AddressBookAlterForm构造函数
        /// <summary>
        /// AddressBookAlterForm构造函数
        /// </summary>
        public AddressBookAlterForm()
        {
            InitializeComponent();
        }
        #endregion

        #region AddressBookAlterForm加载事件
        /// <summary>
        /// AddressBookAlterForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void AddressBookAlterForm_Load(object sender, EventArgs e)
        {
            //输入框限制输入长度
            address_Name.MaxLength = 10;//姓名
            address_Phone.MaxLength =11;//手机号
            address_QQ.MaxLength = 15;//QQ
            address_Mailbox.MaxLength = 20;//邮箱
            try
            {
                //填充下拉列表数据
                myFunctionClass.SetCmbData(address_Sex, "tb_SexType", "Sex");
                if ((int)this.Tag == 1)//添加窗体
                {
                    ENO = myFunctionClass.GetAutoNO("tb_AddressBook", "ENO");//新数据编号
                    //清空控件
                    myFunctionClass.ClearControl(groupBox.Controls);
                }
                else if ((int)this.Tag == 2)//修改窗体
                {
                    ENO = AddressBookForm.ENO;//数据编号
                    //查找相关数据
                    DataTable dataTable = myDataClass.SelectData("Name,Sex,Phone,QQ,Mailbox", "tb_AddressBook", "ENO=" + ENO);
                    if (dataTable.Rows.Count > 0)
                    {
                        //控件显示数据
                        address_Name.Text = dataTable.Rows[0][0].ToString();
                        address_Sex.Text = dataTable.Rows[0][1].ToString();
                        address_Phone.Text = dataTable.Rows[0][2].ToString();
                        address_QQ.Text = dataTable.Rows[0][3].ToString();
                        address_Mailbox.Text = dataTable.Rows[0][4].ToString();
                    }
                    else
                    {
                        MessageBox.Show("数据不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("打开窗体出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(address_Name.Text=="")
            {
                MessageBox.Show("姓名不可为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if ((int)this.Tag == 1)//添加窗体
                {
                    //添加字段
                    string strField = "ENO,Name,Sex,Phone,QQ,Mailbox";
                    //添加语句
                    string strValue = ENO+","+myFunctionClass.GetInsertValue(strField,groupBox.Controls,"address_");
                    //执行更新语句
                    myDataClass.ExecuteInsertSql("tb_AddressBook", strField, strValue);
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if ((int)this.Tag == 2)//修改窗体
                {
                    //更新内容整合
                    string strFieldValue = myFunctionClass.GetUpdateFieldValue(groupBox.Controls, "address_");
                    //执行更新语句
                    myDataClass.ExecuteUpdateSql("tb_AddressBook", strFieldValue, "ENO=" + ENO);
                    MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("保存过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myFunctionClass.ClearControl(groupBox.Controls);//清空控件内容
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
