//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Xml;
using System.Text;

namespace DotNet.WinForm
{
    /// <summary>
    ///	CodeGenerator
    /// 主键生成器
    /// 
    /// 修改纪录
    /// 
    ///		2012.04.07 版本：1.0    吉日嘎拉 整理。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.07</date>
    /// </author> 
    /// </summary>
    public partial class CodeGenerator
    {
        public string GetSearch()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.Append(System.Environment.NewLine);

            XmlNode xmlNode = this.GetXmlNode();

            bool isKeyword = false;
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldName = string.Empty;
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
                                isKeyword = this.IsKeywords(ref field);
                                if (isKeyword)
                                {
                                    continue;
                                }
                            }
                        }
                        if (this.IsKeywords(ref field, true))
                        {
                            continue;
                        }
                        if (field.EndsWith("Id"))
                        {
                            continue;
                        }
                        string dataType = this.GetColumnDataType(xmlNode, field, true).ToUpper();
                        if (dataType.Equals("STRING")
                            ||dataType.Equals("NVARCHAR")
                            || dataType.Equals("VARCHAR2")
                            || dataType.Equals("CHAR"))
                        {
                            returnValue.AppendLine("                whereConditional += \" OR \" + #ClassName#Entity.Field" + field + " + \" LIKE \" + searchValue;");
                        }
                    }
                    break;
                }
            }
            return returnValue.ToString();
        }   
    }
}