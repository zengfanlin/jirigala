//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
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
    public partial class BaseUserEntity
    {
        ///<summary>
        /// 系统用户表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseUser";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 登录名
        ///</summary>
        [NonSerialized]
        public static string FieldUserName = "UserName";

        ///<summary>
        /// 快速查询
        ///</summary>
        [NonSerialized]
        public static string FieldQuickQuery = "QuickQuery";

        ///<summary>
        /// 姓名
        ///</summary>
        [NonSerialized]
        public static string FieldRealName = "RealName";

        ///<summary>
        /// 安全级别
        ///</summary>
        [NonSerialized]
        public static string FieldSecurityLevel = "SecurityLevel";

        ///<summary>
        /// 默认角色主键
        ///</summary>
        [NonSerialized]
        public static string FieldRoleId = "RoleId";

        ///<summary>
        /// 用户来源
        ///</summary>
        [NonSerialized]
        public static string FieldUserFrom = "UserFrom";

        ///<summary>
        /// 工作行业
        ///</summary>
        [NonSerialized]
        public static string FieldWorkCategory = "WorkCategory";

        ///<summary>
        /// 公司主键
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyId = "CompanyId";

        ///<summary>
        /// 公司名称
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyName = "CompanyName";

        ///<summary>
        /// 分支机构主键
        ///</summary>
        [NonSerialized]
        public static string FieldSubCompanyId = "SubCompanyId";

        ///<summary>
        /// 分支机构名称
        ///</summary>
        [NonSerialized]
        public static string FieldSubCompanyName = "SubCompanyName";

        ///<summary>
        /// 部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        ///<summary>
        /// 部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentName = "DepartmentName";

        ///<summary>
        /// 工作组主键
        ///</summary>
        [NonSerialized]
        public static string FieldWorkgroupId = "WorkgroupId";

        ///<summary>
        /// 工作组名称
        ///</summary>
        [NonSerialized]
        public static string FieldWorkgroupName = "WorkgroupName";

        ///<summary>
        /// 性别
        ///</summary>
        [NonSerialized]
        public static string FieldGender = "Gender";

        ///<summary>
        /// 手机
        ///</summary>
        [NonSerialized]
        public static string FieldMobile = "Mobile";

        ///<summary>
        /// 电话号码
        ///</summary>
        [NonSerialized]
        public static string FieldTelephone = "Telephone";        

        ///<summary>
        /// 出生日期
        ///</summary>
        [NonSerialized]
        public static string FieldBirthday = "Birthday";

        ///<summary>
        /// 岗位
        ///</summary>
        [NonSerialized]
        public static string FieldDuty = "Duty";

        ///<summary>
        /// 职称
        ///</summary>
        [NonSerialized]
        public static string FieldTitle = "Title";

        ///<summary>
        /// 用户密码
        ///</summary>
        [NonSerialized]
        public static string FieldUserPassword = "UserPassword";

        ///<summary>
        /// 最后修改密码日期
        ///</summary>
        [NonSerialized]
        public static string FieldChangePasswordDate = "ChangePasswordDate";

        ///<summary>
        /// 通讯密码
        ///</summary>
        [NonSerialized]
        public static string FieldCommunicationPassword = "CommunicationPassword";

        ///<summary>
        /// 数字签名密码
        ///</summary>
        [NonSerialized]
        public static string FieldSignedPassword = "SignedPassword";

        ///<summary>
        /// 公钥
        ///</summary>
        [NonSerialized]
        public static string FieldPublicKey = "PublicKey";

        ///<summary>
        /// QQ号码
        ///</summary>
        [NonSerialized]
        public static string FieldOICQ = "OICQ";

        ///<summary>
        /// 电子邮件
        ///</summary>
        [NonSerialized]
        public static string FieldEmail = "Email";

        ///<summary>
        /// 系统语言选择
        ///</summary>
        [NonSerialized]
        public static string FieldLang = "Lang";

        ///<summary>
        /// 系统样式选择
        ///</summary>
        [NonSerialized]
        public static string FieldTheme = "Theme";

        ///<summary>
        /// 允许登录时间开始
        ///</summary>
        [NonSerialized]
        public static string FieldAllowStartTime = "AllowStartTime";

        ///<summary>
        /// 允许登录时间结束
        ///</summary>
        [NonSerialized]
        public static string FieldAllowEndTime = "AllowEndTime";
        
        ///<summary>
        /// 暂停用户开始日期
        ///</summary>
        [NonSerialized]
        public static string FieldLockStartDate = "LockStartDate";
        
        ///<summary>
        /// 暂停用户结束日期
        ///</summary>
        [NonSerialized]
        public static string FieldLockEndDate = "LockEndDate";

        ///<summary>
        /// 第一次访问时间
        ///</summary>
        [NonSerialized]
        public static string FieldFirstVisit = "FirstVisit";

        ///<summary>
        /// 上一次访问时间
        ///</summary>
        [NonSerialized]
        public static string FieldPreviousVisit = "PreviousVisit";

        ///<summary>
        /// 最后访问时间
        ///</summary>
        [NonSerialized]
        public static string FieldLastVisit = "LastVisit";

        ///<summary>
        /// 登录次数
        ///</summary>
        [NonSerialized]
        public static string FieldLogOnCount = "LogOnCount";

        ///<summary>
        /// 是否员工
        ///</summary>
        [NonSerialized]
        public static string FieldIsStaff = "IsStaff";

        ///<summary>
        /// 审核状态
        ///</summary>
        [NonSerialized]
        public static string FieldAuditStatus = "AuditStatus";

        ///<summary>
        /// 是否显示
        ///</summary>
        [NonSerialized]
        public static string FieldIsVisible = "IsVisible";

        ///<summary>
        /// 在线状态
        ///</summary>
        [NonSerialized]
        public static string FieldUserOnLine = "UserOnLine";

        ///<summary>
        /// IP地址
        ///</summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPAddress";

        ///<summary>
        /// MAC地址
        ///</summary>
        [NonSerialized]
        public static string FieldMACAddress = "MACAddress";

        ///<summary>
        /// 当点登录标示
        ///</summary>
        [NonSerialized]
        public static string FieldOpenId = "OpenId";

        ///<summary>
        /// 密码提示问题代码
        ///</summary>
        [NonSerialized]
        public static string FieldQuestion = "Question";

        ///<summary>
        /// 密码提示答案
        ///</summary>
        [NonSerialized]
        public static string FieldAnswerQuestion = "AnswerQuestion";

        ///<summary>
        /// 用户默认地址
        ///</summary>
        [NonSerialized]
        public static string FieldUserAddressId = "UserAddressId";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 个性签名
        ///</summary>
        [NonSerialized]
        public static string FieldSignature = "Signature";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
