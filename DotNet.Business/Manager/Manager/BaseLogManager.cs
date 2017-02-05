//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;

namespace DotNet.Business
{
    using DotNet.Utilities;

	/// <summary>
    /// BaseLogManager
    /// 日志的基类（程序OK）
	/// 
	/// 想在这里实现访问记录、继承以前的比较好的思路。
	///
	/// 修改纪录
    /// 
    ///     2011.03.24 版本：2.6 JiRiGaLa   讲程序转移到DotNet.BaseManager命名空间中。
    ///     2008.10.21 版本：2.5 JiRiGaLa   日志功能改进。
    ///     2008.04.22 版本：2.4 JiRiGaLa   在新的数据库连接里保存日志，不影响其它程序逻辑的事务处理。
    ///     2007.12.03 版本：2.3 JiRiGaLa   进行规范化整理。
    ///     2007.11.08 版本：2.2 JiRiGaLa   整理多余的主键（OK）。
    ///		2007.07.09 版本：2.1 JiRiGaLa   程序整理，修改 Static 方法，采用 Instance 方法。
    ///		2006.12.02 版本：2.0 JiRiGaLa   程序整理，错误方法修改。
	///		2004.07.28 版本：1.0 JiRiGaLa   进行了排版、方法规范化、接口继承、索引器。
	///		2004.11.12 版本：1.0 JiRiGaLa   删除了一些方法。
	///		2005.09.30 版本：1.0 JiRiGaLa   又进行一次飞跃，把一些思想进行了统一。
	/// 
    /// 版本：2.4
	///
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.22</date>
	/// </author> 
	/// </summary>
    public class BaseLogManager : BaseManager
    {
        public BaseLogManager()
        {
            // 用自增量的方式
            base.Identity = true;
            base.ReturnId = false;
            base.CurrentTableName = BaseLogEntity.TableName;
        }

        public BaseLogManager(IDbHelper dbHelper) : this()
        {
            DbHelper = dbHelper;
        }

        public BaseLogManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        private static BaseLogManager instance = null;
        private static object locker = new Object();

