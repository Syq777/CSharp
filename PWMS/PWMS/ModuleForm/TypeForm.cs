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
    /// 基础数据窗体
    /// </summary>
    public partial class TypeForm : Form
    {
        #region 公共变量
        /// <summary>
        /// 数据库字段
        /// </summary>
        public static string  sqlField = "";
        /// <summary>
        /// 数据库类
        /// </summary>
        DataClass.MyData myDataClass = new DataClass.MyData();
        /// <summary>
        /// 模块函数类
        /// </summary>
        FunctionClass.MyFunction myFunctionClass = new FunctionClass.MyFunction();
        /// <summary>
        /// ListBox选中项索引
        /// </summary>
        private int selectedIndex;
        #endregion

        #region TypeForm构造函数
        /// <summary>
        /// TypeForm构造函数
        /// </summary>
        public TypeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region TypeForm加载事件
        /// <summary>
        /// TypeForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void TypeForm_Load(object sender, EventArgs e)
        {
            //设置输入框长度限制
            txtData.MaxLength = 20;//种类
            lstData.Items.Clear();//清空ListBox
            DataTable dataTable=new DataTable();
            try
            {
                //查找类别数据
                dataTable = myDataClass.SelectData(sqlField,"tb_" + sqlField + "Type");
            }
            catch
            {
                MessageBox.Show("打开窗体出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }            
            for (int i = 0;i < dataTable.Rows.Count;i++)//将数据添加进ListBox控件
            {
                lstData.Items.Add(dataTable.Rows[i][0].ToString());
            }
            if (lstData.Items.Count != 0)
            {
                btnAlter.Enabled = true;//可编辑和修改
                btnDelete.Enabled = true;
                lstData.SelectedIndex = 0;//选中第一项
            }
            else
            {
                btnAlter.Enabled = false;//不可编辑和修改
                btnDelete.Enabled = false;
            }
            txtData.Focus();//textBox_data获得焦点
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
            if(txtData.Text!="")
            {
                try
                {
                    bool bl = true;  
                    //是否存在同名数据             
                    bl = myDataClass.IsExistData("*", "tb_" + sqlField.Trim() + "Type", sqlField.Trim() + "='"+txtData.Text.Trim() + "'");               
                    if(bl==false)
                    {
                        //新数据编号
                        int NO=myFunctionClass.GetAutoNO("tb_" + sqlField.Trim() + "Type", "TNO");   
                        //插入数据                                        
                        myDataClass.ExecuteInsertSql("tb_" + sqlField.Trim() + "Type", sqlField.Trim()+",TNO","'"+ txtData.Text.Trim()+"','"+NO+"'");
                        //在ListBox中添加新数据
                        lstData.Items.Add(txtData.Text);
                        //ListBox选中新数据
                        lstData.SelectedIndex = lstData.Items.Count-1;
                        txtData.Text = "";
                        MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("同名数据已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtData.Text = "";
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("添加过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtData.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("添加内容不可为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtData.Focus();//textBox_data获得焦点
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
            if (txtData.Text != "")
            {
                try
                {
                    bool bl = true;
                    //判断是否有同名数据
                    bl = myDataClass.IsExistData("*", "tb_" + sqlField.Trim() + "Type",  sqlField.Trim() + "='" + txtData.Text.Trim() + "'");
                    if (bl == false)
                    {
                        if(MessageBox.Show("是否修改","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            //更新数据
                            myDataClass.ExecuteUpdateSql("tb_" + sqlField.Trim() + "Type", sqlField.Trim() + "='" + txtData.Text.Trim()+"'", sqlField.Trim() + "='" + lstData.Items[selectedIndex].ToString().Trim() + "'");
                            //更新ListBox数据
                            lstData.Items[selectedIndex]= txtData.Text;
                            txtData.Text = "";
                            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("同名数据已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtData.Text = "";
                        return;
                    }
                 }
                catch
                {
                    MessageBox.Show("修改过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtData.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("修改内容不可为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtData.Focus();//textBox_data获得焦点
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
            try
            {
                if (MessageBox.Show("是否删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    //删除数据
                    myDataClass.ExecuteDeleteSql("tb_" + sqlField.Trim() + "Type",sqlField.Trim() + "='" + lstData.Items[selectedIndex].ToString().Trim() + "'");
                    lstData.Items.RemoveAt(selectedIndex);//从ListBox中删除数据
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(lstData.Items.Count>0)
                    {
                        lstData.SelectedIndex = 0;//选中第一项
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("删除过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtData.Focus();//textBox_data获得焦点
        }
        #endregion

        #region btnQuit点击事件
        /// <summary>
        /// button_quit点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region lstData选中项改变事件
        /// <summary>
        /// lstData选中项改变
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstData.Items.Count != 0)//根据是否有项设置是否可以删除和修改
            {
                btnAlter.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnAlter.Enabled = false;
                btnDelete.Enabled = false;
            }
            selectedIndex = lstData.SelectedIndex;//获得新选中项的索引
            txtData.Focus();//textBox_data获得焦点
        }
        #endregion

    }
}
