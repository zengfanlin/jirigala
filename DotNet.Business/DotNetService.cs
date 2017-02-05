//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// DotNetService
    /// 
    /// 修改纪录
    /// 
    ///		2011.08.21 版本：2.0 JiRiGaLa 方便在系统组件化用,命名进行了修改。
    ///		2007.12.27 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.21</date>
    /// </author> 
    /// </summary>
    public class DotNetService : AbstractServiceFactory
    {
        private static readonly string servicePath = BaseSystemInfo.Service;
        private static readonly string serviceFactoryClass = BaseSystemInfo.ServiceFactory;
        
        public DotNetService()
        {
            serviceFactory = GetServiceFactory(servicePath, serviceFactoryClass);
        }

        private IServiceFactory serviceFactory = null;

        public void InitService()
        {
            serviceFactory.InitService();
        }


        // 这里不能继续用单实例了，会遇到WCF回收资源的问题

        private static DotNetService instance = null;
        private static object locker = new Object();

        public static DotNetService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new DotNetService();
                        }
                    }
                }
                return instance;
            }
        }

        public virtual ILogOnService LogOnService
        {
            get
            {
                return serviceFactory.CreateLogOnService();
            }
        }

        public virtual ISequenceService SequenceService
        {
            get
            {
                return serviceFactory.CreateSequenceService();
            }
        }

        public virtual IUserService UserService
        {
            get
            {
                return serviceFactory.CreateUserService();
            }
        }

        public virtual ILogService LogService
        {
            get
            {
                return serviceFactory.CreateLogService();
            }
        }

        public virtual IExceptionService ExceptionService
        {
            get
            {
                return serviceFactory.CreateExceptionService();
            }
        }

        public virtual IPermissionItemService PermissionItemService
        {
            get
            {
                return serviceFactory.CreatePermissionItemService();
            }
        }

        public virtual IOrganizeService OrganizeService
        {
            get
            {
                return serviceFactory.CreateOrganizeService();
            }
        }

        public virtual IItemsService ItemsService
        {
            get
            {
                return serviceFactory.CreateItemsService();
            }
        }

        public virtual IItemDetailsService ItemDetailsService
        {
            get
            {
                return serviceFactory.CreateItemDetailsService();
            }
        }

        public virtual IModuleService ModuleService
        {
            get
            {
                return serviceFactory.CreateModuleService();
            }
        }

        public virtual IStaffService StaffService
        {
            get
            {
                return serviceFactory.CreateStaffService();
            }
        }

        public virtual IRoleService RoleService
        {
            get
            {
                return serviceFactory.CreateRoleService();
            }
        }

        public virtual IMessageService MessageService
        {
            get
            {
                return serviceFactory.CreateMessageService();
            }
        }

        public virtual IFileService FileService
        {
            get
            {
                return serviceFactory.CreateFileService();
            }
        }

        public virtual IFolderService FolderService
        {
            get
            {
                return serviceFactory.CreateFolderService();
            }
        }

        public virtual IParameterService ParameterService
        {
            get
            {
                return serviceFactory.CreateParameterService();
            }
        }

        public virtual IPermissionService PermissionService
        {
            get
            {
                return serviceFactory.CreatePermissionService();
            }
        }

        public virtual IDbHelperService BusinessDbHelperService
        {
            get
            {
                return serviceFactory.CreateBusinessDbHelperService();
            }
        }

        public virtual IDbHelperService UserCenterDbHelperService
        {
            get
            {
                return serviceFactory.CreateUserCenterDbHelperService();
            }
        }

        /// <summary>
        /// 创建当前工作流服务
        /// </summary>
        /// <returns>服务接口</returns>
        public virtual IWorkFlowCurrentService WorkFlowCurrentService
        {
            get
            {
                return serviceFactory.CreateWorkFlowCurrentService();
            }
        }

        /// <summary>
        /// 创建工作流审核步骤管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        public virtual IWorkFlowActivityAdminService WorkFlowActivityAdminService
        {
            get
            {
                return serviceFactory.CreateWorkFlowActivityAdminService();
            }
        }

        /// <summary>
        /// 创建工作流管理服务
        /// </summary>
        /// <returns>服务接口</returns>
        public virtual IWorkFlowProcessAdminService WorkFlowProcessAdminService
        {
            get
            {
                return serviceFactory.CreateWorkFlowProcessAdminService();
            }
        }

        /// <summary>
        /// 表字段结构
        /// </summary>
        /// <returns>服务接口</returns>
        public virtual ITableColumnsService TableColumnsService
        {
            get
            {
                return serviceFactory.CreateTableColumnsService();
            }
        }
    }
}