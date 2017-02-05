//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowProcessManager
    /// 工作流定义
    ///
    /// 修改纪录
    ///
    ///		2012-04-09 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012-04-09</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowProcessManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowProcessManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseWorkFlowProcessEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseWorkFlowProcessManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseWorkFlowProcessManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowProcessManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowProcessManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseWorkFlowProcessManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowProcessEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowProcessEntity baseWorkFlowProcessEntity)
        {
            return this.AddEntity(baseWorkFlowProcessEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowProcessEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowProcessEntity baseWorkFlowProcessEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseWorkFlowProcessEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseWorkFlowProcessEntity">实体</param>
        public int Update(BaseWorkFlowProcessEntity baseWorkFlowProcessEntity)
        {
            return this.UpdateEntity(baseWorkFlowProcessEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowProcessEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public BaseWorkFlowProcessEntity GetEntity(int id)
        {
            BaseWorkFlowProcessEntity baseWorkFlowProcessEntity = new BaseWorkFlowProcessEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldId, id)));
            return baseWorkFlowProcessEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseWorkFlowProcessEntity">实体</param>
        public string AddEntity(BaseWorkFlowProcessEntity baseWorkFlowProcessEntity)
        {
            string sequence = string.Empty;
            if (baseWorkFlowProcessEntity.SortCode == null || baseWorkFlowProcessEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseWorkFlowProcessEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseWorkFlowProcessEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldId, baseWorkFlowProcessEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowProcessEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowProcessEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseWorkFlowProcessEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseWorkFlowProcessEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldId, baseWorkFlowProcessEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseWorkFlowProcessEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowProcessEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowProcessEntity.FieldModifiedOn);
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
        /// <param name="baseWorkFlowProcessEntity">实体</param>
        public int UpdateEntity(BaseWorkFlowProcessEntity baseWorkFlowProcessEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseWorkFlowProcessEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowProcessEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkFlowProcessEntity.FieldId, baseWorkFlowProcessEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseWorkFlowProcessEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkFlowProcessEntity baseWorkFlowProcessEntity)
        {
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldUserId, baseWorkFlowProcessEntity.UserId);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldOrganizeId, baseWorkFlowProcessEntity.OrganizeId);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldBillTemplateId, baseWorkFlowProcessEntity.BillTemplateId);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldAuditCategoryCode, baseWorkFlowProcessEntity.AuditCategoryCode);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldCallBackClass, baseWorkFlowProcessEntity.CallBackClass);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldCallBackTable, baseWorkFlowProcessEntity.CallBackTable);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldCategoryCode, baseWorkFlowProcessEntity.CategoryCode);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldCode, baseWorkFlowProcessEntity.Code);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldFullName, baseWorkFlowProcessEntity.FullName);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldContents, baseWorkFlowProcessEntity.Contents);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldSortCode, baseWorkFlowProcessEntity.SortCode);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldEnabled, baseWorkFlowProcessEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldDeletionStateCode, baseWorkFlowProcessEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseWorkFlowProcessEntity.FieldDescription, baseWorkFlowProcessEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldId, id));
        }
    }
}
