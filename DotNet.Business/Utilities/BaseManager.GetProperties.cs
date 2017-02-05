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
        // 获得主键列表
        //

        public virtual string[] GetIds()
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, null, 0, BaseBusinessLogic.FieldId);
        }

        public virtual string[] GetIds(int topLimit, string targetField)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, null, topLimit, targetField);
        }

        public virtual string[] GetIds(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, 0, BaseBusinessLogic.FieldId);
        }

        public virtual string[] GetIds(KeyValuePair<string, object> parameter)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, 0, BaseBusinessLogic.FieldId);
        }

        public virtual string[] GetIds(string name, Object[] values)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, name, values, BaseBusinessLogic.FieldId);
        }

        public virtual string[] GetIds(List<KeyValuePair<string, object>> parameters)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, 0, BaseBusinessLogic.FieldId);
        }


        public virtual string[] GetProperties(string targetField)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, null, 0, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, 0, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter, int topLimit, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, topLimit, targetField);
        }

        public virtual string[] GetProperties(int topLimit, string targetField)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, null, topLimit, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, 0, targetField);
        }

        public virtual string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, int topLimit, string targetField)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, topLimit, targetField);
        }

        public virtual string[] GetProperties(string name, Object[] values, string targetField)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, name, values, targetField);
        }

        public virtual string[] GetProperties(List<KeyValuePair<string, object>> parameters, string targetField)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, 0, targetField);
        }

        public virtual string[] GetProperties(List<KeyValuePair<string, object>> parameters, int topLimit = 0, string targetField = null)
        {
            return DbLogic.GetProperties(DbHelper, this.CurrentTableName, parameters, topLimit, targetField);
        }
    }
}