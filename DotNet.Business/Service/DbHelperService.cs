//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;
    using System.Data.OleDb;
    // using System.Web.UI.WebControls;

    /// <summary>
    /// DbHelperService
    /// 执行传入的SQL语句
    /// 
    /// 修改纪录
    /// 
    ///		2011.05.07 版本：2.3 JiRiGaLa 改进为虚类。
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.07.10 版本：1.0 JiRiGaLa 数据库访问类。
    ///		
    /// 版本：2.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.07</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public abstract class DbHelperService : System.MarshalByRefObject, IDbHelperService
    {
        public string ServiceDbConnection = BaseSystemInfo.BusinessDbConnection;
        public CurrentDbType ServiceDbType = BaseSystemInfo.BusinessDbType;

        public DbHelperService()
        {
        }

        public DbHelperService(string dbConnection)
        {
            ServiceDbConnection = dbConnection;
        }

        #region 执行sql  public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText)
       /// <summary>
       /// 执行sql
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <returns></returns>
        public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteNonQuery(commandText);
        }
        #endregion

        #region  执行sql 带参数 public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        /// <summary>
       /// 执行sql 带参数
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <param name="dbParameters"></param>
       /// <returns></returns>
        public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteNonQuery(commandText, dbParameters);
        }
        #endregion

        #region  执行sql public object ExecuteScalar(BaseUserInfo userInfo, string commandText)
        /// <summary>
       /// 执行sql
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <returns></returns>
        public object ExecuteScalar(BaseUserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteScalar(commandText);
        }
        #endregion

        #region 执行sql 带参数 public object ExecuteScalar(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
       /// <summary>
       /// 执行sql 带参数
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <param name="dbParameters"></param>
       /// <returns></returns>
        public object ExecuteScalar(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteScalar(commandText, dbParameters);
        }
        #endregion

        #region  执行Sql 返回DataTable public DataTable Fill(BaseUserInfo userInfo, string commandText)
        /// <summary>
       /// 执行Sql 返回DataTable
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <returns></returns>
        public DataTable Fill(BaseUserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.Fill(commandText);
        }
        #endregion

        #region 执行Sql 返回DataTable public DataTable Fill(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        /// <summary>
        /// 执行Sql 返回DataTable
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <param name="dbParameters"></param>
       /// <returns></returns>
        public DataTable Fill(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.Fill(commandText, dbParameters);
        }
        #endregion 
    }

    public class DataBase
    {
        public DataBase()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
       
        private OleDbConnection Con;//连接变量
        public string ServiceDbConnection = BaseSystemInfo.BusinessDbConnection;
        public CurrentDbType ServiceDbType = BaseSystemInfo.BusinessDbType;

        private void Open()
        {
            if (Con == null)
                Con = new OleDbConnection(ServiceDbConnection);

            if (Con.State == System.Data.ConnectionState.Closed)
                Con.Open();
        }

        public OleDbConnection DBCon()
        {
            return new OleDbConnection(ServiceDbConnection);
        }

        private void Close()
        {
            if (Con != null)
                Con.Close();
        }

        public void Dispose()
        {
            if (Con != null)
            {
                Con.Dispose();
                Con = null;
            }
        }

        public OleDbParameter MakeParam(string ParamName, OleDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OleDbParameter param;
            if (Size > 0)
                param = new OleDbParameter(ParamName, DbType, Size);
            else
                param = new OleDbParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }

        public OleDbParameter MakeInParm(string ParamName, OleDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        private OleDbCommand CreateCommand(string procName, OleDbParameter[] prams)
        {
            this.Open();
            OleDbCommand Cmd = new OleDbCommand(procName, Con);
            Cmd.CommandType = CommandType.Text;

            if (prams != null)
            {
                foreach (OleDbParameter parameter in prams)
                    Cmd.Parameters.Add(parameter);                
            }

            // Access 不支持函数的返回
            /*Cmd.Parameters.Add(new OleDbParameter("ReturnValue", OleDbType.Integer, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null)
                );*/

            return Cmd;
        }

        public int RunProc(string procName, OleDbParameter[] prams)
        {            
            OleDbCommand Cmd = CreateCommand(procName, prams);
            int ReturnValue = Cmd.ExecuteNonQuery();
            this.Close();

            return ReturnValue;
 
            // Access 不支持函数的返回 (int)Cmd.Parameters["ReturnValue"].Value;
        }

        public int RunProc(string procName)
        {
            this.Open();
            OleDbCommand Cmd = new OleDbCommand(procName, Con);

            int ReturnValue = Cmd.ExecuteNonQuery();
            this.Close();
            return ReturnValue;
        }

        /// <summary>
        /// 返回数据提供器 DataAdaper
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        private OleDbDataAdapter CreateDataAdaper(string procName, OleDbParameter[] prams)
        {
            this.Open();
            OleDbDataAdapter dap = new OleDbDataAdapter(procName, Con);
            dap.SelectCommand.CommandType = CommandType.Text;

            if (prams != null)
            {
                foreach (OleDbParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }

            dap.SelectCommand.Parameters.Add(new OleDbParameter("ReturnValue", OleDbType.Integer, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }

        public DataSet RunProcReturn(string procName, OleDbParameter[] prams, string tbName)
        {
            OleDbDataAdapter dap = CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            return ds;
        }
        
        public DataSet RunProcReturn(string procName, string tbName)
        {
            OleDbDataAdapter dap =  CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);

            this.Close();
            return ds;
        }

        /*
        public void BindDG(GridView dg, string id, string strSql, string Tname)
        {   
            // 需要WEB.UI的支持
          
            SqlConnection Conn = DBCon();
            SqlDataAdapter sda = new SqlDataAdapter(strSql, Conn);
            DataSet ds = new DataSet();

            sda.Fill(ds, Tname);
            dg.DataSource = ds.Tables[Tname];

            dg.DataKeyNames = new string[] { id };
            dg.DataBind();
        }
        */
    }
}