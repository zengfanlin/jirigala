//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using System.Xml;

namespace DotNet.WinForm
{
    /// <summary>
    ///	CodeGenerator
    /// 主键生成器
    /// 
    /// 修改纪录
    ///     2012.03.29 版本：3.5    张广梁   修改DataTypeMapping
    ///     2011.10.16 版本：3.4    张广梁   修改entity没有备注的bug
    ///     2011.10.15 版本：3.3    吉日嘎拉 将类文件进行拆分。
    ///     2011.10.02 版本：3.2    吉日嘎拉 字段的默认值都修改错了，修改过来。
    ///     2011.09.14 版本：3.1    张广梁   修改字符串类型默认值为string.Empty。
    ///     2011.09.14 版本：3.0    张广梁   增加对TEXT类型的支持。
    ///     2011.08.16 版本：2.9    张广梁   增加对decimal类型的支持。
    ///     2011.06.18 版本：2.8    吉日嘎拉 修改功能，自动生成默认值。并留有接口 edit by zgl。
    ///		2011.03.31 版本：2.7    吉日嘎拉 主键为GUID类型，字段名为ID的无法正确写入的问题解决。
    ///		2011.03.31 版本：2.6    吉日嘎拉 Business命名空间修改为Manager。
    ///		2010.11.14 版本：2.5    吉日嘎拉 名称修改为CodeGenerator。
    ///		2010.07.13 版本：2.4    吉日嘎拉 表字段名生成注释的功能。
    ///		2010.06.14 版本：2.3    吉日嘎拉 创建人主键、创建人、创建日期、修改人主键、修改人、修改日期这些字段的有与否的区别对待。
    ///		2010.06.13 版本：2.3    吉日嘎拉 UserInfo 为空的判断。
    ///		2010.04.22 版本：2.2    吉日嘎拉 ID更名为Id，开发环境的建议。
    ///		2010.01.19 版本：2.1    吉日嘎拉 主键质量检查。
    ///		2009.12.17 版本：2.0    吉日嘎拉 换行进行排版优化。
    ///		2009.12.07 版本：1.9    吉日嘎拉 是否有排序字段进行优化。
    ///		2009.12.06 版本：1.8    吉日嘎拉 描述的产生方式进行优化。
    ///		2009.12.02 版本：1.7    吉日嘎拉 命名空间生成的改进、空公司名称的改进。
    ///		2009.12.02 版本：1.7    吉日嘎拉 文件名生成的改进。
    ///		2008.11.28 版本：1.6    吉日嘎拉 public partial class 改进。
    ///		2008.10.02 版本：1.5    吉日嘎拉 添加 构造方法中指定表明的功能，tableName。
    ///		2008.11.05 版本：1.4    吉日嘎拉 添加 BuilderService 方法。
    ///		2008.08.28 版本：1.3    吉日嘎拉 修正 GetEntity 方法错误。
    ///		2008.08.27 版本：1.2    吉日嘎拉 PowerDesigner 11,12 兼容性改进。
    ///		2008.07.29 版本：1.1    吉日嘎拉 整理。
    ///		2008.07.28 版本：1.0    吉日嘎拉 整理。
    ///	
    /// 版本：3.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.15</date>
    /// </author> 
    /// </summary>
    public partial class CodeGenerator
    {
        private string company = string.Empty;
        private string project = string.Empty;
        private string author = string.Empty;
        private string yearCreated = string.Empty;
        private string dateCreated = string.Empty;

        private string className = string.Empty;
        private string postfix = string.Empty;
        private string tableName = string.Empty;
        private string description = string.Empty;

