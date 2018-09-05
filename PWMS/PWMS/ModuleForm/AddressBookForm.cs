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
    /// 通讯录窗体
    /// </summary>
    public partial class AddressBookForm : Form
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
        /// 查找种类
        /// </summary>
        private string selectType = "";
        /// <summary>
        /// 数据编号
        /// </summary>
        public static int ENO=-1;
        #endregion

        #region AddressBookForm构造函数
        /// <summary>
        /// AddressBookForm构造函数
        /// </summary>
        public AddressBookForm()
        {
            InitializeComponent();
        }
        #endregion

        #region AddressBookForm加载事件
        /// <summary>
        /// AddressBookForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void AddressBookForm_Load(object sender, EventArgs e)
        {
            //输入框输入长度限制
            txtConditon.MaxLength = 10;//选择条件
            //显示所有数据
            btnAll_Click(sender, e);
            //设置DataGridView控件
            myFunctionClass.SetDgv(dgvData);
            dgvData.RowHeadersVisible = false;//不显示第一列空白栏
            //comboBox_type添加数据
            cmbType.Items.Add("姓名");
            cmbType.Items.Add("性别");
            cmbType.Items.Add("联系电话");
            cmbType.Items.Add("QQ");
            cmbType.Items.Add("邮箱");
            //选中第一项
            cmbType.SelectedIndex = 0;
        }
        #endregion

        #region AddressBookForm激活事件
        /// <summary>
        /// AddressBookForm激活事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void AddressBookForm_Activated(object sender, EventArgs e)
        {
            btnAll_Click(sender, e);//显示所有数据
        }
        #endregion

        #region button_select点击事件
        /// <summary>
        /// button_select点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(selectType == ""||txtConditon.Text=="")
            {
                MessageBox.Show("查询条件不可为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataSet dataSet = new DataSet();
            try
            {
                //查找用户数据
                dataSet = myDataClass.GetDataSet("ENO 编号,Name AS 姓名,Sex AS 性别,Phone AS 手机号,QQ,Mailbox AS 邮箱", "tb_AddressBook",selectType+" LIKE '%"+txtConditon.Text.Trim()+ "%'");
            }
            catch
            {
                MessageBox.Show("查找数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //设置DataGridView数据
            dgvData.DataSource = dataSet.Tables[0];
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
                dataSet = myDataClass.GetDataSet("ENO 编号,Name AS 姓名,Sex AS 性别,Phone AS 手机号,QQ,Mailbox AS 邮箱", "tb_AddressBook");
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

        #region btnAdd点击事件
        /// <summary>
        /// btnAdd点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddressBookAlterForm frmAddressBookAlterForm = new AddressBookAlterForm();
            frmAddressBookAlterForm.Text = "通讯录添加操作";
            frmAddressBookAlterForm.Tag = 1;//设置窗体标记为添加
            frmAddressBookAlterForm.ShowDialog();//打开添加窗体
            frmAddressBookAlterForm.Dispose();
        }
        #endregion

        #region btnAlter点击事件
        /// <summary>
        /// btnAlter点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (ENO==-1)
            {
                MessageBox.Show("当前未选中数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            AddressBookAlterForm frmAddressBookAlterForm = new AddressBookAlterForm();
            frmAddressBookAlterForm.Text = "通讯录修改操作"; 
            frmAddressBookAlterForm.Tag = 2; //设置窗体标记为修改
            frmAddressBookAlterForm.ShowDialog();//打开修改窗体
            frmAddressBookAlterForm.Dispose();

        }
        #endregion

        #region btnDelete点击事件
        /// <summary>
        /// btnDelete点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ENO==-1)
            {
                MessageBox.Show("当前未选中数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("是否删除此数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    //删除数据
                    myDataClass.ExecuteDeleteSql("tb_AddressBook", "ENO=" + ENO);
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("删除过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (dgvData.RowCount == 0)//数据0行时
            {
                ENO = -1;
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

        #region dgvData_data单元格选中事件
        /// <summary>
        /// dgvData_data单元格选中事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {            
            try
            {
                //记录当前焦点的数据编号
                ENO = (int)dgvData[0, dgvData.CurrentCell.RowIndex].Value;
            }
            catch
            {
                MessageBox.Show("记录焦点单元格数据出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
        #endregion

        #region cmbType文本改变事件
        /// <summary>
        /// cmbType文本改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void cmbType_TextChanged(object sender, EventArgs e)
        {
            switch (cmbType.Text.Trim())//选择条件
            {
                case "姓名": selectType = "Name"; break;
                case "性别": selectType = "Sex"; break;
                case "联系电话": selectType = "Phone"; break;
                case "QQ": selectType = "QQ"; break;
                case "邮箱": selectType = "Mailbox"; break;
                default: selectType = ""; break;
            }
        }
        #endregion
    }
}
