using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWMS.ModuleForm
{
    /// <summary>
    /// 人事档案管理界面
    /// </summary>
    public partial class ManagerForm : Form
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
        private int SNO = -1;
        /// <summary>
        /// 编辑或添加状态 1为添加 2为编辑 0为查看
        /// </summary>
        private int alterAdd = 0;
        /// <summary>
        /// 查询类型
        /// </summary>
        private string selectType = "";
        /// <summary>
        /// 存储图片数组
        /// </summary>
        private byte[] photoByte;
        #endregion

        #region 自定义函数
        #region 显示TabControl所有页面
        /// <summary>
        /// 显示TabControl所有页面
        /// </summary>
        private void ShowTab()
        {            
            //显示所有页面
            pageStaff.Parent = tabControl;
            pageResume.Parent = tabControl;
            pageFamily.Parent = tabControl;
            pageWorkResume.Parent = tabControl;
            pageTrain.Parent = tabControl;
            pageRP.Parent = tabControl;
            //按顺序排列页面
            tabControl.TabPages[0] = pageStaff;
            tabControl.TabPages[1] = pageResume;
            tabControl.TabPages[2] = pageFamily;
            tabControl.TabPages[3] = pageWorkResume;
            tabControl.TabPages[4] = pageTrain;
            tabControl.TabPages[5] = pageRP;           
        }
        #endregion

        #region 设置TabPage只读
        /// <summary>
        /// 设置TabPage只读
        /// </summary>
        private void SetPageReadOnly()
        {
            switch (tabControl.SelectedTab.Name)//选中页面
            {
                //设置页面内容只读
                case "pageStaff": myFunctionClass.SetControlReadOnly(pageStaff.Controls); break;
                case "pageResume": myFunctionClass.SetControlReadOnly(pageResume.Controls); break;
                case "pageFamily": myFunctionClass.SetControlReadOnly(grpFamily.Controls); break;
                case "pageWorkResume": myFunctionClass.SetControlReadOnly(grpWorkResume.Controls); break;
                case "pageTrain": myFunctionClass.SetControlReadOnly(grpTrain.Controls); break;
                case "pageRP": myFunctionClass.SetControlReadOnly(grpRP.Controls); break;
                default : break;
            }
        }
        #endregion

        #region 显示TabPage可编辑
        /// <summary>
        /// 显示TabPage可编辑
        /// </summary>
        private void SetPageWrite()
        {
            switch (tabControl.SelectedTab.Name)//选中页面
            {
                //恢复页面可编辑
                case "pageStaff": myFunctionClass.SetControlWrite(pageStaff.Controls); break;
                case "pageResume": myFunctionClass.SetControlWrite(pageResume.Controls); break;
                case "pageFamily": myFunctionClass.SetControlWrite(grpFamily.Controls); break;
                case "pageWorkResume": myFunctionClass.SetControlWrite(grpWorkResume.Controls); break;
                case "pageTrain": myFunctionClass.SetControlWrite(grpTrain.Controls); break;
                case "pageRP": myFunctionClass.SetControlWrite(grpRP.Controls); break;
                default: break;
            }
        }
        #endregion

        #region 清除TabPage显示内容
        /// <summary>
        /// 清除TabPage显示内容
        /// </summary>
        private void ClearPage()
        {
            switch (tabControl.SelectedTab.Name)//选中页面
            {
                //清空页面内容
                case "pageStaff": myFunctionClass.ClearControl(pageStaff.Controls); break;
                case "pageResume": myFunctionClass.ClearControl(pageResume.Controls); break;
                case "pageFamily": myFunctionClass.ClearControl(grpFamily.Controls); break;
                case "pageWorkResume": myFunctionClass.ClearControl(grpWorkResume.Controls); break;
                case "pageTrain": myFunctionClass.ClearControl(grpTrain.Controls); break;
                case "pageRP": myFunctionClass.ClearControl(grpRP.Controls); break;
                default: break;
            }
        }
        #endregion        

        #region 限制输入框长度
        /// <summary>
        /// 限制输入框长度
        /// </summary>
        private void Limitlength()
        {
            cboCondition.MaxLength = 10;//查询条件
            stf_StaffName.MaxLength = 10;//姓名
            stf_IDCard.MaxLength = 20;//身份证号
            stf_HomeAddress.MaxLength = 30;//家庭住址
            stf_Phone.MaxLength = 11;//联系电话
            stf_School.MaxLength = 30;//毕业学校
            stf_Major.MaxLength = 20;//专业
            stf_BankCard.MaxLength = 20;//银行账号
            stf_Salary.MaxLength = 9;//月工资
            stf_ContractY.MaxLength = 3;//合同年限
            fa_Name.MaxLength = 10;//家庭成员名称
            fa_Relation.MaxLength = 10;//与本人关系
            fa_Company.MaxLength = 30;//工作单位
            fa_Position.MaxLength = 20;//职务
            fa_PoliticalStatus.MaxLength = 20;//政治面貌
            fa_Phone.MaxLength = 11;//手机号码
            work_Company.MaxLength = 30;//工作简介工作单位
            work_Department.MaxLength = 20;//工作简介部门
            work_Position.MaxLength = 20;//工作简介职务
            tr_Means.MaxLength = 20;//培训方式
            tr_Major.MaxLength = 20;//培训专业
            tr_TrainCompany.MaxLength = 30;//培训单位
            tr_Content.MaxLength = 50;//培训内容
            tr_Charge.MaxLength = 10;//培训花费     
            tr_Effect.MaxLength = 20;//培训效果      
            rp_Auditor.MaxLength = 10;//奖惩批准人
            rp_Remark.MaxLength = 50;//奖惩备注
        }
        #endregion
        #endregion

        #region ManagerForm构造函数
        /// <summary>
        /// ManagerForm构造函数
        /// </summary>
        public ManagerForm()
        {
            InitializeComponent();
        }
        #endregion

        #region  ManagerForm加载事件
        /// <summary>
        /// ManagerForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void ManagerForm_Load(object sender, EventArgs e)
        {           
            Limitlength();//设置输入框输入长度限制      
            btnAll_Click(sender, e);//初始化数据和按钮
            myFunctionClass.SetButton(btnFirst, btnPrevious, btnNext, btnEnd, false, false, false, false);
            myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, true, true, true, false, false);
            try
            {
                //设置下拉框值
                myFunctionClass.SetControlsData(pageStaff.Controls, "no_");
                myFunctionClass.SetCmbData(no_RP, "tb_RPType", "RP");
            }
            catch
            {
                MessageBox.Show("下拉框填充数据出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //comboBox_type添加数据
            cboSelectType.Items.Add("姓名");
            cboSelectType.Items.Add("性别");
            cboSelectType.Items.Add("民族");
            cboSelectType.Items.Add("政治面貌");
            cboSelectType.Items.Add("职工类别");
            cboSelectType.Items.Add("职工职务");
            cboSelectType.Items.Add("职工部门");
            cboSelectType.Items.Add("职称类别");
            cboSelectType.Items.Add("工资类别");
            cboSelectType.SelectedIndex = 0;
            //设置MaskedTextBox控件
            myFunctionClass.SetMtxData(stf_Birthday);
            myFunctionClass.SetMtxData(stf_GraduateDate);
            myFunctionClass.SetMtxData(stf_ContractB);
            myFunctionClass.SetMtxData(stf_ContractE);
            myFunctionClass.SetMtxData(stf_WorkDate);
            myFunctionClass.SetMtxData(fa_Birthday);
            myFunctionClass.SetMtxData(work_BeginDate);
            myFunctionClass.SetMtxData(work_EndDate);
            myFunctionClass.SetMtxTime(tr_BeginTime);
            myFunctionClass.SetMtxTime(tr_EndTime);
            myFunctionClass.SetMtxTime(rp_RPTime);
            //设置DataGridView控件
            myFunctionClass.SetDgv(dgvStaff);
            dgvStaff.RowHeadersVisible = false;//不显示第一列空白栏
            myFunctionClass.SetDgv(dgvWorkResume);
            dgvWorkResume.RowHeadersVisible = false;//不显示第一列空白栏
            myFunctionClass.SetDgv(dgvFamily);
            dgvFamily.RowHeadersVisible = false;//不显示第一列空白栏
            myFunctionClass.SetDgv(dgvRP);
            dgvRP.RowHeadersVisible = false;//不显示第一列空白栏
            myFunctionClass.SetDgv(dgvTrain);
            dgvTrain.RowHeadersVisible = false;//不显示第一列空白栏
            for (int i = 2; i < dgvStaff.ColumnCount; i++)
            {
                dgvStaff.Columns[i].Visible = false;//设置部分数据不可见
            }
            //设置信息只读
            myFunctionClass.SetControlReadOnly(pageStaff.Controls);
            myFunctionClass.SetControlReadOnly(pageResume.Controls);
            myFunctionClass.SetControlReadOnly(grpFamily.Controls);
            myFunctionClass.SetControlReadOnly(grpTrain.Controls);
            myFunctionClass.SetControlReadOnly(grpWorkResume.Controls);
            myFunctionClass.SetControlReadOnly(grpRP.Controls);
            //设置用户编号只读
            stf_ID.ReadOnly = true;
        }
        #endregion

        #region ManagerForm激活事件
        /// <summary>
        /// ManagerForm激活事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>

        private void ManagerForm_Activated(object sender, EventArgs e)
        {
            if (dgvStaff.Rows.Count > 0)
            {
                if(dgvStaff.CurrentCell==null)
                {
                    dgvStaff.Rows[0].Selected = true;//选中第一行
                }
                else
                {
                    int selectRow = dgvStaff.CurrentCell.RowIndex;
                    dgvStaff.CurrentCell = null;//不选中单元格 
                    dgvStaff.CurrentCell = dgvStaff[0, selectRow];//选中当前行
                }                
            }
        }
        #endregion

        #region 功能按钮
        #region btnAdd点击事件
        /// <summary>
        /// btnAdd点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {            
            //清空当前页面内容
            ClearPage();
            if (tabControl.SelectedTab.Name == "pageStaff")//职工信息页
            {
                try
                {
                    stf_ID.Text = myFunctionClass.GetAutoID();//自动获取职工编号
                }
                catch
                {
                    MessageBox.Show("职工编号获取错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                                        
                    btnAll_Click(sender, e);
                    return;
                }
            }
            else
            {
                if(stf_ID.Text=="")
                {
                    MessageBox.Show("不存在员工信息，请先增加员工信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                  
                    tabControl.SelectedIndex = 0;//选中第一个页面
                    btnAll_Click(sender, e);
                    return;
                }
            }
            //设置状态标志
            alterAdd = 1;
            //设置按钮状态
            myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, false, false, false, true, true);           
            myFunctionClass.HideTab(tabControl);//隐藏部分页面
            SetPageWrite();//设置页面可编辑
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
            if (lblID.Text == ""||(tabControl.SelectedTab.Name != "pageStaff" && tabControl.SelectedTab.Name != "pageResume" && SNO == -1))
            {
                MessageBox.Show("未选中职工数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                alterAdd = 2;//编辑状态
                //设置按钮状态
                myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, false, false, false, true, true);
                myFunctionClass.HideTab(tabControl);//隐藏部分页面
                SetPageWrite();//设置页面可编辑
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
            int selectRow = 0;
            if (lblID.Text == ""||(tabControl.SelectedTab.Name != "pageStaff" && tabControl.SelectedTab.Name != "pageResume"&&SNO==-1))
            {
                MessageBox.Show("未选中职工数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("是否删除记录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        //删除数据
                        switch (tabControl.SelectedTab.Name)
                        {
                            case "pageStaff":
                                {
                                    if (MessageBox.Show("删除职工信息将删除员工所有相关信息", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                    {
                                        //删除职工信息表所有相关信息
                                        myDataClass.ExecuteDeleteSql("tb_Staff", "ID='" + stf_ID.Text.Trim() + "'");
                                        myDataClass.ExecuteDeleteSql("tb_Resume", "ID='" + stf_ID.Text.Trim() + "'");
                                        myDataClass.ExecuteDeleteSql("tb_Family", "ID='" + stf_ID.Text.Trim() + "'");
                                        myDataClass.ExecuteDeleteSql("tb_WorkResume", "ID='" + stf_ID.Text.Trim() + "'");
                                        myDataClass.ExecuteDeleteSql("tb_Train", "ID='" + stf_ID.Text.Trim() + "'");
                                        myDataClass.ExecuteDeleteSql("tb_RP", "ID='" + stf_ID.Text.Trim() + "'");
                                    }                                        
                                    if (dgvStaff.Rows.Count == 0)//无数据
                                    {
                                        lblID.Text = "";
                                    }
                                    break;
                                }
                            case "pageResume":
                                {
                                    selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                                    //执行插入语句，清空职工简介内容
                                    myDataClass.ExecuteUpdateSql("tb_Resume", "Content=''", "ID='" + stf_ID.Text + "'");
                                    break;
                                }
                            case "pageFamily":
                                {
                                    selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                                    //删除选中数据
                                    myDataClass.ExecuteDeleteSql("tb_Family", "SNO=" + SNO);
                                    if (dgvFamily.Rows.Count == 0)//无数据
                                    {
                                        SNO=-1;
                                    }
                                    break;
                                }
                            case "pageWorkResume":
                                {
                                    selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                                    //删除选中数据
                                    myDataClass.ExecuteDeleteSql("tb_WorkResume", "SNO=" + SNO);
                                    if (dgvWorkResume.Rows.Count == 0)//无数据
                                    {
                                        SNO = -1;
                                    }
                                    break;
                                }
                            case "pageTrain":
                                {
                                    selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                                    //删除选中数据
                                    myDataClass.ExecuteDeleteSql("tb_Train", "SNO=" + SNO);
                                    if (dgvTrain.Rows.Count == 0)//无数据
                                    {
                                        SNO = -1;
                                    }
                                    break;
                                }
                            case "pageRP":
                                {
                                    selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                                    //删除选中数据
                                    myDataClass.ExecuteDeleteSql("tb_RP", "SNO=" + SNO);
                                    if (dgvRP.Rows.Count == 0)//无数据
                                    {
                                        SNO = -1;
                                    }
                                    break;
                                }
                            default: return;
                        }
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        myFunctionClass.ClearControl(pageStaff.Controls);//清空控件内容
                        btnAll_Click(sender, e);//显示全部数据   
                        if(dgvStaff.RowCount!=0)
                        {
                            dgvStaff.CurrentCell = null;//不选中单元格 
                            dgvStaff.CurrentCell = dgvStaff[0, selectRow];//选中当前行                          
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

        #region  btnQuit点击事件
        /// <summary>
        /// btnQuit点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出编辑", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {             
                TabPage selectPage = tabControl.SelectedTab;//当前选中页面
                int selectRow=dgvStaff.CurrentCell.RowIndex;//当前选中数据
                alterAdd = 0;//设置状态标志
                stf_ID.Text = "";                
                //设置按钮状态
                myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, true, true, true, false, false);
                SetPageReadOnly();//设置页面只读
                ShowTab();//显示所有页面
                btnAll_Click(sender, e);//显示所有数据
                tabControl.SelectedTab = selectPage;//选中刚才页  
                dgvStaff.CurrentCell = null;//不选中单元格 
                dgvStaff.CurrentCell = dgvStaff[0, selectRow];//选中当前行
            }
        }
        #endregion

        #region  btnSave点击事件
        /// <summary>
        /// btnSave点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int selectRow = 0;
            TabPage selectPage = tabControl.SelectedTab;//当前选中页面
            switch (selectPage.Name)//当前选中页面
            {
                case "pageStaff":
                    {
                        if (alterAdd == 1)//添加
                        {
                            //获得新编号
                            string ID = myFunctionClass.GetAutoID();
                            ////插入字段
                            string field = "ID,StaffName,SexType,Birthday,NationType,EducationType,"+
                                "PoliticalStatusType,MarriageType,IDCard,HomeAddress,Phone,School,Major," +
                                 "GraduateDate,StaffType,DepartmentType,PositionType,TitleType,SalaryType," +
                                 "Salary,BankCard,WorkDate,ContractB,ContractE,ContractY";
                            //插入值
                            string value = myFunctionClass.GetInsertValue(field, pageStaff.Controls, "stf_");
                            //执行插入语句
                            myDataClass.ExecuteInsertSql("tb_Staff", field, value);
                            //保存图片
                            if(stf_Photo.Image!=null)
                            {
                                myFunctionClass.SaveImage(stf_ID.Text, photoByte);                               
                            }
                            //保存籍贯信息
                            myFunctionClass.UpdateNativePlace(no_Province.Text, no_City.Text, stf_ID.Text);
                            //新建简历
                            //插入字段
                            string rfield = "ID,Content";
                            //插入值
                            string rvalue = "'" + stf_ID.Text.Trim() + "',''";
                            //执行插入语句
                            myDataClass.ExecuteInsertSql("tb_Resume", rfield, rvalue);
                        }
                        else if(alterAdd==2)//修改
                        {
                            //更新字段和值
                            string fieldValue = myFunctionClass.GetUpdateFieldValue( pageStaff.Controls, "stf_");
                            //执行更新语句
                            myDataClass.ExecuteUpdateSql("tb_Staff", fieldValue,"ID='"+stf_ID.Text+"'");
                            //保存图片
                            if (stf_Photo.Image != null)
                            {
                                myFunctionClass.SaveImage(stf_ID.Text, photoByte);
                            }
                            //保存籍贯信息
                            myFunctionClass.UpdateNativePlace(no_Province.Text, no_City.Text, stf_ID.Text);
                        }
                        else
                        {
                            return;
                        }
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "pageResume":
                    {
                        if (alterAdd == 1||alterAdd == 2)//添加或修改
                        {
                            selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                            //更新字段和值
                            string fieldValue = "Content='"+ re_Content.Text.Trim() + "'";
                            //执行插入语句
                            myDataClass.ExecuteUpdateSql("tb_Resume", fieldValue, "ID='" + stf_ID.Text + "'");
                        }
                        else
                        {
                            return;
                        }
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "pageFamily":
                    {
                        if (alterAdd == 1)//添加
                        {
                            //获得新编号
                            SNO= myFunctionClass.GetAutoNO("tb_Family","SNO");
                            ////插入字段
                            string field = "SNO,ID,Name,Relation,Birthday,Company,Position,PoliticalStatus,Phone";
                            //插入值
                            string value = SNO+",'"+stf_ID.Text+"',"+myFunctionClass.GetInsertValue(field, grpFamily.Controls, "fa_");
                            //执行插入语句
                            myDataClass.ExecuteInsertSql("tb_Family", field, value);
                        }
                        else if (alterAdd == 2)//修改
                        {
                            //更新字段和值
                            string fieldValue = myFunctionClass.GetUpdateFieldValue(grpFamily.Controls, "fa_");
                            //执行更新语句
                            myDataClass.ExecuteUpdateSql("tb_Family", fieldValue, "SNO=" +SNO );
                        }
                        else
                        {
                            return;                           
                        }
                        selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "pageWorkResume":
                    {
                        if (alterAdd == 1)//添加
                        {
                            //获得新编号
                            SNO = myFunctionClass.GetAutoNO("tb_WorkResume", "SNO");
                            ////插入字段
                            string field = "SNO,ID,BeginDate,EndDate,Company,Department,Position";
                            //插入值
                            string value = SNO + ",'" + stf_ID.Text + "'," + myFunctionClass.GetInsertValue(field, grpWorkResume.Controls, "work_");
                            //执行插入语句
                            myDataClass.ExecuteInsertSql("tb_WorkResume", field, value);
                        }
                        else if (alterAdd == 2)//修改
                        {
                            //更新字段和值
                            string fieldValue = myFunctionClass.GetUpdateFieldValue(grpWorkResume.Controls, "work_");
                            //执行更新语句
                            myDataClass.ExecuteUpdateSql("tb_WorkResume", fieldValue, "SNO=" + SNO);
                        }
                        else
                        {
                            return;
                        }
                        selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "pageTrain":
                    {
                        if (alterAdd == 1)//添加
                        {
                            //获得新编号
                            SNO = myFunctionClass.GetAutoNO("tb_Train", "SNO");
                            ////插入字段
                            string field = "SNO,ID,Means,BeginTime,EndTime,Major,TrainCompany,Content,Charge,Effect";
                            //插入值
                            string value = SNO + ",'" + stf_ID.Text + "'," + myFunctionClass.GetInsertValue(field, grpTrain.Controls, "tr_");
                            //执行插入语句
                            myDataClass.ExecuteInsertSql("tb_Train", field, value);
                        }
                        else if (alterAdd == 2)//修改
                        {
                            //更新字段和值
                            string fieldValue = myFunctionClass.GetUpdateFieldValue(grpTrain.Controls, "tr_");
                            //执行更新语句
                            myDataClass.ExecuteUpdateSql("tb_Train", fieldValue, "SNO=" + SNO);
                        }
                        else
                        {
                            return;
                        }
                        selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "pageRP":
                    {
                        if (alterAdd == 1)//添加
                        {
                            //获得新编号
                            SNO = myFunctionClass.GetAutoNO("tb_RP", "SNO");
                            ////插入字段
                            string field = "SNO,ID,RPType,RPTime,Auditor,Remark";
                            //插入值
                            string value = SNO + ",'" + stf_ID.Text + "'," + myFunctionClass.GetInsertValue(field, grpRP.Controls, "rp_");
                            //执行插入语句
                            myDataClass.ExecuteInsertSql("tb_RP", field, value);
                        }
                        else if (alterAdd == 2)//修改
                        {
                            //更新字段和值
                            string fieldValue = myFunctionClass.GetUpdateFieldValue(grpRP.Controls, "rp_");
                            //执行更新语句
                            myDataClass.ExecuteUpdateSql("tb_RP", fieldValue, "SNO=" + SNO);
                        }
                        else
                        {
                            return;
                        }
                        selectRow = dgvStaff.CurrentCell.RowIndex;//记录当前活动窗格
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                default:return;
            }
            alterAdd = 0;//查看状态          
            btnAll_Click(sender, e);//显示所有数据
            dgvStaff.CurrentCell = null;//不选中单元格 
            dgvStaff.CurrentCell = dgvStaff[0, selectRow];//选中当前行
            //设置按钮状态
            myFunctionClass.SetButton(btnAdd, btnAlter, btnDelete, btnQuit, btnSave, true, true, true, false, false);
            SetPageReadOnly();//设置信息只读
            ShowTab();//显示所有页面   
            tabControl.SelectedTab = selectPage;//选中刚才页         
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
            dgvStaff.DataSource = dataSet.Tables[0];
            if(dgvStaff.CurrentCell!=null)
            {
                int selectRow= dgvStaff.CurrentCell.RowIndex;
                dgvStaff.CurrentCell = null;//不选中单元格 
                dgvStaff.CurrentCell = dgvStaff[0, selectRow];//选中当前行  
            }
                 
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
            if ( cboSelectType.Text==""||cboCondition.Text=="")
            {
                MessageBox.Show("查找条件为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string condition;//查找条件
            if(selectType== "StaffName")//查找类型为职工姓名
            {
                condition = "tb_Staff." + selectType + " LIKE '%" + cboCondition.Text + "%'";
            }   
            else
            {
                condition = "tb_"+ selectType +"Type."+ selectType + " LIKE '%" + cboCondition.Text + "%'";
            }        
            DataSet dataSet = new DataSet();
            try
            {
                //填充用户数据
                dataSet = myFunctionClass.GetStaffData(condition);
            }
            catch
            {
                MessageBox.Show("查找数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //设置DataGridView数据
            dgvStaff.DataSource = dataSet.Tables[0];
            if (dgvStaff.Rows.Count == 0 && alterAdd == 0)
            {
                //清空控件内容
                ClearPage();
                stf_ID.Text = "";
            }
        }
        #endregion

        #region btnPhoto点击事件
        /// <summary>
        /// btnPhoto点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";//设置文件筛选
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //从指定文件显示图片
                    stf_Photo.Image = Image.FromFile(openFileDialog.FileName);
                    //将图片以文件流的方式保存
                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    photoByte = br.ReadBytes((int)fs.Length);//将流内数据保存到数组
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stf_Photo.Image = null;
                }
            }
        }
        #endregion
        #endregion

        #region 调序按钮
        #region btnFirst点击事件
        /// <summary>
        /// btnFirst点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvStaff.Rows.Count > 0)//存在数据
            {
                dgvStaff.CurrentCell = dgvStaff[0,0];//选中第一行
            }                
        }
        #endregion

        #region btnPrevious点击事件
        /// <summary>
        /// btnPrevious点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(dgvStaff.CurrentCell!=null)//当前选中项不为空
            {
                if (dgvStaff.CurrentCell.RowIndex > 0)
                {
                    dgvStaff.CurrentCell = dgvStaff[0, dgvStaff.CurrentCell.RowIndex - 1];//选中上一行                    
                }
            }            
        }
        #endregion

        #region btnNext点击事件
        /// <summary>
        /// btnNext点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentCell != null)//当前选中项不为空
            {
                if (dgvStaff.CurrentCell.RowIndex < dgvStaff.Rows.Count - 1)
                {
                    dgvStaff.CurrentCell = dgvStaff[0, dgvStaff.CurrentCell.RowIndex + 1];//选中下一行
                }
            }
               
        }
        #endregion

        #region btnEnd点击事件
        /// <summary>
        /// btnEnd点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (dgvStaff.Rows.Count > 0)//存在数据
            {
                dgvStaff.CurrentCell = dgvStaff[0,dgvStaff.Rows.Count-1];//选中最后一行
            }
        }
        #endregion
        #endregion

        #region dgvStaff单元格点击事件
        /// <summary>
        /// dgvStaff单元格点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvStaff_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStaff.CurrentCell != null)//当前选中项不为空
            {
                if(dgvStaff.Rows.Count==1)//数据只有一行
                {
                    //设置按钮状态
                    myFunctionClass.SetButton(btnFirst, btnPrevious, btnNext, btnEnd, false, false, false, false);
                }
                else if (dgvStaff.CurrentCell.RowIndex ==0)//当前选中第一行
                {
                    //设置按钮状态
                    myFunctionClass.SetButton(btnFirst, btnPrevious, btnNext, btnEnd, false, false, true, true);
                }
                else if(dgvStaff.CurrentCell.RowIndex == dgvStaff.Rows.Count - 1)//当前选中最后一行
                {
                    //设置按钮状态
                    myFunctionClass.SetButton(btnFirst, btnPrevious, btnNext, btnEnd, true, true, false, false);
                }
                else
                {
                    //设置按钮状态
                    myFunctionClass.SetButton(btnFirst, btnPrevious, btnNext, btnEnd, true, true, true, true);
                }
            }
            else
            {
                //设置按钮状态
                myFunctionClass.SetButton(btnFirst, btnPrevious, btnNext, btnEnd, false, false, false, false);
            }

            try
            {
                lblID.Text = dgvStaff[0, dgvStaff.CurrentCell.RowIndex].Value.ToString();//记录当前活动窗格
            }
            catch
            {

                MessageBox.Show("获取当前选中职工ID出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            //状态为查看信息时显示信息
            if (alterAdd == 0)
            {
                ClearPage();//清空内容
                SNO = -1;
                try
                {
                    string staffField = "StaffName,SexType,Birthday,NationType,EducationType,PoliticalStatusType," +
                        "MarriageType,IDCard,ProvinceType,CityType,HomeAddress,Phone,School,Major," +
                        "GraduateDate,StaffType,DepartmentType,PositionType,TitleType,SalaryType," + 
                        "Salary,BankCard,WorkDate,ContractB,ContractE,ContractY";
                    //记录当前焦点的ID编号                    
                    stf_ID.Text = dgvStaff[0, dgvStaff.CurrentCell.RowIndex].Value.ToString();
                   //显示当前职工信息
                    myFunctionClass.ShowDgvData(staffField, dgvStaff, pageStaff.Controls, "stf_");
                    //显示图片
                    try
                    {
                        photoByte = myFunctionClass.GetStaffPhoto(stf_ID.Text);
                        MemoryStream ms = new MemoryStream(photoByte);			//将字节数组存入到二进制流中
                        stf_Photo.Image = Image.FromStream(ms);   //二进制流Image控件中显示
                    }
                    catch
                    {
                        stf_Photo.Image = null;//图片为空
                    }
                    //显示其他页数据
                    DataTable dataTable= myDataClass.SelectData("Content", "tb_Resume", "ID=" + stf_ID.Text);
                    if (dataTable.Rows.Count > 0)
                    {
                        //控件显示数据
                        re_Content.Text = dataTable.Rows[0][0].ToString();
                    }
                    //设置dgvFamily数据
                    DataSet dataSet1 =myDataClass.GetDataSet("SNO 编号,Name 家庭成员名称,Relation 关系,"+
                        "Birthday 出生日期,Company 工作单位,Position 职务,PoliticalStatus 政治面貌,"+
                        "Phone 手机", "tb_Family", "ID=" + stf_ID.Text);                    
                    dgvFamily.DataSource = dataSet1.Tables[0];
                    //设置dgvWorkResume数据
                    DataSet dataSet2 = myDataClass.GetDataSet("SNO 编号,BeginDate 开始时间,EndDate 结束时间,"+
                        "Company 工作单位,Department 部门,Position 职务", "tb_WorkResume", "ID=" + stf_ID.Text);                    
                    dgvWorkResume.DataSource = dataSet2.Tables[0];
                    //设置dgvTrain数据
                    DataSet dataSet3 = myDataClass.GetDataSet("SNO 编号,Means 培训方式,BeginTime 开始时间," +
                        "EndTime 结束时间,Major 培训专业,TrainCompany 培训单位,Content 培训内容,"+
                        "Charge 培训费用,Effect 培训效果", "tb_Train", "ID=" + stf_ID.Text);                    
                    dgvTrain.DataSource = dataSet3.Tables[0];
                    //设置dgvRP数据
                    DataSet dataSet4 = myDataClass.GetDataSet("SNO 编号,tb_RPType.RP 奖惩种类,RPTime 奖惩时间," +
                        "Auditor 批准人,Remark 备注", "tb_RP LEFT JOIN tb_RPType " +
                    "ON tb_RPType.TNO=tb_RP.RPType " , "ID=" + stf_ID.Text);                   
                    dgvRP.DataSource = dataSet4.Tables[0];
                }
                catch
                {
                    MessageBox.Show("职工信息显示出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region dgvFamilly单元格点击事件
        /// <summary>
        /// dgvFamilly单元格点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvFamily_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //状态为查看信息时显示信息
            if (alterAdd == 0)
            {
                try
                {
                    string field = "Name,Relation,Birthday,Company,Position,PoliticalStatus,Phone";
                    //记录当前焦点的数据编号                    
                    SNO= (int)dgvFamily[0, dgvFamily.CurrentCell.RowIndex].Value;
                    //将数据显示在页面上
                    myFunctionClass.ShowDgvData(field, dgvFamily, grpFamily.Controls, "fa_");
                }
                catch
                {
                    MessageBox.Show("家庭关系显示出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region dgvWorkResume单元格点击事件
        /// <summary>
        /// dgvWorkResume单元格点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvWorkResume_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //状态为查看信息时显示信息
            if (alterAdd == 0)
            {
                try
                {
                    string field = "BeginDate,EndDate,Company,Department,Position";
                    //记录当前焦点的数据编号                    
                    SNO = (int)dgvWorkResume[0, dgvWorkResume.CurrentCell.RowIndex].Value;
                    //将数据显示在页面上
                    myFunctionClass.ShowDgvData(field, dgvWorkResume, grpWorkResume.Controls, "work_");
                }
                catch
                {
                    MessageBox.Show("工作经历显示出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region dgvTrain单元格点击事件
        /// <summary>
        /// dgvTrain单元格点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvTrain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //状态为查看信息时显示信息
            if (alterAdd == 0)
            {
                try
                {
                    string field = "Means,BeginTime,EndTime,Major,TrainCompany,Content,Charge,Effect";
                    //记录当前焦点的数据编号                    
                    SNO = (int)dgvTrain[0, dgvTrain.CurrentCell.RowIndex].Value;
                    //将数据显示在页面上
                    myFunctionClass.ShowDgvData(field, dgvTrain ,grpTrain.Controls, "tr_");
                }
                catch
                {
                    MessageBox.Show("培训数据显示出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region dgvRP单元格点击事件
        /// <summary>
        /// dgvRP单元格点击事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void dgvRP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //状态为查看信息时显示信息
            if (alterAdd == 0)
            {
                try
                {
                    string field = "RPType,RPTime,Auditor,Remark";
                    //记录当前焦点的数据编号                    
                    SNO = (int)dgvRP[0, dgvRP.CurrentCell.RowIndex].Value;
                    //将数据显示在页面上
                    myFunctionClass.ShowDgvData(field, dgvRP, grpRP.Controls, "rp_");
                }
                catch
                {
                    MessageBox.Show("奖惩数据显示出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region tabControl选中页改变事件
        /// <summary>
        /// tabControl选中页改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((TabControl)sender).SelectedTab!=null)
            {
                if(((TabControl)sender).SelectedTab.Name!="pageStaff"&& stf_ID.Text == "")
                {
                    MessageBox.Show("无选中职工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ((TabControl)sender).SelectedIndex = 0;//选中第一页                                         
                }
                switch (((TabControl)sender).SelectedTab.Name)//选中页面
                {
                    case "pageStaff":
                        {
                            SNO = -1;
                            break;
                        }
                    case "pageResume":
                        {
                            SNO = -1;
                            break;
                        }
                    case "pageFamily":
                        {
                            myFunctionClass.ClearControl(grpFamily.Controls);//清空内容
                            if (dgvFamily.Rows.Count > 0)//选中第一行
                            {
                                dgvFamily.CurrentCell = null;//选中单元格为空
                                dgvFamily.CurrentCell = dgvFamily[0, 0];//选中第一个单元格
                            }
                            else
                            {
                                SNO = -1;
                            }
                            break;
                        }
                    case "pageWorkResume":
                        {
                            myFunctionClass.ClearControl(grpWorkResume.Controls);//清空内容
                            if (dgvWorkResume.Rows.Count > 0)//选中第一行
                            {
                                dgvWorkResume.CurrentCell = null;//选中单元格为空
                                dgvWorkResume.CurrentCell = dgvWorkResume[0, 0];//选中第一个单元格
                            }
                            else
                            {
                                SNO = -1;
                            }
                            break;
                        }
                    case "pageTrain":
                        {
                            myFunctionClass.ClearControl(grpTrain.Controls);//清空内容
                            if (dgvTrain.Rows.Count > 0)//选中第一行
                            {
                                dgvTrain.CurrentCell = null;//选中单元格为空
                                dgvTrain.CurrentCell = dgvTrain[0, 0];//选中第一个单元格
                            }
                            else
                            {
                                SNO = -1;
                            }
                            break;
                        }
                    case "pageRP":
                        {
                            myFunctionClass.ClearControl(grpRP.Controls);//清空内容
                            if (dgvRP.Rows.Count > 0)//选中第一行
                            {
                                dgvRP.CurrentCell = null;//选中单元格为空
                                dgvRP.CurrentCell = dgvRP[0, 0];//选中第一个单元格
                            }
                            else
                            {
                                SNO = -1;
                            }
                            break;
                        }
                    default: break;
                }
            }
            
        }
        #endregion

        #region no_Province选项改变事件
        /// <summary>
        /// no_Province选项改变事件
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
                MessageBox.Show("城市数据填充出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region cboSelectType文本改变事件
        /// <summary>
        /// cboSelectType文本改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void cboSelectType_TextChanged(object sender, EventArgs e)
        {
            cboCondition.Text = "";
            cboCondition.Items.Clear();//清空下拉框内容
            switch (cboSelectType.Text.Trim())//选择条件
            {
                case "姓名":
                    {
                        selectType = "StaffName";
                        break;
                    }                    
                case "性别":
                    {
                        selectType = "Sex";
                        break;
                    }
                case "民族":
                    {
                        selectType = "Nation";
                        break;
                    }
                case "政治面貌":
                    {
                        selectType = "PoliticalStatus";
                        break;
                    }
                case "职工类别":
                    {
                        selectType = "Staff";
                        break;
                    }
                case "职工职务":
                    {
                        selectType = "Position";
                        break;
                    }
                case "职工部门":
                    {
                        selectType = "Department";
                        break;
                    }
                case "职称类别":
                    {
                        selectType = "Title";
                        break;
                    }
                case "工资类别":
                    {
                        selectType = "Salary";
                        break;
                    }
                default : selectType = ""; break;
            }
            if(selectType!=""&&selectType!= "StaffName")
            {
                try
                {
                    //填充数据
                    myFunctionClass.SetCmbData(cboCondition, "tb_" + selectType + "Type", selectType);
                }                
                catch
                {
                    MessageBox.Show("查找内容框数据填充出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 输入限制
        #region MaskedTextBox失去焦点事件
        /// <summary>
        /// MaskedTextBox失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void MaskedTextBox_Leave(object sender, EventArgs e)
        {
            if (myFunctionClass.IsDataTime((MaskedTextBox)sender) == false)
            {
                MessageBox.Show("时间输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region stf_ContractE失去焦点事件
        /// <summary>
        /// stf_ContractE失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void stf_ContractE_Leave(object sender, EventArgs e)
        {
            if (myFunctionClass.IsDataTime(stf_ContractE) == true)//输入时间格式正确
            {
                if (myFunctionClass.FormatData(stf_ContractB.Text) != "" && myFunctionClass.FormatData(stf_ContractE.Text) != "")
                {
                    if (Convert.ToDateTime(stf_ContractB.Text) >= Convert.ToDateTime(stf_ContractE.Text))
                    {
                        MessageBox.Show("当前日期必须大于它前一个日期。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        stf_ContractE.Text = "";
                    }
                    //记录年限
                    stf_ContractY.Text = (Convert.ToDateTime(stf_ContractE.Text).Year - Convert.ToDateTime(stf_ContractB.Text).Year).ToString();
                }
            }
            else
            {
                MessageBox.Show("时间输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region work_EndDate失去焦点事件
        /// <summary>
        /// work_EndDate失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void work_EndDate_Leave(object sender, EventArgs e)
        {
            if (myFunctionClass.IsDataTime(work_EndDate) == true)//输入时间格式正确
            {
                if (myFunctionClass.FormatData(work_BeginDate.Text) != "" && myFunctionClass.FormatData(work_EndDate.Text) != "")
                {
                    if (Convert.ToDateTime(work_BeginDate.Text) >= Convert.ToDateTime(work_EndDate.Text))
                    {
                        MessageBox.Show("当前日期必须大于它前一个日期。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        work_EndDate.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("时间输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region tr_EndTime失去焦点事件
        /// <summary>
        /// tr_EndTime失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void tr_EndTime_Leave(object sender, EventArgs e)
        {
            if (myFunctionClass.IsDataTime(tr_EndTime) == true)//输入时间格式正确
            {
                if (myFunctionClass.FormatDataTime(tr_BeginTime.Text) != "" && myFunctionClass.FormatDataTime(tr_EndTime.Text) != "")
                {
                    if (Convert.ToDateTime(tr_BeginTime.Text) >= Convert.ToDateTime(tr_EndTime.Text))
                    {
                        MessageBox.Show("当前时间必须大于它前一个日期。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        work_EndDate.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("时间输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region stf_ContractY失去焦点事件
        /// <summary>
        /// stf_ContractY失去焦点事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void stf_ContractY_Leave(object sender, EventArgs e)
        {
            if (myFunctionClass.FormatDataTime(stf_ContractB.Text) != "" && myFunctionClass.FormatDataTime(stf_ContractE.Text) != "")
            {
                if ((Convert.ToDateTime(stf_ContractE.Text).Year - Convert.ToDateTime(stf_ContractB.Text).Year).ToString()!= stf_ContractY.Text.Trim())
                {
                    MessageBox.Show("合同年限与合同日期间不符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    stf_ContractY.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请先补充完整合同期限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stf_ContractY.Text = "";
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
            myFunctionClass.LimitFloatKey(e, ((Control)sender).Text);//限制只可输入浮点型字符
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

        #region ComboBox输入字符事件
        /// <summary>
        ///  ComboBox输入字符事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//设置输入无效
        }
        #endregion
        #endregion
    }
}
