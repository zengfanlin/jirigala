//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;
    
    /// <summary>
    /// IPermissionService
    /// 与权限判断等相关的接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2012.03.22 版本：1.0 JiRiGaLa 添加权限。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.22</date>
    /// </author> 
    /// </summary>
    public partial interface IPermissionService
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 资源权限设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 获取资源权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetResourcePermissionItemIds(BaseUserInfo userInfo, string resourceCategory, string resourceId);

        /// <summary>
        /// 授予资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="grantPermissionItemIds">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantResourcePermission(BaseUserInfo userInfo, string resourceCategory, string resourceId, string[] grantPermissionItemIds);

        /// <summary>
        /// 撤消资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="revokePermissionItemIds">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeResourcePermission(BaseUserInfo userInfo, string resourceCategory, string resourceId, string[] revokePermissionItemIds);


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 资源权限范围设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 获取资源权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetPermissionScopeTargetIds(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemCode);

        /// <summary>
        /// 获取数据权限目标主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="targetResourceId">资源主键</param>
        /// <param name="targetResourceCategory">目标资源</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetPermissionScopeResourceIds(BaseUserInfo userInfo, string resourceCategory, string targetResourceId, string targetResourceCategory, string permissionItemCode);

        /// <summary>
        /// 授予资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="grantTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantPermissionScopeTargets(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId);

        /// <summary>
        /// 授予数据权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceIds">资源主键数组</param>
        /// <param name="targetCategory">目标资源类别</param>
        /// <param name="grantTargetId">目标资源主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int GrantPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId);

        /// <summary>
        /// 撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokePermissionScopeTargets(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId);

        /// <summary>
        /// 撤销数据权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceIds">资源主键数组</param>
        /// <param name="targetCategory">目标分类</param>
        /// <param name="revokeTargetId">目标主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int RevokePermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId);

        /// <summary>
        /// 清除数据权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ClearPermissionScopeTarget(BaseUserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemId);

        /// <summary>
        /// 获取用户的某个资源的权限范围(列表资源)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetResourceScopeIds(BaseUserInfo userInfo, string userId, string targetCategory, string permissionItemCode);

        /// <summary>
        /// 获取用户的某个资源的权限范围(树型资源)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">是否含子节点</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetTreeResourceScopeIds(BaseUserInfo userInfo, string userId, string targetCategory, string permissionItemCode, bool childrens);
    }
}