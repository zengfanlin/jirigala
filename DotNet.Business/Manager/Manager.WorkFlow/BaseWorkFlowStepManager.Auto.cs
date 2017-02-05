//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowStepManager
    /// 工作流步骤定义
    ///
    /// 修改纪录
    ///
    ///		2011-11-18 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011-11-18</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowStepManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowStepManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseWorkFlowStepEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseWorkFlowStepManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseWorkFlowStepManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowStepManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowStepManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseWorkFlowStepManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="BaseWorkFlowStepEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowStepEntity BaseWorkFlowStepEntity)
        {
            return this.AddEntity(BaseWorkFlowStepEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="BaseWorkFlowStepEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowStepEntity BaseWorkFlowStepEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(BaseWorkFlowStepEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="BaseWorkFlowStepEntity">实体</param>
        public int Update(BaseWorkFlowStepEntity BaseWorkFlowStepEntity)
        {
            return this.UpdateEntity(BaseWorkFlowStepEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowStepEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowStepEntity GetEntity(int? id)
        {
            return GetEntity((int)id);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowStepEntity GetEntity(string id)
        {
            BaseWorkFlowStepEntity BaseWorkFlowStepEntity = new BaseWorkFlowStepEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldId, id)));
            return BaseWorkFlowStepEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="workFlowActivityEntity">实体</param>
        public string AddEntity(BaseWorkFlowStepEntity workFlowActivityEntity)
        {
            string sequence = string.Empty;
            if (workFlowActivityEntity.SortCode == null || workFlowActivityEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                workFlowActivityEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseWorkFlowStepEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldId, workFlowActivityEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowStepEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowStepEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (workFlowActivityEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            workFlowActivityEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldId, workFlowActivityEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, workFlowActivityEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowStepEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowStepEntity.FieldModifiedOn);
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
        /// <param name="BaseWorkFlowStepEntity">实体</param>
        public int UpdateEntity(BaseWorkFlowStepEntity BaseWorkFlowStepEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, BaseWorkFlowStepEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowStepEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkFlowStepEntity.FieldId, BaseWorkFlowStepEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="BaseWorkFlowStepEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkFlowStepEntity BaseWorkFlowStepEntity)
        {
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldCategoryCode, BaseWorkFlowStepEntity.CategoryCode);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldObjectId, BaseWorkFlowStepEntity.ObjectId);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldWorkFlowId, BaseWorkFlowStepEntity.WorkFlowId);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldActivityId, BaseWorkFlowStepEntity.ActivityId);            
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldCode, BaseWorkFlowStepEntity.Code);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldFullName, BaseWorkFlowStepEntity.FullName);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditDepartmentId, BaseWorkFlowStepEntity.AuditDepartmentId);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditDepartmentName, BaseWorkFlowStepEntity.AuditDepartmentName);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditUserId, BaseWorkFlowStepEntity.AuditUserId);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditUserCode, BaseWorkFlowStepEntity.AuditUserCode);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditUserRealName, BaseWorkFlowStepEntity.AuditUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditRoleId, BaseWorkFlowStepEntity.AuditRoleId);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditRoleRealName, BaseWorkFlowStepEntity.AuditRoleRealName);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldActivityType, BaseWorkFlowStepEntity.ActivityType);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAllowPrint, BaseWorkFlowStepEntity.AllowPrint);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAllowEditDocuments, BaseWorkFlowStepEntity.AllowEditDocuments);            
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldSortCode, BaseWorkFlowStepEntity.SortCode);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldEnabled, BaseWorkFlowStepEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldDeletionStateCode, BaseWorkFlowStepEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldDescription, BaseWorkFlowStepEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldId, id));
        }        
    }
}
