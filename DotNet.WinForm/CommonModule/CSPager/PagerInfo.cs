//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace DotNet.WinForm
{
	[Serializable]
    public class PagerInfo
    {
        private int currenetPageIndex; //当前页码
        private int pageSize;//每页显示的记录
        private int recordCount;//记录总数

        #region 属性变量

        /// <summary>
        /// 获取或设置当前页码
        /// </summary>
        [XmlElement(ElementName = "CurrenetPageIndex")]
        public int CurrenetPageIndex
        {
            get { return currenetPageIndex; }
            set { currenetPageIndex = value; }
        }

        /// <summary>
        /// 获取或设置每页显示的记录
        /// </summary>
        [XmlElement(ElementName = "PageSize")]
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 获取或设置记录总数
        /// </summary>
        [XmlElement(ElementName = "RecordCount")]
        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        } 

        #endregion
    }
}
