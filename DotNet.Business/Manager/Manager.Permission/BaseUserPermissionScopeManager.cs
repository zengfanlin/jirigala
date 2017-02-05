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
    /// 用户权限域
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

        #region public string[] GetPermissionItemIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;
   
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BasePermissionItemEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));

            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantPermissionItem(BasePermissionScopeManager permissionScopeManager, string id, string userId, string grantPermissionId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="userId">员工主键</param>
        /// <param name="grantPermissionId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantPermissionItem(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantPermissionId)
        {
            string returnValue = string.Empty;
            BasePermissionScopeEntity resourcePermissionScopeEntity = new BasePermissionScopeEntity();
            resourcePermissionScopeEntity.PermissionId = int.Parse(this.GetIdByCode(permissionItemCode));
            resourcePermissionScopeEntity.ResourceCategory = BaseUserEntity.TableName;
            resourcePermissionScopeEntity.ResourceId = userId;
            resourcePermissionScopeEntity.TargetCategory = BasePermissionItemEntity.TableName;
            resourcePermissionScopeEntity.TargetId = grantPermissionId;
            resourcePermissionScopeEntity.Enabled = 1;
            resourcePermissionScopeEntity.DeletionStateCode = 0;
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantPermissionItem(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantPermissionItem(string userId, string permissionItemCode, string grantPermissionId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.GrantPermissionItem(permissionScopeManager, userId, permissionItemCode, grantPermissionId);
        }
        #endregion

        public int GrantPermissionItemes(string userId, string permissionItemCode, string[] grantPermissionIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < grantPermissionIds.Length; i++)
            {
                this.GrantPermissionItem(permissionScopeManager, userId, permissionItemCode, grantPermissionIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantPermissionItemes(string[] userIds, string permissionItemCode, string grantPermissionId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantPermissionItem(permissionScopeManager, userIds[i], permissionItemCode, grantPermissionId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantPermissionItems(string[] userIds, string permissionItemCode, string[] grantPermissionIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantPermissionIds.Length; j++)
                {
                    this.GrantPermissionItem(permissionScopeManager, userIds[i], permissionItemCode, grantPermissionIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokePermissionItem(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokePermissionId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="revokePermissionId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokePermissionItem(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokePermissionId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BasePermissionItemEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokePermissionId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokePermissionItem(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokePermissionItem(string userId, string permissionItemCode, string revokePermissionId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.RevokePermissionItem(permissionScopeManager, userId, permissionItemCode, revokePermissionId);
        }
        #endregion

        public int RevokePermissionItems(string userId, string permissionItemCode, string[] revokePermissionIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < revokePermissionIds.Length; i++)
            {
                this.RevokePermissionItem(permissionScopeManager, userId, permissionItemCode, revokePermissionIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokePermissionItems(string[] userIds, string permissionItemCode, string revokePermissionId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokePermissionItem(permissionScopeManager, userIds[i], permissionItemCode, revokePermissionId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokePermissionItems(string[] userIds, string permissionItemCode, string[] revokePermissionIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokePermissionIds.Length; j++)
                {
                    this.RevokePermissionItem(permissionScopeManager, userIds[i], permissionItemCode, revokePermissionIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}