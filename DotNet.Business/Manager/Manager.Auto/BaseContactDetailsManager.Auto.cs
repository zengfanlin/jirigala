//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd .
//-------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseContactDetailsManager
    /// 联络单明细表
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
    public partial class BaseContactDetailsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseContactDetailsManager()
        {
            base.CurrentTableName = BaseContactDetailsEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseContactDetailsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseContactDetailsManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseContactDetailsManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseContactDetailsManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseContactDetailsManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseContactDetailsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseContactDetailsEntity baseContactDetailsEntity)
        {
            return this.AddEntity(baseContactDetailsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseContactDetailsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <returns>主键</returns>
        public string Add(BaseContactDetailsEntity baseContactDetailsEntity, bool identity)
        {
            this.Identity = identity;
            return this.AddEntity(baseContactDetailsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseContactDetailsEntity">实体</param>
        public int Update(BaseContactDetailsEntity baseContactDetailsEntity)
        {
            return this.UpdateEntity(baseContactDetailsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseContactDetailsEntity GetEntity(string id)
        {
            BaseContactDetailsEntity baseContactDetailsEntity = new BaseContactDetailsEntity(this.GetDataTableById(id));
            return baseContactDetailsEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseContactDetailsEntity">实体</param>
        public string AddEntity(BaseContactDetailsEntity baseContactDetailsEntity)
        {
            string sequence = string.Empty;
            sequence = baseContactDetailsEntity.Id;
            if (baseContactDetailsEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseContactDetailsEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(BaseContactDetailsEntity.TableName, BaseContactDetailsEntity.FieldId);
            if (baseContactDetailsEntity.Id is string)
            {
                this.Identity = false;
            }
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldId, baseContactDetailsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(BaseContactDetailsEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        if (string.IsNullOrEmpty(sequence))
                        {
                            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                            sequence = sequenceManager.GetSequence(this.CurrentTableName);
                        }
                        baseContactDetailsEntity.Id = sequence;
                        sqlBuilder.SetValue(BaseContactDetailsEntity.FieldId, baseContactDetailsEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseContactDetailsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseContactDetailsEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseContactDetailsEntity.FieldModifiedOn);
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
        /// <param name="baseContactDetailsEntity">实体</param>
        public int UpdateEntity(BaseContactDetailsEntity baseContactDetailsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(BaseContactDetailsEntity.TableName);
            this.SetEntity(sqlBuilder, baseContactDetailsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseContactDetailsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseContactDetailsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseContactDetailsEntity.FieldId, baseContactDetailsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseContactDetailsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseContactDetailsEntity baseContactDetailsEntity)
        {
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldContactId, baseContactDetailsEntity.ContactId);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldCategory, baseContactDetailsEntity.Category);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldReceiverId, baseContactDetailsEntity.ReceiverId);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldReceiverRealName, baseContactDetailsEntity.ReceiverRealName);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldIsNew, baseContactDetailsEntity.IsNew);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldNewComment, baseContactDetailsEntity.NewComment);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldLastViewIP, baseContactDetailsEntity.LastViewIP);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldLastViewDate, baseContactDetailsEntity.LastViewDate);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldEnabled, baseContactDetailsEntity.Enabled);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldDeletionStateCode, baseContactDetailsEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldSortCode, baseContactDetailsEntity.SortCode);
            sqlBuilder.SetValue(BaseContactDetailsEntity.FieldDescription, baseContactDetailsEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseContactDetailsEntity.FieldId, id));
        }
    }
}
