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
    /// BaseModuleManager
    /// 模块（菜单）表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-22 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-22</date>
    /// </author>
    /// </summary>
    public partial class BaseModuleManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseModuleManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseModuleEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseModuleManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseModuleManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseModuleManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseModuleManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseModuleManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseModuleEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseModuleEntity baseModuleEntity)
        {
            return this.AddEntity(baseModuleEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseModuleEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseModuleEntity baseModuleEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseModuleEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseModuleEntity">实体</param>
        public int Update(BaseModuleEntity baseModuleEntity)
        {
            return this.UpdateEntity(baseModuleEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseModuleEntity GetEntity(string id)
        {
            return GetEntity(int.Parse(id));
        }

        public BaseModuleEntity GetEntity(int id)
        {
            BaseModuleEntity baseModuleEntity = new BaseModuleEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, id)));
            return baseModuleEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseModuleEntity">实体</param>
        public string AddEntity(BaseModuleEntity baseModuleEntity)
        {
            string sequence = string.Empty;
            if (baseModuleEntity.SortCode == null || baseModuleEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseModuleEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseModuleEntity.FieldId);
            if (!this.Identity) 
            {
                sqlBuilder.SetValue(BaseModuleEntity.FieldId, baseModuleEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseModuleEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseModuleEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseModuleEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseModuleEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseModuleEntity.FieldId, baseModuleEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseModuleEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseModuleEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseModuleEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseModuleEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseModuleEntity.FieldModifiedOn);
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
        /// <param name="baseModuleEntity">实体</param>
        public int UpdateEntity(BaseModuleEntity baseModuleEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseModuleEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseModuleEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseModuleEntity.FieldId, baseModuleEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseModuleEntity baseModuleEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseModuleEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseModuleEntity baseModuleEntity)
        {
            SetEntityExpand(sqlBuilder, baseModuleEntity);
            sqlBuilder.SetValue(BaseModuleEntity.FieldParentId, baseModuleEntity.ParentId);
            sqlBuilder.SetValue(BaseModuleEntity.FieldCode, baseModuleEntity.Code);
            sqlBuilder.SetValue(BaseModuleEntity.FieldFullName, baseModuleEntity.FullName);
            sqlBuilder.SetValue(BaseModuleEntity.FieldCategory, baseModuleEntity.Category);
            sqlBuilder.SetValue(BaseModuleEntity.FieldImageIndex, baseModuleEntity.ImageIndex);
            sqlBuilder.SetValue(BaseModuleEntity.FieldSelectedImageIndex, baseModuleEntity.SelectedImageIndex);
            sqlBuilder.SetValue(BaseModuleEntity.FieldNavigateUrl, baseModuleEntity.NavigateUrl);
            sqlBuilder.SetValue(BaseModuleEntity.FieldTarget, baseModuleEntity.Target);
            sqlBuilder.SetValue(BaseModuleEntity.FieldFormName, baseModuleEntity.FormName);
            sqlBuilder.SetValue(BaseModuleEntity.FieldAssemblyName, baseModuleEntity.AssemblyName);
            sqlBuilder.SetValue(BaseModuleEntity.FieldPermissionItemCode, baseModuleEntity.PermissionItemCode);
            sqlBuilder.SetValue(BaseModuleEntity.FieldPermissionScopeTables, baseModuleEntity.PermissionScopeTables);
            sqlBuilder.SetValue(BaseModuleEntity.FieldSortCode, baseModuleEntity.SortCode);
            sqlBuilder.SetValue(BaseModuleEntity.FieldEnabled, baseModuleEntity.Enabled);
            sqlBuilder.SetValue(BaseModuleEntity.FieldDeletionStateCode, baseModuleEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseModuleEntity.FieldIsPublic, baseModuleEntity.IsPublic);
            sqlBuilder.SetValue(BaseModuleEntity.FieldExpand, baseModuleEntity.Expand);
            sqlBuilder.SetValue(BaseModuleEntity.FieldAllowEdit, baseModuleEntity.AllowEdit);
            sqlBuilder.SetValue(BaseModuleEntity.FieldAllowDelete, baseModuleEntity.AllowDelete);
            sqlBuilder.SetValue(BaseModuleEntity.FieldDescription, baseModuleEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, id));
        }
    }
}
