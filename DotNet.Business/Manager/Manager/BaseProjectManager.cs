//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BUBaseProject
    /// 项目结构定义部分
    /// 
    /// 修改纪录
    ///     2006.05.08 版本：1.1 JiRiGaLa  主键规范化，添加注释，对添加、更新进行打包。
    ///     2006.05.23 版本：1.1 GetFrom  添加了一个GetProjectList()
    /// 版本：1.1
    /// <author>
    ///		<name>GetFrom</name>
    ///		<date>2006.05.23</date>
    /// </author> 
    /// </summary>
    public class BaseProjectManager : BaseManager
    {
        public BaseProjectManager()
        {
            base.CurrentTableName = BaseProjectEntity.TableName;
        }

        public BaseProjectManager(IDbHelper dbHelper):this()
        {
            DbHelper = dbHelper;
        }

        public BaseProjectManager(BaseUserInfo userInfo): this()
        {
            UserInfo = userInfo;
        }

        public BaseProjectManager(IDbHelper dbHelper, BaseUserInfo userInfo): this(dbHelper)
        {
            UserInfo = userInfo;
        }

        #region public string IDToCode(string id)
        /// <summary>
        /// 通过ID获取编码
        /// </summary>
        /// <param name="dbHelper">数据库接连</param>
        /// <param name="id">ID</param>
        /// <returns>编码</returns>
        public string IDToCode(string id)
        {
            return this.GetProperty( id, BaseProjectEntity.FieldCode);
        }
        #endregion

        #region public string FieldToList(DataTable dataTable)
        /// <summary>
        /// 表格主键变为字符串列表
        /// </summary>
        /// <param name="DataSetOrganize">数据集</param>
        /// <returns>主键字符串</returns>
        public string FieldToList(DataTable dataTable)
        {
            //return this.FieldToList(dataTable, BaseProjectEntity.FieldId);
            return "";
        }
        #endregion

        #region public DataTable GetList()
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataTable GetList()
        {
            string sqlQuery = " SELECT  Id, Code, FullName, CategoryId, Description, Enabled, OrganizeId, ManagerId, CategoryId, "
            + " (SELECT FullName FROM " + BaseOrganizeEntity.TableName + " WHERE (ID = T_Project.OrganizeId)) AS OrganizeFullName ,"
            + " (SELECT FullName FROM " + BaseStaffEntity.TableName + " WHERE (ID = T_Project.ManagerId)) AS ManagerFullName ,"
            + " (SELECT FullName FROM T_ItemDetails WHERE (ID = T_Project.CategoryId)) AS CategoryFullName "
            + " FROM " + BaseProjectEntity.TableName;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion
    }
}
