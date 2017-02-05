//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
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
        // 判断数据是否存在
        //
        public virtual bool Exists(object id)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(this.PrimaryKey, id));
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters);
        }

        public virtual bool Exists(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            for (int i = 0; i < parameters.Length; i++)
            {
                parametersList.Add(parameters[i]);
            }
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parametersList);
        }
        
        public virtual bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters);
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, object id)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters, new KeyValuePair<string, object>(this.PrimaryKey, id));
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters, parameter);
        }

        public virtual bool Exists(KeyValuePair<string, object> parameter, object id)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters, new KeyValuePair<string, object>(this.PrimaryKey, id));
        }

        public virtual bool Exists(List<KeyValuePair<string, object>> parameters, object id = null)
        {
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters, new KeyValuePair<string, object>(this.PrimaryKey, id));
        }
    }
}