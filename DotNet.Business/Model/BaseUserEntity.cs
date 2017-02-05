//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserEntity
    /// 系统用户表
    ///
    /// 修改纪录
    ///
    ///		2010-08-07 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-08-07</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseUserEntity : BaseEntity
    {
        private string id = null;
        /// <summary>
        /// 主键
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

        private string userName = string.Empty;
        /// <summary>
        /// 登录名
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
        /// 姓名
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

        private string quickQuery = string.Empty;
        /// <summary>
        /// 快速查询
        /// </summary>
        public string QuickQuery
        {
            get
            {
                return this.quickQuery;
            }
            set
            {
                this.quickQuery = value;
            }
        }

        private string roleId = null;
        /// <summary>
        /// 默认角色主键
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

        private int? securityLevel = null;
        /// <summary>
        /// 安全级别
        /// </summary>
        public int? SecurityLevel
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

        private string userFrom = string.Empty;
        /// <summary>
        /// 用户来源
        /// </summary>
        public string UserFrom
        {
            get
            {
                return this.userFrom;
            }
            set
            {
                this.userFrom = value;
            }
        }

        private string workCategory = string.Empty;
        /// <summary>
        /// 工作行业
        /// </summary>
        public string WorkCategory
        {
            get
            {
                return this.workCategory;
            }
            set
            {
                this.workCategory = value;
            }
        }

        private string companyId = null;
        /// <summary>
        /// 公司主键
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

        private string companyName = string.Empty;
        /// <summary>
        /// 公司名称
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
        /// 部门主键
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

        private string departmentName = string.Empty;
        /// <summary>
        /// 部门名称
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
        /// 工作组代码
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

        private string workgroupName = string.Empty;
        /// <summary>
        /// 工作组名称
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

        private string gender = string.Empty;
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        private string mobile = string.Empty;
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
            }
        }

        private string telephone = string.Empty;
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telephone
        {
            get
            {
                return this.telephone;
            }
            set
            {
                this.telephone = value;
            }
        }        

        private string birthday = string.Empty;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                this.birthday = value;
            }
        }

        private string duty = null;
        /// <summary>
        /// 岗位
        /// </summary>
        public string Duty
        {
            get
            {
                return this.duty;
            }
            set
            {
                this.duty = value;
            }
        }

        private string title = null;
        /// <summary>
        /// 职称
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private string userPassword = null;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword
        {
            get
            {
                return this.userPassword;
            }
            set
            {
                this.userPassword = value;
            }
        }

        private DateTime? changePasswordDate = null;
        /// <summary>
        /// 最后修改密码日期
        /// </summary>
        public DateTime? ChangePasswordDate
        {
            get
            {
                return this.changePasswordDate;
            }
            set
            {
                this.changePasswordDate = value;
            }
        }

        private string communicationPassword = null;
        /// <summary>
        /// 通讯密码
        /// </summary>
        public string CommunicationPassword
        {
            get
            {
                return this.communicationPassword;
            }
            set
            {
                this.communicationPassword = value;
            }
        }

        private string signedPassword = null;
        /// <summary>
        /// 数字签名密码
        /// </summary>
        public string SignedPassword
        {
            get
            {
                return this.signedPassword;
            }
            set
            {
                this.signedPassword = value;
            }
        }

        private string publicKey = null;
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey
        {
            get
            {
                return this.publicKey;
            }
            set
            {
                this.publicKey = value;
            }
        }

        private string oICQ = null;
        /// <summary>
        /// QQ号码
        /// </summary>
        public string OICQ
        {
            get
            {
                return this.oICQ;
            }
            set
            {
                this.oICQ = value;
            }
        }

        private string email = null;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        private string lang = null;
        /// <summary>
        /// 系统语言选择
        /// </summary>
        public string Lang
        {
            get
            {
                return this.lang;
            }
            set
            {
                this.lang = value;
            }
        }

        private string theme = null;
        /// <summary>
        /// 系统样式选择
        /// </summary>
        public string Theme
        {
            get
            {
                return this.theme;
            }
            set
            {
                this.theme = value;
            }
        }

        private DateTime? allowStartTime = null;
        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        public DateTime? AllowStartTime
        {
            get
            {
                return this.allowStartTime;
            }
            set
            {
                this.allowStartTime = value;
            }
        }

        private DateTime? allowEndTime = null;
        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        public DateTime? AllowEndTime
        {
            get
            {
                return this.allowEndTime;
            }
            set
            {
                this.allowEndTime = value;
            }
        }

        private DateTime? lockStartDate = null;
        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        public DateTime? LockStartDate
        {
            get
            {
                return this.lockStartDate;
            }
            set
            {
                this.lockStartDate = value;
            }
        }

        private DateTime? lockEndDate = null;
        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        public DateTime? LockEndDate
        {
            get
            {
                return this.lockEndDate;
            }
            set
            {
                this.lockEndDate = value;
            }
        }

        private DateTime? firstVisit = null;
        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime? FirstVisit
        {
            get
            {
                return this.firstVisit;
            }
            set
            {
                this.firstVisit = value;
            }
        }

        private DateTime? previousVisit = null;
        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime? PreviousVisit
        {
            get
            {
                return this.previousVisit;
            }
            set
            {
                this.previousVisit = value;
            }
        }

        private DateTime? lastVisit = null;
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? LastVisit
        {
            get
            {
                return this.lastVisit;
            }
            set
            {
                this.lastVisit = value;
            }
        }

        private int? logOnCount = 0;
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LogOnCount
        {
            get
            {
                return this.logOnCount;
            }
            set
            {
                this.logOnCount = value;
            }
        }

        private int? isStaff = 0;
        /// <summary>
        /// 是否员工
        /// </summary>
        public int? IsStaff
        {
            get
            {
                return this.isStaff;
            }
            set
            {
                this.isStaff = value;
            }
        }

        private string auditStatus = null;
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditStatus
        {
            get
            {
                return this.auditStatus;
            }
            set
            {
                this.auditStatus = value;
            }
        }

        private int? isVisible = 1;
        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
            }
        }

        private int? userOnLine = 0;
        /// <summary>
        /// 在线状态
        /// </summary>
        public int? UserOnLine
        {
            get
            {
                return this.userOnLine;
            }
            set
            {
                this.userOnLine = value;
            }
        }

        private string iPAddress = null;
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress
        {
            get
            {
                return this.iPAddress;
            }
            set
            {
                this.iPAddress = value;
            }
        }

        private string mACAddress = null;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress
        {
            get
            {
                return this.mACAddress;
            }
            set
            {
                this.mACAddress = value;
            }
        }

        private string openId = BaseBusinessLogic.NewGuid();
        /// <summary>
        /// 当点登录标示
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

        private string question = null;
        /// <summary>
        /// 密码提示问题代码
        /// </summary>
        public string Question
        {
            get
            {
                return this.question;
            }
            set
            {
                this.question = value;
            }
        }

        private string answerQuestion = null;
        /// <summary>
        /// 密码提示答案
        /// </summary>
        public string AnswerQuestion
        {
            get
            {
                return this.answerQuestion;
            }
            set
            {
                this.answerQuestion = value;
            }
        }

        private string userAddressId = null;
        /// <summary>
        /// 用户默认地址
        /// </summary>
        public string UserAddressId
        {
            get
            {
                return this.userAddressId;
            }
            set
            {
                this.userAddressId = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private int? enabled = 0;
        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private int? sortCode = 0;
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private string description = null;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private string signature = null;
        /// <summary>
        /// 个性签名
        /// </summary>
        public string Signature
        {
            get
            {
                return this.signature;
            }
            set
            {
                this.signature = value;
            }
        }

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private string createUserId = null;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private string createBy = null;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        private string modifiedUserId = null;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        private string modifiedBy = null;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseUserEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseUserEntity> GetList(DataTable dataTable)
        {
            List<BaseUserEntity> entites = new List<BaseUserEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseUserEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldCode]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldUserName]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldRealName]);
            this.QuickQuery = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldQuickQuery]);
            this.RoleId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldRoleId]);
            this.SecurityLevel = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldSecurityLevel]);
            this.UserFrom = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldUserFrom]);
            this.WorkCategory = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldWorkCategory]);
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldCompanyId]);
            this.CompanyName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldCompanyName]);
            this.SubCompanyId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldSubCompanyId]);
            this.SubCompanyName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldSubCompanyName]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldDepartmentId]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldDepartmentName]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldWorkgroupId]);
            this.WorkgroupName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldWorkgroupName]);
            this.Gender = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldGender]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldMobile]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldTelephone]);
            this.Birthday = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldBirthday]);
            this.Duty = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldDuty]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldTitle]);
            this.UserPassword = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldUserPassword]);
            this.ChangePasswordDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldChangePasswordDate]);
            this.CommunicationPassword = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldCommunicationPassword]);
            this.SignedPassword = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldSignedPassword]);
            this.PublicKey = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldPublicKey]);
            this.OICQ = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldOICQ]);
            this.Email = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldEmail]);
            this.Lang = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldLang]);
            this.Theme = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldTheme]);

            this.AllowStartTime = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldAllowStartTime]);
            this.AllowEndTime = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldAllowEndTime]);
            this.LockStartDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldLockStartDate]);
            this.LockEndDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldLockEndDate]);

            this.FirstVisit = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldFirstVisit]);
            this.PreviousVisit = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldPreviousVisit]);
            this.LastVisit = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldLastVisit]);
            this.LogOnCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldLogOnCount]);
            this.IsStaff = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldIsStaff]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldAuditStatus]);
            this.IsVisible = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldIsVisible]);
            this.UserOnLine = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldUserOnLine]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldIPAddress]);
            this.MACAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldMACAddress]);
            this.OpenId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldOpenId]);
            this.Question = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldQuestion]);
            this.AnswerQuestion = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldAnswerQuestion]);
            this.UserAddressId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldUserAddressId]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldModifiedBy]);
            this.Signature = BaseBusinessLogic.ConvertToString(dataRow[BaseUserEntity.FieldSignature]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldCode]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldUserName]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldRealName]);
            this.QuickQuery = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldQuickQuery]);
            this.RoleId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldRoleId]);
            this.SecurityLevel = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldSecurityLevel]);
            this.UserFrom = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldUserFrom]);
            this.WorkCategory = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldWorkCategory]);
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldCompanyId]);
            this.CompanyName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldCompanyName]);
            this.SubCompanyId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldSubCompanyId]);
            this.SubCompanyName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldSubCompanyName]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldDepartmentId]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldDepartmentName]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldWorkgroupId]);
            this.WorkgroupName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldWorkgroupName]);
            this.Gender = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldGender]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldMobile]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldTelephone]);
            
            this.Birthday = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldBirthday]);
            this.Duty = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldDuty]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldTitle]);
            this.UserPassword = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldUserPassword]);
            this.ChangePasswordDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldChangePasswordDate]);
            this.CommunicationPassword = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldCommunicationPassword]);
            this.SignedPassword = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldSignedPassword]);
            this.PublicKey = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldPublicKey]);
            this.OICQ = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldOICQ]);
            this.Email = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldEmail]);
            this.Lang = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldLang]);
            this.Theme = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldTheme]);

            this.AllowStartTime = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldAllowStartTime]);
            this.AllowEndTime = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldAllowEndTime]);
            this.LockStartDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldLockStartDate]);
            this.LockEndDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldLockEndDate]);

            this.FirstVisit = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldFirstVisit]);
            this.PreviousVisit = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldPreviousVisit]);
            this.LastVisit = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldLastVisit]);
            this.LogOnCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldLogOnCount]);
            this.IsStaff = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldIsStaff]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldAuditStatus]);
            this.IsVisible = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldIsVisible]);
            this.UserOnLine = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldUserOnLine]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldIPAddress]);
            this.MACAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldMACAddress]);
            this.OpenId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldOpenId]);
            this.Question = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldQuestion]);
            this.AnswerQuestion = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldAnswerQuestion]);
            this.UserAddressId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldUserAddressId]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldModifiedBy]);
            this.Signature = BaseBusinessLogic.ConvertToString(dataReader[BaseUserEntity.FieldSignature]);
            return this;
        }
    }
}
