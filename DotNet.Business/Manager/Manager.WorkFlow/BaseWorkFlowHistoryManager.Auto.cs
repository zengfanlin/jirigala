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
    /// BaseWorkFlowHistoryManager
    /// 工作流审核历史步骤记录
    /// 
    /// 修改纪录
    /// 
    /// 2012-07-03 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-07-03</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowHistoryManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowHistoryManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseWorkFlowHistoryEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseWorkFlowHistoryManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseWorkFlowHistoryManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowHistoryManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowHistoryManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseWorkFlowHistoryManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            return this.AddEntity(baseWorkFlowHistoryEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseWorkFlowHistoryEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        public int Update(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            return this.UpdateEntity(baseWorkFlowHistoryEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowHistoryEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public BaseWorkFlowHistoryEntity GetEntity(int id)
        {
            BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity = new BaseWorkFlowHistoryEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowHistoryEntity.FieldId, id)));
            return baseWorkFlowHistoryEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        public string AddEntity(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            string sequence = string.Empty;
            if (baseWorkFlowHistoryEntity.SortCode == null || baseWorkFlowHistoryEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseWorkFlowHistoryEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseWorkFlowHistoryEntity.FieldId);
            if (!this.Identity) 
            {
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldId, baseWorkFlowHistoryEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowHistoryEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowHistoryEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseWorkFlowHistoryEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseWorkFlowHistoryEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldId, baseWorkFlowHistoryEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseWorkFlowHistoryEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseWorkFlowHistoryEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseWorkFlowHistoryEntity.FieldModifiedOn);
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
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        public int UpdateEntity(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseWorkFlowHistoryEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseWorkFlowHistoryEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkFlowHistoryEntity.FieldId, baseWorkFlowHistoryEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            SetEntityExpand(sqlBuilder, baseWorkFlowHistoryEntity);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldCurrentFlowId, baseWorkFlowHistoryEntity.CurrentFlowId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldWorkFlowId, baseWorkFlowHistoryEntity.WorkFlowId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldActivityId, baseWorkFlowHistoryEntity.ActivityId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldActivityFullName, baseWorkFlowHistoryEntity.ActivityFullName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldToDepartmentId, baseWorkFlowHistoryEntity.ToDepartmentId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldToDepartmentName, baseWorkFlowHistoryEntity.ToDepartmentName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldToUserId, baseWorkFlowHistoryEntity.ToUserId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldToUserRealName, baseWorkFlowHistoryEntity.ToUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldToRoleId, baseWorkFlowHistoryEntity.ToRoleId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldToRoleRealName, baseWorkFlowHistoryEntity.ToRoleRealName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditUserId, baseWorkFlowHistoryEntity.AuditUserId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditUserCode, baseWorkFlowHistoryEntity.AuditUserCode);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditUserRealName, baseWorkFlowHistoryEntity.AuditUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldSendDate, baseWorkFlowHistoryEntity.SendDate);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditDate, baseWorkFlowHistoryEntity.AuditDate);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditIdea, baseWorkFlowHistoryEntity.AuditIdea);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditStatus, baseWorkFlowHistoryEntity.AuditStatus);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldAuditStatusName, baseWorkFlowHistoryEntity.AuditStatusName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldSortCode, baseWorkFlowHistoryEntity.SortCode);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldEnabled, baseWorkFlowHistoryEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldDeletionStateCode, baseWorkFlowHistoryEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseWorkFlowHistoryEntity.FieldDescription, baseWorkFlowHistoryEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseWorkFlowHistoryEntity.FieldId, id));
        }
    }
}
