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
    /// BaseWorkFlowBillTemplateManager
    /// 工作流模板表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-18 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-18</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowBillTemplateManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowBillTemplateManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseWorkFlowBillTemplateEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseWorkFlowBillTemplateManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseWorkFlowBillTemplateManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowBillTemplateManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowBillTemplateManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseWorkFlowBillTemplateManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowBillTemplateEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity)
        {
            return this.AddEntity(baseWorkFlowBillTemplateEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowBillTemplateEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseWorkFlowBillTemplateEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseWorkFlowBillTemplateEntity">实体</param>
        public int Update(BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity)
        {
            return this.UpdateEntity(baseWorkFlowBillTemplateEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowBillTemplateEntity GetEntity(string id)
        {
            BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity = new BaseWorkFlowBillTemplateEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldId, id)));
            return baseWorkFlowBillTemplateEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseWorkFlowBillTemplateEntity">实体</param>
        public string AddEntity(BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (baseWorkFlowBillTemplateEntity.SortCode == null || baseWorkFlowBillTemplateEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseWorkFlowBillTemplateEntity.SortCode = int.Parse(sequence);
            }
            if (baseWorkFlowBillTemplateEntity.Id != null)
            {
                sequence = baseWorkFlowBillTemplateEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseWorkFlowBillTemplateEntity.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(baseWorkFlowBillTemplateEntity.Id)) 
                { 
                    sequence = BaseBusinessLogic.NewGuid(); 
                    baseWorkFlowBillTemplateEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldId, baseWorkFlowBillTemplateEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowBillTemplateEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowBillTemplateEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(baseWorkFlowBillTemplateEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseWorkFlowBillTemplateEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldId, baseWorkFlowBillTemplateEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseWorkFlowBillTemplateEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseWorkFlowBillTemplateEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseWorkFlowBillTemplateEntity.FieldModifiedOn);
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
        /// <param name="baseWorkFlowBillTemplateEntity">实体</param>
        public int UpdateEntity(BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseWorkFlowBillTemplateEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseWorkFlowBillTemplateEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkFlowBillTemplateEntity.FieldId, baseWorkFlowBillTemplateEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseWorkFlowBillTemplateEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkFlowBillTemplateEntity baseWorkFlowBillTemplateEntity)
        {
            SetEntityExpand(sqlBuilder, baseWorkFlowBillTemplateEntity);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldTitle, baseWorkFlowBillTemplateEntity.Title);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldCode, baseWorkFlowBillTemplateEntity.Code);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldCategoryCode, baseWorkFlowBillTemplateEntity.CategoryCode);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldIntroduction, baseWorkFlowBillTemplateEntity.Introduction);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldContents, baseWorkFlowBillTemplateEntity.Contents);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldTemplateType, baseWorkFlowBillTemplateEntity.TemplateType);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldUseWorkFlow, baseWorkFlowBillTemplateEntity.UseWorkFlow);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldAddPage, baseWorkFlowBillTemplateEntity.AddPage);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldEditPage, baseWorkFlowBillTemplateEntity.EditPage);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldShowPage, baseWorkFlowBillTemplateEntity.ShowPage);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldListPage, baseWorkFlowBillTemplateEntity.ListPage);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldAdminPage, baseWorkFlowBillTemplateEntity.AdminPage);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldAuditStatus, baseWorkFlowBillTemplateEntity.AuditStatus);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode, baseWorkFlowBillTemplateEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldDescription, baseWorkFlowBillTemplateEntity.Description);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldEnabled, baseWorkFlowBillTemplateEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkFlowBillTemplateEntity.FieldSortCode, baseWorkFlowBillTemplateEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldId, id));
        }
    }
}
