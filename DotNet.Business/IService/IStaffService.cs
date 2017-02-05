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
    /// IStaffService
    /// 
    /// 修改纪录
    /// 
    ///		2010.04.08 版本：2.0 JiRiGaLa 面向对象的方式进行改进。
    ///		2008.04.05 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.05</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IStaffService
    {
        /// <summary>
        /// 获取内部通讯录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="search">查询内容</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetAddressDataTable(BaseUserInfo userInfo, string organizeId, string searchValue);

        /// <summary>
        /// 获取内部通讯录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="search">查询内容</param>
        /// <param name="pageSize">分页的条数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetAddressDataTableByPage(BaseUserInfo userInfo, string organizeId, string searchValue, int pageSize, int pageIndex, out int recordCount);

        /// <summary>
        /// 更新通讯地址
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntity">实体</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateAddress(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新通讯地址
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntites">实体</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchUpdateAddress(BaseUserInfo userInfo, List<BaseStaffEntity> staffEntites, out string statusCode, out string statusMessage);

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddStaff(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateStaff(BaseUserInfo userInfo, BaseStaffEntity staffEntity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 获得员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        [OperationContract]
        BaseStaffEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 按主键获取
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 按部门获取部门员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="DepartmentId">部门主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByDepartment(BaseUserInfo userInfo, string departmentId, bool containChildren);

        /// <summary>
        /// 获得员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByOrganize(BaseUserInfo userInfo, string organizeId, bool containChildren);

        /// <summary>
        /// 获取子节点成员
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetChildrenStaffs(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 获取父子节点成员
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetParentChildrenStaffs(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 获得员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(BaseUserInfo userInfo, string organizeId, string searchValue);

        /// <summary>
        /// 设置员工关联的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetStaffUser(BaseUserInfo userInfo, string staffId, string userId);


        /// <summary>
        /// 删除员工关联的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int DeleteUser(BaseUserInfo userInfo, string staffId);

        /// <summary>
        /// 单个删除
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
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">主键</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(BaseUserInfo userInfo, string id, string organizeId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">主键数组</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string organizeId);

        /// <summary>
        /// 批量保存员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable); 

        /// <summary>
        /// 重新排序数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ResetSortCode(BaseUserInfo userInfo);

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        string GetId(BaseUserInfo userInfo, string name, object value); 
    }
}