//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Business
{
    /// <summary>
    /// ServiceFactory
    /// 本地服务的具体实现接口
    /// 
    /// 修改纪录
    /// 
    ///		2011.08.21 版本：2.0 JiRiGaLa 方便在系统组件化用,命名进行了修改。
    ///		2007.12.30 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.21</date>
    /// </author> 
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        public void InitService()
        {
        }

        public virtual ILogOnService CreateLogOnService()
        {
            return new LogOnService();
        }

        public virtual ISequenceService CreateSequenceService()
        {
            return new SequenceService();
        }

        public virtual IUserService CreateUserService()
        {
            return new UserService();
        }

        public virtual ILogService CreateLogService()
        {
            return new LogService();
        }

        public virtual IExceptionService CreateExceptionService()
        {
            return new ExceptionService();
        }

        public virtual IPermissionItemService CreatePermissionItemService()
        {
            return new PermissionItemService();
        }

        public virtual IOrganizeService CreateOrganizeService()
        {
            return new OrganizeService();
        }

        public virtual IItemsService CreateItemsService()
        {
            return new ItemsService();
        }

        public virtual IItemDetailsService CreateItemDetailsService()
        {
            return new ItemDetailsService();
        }

        public virtual IModuleService CreateModuleService()
        {
            return new ModuleService();
        }

        public virtual IStaffService CreateStaffService()
        {
            return new StaffService();
        }

        public virtual IRoleService CreateRoleService()
        {
            return new RoleService();
        }

        public virtual IMessageService CreateMessageService()
        {
            return new MessageService();
        }

        public virtual IFileService CreateFileService()
        {
            return new FileService();
        }

        public virtual IFolderService CreateFolderService()
        {
            return new FolderService();
        }

        public virtual IParameterService CreateParameterService()
        {
            return new ParameterService();
        }

        public virtual IPermissionService CreatePermissionService()
        {
            return new PermissionService();
        }

        /// <summary>
        /// 创建业务数据库服务
        /// </summary>
        /// <returns>数据库服务</returns>
        public virtual IDbHelperService CreateBusinessDbHelperService()
        {
            return new BusinessDbHelperService();
        }

        /// <summary>
        /// 创建用户中心数据库服务
        /// </summary>
        /// <returns>数据库服务</returns>
        public virtual IDbHelperService CreateUserCenterDbHelperService()
        {
            return new UserCenterDbHelperService();
        }

        public virtual IWorkFlowCurrentService CreateWorkFlowCurrentService()
        {
            return new WorkFlowCurrentService();
        }

        public virtual IWorkFlowActivityAdminService CreateWorkFlowActivityAdminService()
        {
            return new WorkFlowActivityAdminService();
        }

        public virtual IWorkFlowProcessAdminService CreateWorkFlowProcessAdminService()
        {
            return new WorkFlowProcessAdminService();
        }

        public virtual ITableColumnsService CreateTableColumnsService()
        {
            return new TableColumnsService();
        }
    }
}