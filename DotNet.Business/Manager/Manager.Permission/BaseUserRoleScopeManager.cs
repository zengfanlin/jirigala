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
    /// 用户对角色权限域
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

        #region public string[] GetRoleIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantRole(BasePermissionScopeManager permissionScopeManager, string id, string userId, string grantRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="userId">员工主键</param>
        /// <param name="grantRoleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantRole(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantRoleId)
        {
            string returnValue = string.Empty;
            BasePermissionScopeEntity resourcePermissionScopeEntity = new BasePermissionScopeEntity();
            resourcePermissionScopeEntity.PermissionId = int.Parse(this.GetIdByCode(permissionItemCode));
            resourcePermissionScopeEntity.ResourceCategory = BaseUserEntity.TableName;
            resourcePermissionScopeEntity.ResourceId = userId;
            resourcePermissionScopeEntity.TargetCategory = BaseRoleEntity.TableName;
            resourcePermissionScopeEntity.TargetId = grantRoleId;
            resourcePermissionScopeEntity.Enabled = 1;
            resourcePermissionScopeEntity.DeletionStateCode = 0;
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantRole(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantRole(string userId, string permissionItemCode, string grantRoleId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.GrantRole(permissionScopeManager, userId, permissionItemCode, grantRoleId);
        }
        #endregion

        public int GrantRoles(string userId, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < grantRoleIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, userId, permissionItemCode, grantRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] userIds, string permissionItemCode, string grantRoleId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, userIds[i], permissionItemCode, grantRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] userIds, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantRoleIds.Length; j++)
                {
                    this.GrantRole(permissionScopeManager, userIds[i], permissionItemCode, grantRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeRole(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="revokeRoleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeRole(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeRoleId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeRoleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokeRole(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeRole(string userId, string permissionItemCode, string revokeRoleId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.RevokeRole(permissionScopeManager, userId, permissionItemCode, revokeRoleId);
        }
        #endregion

        public int RevokeRoles(string userId, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < revokeRoleIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, userId, permissionItemCode, revokeRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] userIds, string permissionItemCode, string revokeRoleId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, userIds[i], permissionItemCode, revokeRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] userIds, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokeRoleIds.Length; j++)
                {
                    this.RevokeRole(permissionScopeManager, userIds[i], permissionItemCode, revokeRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}