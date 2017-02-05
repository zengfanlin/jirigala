using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace DotNet.Business
{
    using DotNet.Utilities;
    public partial class BaseManager : IBaseManager
    {
        public virtual List<T> GetListById<T>(string id)where T : new()
        {
            return this.GetList<T>(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="categoryId">类别主键</param>
        /// <returns>数据表</returns>
        public virtual List<T> GetListByCategory<T>(string categoryId) where T : new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCategoryId, categoryId));
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parameters);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(int topLimit = 0, string order = null) where T : new()
        {
            IDataReader dr=DbLogic.GetDataReader(DbHelper, this.CurrentTableName, null, topLimit, order);
            return GetList<T>(dr); 
        }
        
        public virtual List<T> GetList<T>(string[] ids) where T : new()
        {
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, BaseBusinessLogic.FieldId, ids);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(string name, Object[] values, string order = null) where T : new()
        {
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, name, values, order);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(KeyValuePair<string, object> parameter, string order) where T : new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parameters, 0, order);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string order) where T : new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parameters, 0, order);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(KeyValuePair<string, object> parameter, int topLimit, string order) where T : new()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(parameter);
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parameters, topLimit, order);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, string order) where T : new()
        {
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parameters, 0, order);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, int topLimit, string order) where T : new()
        {
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parameters, topLimit, order);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(params KeyValuePair<string, object>[] parameters) where T : new()
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            for (int i = 0; i < parameters.Length; i++)
            {
                parametersList.Add(parameters[i]);
            }
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, parametersList);
            return GetList<T>(dr); 
        }
        public virtual List<T> GetList<T>(string order) where T : new()
        {
            IDataReader dr = DbLogic.GetDataReader(DbHelper, this.CurrentTableName, null, 0, order);
            return GetList<T>(dr);
        }
        private List<T> GetList<T>(IDataReader dr) where T : new()
        {
            List<T> lstT = new List<T>();
            while (dr.NextResult())
            {
                dynamic dynTemp = new T();
                lstT.Add(dynTemp.GetFrom(dr));
            }
            return lstT;
        }
    }

}
