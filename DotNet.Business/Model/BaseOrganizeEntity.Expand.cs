//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizeEntity
    /// 组织机构、部门表
    ///
    /// 修改纪录
    ///
    ///		2012-05-07 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012-05-07</date>
    /// </author>
    /// </summary>
    public partial class BaseOrganizeEntity
    {
        private int? layer = 0;
        /// <summary>
        /// 层
        /// </summary>
        public int? Layer
        {
            get
            {
                return this.layer;
            }
            set
            {
                this.layer = value;
            }
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public override void GetFromExpand(DataRow dataRow)
        {
            this.Layer = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldLayer]);
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public override void GetFromExpand(IDataReader dataReader)
        {
            this.Layer = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldLayer]);
        }
    }
}
