//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2012.04.12 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.12</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        /// <summary>
        /// 获取有岗位的组织机构主键
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="dutyName">岗位名称</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIdsByDutyName(string userId = null, string dutyName = "部门主管")
        {
            // 这里需要一个转换的过程，先找到系统角色里这个角色是什么编号
            string dutyCode = "Manager";
            BaseRoleManager roleManager = new BaseRoleManager(this.UserInfo);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, dutyName));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "SystemRole"));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
            roleManager.GetId(parameters);
            // 这里需要返回公司的主键数组
            return GetOrganizeIdsByDuty(userId, dutyCode);
        }

        /// <summary>
        /// 获取有岗位的组织机构主键
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="dutyCode">岗位主键</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIdsByDuty(string userId = null, string dutyCode = "Manager")
        {
            // 定义返回值
            string[] returnValue = null;
            // 当前用户主键确定
            if (!string.IsNullOrEmpty(userId))
            {
                userId = this.UserInfo.Id;
            }
            // 当前用户的所有角色
            string[] roleIds = GetAllRoleIds(userId);
            // 当前角色拥有的所有的岗位的组织机构主键数组
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldId, roleIds));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, dutyCode));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "Duty"));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
            returnValue = this.GetProperties(parameters, BaseRoleEntity.FieldOrganizeId);
            // 返回所有的组织机构主键
            return returnValue;
        }
    }
}