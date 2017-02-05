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
        //
        // 设置属性
        //

        public virtual int SetProperty(KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.SetProperty(DbHelper, this.CurrentTableName, null, parameters);
        }

        public virtual int SetProperty(object id, KeyValuePair<string, object> parameter)
        {
            return this.SetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id), parameter);
        }

        public virtual int SetProperty(object id, List<KeyValuePair<string, object>> parameters)
        {
            return this.SetProperty(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id), parameters);
        }

        public virtual int SetProperty(object[] ids, KeyValuePair<string, object> parameter)
        {
            return this.SetProperty(BaseBusinessLogic.FieldId, ids, parameter);
        }

        public virtual int SetProperty(object[] ids, List<KeyValuePair<string, object>> parameters)
        {
            return this.SetProperty(BaseBusinessLogic.FieldId, ids, parameters);
        }

        public virtual int SetProperty(string name, object[] values, KeyValuePair<string, object> parameter)
        {
            int returnValue = 0;
            if (values == null)
            {
                returnValue += this.SetProperty(new KeyValuePair<string, object>(name, string.Empty), parameter);
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    returnValue += this.SetProperty(new KeyValuePair<string, object>(name, values[i]), parameter);
                }
            }
            return returnValue;
        }

        public virtual int SetProperty(string name, object[] values, List<KeyValuePair<string, object>> parameters)
        {
            int returnValue = 0;
            if (values == null)
            {
                returnValue += this.SetProperty(new KeyValuePair<string, object>(name, string.Empty), parameters);
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    returnValue += this.SetProperty(new KeyValuePair<string, object>(name, values[i]), parameters);
                }
            }
            return returnValue;
        }

        public virtual int SetProperty(KeyValuePair<string, object> whereParameter1, KeyValuePair<string, object> whereParameter2, KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(whereParameter1);
            whereParameters.Add(whereParameter2);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);

            return DbLogic.SetProperty(DbHelper, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(KeyValuePair<string, object> whereParameter, KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(whereParameter);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.SetProperty(DbHelper, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(List<KeyValuePair<string, object>> whereParameters, KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);

            return DbLogic.SetProperty(DbHelper, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(KeyValuePair<string, object> whereParameter, List<KeyValuePair<string, object>> parameters)
        {
            List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
            whereParameters.Add(whereParameter);
            return DbLogic.SetProperty(DbHelper, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters)
        {
            return DbLogic.SetProperty(DbHelper, this.CurrentTableName, whereParameters, parameters);
        }
    }
}