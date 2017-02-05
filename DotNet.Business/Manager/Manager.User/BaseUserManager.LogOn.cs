//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.17 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.17</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        public BaseUserInfo LogOnByUserName(string userName, string ipAddress = null, string macAddress = null)
        {
            BaseUserInfo userInfo = null;
            // 用户没有找到状态
            this.ReturnStatusCode = StatusCode.UserNotFound.ToString();
            // 检查是否有效的合法的参数
            if (!String.IsNullOrEmpty(userName))
            {
                BaseUserManager userManager = new BaseUserManager(DbHelper);
                DataTable dataTable = userManager.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName));
                if (dataTable.Rows.Count == 1)
                {
                    BaseUserEntity userEntity = new BaseUserEntity(dataTable);
                    userInfo = this.LogOn(userEntity.UserName, userEntity.UserPassword, true, ipAddress, macAddress);
                }
            }
            return userInfo;
        }

        public BaseUserInfo LogOnByOpenId(string openId, string ipAddress = null, string macAddress = null)
        {
            BaseUserInfo userInfo = null;
            // 用户没有找到状态
            this.ReturnStatusCode = StatusCode.UserNotFound.ToString();
            // 检查是否有效的合法的参数
            if (!String.IsNullOrEmpty(openId))
            {
                BaseUserManager userManager = new BaseUserManager(DbHelper);
                DataTable dataTable = userManager.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldOpenId, openId));
                if (dataTable.Rows.Count == 1)
                {
                    BaseUserEntity userEntity = new BaseUserEntity(dataTable);
                    userInfo = this.LogOn(userEntity.UserName, userEntity.UserPassword, false, ipAddress, macAddress, false);
                }
            }
            return userInfo;
        }

        #region public BaseUserInfo LogOn(string userName, string password, bool createNewOpenId = false, string ipAddress = null , string macAddress = null) 进行登录操作
        /// <summary>
        /// 进行登录操作
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="createNewOpenId"></param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="macAddress">MAC地址</param>
        /// <param name="checkUserPassword">是否要检查用户密码</param>
        /// <returns>用户信息</returns>
        public BaseUserInfo LogOn(string userName, string password, bool createNewOpenId = false, string ipAddress = null, string macAddress = null, bool checkUserPassword = true)
        {
            BaseUserInfo userInfo = null;

            string realName = string.Empty;
            if (UserInfo != null)
            {
                realName = UserInfo.RealName;
            }

            if (ipAddress == null)
            {
                if (UserInfo != null)
                {
                    ipAddress = UserInfo.IPAddress;
                }
            }

            // 01: 系统是否采用了在线用户的限制
            if (BaseSystemInfo.OnLineLimit > 0)
            {
                if (this.CheckOnLineLimit())
                {
                    this.ReturnStatusCode = StatusCode.ErrorOnLineLimit.ToString();
                    BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0089 + BaseSystemInfo.OnLineLimit.ToString());
                    return userInfo;
                }
            }

            // 04. 默认为用户没有找到状态，查找用户
            // 这是为了达到安全要求，不能提示用户未找到，那容易让别人猜测到帐户
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                this.ReturnStatusCode = StatusCode.ErrorLogOn.ToString();
            }
            else
            {
                this.ReturnStatusCode = StatusCode.UserNotFound.ToString();
            }

            // 02. 查询数据库中的用户数据？只查询未被删除的
            // 先按用户名登录
            DataTable dataTable = this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userName)
                , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
            // 若不是严格检查，可以采用多种方式登录
            if (!BaseSystemInfo.CheckPasswordStrength)
            {
                if (dataTable.Rows.Count == 0)
                {
                    // 若没数据再按工号登录
                    dataTable = this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, userName)
                        , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                }
                if (dataTable.Rows.Count == 0)
                {
                    // 若没数据再按邮件登录
                    dataTable = this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldEmail, userName)
                        , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                }
                if (dataTable.Rows.Count == 0)
                {
                    // 若没数据再按手机号码登录
                    dataTable = this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldMobile, userName)
                        , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                }
                if (dataTable.Rows.Count == 0)
                {
                    // 若没数据再按手机号码登录
                    dataTable = this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldTelephone, userName)
                        , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                }
            }
            BaseUserEntity userEntity = null;
            if (dataTable.Rows.Count > 1)
            {
                this.ReturnStatusCode = StatusCode.UserDuplicate.ToString();
            }
            else if (dataTable.Rows.Count == 1)
            {
                // 03. 系统是否采用了密码加密策略？
                string encryptPassword = string.Empty;
                if (checkUserPassword)
                {
                    if (BaseSystemInfo.ServerEncryptPassword)
                    {
                        password = this.EncryptUserPassword(password);
                    }
                }

                // 05. 判断密码，是否允许登录，是否离职是否正确
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    userEntity = new BaseUserEntity(dataRow);
                    if (!string.IsNullOrEmpty(userEntity.AuditStatus) && userEntity.AuditStatus.EndsWith(AuditStatus.WaitForAudit.ToString()))
                    {
                        this.ReturnStatusCode = AuditStatus.WaitForAudit.ToString();
                        BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0078);
                        return userInfo;
                    }
                    // 用户是否有效的
                    if (userEntity.Enabled == 0)
                    {
                        this.ReturnStatusCode = StatusCode.LogOnDeny.ToString();
                        BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0079);
                        return userInfo;
                    }
                    // 用户是否有效的
                    if (userEntity.Enabled == -1)
                    {
                        this.ReturnStatusCode = StatusCode.UserNotActive.ToString();
                        BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0080);
                        return userInfo;
                    }

                    // 06. 允许登录时间是否有限制
                    if (userEntity.AllowEndTime != null)
                    {
                        userEntity.AllowEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userEntity.AllowEndTime.Value.Hour, userEntity.AllowEndTime.Value.Minute, userEntity.AllowEndTime.Value.Second);
                    }
                    if (userEntity.AllowStartTime != null)
                    {
                        userEntity.AllowStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userEntity.AllowStartTime.Value.Hour, userEntity.AllowStartTime.Value.Minute, userEntity.AllowStartTime.Value.Second);
                        if (DateTime.Now < userEntity.AllowStartTime)
                        {
                            this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                            BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0081 + userEntity.AllowStartTime.Value.ToString("HH:mm"));
                            return userInfo;
                        }
                    }
                    if (userEntity.AllowEndTime != null)
                    {
                        if (DateTime.Now > userEntity.AllowEndTime)
                        {
                            this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                            BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0082 + userEntity.AllowEndTime.Value.ToString("HH:mm"));
                            return userInfo;
                        }
                    }

                    // 07. 锁定日期是否有限制
                    if (userEntity.LockStartDate != null)
                    {
                        if (DateTime.Now > userEntity.LockStartDate)
                        {
                            if (userEntity.LockEndDate == null || DateTime.Now < userEntity.LockEndDate)
                            {
                                this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                                BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0083 + userEntity.LockStartDate.Value.ToString("yyyy-MM-dd"));
                                return userInfo;
                            }
                        }
                    }
                    if (userEntity.LockEndDate != null)
                    {
                        if (DateTime.Now < userEntity.LockEndDate)
                        {
                            this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                            BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0084 + userEntity.LockEndDate.Value.ToString("yyyy-MM-dd"));
                            return userInfo;
                        }
                    }

                    // 08. 是否检查用户IP地址，是否进行访问限制？管理员不检查IP.
                    if (BaseSystemInfo.CheckIPAddress && !this.IsAdministrator(userEntity.Id.ToString()))
                    {
                        List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, userEntity.Id.ToString()));
                        parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, "IPAddress"));
                        // 没有设置IP地址时不检查
                        BaseParameterManager baseParameterManager = new BaseParameterManager(this.DbHelper);
                        if (baseParameterManager.Exists(parameters))
                        {
                            if (!string.IsNullOrEmpty(ipAddress) && !this.CheckIPAddress(ipAddress, userEntity.Id.ToString()))
                            {
                                this.ReturnStatusCode = StatusCode.ErrorIPAddress.ToString();
                                BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, ipAddress, ipAddress, AppMessage.MSG0085);
                                return userInfo;
                            }
                        }

                        // 没有设置MAC地址时不检查
                        parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, userEntity.Id.ToString()));
                        parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, "MacAddress"));
                        if (baseParameterManager.Exists(parameters))
                        {
                            if (!string.IsNullOrEmpty(macAddress) && !this.CheckMacAddress(macAddress, userEntity.Id.ToString()))
                            {
                                this.ReturnStatusCode = StatusCode.ErrorMacAddress.ToString();
                                BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, macAddress, ipAddress, AppMessage.MSG0086);
                                return userInfo;
                            }
                        }
                    }

                    // 10. 只允许登录一次，需要检查是否自己重新登录了，或者自己扮演自己了
                    if ((UserInfo != null) && (!UserInfo.Id.Equals(userEntity.Id.ToString())))
                    {
                        if (BaseSystemInfo.CheckOnLine)
                        {
                            if (userEntity.UserOnLine > 0)
                            {
                                this.ReturnStatusCode = StatusCode.ErrorOnLine.ToString();
                                BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0087);
                                return userInfo;
                            }
                        }
                    }

                    // 11. 密码是否正确(null 与空看成是相等的)
                    if (!(string.IsNullOrEmpty(userEntity.UserPassword) && string.IsNullOrEmpty(password)))
                    {
                        bool userPasswordOK = true;
                        // 用户密码是空的
                        if (string.IsNullOrEmpty(userEntity.UserPassword))
                        {
                            // 但是输入了不为空的密码
                            if (!string.IsNullOrEmpty(password))
                            {
                                userPasswordOK = false;
                            }
                        }
                        else
                        {
                            // 用户的密码不为空，但是用户是输入了密码
                            if (string.IsNullOrEmpty(password))
                            {
                                userPasswordOK = false;
                            }
                            else
                            {
                                // 再判断用户的密码与输入的是否相同
                                userPasswordOK = userEntity.UserPassword.Equals(password);
                            }
                        }
                        // 用户的密码不相等
                        if (!userPasswordOK)
                        {
                            // 密码错误后 1：应该记录日志
                            BaseLogManager.Instance.Add(DbHelper, userEntity.Id.ToString(), userEntity.RealName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userEntity.RealName, ipAddress, AppMessage.MSG0088);
                            // TODO: 密码错误后 2：看最近1个小时输入了几次错误了？24小时里。
                            // TODO: 密码错误后 3：若错误密码数量已经超过了指定的限制，那用户就需要被锁定1个小时。
                            // TODO: 密码错误后 4：同时需要处理返回值，是由于密码次数过多导致的被锁定，登录时也应该能读取这个状态比较，时间过期了，也应该进行处理一下状态。
                            // 密码强度检查，若是要有安全要求比较高的，返回的提醒消息要进行特殊处理，不能返回非常明确的提示信息。
                            if (BaseSystemInfo.CheckPasswordStrength)
                            {
                                this.ReturnStatusCode = StatusCode.ErrorLogOn.ToString();
                            }
                            else
                            {
                                this.ReturnStatusCode = StatusCode.PasswordError.ToString();
                            }
                            return userInfo;
                        }
                    }

                    // 09. 更新IP地址，更新MAC地址
                    if (!string.IsNullOrEmpty(ipAddress))
                    {
                        this.SetProperty(userEntity.Id, new KeyValuePair<string, object>(BaseUserEntity.FieldIPAddress, ipAddress));
                    }
                    if (!string.IsNullOrEmpty(macAddress))
                    {
                        this.SetProperty(userEntity.Id, new KeyValuePair<string, object>(BaseUserEntity.FieldMACAddress, macAddress));
                    }

                    // 可以正常登录了
                    this.ReturnStatusCode = StatusCode.OK.ToString();

                    // 13. 登录、重新登录、扮演时的在线状态进行更新
                    this.ChangeOnLine(userEntity.Id.ToString());

                    userInfo = this.ConvertToUserInfo(userEntity);
                    // 获得员工的信息，这里员工的一些信息还是有错误，部门的主键啥的
                    if (userEntity.IsStaff == 1)
                    {
                        // BaseStaffManager staffManager = new BaseStaffManager(DbHelper, UserInfo);
                        // 这里需要按 员工的用户ID来进行查找对应的员工-用户关系
                        // BaseStaffEntity staffEntity = new BaseStaffEntity(staffManager.GetDataTable(BaseStaffEntity.FieldUserId, userEntity.Id));
                        // if (staffEntity.Id > 0)
                        // {
                            // userInfo = staffManager.ConvertToUserInfo(staffEntity, userInfo);
                        // }
                    }
                    userInfo.IPAddress = ipAddress;
                    userInfo.MACAddress = macAddress;
                    userInfo.Password = password;
                    // 这里是判断用户是否为系统管理员的
                    userInfo.IsAdministrator = IsAdministrator(userInfo.Id);
                    userInfo.StaffId = new BaseStaffManager(DbHelper).GetIdByUserId(userInfo.Id);
                    // 数据找到了，就可以退出循环了)
                    break;
                }
            }

            // 14. 记录系统访问日志
            if (this.ReturnStatusCode == StatusCode.OK.ToString())
            {
                BaseLogManager.Instance.Add(DbHelper, userEntity.Id.ToString(), userEntity.RealName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userEntity.RealName, ipAddress, AppMessage.BaseUserManager_LogOnSuccess);
                if (string.IsNullOrEmpty(userInfo.OpenId))
                {
                    createNewOpenId = true;
                }
                if (createNewOpenId)
                {
                    userInfo.OpenId = this.UpdateVisitDate(userEntity.Id.ToString(), createNewOpenId);
                }
                else
                {
                    this.UpdateVisitDate(userEntity.Id.ToString());
                }
            }
            else
            {
                BaseLogManager.Instance.Add(DbHelper, userName, realName, "LogOn", AppMessage.BaseUserManager, "LogOn", AppMessage.BaseUserManager_LogOn, userName, ipAddress, AppMessage.MSG0090);
            }
            return userInfo;
        }
        #endregion

        #region private string UpdateVisitDate(string userId, bool createOpenId = false) 更新访问当前访问状态
        /// <summary>
        /// 更新访问当前访问状态
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="createOpenId">是否每次都产生新的OpenId</param>
        /// <returns>OpenId</returns>
        private string UpdateVisitDate(string userId, bool createOpenId = false)
        {
            string returnValue = string.Empty;

#if (DEBUG)
            int milliStart = Environment.TickCount;
#endif

            string sqlQuery = string.Empty;

            // 是否更新访问日期信息
            if (BaseSystemInfo.UpdateVisit)
            {
                // 第一次登录时间
                sqlQuery = " UPDATE " + BaseUserEntity.TableName
                         + " SET " + BaseUserEntity.FieldFirstVisit + " = " + DbHelper.GetDBNow();

                switch (DbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                        sqlQuery = sqlQuery + "  WHERE (" + BaseUserEntity.FieldId + " = " + userId + ") AND " + BaseUserEntity.FieldFirstVisit + " IS NULL";
                        break;
                    default:
                        sqlQuery = sqlQuery + "  WHERE (" + BaseUserEntity.FieldId + " = '" + userId + "') AND " + BaseUserEntity.FieldFirstVisit + " IS NULL";
                        break;
                }

                DbHelper.ExecuteNonQuery(sqlQuery);

                // 最后一次登录时间
                sqlQuery = " UPDATE " + BaseUserEntity.TableName
                            + " SET " + BaseUserEntity.FieldPreviousVisit + " = " + BaseUserEntity.FieldLastVisit + " , "
                            + BaseUserEntity.FieldUserOnLine + " = 1 , "
                            + BaseUserEntity.FieldLastVisit + " = " + DbHelper.GetDBNow() + " , "
                            + BaseUserEntity.FieldLogOnCount + " = " + BaseUserEntity.FieldLogOnCount + " + 1 ";

                switch (DbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                        sqlQuery += "  WHERE (" + BaseUserEntity.FieldId + " = " + userId + ")";
                        break;
                    default:
                        sqlQuery += "  WHERE (" + BaseUserEntity.FieldId + " = '" + userId + "')";
                        break;
                }

                DbHelper.ExecuteNonQuery(sqlQuery);
            }

            // 实现单点登录功能，每次都更换Guid
            if (createOpenId)
            {
                returnValue = BaseBusinessLogic.NewGuid();
                sqlQuery = " UPDATE " + BaseUserEntity.TableName
                         + "    SET " + BaseUserEntity.FieldOpenId + " = '" + returnValue + "'";

                switch (DbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                        sqlQuery += " WHERE (" + BaseUserEntity.FieldId + " = " + userId + ")";
                        break;
                    default:
                        sqlQuery += " WHERE (" + BaseUserEntity.FieldId + " = '" + userId + "')";
                        break;

                }

                // sqlQuery += " AND " + BaseUserEntity.FieldOpenId + " IS NULL ";
                DbHelper.ExecuteNonQuery(sqlQuery);
            }

            // 写入调试信息
#if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.UpdateVisitDate(" + userId + ")");
#endif

            return returnValue;
        }
        #endregion

        #region public int OnLine(string userId, int onLineState = 1) 用户在线
        /// <summary>
        /// 用户在线
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <returns>影响行数</returns>
        public int OnLine(string userId, int onLineState = 1)
        {
            int returnValue = 0;
            // 是否更新访问日期信息
            if (!BaseSystemInfo.UpdateVisit)
            {
                return returnValue;
            }

#if (DEBUG)
            int milliStart = Environment.TickCount;
#endif

            string sqlQuery = string.Empty;
            // 最后一次登录时间
            sqlQuery = " UPDATE " + BaseUserEntity.TableName
                     + "    SET " + BaseUserEntity.FieldUserOnLine + " = " + onLineState.ToString()
                     + " , " + BaseUserEntity.FieldLastVisit + " = " + DbHelper.GetDBNow();

            switch (DbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                    sqlQuery += "  WHERE (" + BaseUserEntity.FieldId + " = " + userId + ")";
                    break;
                default:
                    sqlQuery += "  WHERE (" + BaseUserEntity.FieldId + " = '" + userId + "')";
                    break;
            }

            returnValue += DbHelper.ExecuteNonQuery(sqlQuery);

            // 写入调试信息
#if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.OnLine(" + userId + ")");
#endif

            return returnValue;
        }
        #endregion

        #region public int OnExit(string userId) 用户退出
        /// <summary>
        /// 用户退出
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int OnExit(string userId)
        {
            int returnValue = 0;
            // 是否更新访问日期信息
            if (!BaseSystemInfo.UpdateVisit)
            {
                return returnValue;
            }

#if (DEBUG)
            int milliStart = Environment.TickCount;
#endif

            string sqlQuery = string.Empty;
            // 最后一次登录时间
            sqlQuery = " UPDATE " + BaseUserEntity.TableName
                        + " SET " + BaseUserEntity.FieldPreviousVisit + " = " + BaseUserEntity.FieldLastVisit + " , "
                        + BaseUserEntity.FieldUserOnLine + " = 0 , "
                        + BaseUserEntity.FieldLastVisit + " = " + DbHelper.GetDBNow();

            switch (DbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                    sqlQuery += "  WHERE (" + BaseUserEntity.FieldId + " = " + userId + ")";
                    break;
                default:
                    sqlQuery += "  WHERE (" + BaseUserEntity.FieldId + " = '" + userId + "')";
                    break;
            }

            returnValue += DbHelper.ExecuteNonQuery(sqlQuery);

            // 写入调试信息
#if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.OnExit(" + userId + ")");
#endif

            return returnValue;
        }
        #endregion

        // 5分钟不在线，表示用户离开

        #region public int CheckOnLine() 检查用户在线状态(服务器专用)
        /// <summary>
        /// 检查用户在线状态(服务器专用)
        /// </summary>
        /// <returns>影响行数</returns>
        public int CheckOnLine()
        {
            int returnValue = 0;
            // 是否更新访问日期信息
            if (!BaseSystemInfo.UpdateVisit)
            {
                return returnValue;
            }

#if (DEBUG)
            int milliStart = Environment.TickCount;
#endif

            string sqlQuery = string.Empty;

            // 最后一次登录时间
            switch (DbHelper.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                    sqlQuery = " UPDATE " + BaseUserEntity.TableName
                            + "     SET " + BaseUserEntity.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + BaseUserEntity.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + BaseUserEntity.FieldUserOnLine + " > 0) AND (" + BaseUserEntity.FieldLastVisit + " IS NOT NULL) AND (DATEADD (s, " + BaseSystemInfo.OnLineTime0ut.ToString() + ", " + BaseUserEntity.FieldLastVisit + ") < " + DbHelper.GetDBNow() + "))";
                    returnValue += DbHelper.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.Oracle:
                    sqlQuery = " UPDATE " + BaseUserEntity.TableName
                            + "     SET " + BaseUserEntity.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + BaseUserEntity.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + BaseUserEntity.FieldUserOnLine + " > 0) AND (" + BaseUserEntity.FieldLastVisit + " IS NOT NULL) AND ((SYSDATE - " + BaseUserEntity.FieldLastVisit + ") * 24 * 60 * 60 > " + BaseSystemInfo.OnLineTime0ut.ToString() + "))";
                    returnValue += DbHelper.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.MySql:
                    sqlQuery = " UPDATE " + BaseUserEntity.TableName
                            + "     SET " + BaseUserEntity.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + BaseUserEntity.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + BaseUserEntity.FieldUserOnLine + " > 0) AND (" + BaseUserEntity.FieldLastVisit + " IS NOT NULL) AND (DATE_ADD(" + BaseUserEntity.FieldLastVisit + ", Interval " + BaseSystemInfo.OnLineTime0ut.ToString() + " SECOND) < " + DbHelper.GetDBNow() + "))";
                    returnValue += DbHelper.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.DB2:
                    sqlQuery = " UPDATE " + BaseUserEntity.TableName
                            + "     SET " + BaseUserEntity.FieldUserOnLine + " = 0 "
                            + "   WHERE (" + BaseUserEntity.FieldLastVisit + " IS NULL) "
                            + "      OR ((" + BaseUserEntity.FieldUserOnLine + " > 0) AND (" + BaseUserEntity.FieldLastVisit + " IS NOT NULL) AND (" + BaseUserEntity.FieldLastVisit + " + " + BaseSystemInfo.OnLineTime0ut.ToString() + " SECONDS < " + DbHelper.GetDBNow() + "))";
                    returnValue += DbHelper.ExecuteNonQuery(sqlQuery);
                    break;
                case CurrentDbType.Access:
                    break;
            }

            // 写入调试信息
#if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.CheckOnLine()");
#endif

            return returnValue;
        }
        #endregion

        #region private bool CheckOnLineLimit()
        /// <summary>
        /// 同时在线用户数量限制
        /// </summary>
        /// <returns>是否符合限制</returns>
        private bool CheckOnLineLimit()
        {
            bool returnValue = false;

#if (DEBUG)
            int milliStart = Environment.TickCount;
#endif

            this.CheckOnLine();

            string sqlQuery = string.Empty;
            // 最后一次登录时间
            sqlQuery = " SELECT COUNT(*) "
                     + "   FROM " + BaseUserEntity.TableName
                     + "  WHERE " + BaseUserEntity.FieldUserOnLine + " > 0 ";
            object userOnLine = DbHelper.ExecuteScalar(sqlQuery);
            if (userOnLine != null)
            {
                if (BaseSystemInfo.OnLineLimit <= int.Parse(userOnLine.ToString()))
                {
                    returnValue = true;
                }
            }

            // 写入调试信息
#if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.CheckOnLineLimit()");
#endif

            return returnValue;
        }
        #endregion

        #region public DataTable GetOnLineStateDT() 获取列表
        /// <summary>
        /// 获取在线状态列表
        /// </summary>	
        /// <returns>数据表</returns>
        public DataTable GetOnLineStateDT()
        {
            string sqlQuery = string.Empty;

            sqlQuery = " SELECT " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId
                                         + ", " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldUserOnLine
                              + " FROM " + BaseUserEntity.TableName
                              + " WHERE " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1 "
                              + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIsVisible + " = 1 "
                              + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 "
                              + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldLastVisit + " IS NOT NULL ";

            switch (DbHelper.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                    sqlQuery += " AND (DATEADD (s, " + (BaseSystemInfo.OnLineTime0ut + 5).ToString() + ", " + BaseUserEntity.FieldLastVisit + ") > " + DbHelper.GetDBNow() + ")";
                    break;
            }
            /*
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId
                                         + ", " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldUserOnLine
                              + " FROM " + BaseUserEntity.TableName
                             + " WHERE " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1 "
                               + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIsVisible + " = 1 "
                               + " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IN (SELECT " + BaseOrganizeEntity.FieldId + " FROM " + BaseOrganizeEntity.TableName + " WHERE " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1) "
                                       + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " IN (SELECT " + BaseOrganizeEntity.FieldId + " FROM " + BaseOrganizeEntity.TableName + " WHERE " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1) "
                                       + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IN (SELECT " + BaseOrganizeEntity.FieldId + " FROM " + BaseOrganizeEntity.TableName + " WHERE " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1)) ";
            */
            return DbHelper.Fill(sqlQuery);
        }
        #endregion
    }
}