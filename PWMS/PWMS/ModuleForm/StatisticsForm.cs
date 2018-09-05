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
    /// 人事资料统计窗体
    /// </summary>
    public partial class StatisticsForm : Form
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

        #region StatisticsForm构造函数
        /// <summary>
        /// StatisticsForm构造函数
        /// </summary>
        public StatisticsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region StatisticsForm加载事件
        /// <summary>
        /// StatisticsForm加载事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            myFunctionClass.SetDgv(dgvData);//设置dgvData属性
            dgvData.RowHeadersVisible = false;//不显示第一列空白栏
            lstCondition.Items.Clear();//清空项
            string[] strField = { "年龄", "工龄", "毕业学校", "专业", "合同年限", "性别", "民族", "教育水平", "政治面貌", "婚姻", "部门", "职务", "职称", "职工类型", "工资类别", "籍贯所在省", "籍贯所在市" };
            foreach (string str in strField)//添加项
            {
                lstCondition.Items.Add("按" + str + "统计");
            }
            lstCondition.SelectedIndex = 0;//选中第一项
        }
        #endregion

        #region  lstConditon选择改变事件
        /// <summary>
        /// lstConditon选择改变事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">事件</param>
        private void lstCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strField = "";
            string strSql = "";
            switch (lstCondition.SelectedItem.ToString())//得到选中项对应字段
            {
                case "按年龄统计":  strField = "Birthday"; break;
                case "按工龄统计": strField = "WorkDate"; break;
                case "按毕业学校统计": strField = "School"; break;
                case "按专业统计": strField = "Major"; break;
                case "按合同年限统计": strField = "ContractY"; break;
                case "按性别统计": strField = "Sex"; break;
                case "按民族统计": strField = "Nation"; break;
                case "按教育水平统计": strField = "Education"; break;
                case "按政治面貌统计": strField = "PoliticalStatus"; break;
                case "按婚姻统计": strField = "Marriage"; break;
                case "按部门统计": strField = "Department"; break;
                case "按职务统计": strField = "Position"; break;
                case "按职称统计": strField = "Title"; break;
                case "按职工类型统计": strField = "Staff"; break;
                case "按工资类别统计": strField = "Salary"; break;
                case "按籍贯所在省统计": strField = "Province"; break;
                case "按籍贯所在市统计": strField = "City"; break;
                default: strField = "";break;
            }
            
            switch (strField)//组成sql语句
            {
                case "Birthday": 
                case "WorkDate":
                    strSql = "SELECT DATEDIFF(yy," + strField + ",GETDATE()) AS " + lstCondition.SelectedItem.ToString() + ",COUNT(DATEDIFF(yy," + strField + ",GETDATE())) AS 数量 " +
                        "FROM tb_Staff  "+
                        "GROUP BY DATEDIFF(yy," + strField + ",GETDATE())";
                    break;
                case "School":
                case "Major":
                case "ContractY":
                    strSql = "SELECT " + strField + " AS " + lstCondition.SelectedItem.ToString() + ",COUNT(" + strField + ") AS 数量 "+
                        "FROM tb_Staff "+
                        " GROUP BY " + strField;
                    break;
                case "Sex": 
                case "Nation": 
                case "Education": 
                case "PoliticalStatus": 
                case "Marriage": 
                case "Department": 
                case "Position": 
                case "Title":
                case "Staff": 
                case "Salary":
                    strSql = "SELECT tb_" + strField + "Type." + strField + " AS " + lstCondition.SelectedItem.ToString() + ",COUNT(tb_" + strField + "Type." + strField + ") AS 数量 "+
                        "FROM tb_Staff,tb_" + strField + "Type "+
                        "WHERE tb_Staff." + strField + "Type=TNO "+
                        "GROUP BY tb_" + strField + "Type." + strField;
                    break;
                case "Province": 
                case "City":
                    strSql = "SELECT " + strField + " AS " + lstCondition.SelectedItem.ToString() + ",COUNT(" + strField + ") AS 数量 " +
                        "FROM tb_Staff,tb_NativePlace WHERE NativePlace=TNO " + 
                        "GROUP BY " + strField;

                    break;
                default: break;
            }
            try
            {
                if (strSql!="")
                {
                    DataSet dataSet = myDataClass.GetDataSet(strSql);//执行SQL语句
                    dgvData.DataSource = dataSet.Tables[0];//显示数据
                }
            }
            catch
            {
                MessageBox.Show("显示数据过程出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
