//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;
    
    /// <summary>
    /// IOrganizeService
    /// 
    /// 修改纪录
    /// 
    ///		2008.03.23 版本：1.0 JiRiGaLa 添加权限。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.03.23</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IOrganizeService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseOrganizeEntity organizeEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父级主键</param>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="categoryId">类别</param>
        /// <param name="outerPhone">外线</param>
        /// <param name="innerPhone">内线</param>
        /// <param name="fax">传真</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddByDetail(BaseUserInfo userInfo, string parentId, string code, string fullName, string categoryId, string outerPhone, string innerPhone, string fax, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">组织机构主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 获得部门列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parameters">参数</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo, List<KeyValuePair<string, object>> parameters);

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父亲节点主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByParent(BaseUserInfo userInfo, string parentId);

        /// <summary>
        /// 获取内部部门
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetInnerOrganizeDT(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetCompanyDT(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 获得部门的列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDepartmentDT(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 搜索部门
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">主键</param>
        /// <param name="search">查询字符</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(BaseUserInfo userInfo, string organizeId, string searchValue);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseOrganizeEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 更新一个
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BaseOrganizeEntity organizeEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(BaseUserInfo userInfo, string organizeId, string parentId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string[] organizeIds, string parentId);

        /// <summary>
        /// 保存组织机构编号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="codes">编号数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSetCode(BaseUserInfo userInfo, string[] ids, string[] codes);

        /// <summary>
        /// 保存组织机构排序顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSetSortCode(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构名称</param>
        /// <returns>数据表</returns>
        DataTable GetCompanyDTByName(BaseUserInfo userInfo, string organizeName);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构名称</param>
        /// <returns>数据表</returns>
        DataTable GetDepartmentDTByName(BaseUserInfo userInfo, string organizeName);
    }
}