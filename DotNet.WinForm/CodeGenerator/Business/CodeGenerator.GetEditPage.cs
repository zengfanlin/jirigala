//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Xml;

using DotNet.Utilities;
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
        private string GetEditEntityValue(string field, string dataType)
        {
            string returnValue = string.Empty;
            if (field.StartsWith("Attachment"))
            {
                return returnValue;
            }
            else if (field.StartsWith("Items"))
            {
                returnValue = System.Environment.NewLine + "		entity." + field + " = this.cmb" + field + ".SelectedValue;";
            }
            else
            {
                string convertFunction = GetToStringFunction(dataType);
                switch (dataType.ToUpper())
                {
                    case "DATE":
                    case "DATETIME":
                    case "SMALLDATETIME":
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (string.IsNullOrEmpty(this.txt" + field + ".Text)) " + System.Environment.NewLine
                                    + "        {" + System.Environment.NewLine
                                    + "            entity." + field + " = null; " + System.Environment.NewLine
                                    + "        } " + System.Environment.NewLine
                                    + "        else " + System.Environment.NewLine
                                    + "        { " + System.Environment.NewLine
                                    + "            entity." + field + " = DateTime.Parse(this.txt" + field + ".Text); " + System.Environment.NewLine
                                    + "        }" + System.Environment.NewLine;
                        break;
                    case "INT":
                    case "TINYINT":
                    case "INTEGER":
                    case "BIGINT":
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (!string.IsNullOrEmpty(this.txt" + field + ".Text)) " + System.Environment.NewLine
                                     + "        { " + System.Environment.NewLine
                                     + "            entity." + field + " = int.Parse(this.txt" + field + ".Text); " + System.Environment.NewLine
                                     + "        }" + System.Environment.NewLine;
                        break;
                    case "BIT":
                        returnValue += System.Environment.NewLine;
                        returnValue += "        entity." + field + " = this.cb" + field + ".Checked;" +
                                       System.Environment.NewLine;
                        break;
                    case "NUMBER":
                    case "NUMERIC":
                    case "DECIMAL":
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (!string.IsNullOrEmpty(this.txt" + field + ".Text)) " + System.Environment.NewLine
                                     + "        { " + System.Environment.NewLine
                                     + "            entity." + field + " = Decimal.Parse(this.txt" + field + ".Text); " + System.Environment.NewLine
                                     + "        }" + System.Environment.NewLine;
                        break;
                    case "FLOAT":
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (!string.IsNullOrEmpty(this.txt" + field + ".Text)) " + System.Environment.NewLine
                                     + "        { " + System.Environment.NewLine
                                     + "            entity." + field + " = float.Parse(this.txt" + field + ".Text); " + System.Environment.NewLine
                                     + "        }" + System.Environment.NewLine;
                        break;
                    case "DOUBLE":
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (!string.IsNullOrEmpty(this.txt" + field + ".Text)) " + System.Environment.NewLine
                                     + "        { " + System.Environment.NewLine
                                     + "            entity." + field + " = double.Parse(this.txt" + field + ".Text); " + System.Environment.NewLine
                                     + "        }" + System.Environment.NewLine;
                        break;
                    default:
                        returnValue += System.Environment.NewLine;
                        returnValue += "        entity." + field + " = this.txt" + field + ".Text;";
                        break;
                }
            }
            return returnValue;
        }

        private string GetEditShowEntity(string field, string dataType)
        {
            string returnValue = string.Empty;
            if (field.StartsWith("Attachment"))
            {
                return returnValue;
            }
            if (field.StartsWith("Items"))
            {
                return returnValue;
            }
            string convertFunction = GetToStringFunction(dataType);
            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    returnValue += System.Environment.NewLine;
                    returnValue += "                if (entity." + field + " != null)" + System.Environment.NewLine
                                 + "                {" + System.Environment.NewLine
                                 + "                    this.txt" + field + ".Text = ((DateTime)entity." + field + ").ToString(BaseSystemInfo.DateFormat).Replace(\"\\r\\n\", \"<br>\"); " + System.Environment.NewLine
                                 + "                }" + System.Environment.NewLine;
                    break;
                case "BIT":
                    returnValue += System.Environment.NewLine;
                    returnValue += "                if (entity." + field + " != null)" + System.Environment.NewLine
                                 + "                {" + System.Environment.NewLine
                                 + "                    this.cb" + field + ".Checked = entity." + field + ".Value;" + System.Environment.NewLine
                                 + "                }" + System.Environment.NewLine;
                    break;
                default:
                    returnValue = System.Environment.NewLine + "	    	    this.txt" + field + ".Text = " + "entity." + field + convertFunction + ";";
                    break;
            }
            return returnValue;
        }

        /// <summary>
        /// 生成js检查代码
        /// </summary>
        /// <param name="field"></param>
        /// <param name="filedName"></param>
        /// <param name="dataType"></param>
        /// <param name="mandatory"></param>
        /// <returns></returns>
        private string GetValidateCode(string field, string filedName, string dataType, string mandatory)
        {
            string returnValue = string.Empty;
            // 不检查附件
            if (field.StartsWith("Attachment"))
            {
                return returnValue;
            }
            // 不检查下拉框
            if (field.StartsWith("Items"))
            {
                return returnValue;
            }

            // 为不允许为空的字段增加验证
            if (mandatory == "1")
            {
                // 检查一般字段
                returnValue += System.Environment.NewLine;
                returnValue += "            if(IsEmpty(document.getElementById(\"txt" + field + "\").value))" + System.Environment.NewLine;
                returnValue += "            {" + System.Environment.NewLine;
                returnValue += "                alert(\"" + filedName + ",不能为空。\");" + System.Environment.NewLine;
                returnValue += "                document.getElementById(\"txt" + field + "\").focus();" + System.Environment.NewLine;
                returnValue += "                return false;" + System.Environment.NewLine;
                returnValue += "            }" + System.Environment.NewLine;
            }
            // 根据数值类型增加验
            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    // 日期类型暂不处理
                    break;
                case "INT":
                case "TINYINT":
                case "INTEGER":
                case "BIGINT":
                    returnValue += System.Environment.NewLine;
                    returnValue += "            if(!IsNumber(document.getElementById(\"txt" + field + "\").value))" + System.Environment.NewLine;
                    returnValue += "            {" + System.Environment.NewLine;
                    returnValue += "                alert(\"" + filedName + ",格式不正确，应为整数。\");" + System.Environment.NewLine;
                    returnValue += "                document.getElementById(\"txt" + field + "\").focus();" + System.Environment.NewLine;
                    returnValue += "                return false;" + System.Environment.NewLine;
                    returnValue += "            }" + System.Environment.NewLine;
                    break;
                case "NUMBER":
                case "NUMERIC":
                case "FLOAT":
                    returnValue += System.Environment.NewLine;
                    returnValue += "            if(!IsFloat(document.getElementById(\"txt" + field + "\").value))" + System.Environment.NewLine;
                    returnValue += "            {" + System.Environment.NewLine;
                    returnValue += "                alert(\"" + filedName + ",格式不正确，应为数字。\");" + System.Environment.NewLine;
                    returnValue += "                document.getElementById(\"txt" + field + "\").focus();" + System.Environment.NewLine;
                    returnValue += "                return false;" + System.Environment.NewLine;
                    returnValue += "            }" + System.Environment.NewLine;
                    break;
                default:
                    // 默认不做处理
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// 生成服务器端的检查代码
        /// </summary>
        /// <param name="field"></param>
        /// <param name="filedName"></param>
        /// <param name="dataType"></param>
        /// <param name="mandatory"></param>
        /// <returns></returns>
        private string GetCheckCode(string field, string filedName, string dataType, string mandatory)
        {
            string returnValue = string.Empty;
            if (field.StartsWith("Attachment"))
            {
                return returnValue;
            }
            // 为不允许为空的字段增加验证
            if (mandatory == "1")
            {
                if (field.StartsWith("Items"))
                {
                    return returnValue; // 暂不处理
                    // 检查下拉框
                    //returnValue += System.Environment.NewLine;
                    //returnValue += "        if(string.IsNullOrEmpty(this.cmb" + field + ".SelectedValue))" + System.Environment.NewLine;
                    //returnValue += "        {" + System.Environment.NewLine;
                    //returnValue += "            MessageBox.ShowAlert(\"" + filedName + ",不能为空。\");" + System.Environment.NewLine;
                    //returnValue += "            this.cmd" + field + ".Focus();" + System.Environment.NewLine;
                    //returnValue += "            return false;" + System.Environment.NewLine;
                    //returnValue += "        }" + System.Environment.NewLine;
                }
                else
                {
                    // 检查一般字段
                    returnValue += System.Environment.NewLine;
                    returnValue += "        if(string.IsNullOrEmpty(this.txt" + field + ".Text.Trim()))" + System.Environment.NewLine;
                    returnValue += "        {" + System.Environment.NewLine;
                    returnValue += "            MessageBox.ShowAlert(\"" + filedName + ",不能为空。\");" + System.Environment.NewLine;
                    returnValue += "            this.txt" + field + ".Focus();" + System.Environment.NewLine;
                    returnValue += "            return false;" + System.Environment.NewLine;
                    returnValue += "        }" + System.Environment.NewLine;
                }

            }
            // 根据数值类型增加验证

            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    // 日期类型暂不处理
                    break;
                case "INT":
                case "TINYINT":
                case "INTEGER":
                case "BIGINT":
                    if (!field.StartsWith("Items"))
                    {
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (!integerRegex.IsMatch(this.txt" + field + ".Text))" + System.Environment.NewLine;
                        returnValue += "        {" + System.Environment.NewLine;
                        returnValue += "            MessageBox.ShowAlert(\"" + filedName + ",格式不正确。\");" + System.Environment.NewLine;
                        returnValue += "            this.txt" + field + ".Focus();" + System.Environment.NewLine;
                        returnValue += "            return false;" + System.Environment.NewLine;
                        returnValue += "        }" + System.Environment.NewLine;
                    }
                    break;
                case "NUMBER":
                case "NUMERIC":
                case "FLOAT":
                    if (!field.StartsWith("Items"))
                    {
                        returnValue += System.Environment.NewLine;
                        returnValue += "        if (!floatRegex.IsMatch(this.txt" + field + ".Text))" + System.Environment.NewLine;
                        returnValue += "        {" + System.Environment.NewLine;
                        returnValue += "            MessageBox.ShowAlert(\"" + filedName + ",格式不正确。\");" + System.Environment.NewLine;
                        returnValue += "            this.txt" + field + ".Focus();" + System.Environment.NewLine;
                        returnValue += "            return false;" + System.Environment.NewLine;
                        returnValue += "        }" + System.Environment.NewLine;
                    }
                    break;
                default:
                    // 默认不做处理
                    break;
            }
            return returnValue;
        }

        /// <summary>
        ///  生成默认值，只处理日期类型
        /// </summary>
        /// <param name="field"></param>
        /// <param name="dataType"></param>
        /// <param name="defalutValue"></param>
        /// <returns></returns>
        private string GetShowDefaultValue(string field, string dataType, string defalutValue)
        {
            string returnValue = string.Empty;
            if (field.StartsWith("Attachment"))
            {
                return returnValue;
            }
            if (field.StartsWith("Items"))
            {
                return returnValue;
            }
            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    if (defalutValue.ToLower() == "getdate()")
                    {
                        returnValue += System.Environment.NewLine;
                        returnValue += "            this.txt" + field + ".Text= DateTime.Now.ToString(BaseSystemInfo.DateFormat);";
                        returnValue += System.Environment.NewLine;
                    }
                    break;
                case "BIT":
                    if (defalutValue.ToLower() == "1")
                    {
                        returnValue += System.Environment.NewLine;
                        returnValue += "            this.cb" + field + ".Checked=true;";
                        returnValue += System.Environment.NewLine;
                    }
                    break;
                default:
                    // 默认不做处理
                    break;
            }
            return returnValue;
        }

        public string GetEditCode(out string getEntity, out string showEntity, out string itemDetails, out string getAttachment, out string saveFiles, out string checkInput, out string showDefaultValue)
        {
            getEntity = string.Empty;
            showEntity = string.Empty;
            itemDetails = string.Empty;
            getAttachment = string.Empty;
            saveFiles = string.Empty;
            checkInput = string.Empty;
            showDefaultValue = string.Empty;
            // 这里循环字段
            XmlNode xmlNode = this.GetXmlNode(tableName);
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldName = string.Empty;
                        string fieldDataType = string.Empty;
                        string mandatory = string.Empty;
                        string defaultVale = string.Empty;
                        for (int z = 0; z < xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; z++)
                        {
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Code"))
                            {
                                field = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Name"))
                            {
                                // 字段名称
                                fieldName = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
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
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Mandatory"))
                            {
                                // 是否为空
                                mandatory = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DefaultValue"))
                            {
                                // 是否为空
                                defaultVale = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
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
                            if (field.Equals("Code") || field.Equals("UserName") || field.Equals("CompanyName") || field.Equals("DepartmentName") || field.Equals("WorkgroupName") || field.Equals("OrganizeName"))
                            {
                                continue;
                            }
                            if (field.StartsWith("Items"))
                            {
                                // 上面的写法.NET早期的版本里会有错误
                                showEntity += System.Environment.NewLine + "                Utilities.SetDropDownListValue(this.cmb" + field + ", entity." + field + ");";
                                // 下拉框的内容获取
                                itemDetails += System.Environment.NewLine
                                            + "                Utilities.GetItemDetails(this.UserInfo, this.cmb" + field + ", \"" + field + "\");";
                            }
                            else if (field.StartsWith("Attachment"))
                            {
                                getAttachment += "                this." + field + ".GetAttachmentList(\"" + field + "\", this.EntityId);" + System.Environment.NewLine;
                                saveFiles += "                this." + field + ".SaveFiles(\"" + field + "\", this.EntityId);" + System.Environment.NewLine;
                            }
                            showEntity += GetEditShowEntity(field, fieldDataType);
                            getEntity += GetEditEntityValue(fieldKey, fieldDataType);
                            checkInput += GetCheckCode(fieldKey, fieldName, fieldDataType, mandatory);
                            showDefaultValue += GetShowDefaultValue(fieldKey, fieldDataType, defaultVale);
                        }
                    }
                    break;
                }
            }
            return showEntity;
        }

        /// <summary>
        /// 显示界面字段
        /// </summary>
        /// <param name="field">显示字段</param>
        /// <param name="fieldName">显示标题</param>
        /// <param name="fieldValue">显示值</param>
        /// <returns>显示内容</returns>
        private string GetEditTextField(string field, string fieldName, string fieldValue = null, string maxLength = null, string dataType = null, string mandatory = null, int rows = 0)
        {
            string returnValue = string.Empty;
            int txtMaxLength = 0;
            if (!string.IsNullOrEmpty(maxLength))
            {
                txtMaxLength = int.Parse(maxLength);
            }
            string textMode = string.Empty;
            if (rows == 0)
            {
                if (txtMaxLength >= 300)
                {
                    rows = 3;
                }
                if (txtMaxLength > 600)
                {
                    rows = 5;
                }
            }
            if (rows > 0)
            {
                textMode = "TextMode=\"MultiLine\" Rows=\"" + rows + "\" ";
            }
            if (txtMaxLength > 0)
            {
                textMode += "MaxLength=\"" + maxLength.ToString() + "\"";
            }
            if (mandatory == "1")
                mandatory = "<font color='red'>*</font>";
            returnValue = "                    <tr>" + System.Environment.NewLine
                        + "                        <td id='{field}' height='25' align='right' nowrap='nowrap' class='td-title'>" + System.Environment.NewLine
                        + "                            " + fieldName + "：" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                        <td class='td-content' nowrap='false' style='padding-top: 3'> " + System.Environment.NewLine
                        + "                            <asp:TextBox ID=\"txt" + field + "\" runat=\"server\" " + textMode + " EnableTheming=\"True\"" + " CssClass=\"ColorBlur\" onBlur=\"this.className='ColorBlur';\" onfocus=\"this.className='ColorFocus';\" {onkeypress} Width=\"95%\" Text=\"{fieldValue}\"></asp:TextBox>{mandatory}" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                    </tr>" + System.Environment.NewLine;
            returnValue =
                returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{fieldValue}",
                                        fieldValue).Replace("{mandatory}", mandatory);
            switch (dataType.ToUpper())
            {
                case "INT":
                case "INTEGER":
                case "BIGINT":
                case "BIT":
                    returnValue = returnValue.Replace("{onkeypress}", "onkeypress=\"event.returnValue=CheckInputIsInt(event.keyCode,this)\"");
                    break;
                case "NUMBER":
                case "NUMERIC":
                case "FLOAT":
                    returnValue = returnValue.Replace("{onkeypress}", "onkeypress=\"event.returnValue=CheckInputIsFloat(event.keyCode,this)\"");
                    break;
                default:
                    returnValue = returnValue.Replace("{onkeypress}", "");
                    break;
            }

            return returnValue;
        }

        private string GetEditDateField(string field, string fieldName, string fieldValue = null, string mandatory = null)
        {
            string returnValue = string.Empty;
            if (mandatory == "1")
                mandatory = "<font color='red'>*</font>";
            returnValue = "                    <tr>" + System.Environment.NewLine
                        + "                        <td id='{field}' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>" + System.Environment.NewLine
                        + "                            " + fieldName + "：" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                        <td class='td-content' nowrap='false' style='width: 200px;padding-top: 3'> " + System.Environment.NewLine
                        + "                            <asp:TextBox ID=\"txt" + field + "\" runat=\"server\" MaxLength=\"10\"  Width=\"150px\" class=\"Wdate\" onFocus=\"WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:true,readOnly:true})\"></asp:TextBox>{mandatory}" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                    </tr>" + System.Environment.NewLine;
            returnValue = returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{mandatory}", mandatory);
            return returnValue;
        }

        private string GetCheckBoxDateField(string field, string fieldName, string fieldValue = null, string mandatory = null)
        {
            string returnValue = string.Empty;
            if (mandatory == "1")
                mandatory = "<font color='red'>*</font>";
            returnValue = "                    <tr>" + System.Environment.NewLine
                        + "                        <td id='{field}' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>" + System.Environment.NewLine
                        + "                            " + fieldName + "：" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                        <td class='td-content' nowrap='false' style='width: 200px;padding-top: 3'> " + System.Environment.NewLine
                        + "                             <asp:CheckBox ID=\"cb" + field + "\" runat=\"server\" />" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                    </tr>" + System.Environment.NewLine;
            returnValue = returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{mandatory}", mandatory);
            return returnValue;
        }

        private string GetEditOrganizeField(string field, string fieldName, string fieldValue = null)
        {
            string returnValue = string.Empty;
            returnValue = returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{fieldValue}", fieldValue);
            return returnValue;
        }

        private string GetDropDownListField(string field, string fieldName, string fieldValue = null)
        {
            string returnValue = string.Empty;
            returnValue = "                    <tr>" + System.Environment.NewLine
                       + "                        <td id=\"ddl" + field + "\" height=\"25\" align=\"right\" nowrap=\"nowrap\" class=\"td-title\"> " + System.Environment.NewLine
                       + "                            " + fieldName + "：" + System.Environment.NewLine
                       + "                        </td> " + System.Environment.NewLine
                       + "                        <td class=\"td-content\" style=\"padding-top: 3\"> " + System.Environment.NewLine
                       + "                            <asp:DropDownList ID=\"cmb" + field + "\" runat=\"server\" Width=\"100%\"> " + System.Environment.NewLine
                       + "                            </asp:DropDownList> " + System.Environment.NewLine
                       + "                        </td> " + System.Environment.NewLine
                       + "                    </tr>" + System.Environment.NewLine;
            return returnValue;
        }

        private string GetAttachmentField(string field, string fieldName, string fieldValue = null)
        {
            string returnValue = string.Empty;
            returnValue = "                    <tr>" + System.Environment.NewLine
                       + "                        <td id=\"" + field + "\" height=\"25\" align=\"right\" nowrap=\"nowrap\" class=\"td-title\"> " + System.Environment.NewLine
                       + "                            " + fieldName + "：" + System.Environment.NewLine
                       + "                        </td> " + System.Environment.NewLine
                       + "                        <td class=\"td-content\" style=\"padding-top: 3\"> " + System.Environment.NewLine
                       + "                            <Attachment:Attachment id=\"" + field + "\" runat=\"server\" ShowFileUploadCount=\"2\" ShowFileUpload=\"true\"/>" + System.Environment.NewLine
                       + "                        </td> " + System.Environment.NewLine
                       + "                     </tr>" + System.Environment.NewLine;
            return returnValue;
        }

        private string GetEditUserField(string field, string fieldName, string fieldValue = null)
        {
            string returnValue = string.Empty;
            returnValue = "<tr>" + System.Environment.NewLine
                        + "                        <td id='{field}' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>" + System.Environment.NewLine
                        + "                            " + fieldName + "：" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                        <td class='td-content' style='padding-top: 3'> " + System.Environment.NewLine
                        + "                            <asp:Label ID=\"lbl" + field + "\" runat=\"server\" Text=\"" + fieldValue + "\"></asp:Label>" + System.Environment.NewLine
                        + "                            <asp:HiddenField ID=\"hdUserId\" runat=\"server\"/>" + System.Environment.NewLine
                        + "                            <asp:HiddenField ID=\"hdOrganizeId\" runat=\"server\"/>" + System.Environment.NewLine
                        + "                            &nbsp;" + System.Environment.NewLine
                        + "                            <a href=\"javascript:SelectUser('hdUserId', 'lblUserName', 'hdOrganizeId','lblOrganizeName')\">" + System.Environment.NewLine
                        + "                                <img src=\"../../../themes/default/images/useradd.png\" title=\"选择" + fieldName + "\"/>" + fieldName + System.Environment.NewLine
                        + "                            </a>" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                    </tr>" + System.Environment.NewLine
                        + "                    <tr>" + System.Environment.NewLine
                        + "                        <td height='25' align='right' nowrap='nowrap' class='td-title'>" + System.Environment.NewLine
                        + "                            部门：" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                        <td class='td-content' style='width: 200px' style='padding-top: 3'>" + System.Environment.NewLine
                        + "                            <asp:Label ID=\"lblOrganizeName\" runat=\"server\" Text=\"\"></asp:Label>" + System.Environment.NewLine
                        + "                        </td> " + System.Environment.NewLine
                        + "                    </tr>" + System.Environment.NewLine;
            returnValue = returnValue.Replace("{field}", field).Replace("{fieldName}", fieldName).Replace("{fieldValue}", fieldValue);
            return returnValue;
        }

        public string GetEditPage(out string validateCode)
        {
            string returnValue = string.Empty;
            XmlNode xmlNode = this.GetXmlNode(tableName);
            validateCode = string.Empty;
            // 这里循环字段
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                if (((XmlNode)xmlNode.ChildNodes[i]).LocalName.Equals("Columns"))
                {
                    for (int j = 0; j < xmlNode.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        string field = string.Empty;
                        string fieldName = string.Empty;
                        string fieldDataType = string.Empty;
                        string maxLength = string.Empty;
                        string defaultValue = string.Empty;
                        string mandatory = string.Empty;
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
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DataType"))
                            {
                                // 字段类型大写
                                fieldDataType = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText.ToUpper();
                                if (fieldDataType.Contains("NUMERIC"))
                                    fieldDataType = "NUMERIC";
                                if (fieldDataType.Contains("DECIMAL"))
                                    fieldDataType = "DECIMAL";
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Length"))
                            {
                                // 字段长度
                                maxLength = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("DefaultValue"))
                            {
                                // 默认值
                                defaultValue = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                            if (xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].LocalName.Equals("Mandatory"))
                            {
                                // 是否为空
                                mandatory = xmlNode.ChildNodes[i].ChildNodes[j].ChildNodes[z].InnerText;
                            }
                        }
                        // 关键字转换
                        if (this.IsKeywords(ref field, true))
                        {
                            continue;
                        }
                        // 若是要显示主键的，没必要在页面上展示了
                        // 首字母进行强制大写改进
                        string fieldKey = field.Substring(0, 1).ToUpper() + field.Substring(1);
                        if (field.Equals("Code"))
                        {
                            continue;
                        }
                        if (!field.EndsWith("Id"))
                        {
                            if (field.Equals("CompanyName") || field.Equals("DepartmentName") || field.Equals("WorkgroupName") || field.Equals("OrganizeName"))
                            {
                                continue;
                            }
                            if (field.Equals("UserName"))
                            {
                                returnValue += this.GetEditUserField(fieldKey, fieldName);
                            }
                            else if (field.StartsWith("Items"))
                            {
                                returnValue += this.GetDropDownListField(fieldKey, fieldName);
                            }
                            else if (field.StartsWith("Attachment"))
                            {
                                returnValue += this.GetAttachmentField(fieldKey, fieldName);
                            }
                            else
                            {
                                switch (fieldDataType.ToUpper())
                                {
                                    case "DATE":
                                    case "DATETIME":
                                    case "SMALLDATETIME":
                                        returnValue += this.GetEditDateField(fieldKey, fieldName, defaultValue, mandatory) + System.Environment.NewLine;
                                        break;
                                    case "BIT":
                                        returnValue += this.GetCheckBoxDateField(fieldKey, fieldName, defaultValue, mandatory) + System.Environment.NewLine;
                                        break;
                                    default:
                                        returnValue += this.GetEditTextField(fieldKey, fieldName, defaultValue, maxLength, fieldDataType, mandatory) + System.Environment.NewLine;
                                        break;
                                }
                                validateCode += this.GetValidateCode(fieldKey, fieldName, fieldDataType, mandatory);
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