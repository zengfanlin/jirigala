//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd .
//-----------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Common.Business
{
    using DotNet.Common.Model;
    using DotNet.Common.Utilities;
    using DotNet.Common.DbUtilities;

    /// <summary>
    /// BUBaseAttchment
    /// 附件
    ///		
    ///     2007.11.12 版本：1.0 JiRiGaLa 
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.11.12</date>
    /// </author> 
    /// </summary>
    public class BaseAttchmentDao : BaseDao, IBaseDao
    {
        public BaseAttchmentDao()
        {
            base.CurrentTableName = BaseAttchmentTable.TableName;
        }

        public BaseAttchmentDao(IDbHelper dbHelper, BaseUserInfo userInfo)
        {
            this.DbHelper = dbHelper;
            this.UserInfo = userInfo;
        }

        private String defaultorder;
        public String DefaultOrder
        {
            get
            {
                defaultorder = BaseAttchmentTable.FieldSortCode;
                return defaultorder;
            }
        }

        #region public void ClearProperty(BaseAttchmentEntity attchmentEntity)
        /// <summary>
        /// 清除内容
        /// </summary>
        public void ClearProperty(BaseAttchmentEntity attchmentEntity)
        {
            attchmentEntity.ID = String.Empty;	// 代码
            attchmentEntity.CategoryID = String.Empty;	// 功能分类代码
            attchmentEntity.ObjectID = String.Empty; // 唯一识别代码
            attchmentEntity.FileName = String.Empty; // 文件名
            attchmentEntity.FilePath = String.Empty; // 文件路径
            attchmentEntity.FileContent = String.Empty; // 文件内容
            attchmentEntity.ReadCount = 0;            // 被阅读次数
            attchmentEntity.SortCode = String.Empty; // 排序
            attchmentEntity.Description = String.Empty; // 备注
            attchmentEntity.StateCode = String.Empty;	// 状态码
            attchmentEntity.Enabled = true;	        // 有效
            attchmentEntity.CreateUserID = String.Empty; // 创建者代码
            attchmentEntity.CreateDate = String.Empty;	// 创建时间
            attchmentEntity.ModifyUserID = String.Empty; // 最后修改者代码
            attchmentEntity.ModifyDate = String.Empty; // 最后修改时间
        }
        #endregion

        #region public BaseAttchmentEntity GetFrom(DataRow dataRow)
        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <returns>BUBaseAttchmentDefine</returns>
        public BaseAttchmentEntity GetFrom(DataRow dataRow, BaseAttchmentEntity attchmentEntity)
        {
            attchmentEntity.ID = dataRow[BaseAttchmentTable.FieldID].ToString();                   // 代码
            attchmentEntity.CategoryID = dataRow[BaseAttchmentTable.FieldCategoryID].ToString();           // 功能分类代码
            attchmentEntity.ObjectID = dataRow[BaseAttchmentTable.FieldObjectID].ToString();             // 唯一识别代码
            attchmentEntity.FileName = dataRow[BaseAttchmentTable.FieldFileName].ToString();             // 文件名
            attchmentEntity.FilePath = dataRow[BaseAttchmentTable.FieldFilePath].ToString();             // 文件路径
            attchmentEntity.FileContent = dataRow[BaseAttchmentTable.FieldFileContent].ToString();          // 文件内容
            attchmentEntity.ReadCount = int.Parse(dataRow[BaseAttchmentTable.FieldReadCount].ToString()); // 被阅读次数
            attchmentEntity.StateCode = dataRow[BaseAttchmentTable.FieldStateCode].ToString();            // 状态码
            attchmentEntity.SortCode = dataRow[BaseAttchmentTable.FieldSortCode].ToString();             // 排序
            attchmentEntity.Description = dataRow[BaseAttchmentTable.FieldDescription].ToString();          // 备注
            attchmentEntity.Enabled = dataRow[BaseAttchmentTable.FieldEnabled].ToString().Equals("1");  // 有效
            attchmentEntity.CreateUserID = dataRow[BaseAttchmentTable.FieldCreateUserID].ToString();        // 创建者代码
            attchmentEntity.CreateDate = dataRow[BaseAttchmentTable.FieldCreateDate].ToString();           // 创建时间
            attchmentEntity.ModifyUserID = dataRow[BaseAttchmentTable.FieldModifyUserID].ToString();        // 最后修改者代码
            attchmentEntity.ModifyDate = dataRow[BaseAttchmentTable.FieldModifyDate].ToString();           // 最后修改时间
            return attchmentEntity;
        }
        #endregion

        #region public override String AddEntity(Object myObject) 添加一条记录
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="mySend">发文定义</param>
        /// <returns>代码</returns>
        public override String AddEntity(Object myObject)
        {
            String id = BaseSequenceDao.Instance.GetSequence(this.DbHelper, BaseAttchmentTable.TableName);
            BaseAttchmentEntity myAttchment = (BaseAttchmentEntity)myObject;
            SQLBuilder sqlBuilder = new SQLBuilder(this.DbHelper);
            sqlBuilder.BeginInsert(BaseAttchmentTable.TableName);
            sqlBuilder.SetValue(BaseAttchmentTable.FieldID, id);
            sqlBuilder.SetValue(BaseAttchmentTable.FieldCategoryID, myAttchment.CategoryID);
            sqlBuilder.SetValue(BaseAttchmentTable.FieldObjectID, myAttchment.ObjectID);
            sqlBuilder.SetValue(BaseAttchmentTable.FieldFileName, myAttchment.FileName);
            sqlBuilder.SetValue(BaseAttchmentTable.FieldDescription, myAttchment.Description);
            sqlBuilder.SetValue(BaseAttchmentTable.FieldCreateUserID, this.UserInfo.ID);
            sqlBuilder.SetDBNow(BaseAttchmentTable.FieldCreateDate);
            sqlBuilder.SetDBNow(BaseAttchmentTable.FieldModifyDate);
            return sqlBuilder.EndInsert() > 0 ? id : String.Empty;
        }
        #endregion
    }
}