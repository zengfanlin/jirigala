//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// MessageService
    /// 消息服务
    /// 
    /// 修改纪录
    /// 
    ///     2011.12.11 版本：2.0 JiRiGaLa Broadcast 广播功能增强。
    ///		2011.09.28 版本：1.2 JiRiGaLa 获取用户状态，内部组织机构的方法进行改进。
    ///		2011.09.20 版本：1.1 JiRiGaLa 优化代码。
    ///		2007.10.30 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.12.11</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MessageService : System.MarshalByRefObject, IMessageService
    {
        private string serviceName = AppMessage.MessageService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;
        
        // 是否有信息被发过来
        public static bool MessageSend = true;                 
        
        // 最后检查在线状态时间
        public static DateTime LaseOnLineStateCheck = DateTime.MinValue;  
        
        // 当前的锁
        private static object locker = new Object();

        public static DataTable InnerOrganizeDT = null;

        // 最后检查组织机构时间
        public static DateTime LaseInnerOrganizeCheck = DateTime.MinValue;  

        #region public DataTable GetInnerOrganize(BaseUserInfo userInfo) 获取内部组织机构
        /// <summary>
        /// 获取内部组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetInnerOrganizeDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            // 是否需要获取用户状态
            bool getOnLine = false;

            lock (locker)
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        BaseOrganizeManager organizeManager = new BaseOrganizeManager(dbHelper, userInfo);
                        if (MessageService.LaseInnerOrganizeCheck == DateTime.MinValue)
                        {
                            getOnLine = true;
                        }
                        else
                        {
                            // 2008.01.23 JiRiGaLa 修正错误
                            TimeSpan timeSpan = DateTime.Now - MessageService.LaseInnerOrganizeCheck;
                            if ((timeSpan.Minutes * 60 + timeSpan.Seconds) >= BaseSystemInfo.OnLineCheck * 100)
                            {
                                getOnLine = true;
                            }
                        }
                        if (OnLineStateDT == null || getOnLine)
                        {
                            string commandText = " SELECT * "
                                                + " FROM " + BaseOrganizeEntity.TableName
                                                + " WHERE " + BaseOrganizeEntity.FieldDeletionStateCode + " = 0 "
                                                + " AND " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1 "
                                                + " AND " + BaseOrganizeEntity.FieldEnabled + " = 1 "
                                                + " ORDER BY " + BaseOrganizeEntity.FieldSortCode;
                            InnerOrganizeDT = organizeManager.Fill(commandText);
                            InnerOrganizeDT.TableName = BaseOrganizeEntity.TableName;
                            MessageService.LaseInnerOrganizeCheck = DateTime.Now;
                        }
                        // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    }
                    catch (Exception ex)
                    {
                        BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                        throw ex;
                    }
                    finally
                    {
                        dbHelper.Close();
                    }
                }
            }

            // 写入调试信息
            #if (DEBUG)
                if (getOnLine)
                {
                    BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
                }
            #endif

            return InnerOrganizeDT;
        }
        #endregion

        #region public DataTable GetUserDTByOrganize(BaseUserInfo userInfo, string organizeId) 按组织机构获取用户列表
        /// <summary>
        /// 按组织机构获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDTByOrganize(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif
            
            DataTable dataTable = new DataTable(BaseUserEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);

                    string sqlQuery = " SELECT " + BaseUserEntity.TableName +".* "  
                        //BaseUserEntity.TableName + "." + BaseUserEntity.FieldId
                        //                        + "," + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRealName
                        //                        + "," + BaseUserEntity.TableName + "." + BaseUserEntity.FieldUserOnLine                                                
                                        + " FROM " + BaseUserEntity.TableName;

                    sqlQuery += " WHERE (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 "
                                + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1  "
                                + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIsVisible + " = 1 ) ";

                    if (!String.IsNullOrEmpty(organizeId))
                    {
                        // 绑定在工作组上的
                        sqlQuery += " AND ((" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " = '" + organizeId + "') ";
                        // 绑定在部门上的
                        sqlQuery += " OR (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " = '" + organizeId + "' AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IS NULL) ";
                        // 绑定在分公司上的
                        sqlQuery += " OR (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSubCompanyId + " = '" + organizeId + "' AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IS NULL AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IS NULL) ";
                        // 绑定在公司上的
                        sqlQuery += " OR (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " = '" + organizeId + "' AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSubCompanyId + " IS NULL AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IS NULL AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IS NULL)) ";
                        // 从兼职表读取用户
                        /*
                        sqlQuery += " OR " + BaseUserEntity.FieldId + " IN ("
                                + " SELECT " + BaseUserOrganizeEntity.FieldUserId
                                + "   FROM " + BaseUserOrganizeEntity.TableName
                                + "  WHERE (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldDeletionStateCode + " = 0 ) "
                                + "       AND (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldDepartmentId + " = '" + organizeId + "' AND " + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldWorkgroupId + " IS NULL "
                                + "            OR (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldWorkgroupId + " = '" + organizeId + "')))) ";
                        */
                    }
                    sqlQuery += " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;
                    dataTable = userManager.Fill(sqlQuery);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_GetUserDTByDepartment, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }
        #endregion


        #region public DataTable GetUserDTByRole(BaseUserInfo userInfo, string roleId) 按角色获取用户列表
        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDTByRole(BaseUserInfo userInfo, string roleId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif
            
            DataTable dataTable = new DataTable(BaseUserEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);

                    string sqlQuery = " SELECT " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId
                                                + "," + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRealName
                                                + "," + BaseUserEntity.TableName + "." + BaseUserEntity.FieldUserOnLine                                                
                                        + " FROM " + BaseUserEntity.TableName;

                    sqlQuery += " WHERE (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 "
                                + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1  "
                                + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIsVisible + " = 1 ) ";

                    if (!String.IsNullOrEmpty(roleId))
                    {
                        // 从用户默认橘色
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRoleId + " = '" + roleId + "') ";
                        // 从兼职表读取用户
                        sqlQuery += " OR " + BaseUserEntity.FieldId + " IN ("
                                + " SELECT " + BaseUserRoleEntity.FieldUserId
                                + "   FROM " + BaseUserRoleEntity.TableName
                                + "  WHERE " + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldDeletionStateCode + " = 0  "
                                + "       AND " + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldEnabled + " = 1  "
                                + "       AND " + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldRoleId + " = '" + roleId + "') ";
                    }
                    sqlQuery += " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;

                    dataTable = userManager.Fill(sqlQuery);
                    dataTable.TableName = BaseUserEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_GetUserDTByDepartment, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }
        #endregion

        #region public string Send(BaseUserInfo userInfo, string receiverId, string contents) 发送消息
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        public string Send(BaseUserInfo userInfo, string receiverId, string contents)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseMessageEntity messageEntity = new BaseMessageEntity();
                    messageEntity.Id = Guid.NewGuid().ToString();
                    messageEntity.CategoryCode = MessageCategory.Send.ToString();
                    messageEntity.FunctionCode = MessageFunction.Message.ToString();
                    messageEntity.ReceiverId = receiverId;
                    messageEntity.Contents = contents;
                    messageEntity.IsNew = (int)MessageStateCode.New;
                    messageEntity.ReadCount = 0;
                    messageEntity.DeletionStateCode = 0;
                    messageEntity.Enabled = 1;
                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    messageManager.Send(messageEntity, true);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_Send, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public string Remind(BaseUserInfo userInfo, string receiverId, string contents) 发送系统提示消息
        /// <summary>
        /// 发送系统提示消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        public string Remind(BaseUserInfo userInfo, string receiverId, string contents)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseMessageEntity entity = new BaseMessageEntity();
                    entity.Id = Guid.NewGuid().ToString();
                    entity.CategoryCode = MessageCategory.Receiver.ToString();
                    entity.FunctionCode = MessageFunction.Remind.ToString();
                    entity.ReceiverId = receiverId;
                    entity.Contents = contents;
                    entity.IsNew = (int)MessageStateCode.New;
                    entity.ReadCount = 0;
                    entity.DeletionStateCode = 0;
                    entity.Enabled = 1;
                    BaseMessageManager manager = new BaseMessageManager(dbHelper, userInfo);
                    returnValue = manager.Add(entity);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_Send, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion


        /// <summary>
        /// 批量发送站内信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverIds">接受者主键数组</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="messageEntity">消息内容</param>
        /// <returns>影响行数</returns>
        public int BatchSend(BaseUserInfo userInfo, string[] receiverIds, string[] organizeIds, string[] roleIds, BaseMessageEntity messageEntity)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    returnValue = messageManager.BatchSend(receiverIds, organizeIds, roleIds, messageEntity, true);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_BatchSend, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="message">消息内容</param>
        /// <returns>主键</returns>
        public int Broadcast(BaseUserInfo userInfo, string message)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    string[] receiverIds = null;
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    receiverIds = userManager.GetIds(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1), new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    BaseMessageEntity messageEntity = new BaseMessageEntity();
                    messageEntity.Id = BaseBusinessLogic.NewGuid();
                    messageEntity.FunctionCode = MessageFunction.Remind.ToString();
                    messageEntity.Contents = message;
                    messageEntity.IsNew = 1;
                    messageEntity.ReadCount = 0;
                    messageEntity.Enabled = 1;
                    messageEntity.DeletionStateCode = 0;
                    returnValue = messageManager.BatchSend(receiverIds, string.Empty, string.Empty, messageEntity, false);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_BatchSend, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;

        }


        #region public string[] MessageChek(BaseUserInfo userInfo, string lastChekDate) 获取消息状态
        /// <summary>
        /// 获取消息状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <param name="lastChekDate">最后检查日期</param>
        /// <returns>消息状态数组</returns>
        public string[] MessageChek(BaseUserInfo userInfo, int onLineState, string lastChekDate)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string[] returnValue = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 设置为在线状态
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    userManager.OnLine(userInfo.Id, onLineState);
                    // 读取信息状态
                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    returnValue = messageManager.MessageChek();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_MessageChek, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion


        #region public DataTable GetDataTableNew(BaseUserInfo userInfo, out string openId) 获取用户的新信息
        /// <summary>
        /// 获取用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">单点登录标识</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableNew(BaseUserInfo userInfo, out string openId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            openId = userInfo.OpenId;
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    if (!BaseSystemInfo.CheckOnLine)
                    {
                        BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                        openId = userManager.GetProperty(userInfo.Id, BaseUserEntity.FieldOpenId);
                    }
                    if (userInfo.OpenId.Equals(openId))
                    {
                        BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                        dataTable = messageManager.GetDataTableNew();
                        dataTable.TableName = BaseMessageEntity.TableName;
                    }
                    // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, "获取用户的新信息", MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }
        #endregion

        #region public DataTable ReadFromReceiver(BaseUserInfo userInfo, string receiverId) 获取特定用户的新信息
        /// <summary>
        /// 获取特定用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">当前交互的用户</param>
        /// <returns>数据表</returns>
        public DataTable ReadFromReceiver(BaseUserInfo userInfo, string receiverId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    dataTable = messageManager.ReadFromReceiver(receiverId);
                    dataTable.TableName = BaseMessageEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_ReadFromReceiver, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }
        #endregion

        #region public void Read(BaseUserInfo userInfo, string id) 阅读消息
        /// <summary>
        /// 阅读消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        public void Read(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseMessageManager messageManager = new BaseMessageManager(dbHelper, userInfo);
                    messageManager.Read(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.MessageService_Read, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
        }
        #endregion

        #region public int CheckOnLine(BaseUserInfo userInfo, int onLineState) 检查在线状态
        /// <summary>
        /// 检查在线状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <returns>离线人数</returns>
        public int CheckOnLine(BaseUserInfo userInfo, int onLineState)
        {
            // 写入调试信息
            #if (DEBUG)
                // int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserManager userManager = new BaseUserManager(dbHelper);
                    // 设置为在线状态
                    userManager.OnLine(userInfo.Id, onLineState);
                    returnValue = userManager.CheckOnLine();
                }
                catch (Exception ex)
                {
                    LogUtil.WriteException(ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                // BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        public static DataTable OnLineStateDT = null;
        
        #region public DataTable GetOnLineState(BaseUserInfo userInfo) 获取在线用户列表
        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetOnLineState(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 是否需要获取用户状态
            bool getOnLine = false;

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            lock (locker)
            {
                using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
                {
                    try
                    {
                        dbHelper.Open(UserCenterDbConnection);
                        BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                        // 设置为在线状态
                        userManager.OnLine(userInfo.Id);
                        if (MessageService.LaseOnLineStateCheck == DateTime.MinValue)
                        {
                            getOnLine = true;
                        }
                        else
                        {
                            // 2008.01.23 JiRiGaLa 修正错误
                            TimeSpan timeSpan = DateTime.Now - MessageService.LaseOnLineStateCheck;
                            if ((timeSpan.Minutes * 60 + timeSpan.Seconds) >= BaseSystemInfo.OnLineCheck)
                            {
                                getOnLine = true;
                            }
                        }
                        if (OnLineStateDT == null || getOnLine)
                        {
                            // 检查用户在线状态(服务器专用)
                            userManager.CheckOnLine();
                            // 获取在线状态列表
                            OnLineStateDT = userManager.GetOnLineStateDT();
                            OnLineStateDT.TableName = BaseUserEntity.TableName;
                            MessageService.LaseOnLineStateCheck = DateTime.Now;
                        }
                        // BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    }
                    catch (Exception ex)
                    {
                        BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                        throw ex;
                    }
                    finally
                    {
                        dbHelper.Close();
                    }
                }
            }

            // 写入调试信息
            #if (DEBUG)
                if (getOnLine)
                {
                    BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
                }
            #endif

            return OnLineStateDT;
        }
        #endregion
    }
}