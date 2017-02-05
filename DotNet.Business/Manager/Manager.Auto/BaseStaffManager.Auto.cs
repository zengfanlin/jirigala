//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// BaseStaffManager
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
    public partial class BaseStaffManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseStaffManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseStaffEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseStaffManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseStaffManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseStaffManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseStaffManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseStaffManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseStaffEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseStaffEntity baseStaffEntity)
        {
            return this.AddEntity(baseStaffEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseStaffEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseStaffEntity baseStaffEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseStaffEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseStaffEntity">实体</param>
        public int Update(BaseStaffEntity baseStaffEntity)
        {
            return this.UpdateEntity(baseStaffEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseStaffEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public BaseStaffEntity GetEntity(int id)
        {
            BaseStaffEntity baseStaffEntity = new BaseStaffEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseStaffEntity.FieldId, id)));
            return baseStaffEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseStaffEntity">实体</param>
        public string AddEntity(BaseStaffEntity baseStaffEntity)
        {
            string sequence = string.Empty;
            if (baseStaffEntity.SortCode == null || baseStaffEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseStaffEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseStaffEntity.FieldId);
            if (!this.Identity) 
            {
                sqlBuilder.SetValue(BaseStaffEntity.FieldId, baseStaffEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseStaffEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseStaffEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseStaffEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseStaffEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseStaffEntity.FieldId, baseStaffEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseStaffEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseStaffEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseStaffEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseStaffEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseStaffEntity.FieldModifiedOn);
            if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.SqlServer || DbHelper.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="baseStaffEntity">实体</param>
        public int UpdateEntity(BaseStaffEntity baseStaffEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseStaffEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseStaffEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseStaffEntity.FieldId, baseStaffEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseStaffEntity baseStaffEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseStaffEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseStaffEntity baseStaffEntity)
        {
            SetEntityExpand(sqlBuilder, baseStaffEntity);
            sqlBuilder.SetValue(BaseStaffEntity.FieldUserId, baseStaffEntity.UserId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldUserName, baseStaffEntity.UserName);
            sqlBuilder.SetValue(BaseStaffEntity.FieldRealName, baseStaffEntity.RealName);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCode, baseStaffEntity.Code);
            sqlBuilder.SetValue(BaseStaffEntity.FieldGender, baseStaffEntity.Gender);
            sqlBuilder.SetValue(BaseStaffEntity.FieldSubCompanyId, baseStaffEntity.SubCompanyId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCompanyId, baseStaffEntity.CompanyId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDepartmentId, baseStaffEntity.DepartmentId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldWorkgroupId, baseStaffEntity.WorkgroupId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldQuickQuery, baseStaffEntity.QuickQuery);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDutyId, baseStaffEntity.DutyId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldIdentificationCode, baseStaffEntity.IdentificationCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldIDCard, baseStaffEntity.IDCard);
            sqlBuilder.SetValue(BaseStaffEntity.FieldBankCode, baseStaffEntity.BankCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEmail, baseStaffEntity.Email);
            sqlBuilder.SetValue(BaseStaffEntity.FieldMobile, baseStaffEntity.Mobile);
            sqlBuilder.SetValue(BaseStaffEntity.FieldShortNumber, baseStaffEntity.ShortNumber);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTelephone, baseStaffEntity.Telephone);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOICQ, baseStaffEntity.OICQ);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficePhone, baseStaffEntity.OfficePhone);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficeZipCode, baseStaffEntity.OfficeZipCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficeAddress, baseStaffEntity.OfficeAddress);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficeFax, baseStaffEntity.OfficeFax);
            sqlBuilder.SetValue(BaseStaffEntity.FieldAge, baseStaffEntity.Age);
            sqlBuilder.SetValue(BaseStaffEntity.FieldBirthday, baseStaffEntity.Birthday);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEducation, baseStaffEntity.Education);
            sqlBuilder.SetValue(BaseStaffEntity.FieldSchool, baseStaffEntity.School);
            sqlBuilder.SetValue(BaseStaffEntity.FieldGraduationDate, baseStaffEntity.GraduationDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldMajor, baseStaffEntity.Major);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDegree, baseStaffEntity.Degree);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTitleId, baseStaffEntity.TitleId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTitleDate, baseStaffEntity.TitleDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTitleLevel, baseStaffEntity.TitleLevel);
            sqlBuilder.SetValue(BaseStaffEntity.FieldWorkingDate, baseStaffEntity.WorkingDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldJoinInDate, baseStaffEntity.JoinInDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomeZipCode, baseStaffEntity.HomeZipCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomeAddress, baseStaffEntity.HomeAddress);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomePhone, baseStaffEntity.HomePhone);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomeFax, baseStaffEntity.HomeFax);
            sqlBuilder.SetValue(BaseStaffEntity.FieldProvince, baseStaffEntity.Province);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCarCode, baseStaffEntity.CarCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCity, baseStaffEntity.City);
            sqlBuilder.SetValue(BaseStaffEntity.FieldArea, baseStaffEntity.Area);
            sqlBuilder.SetValue(BaseStaffEntity.FieldNativePlace, baseStaffEntity.NativePlace);
            sqlBuilder.SetValue(BaseStaffEntity.FieldParty, baseStaffEntity.Party);
            sqlBuilder.SetValue(BaseStaffEntity.FieldNation, baseStaffEntity.Nation);
            sqlBuilder.SetValue(BaseStaffEntity.FieldNationality, baseStaffEntity.Nationality);
            sqlBuilder.SetValue(BaseStaffEntity.FieldWorkingProperty, baseStaffEntity.WorkingProperty);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCompetency, baseStaffEntity.Competency);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEmergencyContact, baseStaffEntity.EmergencyContact);
            sqlBuilder.SetValue(BaseStaffEntity.FieldIsDimission, baseStaffEntity.IsDimission);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDimissionDate, baseStaffEntity.DimissionDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDimissionCause, baseStaffEntity.DimissionCause);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDimissionWhither, baseStaffEntity.DimissionWhither);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEnabled, baseStaffEntity.Enabled);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDeletionStateCode, baseStaffEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldSortCode, baseStaffEntity.SortCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDescription, baseStaffEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseStaffEntity.FieldId, id));
        }
    }
}
