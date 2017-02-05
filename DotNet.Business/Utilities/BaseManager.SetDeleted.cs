//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
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
    ///		2012.03.27 版本：2.1 JiRiGaLa 进行整理。
    ///		2012.03.21 版本：2.0 JiRiGaLa 进行整理。
    ///		2012.02.04 版本：1.0 JiRiGaLa 进行提炼，把代码进行分组。
    ///
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.27</date>
    /// </author> 
    /// </summary>
    public partial class BaseManager : IBaseManager
    {
        #region public virtual int SetDeleted(object id, bool enabled = false, bool modifiedUser = false) 删除标志
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="enabled">有效</param>
        /// <param name="modifiedUser">修改者</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(object id, bool enabled = false, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 1));
            if (enabled)
            {
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldEnabled, 0));
            }
            if (modifiedUser && this.UserInfo != null)
            {
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id));
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldModifiedOn, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            return this.SetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id), parameters);
        }
        #endregion

        #region public virtual int SetDeleted(object[] ids, bool enabled = false, bool modifiedUser = false) 批量删除标志
        /// <summary>
        /// 批量删除标志
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="enabled">有效</param>
        /// <param name="modifiedUser">修改者</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(object[] ids, bool enabled = false, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 1));
            if (enabled)
            {
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldEnabled, 0));
            }
            if (modifiedUser && this.UserInfo != null)
            {
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id));
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldModifiedOn, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ));
            }
            return this.SetProperty(ids, parameters);
        }
        #endregion

        #region public virtual int SetDeleted(params KeyValuePair<string, object>[] parameters) 删除标志
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <param name="parameter">更新字段，值</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            for (int i = 0; i < parameters.Length; i++)
            {
                parametersList.Add(parameters[i]);
            }
            return this.SetProperty(parametersList, new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 1));
        }
        #endregion

        #region public virtual int SetDeleted(List<KeyValuePair<string, object>> whereParameters, bool modifiedUser = false) 批量删除标志
        /// <summary>
        /// 批量删除标志
        /// </summary>
        /// <param name="whereParameters">条件字段，值</param>
        /// <returns>影响行数</returns>
        public virtual int SetDeleted(List<KeyValuePair<string, object>> whereParameters, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 1));
            if (modifiedUser && this.UserInfo != null)
            {
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id));
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldModifiedOn, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ));
            }
            return this.SetProperty(whereParameters, parameters);
        }
        #endregion
    }
}