//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------

using System.Collections.Generic;
using System.Xml;

namespace DotNet.WinForm
{
    /// <summary>
    /// pdmReader 类
    /// </summary>
    public class PdmReader
    {
        /// <summary>
        /// 
        /// </summary>
        #region  定义属性
        public const string a = "attribute", c = "collection", o = "object";
        public const string cClasses = "c:Classes";
        public const string oClass = "o:Class";
        public const string cAttributes = "c:Attributes";
        public const string oAttribute = "o:Attribute";
        public const string cTables = "c:Tables";
        public const string oTable = "o:Table";
        public const string cColumns = "c:Columns";
        public const string oColumn = "o:Column";
        #endregion

        XmlDocument xmlDoc;
        XmlNamespaceManager xmlnsManager;// 命名空间

        public PdmReader()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            xmlDoc = new XmlDocument();
        }
        public PdmReader(string pdm_file)
        {
            PdmFile = pdm_file;

        }

        private string pdmFile;
        public string PdmFile
        {
            get { return pdmFile; }
            set
            {
                pdmFile = value;
                if (xmlDoc == null)
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(pdmFile);

                    xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                    xmlnsManager.AddNamespace("a", "attribute");
                    xmlnsManager.AddNamespace("c", "collection");
                    xmlnsManager.AddNamespace("o", "object");
                }

            }
        }

        IList<TableInfo> tables;
        public IList<TableInfo> Tables
        {
            get { return tables; }
            set { this.tables = value; }
        }

        /// <summary>
        /// 获取xml文件的内容
        /// 遍历各个table
        /// </summary>
        public void InitData()
        {
            if (Tables == null)
            {
                Tables = new List<TableInfo>();

            }
            XmlNode xnTables = xmlDoc.SelectSingleNode("//" + cTables, xmlnsManager);
            foreach (XmlNode xnTable in xnTables.ChildNodes)
            {
                Tables.Add(GetTable(xnTable));// 遍历各个table
            }

        }

        /// <summary>
        /// 获取table类型结点的内容
        /// </summary>
        /// <param name="xnTable">table结点</param>
        /// <returns></returns>
        private TableInfo GetTable(XmlNode xnTable)
        {
            TableInfo mTable = new TableInfo();
            XmlElement xe = (XmlElement)xnTable;

            mTable.Id = xe.GetAttribute("Id");

            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                /// <summary>
                /// 以下判断可能还不全面，例如还有c:PrimaryKey
                /// 需要根据实际的需要添加
                /// </summary>
                switch (xnP.Name)
                {
                    case "a:ObjectID": mTable.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name": mTable.Name = xnP.InnerText;
                        break;
                    case "a:Code": mTable.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate": mTable.CreationDate = xnP.InnerText;
                        break;
                    case "a:Creator": mTable.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate": mTable.ModificationDate = xnP.InnerText;
                        break;
                    case "a:Modifier": mTable.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment": mTable.Comment = xnP.InnerText;
                        break;
                    case "c:Columns": ReadColumns(xnP, mTable);
                        break;
                    case "c:Keys": ReadKeys(xnP, mTable);
                        break;
                }
            }
            return mTable;

        }

        
        #region  读取table 中 column类型结点的内容
        /// <summary>
        /// 读取table 中 column类型结点的内容
        ///         /// </summary>
        /// <param name="xnColumns">column结点</param>
        /// <param name="pTable">column结点 所属的table</param>
        private void ReadColumns(XmlNode xnColumns, TableInfo pTable)
        {
            foreach (XmlNode xnColumn in xnColumns)
            {
                pTable.AddColumn(GetColumn(xnColumn));
            }
        }
        /// <summary>
        /// 读取Column node 中的内容
        /// </summary>
        /// <param name="xnColumn">column node</param>
        /// <returns></returns>
        private ColumnInfo GetColumn(XmlNode xnColumn)
        {
            ColumnInfo mColumn = new ColumnInfo();

            XmlElement xe = (XmlElement)xnColumn;

            mColumn.Id = xe.GetAttribute("Id");

            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID": mColumn.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name": mColumn.Name = xnP.InnerText;
                        break;
                    case "a:Code": mColumn.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate": mColumn.CreationDate = xnP.InnerText;
                        break;
                    case "a:Creator": mColumn.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate": mColumn.ModificationDate = xnP.InnerText;
                        break;
                    case "a:Modifier": mColumn.Modifier = xnP.InnerText;
                        break;

                    case "a:Comment": mColumn.Comment = xnP.InnerText;
                        break;
                    case "a:DataType": mColumn.DataType = xnP.InnerText;
                        break;
                    case "a:Length": mColumn.Length = xnP.InnerText;
                        break;
                    case "a:Identity": mColumn.Identity = xnP.InnerText;
                        break;
                    case "a:Mandatory": mColumn.Mandatory = xnP.InnerText;
                        break;
                    case "a:DefaultValue": mColumn.DefaultValue = xnP.InnerText;
                        break;
                }
            }
            return mColumn;

        }
        #endregion


        #region 读取table 中 key类型结点的内容
        /// <summary>
        /// 读取table 中 key类型结点的内容
        /// 
        /// </summary>
        /// <param name="xnColumns">key结点</param>
        /// <param name="pTable">key结点 所属的table</param>
        private void ReadKeys(XmlNode xnKeys, TableInfo pTable)
        {
            foreach (XmlNode xnKey in xnKeys)
            {
                pTable.AddKey(GetKey(xnKey));
            }
        }

       
        /// <summary>
        /// 读取key node的内容
        /// </summary>
        /// <param name="xnKey">key node</param>
        /// <returns></returns>
        private KeyInfo GetKey(XmlNode xnKey)
        {
            KeyInfo mKey = new KeyInfo();
            XmlElement xe = (XmlElement)xnKey;
            mKey.Id = xe.GetAttribute("Id");
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID": mKey.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name": mKey.Name = xnP.InnerText;
                        break;
                    case "a:Code": mKey.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate": mKey.CreationDate = xnP.InnerText;
                        break;
                    case "a:Creator": mKey.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate": mKey.ModificationDate = xnP.InnerText;
                        break;
                    case "a:Modifier": mKey.Modifier = xnP.InnerText;
                        break;
                    case "c:Key.Columns":
                        GetRefIds(xnP, mKey);
                        break;

                }
            }
            return mKey;
        }

        #endregion

        #region 读取设为主键的列
        /// <summary>
        /// 读取key node 下的关联的column的 Id
        /// </summary>
        /// <param name="xnP"></param>
        /// <param name="mKey"></param>
        private void GetRefIds(XmlNode xnP, KeyInfo mKey)
        {
            foreach (XmlNode xnp in xnP.ChildNodes)
            {
                XmlElement xe = (XmlElement)xnp;
                ColumnInfo column = new ColumnInfo();
                column.RefId = xe.GetAttribute("Ref");
                mKey.AddColumn(column);
            }
        }
        #endregion


    }

    /// <summary>
    /// 定义基本的Info类，包含table,key,column 的基本属性
    /// </summary>
    public class PdmBasicInfo
    {
        //Id
        private string id;
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        //ObjectId
        private string objectId;
        public string ObjectID
        {
            get { return this.objectId; }
            set { this.objectId = value; }
        }

        //Name
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        //Code
        private string code;
        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        //CreationDate
        private string creationDate;
        public string CreationDate
        {
            get { return this.creationDate; }
            set { this.creationDate = value; }
        }

        //Creator
        private string creator;
        public string Creator
        {
            get { return this.creator; }
            set { this.creator = value; }
        }

        //ModificationDate
        private string modificationDate;
        public string ModificationDate
        {
            get { return this.modificationDate; }
            set { this.modificationDate = value; }
        }

        //Modifier
        private string modifier;
        public string Modifier
        {
            get { return this.modifier; }
            set { this.modifier = value; }
        }

        //Comment
        private string comment;
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
    }

    /// <summary>
    ///TableInfo 类
    /// </summary>
    public class TableInfo:PdmBasicInfo
    {
        public TableInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 定义属性 ,不全的话可以根据Pdm再加
        //TotalSavingCurrency
        private string totalSavingCurrency;
        public string TotalSavingCurrency
        {
            get { return this.totalSavingCurrency; }
            set { this.totalSavingCurrency = value; }
        }

        private IList<ColumnInfo> columns;
        public IList<ColumnInfo> Columns
        {
            get { return this.columns; }

        }

        private IList<KeyInfo> keys;
        public IList<KeyInfo> Keys
        {
            get { return this.keys; }

        }

        #endregion

        #region 定义方法
        public void AddColumn(ColumnInfo mColumn)
        {
            if (columns == null)
                columns = new List<ColumnInfo>();
            columns.Add(mColumn);

        }

        public void AddKey(KeyInfo mKey)
        {
            if (keys == null)
                keys = new List<KeyInfo>();
            keys.Add(mKey);

        }
        #endregion

    }
    /// <summary>
    ///ColumnInfo 类
    /// </summary>
    public class ColumnInfo:PdmBasicInfo
    {
        public ColumnInfo()
        { }
        #region 定义属性 ,不全的话可以根据Pdm再加
        //RefId
        private string refId;
        public string RefId
        {
            get { return this.refId; }
            set { this.refId = value; }
        }
        //DataType
        private string dataType;
        public string DataType
        {
            get { return this.dataType; }
            set { this.dataType = value; }
        }
        //Length
        private string length;
        public string Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        //Mandatory
        private string mandatory;
        public string Mandatory
        {
            get { return this.mandatory; }
            set { this.mandatory = value; }
        }


        //DefaultValue
        private string defaultValue;
        public string DefaultValue
        {
            get { return this.defaultValue; }
            set { this.defaultValue = value; }

        }
        private string identity;
        public string Identity
        {
            get { return this.identity; }
            set { this.identity = value; }
        }
        #endregion

    }

    /// <summary>
    ///KeyInfo 类
    /// </summary>
    public class KeyInfo : PdmBasicInfo
    {
        public KeyInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        #region 定义方法
        private IList<ColumnInfo> columns;
        public IList<ColumnInfo> Columns
        {
            get { return this.columns; }
        }

        public void AddColumn(ColumnInfo mColumn)
        {
            if (columns == null)
            {
                columns = new List<ColumnInfo>();
            }
            columns.Add(mColumn);

        }
        #endregion
    }
}