        public static BaseLogManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new BaseLogManager();
                        }
                    }
                }
                return instance;
            }
        }

        #region public int AddEntity(BaseLogEntity logEntity)
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logEntity">日志对象</param>
        /// <returns>主键</returns>
        public int AddEntity(BaseLogEntity logEntity)
        {
            int returnValue = 0;
            // if (!BaseSystemInfo.RecordLog)
            // {
            //    return string.Empty;
            // }
            // 由于并发控制，没有能获得有效ID的错误处理，测试一下错误发生的数量。 
            // if (Log.ID.Length == 0)
            // {
            //    return returnValue;
            // }
            // string sequence = BaseSequenceManager.Instance.GetSequence(DbHelper, BaseLogEntity.TableName);
            // string sequence = BaseSequenceManager.Instance.NewGuid();
            string sequence = string.Empty;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);

            if (DbHelper.CurrentDbType == CurrentDbType.Access)
            // sqlBuilder.BeginInsert(this.CurrentTableName, "LogId", this.Identity);
            {
                // 写入日志 04-24
                dbHelper.Open(BaseSystemInfo.UserCenterDbConnection);
                // 用户已经不存在的需要整理干净，防止数据不完整。
                string sqlQuery = " INSERT INTO [BaseLog]([ProcessId],[ProcessName],[MethodId] " +
                    " ,[MethodName],[Parameters],[UserId],[UserRealName],[IPAddress],[UrlReferrer],[WebUrl],[Description],[CreateOn],[ModifiedOn]) VALUES " +
                    "( '" + logEntity.ProcessId + "','" + logEntity.ProcessName + "','" + logEntity.MethodId.ToString() + "','" + logEntity.MethodName + "','" +
                    logEntity.Parameters + "','" + logEntity.UserId + "','" + logEntity.UserRealName + "','" + logEntity.IPAddress + "','" + logEntity.UrlReferrer + "','" +
                    logEntity.WebUrl + " ','" + logEntity.Description + "'," + DbHelper.GetDBNow() + "," + DbHelper.GetDBNow() + ")";

                return dbHelper.ExecuteNonQuery(sqlQuery); ;
            }
            else
            sqlBuilder.BeginInsert(this.CurrentTableName, this.Identity);
            
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseLogEntity.FieldId, logEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseLogEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseLogEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(logEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            logEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseLogEntity.FieldId, logEntity.Id);
                    }
                }
            }
            if (String.IsNullOrEmpty(logEntity.UserId))
            {
                logEntity.UserId = logEntity.IPAddress;
            }
            sqlBuilder.SetValue(BaseLogEntity.FieldUserId, logEntity.UserId);
            sqlBuilder.SetValue(BaseLogEntity.FieldUserRealName, logEntity.UserRealName);
            sqlBuilder.SetValue(BaseLogEntity.FieldProcessId, logEntity.ProcessId);
            sqlBuilder.SetValue(BaseLogEntity.FieldProcessName, logEntity.ProcessName);
            sqlBuilder.SetValue(BaseLogEntity.FieldMethodId, logEntity.MethodId);
            sqlBuilder.SetValue(BaseLogEntity.FieldMethodName, logEntity.MethodName);
            sqlBuilder.SetValue(BaseLogEntity.FieldParameters, logEntity.Parameters);
            sqlBuilder.SetValue(BaseLogEntity.FieldUrlReferrer, logEntity.UrlReferrer);
            sqlBuilder.SetValue(BaseLogEntity.FieldWebUrl, logEntity.WebUrl);
            sqlBuilder.SetValue(BaseLogEntity.FieldIPAddress, logEntity.IPAddress);
            sqlBuilder.SetValue(BaseLogEntity.FieldDescription, logEntity.Description);
            //if (logEntity.CreateUserId.Length == 0)
            //{
            //    logEntity.CreateUserId = logEntity.IPAddress;
            //}
            //sqlBuilder.SetValue(BaseLogEntity.FieldCreateUserId, logEntity.CreateUserId);
            sqlBuilder.SetDBNow(BaseLogEntity.FieldCreateOn);
            // return sqlBuilder.EndInsert() > 0 ? sequence : string.Empty;
            if (DbHelper.CurrentDbType == CurrentDbType.SqlServer)
            {
                returnValue = sqlBuilder.EndInsert();
            }
            else
            {
                sqlBuilder.EndInsert();
                if (this.ReturnId)//如果需要反回值
                {
                    returnValue = int.Parse(logEntity.Id);
                }
                else
                {
                    returnValue = 0;
                }
            }
            return returnValue;
        }
        #endregion

        public void AddWebLog(string urlReferrer, string adId, string webUrl)
        {
            string userId = string.Empty;
            if (!UserInfo.Id.Equals(UserInfo.IPAddress))
            {
                userId = UserInfo.Id;
            }
            string userName = string.Empty;
            if (!UserInfo.UserName.Equals(UserInfo.IPAddress))
            {
                userName = UserInfo.UserName;
            }
            this.AddWebLog(urlReferrer, adId, webUrl, UserInfo.IPAddress, userId, userName);
        }

        /// <summary>
        /// 写入网页访问日志
        /// </summary>
        /// <param name="urlReferrer">导入网址</param>
        /// <param name="ad">广告商ID</param>
        /// <param name="webUrl">访问的网址</param>
        /// <param name="ipAddress">网络地址</param>
        /// <param name="userId">用户主键</param>
        /// <param name="userName">用户名</param>
        public void AddWebLog(string urlReferrer, string adId, string webUrl, string ipAddress, string userId, string userName)
        {
            BaseLogEntity logEntity = new BaseLogEntity();
            logEntity.ProcessId = "WebLog";
            logEntity.UrlReferrer = urlReferrer;
            if (!string.IsNullOrEmpty(adId))
            {
                logEntity.MethodName = "AD";
                logEntity.Parameters = adId;
            }
            logEntity.WebUrl = webUrl;
            logEntity.IPAddress = ipAddress;
            logEntity.UserId = userId;
            logEntity.UserRealName = userName;
            this.AddEntity(logEntity);        
        }

        public DataTable GetDataTableByDateByUserIds(string[] userIds, string name, string value, string beginDate, string endDate)
        {
            string sqlQuery = this.GetDataTableSql(userIds, name, value, beginDate, endDate);
            return DbHelper.Fill(sqlQuery);
        }

        private string GetDataTableSql(string[] userIds, string name, string value, string beginDate, string endDate)
        {
            string sqlQuery = " SELECT * FROM " + BaseLogEntity.TableName + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(value))
            {
                sqlQuery += " AND " + name + " = '" + value + "' ";
            }
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Parse(beginDate.ToString()).ToShortDateString();
                endDate = DateTime.Parse(endDate.ToString()).AddDays(1).ToShortDateString();
            }
            // 注意安全问题
            if (userIds != null)
            {
                sqlQuery += " AND " + BaseLogEntity.FieldUserId + " IN (" + BaseBusinessLogic.ObjectsToList(userIds) + ") ";
            }
            switch (DbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                    // Access 中的时间分隔符 是 “#”
                    if (beginDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CreateOn >= #" + beginDate + "#";
                    }
                    if (endDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CreateOn <= #" + endDate + "#";
                    }
                    break;
                case CurrentDbType.SqlServer:
                    if (beginDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CreateOn >= '" + beginDate + "'";
                    }
                    if (endDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CreateOn <= '" + endDate + "'";
                    }
                    break;
                case CurrentDbType.Oracle:
                    if (beginDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CreateOn >= TO_DATE( '" + beginDate + "','yyyy-mm-dd hh24-mi-ss') ";
                    }
                    if (endDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CreateOn <= TO_DATE('" + endDate + "','yyyy-mm-dd hh24-mi-ss')";
                    }
                    break;
            }
            sqlQuery += " ORDER BY CreateOn DESC ";
            return sqlQuery;
        }

        #region public DataTable GetDataTableByDate(string name, string value, string beginDate, string endDate) 查询
        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByDate(string name, string value, string beginDate, string endDate)
        {
            string sqlQuery = this.GetDataTableSql(null, name, value, beginDate, endDate);
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetDataTableByDate(IDbHelper dbHelper, string createOn, string processId, string createUserId)
        /// <summary>
        /// 按日期查询
		/// </summary>
		/// <param name="dateTime">记录日期 yyyy/mm/dd</param>
        /// <param name="processId">模块主键</param>
		/// <param name="createUserId">用户主键</param>
		/// <returns>数据表</returns>
        public DataTable GetDataTableByDate(IDbHelper dbHelper, string createOn, string processId, string createUserId)
		{
            string sqlQuery = " SELECT * FROM " + BaseLogEntity.TableName
                    + " WHERE CONVERT(NVARCHAR, " + BaseLogEntity.FieldCreateOn + ", 111) = " + dbHelper.GetParameter(BaseLogEntity.FieldCreateOn)
                    + " AND " + BaseLogEntity.FieldProcessId + " = " + dbHelper.GetParameter(BaseLogEntity.FieldProcessId)
                    + " AND " + BaseLogEntity.FieldUserId + " = " + dbHelper.GetParameter(BaseLogEntity.FieldUserId);
            sqlQuery += " ORDER BY " + BaseLogEntity.FieldCreateOn;
			string[] names		= new string[3];
            names[0] = BaseLogEntity.FieldCreateOn;
            names[1] = BaseLogEntity.FieldProcessName;
            names[2] = BaseLogEntity.FieldUserId;
            Object[] values	= new Object[3];
			values[0]	= createOn;
            values[1]   = processId;
			values[2]	= createUserId;
            DataTable dataTable = new DataTable(BaseLogEntity.TableName);
            dbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
			return dataTable;
		}
		#endregion

        public void Add(IDbHelper dbHelper, BaseUserInfo userInfo, MethodBase methodBase)
        {
            DbHelper = dbHelper;
            UserInfo = userInfo;
            this.Add(DbHelper, UserInfo, methodBase.ReflectedType.FullName, methodBase.ReflectedType.Name, methodBase);
        }


        public void Add(IDbHelper dbHelper, BaseUserInfo userInfo, string serviceName, MethodBase methodBase)
        {
            DbHelper = dbHelper;
            UserInfo = userInfo;
            this.Add(DbHelper, UserInfo, serviceName, methodBase.ReflectedType.FullName, methodBase);
        }


        public void Add(IDbHelper dbHelper, BaseUserInfo userInfo, string serviceName, string methodName, MethodBase methodBase)
        {
            DbHelper = dbHelper;
            UserInfo = userInfo;
            this.Add(dbHelper, userInfo, serviceName, methodName, methodBase.ReflectedType.Name, methodBase.Name, string.Empty);
        }

        public void Add(IDbHelper dbHelper, BaseUserInfo userInfo, string processName, string methodName, string processId, string methodId, string parameters)
        {
            // int returnValue = 0;
            DbHelper = dbHelper;
            UserInfo = userInfo;
            if (!BaseSystemInfo.RecordLog)
            {
                return;
            }
            BaseLogEntity logEntity = new BaseLogEntity();
            logEntity.UserId = userInfo.Id;
            logEntity.UserRealName = userInfo.RealName;
            logEntity.ProcessId = processId;
            logEntity.ProcessName = processName;
            logEntity.MethodId = methodId;
            logEntity.MethodName = methodName;
            logEntity.Parameters = parameters;
            logEntity.IPAddress = userInfo.IPAddress;
            this.Add(dbHelper, logEntity);
        }

        public void Add(IDbHelper dbHelper, string userId, string realName, string processId, string processName, string methodId, string methodName, string parameters, string ipAddress, string description)
        {
            DbHelper = dbHelper;
            this.Add(userId, realName, processId, processName, methodId, methodName, parameters, ipAddress, description);
        }

        #region public int Add(string userId, string realName, string processId, string processName, string methodName, string parameters, string ipAddress, string description)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userRealName">用户姓名</param>
        /// <param name="processID">模块ID</param>
        /// <param name="processName">模块名称</param>
        /// <param name="methodName">对象ID</param>
        /// <param name="parameters">对象名称</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="description">描述</param>
        /// <returns>主键</returns>
        public void Add(string userId, string realName, string processId, string processName, string methodId, string methodName, string parameters, string ipAddress, string description)
        {
            BaseLogEntity logEntity = new BaseLogEntity();
            logEntity.UserId = userId;
            logEntity.UserRealName = realName;
            logEntity.ProcessId = processId;
            logEntity.ProcessName = processName;
            logEntity.MethodName = methodName;
            logEntity.MethodId = methodId;
            logEntity.Parameters = parameters;
            logEntity.IPAddress = ipAddress;
            logEntity.Description = description;
            // 这里是出错了，才调试
            // return 0;
            this.AddEntity(logEntity);
        }
        #endregion

        #region public int Add(IDbHelper dbHelper, BaseLogEntity logEntity)
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="logEntity">日志对象</param>
        /// <returns>主键</returns>
        public void Add(IDbHelper dbHelper, BaseLogEntity logEntity)
        {
            DbHelper = dbHelper;
            // 这里是出错了，才调试
            // return 0;
            AddEntity(logEntity);
        }
        #endregion

        //public DataTable Search(string[] userIds, string search, bool? enabled, bool OnlyOnLine)
        //{
        //    search = StringUtil.GetSearchString(search);
        //    string sqlQuery = " SELECT " + BaseLogEntity.TableName + ".*," + BaseUserEntity.TableName+ ".* " 
        //        + " FROM  " + BaseLogEntity.TableName + " LEFT OUTER JOIN "+
        //        BaseUserEntity.TableName + " ON RTRIM(LTRIM(" + BaseUserEntity.FieldId +"))="+
        //        BaseLogEntity.FieldUserId +
        //        " WHERE 1=1 ";
        //    //string sqlQuery = " SELECT * FROM " + BaseLogEntity.TableName + " WHERE 1=1 ";
            
        //    // 注意安全问题
        //    if (userIds.Length >0) 
        //    {
        //        sqlQuery += " AND " + BaseLogEntity.FieldUserId + " IN (" + BaseBusinessLogic.ObjectsToList(userIds) + ") ";
        //    }


        //     sqlQuery += " AND ("  + BaseLogEntity.TableName +"." + BaseLogEntity.FieldWebUrl + " LIKE '" + search + "'"
        //                + " OR " + BaseLogEntity.TableName + "." + BaseLogEntity.FieldUserId + " LIKE '" + search + "'"
        //                + " OR " + BaseLogEntity.TableName + "." + BaseLogEntity.FieldUserRealName + " LIKE '" + search + "'"
        //                + " OR " + BaseLogEntity.TableName + "." + BaseLogEntity.FieldUrlReferrer + " LIKE '" + search + "'"
        //                + " OR " + BaseLogEntity.TableName + "." + BaseLogEntity.FieldIPAddress + " LIKE '" + search + "'"
        //                + " OR " + BaseLogEntity.TableName + "." + BaseLogEntity.FieldDescription + " LIKE '" + search + "')";

        //    //sqlQuery += " ORDER BY " + BaseLogEntity.TableName + "." + BaseUserEntity.FieldSortCode;
        //    return DbHelper.Fill(sqlQuery);
        //}

        public DataTable Search(string[] userIds, string search, bool? enabled, bool OnlyOnLine)
        {
            search = StringUtil.GetSearchString(search);
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + ".* "
                            + "        , ( SELECT " + BaseRoleEntity.FieldRealName
                                        + "  FROM " + BaseRoleEntity.TableName
                                        + " WHERE " + BaseRoleEntity.FieldId + " = " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRoleId + ") AS RoleName "
                            + "   FROM " + BaseUserEntity.TableName
                            + " WHERE " + BaseUserEntity.FieldDeletionStateCode + "= 0 "
                            + " AND " + BaseUserEntity.FieldIsVisible + "= 1 ";

            sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRealName + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIPAddress + " LIKE '" + search + "'"
                        + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldMACAddress + " LIKE '" + search + "'"
                        +")";

            sqlQuery += " ORDER BY " + BaseUserEntity.FieldSortCode;

            return DbHelper.Fill(sqlQuery);
        }
    }
}