//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Business
{
    /// <summary>
    /// IServiceFactory
    /// 服务工厂接口定义
    /// 
    /// 修改纪录
    /// 
    ///	    2011.05.07 版本：3.0 JiRiGaLa 整理目录结构。
    ///	    2011.04.30 版本：2.0 JiRiGaLa 修改注释。
    ///	    2007.12.30 版本：1.0 JiRiGaLa 创建。
    ///	    
    /// 版本：3.0
    /// <author>
    ///     <name>JiRiGaLa</name>
    ///     <date>2011.05.07</date>
    /// </author> 
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// 初始化服务
        /// </summary>
        void InitService();

        /// <summary>
        /// 创建名片服务
        /// </summary>
        /// <returns>服务接口</returns>
        // IBusinessCardService CreateBusinessCardService();

        /// <summary>
        /// 创建登录服务
        /// </summary>
        /// <returns>服务接口</returns>
        ILogOnService CreateLogOnService();

        /// <summary>
        /// 创建序列服务
        /// </summary>
        /// <returns>服务接口</returns>
        ISequenceService CreateSequenceService();

        /// <summary>
        /// 创建用户服务
        /// </summary>
        /// <returns>服务接口</returns>
        IUserService CreateUserService();

        /// <summary>
        /// 创建日志服务
        /// </summary>
        /// <returns>服务接口</returns>
        ILogService CreateLogService();

        /// <summary>
        /// 创建异常服务
        /// </summary>
        /// <returns>服务接口</returns>
        IExceptionService CreateExceptionService();

        /// <summary>
        /// 创建权限管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        IPermissionItemService CreatePermissionItemService();

        /// <summary>
        /// 创建部门管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        IOrganizeService CreateOrganizeService();

        /// <summary>
        /// 创建选项服务
        /// </summary>
        /// <returns>服务接口</returns>
        IItemsService CreateItemsService();

        /// <summary>
        /// 创建选项明细服务
        /// </summary>
        /// <returns>服务接口</returns>
        IItemDetailsService CreateItemDetailsService();

        /// <summary>
        /// 创建模块服务
        /// </summary>
        /// <returns>服务接口</returns>
        IModuleService CreateModuleService();

        /// <summary>
        /// 创建员工服务
        /// </summary>
        /// <returns>服务接口</returns>
        IStaffService CreateStaffService();

        /// <summary>
        /// 创建角色服务
        /// </summary>
        /// <returns>服务接口</returns>
        IRoleService CreateRoleService();

        /// <summary>
        /// 创建消息服务
        /// </summary>
        /// <returns>服务接口</returns>
        IMessageService CreateMessageService();

        /// <summary>
        /// 创建文件服务
        /// </summary>
        /// <returns>服务接口</returns>
        IFileService CreateFileService();

        /// <summary>
        /// 创建目录服务
        /// </summary>
        /// <returns>服务接口</returns>
        IFolderService CreateFolderService();

        /// <summary>
        /// 创建参数服务
        /// </summary>
        /// <returns>服务接口</returns>
        IParameterService CreateParameterService();

        /// <summary>
        /// 创建权限服务
        /// </summary>
        /// <returns>服务接口</returns>
        IPermissionService CreatePermissionService();

        /// <summary>
        /// 创建业务数据库服务
        /// </summary>
        /// <returns>服务接口</returns>
        IDbHelperService CreateBusinessDbHelperService();

        /// <summary>
        /// 创建用户中心数据库服务
        /// </summary>
        /// <returns>服务接口</returns>
        IDbHelperService CreateUserCenterDbHelperService();

        /// <summary>
        /// 创建当前工作流服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowCurrentService CreateWorkFlowCurrentService();

        /// <summary>
        /// 创建工作流审核步骤管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowActivityAdminService CreateWorkFlowActivityAdminService();

        /// <summary>
        /// 创建工作流管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        IWorkFlowProcessAdminService CreateWorkFlowProcessAdminService();

        /// <summary>
        /// 表字段结构
        /// </summary>
        /// <returns>服务接口</returns>
        ITableColumnsService CreateTableColumnsService();
    }
}