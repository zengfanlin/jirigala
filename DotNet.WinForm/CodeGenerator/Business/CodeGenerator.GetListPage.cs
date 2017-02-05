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
        public string GetListPage()
        {
            StringBuilder returnValue = new StringBuilder();

            string boundFieldData = System.Environment.NewLine;
            boundFieldData += "                            <asp:BoundField DataField=\"#DataField#\" HeaderText=\"#HeaderText#\" HtmlEncode=\"False\" DataFormatString=\"{0:yyyy-MM-dd}\" SortExpression=\"#DataField#\">" + System.Environment.NewLine
                            + "                                <HeaderStyle Width=\"80px\" HorizontalAlign=\"Center\" Font-Bold=\"False\" /> " + System.Environment.NewLine
                            + "                                <ItemStyle HorizontalAlign=\"Center\" Wrap=\"False\" />" + System.Environment.NewLine
                            + "                            </asp:BoundField>";

            string boundField = System.Environment.NewLine;
            boundField += "                            <asp:BoundField DataField=\"#DataField#\" HeaderText=\"#HeaderText#\" HtmlEncode=\"False\" SortExpression=\"#DataField#\"> " + System.Environment.NewLine
                        + "                                <HeaderStyle HorizontalAlign=\"Center\" Font-Bold=\"False\" /> " + System.Environment.NewLine
                        + "                                <ItemStyle Wrap=\"False\" CssClass=\"leftBlank rightBlank\" /> " + System.Environment.NewLine
                        + "                            </asp:BoundField>";

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
                                isKeyword = this.IsKeywords(ref field);
                                if (isKeyword)
                                {
                                    continue;
                                }
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
                        if (this.IsKeywords(ref field, true))
                        {
                            continue;
                        }
                        if (field.EndsWith("Id"))
                        {
                            continue;
                        }
                        string dataType = this.GetColumnDataType(xmlNode, field, true).ToUpper();
                        if (dataType.Equals("DATE") || dataType.Equals("DATETIME") || dataType.Equals("SMALLDATETIME"))
                        {
                            returnValue.AppendLine(boundFieldData.Replace("#DataField#", field).Replace("#HeaderText#", fieldDescription));
                        }
                        else
                        {
                            returnValue.AppendLine(boundField.Replace("#DataField#", field).Replace("#HeaderText#", fieldDescription));
                        }
                    }
                    break;
                }
            }
            return returnValue.ToString();
        }   
    }
}