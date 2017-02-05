//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkReportManager
    /// 
    /// 修改纪录
    /// 
    ///     2008.06.09 版本:1.2 吉日嘎拉 检查工作日志的功能在数据访问层中实现
    ///     2008.05.21 版本:1.1 吉日嘎拉 GetListByUser的修改
    ///     2008.05.17 版本:1.1 吉日嘎拉 审核管理添加姓名查询
    ///     2008.05.16 版本:1.1 吉日嘎拉 主键优化,在编辑处添加了一个职工姓名
    ///     2008.05.15 版本:1.0 吉日嘎拉 添加项目主键数据字段,并对部分主键进行修改
    ///     2008.05.08 版本:1.0 吉日嘎拉 公司主键及部门主键两个数据字段的添加,对于部分主键进行修改
    ///     2008.05.07 版本:1.0 吉日嘎拉 主键的优化
    ///     2008.05.04 版本:1.0 吉日嘎拉 主键的创建(获取数据）
    /// 
    /// 版本:1.2
    /// 
    /// <author>
    ///     <name>吉日嘎拉</name>
    ///     <date>2008.05.04</date>
    /// </author>
    /// </summary>
    public class BaseWorkReportManager : BaseManager
    {
        public BaseWorkReportManager()
        {
            base.CurrentTableName = BaseWorkReportTable.TableName;
        }

        public BaseWorkReportManager(IDbHelper dbHelper) : this()
        {
            DbHelper = dbHelper;
        }

        public BaseWorkReportManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        public BaseWorkReportManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        #region public DataTable GetDTByUser(string name, string value, string DepartmentId, DateTime date) 获取职员工作日志列表
        /// <summary>
        /// 获取职员工作日志列表
        /// </summary>
        /// <param name="staffId">职员主键</param>
        /// <param name="date">日期</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByUser(string staffId, string date)
        {
            string sqlQuery = " SELECT A.*, B." + BaseStaffTable.FieldRealName + " AS StaffFullName "
                            + "   FROM " + BaseWorkReportTable.TableName + " AS A"
                            + " LEFT JOIN " + BaseStaffTable.TableName + " AS B ON B." + BaseStaffTable.FieldId + "=A." + BaseWorkReportTable.FieldStaffId;
            if (staffId.Trim().Length != 0)
            {
                sqlQuery += " WHERE A." + BaseWorkReportTable.FieldStaffId + " = '" + staffId + "'";
            }
            if (date.Trim().Length == 0)
            {
                switch (DbHelper.CurrentDataBaseType)
                {
                    case DataBaseType.Access:
                    case DataBaseType.SqlServer:
                        sqlQuery += " AND DATEPART(WEEK, " + BaseWorkReportTable.FieldWorkDate + ") = DATEPART(WEEK, GETDATE())";
                        break;
                    case DataBaseType.Oracle:
                        break;
                    case DataBaseType.MySql:
                        sqlQuery += " AND WEEK(" + BaseWorkReportTable.FieldWorkDate + ") = WEEK(now())";
                        break;
                }
            }
            else if (date.Trim().Length > 0)
            {
                sqlQuery += " AND " + BaseWorkReportTable.FieldWorkDate + " = '" + date + "'";
            }
            sqlQuery += " ORDER BY A." + BaseWorkReportTable.FieldEnabled + ", A." + BaseWorkReportTable.FieldWorkDate + " DESC ";
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public int Update(BaseWorkReportEntity workReportEntity, out string statusCode) 更新一条记录
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="workReportEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(BaseWorkReportEntity workReportEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DbHelper, BaseWorkReportTable.TableName, workReportEntity.Id, workReportEntity.ModifiedUserId, workReportEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}

                // 进行更新操作
                returnValue = this.UpdateEntity(workReportEntity);
                if (returnValue == 1)
                {
                    statusCode = StatusCode.OKUpdate.ToString();
                }
                else
                {
                    // 数据可能被删除
                    statusCode = StatusCode.ErrorDeleted.ToString();
                }

            return returnValue;
        }
        #endregion

        #region public int UpdateEntity(BaseWorkReportEntity workReportEntity) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="workReportEntity">实体</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(BaseWorkReportEntity workReportEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(BaseWorkReportTable.TableName);
            this.SetEntity(sqlBuilder, workReportEntity);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetDBNow(BaseWorkReportTable.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkReportTable.FieldId, workReportEntity.Id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region private void SetEntity(SQLBuilder sqlBuilder, BaseWorkReportEntity workReportEntity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL生成器</param>
        /// <param name="workReportEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkReportEntity workReportEntity)
        {
            sqlBuilder.SetValue(BaseWorkReportTable.FieldWorkDate, workReportEntity.WorkDate);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldCategoryId, workReportEntity.CategoryId);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldContent, workReportEntity.Content);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldManHour, workReportEntity.ManHour);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldProjectId, workReportEntity.ProjectId);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldStaffId, workReportEntity.StaffId);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldEnabled, workReportEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldAuditStaffId, workReportEntity.AuditStaffId);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldScore, workReportEntity.Score);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldDescription, workReportEntity.Description);
        }
        #endregion

        #region private string AddEntity(BaseWorkReportEntity workReportEntity) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="workReportEntity">实体</param>
        /// <returns>主键</returns>
        private string AddEntity(BaseWorkReportEntity workReportEntity)
        {
            string returnValue = string.Empty;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string sequence = sequenceManager.GetSequence(BaseWorkReportTable.TableName);
            workReportEntity.SortCode = sequence;

            //获取职员的部门主键和公司主键
            BaseStaffManager staffManager = new BaseStaffManager(DbHelper, UserInfo);
            string CompanyId = staffManager.GetProperty(workReportEntity.StaffId, BaseStaffTable.FieldCompanyId);
            string DepartmentId = staffManager.GetProperty(workReportEntity.StaffId, BaseStaffTable.FieldDepartmentId);

            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginInsert(BaseWorkReportTable.TableName);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldId, sequence);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldCompanyId, CompanyId);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldDepartmentId, DepartmentId);
            this.SetEntity(sqlBuilder, workReportEntity);
            sqlBuilder.SetValue(BaseWorkReportTable.FieldCreateUserId, UserInfo.Id);
            sqlBuilder.SetDBNow(BaseWorkReportTable.FieldCreateOn);
            returnValue = sqlBuilder.EndInsert() > 0 ? sequence : string.Empty;
            return returnValue;
        }
        #endregion

        #region public string Add(BaseWorkReportEntity workReportEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="workReportEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>返回</returns>
        public string Add(BaseWorkReportEntity workReportEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            returnValue = this.AddEntity(workReportEntity);
            // 运行成功
            statusCode = StatusCode.OKAdd.ToString();
            return returnValue;
        }
        #endregion

        #region public DataTable Search(int enabled, DateTime startDate, DateTime endDate) 获取审核状态表
        /// 获取审核状态表
        /// </summary>
        /// <param name="enabled">审核状态</param>
        /// <param name="startDate"></param>
        /// <param name="paramEnd"></param>
        /// <returns>数据表</returns>
        public DataTable Search(int enabled, DateTime startDate, DateTime endDate)
        {
            string sqlQuery = " SELECT A.*, B." + BaseStaffTable.FieldRealName + " AS StaffFullName "
                            + " ,C." + BaseStaffTable.FieldUserName + " AS AuditName "
                            + "   FROM " + BaseWorkReportTable.TableName + " AS A"
                            + " LEFT JOIN " + BaseStaffTable.TableName + " AS B ON B." + BaseStaffTable.FieldId + "=A." + BaseWorkReportTable.FieldStaffId
                            + " LEFT JOIN " + BaseStaffTable.TableName + " AS C ON C." + BaseStaffTable.FieldId + "=A." + BaseWorkReportTable.FieldAuditStaffId;
            //+ " WHERE A." + BaseWorkReportTable.FieldEnabled + " = ? ";
            
            // 设置审核状态
            sqlQuery += " WHERE A." + BaseWorkReportTable.FieldEnabled + " = " + enabled;
            if (startDate.ToString().Trim().Length > 0)
            {
                sqlQuery += " AND A." + BaseWorkReportTable.FieldWorkDate + " >= '" + startDate + "'";
            }
            if (endDate.ToString().Trim().Length > 0)
            {
                sqlQuery += " AND A." + BaseWorkReportTable.FieldWorkDate + " <= '" + endDate + "'";
            }
            // 是否系统管理员
            if (!UserInfo.IsAdministrator)
            {
                BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
                string[] staffIds = permissionScopeManager.GetUserIds(UserInfo.Id, "Resource.ManagePermission");
                string staffs = BaseBusinessLogic.ObjectsToList(staffIds);
                sqlQuery += " AND A." + BaseWorkReportTable.FieldStaffId + " IN (" + staffs + ")";
            }
            sqlQuery += " ORDER BY " + BaseWorkReportTable.FieldWorkDate + " DESC ";

            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public int BatchSave(DataTable dataTable) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseWorkReportEntity workReportEntity = new BaseWorkReportEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Modified)
                {
                    workReportEntity.GetFrom(dataRow);
                    returnValue += this.UpdateEntity(workReportEntity) > 0 ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }
        #endregion

        #region public DateTime[] CheckWorkDate(string paramstaffId) 检查工作日志是否全
        /// <summary>
        /// 检查工作日志是否全
        /// </summary>
        /// <param name="staffId">职员主键</param>
        /// <returns>日期数组</returns>
        public DateTime[] CheckWorkDate(string paramstaffId)
        {
            DateTime[] returnValue = new DateTime[31];
            for (int i = -30; i <= 0; i++)
            {
                DateTime date = DateTime.Now.AddDays(i);
                if (!this.ExistDate(date, paramstaffId))
                {
                    returnValue[30 + i] = date;
                }
            }
            return returnValue;
        }
        #endregion

        #region private bool ExistDate(DateTime date, string staffId) 检查工作日志
        /// <summary>
        /// 检查工作日志
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="staffId">职员主键</param>
        /// <returns>有效</returns>
        private bool ExistDate(DateTime date, string staffId)
        {
            bool returnValue = false;
            string sqlQuery = " SELECT " + BaseWorkReportTable.FieldWorkDate
                            + " FROM " + BaseWorkReportTable.TableName
                            + " WHERE " + BaseWorkReportTable.FieldWorkDate + " = '" + date.ToShortDateString() + "'"
                            + " AND " + BaseWorkReportTable.FieldStaffId + "='" + staffId + "'";
            int existsDate = DbHelper.ExecuteNonQuery(sqlQuery);
            if (existsDate != 0)
            {
                returnValue = true;
            }
            return returnValue;
        }
        #endregion

        #region public Double SumManHour(string paramStaffId, DateTime paramDate)
        /// <summary>
        /// 求某天工时之和
        /// </summary>
        /// <param name="paramStaffID">当前操作员信息</param>
        /// <param name="paramDate">职员主键</param>
        /// <returns>工时之和</returns>
        public Double SumManHour(string paramStaffId, DateTime paramDate)
        {
            Double returnValue = 0.0;
            string sqlQuery = "SELECT SUM( " + BaseWorkReportTable.FieldManHour + ")"
                            + "FROM " + BaseWorkReportTable.TableName
                            + " WHERE " + BaseWorkReportTable.FieldWorkDate + "='" + paramDate.ToShortDateString()+"'"
                            + " AND " + BaseWorkReportTable.FieldStaffId + "='" + paramStaffId + "'";
            string sumManHour = DbHelper.ExecuteScalar(sqlQuery).ToString();
            if (!String.IsNullOrEmpty(sumManHour))
            {
                returnValue = Convert.ToDouble(sumManHour);
            }
            return returnValue;
        }
        #endregion
    }
}