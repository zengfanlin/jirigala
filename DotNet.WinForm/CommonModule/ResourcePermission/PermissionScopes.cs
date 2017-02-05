//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// PermissionScopes.cs
    /// 权限范围
    ///		
    /// 修改记录
    ///
    ///     2011.03.18 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.03.18</date>
    /// </author> 
    /// </summary>  
    [Serializable]
    public class PermissionScopes
    {
        public string[] GrantUserIds = null;
        public string[] GrantRoleIds = null;
        public string[] GrantOrganizeIds = null;
        public string[] GrantModuleIds = null;
        public string[] GrantPermissionIds = null;
    }
}