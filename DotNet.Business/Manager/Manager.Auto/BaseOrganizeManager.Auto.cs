//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizeManager
    /// 组织机构、部门表
    ///
    /// 修改纪录
    ///
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    public partial class BaseOrganizeManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseOrganizeManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseOrganizeEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseOrganizeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseOrganizeManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseOrganizeManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseOrganizeManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseOrganizeManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseOrganizeEntity organizeEntity)
        {
            return this.AddEntity(organizeEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseOrganizeEntity organizeEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(organizeEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        public int Update(BaseOrganizeEntity organizeEntity)
        {
            return this.UpdateEntity(organizeEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseOrganizeEntity GetEntity(int? id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseOrganizeEntity GetEntity(string id)
        {
            BaseOrganizeEntity organizeEntity = new BaseOrganizeEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldId, id)));
            return organizeEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        public string AddEntity(BaseOrganizeEntity organizeEntity)
        {
            string sequence = string.Empty;
            if (organizeEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                organizeEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseOrganizeEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldId, organizeEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseOrganizeEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseOrganizeEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (organizeEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            organizeEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseOrganizeEntity.FieldId, organizeEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, organizeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseOrganizeEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseOrganizeEntity.FieldModifiedOn);
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
        /// <param name="organizeEntity">实体</param>
        public int UpdateEntity(BaseOrganizeEntity organizeEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, organizeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseOrganizeEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseOrganizeEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseOrganizeEntity.FieldId, organizeEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseOrganizeEntity organizeEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseOrganizeEntity organizeEntity)
        {   
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldParentId, organizeEntity.ParentId);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldCode, organizeEntity.Code);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldShortName, organizeEntity.ShortName);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldFullName, organizeEntity.FullName);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldCategory, organizeEntity.Category);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldOuterPhone, organizeEntity.OuterPhone);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldInnerPhone, organizeEntity.InnerPhone);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldFax, organizeEntity.Fax);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldPostalcode, organizeEntity.Postalcode);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldAddress, organizeEntity.Address);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldWeb, organizeEntity.Web);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldIsInnerOrganize, organizeEntity.IsInnerOrganize);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldBank, organizeEntity.Bank);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldBankAccount, organizeEntity.BankAccount);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldDeletionStateCode, organizeEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldEnabled, organizeEntity.Enabled);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldSortCode, organizeEntity.SortCode);
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldDescription, organizeEntity.Description);
            SetEntityExpand(sqlBuilder, organizeEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldId, id));
        }
    }
}
