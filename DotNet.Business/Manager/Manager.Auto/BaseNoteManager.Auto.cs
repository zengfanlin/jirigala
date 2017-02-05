//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// <author>
    ///		<name>Caihuajun</name>
    ///		<date>2008.09.16</date>
    /// </author>
    /// </summary>
    public partial class BaseNoteManager : BaseManager
    {
        public BaseNoteManager()
        {
            base.CurrentTableName = BaseNoteEntity.TableName;
        }

        public BaseNoteManager(IDbHelper dbHelper) : this()
        {
            DbHelper = dbHelper;
        }

        public BaseNoteManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        public BaseNoteManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseNoteEntity noteEntity);

        #region private void SetEntity(SQLBuilder sqlBuilder, BaseNoteEntity noteEntity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL生成器</param>
        /// <param name="noteEntity">实体对象</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseNoteEntity noteEntity)
        {
            sqlBuilder.SetValue(BaseNoteEntity.FieldTitle, noteEntity.Title);
            sqlBuilder.SetValue(BaseNoteEntity.FieldCategoryId, noteEntity.CategoryId);
            sqlBuilder.SetValue(BaseNoteEntity.FieldCategoryFullName, noteEntity.CategoryFullName);
            sqlBuilder.SetValue(BaseNoteEntity.FieldColor, noteEntity.Color);
            sqlBuilder.SetValue(BaseNoteEntity.FieldContent, noteEntity.Content);
            sqlBuilder.SetValue(BaseNoteEntity.FieldEnabled, noteEntity.Enabled);
            sqlBuilder.SetValue(BaseNoteEntity.FieldImportant, noteEntity.Important);
            SetEntityExpand(sqlBuilder, noteEntity);
        }
        #endregion

        public string Add(BaseNoteEntity noteEntity)
        {
            return this.AddEntity(noteEntity);
        }

        #region public string AddEntity(BaseNoteEntity noteEntity) 添加一条记录
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="noteEntity">实体对象</param>
        /// <returns>主键</returns>
        public string AddEntity(BaseNoteEntity noteEntity)
        {
            string id = Guid.NewGuid().ToString();
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginInsert(this.CurrentTableName);
            sqlBuilder.SetValue(BaseNoteEntity.FieldId, id);
            this.SetEntity(sqlBuilder, noteEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseNoteEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetDBNow(BaseNoteEntity.FieldCreateOn);
            }
            sqlBuilder.SetDBNow(BaseNoteEntity.FieldModifiedOn);
            return sqlBuilder.EndInsert() > 0 ? id : string.Empty;
        }
        #endregion

        #region public int UpdateEntity(BaseNoteEntity noteEntity) 更新一条记录
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="noteEntity">实体对象</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(BaseNoteEntity noteEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, noteEntity);
            sqlBuilder.SetValue(BaseNoteEntity.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetDBNow(BaseNoteEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseNoteEntity.FieldId, noteEntity.Id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        public int Update(BaseNoteEntity noteEntity)
        {
            return this.UpdateEntity(noteEntity);
        }
    }
}