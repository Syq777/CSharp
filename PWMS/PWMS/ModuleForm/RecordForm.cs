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
    /// 日常记事窗体
    /// </summary>
    public partial class RecordForm : Form
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
        /// 数据编号
        /// </summary>
        private int ENO = -1;
        /// <summary>
        /// 编辑或添加状态 1为添加 2为编辑 0为查看
        /// </summary>
        private int alterAdd = 0;
        #endregion

        #region RecordForm构造函数
        /// <summary>
        /// RecordForm构造函数
        /// </summary>
        public RecordForm()
        {
            InitializeComponent();
        }
        #endregion

        #region RecordForm加载事件
        /// <summary>
        /// RecordForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void RecordForm_Load(object sender, EventArgs e)
        {
            //设置输入框长度限制          
            re_Theme.MaxLength = 20;//主题
            btnAll_Click(sender, e);//初始化数据和按钮
            //设置按钮是否可用
            myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete,btnQuit, btnSave, true, true,true, false, false);
            try
            {
                //cboType添加数据
                myFunctionClass.SetCmbData(cmbSelectType, "tb_RecordType", "Record");
                cmbSelectType.SelectedIndex = -1;//不选中数据
                myFunctionClass.SetCmbData(no_Record, "tb_RecordType", "Record");
                no_Record.SelectedIndex = -1;//不选中数据
            }
            catch
            {
                MessageBox.Show("窗体初始化出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //设置DataGridView控件
            myFunctionClass.SetDgv(dgvData);
            dgvData.RowHeadersVisible = false;//不显示第一列空白栏
            dgvData.Columns[4].Visible = false;//设置第4列不可见
            myFunctionClass.SetControlReadOnly(grpRecord.Controls);//设置信息只读
            
        }
        #endregion

        #region RecordForm激活事件
        /// <summary>
        /// RecordForm激活事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void RecordForm_Activated(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                dgvData.Rows[0].Selected = true;//选中第一行单元格
            }            
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
            //清空控件内容
            myFunctionClass.ClearControl(grpRecord.Controls);
            //设置状态标志
            alterAdd = 1;
            //设置按钮状态
            myFunctionClass.SetButton(btnAdd, btnAlter,btnDelete, btnQuit, btnSave, false, false,false, true, true);
            myFunctionClass.SetControlWrite(grpRecord.Controls);//恢复信息可编辑
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
            if(ENO==-1)
            {
                MessageBox.Show("未选中数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                alterAdd = 2;//编辑状态
                //设置按钮状态
                myFunctionClass.SetButton(btnAdd, btnAlter,btnDelete, btnQuit, btnSave, false, false,false, true, true);
                myFunctionClass.SetControlWrite(grpRecord.Controls);//恢复信息可编辑
            }            
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
            if (ENO == -1)
            {
                MessageBox.Show("未选中数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("是否删除记录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        //删除数据
                        myDataClass.ExecuteDeleteSql("tb_Record", "ENO=" + ENO);
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        myFunctionClass.ClearControl(grpRecord.Controls);//清空控件内容
                        btnAll_Click(sender, e);//显示全部数据    
                        if(dgvData.Rows.Count==0)//无数据
                        {
                            ENO = -1;
                        }                    
                    }
                    catch
                    {
                        MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                    
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
            if (MessageBox.Show("是否退出编辑", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                alterAdd = 0;//设置状态标志
                btnAll_Click(sender, e);//显示所有数据
                //设置按钮状态
                myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, true, true, true, false, false);
                myFunctionClass.SetControlReadOnly(grpRecord.Controls);//设置信息只读
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
                if (alterAdd == 1)
                {
                    //获得新编号
                    int NO = myFunctionClass.GetAutoNO("tb_Record", "ENO");
                    ////插入字段
                    string field = "ENO,RecordDate,RecordType,Theme,Content";
                    //插入值
                    string value = NO + "," + myFunctionClass.GetInsertValue(field, grpRecord.Controls, "re_");
                    //执行插入语句
                    myDataClass.ExecuteInsertSql("tb_Record", field, value);
                }
                else if (alterAdd == 2)
                {
                    //插入字段
                    string fieldValue =myFunctionClass.GetUpdateFieldValue(grpRecord.Controls, "re_");
                    //执行插入语句
                    myDataClass.ExecuteUpdateSql("tb_Record", fieldValue, "ENO=" + ENO);
                }
                else
                {
                    return;
                }
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            alterAdd = 0;
            btnAll_Click(sender, e);//显示所有数据
            //设置按钮状态
            myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, true, true, true, false, false);
            myFunctionClass.SetControlReadOnly(grpRecord.Controls);//设置信息只读
        }

        #endregion

        #region btnAll点击事件
        /// <summary>
        /// btnAll点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">点击</param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            try
            {
                //填充用户数据
                dataSet = myDataClass.GetDataSet("ENO 编号,RecordDate AS 记事时间,Record AS 记事类别,Theme AS 主题,Content", "tb_Record LEFT JOIN tb_RecordType ON tb_Record.RecordType=tb_RecordType.TNO");
            }
            catch
            {
                MessageBox.Show("查找数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //设置DataGridView数据
            dgvData.DataSource = dataSet.Tables[0];
            chkSelectTime.Checked = false;
            chkSelectType.Checked = false;
        }
        #endregion

        #region btnSelect点击事件
        /// <summary>
        /// btnSelect点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //查找条件
            if (chkSelectTime.Checked == false && chkSelectType.Checked == false || (chkSelectType.Checked == true && chkSelectType.Text == ""))
            {
                MessageBox.Show("查找条件为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //存储查找条件    
            string selectCondition = "";
            if (chkSelectTime.Checked == true)
            {
                selectCondition += "RecordDate='" + myFunctionClass.FormatData(dtpSelectTime.Value.ToString()) + "'";
            }
            if (chkSelectType.Checked == true)
            {
                if (chkSelectTime.Checked == true)
                {
                    selectCondition += " AND ";
                }
                selectCondition += "Record='" + cmbSelectType.Text.Trim() + "'";
            }
            DataSet dataSet = new DataSet();
            try
            {
                //填充用户数据
                dataSet = myDataClass.GetDataSet("ENO 编号,RecordDate AS 记事时间,Record AS 记事类别,Theme AS 主题,Content", "tb_Record LEFT JOIN tb_RecordType ON tb_Record.RecordType=tb_RecordType.TNO", selectCondition);
            }
            catch
            {
                MessageBox.Show("查找数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //设置DataGridView数据
            dgvData.DataSource = dataSet.Tables[0];
            if (dgvData.Rows.Count == 0 && alterAdd == 0)
            {
                //清空控件内容
                myFunctionClass.ClearControl(grpRecord.Controls);
                ENO = -1;
            }
        }
        #endregion

        #region dgvData单元格选中事件
        /// <summary>
        /// dgvData单元格选中事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (alterAdd == 0)//查看模式
            {
                try
                {
                    //记录当前焦点的数据编号
                    ENO = (int)dgvData[0, dgvData.CurrentCell.RowIndex].Value;
                    re_RecordDate.Value = Convert.ToDateTime(dgvData[1, dgvData.CurrentCell.RowIndex].Value.ToString());
                    no_Record.Text = dgvData[2, dgvData.CurrentCell.RowIndex].Value.ToString();
                    re_Theme.Text = dgvData[3, dgvData.CurrentCell.RowIndex].Value.ToString();
                    re_Content.Text = dgvData[4, dgvData.CurrentCell.RowIndex].Value.ToString();

                }
                catch
                {
                    MessageBox.Show("转换数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region re_NORecordType输入字符事件
        /// <summary>
        /// re_NORecordType输入字符事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void re_NORecordType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//设置输入无效
        }
        #endregion
    }
}
