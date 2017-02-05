//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizeManager（程序OK）
    /// 组织机构、部门表
    ///
    /// 修改记录
    ///     
    ///     2007.12.02 版本：3.3 JiRiGaLa   增加 SetEntity 方法，优化主键。
    ///     2007.05.31 版本：3.2 JiRiGaLa   OKAdd，OKUpdate，OKDelete 状态进行改进整理。
    ///     2007.05.29 版本：3.1 JiRiGaLa   ErrorDeleted，ErrorChanged 状态进行改进整理。
    ///	    2007.05.29 版本：3.1 JiRiGaLa   BatchSave，ErrorDataRelated，force 进行改进整理。
    ///	    2007.05.29 版本：3.1 JiRiGaLa   ReturnStatusCode，ReturnStatusMessage 进行改进。
    ///	    2007.05.29 版本：3.1 JiRiGaLa   BatchSave 进行改进。
    ///		2007.04.18 版本：3.0 JiRiGaLa	重新整理主键。
    ///		2007.01.17 版本：2.0 JiRiGaLa	重新整理主键。
    ///		2006.02.06 版本：1.1 JiRiGaLa	重新调整主键的规范化。
    ///		2003.12.29 版本：1.0 JiRiGaLa	最后修改，改进成以后可以扩展到多种数据库的结构形式
    ///		2004.08.16 版本：1.0 JiRiGaLa	更新部分主键
    ///		2004.09.06 版本：1.0 JiRiGaLa	更新一些获得子部门，上级部门等的主键部分
    ///		2004.11.11 版本：1.0 JiRiGaLa	整理主键
    ///		2004.11.12 版本：1.0 JiRiGaLa	有些思想进行了改进。
    ///
    /// 版本：3.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.02</date>
    /// </author>
    /// </summary>
    public partial class BaseOrganizeManager : BaseManager //, IBaseOrganizeManager
    {
        public string Add(BaseOrganizeEntity organizeEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查是否重复
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, organizeEntity.ParentId));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldFullName, organizeEntity.FullName));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));

            //注意Access 的时候，类型不匹配，会出错故此将 ID 传入
            if (BaseSystemInfo.UserCenterDbType == CurrentDbType.Access)
            {
                if (this.Exists(parameters, organizeEntity.Id))
                {
                    // 名称已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCode, organizeEntity.Code));
                    parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
                    if (organizeEntity.Code.Length > 0 && this.Exists(parameters))
                    {
                        // 编号已重复
                        statusCode = StatusCode.ErrorCodeExist.ToString();
                    }
                    else
                    {
                        returnValue = this.AddEntity(organizeEntity);
                        // 运行成功
                        statusCode = StatusCode.OKAdd.ToString();
                    }
                }
            }
            else if (this.Exists(parameters))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCode, organizeEntity.Code));
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
                if (organizeEntity.Code.Length > 0 && this.Exists(parameters))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    returnValue = this.AddEntity(organizeEntity);
                    // 运行成功
                    statusCode = StatusCode.OKAdd.ToString();
                }
            }
            return returnValue;
        }

        public string AddByDetail(string parentId, string code, string fullName, string category, string outerPhone, string innerPhone, string fax, bool enabled, out string statusCode)
        {
            BaseOrganizeEntity organizeEntity = new BaseOrganizeEntity();
            organizeEntity.ParentId = parentId;
            organizeEntity.Code = code;
            organizeEntity.FullName = fullName;
            organizeEntity.Category = category;
            organizeEntity.OuterPhone = outerPhone;
            organizeEntity.InnerPhone = innerPhone;
            organizeEntity.Fax = fax;
            organizeEntity.Enabled = enabled ? 1 : 0;
            return this.Add(organizeEntity, out statusCode);
        }

        public DataTable GetInnerOrganize(string organizeId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldIsInnerOrganize, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
        }

        public DataTable GetCompanyDT(string organizeId)
        {
            return this.GetDataTable(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCategory, "Company"), BaseOrganizeEntity.FieldSortCode);
        }

        public DataTable GetCompanyDTByName(string organizeName)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCategory, "Company"));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldFullName, organizeName));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
        }

        public DataTable GetDepartmentDT(string organizeId = null)
        {
            if (String.IsNullOrEmpty(organizeId))
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCategory, "Department"));
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
                return this.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
            }
            return this.GetDataTable(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, organizeId), new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCategory, "Department"), BaseOrganizeEntity.FieldSortCode);
        }

        public DataTable GetFullNameDepartment(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                BaseOrganizeEntity subCompanyNameEntity = DotNetService.Instance.OrganizeService.GetEntity(UserInfo, dr[BaseOrganizeEntity.FieldParentId].ToString());
                dr[BaseOrganizeEntity.FieldFullName] = subCompanyNameEntity.FullName.ToString() + "--" + dr[BaseOrganizeEntity.FieldFullName].ToString();
                BaseOrganizeEntity companyEntity = DotNetService.Instance.OrganizeService.GetEntity(UserInfo, subCompanyNameEntity.ParentId.ToString());
                dr[BaseOrganizeEntity.FieldFullName] = companyEntity.FullName.ToString() + "--" + dr[BaseOrganizeEntity.FieldFullName].ToString();
            }
            return dataTable;
        }

        public DataTable GetDepartmentDTByName(string organizeName)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCategory, "Department"));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldFullName, organizeName));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
        }

        public int Update(BaseOrganizeEntity organizeEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DbHelper, BaseOrganizeEntity.TableName, organizeEntity.Id, organizeEntity.ModifiedUserId, organizeEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, organizeEntity.ParentId));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldFullName, organizeEntity.FullName));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters, organizeEntity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                // 检查编号是否重复
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldCode, organizeEntity.Code));
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));

                if (organizeEntity.Code.Length > 0 && this.Exists(parameters, organizeEntity.Id))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    // 1:更新部门的信息
                    returnValue = this.UpdateEntity(organizeEntity);
                    // 2:组织机构修改时，用户表的公司，部门，工作组数据给同步更新。
                    BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
                    userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldCompanyId, organizeEntity.Id), new KeyValuePair<string, object>(BaseUserEntity.FieldCompanyName, organizeEntity.FullName));
                    userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldDepartmentId, organizeEntity.Id), new KeyValuePair<string, object>(BaseUserEntity.FieldDepartmentName, organizeEntity.FullName));
                    userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldWorkgroupId, organizeEntity.Id), new KeyValuePair<string, object>(BaseUserEntity.FieldWorkgroupName, organizeEntity.FullName));
                    // 03：组织机构修改时，文件夹同步更新
                    BaseFolderManager folderManager = new BaseFolderManager(this.DbHelper, this.UserInfo);
                    folderManager.SetProperty(new KeyValuePair<string, object>(BaseFolderEntity.FieldFolderName, organizeEntity.FullName), new KeyValuePair<string, object>(BaseFolderEntity.FieldId, organizeEntity.Id));
                    if (returnValue == 1)
                    {
                        statusCode = StatusCode.OKUpdate.ToString();
                    }
                    else
                    {
                        statusCode = StatusCode.ErrorDeleted.ToString();
                    }
                }
            }
            //}
            return returnValue;
        }

        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseOrganizeEntity organizeEntity = new BaseOrganizeEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseOrganizeEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.DeleteEntity(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseOrganizeEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        organizeEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(organizeEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    organizeEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(organizeEntity).Length > 0 ? 1 : 0;
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

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, parentId));
        }

        /// <summary>
        /// 部门缓存表
        /// </summary>
        private DataTable DTOrganize = null;

        /// <summary>
        ///  部门名称前缀
        /// </summary>
        private string head = "|";

        /// <summary>
        /// 部门绑定表
        /// </summary>
        private DataTable organizeTable = new DataTable(BaseOrganizeEntity.TableName);

        #region public DataTable GetOrganizeTree(DataTable dtOrganize = null) 绑定下拉筐数据,组织机构树表
        /// <summary>
        /// 绑定下拉筐数据,组织机构树表
        /// </summary>
        /// <param name="dtOrganize">组织机构</param>
        /// <returns>组织机构树表</returns>
        public DataTable GetOrganizeTree(DataTable dtOrganize = null)
        {
            if (dtOrganize != null)
            {
                DTOrganize = dtOrganize;
            }
            // 初始化部门表
            if (organizeTable.Columns.Count == 0)
            {
                //建立表的列，不能重复建立
                organizeTable.Columns.Add(new DataColumn(BaseOrganizeEntity.FieldId, System.Type.GetType("System.Int32")));
                organizeTable.Columns.Add(new DataColumn(BaseOrganizeEntity.FieldFullName, System.Type.GetType("System.String")));
            }
            if (DTOrganize == null)
            {
                // 绑定部门
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldIsInnerOrganize, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));

                DTOrganize = this.GetDataTable(parameters, BaseOrganizeEntity.FieldSortCode);
            }
            // 查找子部门
            for (int i = 0; i < DTOrganize.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(DTOrganize.Rows[i][BaseOrganizeEntity.FieldParentId].ToString()))
                {
                    DataRow dr = organizeTable.NewRow();
                    dr[BaseOrganizeEntity.FieldId] = DTOrganize.Rows[i][BaseOrganizeEntity.FieldId].ToString();
                    dr[BaseOrganizeEntity.FieldFullName] =
                        DTOrganize.Rows[i][BaseOrganizeEntity.FieldFullName].ToString();
                    organizeTable.Rows.Add(dr);
                    this.GetSubOrganize(DTOrganize.Rows[i][BaseOrganizeEntity.FieldId].ToString());
                }

            }
            return organizeTable;
        }

        /// <summary>
        /// 获取子部门
        /// </summary>
        /// <param name="parentId">父节点主键</param>
        public void GetSubOrganize(string parentId)
        {
            head += "--";
            for (int i = 0; i < DTOrganize.Rows.Count; i++)
            {
                if (DTOrganize.Rows[i][BaseOrganizeEntity.FieldParentId].ToString().EndsWith(parentId))
                {
                    DataRow dr = organizeTable.NewRow();
                    dr[BaseOrganizeEntity.FieldId] = DTOrganize.Rows[i][BaseOrganizeEntity.FieldId].ToString();
                    dr[BaseOrganizeEntity.FieldFullName] = head + DTOrganize.Rows[i][BaseOrganizeEntity.FieldFullName].ToString();
                    organizeTable.Rows.Add(dr);
                    this.GetSubOrganize(DTOrganize.Rows[i][BaseOrganizeEntity.FieldId].ToString());
                }
            }
            // 子部门遍历完成后，退到上一级
            head = head.Substring(0, head.Length - 2);
        }
        #endregion

        #region  public DataTable Search(string searchValue, string parentId=null,string isInner="1") 搜索部门
        /// <summary>
        /// 搜索部门
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="parentId"></param>
        /// <param name="isInner"></param>
        /// <returns></returns>
        public DataTable Search(string searchValue, string organizeId, bool isInnerOrganize = true)
        {
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT * "
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + BaseOrganizeEntity.FieldDeletionStateCode + " =  0 ";
            if (isInnerOrganize)
            {
                string innerOrganize = isInnerOrganize ? "1" : "0";
                sqlQuery += " AND " + BaseOrganizeEntity.FieldIsInnerOrganize + " = " + innerOrganize;
            }
            if (!string.IsNullOrEmpty(organizeId))
            {
                sqlQuery += " AND " + BaseOrganizeEntity.FieldParentId + " = " + organizeId;
            }
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();

            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                sqlQuery += " AND " + BaseOrganizeEntity.FieldFullName + " LIKE " + DbHelper.GetParameter(BaseOrganizeEntity.FieldFullName);

                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseOrganizeEntity.FieldFullName, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseOrganizeEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }
        #endregion
    }
}