        public string primaryKey = "Id"; 
        /// <summary>
        /// 主键字段
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                // 对主键进行规范化
                if (!string.IsNullOrEmpty(primaryKey))
                {   
                    if (primaryKey.Equals("Id"))
                    {
                        primaryKey = "Id"; 
                    }
                }
                return primaryKey;
            }
            set
            {
                primaryKey = value;
            }
        }

        /// <summary>
        /// 设计文档
        /// </summary>
        private XmlDocument xmlDocument = new XmlDocument();

        private StringBuilder CodeText = new StringBuilder();

        private string ClassEntity
        {
            get
            {
                return this.className.Substring(0, 1).ToLower() + this.className.Substring(1) + "Entity";
            }
        }

        public CodeGenerator()
        {
        }

        public CodeGenerator(XmlDocument xmlDocument)
        {
            this.xmlDocument = xmlDocument;
        }

        public CodeGenerator(XmlDocument xmlDocument, string company, string project, string author, string yearCreated, string dateCreated, string className, string postfix, string tableName, string description)
            : this(xmlDocument)
        {
            this.xmlDocument = xmlDocument;

            this.company = company;
            this.project = project;
            this.author = author;
            this.yearCreated = yearCreated;
            this.dateCreated = dateCreated;

            this.className = className;
            this.postfix = postfix;
            this.tableName = tableName;
            this.description = description;
        }

        private void GetCodeCopyright()
        {
            this.CodeText = new StringBuilder();
            this.CodeText.AppendLine("//--------------------------------------------------------------------");
            string company = "Jirisoft";
            if (!String.IsNullOrEmpty(this.company))
            {
                company = this.company;
            }

            this.CodeText.AppendLine("// All Rights Reserved , Copyright (C) " + this.yearCreated + " , " + company + " TECH, Ltd.");
            this.CodeText.AppendLine("//--------------------------------------------------------------------");
            this.CodeText.AppendLine(string.Empty);
        }

        private void GetCodeUsing(bool table)
        {
            this.CodeText.AppendLine("using System;");
            this.CodeText.AppendLine("using System.Collections.Generic;");
            if (!table)
            {
                this.CodeText.AppendLine("using System.Data;");
            }
        }

        private void GetCodeUsing()
        {
            this.GetCodeUsing(false);
        }

        private void GetCodeNamespace(string space, bool table)
        {
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.Append("namespace ");
            // 公司名做命名空间的一部分
            //if (!String.IsNullOrEmpty(this.company))
            //{
            //    this.CodeText.Append(this.company + ".");
            //}
            this.CodeText.Append(this.project+".Business");
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("{");
            if (space.Equals("Manager") || space.Equals("Service"))
            {
                this.CodeText.AppendLine("    using DotNet.Business;");
                this.CodeText.AppendLine("    using DotNet.Utilities;");
                this.CodeText.AppendLine(string.Empty);
            }
            else
            {
                if (!table)
                {
                    this.CodeText.AppendLine("    using DotNet.Utilities;");
                    this.CodeText.AppendLine(string.Empty);
                }
            }
        }

        private void GetCodeNamespace(string space)
        {
            this.GetCodeNamespace(space, false);
        }

        private void GetCodeRemark()
        {
            this.CodeText.AppendLine("    /// <summary>");
            this.CodeText.AppendLine("    /// " + this.className + this.postfix);
            this.CodeText.AppendLine("    /// " + this.description);
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// 修改纪录");
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// " + this.dateCreated + " 版本：1.0 " + this.author + " 创建主键。");
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// 版本：1.0");
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// <author>");
            this.CodeText.AppendLine("    /// <name>" + this.author + "</name>");
            this.CodeText.AppendLine("    /// <date>" + this.dateCreated + "</date>");
            this.CodeText.AppendLine("    /// </author>");
            this.CodeText.AppendLine("    /// </summary>");
            if (this.postfix.Equals("Entity"))
            {
                this.CodeText.AppendLine("    [Serializable]");
            }
        }

        private void GetCodeClassName()
        {
            switch (this.postfix)
            {
                case "Table":
                    this.CodeText.AppendLine("    public partial class " + this.className + "Entity");
                    break;
                case "Entity":
                    this.CodeText.AppendLine("    public partial class " + this.className + "Entity : BaseEntity");
                    break;
                case "Manager":
                    this.CodeText.AppendLine("    public partial class " + this.className + this.postfix + " : BaseManager, IBaseManager");
                    break;
                default:
                    this.CodeText.AppendLine("    public class " + this.className + this.postfix);
                    break;
            }

            this.CodeText.AppendLine("    {");
        }
       
        public XmlNode GetXmlNode(string tableName = null)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = this.tableName;
            }
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            nsmgr.AddNamespace("a", "attribute");
            nsmgr.AddNamespace("c", "collection");
            nsmgr.AddNamespace("o", "object");

            XmlNode returnValue = null;
            // Tables
            //string selectPath = "/Model/*[local-name()='RootObject' and namespace-uri()='object'][1]/*[local-name()='Children' and namespace-uri()='collection'][1]/*[local-name()='Model' and namespace-uri()='object'][1]/*[local-name()='Tables' and namespace-uri()='collection'][1]";
            // Columns
            // string selectPath = "/Model/*[local-name()='RootObject' and namespace-uri()='object'][1]/*[local-name()='Children' and namespace-uri()='collection'][1]/*[local-name()='Model' and namespace-uri()='object'][1]/*[local-name()='Tables' and namespace-uri()='collection'][1]/*[local-name()='Table' and namespace-uri()='object'][1]/*[local-name()='Columns' and namespace-uri()='collection'][1]";

            var tableList = xmlDocument.SelectNodes("/descendant::c:Tables/o:Table", nsmgr);
            foreach (XmlNode xmlNode in tableList)
            {
                if (xmlNode.ChildNodes[2].InnerText.Equals(tableName))
                {
                    returnValue = xmlNode;
                    break;
                }
            }
            return returnValue;
        }

        private string GetPrimaryKey()
        {
            XmlNode xmlNode = this.GetXmlNode(tableName);
            return this.GetPrimaryKey(xmlNode);
        }

        /// <summary>
        /// 获取当前表的主键
        /// </summary>
        /// <param name="xmlNode">文档</param>
        /// <returns>主键</returns>
        public string GetPrimaryKey(XmlNode xmlNode)
        {
            string primaryKey = "Id";
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    // Pcsky 2012.05.02 修正检测到无法访问的代码的问题
                    primaryKey = xmlNode.ChildNodes[i].ChildNodes[0].ChildNodes[2].InnerText;
                    this.IsKeywords(ref primaryKey);

                    //for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    //{
                    //    primaryKey = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[2].InnerText;
                    //    this.IsKeywords(ref primaryKey);
                    //    break;
                    //}

                    break;
                }
            }
            this.PrimaryKey = primaryKey;
            return primaryKey;
        }

        /// <summary>
        /// 判断是否关键字
        /// </summary>
        /// <param name="field">字段</param>
        /// <returns>是关键字</returns>
        public bool IsKeywords(ref string field, bool allKeywords = false)
        {
            bool returnValue = false;
            // 首字母进行强制大写改进
            field = field.Substring(0, 1).ToUpper() + field.Substring(1);

            string[] keywords = new string[] { this.PrimaryKey, "CreateOn", "CreateUserId", "CreateBy", "ModifiedOn", "ModifiedUserId", "ModifiedBy" };
            if (allKeywords)
            {
                keywords = new string[] { this.PrimaryKey, "Code", "AuditStatus", "SortCode", "DeletionStateCode", "Enabled", "CreateOn", "CreateUserId", "CreateBy", "ModifiedOn", "ModifiedUserId", "ModifiedBy" };
            }

            for (int y = 0; y < keywords.Length; y++)
            {
                // 防止大小写问题发生
                if (keywords[y].ToUpper().Equals(field.ToUpper()))
                {
                    // 进行大小写转换
                    field = keywords[y];
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region private void GetCodeEntityManager(XmlNode xmlNode) 获取字段的写法
        /// <summary>
        /// 获取字段的写法
        /// </summary>
        /// <param name="xmlNode">文档</param>
        private void GetCodeEntityManager(XmlNode xmlNode)
        {
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        bool isFilter = false;
                        string field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[2].InnerText;
                        isFilter = IsKeywords(ref field);
                        if (!isFilter)
                        {
                            this.CodeText.AppendLine("            sqlBuilder.SetValue(" + this.className + "Entity.Field" + field + ", " + this.ClassEntity + "." + field + ");");
                        }
                    }
                    break;
                }
            }
        }
        #endregion

        #region private void GetCodeEntityColumn(XmlNode xmlNode) 获取字段的写法
        /// <summary>
        /// 获取字段的写法
        /// </summary>
        /// <param name="xmlNode">表名</param>
        private void GetCodeEntityColumn(XmlNode xmlNode)
        {
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldDescription = string.Empty;
                        string fieldDataType = string.Empty;
                        string fieldName = string.Empty;
                        string fieldDefaultValue = string.Empty;
                        for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                        {
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                            {
                                field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Comment"))
                            {
                                fieldDescription = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DataType"))
                            {
                                // 字段类型大写
                                fieldDataType = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText.ToUpper();
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Name"))
                            {
                                fieldName = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            //add by zgl 20110618
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DefaultValue"))
                            {
                                fieldDefaultValue = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                        }
                        if (String.IsNullOrEmpty(fieldDescription))
                        {
                            fieldDescription = fieldName;
                        }
                        // 关键字转换
                        this.IsKeywords(ref field);
                        // 这里是判断各个类型的，默认值等等
                        //string defaultValue = string.Empty;
                        string defaultValue = fieldDefaultValue;
                        string dataType = string.Empty;
                        dataType = GetDataType(fieldDataType, ref defaultValue);

                        /*
                        // 最闹心的是处理默认值不方便
                        this.CodeText.AppendLine("        /// <summary>");
                        this.CodeText.AppendLine("        /// " + fieldDescription);
                        this.CodeText.AppendLine("        /// </summary>");
                        this.CodeText.AppendLine("        public " + dataType + " " + field + " { get; set; }");
                        */

                        // 采用这个方式的好处是可以处理默认值
                        string privateField = field.Substring(0, 1).ToLower() + field.Substring(1);
                        this.CodeText.AppendLine("        private " + dataType + " " + privateField + " = " + defaultValue + ";");
                        this.CodeText.AppendLine("        /// <summary>");
                        this.CodeText.AppendLine("        /// " + fieldDescription);
                        this.CodeText.AppendLine("        /// </summary>");
                        this.CodeText.AppendLine("        public " + dataType + " " + field);
                        this.CodeText.AppendLine("        {");
                        this.CodeText.AppendLine("            get");
                        this.CodeText.AppendLine("            {");
                        this.CodeText.AppendLine("                return this." + privateField + ";");
                        this.CodeText.AppendLine("            }");
                        this.CodeText.AppendLine("            set");
                        this.CodeText.AppendLine("            {");
                        this.CodeText.AppendLine("                this." + privateField + " = value;");
                        this.CodeText.AppendLine("            }");
                        this.CodeText.AppendLine("        }");
                        
                        this.CodeText.AppendLine(string.Empty);
                    }
                    break;
                }
            }
        }
        #endregion

        /// <summary>
        /// 数据库类型映射关系（数据库类型、C#类型、默认值、读取函数）
        /// </summary>
        string [,]  DataTypeMapping = {
                                    {"NVARCHAR", "String", "string.Empty", "ToString"},
                                    {"VARCHAR2", "String", "string.Empty", "ToString"},
                                    {"CHAR", "String", "string.Empty", "ToString"},
                                    {"INT", "int?", "null", "ToInt"},
                                    {"INTEGER", "int?", "null", "ToInt"},
                                    {"BIGINT", "long?", "null", "ToLong"},
                                    {"TINYINT", "int?", "null", "ToInt"},
                                    {"BIT", "Boolean?", "null", "ToBoolean"},                                      
                                    {"NUMBER", "Decimal?", "0", "ToDecimal"},
                                    {"DECIMAL", "Decimal?", "0", "ToDecimal"},
                                    {"NUMERIC", "Decimal?", "0", "ToDecimal"},
                                    {"FLOAT", "float?", "0", "ToFloat"},
                                    {"DATE", "DateTime?", "null", "ToDateTime"},
                                    {"DATETIME", "DateTime?", "null", "ToDateTime"},
                                    {"SMALLDATETIME", "DateTime?", "null", "ToDateTime"},
                                    {"BLOB", "Byte[]", "null", "ToByte"},
                                    {"BFILE", "Byte[]", "null", "ToByte"},
                                    {"IMAGE", "Byte[]", "null", "ToByte"},
                                    {"TEXT", "String?", "string.Empty", "ToString"}
            
                    };

        /// <summary>
        /// 获取字段的类型
        /// </summary>
        /// <param name="fieldDataType">数据库字段类型</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>数据类型</returns>
        private string GetDataType(string fieldDataType, ref string defaultValue)
        {
            // 这是默认值
            string returnValue = typeof(string).Name.ToString();
            // 这个是查找对比对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (fieldDataType.IndexOf(DataTypeMapping[i, 0]) >= 0)
                {
                    returnValue = DataTypeMapping[i, 1];
                    // 如果defaultValue 为空的话 读取默认的 默认值 add by zgl 20110618
                    if (string.IsNullOrEmpty(defaultValue))
                    {
                        defaultValue = DataTypeMapping[i, 2];
                    }
                    else
                    {
                        //定义dataTypeStr，并格式化
                        string dataType = string.Empty;
                        if (fieldDataType.IndexOf('(') > 0)
                        {
                            dataType = fieldDataType.Substring(0, fieldDataType.IndexOf('(')).ToUpper();
                        }
                        else
                        {
                            dataType = fieldDataType.ToUpper();
                        }                        
                        switch (dataType)
                        {
                            // 如果是字符类型，加""
                            case "NVARCHAR2":
                            case "NVARCHAR":
                            case "VARCHAR2":
                            case "VARCHAR":
                            case "CHAR":
                            case "TEXT":
                            case "NTEXT":
                                defaultValue = "\"" + defaultValue + "\"";
                                break;
                            case "DATE":
                            case "DATETIME":
                            case "SMALLDATETIME":
                                if (!string.IsNullOrEmpty(defaultValue))
                                {
                                    if (defaultValue.ToString().ToUpper().Equals("GETDATE()")
                                        || defaultValue.ToString().ToUpper().Equals("SYSDATE"))
                                    defaultValue = "DateTime.Now";
                                }
                                break;
                            case "BIT":
                                if (!string.IsNullOrEmpty(defaultValue))
                                {
                                    if (defaultValue.ToString().Equals("1"))
                                    {
                                        defaultValue = "true";
                                    }
                                    if (defaultValue.ToString().Equals("0"))
                                    {
                                        defaultValue = "false";
                                    }
                                }
                                break;
                            // 如果是数值类型，直接用defaultValue
                            case "INT":
                            case "INTEGER":
                            case "BIGINT":
                                break;
                        }
                    }
                    // 不循环了，提高效率
                    break;
                }                
            }
            //如果 找不到 匹配的，则返回string 类型默认值为 null
            if (string.IsNullOrEmpty(defaultValue))
            {
                defaultValue = "string.Empty";
            }
            return returnValue;
        }

        private string GetDataType(string fieldDataType)
        {
            // 这是默认值
            string returnValue = typeof(string).Name.ToString();
            // 这个是差找对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (fieldDataType.IndexOf(DataTypeMapping[i, 0]) >= 0)
                {
                    returnValue = DataTypeMapping[i, 1];
                    // 不循环了，提高效率
                    break;
                }
            }
            return returnValue;
        }

        public string GetColumnDataType(XmlNode xmlNode, string columnName, bool dbDataType = false)
        {
            string fieldDataType = string.Empty;
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[2].InnerText.ToUpper();
                        if (field.Equals(columnName.ToUpper()))
                        {
                            for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                            {
                                if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DataType"))
                                {
                                    // 字段类型大写
                                    fieldDataType = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText.ToUpper();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            fieldDataType = GetDataType(fieldDataType);
            if (dbDataType)
            {
                fieldDataType = fieldDataType.TrimEnd('?');
                fieldDataType = fieldDataType.TrimEnd(']');
                fieldDataType = fieldDataType.TrimEnd('[');
            }
            return fieldDataType;
        }

        private string GetToStringFunction(string dataType)
        {
            // 这是默认值
            string returnValue = string.Empty;
            switch (dataType.ToUpper())
            {
                case "INT":
                case "TINYINT":
                case "INTEGER":
                case "BIGINT":
                case "DECIMAL":
                case "NUMERIC":
                    returnValue = ".ToString()";
                    break;
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    returnValue = "ToString(BaseSystemInfo.DateFormat)";
                    break;
                case "NVARCHAR2":
                case "NVARCHAR":
                case "VARCHAR2":
                case "VARCHAR":
                case "CHAR":
                case "TEXT":
                case "NTEXT":
                case "BIT":
                    break;
            }
            return returnValue;
        }

        private string GetConvertFunction(string fieldDataType)
        {
            int indexOf = fieldDataType.IndexOf('(');
            if (indexOf > 0)
            {
                fieldDataType = fieldDataType.Substring(0, indexOf);
            }
            // 这是默认值
            string returnValue = "ToString";
            // 这个是差找对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (fieldDataType.IndexOf(DataTypeMapping[i, 0]) >= 0)
                {
                    returnValue = DataTypeMapping[i, 3];
                    // 不循环了，提高效率
                    break;
                }
            }
            return returnValue;
        }
        
        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="xmlNode">xml文件</param>
        /// <param name="columnName">列名</param>
        /// <returns>存在</returns>
        private bool ColumnsExists(XmlNode xmlNode, string columnName)
        {
            bool retuanValue = false;
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[2].InnerText.ToUpper();
                        if (field.Equals(columnName.ToUpper()))
                        {
                            retuanValue = true;
                            break;
                        }
                    }
                    break;
                }
            }
            return retuanValue;
        }

        private void GetCodeEnd()
        {
            this.CodeText.AppendLine("    }");
            this.CodeText.Append("}");
        }

        #region public static void WriteCode(string fileName, bool overwrite, string code) 写入主键
        /// <summary>
        /// 写入主键
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="overwrite">覆盖</param>
        /// <param name="code">主键</param>
        /// <returns>成功</returns>
        public static bool WriteCode(string fileName, bool overwrite, string code)
        {
            bool returnValue = overwrite;
            if (File.Exists(fileName))
            {
                if (!overwrite)
                {
                    return returnValue;
                }
            }
            else
            {
                string path = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fileStream.Close();
            }
            StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);
            streamWriter.WriteLine(code);
            streamWriter.Close();
            return returnValue;
        }
        #endregion
    }
}