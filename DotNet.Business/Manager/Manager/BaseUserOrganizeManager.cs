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
    /// BaseUserOrganizeManager
    /// 用户-组织结构关系管理
    /// 
    /// 修改纪录
    /// 
    ///     2010.09.25 版本：1.0 JiRiGaLa	创建。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.09.25</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserOrganizeManager : BaseManager
    {
        #region public string Add(BaseUserOrganizeEntity userOrganizeEntity, out string statusCode) 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userOrganizeEntity">用户组织机构实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>主键</returns>
        public string Add(BaseUserOrganizeEntity userOrganizeEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 判断数据是否重复了
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldDeletionStateCode, 0));
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldUserId, userOrganizeEntity.UserId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldCompanyId, userOrganizeEntity.CompanyId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldDepartmentId, userOrganizeEntity.DepartmentId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldWorkgroupId, userOrganizeEntity.WorkgroupId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldRoleId, userOrganizeEntity .RoleId));
            if (this.Exists(parameters))
            {
                // 用户名已重复
                statusCode = StatusCode.Exist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(userOrganizeEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion
        
        /// <summary>
        /// 获得用户的组织机构兼职情况
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserOrganizeDT(string userId)
        {
            string sqlQuery = string.Empty ;
            switch (BaseSystemInfo.UserCenterDbType)
            {
                case CurrentDbType.Access:
                    sqlQuery = " SELECT A.* , E.Code AS RoleCode , E.RealName AS RoleName " +
                               " , B.FullName AS CompanyName " +
                               " , C.FullName AS DepartmentName " +
                               " , D.FullName AS WorkgroupName " +

                               " FROM ((((BaseUserOrganize A Inner JOIN BaseRole E ON A.RoleId = E.Id)" +
                               " left JOIN BaseOrganize B ON A.CompanyId = B.Id )" +
                               " left JOIN BaseOrganize C ON A.DepartmentId = C.Id)" +
                               " left JOIN BaseOrganize D ON A.WorkgroupId = D.Id )" +

                               " WHERE UserId = " + userId;
                    break;
                default:
                    sqlQuery = " SELECT BaseUserOrganize.* "
                             + " , BaseRole.Code AS RoleCode "
                             + " , BaseRole.RealName AS RoleName "
                             + " , BaseOrganize1.FullName AS CompanyName "
                             + " , BaseOrganize2.FullName AS DepartmentName "
                             + " , BaseOrganize3.FullName AS WorkgroupName "

                             + " FROM BaseUserOrganize LEFT OUTER JOIN "
                             + " BaseOrganize BaseOrganize1 ON BaseUserOrganize.CompanyId = BaseOrganize1.Id LEFT OUTER JOIN "
                             + " BaseOrganize BaseOrganize2 ON BaseUserOrganize.DepartmentId = BaseOrganize2.Id LEFT OUTER JOIN "
                             + " BaseOrganize BaseOrganize3 ON BaseUserOrganize.WorkgroupId = BaseOrganize3.Id LEFT OUTER JOIN "
                             + " BaseRole ON BaseUserOrganize.RoleId = BaseRole.Id "
                             + " WHERE UserId = '" + userId + "'";
                    break;
            }

            return DbHelper.Fill(sqlQuery);
        }
    }
}