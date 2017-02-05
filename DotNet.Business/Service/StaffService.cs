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
    /// StaffService
    /// 员工服务
    /// 
    /// 修改纪录
    ///		2007.05.22 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.22</date>
    /// </author> 
    /// </summary>
   [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class StaffService : System.MarshalByRefObject, IStaffService
    {
        private string serviceName = AppMessage.StaffService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public DataTable GetAddressDataTable(BaseUserInfo userInfo, string organizeId, string searchValue)
        /// <summary>
        /// 获取内部通讯录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="search">查询内容</param>
        /// <returns>数据表</returns>
        public DataTable GetAddressDataTable(BaseUserInfo userInfo, string organizeId, string searchValue)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.GetAddressDataTable(organizeId, searchValue);
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetAddressDT, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetAddressDataTableByPage(BaseUserInfo userInfo, string organizeId, string searchValue, int pageSize, int pageIndex,out int recordCount)
        /// <summary>
        /// 获取内部通讯录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="search">查询内容</param>
        /// <param name="pageSize">分页的条数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <returns>数据表</returns>
        public DataTable GetAddressDataTableByPage(BaseUserInfo userInfo, string organizeId, string searchValue, int pageSize, int pageIndex, out int recordCount)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.GetAddressDataTableByPage(out recordCount, pageSize, pageIndex, organizeId, searchValue);
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetAddressPageDT, MethodBase.GetCurrentMethod());
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

        #region public int UpdateAddressDT(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage) 更新通讯地址
        /// <summary>
        /// 更新通讯地址
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        public int UpdateAddress(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage)
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
                    statusCode = string.Empty;
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    // for (int i = 0; i < dataTable.Rows.Count; i++)
                    // {
                    returnValue += staffManager.UpdateAddress(staffEntity, out statusCode);
                    // }
                    statusMessage = staffManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_UpdateAddress, MethodBase.GetCurrentMethod());
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
        /// 批量更新通讯地址
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntites">实体</param>
        /// <returns>影响行数</returns>
        public int BatchUpdateAddress(BaseUserInfo userInfo, List<BaseStaffEntity> staffEntites, out string statusCode, out string statusMessage)
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
                    statusCode = string.Empty;
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    for (int i = 0; i < staffEntites.Count; i++)
                    {
                        returnValue += staffManager.UpdateAddress(staffEntites[i], out statusCode);
                    }
                    statusMessage = staffManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_BatchUpdateAddress, MethodBase.GetCurrentMethod());
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
        
        #region public string AddStaff(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage) 添加员工
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        public string AddStaff(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage)
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
                    // 1.若添加用户成功，添加员工。
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.Add(staffEntity, out statusCode);
                    statusMessage = staffManager.GetStateMessage(statusCode);
                    // 2.自己不用给自己发提示信息，这个提示信息是为了提高工作效率的
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_AddStaff, MethodBase.GetCurrentMethod());
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

        #region public int UpdateStaff(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage) 更新员工
        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        public int UpdateStaff(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            if (!BaseSystemInfo.IsAuthorized(userInfo))
            {
                throw new Exception(AppMessage.MSG0800);
            }

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 3.员工的修改
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.Update(staffEntity, out statusCode);
                    statusMessage = staffManager.GetStateMessage(statusCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_UpdateStaff, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTable(BaseUserInfo userInfo) 获取员工列表
        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.GetDataTable(new KeyValuePair<string, object>(BaseStaffEntity.FieldDeletionStateCode, 0), BaseStaffEntity.FieldSortCode);
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetDataTable, MethodBase.GetCurrentMethod());
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

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public BaseStaffEntity GetEntity(BaseUserInfo userInfo, string id)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif
            
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            BaseStaffEntity staffEntity = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    staffEntity = staffManager.GetEntity(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetEntity, MethodBase.GetCurrentMethod());
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

            return staffEntity;
        }

        #region public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids) 获取员工列表
        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">组织主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.GetDataTable(BaseStaffEntity.FieldId, ids, BaseStaffEntity.FieldSortCode);
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetDataTableByIds, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByDepartment(BaseUserInfo userInfo, string departmentId, bool containChildren) 按部门获取员工列表
        /// <summary>
        /// 按部门获取员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByDepartment(BaseUserInfo userInfo, string departmentId, bool containChildren)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    if (containChildren)
                    {
                        dataTable = staffManager.GetChildrenStaffs(departmentId);
                    }
                    else
                    {
                        dataTable = staffManager.GetDataTableByDepartment(departmentId);
                    }
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetDataTableByDepartment, MethodBase.GetCurrentMethod());
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

        #region public DataTable GetDataTableByOrganize(BaseUserInfo BaseUserInfo, string organizeId, bool containChildren) 按公司获取员工列表
        /// <summary>
        /// 按公司获取员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByOrganize(BaseUserInfo userInfo, string organizeId, bool containChildren)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 用户已经不存在的需要整理干净，防止数据不完整。
                    string sqlQuery = "UPDATE BaseStaff SET UserId = NULL WHERE (UserId NOT IN (SELECT Id FROM BaseUser))";
                    dbHelper.ExecuteNonQuery(sqlQuery);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    if (containChildren)
                    {
                        dataTable = staffManager.GetChildrenStaffs(organizeId);
                    }
                    else
                    {
                        dataTable = staffManager.GetDataTableByOrganize(organizeId);
                    }
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_GetDataTableByOrganize, MethodBase.GetCurrentMethod());
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

        public DataTable GetChildrenStaffs(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.GetChildrenStaffs(organizeId);
                    dataTable.DefaultView.Sort = BaseStaffEntity.FieldSortCode;
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        public DataTable GetParentChildrenStaffs(BaseUserInfo userInfo, string organizeId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    // 获得组织机构列表
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.GetParentChildrenStaffs(organizeId);
                    dataTable.DefaultView.Sort = BaseStaffEntity.FieldSortCode;
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public DataTable Search(BaseUserInfo userInfo, string organizeId, string searchValue) 获得员工列表
        /// <summary>
        /// 获得员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织主键</param>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(BaseUserInfo userInfo, string organizeId, string searchValue)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseStaffEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    dataTable = staffManager.Search(organizeId, searchValue, false);
                    dataTable.TableName = BaseStaffEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int SetStaffUser(BaseUserInfo userInfo, string staffId, string userId)
        /// <summary>
        /// 员工关联用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int SetStaffUser(BaseUserInfo userInfo, string staffId, string userId)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    if (string.IsNullOrEmpty(userId))
                    {
                        returnValue = staffManager.SetProperty(staffId, new KeyValuePair<string, object>(BaseStaffEntity.FieldUserId, userId));
                    }
                    else
                    {
                        // 一个用户只能帮定到一个帐户上，检查是否已经绑定过这个用户了。
                        string[] staffIds = staffManager.GetIds(new KeyValuePair<string, object>(BaseStaffEntity.FieldUserId, userId), new KeyValuePair<string, object>(BaseStaffEntity.FieldDeletionStateCode, 0));
                        if (staffIds == null || staffIds.Length == 0)
                        {
                            returnValue = staffManager.SetProperty(staffId, new KeyValuePair<string, object>(BaseStaffEntity.FieldUserId, userId));
                            BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                            BaseUserEntity userEntity = userManager.GetEntity(userId);
                            returnValue = staffManager.SetProperty(staffId, new KeyValuePair<string, object>(BaseStaffEntity.FieldUserName, userEntity.UserName));
                        }
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, AppMessage.StaffService_SetStaffUser, MethodBase.GetCurrentMethod());
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

            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            return returnValue;
        }
        #endregion

        #region public int DeleteUser(BaseUserInfo userInfo, string staffId)
        /// <summary>
        /// 删除员工关联的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <returns>影响行数</returns>
        public int DeleteUser(BaseUserInfo userInfo, string staffId)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.DeleteUser(staffId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public int Delete(BaseUserInfo userInfo, string id) 单个删除
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(BaseUserInfo userInfo, string id)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.Delete(id);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif
            
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(BaseUserInfo userInfo, string[] ids) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(BaseUserInfo userInfo, string[] ids)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.BatchDelete(ids);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int SetDeleted(BaseUserInfo userInfo, string[] ids) 批量打删除标志
        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(BaseUserInfo userInfo, string[] ids)
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
                    BaseUserManager userManager = new BaseUserManager(dbHelper, userInfo);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    BaseStaffEntity staffEntity = null;
                    for (int i = 0; i < ids.Length; i++)
                    {
                        // 删除相应的用户
                        staffEntity = staffManager.GetEntity(ids[i]);
                        if (staffEntity.UserId != null)
                        {   
                            userManager.SetDeleted(staffEntity.UserId);
                        }
                        // 删除职员
                        returnValue = staffManager.SetDeleted(ids[i], true);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int MoveTo(BaseUserInfo userInfo, string id, string organizeId) 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="organizeId">父结点主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(BaseUserInfo userInfo, string id, string organizeId)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.SetProperty(id, new KeyValuePair<string, object>(BaseStaffEntity.FieldDepartmentId, organizeId));
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string organizeId) 移动数据
        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="organizeId">父结点主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string organizeId)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        returnValue += staffManager.SetProperty(ids[i], new KeyValuePair<string, object>(BaseStaffEntity.FieldDepartmentId, organizeId));
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int ChangeDepartment(BaseUserInfo userInfo, string id, string CompanyId, string DepartmentId) 部门变动
        /// <summary>
        /// 部门变动
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">员工主键</param>
        /// <param name="companyId">单位主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <returns>影响行数</returns>
        public int ChangeDepartment(BaseUserInfo userInfo, string id, string companyId, string departmentId)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldCompanyId, companyId));
                    parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldDepartmentId, departmentId));
                    returnValue = staffManager.SetProperty(new KeyValuePair<string, object>(BaseStaffEntity.FieldId, id), parameters);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int BatchSave(BaseUserInfo userInfo, DataTable dataTable) 批量保存员工
        /// <summary>
        /// 批量保存员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(BaseUserInfo userInfo, DataTable dataTable)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper, userInfo);
                    returnValue = staffManager.BatchSave(dataTable);
                    // ReturnDataTable = Staff.GetDataTableByOrganize(organizeId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region public int ResetSortCode(BaseUserInfo userInfo) 重新排序数据
        /// <summary>
        /// 重新排序数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>影响行数</returns>
        public int ResetSortCode(BaseUserInfo userInfo)
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
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper);
                    returnValue = staffManager.ResetSortCode();
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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

        #region  public string GetId(BaseUserInfo userInfo,string name, object value) 获取主键
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">查询的参数</param>
        /// <param name="value">参数值</param>
        /// <returns>影响行数</returns>
        public string GetId(BaseUserInfo userInfo, string name, object value)
        {
              // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif
            string returnValue=string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
            {
                try
                {
                    dbHelper.Open(UserCenterDbConnection);
                    BaseStaffManager staffManager = new BaseStaffManager(dbHelper);
                    returnValue = staffManager.GetId(new KeyValuePair<string, object>(name, value));
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
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
    }
}