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
    /// BaseNewsManager
    /// 新闻表
    ///
    /// 修改纪录
    ///
    ///		2010-07-28 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-28</date>
    /// </author>
    /// </summary>
    public partial class BaseNewsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseNewsManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseNewsEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseNewsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseNewsManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseNewsManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseNewsManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseNewsManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="newsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseNewsEntity newsEntity)
        {
            return this.AddEntity(newsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="newsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseNewsEntity newsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(newsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="newsEntity">实体</param>
        public int Update(BaseNewsEntity newsEntity)
        {
            return this.UpdateEntity(newsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseNewsEntity GetEntity(string id)
        {
            BaseNewsEntity newsEntity = new BaseNewsEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldId, id)));
            return newsEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="newsEntity">实体</param>
        public string AddEntity(BaseNewsEntity newsEntity)
        {
            string sequence = string.Empty;
            sequence = newsEntity.Id;
            if (newsEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                newsEntity.SortCode = int.Parse(sequence);
            }
            if (newsEntity.Id is string)
            {
                this.Identity = false;
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseNewsEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseNewsEntity.FieldId, newsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(BaseNewsEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        if (string.IsNullOrEmpty(newsEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            newsEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseNewsEntity.FieldId, newsEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, newsEntity);
            if (UserInfo != null)
            {
                newsEntity.CreateUserId = UserInfo.Id;
                newsEntity.CreateBy = UserInfo.RealName;
                sqlBuilder.SetValue(BaseNewsEntity.FieldCreateUserId, newsEntity.CreateUserId);
                sqlBuilder.SetValue(BaseNewsEntity.FieldCreateBy, newsEntity.CreateBy);
                newsEntity.ModifiedBy = UserInfo.RealName;
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedUserId, newsEntity.CreateUserId);
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedBy, newsEntity.CreateBy);
            }
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldCreateOn);
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldModifiedOn);
            /*
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldModifiedOn);
             */
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
        /// <param name="newsEntity">实体</param>
        public int UpdateEntity(BaseNewsEntity newsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, newsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseNewsEntity.FieldId, newsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseNewsEntity newsEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="newsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseNewsEntity newsEntity)
        {
            if (newsEntity.Contents == null)
            {
                newsEntity.FileSize = 0;
            }
            else
            {
                newsEntity.FileSize = newsEntity.Contents.Length;
            }
            sqlBuilder.SetValue(BaseNewsEntity.FieldDepartmentId, newsEntity.DepartmentId);
            sqlBuilder.SetValue(BaseNewsEntity.FieldDepartmentName, newsEntity.DepartmentName);
            sqlBuilder.SetValue(BaseNewsEntity.FieldFolderId, newsEntity.FolderId);
            sqlBuilder.SetValue(BaseNewsEntity.FieldCategoryCode, newsEntity.CategoryCode);
            sqlBuilder.SetValue(BaseNewsEntity.FieldCode, newsEntity.Code);
            sqlBuilder.SetValue(BaseNewsEntity.FieldTitle, newsEntity.Title);
            sqlBuilder.SetValue(BaseNewsEntity.FieldFilePath, newsEntity.FilePath);
            sqlBuilder.SetValue(BaseNewsEntity.FieldIntroduction, newsEntity.Introduction);
            sqlBuilder.SetValue(BaseNewsEntity.FieldContents, newsEntity.Contents);
            sqlBuilder.SetValue(BaseNewsEntity.FieldSource, newsEntity.Source);
            sqlBuilder.SetValue(BaseNewsEntity.FieldKeywords, newsEntity.Keywords);
            sqlBuilder.SetValue(BaseNewsEntity.FieldFileSize, newsEntity.FileSize);
            sqlBuilder.SetValue(BaseNewsEntity.FieldImageUrl, newsEntity.ImageUrl);
            sqlBuilder.SetValue(BaseNewsEntity.FieldHomePage, newsEntity.HomePage);
            sqlBuilder.SetValue(BaseNewsEntity.FieldSubPage, newsEntity.SubPage);
            sqlBuilder.SetValue(BaseNewsEntity.FieldAuditStatus, newsEntity.AuditStatus);
            sqlBuilder.SetValue(BaseNewsEntity.FieldReadCount, newsEntity.ReadCount);
            sqlBuilder.SetValue(BaseNewsEntity.FieldDeletionStateCode, newsEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseNewsEntity.FieldDescription, newsEntity.Description);
            sqlBuilder.SetValue(BaseNewsEntity.FieldEnabled, newsEntity.Enabled);
            sqlBuilder.SetValue(BaseNewsEntity.FieldSortCode, newsEntity.SortCode);
            SetEntityExpand(sqlBuilder, newsEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseNewsEntity.FieldId, id));
        }
    }
}
