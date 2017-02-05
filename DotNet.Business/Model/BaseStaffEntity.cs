//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseStaffEntity
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
    [Serializable]
    public partial class BaseStaffEntity : BaseEntity
    {
        private int? id = null;
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id
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

        private int? userId = null;
        /// <summary>
        /// 用户主键
        /// </summary>
        public int? UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private String userName = string.Empty;
        /// <summary>
        /// 用户名(登录用)
        /// </summary>
        public String UserName
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

        private String realName = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        public String RealName
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

        private String code = string.Empty;
        /// <summary>
        /// 编号,工号
        /// </summary>
        public String Code
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

        private String gender = string.Empty;
        /// <summary>
        /// 性别
        /// </summary>
        public String Gender
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

        private String subCompanyId = string.Empty;
        /// <summary>
        /// 分支机构主键，数据库中可以设置为int
        /// </summary>
        public String SubCompanyId
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

        private String companyId = string.Empty;
        /// <summary>
        /// 公司主键，数据库中可以设置为int
        /// </summary>
        public String CompanyId
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

        private String departmentId = string.Empty;
        /// <summary>
        /// 部门主键，数据库中可以设置为int
        /// </summary>
        public String DepartmentId
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

        private String workgroupId = string.Empty;
        /// <summary>
        /// 工作组主键，数据库中可以设置为int
        /// </summary>
        public String WorkgroupId
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

        private String quickQuery = string.Empty;
        /// <summary>
        /// 快速查找，记忆符
        /// </summary>
        public String QuickQuery
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

        private String dutyId = string.Empty;
        /// <summary>
        /// 职位代码
        /// </summary>
        public String DutyId
        {
            get
            {
                return this.dutyId;
            }
            set
            {
                this.dutyId = value;
            }
        }

        private String identificationCode = string.Empty;
        /// <summary>
        /// 唯一身份Id
        /// </summary>
        public String IdentificationCode
        {
            get
            {
                return this.identificationCode;
            }
            set
            {
                this.identificationCode = value;
            }
        }

        private String iDCard = string.Empty;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public String IDCard
        {
            get
            {
                return this.iDCard;
            }
            set
            {
                this.iDCard = value;
            }
        }

        private String bankCode = string.Empty;
        /// <summary>
        /// 银行卡号
        /// </summary>
        public String BankCode
        {
            get
            {
                return this.bankCode;
            }
            set
            {
                this.bankCode = value;
            }
        }

        private String email = string.Empty;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public String Email
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

        private String mobile = string.Empty;
        /// <summary>
        /// 手机
        /// </summary>
        public String Mobile
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

        private String shortNumber = string.Empty;
        /// <summary>
        /// 短号
        /// </summary>
        public String ShortNumber
        {
            get
            {
                return this.shortNumber;
            }
            set
            {
                this.shortNumber = value;
            }
        }

        private String telephone = string.Empty;
        /// <summary>
        /// 电话
        /// </summary>
        public String Telephone
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

        private String oICQ = string.Empty;
        /// <summary>
        /// QQ号码
        /// </summary>
        public String OICQ
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

        private String officePhone = string.Empty;
        /// <summary>
        /// 办公电话
        /// </summary>
        public String OfficePhone
        {
            get
            {
                return this.officePhone;
            }
            set
            {
                this.officePhone = value;
            }
        }

        private String officeZipCode = string.Empty;
        /// <summary>
        /// 办公邮编
        /// </summary>
        public String OfficeZipCode
        {
            get
            {
                return this.officeZipCode;
            }
            set
            {
                this.officeZipCode = value;
            }
        }

        private String officeAddress = string.Empty;
        /// <summary>
        /// 办公地址
        /// </summary>
        public String OfficeAddress
        {
            get
            {
                return this.officeAddress;
            }
            set
            {
                this.officeAddress = value;
            }
        }

        private String officeFax = string.Empty;
        /// <summary>
        /// 办公传真
        /// </summary>
        public String OfficeFax
        {
            get
            {
                return this.officeFax;
            }
            set
            {
                this.officeFax = value;
            }
        }

        private String age = string.Empty;
        /// <summary>
        /// 年龄
        /// </summary>
        public String Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        private String birthday = string.Empty;
        /// <summary>
        /// 出生日期
        /// </summary>
        public String Birthday
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

        private String education = string.Empty;
        /// <summary>
        /// 最高学历
        /// </summary>
        public String Education
        {
            get
            {
                return this.education;
            }
            set
            {
                this.education = value;
            }
        }

        private String school = string.Empty;
        /// <summary>
        /// 毕业院校
        /// </summary>
        public String School
        {
            get
            {
                return this.school;
            }
            set
            {
                this.school = value;
            }
        }

        private String graduationDate = string.Empty;
        /// <summary>
        /// 毕业时间
        /// </summary>
        public String GraduationDate
        {
            get
            {
                return this.graduationDate;
            }
            set
            {
                this.graduationDate = value;
            }
        }

        private String major = string.Empty;
        /// <summary>
        /// 专业
        /// </summary>
        public String Major
        {
            get
            {
                return this.major;
            }
            set
            {
                this.major = value;
            }
        }

        private String degree = string.Empty;
        /// <summary>
        /// 最高学位
        /// </summary>
        public String Degree
        {
            get
            {
                return this.degree;
            }
            set
            {
                this.degree = value;
            }
        }

        private String titleId = string.Empty;
        /// <summary>
        /// 职称主键
        /// </summary>
        public String TitleId
        {
            get
            {
                return this.titleId;
            }
            set
            {
                this.titleId = value;
            }
        }

        private String titleDate = string.Empty;
        /// <summary>
        /// 职称评定日期
        /// </summary>
        public String TitleDate
        {
            get
            {
                return this.titleDate;
            }
            set
            {
                this.titleDate = value;
            }
        }

        private String titleLevel = string.Empty;
        /// <summary>
        /// 职称等级
        /// </summary>
        public String TitleLevel
        {
            get
            {
                return this.titleLevel;
            }
            set
            {
                this.titleLevel = value;
            }
        }

        private String workingDate = string.Empty;
        /// <summary>
        /// 工作时间
        /// </summary>
        public String WorkingDate
        {
            get
            {
                return this.workingDate;
            }
            set
            {
                this.workingDate = value;
            }
        }

        private String joinInDate = string.Empty;
        /// <summary>
        /// 加入本单位时间
        /// </summary>
        public String JoinInDate
        {
            get
            {
                return this.joinInDate;
            }
            set
            {
                this.joinInDate = value;
            }
        }

        private String homeZipCode = string.Empty;
        /// <summary>
        /// 家庭住址邮编
        /// </summary>
        public String HomeZipCode
        {
            get
            {
                return this.homeZipCode;
            }
            set
            {
                this.homeZipCode = value;
            }
        }

        private String homeAddress = string.Empty;
        /// <summary>
        /// 家庭住址
        /// </summary>
        public String HomeAddress
        {
            get
            {
                return this.homeAddress;
            }
            set
            {
                this.homeAddress = value;
            }
        }

        private String homePhone = string.Empty;
        /// <summary>
        /// 住宅电话
        /// </summary>
        public String HomePhone
        {
            get
            {
                return this.homePhone;
            }
            set
            {
                this.homePhone = value;
            }
        }

        private String homeFax = string.Empty;
        /// <summary>
        /// 家庭传真
        /// </summary>
        public String HomeFax
        {
            get
            {
                return this.homeFax;
            }
            set
            {
                this.homeFax = value;
            }
        }

        private String province = string.Empty;
        /// <summary>
        /// 籍贯省
        /// </summary>
        public String Province
        {
            get
            {
                return this.province;
            }
            set
            {
                this.province = value;
            }
        }

        private String carCode = string.Empty;
        /// <summary>
        /// 车牌号
        /// </summary>
        public String CarCode
        {
            get
            {
                return this.carCode;
            }
            set
            {
                this.carCode = value;
            }
        }

        private String city = string.Empty;
        /// <summary>
        /// 籍贯市
        /// </summary>
        public String City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        private String area = string.Empty;
        /// <summary>
        /// 籍贯区
        /// </summary>
        public String Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }

        private String nativePlace = string.Empty;
        /// <summary>
        /// 籍贯
        /// </summary>
        public String NativePlace
        {
            get
            {
                return this.nativePlace;
            }
            set
            {
                this.nativePlace = value;
            }
        }

        private String party = string.Empty;
        /// <summary>
        /// 政治面貌
        /// </summary>
        public String Party
        {
            get
            {
                return this.party;
            }
            set
            {
                this.party = value;
            }
        }

        private String nation = string.Empty;
        /// <summary>
        /// 国籍
        /// </summary>
        public String Nation
        {
            get
            {
                return this.nation;
            }
            set
            {
                this.nation = value;
            }
        }

        private String nationality = string.Empty;
        /// <summary>
        /// 民族
        /// </summary>
        public String Nationality
        {
            get
            {
                return this.nationality;
            }
            set
            {
                this.nationality = value;
            }
        }

        private String workingProperty = string.Empty;
        /// <summary>
        /// 工作性质
        /// </summary>
        public String WorkingProperty
        {
            get
            {
                return this.workingProperty;
            }
            set
            {
                this.workingProperty = value;
            }
        }

        private String competency = string.Empty;
        /// <summary>
        /// 职业资格
        /// </summary>
        public String Competency
        {
            get
            {
                return this.competency;
            }
            set
            {
                this.competency = value;
            }
        }

        private String emergencyContact = string.Empty;
        /// <summary>
        /// 紧急联系
        /// </summary>
        public String EmergencyContact
        {
            get
            {
                return this.emergencyContact;
            }
            set
            {
                this.emergencyContact = value;
            }
        }

        private int? isDimission = 0;
        /// <summary>
        /// 离职
        /// </summary>
        public int? IsDimission
        {
            get
            {
                return this.isDimission;
            }
            set
            {
                this.isDimission = value;
            }
        }

        private String dimissionDate = string.Empty;
        /// <summary>
        /// 离职日期
        /// </summary>
        public String DimissionDate
        {
            get
            {
                return this.dimissionDate;
            }
            set
            {
                this.dimissionDate = value;
            }
        }

        private String dimissionCause = string.Empty;
        /// <summary>
        /// 离职原因
        /// </summary>
        public String DimissionCause
        {
            get
            {
                return this.dimissionCause;
            }
            set
            {
                this.dimissionCause = value;
            }
        }

        private String dimissionWhither = string.Empty;
        /// <summary>
        /// 离职去向
        /// </summary>
        public String DimissionWhither
        {
            get
            {
                return this.dimissionWhither;
            }
            set
            {
                this.dimissionWhither = value;
            }
        }

        private int? enabled = 1;
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

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标记
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

        private int? sortCode = null;
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

        private String description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public String Description
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

        private String createUserId = string.Empty;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId
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

        private String createBy = string.Empty;
        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy
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

        private String modifiedUserId = string.Empty;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId
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

        private String modifiedBy = string.Empty;
        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy
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
        public BaseStaffEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseStaffEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseStaffEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseStaffEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseStaffEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取返回实体列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public List<BaseStaffEntity>  GetList(DataTable dataTable)
        {
            List<BaseStaffEntity> entities=new List<BaseStaffEntity>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                entities.Add(GetFrom(dataRow));
            }
            return entities;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseStaffEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldUserId]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldUserName]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldRealName]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCode]);
            this.Gender = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldGender]);
            this.SubCompanyId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldSubCompanyId]);
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDepartmentId]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldWorkgroupId]);
            this.QuickQuery = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldQuickQuery]);
            this.DutyId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDutyId]);
            this.IdentificationCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldIdentificationCode]);
            this.IDCard = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldIDCard]);
            this.BankCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldBankCode]);
            this.Email = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldEmail]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldMobile]);
            this.ShortNumber = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldShortNumber]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTelephone]);
            this.OICQ = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOICQ]);
            this.OfficePhone = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficePhone]);
            this.OfficeZipCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficeZipCode]);
            this.OfficeAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficeAddress]);
            this.OfficeFax = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficeFax]);
            this.Age = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldAge]);
            this.Birthday = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldBirthday]);
            this.Education = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldEducation]);
            this.School = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldSchool]);
            this.GraduationDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldGraduationDate]);
            this.Major = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldMajor]);
            this.Degree = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDegree]);
            this.TitleId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTitleId]);
            this.TitleDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTitleDate]);
            this.TitleLevel = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTitleLevel]);
            this.WorkingDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldWorkingDate]);
            this.JoinInDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldJoinInDate]);
            this.HomeZipCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomeZipCode]);
            this.HomeAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomeAddress]);
            this.HomePhone = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomePhone]);
            this.HomeFax = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomeFax]);
            this.Province = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldProvince]);
            this.CarCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCarCode]);
            this.City = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCity]);
            this.Area = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldArea]);
            this.NativePlace = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldNativePlace]);
            this.Party = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldParty]);
            this.Nation = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldNation]);
            this.Nationality = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldNationality]);
            this.WorkingProperty = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldWorkingProperty]);
            this.Competency = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCompetency]);
            this.EmergencyContact = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldEmergencyContact]);
            this.IsDimission = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldIsDimission]);
            this.DimissionDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDimissionDate]);
            this.DimissionCause = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDimissionCause]);
            this.DimissionWhither = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDimissionWhither]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseStaffEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseStaffEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseStaffEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);;
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldUserId]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldUserName]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldRealName]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCode]);
            this.Gender = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldGender]);
            this.SubCompanyId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldSubCompanyId]);
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDepartmentId]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldWorkgroupId]);
            this.QuickQuery = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldQuickQuery]);
            this.DutyId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDutyId]);
            this.IdentificationCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldIdentificationCode]);
            this.IDCard = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldIDCard]);
            this.BankCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldBankCode]);
            this.Email = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldEmail]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldMobile]);
            this.ShortNumber = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldShortNumber]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTelephone]);
            this.OICQ = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOICQ]);
            this.OfficePhone = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficePhone]);
            this.OfficeZipCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficeZipCode]);
            this.OfficeAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficeAddress]);
            this.OfficeFax = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficeFax]);
            this.Age = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldAge]);
            this.Birthday = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldBirthday]);
            this.Education = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldEducation]);
            this.School = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldSchool]);
            this.GraduationDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldGraduationDate]);
            this.Major = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldMajor]);
            this.Degree = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDegree]);
            this.TitleId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTitleId]);
            this.TitleDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTitleDate]);
            this.TitleLevel = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTitleLevel]);
            this.WorkingDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldWorkingDate]);
            this.JoinInDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldJoinInDate]);
            this.HomeZipCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomeZipCode]);
            this.HomeAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomeAddress]);
            this.HomePhone = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomePhone]);
            this.HomeFax = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomeFax]);
            this.Province = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldProvince]);
            this.CarCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCarCode]);
            this.City = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCity]);
            this.Area = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldArea]);
            this.NativePlace = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldNativePlace]);
            this.Party = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldParty]);
            this.Nation = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldNation]);
            this.Nationality = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldNationality]);
            this.WorkingProperty = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldWorkingProperty]);
            this.Competency = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCompetency]);
            this.EmergencyContact = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldEmergencyContact]);
            this.IsDimission = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldIsDimission]);
            this.DimissionDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDimissionDate]);
            this.DimissionCause = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDimissionCause]);
            this.DimissionWhither = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDimissionWhither]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseStaffEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseStaffEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldModifiedBy]);
            return this;
        }
    }
}
