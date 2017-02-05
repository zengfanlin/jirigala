//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// BaseUserInfo
    /// 用户核心基础信息
    /// 
    /// 修改纪录
    /// 
    ///      2012.3.16  zhangyi  版本：3.7 修改注释方式，可以在其他类调用的时候显示其参数中文名称。
    ///		2011.09.12 JiRiGaLa 版本：2.1 公司名称、部门名称、工作组名称进行重构。
    ///		2011.05.11 JiRiGaLa 版本：2.0 增加安全通讯用户名、密码。
    ///		2008.08.26 JiRiGaLa 版本：1.2 整理主键。
    ///		2006.05.03 JiRiGaLa 版本：1.1 添加到工程项目中。
    ///		2006.01.21 JiRiGaLa 版本：1.0 远程传递参数用属性才可以。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.12</date>
    /// </author> 
    /// </summary>
    [Serializable]
    public class BaseUserInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserInfo()
        {
            this.ServiceUserName = BaseSystemInfo.ServiceUserName;
            this.ServicePassword = BaseSystemInfo.ServicePassword;
            this.CurrentLanguage = BaseSystemInfo.CurrentLanguage;
        }

        public string GetUserParameter(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                url = url.Replace("{Ticks}", DateTime.Now.Ticks.ToString());
                url = url.Replace("{UserCode}", this.Code);
                url = url.Replace("{UserName}", this.UserName);
                url = url.Replace("{Password}", this.Password);
                url = url.Replace("{UserId}", this.Id);
                url = url.Replace("{OpenId}", this.OpenId);
            }
            return url;
        }

        /// <summary>
        /// 获取当点登录的网址
        /// </summary>
        /// <param name="url">当前网址</param>
        /// <returns>单点登录网址</returns>
        public string GetUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                url = this.GetUserParameter(url);
                if (url.ToUpper().IndexOf("HTTP://") < 0)
                {
                    url = BaseSystemInfo.WebHostUrl + url;
                }
            }
            return url;
        }

        private string serviceUserName = "Hairihan";
        /// <summary>
        /// 远程调用Service用户名（为了提高软件的安全性）
        /// </summary>
        public string ServiceUserName
        {
            get
            {
                return this.serviceUserName;
            }
            set
            {
                this.serviceUserName = value;
            }
        }

        private string servicePassword = "Hairihan";
        /// <summary>
        /// 远程调用Service密码（为了提高软件的安全性）
        /// </summary>
        public string ServicePassword
        {
            get
            {
                return this.servicePassword;
            }
            set
            {
                this.servicePassword = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 单点登录唯一识别标识
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        private string targetUserId = string.Empty;
        /// <summary>
        /// 目标用户
        /// </summary>
        public string TargetUserId
        {
            get
            {
                return this.targetUserId;
            }
            set
            {
                this.targetUserId = value;
            }
        }

        private string id = string.Empty;
        /// <summary>
        /// 用户主键
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string userName = string.Empty;
        /// <summary>
        /// 用户用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        private string realName = string.Empty;
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName
        {
            get
            {
                return this.realName;
            }
            set
            {
                this.realName = value;
            }
        }

        private string code = string.Empty;
        /// <summary>
        /// 编号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string companyId = null;
        /// <summary>
        /// 当前的组织结构公司主键
        /// </summary>
        public string CompanyId
        {
            get
            {
                return this.companyId;
            }
            set
            {
                this.companyId = value;
            }
        }

        private string companyCode = string.Empty;
        /// <summary>
        /// 当前的组织结构公司编号
        /// </summary>
        public string CompanyCode
        {
            get
            {
                return this.companyCode;
            }
            set
            {
                this.companyCode = value;
            }
        }

        private string companyName = string.Empty;
        /// <summary>
        /// 当前的组织结构公司名称
        /// </summary>
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                this.companyName = value;
            }
        }

        private string subCompanyId = null;
        /// <summary>
        /// 分支机构主键
        /// </summary>
        public string SubCompanyId
        {
            get
            {
                return this.subCompanyId;
            }
            set
            {
                this.subCompanyId = value;
            }
        }

        private string subCompanyCode = string.Empty;
        /// <summary>
        /// 分支机构编号
        /// </summary>
        public string SubCompanyCode
        {
            get
            {
                return this.subCompanyCode;
            }
            set
            {
                this.subCompanyCode = value;
            }
        }

        private string subCompanyName = string.Empty;
        /// <summary>
        /// 分支机构名称
        /// </summary>
        public string SubCompanyName
        {
            get
            {
                return this.subCompanyName;
            }
            set
            {
                this.subCompanyName = value;
            }
        }

        private string departmentId = null;
        /// <summary>
        /// 当前的组织结构部门主键
        /// </summary>
        public string DepartmentId
        {
            get
            {
                return this.departmentId;
            }
            set
            {
                this.departmentId = value;
            }
        }

        private string departmentCode = string.Empty;
        /// <summary>
        /// 当前的组织结构部门编号
        /// </summary>
        public string DepartmentCode
        {
            get
            {
                return this.departmentCode;
            }
            set
            {
                this.departmentCode = value;
            }
        }

        private string departmentName = string.Empty;
        /// <summary>
        /// 当前的组织结构部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }
            set
            {
                this.departmentName = value;
            }
        }

        private string workgroupId = null;
        /// <summary>
        /// 当前的组织结构工作组主键
        /// </summary>
        public string WorkgroupId
        {
            get
            {
                return this.workgroupId;
            }
            set
            {
                this.workgroupId = value;
            }
        }

        private string workgroupCode = string.Empty;
        /// <summary>
        /// 当前的组织结构工作组编号
        /// </summary>
        public string WorkgroupCode
        {
            get
            {
                return this.workgroupCode;
            }
            set
            {
                this.workgroupCode = value;
            }
        }

        private string workgroupName = string.Empty;
        /// <summary>
        /// 当前的组织结构工作组名称
        /// </summary>
        public string WorkgroupName
        {
            get
            {
                return this.workgroupName;
            }
            set
            {
                this.workgroupName = value;
            }
        }

        private string roleId = string.Empty;
        /// <summary>
        /// 默认角色
        /// </summary>
        public string RoleId
        {
            get
            {
                return this.roleId;
            }
            set
            {
                this.roleId = value;
            }
        }

        private int securityLevel = 0;
        /// <summary>
        /// 安全级别
        /// </summary>
        public int SecurityLevel
        {
            get
            {
                return this.securityLevel;
            }
            set
            {
                this.securityLevel = value;
            }
        }

        private string roleName = string.Empty;
        /// <summary>
        /// 默认角色名称
        /// </summary>
        public string RoleName
        {
            get
            {
                return this.roleName;
            }
            set
            {
                this.roleName = value;
            }
        }

        private bool isAdministrator = false;
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsAdministrator
        {
            get
            {
                return this.isAdministrator;
            }
            set
            {
                this.isAdministrator = value;
            }
        }

        private string staffId = string.Empty;
        /// <summary>
        /// 员工主键
        /// </summary>
        public string StaffId
        {
            get
            {
                return this.staffId;
            }
            set
            {
                this.staffId = value;
            }
        }

        private string password = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        private string ipAddress = string.Empty;
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress
        {
            get
            {
                return this.ipAddress;
            }
            set
            {
                this.ipAddress = value;
            }
        }

        private string macAddress = string.Empty;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress
        {
            get
            {
                return this.macAddress;
            }
            set
            {
                this.macAddress = value;
            }
        }

        private string currentLanguage = string.Empty;
        /// <summary>
        /// 当前语言选择
        /// </summary>
        public string CurrentLanguage
        {
            get
            {
                return this.currentLanguage;
            }
            set
            {
                this.currentLanguage = value;
            }
        }

        private string themes = string.Empty;
        /// <summary>
        /// 当前布局风格选择
        /// </summary>
        public string Themes
        {
            get
            {
                return this.themes;
            }
            set
            {
                this.themes = value;
            }
        }
    }
}