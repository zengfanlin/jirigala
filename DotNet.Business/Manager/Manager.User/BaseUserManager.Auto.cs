//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
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
    public partial class BaseUserManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseUserEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseUserManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseUserManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseUserManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseUserManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseUserManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseUserEntity userEntity)
        {
            return this.AddEntity(userEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseUserEntity userEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(userEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userEntity">实体</param>
        public int Update(BaseUserEntity userEntity)
        {
            return this.UpdateEntity(userEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseUserEntity GetEntity(int? id)
        {
            BaseUserEntity userEntity = new BaseUserEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldId, id)));
            return userEntity;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseUserEntity GetEntity(string id)
        {
            BaseUserEntity userEntity = new BaseUserEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseUserEntity.FieldId, id)));
            return userEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userEntity">实体</param>
        public string AddEntity(BaseUserEntity userEntity)
        {
            string sequence = string.Empty;
            if (userEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                userEntity.SortCode = int.Parse(sequence);
            }
            userEntity.QuickQuery = StringUtil.GetPinyin(userEntity.RealName);
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseUserEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseUserEntity.FieldId, userEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseUserEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseUserEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (userEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            userEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseUserEntity.FieldId, userEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, userEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserEntity.FieldModifiedOn);
            if (DbHelper.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
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
        /// <param name="userEntity">实体</param>
        public int UpdateEntity(BaseUserEntity userEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            userEntity.QuickQuery = StringUtil.GetPinyin(userEntity.RealName);
            this.SetEntity(sqlBuilder, userEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseUserEntity.FieldId, userEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="userEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseUserEntity userEntity)
        {
            sqlBuilder.SetValue(BaseUserEntity.FieldCode, userEntity.Code);
            sqlBuilder.SetValue(BaseUserEntity.FieldUserName, userEntity.UserName);
            sqlBuilder.SetValue(BaseUserEntity.FieldRealName, userEntity.RealName);
            sqlBuilder.SetValue(BaseUserEntity.FieldQuickQuery, userEntity.QuickQuery);
            sqlBuilder.SetValue(BaseUserEntity.FieldRoleId, userEntity.RoleId);
            sqlBuilder.SetValue(BaseUserEntity.FieldSecurityLevel, userEntity.SecurityLevel);
            sqlBuilder.SetValue(BaseUserEntity.FieldUserFrom, userEntity.UserFrom);
            sqlBuilder.SetValue(BaseUserEntity.FieldWorkCategory, userEntity.WorkCategory);
            sqlBuilder.SetValue(BaseUserEntity.FieldCompanyId, userEntity.CompanyId);
            sqlBuilder.SetValue(BaseUserEntity.FieldCompanyName, userEntity.CompanyName);
            sqlBuilder.SetValue(BaseUserEntity.FieldSubCompanyId, userEntity.SubCompanyId);
            sqlBuilder.SetValue(BaseUserEntity.FieldSubCompanyName, userEntity.SubCompanyName);
            sqlBuilder.SetValue(BaseUserEntity.FieldDepartmentId, userEntity.DepartmentId);
            sqlBuilder.SetValue(BaseUserEntity.FieldDepartmentName, userEntity.DepartmentName);
            sqlBuilder.SetValue(BaseUserEntity.FieldWorkgroupId, userEntity.WorkgroupId);
            sqlBuilder.SetValue(BaseUserEntity.FieldWorkgroupName, userEntity.WorkgroupName);
            sqlBuilder.SetValue(BaseUserEntity.FieldGender, userEntity.Gender);
            sqlBuilder.SetValue(BaseUserEntity.FieldMobile, userEntity.Mobile);
            sqlBuilder.SetValue(BaseUserEntity.FieldTelephone, userEntity.Telephone);            
            sqlBuilder.SetValue(BaseUserEntity.FieldBirthday, userEntity.Birthday);
            sqlBuilder.SetValue(BaseUserEntity.FieldDuty, userEntity.Duty);
            sqlBuilder.SetValue(BaseUserEntity.FieldTitle, userEntity.Title);
            sqlBuilder.SetValue(BaseUserEntity.FieldUserPassword, userEntity.UserPassword);
            sqlBuilder.SetValue(BaseUserEntity.FieldCommunicationPassword, userEntity.CommunicationPassword);
            sqlBuilder.SetValue(BaseUserEntity.FieldOICQ, userEntity.OICQ);
            sqlBuilder.SetValue(BaseUserEntity.FieldEmail, userEntity.Email);
            sqlBuilder.SetValue(BaseUserEntity.FieldLang, userEntity.Lang);
            sqlBuilder.SetValue(BaseUserEntity.FieldTheme, userEntity.Theme);

            sqlBuilder.SetValue(BaseUserEntity.FieldAllowStartTime, userEntity.AllowStartTime);
            sqlBuilder.SetValue(BaseUserEntity.FieldAllowEndTime, userEntity.AllowEndTime);
            sqlBuilder.SetValue(BaseUserEntity.FieldLockStartDate, userEntity.LockStartDate);
            sqlBuilder.SetValue(BaseUserEntity.FieldLockEndDate, userEntity.LockEndDate);

            sqlBuilder.SetValue(BaseUserEntity.FieldFirstVisit, userEntity.FirstVisit);
            sqlBuilder.SetValue(BaseUserEntity.FieldPreviousVisit, userEntity.PreviousVisit);
            sqlBuilder.SetValue(BaseUserEntity.FieldLastVisit, userEntity.LastVisit);
            sqlBuilder.SetValue(BaseUserEntity.FieldLogOnCount, userEntity.LogOnCount);
            sqlBuilder.SetValue(BaseUserEntity.FieldIsStaff, userEntity.IsStaff);
            sqlBuilder.SetValue(BaseUserEntity.FieldAuditStatus, userEntity.AuditStatus);
            sqlBuilder.SetValue(BaseUserEntity.FieldIsVisible, userEntity.IsVisible);
            sqlBuilder.SetValue(BaseUserEntity.FieldUserOnLine, userEntity.UserOnLine);
            sqlBuilder.SetValue(BaseUserEntity.FieldIPAddress, userEntity.IPAddress);
            sqlBuilder.SetValue(BaseUserEntity.FieldMACAddress, userEntity.MACAddress);
            sqlBuilder.SetValue(BaseUserEntity.FieldOpenId, userEntity.OpenId);
            sqlBuilder.SetValue(BaseUserEntity.FieldQuestion, userEntity.Question);
            sqlBuilder.SetValue(BaseUserEntity.FieldAnswerQuestion, userEntity.AnswerQuestion);
            sqlBuilder.SetValue(BaseUserEntity.FieldUserAddressId, userEntity.UserAddressId);
            sqlBuilder.SetValue(BaseUserEntity.FieldDeletionStateCode, userEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseUserEntity.FieldEnabled, userEntity.Enabled);
            sqlBuilder.SetValue(BaseUserEntity.FieldSortCode, userEntity.SortCode);
            sqlBuilder.SetValue(BaseUserEntity.FieldDescription, userEntity.Description);
            sqlBuilder.SetValue(BaseUserEntity.FieldSignature, userEntity.Signature);
        }
    }
}
