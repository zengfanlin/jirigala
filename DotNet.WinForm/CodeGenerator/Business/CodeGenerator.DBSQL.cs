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
        public string DBSQL()
        {
            // this.GetCodeCopyright();
            XmlNode xmlNode = this.GetXmlNode(tableName);
            // 获取主键
            // this.GetPrimaryKey(xmlNode);
            this.DBSQL(xmlNode);
            return this.CodeText.ToString();
        }

        public void DBSQL(XmlNode xmlNode)
        {
            bool isKeyword = false;

            this.CodeText.AppendLine(" -- 审批流程表");
            this.CodeText.AppendLine(" USE [WorkFlowV37]");
            // this.CodeText.AppendLine(" DELETE FROM WorkFlowBillTemplate WHERE (Code = \'" + this.tableName + "\');");
            // this.CodeText.AppendLine(" DELETE FROM BaseWorkFlowProcess WHERE (Code = \'" + this.tableName + "\');");

            this.CodeText.AppendLine(" IF NOT EXISTS(SELECT Code FROM BaseWorkFlowBillTemplate WHERE Code = \'" + this.tableName + "\')");
            this.CodeText.AppendLine(" BEGIN ");
            this.CodeText.AppendLine(" INSERT INTO BaseWorkFlowBillTemplate(Code, Title, TemplateType, AddPage, EditPage, ShowPage, ListPage, AdminPage) VALUES (" + "\'"
                + this.tableName + "\', \'" + this.description + "\', 'InternalBill' , '../../WorkFlow/" + this.tableName + "/"
                + this.tableName + "Edit.aspx', '../../WorkFlow/" + this.tableName + "/"
                + this.tableName + "Edit.aspx?Id={Id}', '../../WorkFlow/" + this.tableName + "/"
                + this.tableName + "Show.aspx?Id={Id}', '../../WorkFlow/" + this.tableName + "/"
                + this.tableName + "List.aspx', '../../WorkFlow/" + this.tableName + "/" 
                + this.tableName + "Admin.aspx');");
            this.CodeText.AppendLine(" END ");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" USE [UserCenterV37]");
            this.CodeText.AppendLine(" -- 菜单表插入数据库");

            // this.CodeText.AppendLine(" DELETE FROM BaseModule WHERE (Code = '" + this.tableName + "List');");

            this.CodeText.AppendLine(" IF NOT EXISTS(SELECT Code FROM BaseModule WHERE Code = \'" + this.tableName + "List\')");
            this.CodeText.AppendLine(" BEGIN ");
            this.CodeText.AppendLine(" INSERT INTO BaseModule(ParentId, Code, FullName, Target, NavigateUrl, IsPublic) VALUES ((SELECT Id FROM  BaseModule WHERE Code = 'UserBill'),'" + this.tableName + "List','" + this.description + "','fraContent','Modules/WorkFlow/" + this.tableName + "/" + this.tableName + "List.aspx',1);");
            this.CodeText.AppendLine(" END ");
            //this.CodeText.AppendLine(" DELETE FROM BaseModule WHERE (Code = '" + this.tableName + "Search');");

            this.CodeText.AppendLine(" IF NOT EXISTS(SELECT Code FROM BaseModule WHERE Code = \'" + this.tableName + "Search\')");
            this.CodeText.AppendLine(" BEGIN ");
            this.CodeText.AppendLine(" INSERT INTO BaseModule(ParentId, Code, FullName, Target, NavigateUrl, IsPublic) VALUES ((SELECT Id FROM  BaseModule WHERE Code = 'BillSearch'),'" + this.tableName + "Search','" + this.description + "','fraContent','Modules/WorkFlow/" + this.tableName + "/" + this.tableName + "Search.aspx',1);");
            this.CodeText.AppendLine(" END ");
            //this.CodeText.AppendLine(" DELETE FROM BaseModule WHERE (Code = '" + this.tableName + "Admin');");

            this.CodeText.AppendLine(" IF NOT EXISTS(SELECT Code FROM BaseModule WHERE Code = \'" + this.tableName + "Admin\')");
            this.CodeText.AppendLine(" BEGIN ");
            this.CodeText.AppendLine(" INSERT INTO BaseModule(ParentId, Code, FullName, Target, NavigateUrl, IsPublic) VALUES ((SELECT Id FROM  BaseModule WHERE Code = 'BillAdmin'),'" + this.tableName + "Admin','" + this.description + "','fraContent','Modules/WorkFlow/" + this.tableName + "/" + this.tableName + "Admin.aspx',0);");
            this.CodeText.AppendLine(" END ");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 数据权限主表里插入表");
            this.CodeText.AppendLine(" DELETE FROM ItemsTablePermissionScope WHERE (ItemCode = \'" + this.tableName + "\');");
            this.CodeText.AppendLine(" INSERT INTO ItemsTablePermissionScope(ItemCode, ItemName, ItemValue) VALUES (" + "\'" + this.tableName + "\', \'" + this.description + "\', \'" + this.tableName + "\');");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 先删除重复的数据");
            this.CodeText.AppendLine(" DELETE FROM BaseTableColumns WHERE (TableCode = '" + this.tableName + "'); ");
            this.CodeText.AppendLine("");
            this.CodeText.AppendLine(" -- 插入字段说明数据");
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

                        string dataType = GetColumnDataType(xmlNode, field, true);

                        string commandText = " INSERT INTO BaseTableColumns (TableCode, ColumnCode, ColumnName, UseConstraint, DataType, Enabled , SortCode) VALUES (" + "\'" + this.tableName + "\', \'" + field + "\', \'" + fieldDescription + "\', ";
                        commandText += isKeyword ? "0" : "1";
                        commandText += ", \'" + dataType + "\', ";
                        commandText += isKeyword ? "0" : "1";
                        commandText += ", " + j.ToString() + ");";

                        this.CodeText.AppendLine(commandText);
                    }
                    break;
                }
            }
            this.CodeText.AppendLine("");
        }
    }
}