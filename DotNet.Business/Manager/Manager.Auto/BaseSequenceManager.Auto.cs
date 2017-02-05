//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseSequenceManager
    /// 序列产生器表
    /// 
    /// 修改纪录
    /// 
    /// 2012-04-23 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-04-23</date>
    /// </author>
    /// </summary>
    public partial class BaseSequenceManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseSequenceManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseSequenceEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseSequenceManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseSequenceManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseSequenceManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseSequenceManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseSequenceManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseSequenceEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseSequenceEntity baseSequenceEntity)
        {
            return this.AddEntity(baseSequenceEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseSequenceEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseSequenceEntity baseSequenceEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseSequenceEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseSequenceEntity">实体</param>
        public int Update(BaseSequenceEntity baseSequenceEntity)
        {
            return this.UpdateEntity(baseSequenceEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseSequenceEntity GetEntity(string id)
        {
            BaseSequenceEntity baseSequenceEntity = new BaseSequenceEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseSequenceEntity.FieldId, id)));
            return baseSequenceEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseSequenceEntity">实体</param>
        public string AddEntity(BaseSequenceEntity baseSequenceEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (baseSequenceEntity.Id != null)
            {
                sequence = baseSequenceEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseSequenceEntity.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(baseSequenceEntity.Id)) 
                { 
                    sequence = BaseBusinessLogic.NewGuid(); 
                    baseSequenceEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(BaseSequenceEntity.FieldId, baseSequenceEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseSequenceEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseSequenceEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(baseSequenceEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseSequenceEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseSequenceEntity.FieldId, baseSequenceEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseSequenceEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseSequenceEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseSequenceEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseSequenceEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseSequenceEntity.FieldModifiedOn);
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
        /// <param name="baseSequenceEntity">实体</param>
        public int UpdateEntity(BaseSequenceEntity baseSequenceEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseSequenceEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseSequenceEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseSequenceEntity.FieldId, baseSequenceEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseSequenceEntity sequenceEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseSequenceEntity sequenceEntity)
        {
            sqlBuilder.SetValue(BaseSequenceEntity.FieldFullName, sequenceEntity.FullName);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldPrefix, sequenceEntity.Prefix);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldSeparator, sequenceEntity.Separator);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldSequence, sequenceEntity.Sequence);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldReduction, sequenceEntity.Reduction);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldStep, sequenceEntity.Step);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldIsVisible, sequenceEntity.IsVisible);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldDescription, sequenceEntity.Description);
            SetEntityExpand(sqlBuilder, sequenceEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseSequenceEntity.FieldId, id));
        }
    }
}
