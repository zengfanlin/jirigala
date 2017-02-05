//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Reflection;
using System.Xml;

namespace DotNet.Utilities
{
    /// <summary>
    /// ConfigHelper
    /// 访问用户配置文件的类。
    /// 
    /// 修改纪录
    ///
    ///		2008.06.08 版本：1.0 JiRiGaLa 创建。
    ///		
    ///	版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class TableConfigHelper
    {
        private string fileName = string.Empty;

        public string FielName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }

        public string SelectPath = "//resultMaps/resultMap/result";

        #region public string GetValue(string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string GetValue(string key)
        {
            return this.GetValue(this.FielName, this.SelectPath, key);
        }
        #endregion

        #region public string GetValue(string fileName, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string GetValue(string fileName, string key)
        {
            return this.GetValue(fileName, this.SelectPath, key);
        }
        #endregion

        #region public string GetValue(string fileName, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string GetValue(string fileName, string selectPath, string key)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return this.GetValue(xmlDocument, selectPath, key);
        }
        #endregion

        #region public string GetValue(XmlDocument xmlDocument, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="XmlDocument">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string GetValue(XmlDocument xmlDocument, string key)
        {
            return this.GetValue(xmlDocument, this.SelectPath, key);
        }
        #endregion

        #region public string GetValue(XmlDocument xmlDocument, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="XmlDocument">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string GetValue(XmlDocument xmlDocument, string selectPath, string key)
        {
            string returnValue = string.Empty;
            XmlNodeList XmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode XmlNode in XmlNodeList)
            {
                if (XmlNode.Attributes["property"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    returnValue = XmlNode.Attributes["column"].Value;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public void GetConfig(string fileName, object table) 从指定的文件读取文件结构配置
        /// <summary>
        /// 从指定的文件读取文件结构配置
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="table">文件结构配置</param>
        public void GetConfig(string fileName, object table)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            Type tableType = table.GetType();
            string fieldName = string.Empty;
            string columnName = string.Empty;
            foreach (FieldInfo fieldInfo in tableType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (fieldInfo.Name.StartsWith("Field"))
                {
                    // 字段名
                    fieldName = fieldInfo.Name.Substring("Field".Length);
                    // 列名
                    columnName = this.GetValue(xmlDocument, fieldName);
                    fieldInfo.SetValue(table, columnName);
                }
            }
        }
        #endregion
    }
}