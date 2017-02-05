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
        public bool BuilderTable(string outputDirectory, bool overwrite, bool twoTier = true)
        {
            this.postfix = "Table";
            string fileName = outputDirectory + "\\" + this.project + ".Business\\" +
                                                (!twoTier ? this.project + ".Model" : this.className) + "\\" + this.className + "Table.cs";
            string code = this.BuilderTable();
            return WriteCode(fileName, overwrite, code);
        }

        public string BuilderTable()
        {
            this.GetCodeCopyright();
            this.GetCodeUsing(true);
            this.GetCodeNamespace("Model", true);
            this.GetCodeRemark();
            this.GetCodeClassName();
            this.GetCodeTableColumn(this.tableName);
            this.GetCodeEnd();
            return this.CodeText.ToString();
        }

        private void GetCodeTableColumn(string tableName)
        {
            this.CodeText.AppendLine("        ///<summary>");
            this.CodeText.AppendLine("        /// " + this.description);
            this.CodeText.AppendLine("        ///</summary>");
            this.CodeText.AppendLine("        [NonSerialized]");
            this.CodeText.AppendLine("        public static string TableName = \"" + tableName + "\";");

            XmlNode xmlNode = this.GetXmlNode(tableName);
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldName = string.Empty;
                        string fieldDescription = string.Empty;
                        for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                        {
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Name"))
                            {
                                fieldName = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                            {
                                field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                                // 关键字转换
                                this.IsKeywords(ref field);
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Comment"))
                            {
                                fieldDescription = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                        }
                        if (String.IsNullOrEmpty(fieldDescription))
                        {
                            fieldDescription = fieldName;
                        }
                        // 首字母进行强制大写改进
                        string fieldKey = field.Substring(0, 1).ToUpper() + field.Substring(1);
                        this.CodeText.AppendLine(string.Empty);
                        this.CodeText.AppendLine("        ///<summary>");
                        this.CodeText.AppendLine("        /// " + fieldDescription);
                        this.CodeText.AppendLine("        ///</summary>");
                        this.CodeText.AppendLine("        [NonSerialized]");
                        this.CodeText.AppendLine("        public static string Field" + fieldKey + " = \"" + field + "\";");
                    }
                    break;
                }
            }
        }
    }
}