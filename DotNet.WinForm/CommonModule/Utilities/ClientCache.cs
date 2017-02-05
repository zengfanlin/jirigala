//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// ClientCache
    /// 客户端缓存功能
    /// 
    /// 修改纪录
    ///
    ///		2008.02.03 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.02.03</date>
    /// </author> 
    /// </summary>
    public class ClientCache
    {
        private static ClientCache instance = null;
        private static object locker = new Object();

        public static ClientCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ClientCache();
                        }
                    }
                }
                return instance;
            }
        }

        private ClientCache()
        {
        }

        // 当前系统中的完整的模块菜单
        private DataTable dtMoule = new DataTable(BaseModuleEntity.TableName);
        
        /// <summary>
        /// 当前系统中的完整的模块菜单
        /// </summary>
        public DataTable DTMoule
        {
            get
            {
                return this.dtMoule;
            }

            set
            {
                this.dtMoule = value;
            }
        }

        // 当前用户可以访问的模块
        private DataTable dtUserMoule = new DataTable(BaseModuleEntity.TableName);

        /// <summary>
        /// 当前用户可以访问的模块菜单
        /// </summary>
        public DataTable DTUserMoule
        {
            get
            {
                return this.dtUserMoule;
            }
            set
            {
                this.dtUserMoule = value;
            }
        }

        // 部门数据缓存
        private DataTable dtOrganize;
        
        /// <summary>
        /// 部门缓存数据
        /// </summary>
        public DataTable DTOrganize
        {
            get
            {
                return this.dtOrganize;
            }
            set
            {
                this.dtOrganize = value;
            }
        }

        /// <summary>
        /// 获得部门缓存数据
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>部门数据表</returns>
        public DataTable GetOrganizeDT(BaseUserInfo userInfo)
        {
            if ((this.dtOrganize == null) || (!BaseSystemInfo.ClientCache))
            {
                DotNetService dotNetService = new DotNetService();
                this.dtOrganize = dotNetService.OrganizeService.GetDataTable(userInfo);
                if (dotNetService.OrganizeService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.OrganizeService).Close();
                }
            }
            this.dtOrganize.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            return this.dtOrganize;
        }

        // 权限数据缓存
        private DataTable dtPermission;

        /// <summary>
        /// 权限缓存数据
        /// </summary>
        public DataTable DTPermission
        {
            get
            {
                return this.dtPermission;
            }
            set
            {
                this.dtPermission = value;
            }
        }

        /// <summary>
        /// 获得权限缓存数据
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>数据表</returns>
        public DataTable GetPermission(BaseUserInfo userInfo)
        {
            if ((this.dtPermission == null) || (!BaseSystemInfo.ClientCache))
            {
                DotNetService dotNetService = new DotNetService();
                this.dtPermission = dotNetService.PermissionService.GetPermissionDT(userInfo);
                if (dotNetService.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionService).Close();
                }
            }
            return this.dtPermission;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        public void GetUserPermission(BaseUserInfo userInfo)
        {
            // 获取模块列表
            DotNetService dotNetService = new DotNetService();
            ClientCache.Instance.DTMoule = dotNetService.ModuleService.GetDataTable(userInfo);
            if (dotNetService.ModuleService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ModuleService).Close();
            }
            // 获取用户模块访问权限范围
            ClientCache.Instance.DTUserMoule = dotNetService.PermissionService.GetModuleDTByUser(userInfo, userInfo.Id);
            if (dotNetService.PermissionService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.PermissionService).Close();
            }
            // 获取用户的操作权限
            ClientCache.Instance.DTPermission = null;
            ClientCache.Instance.GetPermission(userInfo);
        }
    }
}