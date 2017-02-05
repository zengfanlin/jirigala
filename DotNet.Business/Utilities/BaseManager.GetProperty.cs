//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseManager
    /// 通用基类部分
    /// 
    /// 总觉得自己写的程序不上档次，这些新技术也玩玩，也许做出来的东西更专业了。
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.0 JiRiGaLa 进行提炼，把代码进行分组。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class BaseManager : IBaseManager
    {
        #region public virtual string GetCodeById(string id) 获取编码
        /// <summary>
        /// 获取编码
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>编号</returns>
        public virtual string GetCodeById(string id)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 0));
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, BaseBusinessLogic.FieldCode);
        }
        #endregion

        #region public virtual string GetIdByCode(string code) 获取主键
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns>主键</returns>
        public virtual string GetIdByCode(string code)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, code));
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 0));
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, BaseBusinessLogic.FieldId);
        }
        #endregion

        #region public virtual string GetFullNameByCode(string code) 获取名称
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns>名称</returns>
        public virtual string GetFullNameByCode(string code)
        {
            return this.GetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, code), BaseBusinessLogic.FieldFullName);
        }
        #endregion

        #region public virtual string GetFullNameById(string id) 获取名称
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>名称</returns>
        public virtual string GetFullNameById(string id)
        {
            return this.GetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id), BaseBusinessLogic.FieldFullName);
        }
        #endregion

        #region public virtual string GetParentId(string id) 获取父级主键
        /// <summary>
        /// 获取父节点主键
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>父级主键</returns>
        public virtual string GetParentId(string id)
        {
            return this.GetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id), BaseBusinessLogic.FieldParentId);
        }
        #endregion

        #region public virtual string GetParentIdByCode(string code) 获取父节点主键
        /// <summary>
        /// 获取父节点主键
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns>父级主键</returns>
        public virtual string GetParentIdByCode(string code)
        {
            return this.GetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, code), BaseBusinessLogic.FieldParentId);
        }
        #endregion

        #region public string GetParentIdByCategory(string categoryId, string code) 获取父节点主键
        /// <summary>
        /// 获取父节点主键
        /// </summary>
        /// <param name="categoryId">分类主键</param>
        /// <param name="code">主键</param>
        /// <returns>父级主键</returns>
        public virtual string GetParentIdByCategory(string categoryId, string code)
        {
            return this.GetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCategoryId, categoryId), new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, code), BaseBusinessLogic.FieldParentId);
        }
        #endregion

        #region public virtual string GetFullNameByCategory(string categoryId, string code) 获取名称
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="categoryId">类别主键</param>
        /// <param name="code">编码</param>
        /// <returns>名称</returns>
        public virtual string GetFullNameByCategory(string categoryId, string code)
        {
            return this.GetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCategoryId, categoryId), new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, code), BaseBusinessLogic.FieldFullName);
        }
        #endregion

        //
        // 读取属性
        //

        public virtual string GetProperty(object id, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetProperty(KeyValuePair<string, object> parameter, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetProperty(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetProperty(List<KeyValuePair<string, object>> parameters, string targetField)
        {
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, targetField);
        }

        public virtual string GetId(KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, BaseBusinessLogic.FieldId);
        }

        public virtual string GetId(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, BaseBusinessLogic.FieldId);
        }

        public virtual string GetId(List<KeyValuePair<string, object>> parameters)
        {
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameters, BaseBusinessLogic.FieldId);
        }

        public virtual string GetId(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parameterList = new List<KeyValuePair<string, object>>();
            foreach (var parameter in parameters)
            {
                parameterList.Add(parameter);
            }
            return DbLogic.GetProperty(DbHelper, this.CurrentTableName, parameterList, BaseBusinessLogic.FieldId);
        }
    }
}