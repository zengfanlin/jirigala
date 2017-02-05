//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizeManager
    /// 组织机构、部门表
    ///
    /// 修改纪录
    ///
    ///		2012-05-17 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012-05-17</date>
    /// </author>
    /// </summary>
    public partial class BaseOrganizeManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseOrganizeEntity organizeEntity)
        {
            sqlBuilder.SetValue(BaseOrganizeEntity.FieldLayer, organizeEntity.Layer);
        }
    }
}
