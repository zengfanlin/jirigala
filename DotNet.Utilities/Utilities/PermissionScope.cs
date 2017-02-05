//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// PermissionScope
    /// 常用权限范围。
    /// 
    /// 修改纪录
    ///
    ///     2012.05.07 版本：2.0 JiRiGaLa 增加UserSubCompany。
    ///     2009.09.01 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.05.07</date>
    /// </author> 
    /// </summary>
    public enum PermissionScope
    {
        None = 0,            // 没有任何数据权限
        All = -1,            // 全部数据
        UserCompany = -2,    // 用户所在公司数据
        UserSubCompany = -3,     // 用户所在分支机构数据
        UserDepartment = -4, // 用户所在部门数据
        UserWorkgroup = -5,  // 用户所在工作组数据
        User = -6,           // 自己的数据，仅本人
        Detail = -7,         // 按详细设定的数据
    }
}