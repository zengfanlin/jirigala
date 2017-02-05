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
    /// BaseCommentManager
    /// 评论表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-14 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-14</date>
    /// </author>
    /// </summary>
    public partial class BaseCommentManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseCommentManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseCommentEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseCommentManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseCommentManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseCommentManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseCommentManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseCommentManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseCommentEntity baseCommentEntity)
        {
            return this.AddEntity(baseCommentEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseCommentEntity baseCommentEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseCommentEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        public int Update(BaseCommentEntity baseCommentEntity)
        {
            return this.UpdateEntity(baseCommentEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseCommentEntity GetEntity(string id)
        {
            BaseCommentEntity baseCommentEntity = new BaseCommentEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseCommentEntity.FieldId, id)));
            return baseCommentEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        public string AddEntity(BaseCommentEntity baseCommentEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (baseCommentEntity.SortCode == null || baseCommentEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseCommentEntity.SortCode = int.Parse(sequence);
            }
            if (baseCommentEntity.Id != null)
            {
                sequence = baseCommentEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseCommentEntity.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(baseCommentEntity.Id)) 
                { 
                    sequence = BaseBusinessLogic.NewGuid(); 
                    baseCommentEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(BaseCommentEntity.FieldId, baseCommentEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseCommentEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseCommentEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(baseCommentEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseCommentEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseCommentEntity.FieldId, baseCommentEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseCommentEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseCommentEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseCommentEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseCommentEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseCommentEntity.FieldModifiedOn);
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
        /// <param name="baseCommentEntity">实体</param>
        public int UpdateEntity(BaseCommentEntity baseCommentEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseCommentEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseCommentEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseCommentEntity.FieldId, baseCommentEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseCommentEntity commentEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="commentEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseCommentEntity commentEntity)
        {   
            sqlBuilder.SetValue(BaseCommentEntity.FieldDepartmentId, commentEntity.DepartmentId);
            sqlBuilder.SetValue(BaseCommentEntity.FieldDepartmentName, commentEntity.DepartmentName);
            sqlBuilder.SetValue(BaseCommentEntity.FieldParentId, commentEntity.ParentId);
            sqlBuilder.SetValue(BaseCommentEntity.FieldCategoryCode, commentEntity.CategoryCode);
            sqlBuilder.SetValue(BaseCommentEntity.FieldObjectId, commentEntity.ObjectId);
            sqlBuilder.SetValue(BaseCommentEntity.FieldTargetURL, commentEntity.TargetURL);
            sqlBuilder.SetValue(BaseCommentEntity.FieldTitle, commentEntity.Title);
            sqlBuilder.SetValue(BaseCommentEntity.FieldContents, commentEntity.Contents);
            sqlBuilder.SetValue(BaseCommentEntity.FieldIPAddress, commentEntity.IPAddress);
            sqlBuilder.SetValue(BaseCommentEntity.FieldDeletionStateCode, commentEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseCommentEntity.FieldEnabled, commentEntity.Enabled);
            sqlBuilder.SetValue(BaseCommentEntity.FieldDescription, commentEntity.Description);
            sqlBuilder.SetValue(BaseCommentEntity.FieldSortCode, commentEntity.SortCode);
            SetEntityExpand(sqlBuilder, commentEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseCommentEntity.FieldId, id));
        }
    }
}
