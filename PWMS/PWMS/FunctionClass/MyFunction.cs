using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWMS.FunctionClass
{
    class MyFunction
    {
        #region 公共变量
        /// <summary>
        /// 数据库类
        /// </summary>
        DataClass.MyData myDataClass = new DataClass.MyData();
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public static string loginID = "";//登录用户ID
        /// <summary>
        /// 用户登录标志
        /// </summary>
        public static int loginFlag = 0;//用户登录标志
        #endregion

        #region 操纵控件
        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="formName">窗体名称</param>
        public void ShowForm(string formName)
        {
            formName = formName.Trim();
            if(formName=="人事档案管理")
            {
                ModuleForm.ManagerForm frmManagerForm = new ModuleForm.ManagerForm();//新建窗体
                frmManagerForm.Text = formName;//设置窗体名称
                frmManagerForm.ShowDialog();//显示窗体
                frmManagerForm.Dispose(); //释放资源                  
            }
            else if(formName=="人事资料查询")
            {
                ModuleForm.LookupForm frmLookupForm = new ModuleForm.LookupForm();
                frmLookupForm.Text = formName;
                frmLookupForm.ShowDialog();
                frmLookupForm.Dispose();    
            }
            else if (formName == "人事资料统计")
            {
                ModuleForm.StatisticsForm frmStatisticsForm = new ModuleForm.StatisticsForm();
                frmStatisticsForm.Text = formName;
                frmStatisticsForm.ShowDialog();
                frmStatisticsForm.Dispose();
            }
            else if (formName == "员工生日提示"|| formName == "员工合同提示")
            {
                ModuleForm.CueForm frmCueForm = new ModuleForm.CueForm();
                frmCueForm.Text = formName;
                if(formName=="员工生日提示")//不同提示设置不同tag
                {
                    frmCueForm.Tag = 1;
                }
                else if(formName=="员工合同提示")
                {
                    frmCueForm.Tag = 2;
                }
                frmCueForm.ShowDialog();
                frmCueForm.Dispose();
            }
            else if (formName == "日常记事")
            {
                ModuleForm.RecordForm frmRecordForm = new ModuleForm.RecordForm();
                frmRecordForm.Text = formName;
                frmRecordForm.ShowDialog();
                frmRecordForm.Dispose();
            }
            else if (formName == "通讯录")
            {
                ModuleForm.AddressBookForm frmAddressBookForm = new ModuleForm.AddressBookForm();
                frmAddressBookForm.Text = formName;
                frmAddressBookForm.ShowDialog();
                frmAddressBookForm.Dispose();
            }
            else if (formName == "备份/还原数据库")
            {
                ModuleForm.BackupRestoreDataForm frmBackupRestoreDataForm = new ModuleForm.BackupRestoreDataForm();
                frmBackupRestoreDataForm.Text = formName;
                frmBackupRestoreDataForm.ShowDialog();
                frmBackupRestoreDataForm.Dispose();
            }
            else if (formName == "清空数据库")
            {
                ModuleForm.DeleteDataForm frmDeleteDataForm = new ModuleForm.DeleteDataForm();
                frmDeleteDataForm.Text = formName;
                frmDeleteDataForm.ShowDialog();
                frmDeleteDataForm.Dispose();
            }
            else if (formName == "重新登录")
            {
                LoginForm frmLoginForm = new LoginForm();
                frmLoginForm.Tag = 2;//重新登录标志
                frmLoginForm.ShowDialog();
                frmLoginForm.Dispose();
            }
            else if (formName == "用户设置")
            {
                ModuleForm.UserForm frmSetForm = new ModuleForm.UserForm();
                frmSetForm.Text = formName;
                frmSetForm.ShowDialog();
                frmSetForm.Dispose();
            }
            else if (formName == "计算器")
            {
                System.Diagnostics.Process.Start("calc.exe");//打开系统计算器
            }
            else if (formName == "记事本")
            {
                System.Diagnostics.Process.Start("notepad.exe");//打开系统记事本
            }
            else if (formName == "系统帮助")
            {
                System.Diagnostics.Process.Start("系统帮助.docx");//打开帮助文件
            }
            else if (formName == "民族类别设置"||formName=="职工类别设置" || formName == "文化程度设置" || formName == "政治面貌设置" || formName == "部门类别设置" || formName == "工资类别设置" || formName == "职务类别设置" || formName == "职称类别设置" || formName == "奖惩类别设置" || formName == "记事类别设置")
            {                
                ModuleForm.TypeForm frmTypeForm = new ModuleForm.TypeForm();
                frmTypeForm.Text = formName;//设置窗体名称
                string sqlField = "";//数据库字段
                switch (formName)//不同类别对应数据库不同字段
                {
                    case "民族类别设置": sqlField = "Nation"; break;
                    case "职工类别设置": sqlField = "Staff"; break;
                    case "文化程度设置": sqlField = "Education"; break;
                    case "政治面貌设置": sqlField = "PoliticalStatus"; break;
                    case "部门类别设置": sqlField = "Department"; break;
                    case "工资类别设置": sqlField = "Salary"; break;
                    case "职务类别设置": sqlField = "Position"; break;
                    case "职称类别设置": sqlField = "Title"; break;
                    case "奖惩类别设置": sqlField = "RP"; break;
                    case "记事类别设置": sqlField = "Record"; break;
                }
                ModuleForm.TypeForm.sqlField = sqlField;//存储对应字段
                frmTypeForm.ShowDialog();//显示窗体
                frmTypeForm.Dispose();//释放资源
            }

        }
        #endregion

        #region 将MenuStrip控件信息添加到TreeView控件中
        /// <summary>
        /// 将MenuStrip控件信息添加到TreeView控件中
        /// </summary>
        /// <param name="treeView">TreeView控件</param>
        /// <param name="menuStrip">MenuStrip控件</param>
        public void CreateTv(TreeView treeView ,MenuStrip menuStrip)
        {
            treeView.Nodes.Clear();
            for(int i=0;i<menuStrip.Items.Count;i++)//遍历一级菜单项
            {
                if(menuStrip.Items[i] is ToolStripMenuItem)//判断是否为菜单项
                {
                    //保存菜单项
                    ToolStripMenuItem toolStripMenuItem1 = (ToolStripMenuItem)menuStrip.Items[i];
                    //菜单项转换成树节点并保存树节点
                    TreeNode treeNode1 = treeView.Nodes.Add(toolStripMenuItem1.Text);
                    for(int j=0;j<toolStripMenuItem1.DropDownItems.Count;j++)//遍历二级菜单项
                    {
                        if(toolStripMenuItem1.DropDownItems[j] is ToolStripMenuItem)//判断是否为菜单项
                        {
                            //保存菜单项
                            ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem)toolStripMenuItem1.DropDownItems[j];
                            //菜单项转换成树节点并保存树节点
                            TreeNode treeNode2 = treeNode1.Nodes.Add(toolStripMenuItem2.Text);
                            for(int k=0;k<toolStripMenuItem2.DropDownItems.Count;k++)//遍历三级菜单项
                            {
                                if(toolStripMenuItem2.DropDownItems[k] is ToolStripMenuItem)//判断是否为菜单项
                                {
                                    //保存菜单项
                                    ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem)toolStripMenuItem2.DropDownItems[k];
                                    //菜单项转换成树节点并保存树节点
                                    TreeNode treeNode3 = treeNode2.Nodes.Add(toolStripMenuItem3.Text);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }                    
            }
        }
        #endregion

        #region 点击TreeView调用MenuStrip按钮
        /// <summary>
        /// 点击TreeView调用MenuStrip按钮
        /// </summary>
        /// <param name="menuStrip">MenuStrip控件</param>
        /// <param name="e">TreeView点击事件</param>
        public void ClickTv(MenuStrip menuStrip,TreeNodeMouseClickEventArgs e)
        {
            string nodeText=e.Node.Text;
            for (int i = 0; i < menuStrip.Items.Count; i++)//遍历一级菜单项
            {
                if (menuStrip.Items[i] is ToolStripMenuItem)//判断是否为菜单项
                {
                    //保存菜单项
                    ToolStripMenuItem toolStripMenuItem1 = (ToolStripMenuItem)menuStrip.Items[i];
                    if (toolStripMenuItem1.Text == nodeText)//找到Treeview对应的MenuStrip按钮
                    {
                        if(toolStripMenuItem1.Enabled==false)//MenuStrip按钮不可用
                        {
                            MessageBox.Show("当前用户无权限调用" + "\"" + nodeText + "\"" + "窗体");
                            break;
                        }
                        else
                        {
                            ShowForm(nodeText);//实现点击打开窗体功能
                        }
                    }
                    for (int j = 0; j < toolStripMenuItem1.DropDownItems.Count; j++)//遍历二级菜单项
                    {
                        if (toolStripMenuItem1.DropDownItems[j] is ToolStripMenuItem)//判断是否为菜单项
                        {
                            //保存菜单项
                            ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem)toolStripMenuItem1.DropDownItems[j];
                            if (toolStripMenuItem2.Text == nodeText)//找到Treeview对应的MenuStrip按钮
                            {
                                if (toolStripMenuItem2.Enabled == false)//MenuStrip按钮不可用
                                {
                                    MessageBox.Show("当前用户无权限调用" + "\"" + nodeText + "\"" + "窗体");
                                    break;
                                }
                                else
                                {
                                    ShowForm(nodeText);//实现点击打开窗体功能
                                }
                            }
                            for (int k = 0; k < toolStripMenuItem2.DropDownItems.Count; k++)//遍历三级菜单项
                            {
                                if (toolStripMenuItem2.DropDownItems[k] is ToolStripMenuItem)//判断是否为菜单项
                                {
                                    //保存菜单项
                                    ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem)toolStripMenuItem2.DropDownItems[k];
                                    if (toolStripMenuItem3.Text == nodeText)//找到Treeview对应的MenuStrip按钮
                                    {
                                        if (toolStripMenuItem3.Enabled == false)//MenuStrip按钮不可用
                                        {
                                            MessageBox.Show("当前用户无权限调用" + "\"" + nodeText + "\"" + "窗体");
                                            break;
                                        }
                                        else
                                        {
                                            ShowForm(nodeText);//实现点击打开窗体功能
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        #endregion

        #region 设置MenuStrip不可用
        /// <summary>
        /// 设置MenuStrip不可用
        /// </summary>
        /// <param name="menuStrip">MenuStrip控件</param>
        public void SetMsDisable(MenuStrip menuStrip)
        {
            string power = "";
            DataTable dataTable = GetUserPower("root");//root用户拥有的所有权限
            for (int m = 0; m < dataTable.Rows.Count; m++)
            {
                power = dataTable.Rows[m][0].ToString();//权利名称
                for (int i = 0; i < menuStrip.Items.Count; i++)//遍历一级菜单项
                {
                    if (menuStrip.Items[i] is ToolStripMenuItem)//判断是否为菜单项
                    {
                        //保存菜单项
                        ToolStripMenuItem toolStripMenuItem1 = (ToolStripMenuItem)menuStrip.Items[i];
                        if (toolStripMenuItem1.Name.IndexOf(power) > -1&& toolStripMenuItem1.Name.IndexOf("menu")==-1)//权限对应功能
                        {
                            toolStripMenuItem1.Enabled = false;//关闭权限
                        }                            
                        for (int j = 0; j < toolStripMenuItem1.DropDownItems.Count; j++)//遍历二级菜单项
                        {
                            if (toolStripMenuItem1.DropDownItems[j] is ToolStripMenuItem)//判断是否为菜单项
                            {
                                //保存菜单项
                                ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem)toolStripMenuItem1.DropDownItems[j];
                                if (toolStripMenuItem2.Name.IndexOf(power) > -1 && toolStripMenuItem2.Name.IndexOf("menu") == -1)//权限对应功能
                                {
                                    toolStripMenuItem2.Enabled = false;//关闭权限
                                }                                    
                                for (int k = 0; k < toolStripMenuItem2.DropDownItems.Count; k++)//遍历三级菜单项
                                {
                                    if (toolStripMenuItem2.DropDownItems[k] is ToolStripMenuItem)//判断是否为菜单项
                                    {
                                        //保存菜单项
                                        ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem)toolStripMenuItem2.DropDownItems[k];
                                        if (toolStripMenuItem3.Name.IndexOf(power) >-1 && toolStripMenuItem3.Name.IndexOf("menu") == -1)//权限对应功能
                                        {
                                            toolStripMenuItem3.Enabled = false;//关闭权限
                                        }                                            
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        #endregion

        #region 根据权限设置MenuStrip
        /// <summary>
        /// 根据权限设置MenuStrip
        /// </summary>
        /// <param name="menuStrip">MenuStrip控件</param>
        public void SetMsEnable(MenuStrip menuStrip)
        {
            string power = "";
            DataTable dataTable = GetUserPower(loginID);//用户对应权限
            for(int m=0;m<dataTable.Rows.Count;m++)
            {
                power = dataTable.Rows[m][0].ToString();//权限名称
                for (int i = 0; i < menuStrip.Items.Count; i++)//遍历一级菜单项
                {
                    if (menuStrip.Items[i] is ToolStripMenuItem)//判断是否为菜单项
                    {
                        //保存菜单项
                        ToolStripMenuItem toolStripMenuItem1 = (ToolStripMenuItem)menuStrip.Items[i];
                        if (toolStripMenuItem1.Name.IndexOf(power)>-1)//权限对应功能
                        {
                            toolStripMenuItem1.Enabled = true;//赋予用户功能
                        }                           
                        for (int j = 0; j < toolStripMenuItem1.DropDownItems.Count; j++)//遍历二级菜单项
                        {
                            if (toolStripMenuItem1.DropDownItems[j] is ToolStripMenuItem)//判断是否为菜单项
                            {
                                //保存菜单项
                                ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem)toolStripMenuItem1.DropDownItems[j];
                                if (toolStripMenuItem2.Name.IndexOf(power) > -1)//权限对应功能
                                {
                                    toolStripMenuItem2.Enabled = true;//赋予用户功能
                                }                                  
                                for (int k = 0; k < toolStripMenuItem2.DropDownItems.Count; k++)//遍历三级菜单项
                                {
                                    if (toolStripMenuItem2.DropDownItems[k] is ToolStripMenuItem)//判断是否为菜单项
                                    {
                                        //保存菜单项
                                        ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem)toolStripMenuItem2.DropDownItems[k];
                                        if (toolStripMenuItem3.Name.IndexOf(power) >-1)//权限对应功能
                                        {
                                            toolStripMenuItem3.Enabled = true;//赋予用户功能
                                        }                                          
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        #endregion
        
        #region 清空控件集内容
        /// <summary>
        /// 清空控件集内容
        /// </summary>
        /// <param name="conCollection">可视化控件集合</param>
        public void ClearControl(Control.ControlCollection conCollection)
        {
            foreach (Control con in conCollection)//遍历控件集合
            {
                if (con is TextBox || con is MaskedTextBox)
                {
                    con.Text = "";//清空控件内容
                }
                else if(con is ComboBox)//选中第一项，清空控件文本内容
                {
                    ((ComboBox)con).SelectedIndex = -1;
                    con.Text = "";
                }
                else if (con is PictureBox)
                {
                    ((PictureBox)con).Image = null;//清空图片
                }
                else if(con is DateTimePicker)//显示当天日期
                {
                    con.Text = "";
                    ((DateTimePicker)con).Value=Convert.ToDateTime(System.DateTime.Now.ToString());
                }
            }
        }
        #endregion

        #region 设置控件集只读
        /// <summary>
        /// 设置控件集只读
        /// </summary>
        /// <param name="conCollection">可视化控件集合</param>
        public void SetControlReadOnly(Control.ControlCollection conCollection)
        {
            foreach (Control con in conCollection)//遍历控件集合
            {
                if (con is TextBox|| con is MaskedTextBox|| con is ComboBox || con is DateTimePicker|| con is Button)
                {
                        con.Enabled = false;//控件不可用
                }
            }
        }
        #endregion

        #region 设置控件集可编辑
        /// <summary>
        /// 设置控件集可编辑
        /// </summary>
        /// <param name="conCollection">可视化控件集合</param>
        public void SetControlWrite(Control.ControlCollection conCollection)
        {
            foreach (Control con in conCollection)//遍历控件集合
            {
                if (con is TextBox || con is MaskedTextBox || con is ComboBox || con is DateTimePicker || con is Button)
                {
                    con.Enabled = true;//控件启用
                }
            }
        }
        #endregion

        #region 隐藏TabControl部分页面
        /// <summary>
        /// 隐藏TabControl部分页面
        /// </summary>
        /// <param name="tabControl">TabControl控件</param>
        public void HideTab(TabControl tabControl)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.Name != tabControl.SelectedTab.Name)//页面为当前选中页
                {
                    tabPage.Parent = null;//隐藏页面
                }
            }
        }
        #endregion

        #region 设置MaskTextBox控件为日期格式
        /// <summary>
        /// 设置MaskTextBox控件为日期格式
        /// </summary>
        /// <param name="maskedTextBox">MaskTextBox控件</param>
        public void SetMtxData(MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Mask = "0000-00-00";//设置运行时使用的输入掩码
            maskedTextBox.ValidatingType = typeof(DateTime);//设置用于验证用户输入的数据的数据类型
        }
        #endregion

        #region 设置MaskTextBox控件为时间格式
        /// <summary>
        /// 设置MaskTextBox控件为时间格式
        /// </summary>
        /// <param name="maskedTextBox">MaskTextBox控件</param>
        public void SetMtxTime(MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Mask = "0000-00-00 00:00:00";//设置运行时使用的输入掩码
            maskedTextBox.ValidatingType = typeof(DateTime);//设置用于验证用户输入的数据的数据类型
        }
        #endregion

        #region 判断控件内容是否为时间格式
        /// <summary>
        /// 判断控件内容是否为时间格式
        /// </summary>
        /// <param name="maskedTextBox">MaskTextBox控件</param>
        /// <returns>控件内容是否为时间格式</returns>
        public bool IsDataTime(MaskedTextBox maskedTextBox)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(maskedTextBox.Text);//判断输入数据是否为时间格式
                return true;
            }
            catch
            {
                maskedTextBox.Text = "";//清空文本
                return false;
            }
        }           
        #endregion

        #region 设置DataGridView控件
        /// <summary>
        /// 设置DataGridView控件
        /// </summary>
        /// <param name="dataGridView">DataGridView控件</param>
        public void SetDgv(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;//禁止自动新增行
            dataGridView.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView.ReadOnly = true;//禁止单元格编辑
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//单击选中一行数据
            dataGridView.MultiSelect = false;//禁止多行选择
        }
        #endregion

        #region 显示DataGridView数据
        /// <summary>
        /// 显示DataGridView数据
        /// </summary>
        /// <param name="allField">所有字段</param>
        /// <param name="dataGridView">DataGridView控件</param>
        /// <param name="conCollection">数据对应控件集</param>
        /// <param name="prefix">控件名称前缀</param>
        public void ShowDgvData(string allField, DataGridView dataGridView, Control.ControlCollection conCollection,string prefix)
        {
            allField = allField.Trim();
            prefix = prefix.Trim(); 
            if (dataGridView.RowCount > 0)
            {
                string[] field = allField.Split(Convert.ToChar(','));//字段分解   

                for (int i =0; i < dataGridView.ColumnCount-1&&i<field.Length; i++)//遍历一行数据
                {  
                    //从第二个数据开始显示                  
                    string data = dataGridView[i+1, dataGridView.CurrentCell.RowIndex].Value.ToString();//选中行数据
                    foreach (Control con in conCollection)//遍历控件查找对应控件
                    {
                        if (con is TextBox && con.Name == (prefix+field[i]))//普通数据
                        {
                            con.Text = data;
                            break;
                        }
                        else if(con is ComboBox&&(con.Name + "Type") == ("no_" + field[i]))//种类控件
                        {
                            con.Text = data;
                            break;
                        }
                        //时间格式控件
                        else if (con is MaskedTextBox && con.Name == (prefix + field[i])&&con.Name.IndexOf("Time")>-1)
                        {
                            con.Text = FormatDataTime(data);//格式化数据为时间格式
                            break;
                        }
                        //日期格式控件
                        else if(con is MaskedTextBox && con.Name == (prefix + field[i]))
                        {
                            con.Text = FormatData(data);//格式化数据为日期格式
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region 设置Button控件状态
        #region 设置Button控件状态(4参数)
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="btn1">1号按钮</param>
        /// <param name="btn2">2号按钮</param>
        /// <param name="btn3">3号按钮</param>
        /// <param name="btn4">4号按钮</param>
        /// <param name="bl1">1号按钮状态</param>
        /// <param name="bl2">2号按钮状态</param>
        /// <param name="bl3">3号按钮状态</param>
        /// <param name="bl4">4号按钮状态</param>
        public void SetButton(Button btn1,Button btn2,Button btn3,Button btn4,bool bl1,bool bl2,bool bl3,bool bl4)
        {
            btn1.Enabled = bl1;//是否启用按钮
            btn2.Enabled = bl2;
            btn3.Enabled = bl3;
            btn4.Enabled = bl4;
        }
        #endregion

        #region 设置Button控件状态(5参数)
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="btn1">1号按钮</param>
        /// <param name="btn2">2号按钮</param>
        /// <param name="btn3">3号按钮</param>
        /// <param name="btn4">4号按钮</param>
        /// <param name="btn5">5号按钮</param>
        /// <param name="bl1">1号按钮状态</param>
        /// <param name="bl2">2号按钮状态</param>
        /// <param name="bl3">3号按钮状态</param>
        /// <param name="bl4">4号按钮状态</param>
        /// <param name="bl5">5号按钮状态</param>
        public void SetButton(Button btn1, Button btn2, Button btn3, Button btn4,Button btn5, bool bl1, bool bl2, bool bl3, bool bl4,bool bl5)
        {
            btn1.Enabled = bl1;//是否启用按钮
            btn2.Enabled = bl2;
            btn3.Enabled = bl3;
            btn4.Enabled = bl4;
            btn5.Enabled = bl5;
        }
        #endregion
        #endregion

        #region 显示用户权限
        /// <summary>
        /// 显示用户权限
        /// </summary>
        /// <param name="conCollection">权限控件集合</param>
        /// <param name="userID">用户ID</param>
        public void ShowPower(Control.ControlCollection conCollection,string userID)
        {
            userID = userID.Trim();
            string userPower = "";//用户权限
            foreach(Control con in conCollection)//清空控件选中状态
            {
                if (con is CheckBox)
                {
                    ((CheckBox)con).Checked = false;//所有CheckBox不选中
                }                    
            }
            DataTable dataTable = GetUserPower(userID);//用户权限表格
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                userPower = dataTable.Rows[i][0].ToString();//用户权限名称
                foreach(Control con in conCollection)//遍历控件
                {
                    if(con is CheckBox &&con.Name.IndexOf(userPower)>-1)//设置对应权限选中
                    {
                        ((CheckBox)con).Checked = true;
                    }
                }
            }
        }
        #endregion        

        #region 设置用户权限
        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="conCollection">权限控件集合</param>
        /// <param name="userID">用户ID</param>
        public void SetPower(Control.ControlCollection conCollection, string userID)
        {
            userID = userID.Trim();
            DeleteUserAllPower(userID);//清空用户拥有权限
            foreach (Control con in conCollection)//遍历权限控件
            {
                if (con is CheckBox)
                {
                    if (((CheckBox)con).Checked == true)//拥有此权限
                    {
                        string[] power = con.Name.Split(Convert.ToChar('_'));
                        AddUserPower(userID, power[1]);//赋予用户此权限
                    }
                }
            }
        }
        #endregion

        #region 限制输入整数
        /// <summary>
        /// 限制输入整数
        /// </summary>
        /// <param name="e">键盘输入事件</param>
        public void LimitIntKey(KeyPressEventArgs e)
        {
            //输入整数回车退格以外的字符
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;//设置输入无效
            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region 限制输入浮点数
        /// <summary>
        /// 限制输入浮点数
        /// </summary>
        /// <param name="e">键盘输入事件</param>
        /// <param name="str">已输入字符串</param>
        public void LimitFloatKey(KeyPressEventArgs e, string str)
        {
            str = str.Trim();
            //输入整数回车退格小数点以外的字符
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != '\r' && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;//设置输入无效
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    if (str == "")//已输入字符串为空，小数点不可做第一个字符
                        e.Handled = true;
                    else
                    {
                        if (str.IndexOf(".") > -1)//字符串中小数点已存在
                            e.Handled = true;
                    }
                }
            }

        }
        #endregion

        #region 限制输入字符
        /// <summary>
        /// 限制输入字符
        /// </summary>
        /// <param name="e">键盘输入事件</param>
        /// <param name="str">已输入字符串</param>
        /// <param name="length">限制长度</param>
        public void LimitCharKey(KeyPressEventArgs e, string str,int length)
        {
            str = str.Trim();
            //输入整数回车退格小数点以外的字符
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != '\r' && e.KeyChar != '\b' )
            {
                e.Handled = true;//设置输入无效
            }
            if(str.Length>=length)
            {
                e.Handled = true;//设置输入无效
            }
        }
        #endregion
        #endregion

        #region 功能函数
        #region 格式化日期yyyy-mm-dd
        /// <summary>
        /// 格式化日期yyyy-mm-dd
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>格式化日期</returns>
        public string FormatData(string date)
        {
            date = date.Trim();
            DateTime dateTime;
            try
            {
                dateTime = Convert.ToDateTime(date);//转换日期
            }
            catch
            {
                return "";
            }
            if (dateTime.Year == 1900) return "";
            //格式化日期
            return string.Format("{0:0000}-{1:00}-{2:00}", dateTime.Year, dateTime.Month, dateTime.Day);
        }
        #endregion

        #region 格式化时间hh:mm:ss
        /// <summary>
        /// 格式化时间hh:mm:ss
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>格式化时间</returns>
        public string FormatTime1(string time)
        {
            time = time.Trim();
            DateTime dateTime;
            try
            {
                dateTime = Convert.ToDateTime(time);//转换时间
            }
            catch
            {
                return "";
            }
            //格式化时间
            return string.Format("{0:00}:{1:00}:{2:00}", dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
        #endregion

        #region 格式化时间hh-mm-ss
        /// <summary>
        /// 格式化时间hh-mm-ss
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>格式化时间</returns>
        public string FormatTime2(string time)
        {
            time = time.Trim();
            DateTime dateTime;
            try
            {
                dateTime = Convert.ToDateTime(time);//转换时间
            }
            catch
            {
                return "";
            }
            //格式化时间
            return string.Format("{0:00}-{1:00}-{2:00}", dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
        #endregion

        #region 格式化DataTime格式yyyy-mm-dd hh:mm:ss
        /// <summary>
        /// 格式化DataTime格式yyyy-mm-dd hh:mm:ss
        /// </summary>
        /// <param name="strDataTime">DataTime字符串</param>
        /// <returns>格式化DataTime</returns>
        public string FormatDataTime(string strDataTime)
        {
            strDataTime = strDataTime.Trim();
            string data = FormatData(strDataTime);//格式化日期
            string time = FormatTime1(strDataTime);//格式化时间      
            if (data != "" && time != "")//组合格式化dataTime
            {
                return data + " " + time;
            }
            else
            {
                return data + time;
            }
        }
        #endregion
        #endregion

        #region 操作数据库
        #region 获得职工信息表
        /// <summary>
        /// 获得职工信息表
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns>职工信息表数据</returns>
        public DataSet GetStaffData(string condition)
        {
            condition = condition.Trim();
            DataSet dataSet = new DataSet();
            string field = "tb_Staff.ID 职工编号,tb_Staff.StaffName 姓名,tb_SexType.Sex 性别," +
                "tb_Staff.Birthday 出生日期,tb_NationType.Nation 民族,tb_EducationType.Education 教育," +
                "tb_PoliticalStatusType.PoliticalStatus 政治面貌,tb_MarriageType.Marriage 婚姻," +
                "tb_Staff.IDCard 身份证号,tb_NativePlace.Province 籍贯省,tb_NativePlace.City 籍贯市," +
                "tb_Staff.HomeAddress 家庭住址,tb_Staff.Phone 联系电话,tb_Staff.School 毕业学校," +
                "tb_Staff.Major 专业,tb_Staff.GraduateDate 毕业时间,tb_StaffType.Staff 职工类型," +
                "tb_DepartmentType.Department 部门,tb_PositionType.Position 职务," +
                "tb_TitleType.Title 职称,tb_SalaryType.Salary 工资类别,tb_Staff.Salary 工资," +
                "tb_Staff.BankCard 银行卡号,tb_Staff.WorkDate 工作时间,tb_Staff.ContractB 合同开始时间," +
                "tb_Staff.ContractE 合同结束时间,tb_Staff.ContractY 合同年限";
            string tableName = "tb_Staff LEFT JOIN tb_SexType " +
                    "ON tb_Staff.SexType=tb_SexType.TNO " +
                    " LEFT JOIN tb_NationType " +
                    "ON tb_Staff.NationType=tb_NationType.TNO " +
                    " LEFT JOIN tb_EducationType " +
                    "ON tb_Staff.EducationType=tb_EducationType.TNO " +
                    " LEFT JOIN tb_PoliticalStatusType " +
                    "ON tb_Staff.PoliticalStatusType=tb_PoliticalStatusType.TNO " +
                    " LEFT JOIN tb_MarriageType " +
                    "ON tb_Staff.MarriageType=tb_MarriageType.TNO " +
                    " LEFT JOIN tb_NativePlace " +
                    "ON tb_Staff.NativePlace=tb_NativePlace.TNO " +
                    " LEFT JOIN tb_StaffType " +
                    "ON tb_Staff.StaffType=tb_StaffType.TNO " +
                    " LEFT JOIN tb_DepartmentType " +
                    "ON tb_Staff.DepartmentType=tb_DepartmentType.TNO " +
                    " LEFT JOIN tb_PositionType " +
                    "ON tb_Staff.PositionType=tb_PositionType.TNO " +
                    " LEFT JOIN tb_TitleType " +
                    "ON tb_Staff.TitleType=tb_TitleType.TNO " +
                    " LEFT JOIN tb_SalaryType " +
                    "ON tb_Staff.SalaryType=tb_SalaryType.TNO ";
            if (condition == "")//无条件
            {
                //获得职工信息表内容
                dataSet = myDataClass.GetDataSet(field, tableName);
            }
            else
            {
                //获得职工信息表内容
                dataSet = myDataClass.GetDataSet(field, tableName, condition);
            }
            return dataSet;
        }
        #endregion

        #region 获得指定职工图片
        /// <summary>
        /// 获得指定职工图片
        /// </summary>
        /// <param name="id">职工ID</param>
        /// <returns>职工图片数组</returns>
        public byte[] GetStaffPhoto(string id)
        {
            id = id.Trim();
            //查找图片数据
            DataTable dataTable = myDataClass.SelectData("Photo", "tb_Staff", "ID='" + id + "'");
            byte[] photo = (byte[])dataTable.Rows[0][0];//将图片转换为二进制数组        
            return photo;
        }
        #endregion

        #region 更新籍贯信息
        /// <summary>
        /// 更新籍贯信息
        /// </summary>
        /// <param name="province">籍贯省</param>
        /// <param name="city">籍贯市</param>
        /// <param name="id">职工ID</param>
        public void UpdateNativePlace(string province, string city, string id)
        {
            province = province.Trim();
            city = city.Trim();
            id = id.Trim();
            //查找籍贯编号
            DataTable dataTable = myDataClass.SelectData("TNO", "tb_NativePlace", "Province='" + province + "' AND City='" + city + "'");
            if (dataTable.Rows.Count > 0)
            {
                int TNO = (int)dataTable.Rows[0][0];//籍贯编号
                myDataClass.ExecuteUpdateSql("tb_Staff", "NativePlace=" + TNO, "ID='" + id + "'");//更新籍贯
            }
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">登录名称</param>
        /// <param name="password">登录密码</param>
        /// <returns>账号密码是否正确</returns>
        public bool UserLogin(string name, string password)
        {
            name = name.Trim();
            password = password.Trim();
            //是否存在对应账号密码
            bool bl = myDataClass.IsExistData("*", "tb_Login", "UserID='" + name + "' AND UserPassword='" + password + "'");
            return bl;
        }
        #endregion

        #region 得到字段新编号
        /// <summary>
        ///得到字段新编号
        /// </summary>
        /// <param name="tableName">表单名</param>
        /// <param name="NOField">编号字段名</param>
        /// <returns>字段新编号</returns>
        public int GetAutoNO(string tableName, string NOField)
        {
            tableName = tableName.Trim();
            NOField = NOField.Trim();
            int autoNO = 0;//存储编号
            if (myDataClass.IsExistData(tableName) == true)//表格不为空
            {
                DataTable dataTable = myDataClass.SelectData("MAX(" + NOField + ")", tableName);//查找当前最大编号
                if (dataTable.Rows.Count != 0)
                {
                    autoNO = (int)dataTable.Rows[0][0];//记录当前最大编号
                    autoNO++;//得到新编号
                }
            }
            return autoNO;
        }
        #endregion

        #region 获得新员工ID
        /// <summary>
        /// 获得新员工ID
        /// </summary>
        /// <returns>新员工ID</returns>
        public string GetAutoID()
        {
            int autoID = 0;
            if (myDataClass.IsExistData("tb_Staff") == true)//表格不为空
            {
                DataTable dataTable = myDataClass.SelectData("MAX(ID)", "tb_Staff");//查找当前最大ID
                if (dataTable.Rows.Count != 0)
                {
                    autoID = Convert.ToInt32(dataTable.Rows[0][0].ToString());//记录当前最大ID
                    autoID++;//得到ID
                }
            }
            return string.Format("{0:00000}", autoID);//格式化ID
        }
        #endregion

        #region 提示信息
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="cueKind">提示种类</param>
        public void MessageCue(int cueKind)
        {
            //查找提示天数
            DataTable dataTable = myDataClass.SelectData("CueDate", "tb_MessageCue", "CueKind = " + cueKind + " AND CueUnlock = 1");
            if (dataTable.Rows.Count > 0)
            {
                int date = (int)dataTable.Rows[0][0];//提示天数
                string strCondition = "";//存储查找条件
                if (cueKind == 1)
                {
                    //查找过生日的职工信息
                    strCondition = "DATEDIFF(DAY,GETDATE(),CONVERT(NVARCHAR(12),CAST(CAST(YEAR(GETDATE()) AS CHAR(4))+'-'+CAST(MONTH(Birthday) AS CHAR(2))+'-'+CAST(DAY(Birthday) AS CHAR(2)) AS DATETIME),110))>=0 AND" +
                        " DATEDIFF(DAY,GETDATE(),CONVERT(NVARCHAR(12),CAST(CAST(YEAR(GETDATE()) AS CHAR(4))+'-'+CAST(MONTH(Birthday) AS CHAR(2))+'-'+CAST(DAY(Birthday) AS CHAR(2)) AS DATETIME),110))<= " + date;
                }
                else
                {
                    //查找合同到期的职工信息
                    strCondition = "(CONVERT(NVARCHAR(12),ContractE,110)-GETDATE())>=0 AND" +
                        " (CONVERT(NVARCHAR(12),ContractE,110)-GETDATE())<=" + date;
                }
                //是否存在对应
                bool bl = myDataClass.IsExistData("*", "tb_Staff", strCondition);
                if (bl == true)//存在信息
                {
                    string str = "是否查看" + date.ToString() + "天内";
                    if (cueKind == 1)
                    {
                        str = str + "过生日的职工信息";
                    }
                    else
                    {
                        str = str + "合同到期的职工信息";
                    }
                    //提示是否查看信息
                    if (MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Sql = strSql;//传递查询语句
                        ShowForm("人事档案管理");//显示窗体
                    }
                }
            }
        }
        #endregion

        #region 获得用户拥有权限
        /// <summary>
        /// 获得用户拥有权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>权限列表</returns>
        private DataTable GetUserPower(string userID)
        {
            userID = userID.Trim();
            //查找用户拥有权限
            DataTable dataTable = myDataClass.SelectData("Power", "tb_PowerType,tb_UserPower", "TNO=PowerType AND UserID='" + userID + "';");
            return dataTable;
        }
        #endregion

        #region 添加用户权限
        /// <summary>
        /// 添加用户权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="power">权限名称</param>
        private void AddUserPower(string userID, string power)
        {
            userID = userID.Trim();
            power = power.Trim();
            //插入用户权限
            myDataClass.ExecuteInsertSql("tb_UserPower", "UserID,PowerType", "'" + userID + "',(SELECT TNO FROM tb_PowerType WHERE Power='" + power + "')");
        }
        #endregion

        #region  删除用户所有权限
        /// <summary>
        /// 删除用户所有权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        private void DeleteUserAllPower(string userID)
        {
            userID = userID.Trim();
            //删除用户所有权限
            myDataClass.ExecuteDeleteSql("tb_UserPower", "UserID = '" + userID + "'; ");
        }
        #endregion

        #region 清空数据库表
        /// <summary>
        /// 清空数据库表
        /// </summary>
        /// <param name="conCollection">控件集合</param>
        public void ClearDataBase(Control.ControlCollection conCollection)
        {
            foreach (Control con in conCollection)//遍历控件
            {
                string conName = con.Name;//控件名称
                string tableName = "";//表名称               
                if (con is CheckBox)
                {
                    if (conName.IndexOf("chk_") == 0 && ((CheckBox)con).Checked == true)//是对应控件
                    {
                        string[] str = conName.Split(Convert.ToChar('_'));//分解控件名
                        tableName = "tb_" + str[1];//组成要删除表的名称
                        if (str[1].ToUpper() == "MessageCue".ToUpper())//提示信息表
                        {
                            myDataClass.ExecuteUpdateSql(tableName, "CueDate=0,CueUnlock=0");//更新提示信息表
                        }
                        else
                        {
                            myDataClass.ExecuteDeleteSql(tableName);//删除相应表内容
                        }
                    }
                }
            }
        }
        #endregion

        #region 保存图片到数据库
        /// <summary>
        /// 保存图片到数据库
        /// </summary>
        /// <param name="id">职员ID</param>
        /// <param name="image">图片数组</param>
        public void SaveImage(string id, byte[] image)
        {
            id = id.Trim();
            SqlConnection sqlConnection = myDataClass.OpenSqlConnection();//打开连接
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Staff SET Photo=@Photo WHERE ID='" + id + "';");//组成sql语句
            SqlCommand sqlCommand = new SqlCommand(strSql.ToString(), sqlConnection);
            sqlCommand.Parameters.Add("@Photo", SqlDbType.Binary).Value = image;
            sqlCommand.ExecuteNonQuery();//添加图片信息
            myDataClass.CloseSqlConnection(sqlConnection);//关闭连接
        }
        #endregion

        #region 获得SQL更新字段值
        /// <summary>
        /// 获得SQL更新字段值
        /// </summary>
        /// <param name="conCollection">Control集合</param>
        /// <param name="prefix">控件前缀</param>
        /// <returns>更新内容</returns>
        public string GetUpdateFieldValue(Control.ControlCollection conCollection, string prefix)
        {
            prefix = prefix.Trim();
            string strFieldValue = "";//存储更新内容
            foreach (Control con in conCollection)//遍历控件
            {
                if (con.Name == "no_Province" || con.Name == "no_City")//籍贯控件
                {
                    continue;
                }
                //存储类型的控件
                if (con.Name.IndexOf("no_") > -1 && con is ComboBox)
                {
                    string[] field = con.Name.Split(Convert.ToChar('_'));//字段分解
                    string conText = con.Text.Trim();
                    if (conText == "")//组合值
                    {
                        strFieldValue += field[1] + "Type=NULL,";
                    }
                    else
                    {
                        //查找对应编号
                        DataTable dataTable = myDataClass.SelectData("TNO", "tb_" + field[1] + "Type", field[1] + "='" + conText + "'");
                        if (dataTable.Rows.Count > 0)
                        {
                            //编号内容组成语句
                            strFieldValue += field[1] + "Type=" + (int)dataTable.Rows[0][0] + ",";
                        }
                    }
                }
                //存储普通数据的控件
                else if (con.Name.IndexOf(prefix) > -1 && (con is ComboBox || con is TextBox || con is MaskedTextBox || con is DateTimePicker))
                {
                    string[] field = con.Name.Split(Convert.ToChar('_'));//字段分解
                    string conText;
                    if (con is MaskedTextBox&&con.Name.IndexOf("Time")>-1)//控件内容保存
                    {
                        conText = FormatDataTime(con.Text);//格式化时间格式
                    }
                    else if (con is MaskedTextBox)//控件内容保存
                    {
                        conText = FormatData(con.Text);//格式化日期格式
                    }
                    else if (con is DateTimePicker)
                    {
                        conText = FormatData(((DateTimePicker)con).Value.ToString());//格式化日期格式
                    }
                    else
                    {
                        conText = con.Text.Trim();
                    }
                    if (conText == "")//组合值
                    {
                        strFieldValue += field[1] + "=NULL,";
                    }
                    else
                    {
                        strFieldValue += field[1] + "='" + conText + "',";
                    }
                }
            }
            //去掉最后一个逗号
            strFieldValue = strFieldValue.Substring(0, strFieldValue.Length - 1);
            return strFieldValue;
        }
        #endregion        

        #region 获得SQL插入值
        /// <summary>
        /// 获得SQL插入值
        /// </summary>
        /// <param name="allField">数据表所有字段</param>
        /// <param name="conCollection">Control集合</param>
        /// <param name="prefix">控件前缀</param>
        /// <returns>SQL插入值</returns>
        public string GetInsertValue(string allField, Control.ControlCollection conCollection, string prefix)
        {
            prefix = prefix.Trim();
            string strValue = "";//存储插入的值
            string[] field = allField.Split(Convert.ToChar(','));//字段分解
            for (int i = 0; i < field.Length; i++)//遍历字段数据
            {
                foreach (Control con in conCollection)//遍历控件
                {
                    //存储类型的控件
                    if ((con.Name + "Type") == ("no_" + field[i]) && con is ComboBox)
                    {
                        string strField = field[i].Substring(0, field[i].Length - 4);//去掉Type字符
                        string conText = con.Text.Trim();
                        if (conText == "")//组合值
                        {
                            strValue += "NULL,";
                        }
                        else
                        {
                            //查找对应编号
                            DataTable dataTable = myDataClass.SelectData("TNO", "tb_" + field[i], strField + "='" + conText + "'");
                            if (dataTable.Rows.Count > 0)
                            {
                                //编号组成值
                                strValue += (int)dataTable.Rows[0][0] + ",";
                            }
                        }
                    }
                    //存储普通数据的控件
                    else if (con.Name == (prefix + field[i]) && (con is TextBox || con is ComboBox || con is MaskedTextBox || con is DateTimePicker))
                    {
                        string conText;
                        if (con is MaskedTextBox && con.Name.IndexOf("Time") > -1)//控件内容保存
                        {
                            conText = FormatDataTime(con.Text);//格式化时间格式
                        }
                        else if (con is MaskedTextBox)//控件内容保存
                        {
                            conText = FormatData(con.Text);//格式化日期格式
                        }
                        else if (con is DateTimePicker)
                        {
                            conText = FormatData(((DateTimePicker)con).Value.ToString());//格式化日期格式
                        }
                        else
                        {
                            conText = con.Text.Trim();
                        }
                        if (conText == "")//组合值
                        {
                            strValue += "NULL,";
                        }
                        else
                        {
                            strValue += "'" + conText + "',";
                        }
                        break;
                    }
                }
            }
            //去掉最后一个逗号
            strValue = strValue.Substring(0, strValue.Length - 1);
            return strValue;
        }
        #endregion

        #region 获得SQL查询条件
        /// <summary>
        /// 获得SQL查询条件
        /// </summary>
        /// <param name="conCollection">Control控件集合</param>
        /// <param name="logic">逻辑运算</param>
        /// <param name="strSql">查询条件语句</param>
        /// <returns>查询条件</returns>
        public string GetSelectCondition(Control.ControlCollection conCollection, string logic, string strSql)
        {
            logic = logic.Trim();
            strSql = strSql.Trim();
            if (strSql.Length > 0)
            {
                strSql += logic;//加上逻辑符号
            }
            foreach (Control con1 in conCollection)//遍历控件
            {
                string[] field = con1.Name.Split(Convert.ToChar('_')); //分解控件名称，找出字段名称 
                //省市数据控件
                if (con1 is ComboBox && (con1.Name.IndexOf("no_Province") == 0 || con1.Name.IndexOf("no_City") == 0) && con1.Text.Trim() != "")
                {
                    strSql += " (tb_NativePlace." + field[1] + "='" + con1.Text.Trim() + "') " + logic;
                }
                //类别数据控件        
                else if (con1 is ComboBox && con1.Name.IndexOf("no_") == 0 && con1.Text.Trim() != "")
                {
                    strSql += " (tb_" + field[1] + "Type." + field[1] + "='" + con1.Text.Trim() + "') " + logic;
                }
                //普通数据控件
                else if (con1 is ComboBox && con1.Name.IndexOf("da_") == 0 && con1.Text.Trim() != "")
                {
                    strSql += " (tb_Staff." + field[1] + "='" + con1.Text.Trim() + "') " + logic;
                }
                //出生年控件
                else if (con1 is ComboBox && con1.Name.IndexOf("sign_Birthday") == 0 && con1.Text.Trim() != "")
                {
                    foreach (Control con2 in conCollection)//遍历控件，寻找ComboBox控件对应的TextBox控件
                    {
                        if (con2 is TextBox && con2.Name.IndexOf(field[1]) == 0)//存储出生年数据的控件
                        {
                            if (con2.Text.Trim() != "")
                            {
                                strSql += " (CAST(YEAR(tb_Staff." + field[1] + ") AS CHAR(4))" + con1.Text.Trim() + "'" + con2.Text.Trim() + "') " + logic;//添加条件
                            }
                            break;
                        }
                    }
                }
                //符号数据控件
                else if (con1 is ComboBox && con1.Name.IndexOf("sign_") == 0 && con1.Text.Trim() != "")
                {
                    foreach (Control con2 in conCollection)//遍历控件，寻找ComboBox控件对应的TextBox控件
                    {
                        if (con2 is TextBox && con2.Name.IndexOf(field[1]) == 0)//存储对应符号数据的控件
                        {
                            if (con2.Text.Trim() != "")
                            {
                                strSql += " (tb_Staff." + field[1] + con1.Text.Trim() + "'" + con2.Text.Trim() + "') " + logic;//添加条件
                            }
                            break;
                        }
                    }
                }
                //日期控件
                else if (con1 is MaskedTextBox && this.FormatData(con1.Text) != "")
                {
                    if (con1.Name == "mtx_Start")//开始日期控件
                    {
                        strSql += " (tb_Staff.WorkDate" + ">'" + con1.Text.Trim() + "') " + logic;
                    }
                    else if (con1.Name == "mtx_End")//结束日期控件
                    {
                        strSql += " (tb_Staff.WorkDate" + "<'" + con1.Text.Trim() + "') " + logic;
                    }
                }
            }
            if (strSql.Length > 0)//去除条件语句最后的逻辑运算符
            {
                if (logic.ToUpper() == "AND")
                {
                    strSql = strSql.Substring(0, strSql.Length - 3);
                }
                else if (logic.ToUpper() == "OR")
                {
                    strSql = strSql.Substring(0, strSql.Length - 2);
                }
            }
            return strSql;
        }
        #endregion

        #region 设置城市数据
        /// <summary>
        /// 设置城市数据
        /// </summary>
        /// <param name="comboBox">ComboBox控件</param>
        /// <param name="province">省份</param>
        public void SetCityData(ComboBox comboBox, string province)
        {
            province = province.Trim();
            comboBox.Items.Clear();//清空ComboBox
            //省对应城市数据
            DataTable dataTable = myDataClass.SelectData("City", "tb_NativePlace", "Province='" + province + "'");//查找要填充的数据
            if (dataTable.Columns.Count < 1) return;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox.Items.Add(dataTable.Rows[i][0].ToString());//添加数据
            }
        }
        #endregion

        #region 设置ComboBox控件数据
        /// <summary>
        /// 设置ComboBox控件数据
        /// </summary>
        /// <param name="comboBox">ComboBox控件</param>
        /// <param name="tableName">数据表</param>
        /// <param name="field">对应字段</param>
        public void SetCmbData(ComboBox comboBox, string tableName, string field)
        {
            tableName = tableName.Trim();
            comboBox.Items.Clear();//清空ComboBox
            DataTable dataTable = myDataClass.SelectData("DISTINCT " + field, tableName);//查找要填充的数据
            if (dataTable.Columns.Count < 1) return;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox.Items.Add(dataTable.Rows[i][0].ToString());//添加数据
            }
        }
        #endregion

        #region 设置控件集ComboBox数据
        /// <summary>
        /// 设置控件集ComboBox数据
        /// </summary>
        /// <param name="conCollection">控件集</param>
        /// <param name="prefix">控件前缀</param>
        public void SetControlsData(Control.ControlCollection conCollection, string prefix)
        {
            prefix = prefix.Trim();
            foreach (Control con in conCollection)
            {
                if (con is ComboBox && con.Name.IndexOf(prefix) == 0)//普通下拉框
                {
                    string[] field = con.Name.Split(Convert.ToChar('_'));//字段分解
                    if (field[1] == "Province")//省数据
                    {
                        SetCmbData((ComboBox)con, "tb_NativePlace", field[1]);//设置控件数据
                    }
                    else if (field[1] == "City")//不设置城市数据
                    {
                        continue;
                    }
                    else
                    {
                        SetCmbData((ComboBox)con, "tb_" + field[1] + "Type", field[1]);//设置控件数据
                    }
                }
                else if (con is ComboBox && con.Name.IndexOf("sign_") == 0)//符号控件
                {
                    //填充符号
                    ((ComboBox)con).Items.Add(">");
                    ((ComboBox)con).Items.Add(">=");
                    ((ComboBox)con).Items.Add("=");
                    ((ComboBox)con).Items.Add("<=");
                    ((ComboBox)con).Items.Add("<");
                    ((ComboBox)con).Items.Add("!=");
                }
            }
        }
        #endregion
        #endregion

    }
}
