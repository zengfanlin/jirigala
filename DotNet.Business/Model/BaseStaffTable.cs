//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseStaffTable
    /// 员工（职员）表
    /// 
    /// 修改纪录
    /// 
    /// 2012-07-07 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-07-07</date>
    /// </author>
    /// </summary>
    public partial class BaseStaffEntity
    {
        ///<summary>
        /// 员工（职员）表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseStaff";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldUserId = "UserId";

        ///<summary>
        /// 用户名(登录用)
        ///</summary>
        [NonSerialized]
        public static string FieldUserName = "UserName";

        ///<summary>
        /// 姓名
        ///</summary>
        [NonSerialized]
        public static string FieldRealName = "RealName";

        ///<summary>
        /// 编号,工号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 性别
        ///</summary>
        [NonSerialized]
        public static string FieldGender = "Gender";

        ///<summary>
        /// 分支机构主键，数据库中可以设置为int
        ///</summary>
        [NonSerialized]
        public static string FieldSubCompanyId = "SubCompanyId";

        ///<summary>
        /// 公司主键，数据库中可以设置为int
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyId = "CompanyId";

        ///<summary>
        /// 部门主键，数据库中可以设置为int
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        ///<summary>
        /// 工作组主键，数据库中可以设置为int
        ///</summary>
        [NonSerialized]
        public static string FieldWorkgroupId = "WorkgroupId";

        ///<summary>
        /// 快速查找，记忆符
        ///</summary>
        [NonSerialized]
        public static string FieldQuickQuery = "QuickQuery";

        ///<summary>
        /// 职位代码
        ///</summary>
        [NonSerialized]
        public static string FieldDutyId = "DutyId";

        ///<summary>
        /// 唯一身份Id
        ///</summary>
        [NonSerialized]
        public static string FieldIdentificationCode = "IdentificationCode";

        ///<summary>
        /// 身份证号码
        ///</summary>
        [NonSerialized]
        public static string FieldIDCard = "IDCard";

        ///<summary>
        /// 银行卡号
        ///</summary>
        [NonSerialized]
        public static string FieldBankCode = "BankCode";

        ///<summary>
        /// 电子邮件
        ///</summary>
        [NonSerialized]
        public static string FieldEmail = "Email";

        ///<summary>
        /// 手机
        ///</summary>
        [NonSerialized]
        public static string FieldMobile = "Mobile";

        ///<summary>
        /// 短号
        ///</summary>
        [NonSerialized]
        public static string FieldShortNumber = "ShortNumber";

        ///<summary>
        /// 电话
        ///</summary>
        [NonSerialized]
        public static string FieldTelephone = "Telephone";

        ///<summary>
        /// QQ号码
        ///</summary>
        [NonSerialized]
        public static string FieldOICQ = "OICQ";

        ///<summary>
        /// 办公电话
        ///</summary>
        [NonSerialized]
        public static string FieldOfficePhone = "OfficePhone";

        ///<summary>
        /// 办公邮编
        ///</summary>
        [NonSerialized]
        public static string FieldOfficeZipCode = "OfficeZipCode";

        ///<summary>
        /// 办公地址
        ///</summary>
        [NonSerialized]
        public static string FieldOfficeAddress = "OfficeAddress";

        ///<summary>
        /// 办公传真
        ///</summary>
        [NonSerialized]
        public static string FieldOfficeFax = "OfficeFax";

        ///<summary>
        /// 年龄
        ///</summary>
        [NonSerialized]
        public static string FieldAge = "Age";

        ///<summary>
        /// 出生日期
        ///</summary>
        [NonSerialized]
        public static string FieldBirthday = "Birthday";

        ///<summary>
        /// 最高学历
        ///</summary>
        [NonSerialized]
        public static string FieldEducation = "Education";

        ///<summary>
        /// 毕业院校
        ///</summary>
        [NonSerialized]
        public static string FieldSchool = "School";

        ///<summary>
        /// 毕业时间
        ///</summary>
        [NonSerialized]
        public static string FieldGraduationDate = "GraduationDate";

        ///<summary>
        /// 专业
        ///</summary>
        [NonSerialized]
        public static string FieldMajor = "Major";

        ///<summary>
        /// 最高学位
        ///</summary>
        [NonSerialized]
        public static string FieldDegree = "Degree";

        ///<summary>
        /// 职称主键
        ///</summary>
        [NonSerialized]
        public static string FieldTitleId = "TitleId";

        ///<summary>
        /// 职称评定日期
        ///</summary>
        [NonSerialized]
        public static string FieldTitleDate = "TitleDate";

        ///<summary>
        /// 职称等级
        ///</summary>
        [NonSerialized]
        public static string FieldTitleLevel = "TitleLevel";

        ///<summary>
        /// 工作时间
        ///</summary>
        [NonSerialized]
        public static string FieldWorkingDate = "WorkingDate";

        ///<summary>
        /// 加入本单位时间
        ///</summary>
        [NonSerialized]
        public static string FieldJoinInDate = "JoinInDate";

        ///<summary>
        /// 家庭住址邮编
        ///</summary>
        [NonSerialized]
        public static string FieldHomeZipCode = "HomeZipCode";

        ///<summary>
        /// 家庭住址
        ///</summary>
        [NonSerialized]
        public static string FieldHomeAddress = "HomeAddress";

        ///<summary>
        /// 住宅电话
        ///</summary>
        [NonSerialized]
        public static string FieldHomePhone = "HomePhone";

        ///<summary>
        /// 家庭传真
        ///</summary>
        [NonSerialized]
        public static string FieldHomeFax = "HomeFax";

        ///<summary>
        /// 籍贯省
        ///</summary>
        [NonSerialized]
        public static string FieldProvince = "Province";

        ///<summary>
        /// 车牌号
        ///</summary>
        [NonSerialized]
        public static string FieldCarCode = "CarCode";

        ///<summary>
        /// 籍贯市
        ///</summary>
        [NonSerialized]
        public static string FieldCity = "City";

        ///<summary>
        /// 籍贯区
        ///</summary>
        [NonSerialized]
        public static string FieldArea = "Area";

        ///<summary>
        /// 籍贯
        ///</summary>
        [NonSerialized]
        public static string FieldNativePlace = "NativePlace";

        ///<summary>
        /// 政治面貌
        ///</summary>
        [NonSerialized]
        public static string FieldParty = "Party";

        ///<summary>
        /// 国籍
        ///</summary>
        [NonSerialized]
        public static string FieldNation = "Nation";

        ///<summary>
        /// 民族
        ///</summary>
        [NonSerialized]
        public static string FieldNationality = "Nationality";

        ///<summary>
        /// 工作性质
        ///</summary>
        [NonSerialized]
        public static string FieldWorkingProperty = "WorkingProperty";

        ///<summary>
        /// 职业资格
        ///</summary>
        [NonSerialized]
        public static string FieldCompetency = "Competency";

        ///<summary>
        /// 紧急联系
        ///</summary>
        [NonSerialized]
        public static string FieldEmergencyContact = "EmergencyContact";

        ///<summary>
        /// 离职
        ///</summary>
        [NonSerialized]
        public static string FieldIsDimission = "IsDimission";

        ///<summary>
        /// 离职日期
        ///</summary>
        [NonSerialized]
        public static string FieldDimissionDate = "DimissionDate";

        ///<summary>
        /// 离职原因
        ///</summary>
        [NonSerialized]
        public static string FieldDimissionCause = "DimissionCause";

        ///<summary>
        /// 离职去向
        ///</summary>
        [NonSerialized]
        public static string FieldDimissionWhither = "DimissionWhither";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 删除标记
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

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
