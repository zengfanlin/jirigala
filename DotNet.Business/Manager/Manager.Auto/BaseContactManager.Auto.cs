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
    /// BaseContactManager
    /// 联络单主表
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
    public partial class BaseContactManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseContactManager()
        {
            base.CurrentTableName = BaseContactEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseContactManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseContactManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseContactManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseContactManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseContactManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseContactEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseContactEntity baseContactEntity)
        {
            return this.AddEntity(baseContactEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseContactEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <returns>主键</returns>
        public string Add(BaseContactEntity baseContactEntity, bool identity)
        {
            this.Identity = identity;
            return this.AddEntity(baseContactEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseContactEntity">实体</param>
        public int Update(BaseContactEntity baseContactEntity)
        {
            return this.UpdateEntity(baseContactEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseContactEntity GetEntity(string id)
        {
            BaseContactEntity baseContactEntity = new BaseContactEntity(this.GetDataTableById(id));
            return baseContactEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseContactEntity">实体</param>
        public string AddEntity(BaseContactEntity baseContactEntity)
        {
            string sequence = string.Empty;
            sequence = baseContactEntity.Id;
            if (baseContactEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseContactEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(BaseContactEntity.TableName, BaseContactEntity.FieldId);
            if (baseContactEntity.Id is string)
            {
                this.Identity = false;
            }
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseContactEntity.FieldId, baseContactEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(BaseContactEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
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
                        baseContactEntity.Id = sequence;
                        sqlBuilder.SetValue(BaseContactEntity.FieldId, baseContactEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseContactEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseContactEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseContactEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseContactEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseContactEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseContactEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseContactEntity.FieldModifiedOn);
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
        /// <param name="baseContactEntity">实体</param>
        public int UpdateEntity(BaseContactEntity baseContactEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(BaseContactEntity.TableName);
            this.SetEntity(sqlBuilder, baseContactEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseContactEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseContactEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseContactEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseContactEntity.FieldId, baseContactEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseContactEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseContactEntity baseContactEntity)
        {
            sqlBuilder.SetValue(BaseContactEntity.FieldParentId, baseContactEntity.ParentId);
            sqlBuilder.SetValue(BaseContactEntity.FieldTitle, baseContactEntity.Title);
            sqlBuilder.SetValue(BaseContactEntity.FieldContents, baseContactEntity.Contents);
            sqlBuilder.SetValue(BaseContactEntity.FieldPriority, baseContactEntity.Priority);
            sqlBuilder.SetValue(BaseContactEntity.FieldSendCount, baseContactEntity.SendCount);
            sqlBuilder.SetValue(BaseContactEntity.FieldReadCount, baseContactEntity.ReadCount);
            sqlBuilder.SetValue(BaseContactEntity.FieldIsOpen, baseContactEntity.IsOpen);
            sqlBuilder.SetValue(BaseContactEntity.FieldCommentUserId, baseContactEntity.CommentUserId);
            sqlBuilder.SetValue(BaseContactEntity.FieldCommentUserRealName, baseContactEntity.CommentUserRealName);
            sqlBuilder.SetValue(BaseContactEntity.FieldCommentDate, baseContactEntity.CommentDate);
            sqlBuilder.SetValue(BaseContactEntity.FieldDeletionStateCode, baseContactEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseContactEntity.FieldEnabled, baseContactEntity.Enabled);
            sqlBuilder.SetValue(BaseContactEntity.FieldSortCode, baseContactEntity.SortCode);
            sqlBuilder.SetValue(BaseContactEntity.FieldDescription, baseContactEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseContactEntity.FieldId, id));
        }
    }
}
