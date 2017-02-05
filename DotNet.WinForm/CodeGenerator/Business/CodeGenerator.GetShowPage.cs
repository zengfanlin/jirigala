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
        private string GetShowCodeField(string field, string dataType)
        {
            string returnValue = string.Empty;
            string convertFunction = GetToStringFunction(dataType);
            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    returnValue = System.Environment.NewLine + "		if (entity." + field + " != null)" + System.Environment.NewLine
                                + "		{" + System.Environment.NewLine
                                + "		    this.lbl" + field + ".Text = ((DateTime)entity." + field + ").ToString(BaseSystemInfo.DateFormat).Replace(\"\\r\\n\", \"<br>\"); " + System.Environment.NewLine
                                + "		}";

                    break;
                case "BIT":
                    returnValue += System.Environment.NewLine;
                    returnValue += "                if (entity." + field + " != null)" + System.Environment.NewLine
                                 + "                {" + System.Environment.NewLine
                                 + "                    this.lbl" + field + ".Text = entity." + field + "==true?\"是\":\"否\";" + System.Environment.NewLine
                                 + "                }" + System.Environment.NewLine;
                    break;
                default:
                    returnValue = System.Environment.NewLine + "		if (entity." + field + " != null)" + System.Environment.NewLine
                                + "		{" + System.Environment.NewLine
                                + "		    this.lbl" + field + ".Text = " + "entity." + field + convertFunction + ".Replace(\"\\r\\n\", \"<br>\");" + System.Environment.NewLine
                                + "		}";

                    break;
            }
            return returnValue;
        }

        private string GetShowCodeAttachmentField(string field, string dataType)
        {
            string returnValue = string.Empty;
            returnValue = "this." + field + ".GetAttachmentList(\"" + field + "\", this.EntityId);" + System.Environment.NewLine;
            return returnValue;
        }

        public string GetShowCode()
        {
            string returnValue = string.Empty;
            // 这里循环字段
            XmlNode xmlNode = this.GetXmlNode(tableName);
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldDataType = string.Empty;
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
                                if (fieldDataType.Contains("NUMERIC"))
                                    fieldDataType = "NUMERIC";
                                if (fieldDataType.Contains("DECIMAL"))
                                    fieldDataType = "DECIMAL";
                            }
                        }
                        // 关键字转换
                        if (this.IsKeywords(ref field, true))
                        {
                            continue;
                        }
                        // 若是要显示主键的，没必要在页面上展示了
                        if (!field.EndsWith("Id"))
                        {
                            // 首字母进行强制大写改进
                            string fieldKey = field.Substring(0, 1).ToUpper() + field.Substring(1);
                            if (field.StartsWith("Attachment"))
                            {
                                returnValue += GetShowCodeAttachmentField(fieldKey, fieldDataType);
                            }
                            else
                            {
                                returnValue += GetShowCodeField(fieldKey, fieldDataType);
                            }
                        }
                    }
                    break;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 显示界面字段
        /// </summary>
        /// <param name="field">显示字段</param>
        /// <param name="fieldName">显示标题</param>
        /// <param name="fieldValue">显示值</param>
        /// <returns>显示内容</returns>
        private string GetShowField(string field, string fieldName, string fieldValue)
        {
            string returnValue = string.Empty;
            returnValue += System.Environment.NewLine;
            returnValue += @"                        <tr>
                            <td id='{field}' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                {fieldName}：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lbl{field}' runat='server'></asp:Label>
                            </td>
                        </tr>";
            returnValue = returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{fieldValue}", fieldValue);
            return returnValue;
        }

        private string GetShowAttachmentField(string field, string fieldName, string fieldValue)
        {
            string returnValue = string.Empty;
            returnValue += System.Environment.NewLine;
            returnValue += @"                        <tr>
                            <td id='{field}' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                {fieldName}：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <Attachment:Attachment ID='{field}' runat='server' AllowDelete='false' ShowFileUploadCount='0'  ShowFileUpload='false'/>
                            </td>
                        </tr>";
            returnValue = returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{fieldValue}", fieldValue);
            return returnValue;
        }

        public string GetShowPageField()
        {
            string returnValue = string.Empty;
            XmlNode xmlNode = this.GetXmlNode(tableName);
            // 这里循环字段
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
                            }
                        }
                        // 关键字转换
                        if (this.IsKeywords(ref field, true))
                        {
                            continue;
                        }
                        // 若是要显示主键的，没必要在页面上展示了
                        if (!field.EndsWith("Id"))
                        {
                            // 首字母进行强制大写改进
                            string fieldKey = field.Substring(0, 1).ToUpper() + field.Substring(1);
                            if (field.StartsWith("Attachment"))
                            {
                                // 首字母进行强制大写改进
                                returnValue += GetShowAttachmentField(fieldKey, fieldName, fieldName) + System.Environment.NewLine;
                            }
                            else
                            {
                                returnValue += GetShowField(fieldKey, fieldName, fieldName) + System.Environment.NewLine;
                            }
                        }
                    }
                    break;
                }
            }
            return returnValue;
        }
    }
}