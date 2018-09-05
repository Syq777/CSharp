using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PWMS.DataClass
{
    class MyData
    {

        #region 私有函数
        #region 获得SqlDataReader对象
        /// <summary>
        /// 获得SqlDataReader对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>SqlDataReader对象</returns>
        private SqlDataReader GetSqlDataReader(string strSql)
        {
            strSql = strSql.Trim();
            SqlConnection sqlCon = OpenSqlConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();
            sqlCom.CommandText = strSql;
            SqlDataReader sqlDataRe = sqlCom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlDataRe;
        }
        #endregion

        #region 获得DataTable对象
        /// <summary>
        /// 获得DataTable对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>DataTable对象</returns>
        private DataTable GetDataTable(string strSql)
        {
            strSql = strSql.Trim();
            SqlDataReader sqlDataRe = GetSqlDataReader(strSql);//SqlDataReader对象
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataRe);//填充dataTable
            sqlDataRe.Close();//关闭对象
            return dataTable;
        }
        #endregion

        #region 执行SqlCommand命令
        ///<summary>
        ///执行SqlCommand命令
        ///</summary>
        ///<param name="strSql">SQL语句</param>
        private void ExecuteSqlCommand(string strSql)
        {
            strSql = strSql.Trim();
            SqlConnection sqlCon = OpenSqlConnection();//打开数据库连接
            SqlCommand sqlCom = new SqlCommand(strSql, sqlCon);
            sqlCom.ExecuteNonQuery();//执行SqlCommand
            sqlCom.Dispose();//关闭对象
            CloseSqlConnection(sqlCon);//关闭连接
        }
        #endregion
        #endregion

        #region 数据库连接
        ///<summary>
        ///数据库连接 
        ///</summary>
        ///<retrurns>SqlConnection对象</retrurns>
        public SqlConnection OpenSqlConnection()
        {
            //string sqlConStr = "Data Source=.;Database=db_PWMS;User id=sa;PWD=2012;Connect Timeout=3";//数据库连接语句
            string sqlConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=db_PWMS;Trusted_Connection=Yes;Connect Timeout=3";//数据库连接语句
            SqlConnection sqlCon = new SqlConnection(sqlConStr);//SqlConnection对象
            sqlCon.Open();//数据库连接打开
            return sqlCon;
        }
        #endregion

        #region 数据库关闭
        /// <summary>
        ///数据库关闭
        /// </summary>
        /// <param name="sqlCon">SqlConnection对象</param>
        public void CloseSqlConnection(SqlConnection sqlCon)
        {
            if (sqlCon.State == ConnectionState.Open)//数据库为打开状态
            {
                sqlCon.Close();//数据关闭
            }
        }
        #endregion

        #region 获得DataSet对象
        #region 获得DataSet对象(纯SQL语句)
        /// <summary>
        /// 获得DataSet对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>DataSet对象</returns>
        public DataSet GetDataSet(string strSql)
        {
            strSql = strSql.Trim();
            SqlConnection sqlCon = OpenSqlConnection();//打开数据库连接
            SqlDataAdapter sqlDataAd = new SqlDataAdapter(strSql, sqlCon);
            DataSet dataSet = new DataSet();
            sqlDataAd.Fill(dataSet);//填充DataSet
            CloseSqlConnection(sqlCon);//关闭连接
            return dataSet;
        }
        #endregion

        #region 获得DataSet对象(无条件)
        /// <summary>
        /// 获得DataSet对象
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strField">字段</param>
        /// <returns>DataSet对象</returns>
        public DataSet GetDataSet(string strField,string tableName)
        {
            strField= strField.Trim();
            tableName= tableName.Trim();           
            //组成无条件的查询语句并生成DataSet
            DataSet dataSet = GetDataSet("SELECT " + strField + " FROM " + tableName + ";");
            return dataSet;
        }
        #endregion

        #region 获得DataSet对象(条件)
        /// <summary>
        /// 获得DataSet对象
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strField">字段</param>
        /// <param name="condition">条件</param>
        /// <returns>DataSet对象</returns>
        public DataSet GetDataSet(string strField, string tableName,  string condition)
        {
            strField= strField.Trim();
            tableName= tableName.Trim();
            condition= condition.Trim();
            //组成有条件的查询语句并生成DataSet
            DataSet dataSet = GetDataSet("SELECT " + strField + " FROM " + tableName + " WHERE " + condition + ";");
            return dataSet;
        }
        #endregion
        #endregion

        #region 判断是否存在数据
        #region 判断是否存在数据(无条件)
        /// <summary>
        /// 判断是否存在数据
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <returns>是否存在数据</returns>
        public bool IsExistData(string tableName)
        {
            tableName = tableName.Trim();
            //SqlDataReader对象
            SqlDataReader sqlDataRe = GetSqlDataReader("SELECT * FROM " + tableName + ";");
            bool bl= sqlDataRe.HasRows;//是否存在数据
            sqlDataRe.Close();//关闭对象
            return bl;               
        }
        #endregion

        #region 判断是否存在数据(有条件)
        /// <summary>
        /// 判断是否存在数据
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strField">字段</param>
        /// <param name="condition">条件</param>
        /// <returns>是否存在数据</returns>
        public bool IsExistData(string strField,string tableName, string condition)
        {
            strField= strField.Trim();
            tableName= tableName.Trim();
            condition= condition.Trim();
            //SqlDataReader对象
            SqlDataReader sqlDataRe = GetSqlDataReader("SELECT " + strField + " FROM " + tableName + " WHERE " + condition + ";");
            bool bl = sqlDataRe.HasRows;//是否存在数据
            sqlDataRe.Close();//关闭对象
            return bl;
        }
        #endregion
        #endregion

        #region 执行SQL查找语句
        #region 查找数据(无条件)
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strField">字段</param>
        /// <returns>数据表</returns>
        public DataTable SelectData(string strField,string tableName )
        {
            tableName = tableName.Trim();
            strField = strField.Trim();
            //执行查询语句生成DataTable
            DataTable dataTable = GetDataTable("SELECT " + strField + " FROM " + tableName + ";");
            return dataTable;
        }
        #endregion

        #region 查找数据(有条件)
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strField">字段</param>
        /// <param name="condition">条件</param>
        /// <returns>数据表</returns>
        public DataTable SelectData(string strField,string tableName , string condition)
        {
            tableName = tableName.Trim();
            strField = strField.Trim();
            condition = condition.Trim();
            //执行查询语句生成DataTable
            DataTable dataTable = GetDataTable("SELECT " + strField + " FROM " + tableName + " WHERE " + condition + ";");
            return dataTable;
        }
        #endregion
        #endregion

        #region 执行SQL插入语句
        /// <summary>
        /// 执行SQL插入语句
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strField">字段</param>
        /// <param name="strValue">值</param>
        public void ExecuteInsertSql(string tableName, string strField, string strValue)
        {
            tableName = tableName.Trim();
            strField = strField.Trim();
            strValue = strValue.Trim();
            //执行插入语句
            ExecuteSqlCommand("INSERT INTO " + tableName + "(" + strField + ") VALUES(" + strValue + ");");
        }
        #endregion

        #region 执行SQL删除语句
        #region 执行SQL删除语句(无条件)
        /// <summary>
        /// 执行SQL删除语句
        /// </summary>
        /// <param name="tableName">数据表名</param>
        public void ExecuteDeleteSql(string tableName)
        {
            tableName = tableName.Trim();
            //执行删除语句
            ExecuteSqlCommand("DELETE FROM " + tableName + ";");
        }
        #endregion

        #region 执行SQL删除语句(有条件)
        /// <summary>
        /// 执行SQL删除语句
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="condition">条件</param>
        public void ExecuteDeleteSql(string tableName, string condition)
        {
            tableName = tableName.Trim();
            condition = condition.Trim();
            //执行删除语句
            ExecuteSqlCommand("DELETE FROM " + tableName + " WHERE " + condition + ";");
        }
        #endregion
        #endregion

        #region 执行SQL更新语句
        #region 执行SQL更新语句(无条件)
        /// <summary>
        /// 执行SQL更新语句
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strFieldValue">设置字段值</param>
        public void ExecuteUpdateSql(string tableName, string strFieldValue)
        {
            tableName = tableName.Trim();
            strFieldValue = strFieldValue.Trim();
            //执行更新语句
            ExecuteSqlCommand("UPDATE " + tableName + " SET " + strFieldValue + ";");
        }
        #endregion

        #region 执行SQL更新语句(有条件)
        /// <summary>
        /// 执行SQL更新语句
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="strFieldValue">设置字段值</param>
        /// <param name="condition">条件</param>
        public void ExecuteUpdateSql(string tableName, string strFieldValue, string condition)
        {
            tableName = tableName.Trim();
            strFieldValue = strFieldValue.Trim();
            condition = condition.Trim();
            //执行更新语句
            ExecuteSqlCommand("UPDATE " + tableName + " SET " + strFieldValue + " WHERE " + condition + ";");
        }
        #endregion
        #endregion

        #region 备份数据库
        /// <summary>
        /// 备份数据库
        /// </summary>
        public void BackupDataBase(string strPath)
        {
            //执行备份语句
            ExecuteSqlCommand("BACKUP DATABASE db_PWMS TO DISK='" + strPath+"'");
        }
        #endregion

        #region 还原数据库
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="strPath">数据库文件路径</param>
        public void RestoreDataBase(string strPath)
        { 
            strPath = strPath.Trim();
           string sqlConStr = "Data Source=.;Database=master;User id=sa;PWD=2012;Connect Timeout=3";//数据库连接语句
           // string sqlConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=master;Trusted_Connection=Yes;Connect Timeout=3";
            SqlConnection sqlCon = new SqlConnection(sqlConStr);//SqlConnection对象
            sqlCon.Open();//数据库连接打开
            //杀掉所有连接 db_PWMS 数据库的进程
            SqlDataAdapter sqlDataRe = new SqlDataAdapter("SELECT spid FROM master..sysprocesses WHERE dbid=db_id( 'db_PWMS') ", sqlConStr);
            DataTable dataTable = new DataTable();
            sqlDataRe.Fill(dataTable);//进程填充进表格
            SqlCommand sqlCom = new SqlCommand("", sqlCon);
            for (int i = 0; i < dataTable.Rows.Count; i++)//遍历杀进程
            {
                sqlCom.CommandText = "KILL " + dataTable.Rows[i][0].ToString();   //强行关闭用户进程 
                sqlCom.ExecuteNonQuery();//执行SqlCommand
            }
            //还原数据库
            sqlCom.CommandText = "USE MASTER RESTORE DATABASE db_PWMS FROM DISK='" + strPath + "' WITH REPLACE";
            sqlCom.ExecuteNonQuery();//执行还原语句
            sqlCom.Dispose();//关闭对象
            sqlCon.Dispose();//关闭连接           
        }
        #endregion


    }


}