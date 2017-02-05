//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Xml;

namespace DotNet.WinForm
{
    /// <summary>
    ///	CodeGenerator
    /// 主键生成器
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.13 版本：1.0    吉日嘎拉 整理。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.13</date>
    /// </author> 
    /// </summary>
    public partial class CodeGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputDirectory">输出目录</param>
        /// <param name="overwrite">覆盖</param>
        /// <param name="twoTier">分层目录</param>
        /// <returns></returns>
        public bool BuilderEntity(string outputDirectory, bool overwrite, bool twoTier=true)
        {
            this.postfix = "Entity";
            string fileName = outputDirectory + "\\" + this.project + ".Business\\" +
                                                (!twoTier ? this.project + ".Model" : this.className) + "\\" + this.className + "Entity.cs";
            string code = this.BuilderEntity();
            return WriteCode(fileName, overwrite, code);
        }

        public string BuilderEntity()
        {
            this.GetCodeCopyright();
            this.GetCodeUsing();
            this.GetCodeNamespace("Model");
            this.GetCodeRemark();
            this.GetCodeClassName();
            XmlNode xmlNode = this.GetXmlNode(tableName);
            this.GetCodeEntityColumn(xmlNode);
            this.GetCodeEntity();
            this.GetCodeEntityForDataRow(xmlNode);
            this.GetCodeEntityForDataReader(xmlNode);
            this.GetCodeEnd();
            
            return this.CodeText.ToString();
        }

        private void GetCodeEntity()
        {
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "()");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataRow\">数据行</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(DataRow dataRow)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetFrom(dataRow);");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataReader\">数据流</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(IDataReader dataReader)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetFrom(dataReader);");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 构造函数");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataTable\">数据表</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + "(DataTable dataTable)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetSingle(dataTable);");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据表读取");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataTable\">数据表</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + " GetSingle(DataTable dataTable)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            if ((dataTable == null) || (dataTable.Rows.Count == 0))");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                return null;");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            foreach (DataRow dataRow in dataTable.Rows)");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                this.GetFrom(dataRow);");
            this.CodeText.AppendLine("                break;");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            return this;");
            this.CodeText.AppendLine("        }");
            this.CodeText.AppendLine(string.Empty);

            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据表读取返回实体列表");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataTable\">数据表</param>");
            this.CodeText.AppendLine("        public List<" + this.className + this.postfix + ">  GetList(DataTable dataTable)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            List<"+this.className+this.postfix+"> entities=new List<"+this.className+this.postfix+">();");
            this.CodeText.AppendLine("            foreach(DataRow dataRow in dataTable.Rows)");
            this.CodeText.AppendLine("            {");
            this.CodeText.AppendLine("                entities.Add(GetFrom(dataRow));");
            this.CodeText.AppendLine("            }");
            this.CodeText.AppendLine("            return entities;");
            this.CodeText.AppendLine("        }");
        }

        private void GetCodeEntityForDataRow(XmlNode xmlNode)
        {
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据行读取");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataRow\">数据行</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + " GetFrom(DataRow dataRow)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetFromExpand(dataRow);");

            string tableClassName = this.className + "Entity";


            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldDataType = string.Empty;
                        string convertFunction = string.Empty;
                        for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                        {
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                            {
                                field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DataType"))
                            {
                                // 字段类型大写
                                fieldDataType = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText.ToUpper();
                            }
                        }
                        // 关键字转换
                        this.IsKeywords(ref field);
                        convertFunction = GetConvertFunction(fieldDataType);
                        this.CodeText.AppendLine("            this." + field + " = BaseBusinessLogic.Convert" + convertFunction + "(dataRow[" + tableClassName + ".Field" + field + "]);");
                    }
                    break;
                }
            }
            this.CodeText.AppendLine("            return this;");
            this.CodeText.AppendLine("        }");
        }

        private void GetCodeEntityForDataReader(XmlNode xmlNode)
        {
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("        /// <summary>");
            this.CodeText.AppendLine("        /// 从数据流读取");
            this.CodeText.AppendLine("        /// </summary>");
            this.CodeText.AppendLine("        /// <param name=\"dataReader\">数据流</param>");
            this.CodeText.AppendLine("        public " + this.className + this.postfix + " GetFrom(IDataReader dataReader)");
            this.CodeText.AppendLine("        {");
            this.CodeText.AppendLine("            this.GetFromExpand(dataReader);;");

            string tableClassName = this.className + "Entity";
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldDataType = string.Empty;
                        string convertFunction = string.Empty;
                        for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                        {
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                            {
                                field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DataType"))
                            {
                                // 字段类型大写
                                fieldDataType = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText.ToUpper();
                            }
                        }
                        // 关键字转换
                        this.IsKeywords(ref field);
                        convertFunction = GetConvertFunction(fieldDataType);
                        this.CodeText.AppendLine("            this." + field + " = BaseBusinessLogic.Convert" + convertFunction + "(dataReader[" + tableClassName + ".Field" + field + "]);");
                    }
                    break;
                }
            }
            this.CodeText.AppendLine("            return this;");
            this.CodeText.AppendLine("        }");
        }
    }
}