//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserScopeManager
    /// 用户模块权限域
    /// 
    /// 修改纪录
    ///
    ///     2011.03.13 版本：2.0 JiRiGaLa 重新整理代码。
    ///     2008.05.24 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.03.13</date>
    /// </author>
    /// </summary>
    public partial class BaseUserScopeManager : BaseManager, IBaseManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetModuleIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetModuleIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseModuleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));

            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantModule(BasePermissionScopeManager permissionScopeManager, string id, string userId, string grantModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="userId">员工主键</param>
        /// <param name="grantModuleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantModule(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            BasePermissionScopeEntity resourcePermissionScopeEntity = new BasePermissionScopeEntity();
            string permissionId = this.GetIdByCode(permissionItemCode);
            if (string.IsNullOrEmpty(permissionId))
            {
                return string.Empty;
            }
            resourcePermissionScopeEntity.PermissionId = int.Parse(permissionId);
            resourcePermissionScopeEntity.ResourceCategory = BaseUserEntity.TableName;
            resourcePermissionScopeEntity.ResourceId = userId;
            resourcePermissionScopeEntity.TargetCategory = BaseModuleEntity.TableName;
            resourcePermissionScopeEntity.TargetId = grantModuleId;
            resourcePermissionScopeEntity.Enabled = 1;
            resourcePermissionScopeEntity.DeletionStateCode = 0;
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantModule(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantModule(string userId, string permissionItemCode, string grantModuleId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.GrantModule(permissionScopeManager, userId, permissionItemCode, grantModuleId);
        }
        #endregion

        public int GrantModules(string userId, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < grantModuleIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, userId, permissionItemCode, grantModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] userIds, string permissionItemCode, string grantModuleId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantModule(permissionScopeManager, userIds[i], permissionItemCode, grantModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantModules(string[] userIds, string permissionItemCode, string[] grantModuleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantModuleIds.Length; j++)
                {
                    this.GrantModule(permissionScopeManager, userIds[i], permissionItemCode, grantModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeModule(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeModuleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="revokeModuleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeModule(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeModuleId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseModuleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeModuleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokeModule(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeModule(string userId, string permissionItemCode, string revokeModuleId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.RevokeModule(permissionScopeManager, userId, permissionItemCode, revokeModuleId);
        }
        #endregion

        public int RevokeModules(string userId, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < revokeModuleIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, userId, permissionItemCode, revokeModuleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] userIds, string permissionItemCode, string revokeModuleId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokeModule(permissionScopeManager, userIds[i], permissionItemCode, revokeModuleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeModules(string[] userIds, string permissionItemCode, string[] revokeModuleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokeModuleIds.Length; j++)
                {
                    this.RevokeModule(permissionScopeManager, userIds[i], permissionItemCode, revokeModuleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}