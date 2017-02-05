//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Utilities
{
    #region public public enum OperationCode 权限枚举类型
    /// <summary>
    /// 权限枚举类型
    /// 
    /// 修改记录
    ///
    ///		2008.05.10 版本：1.1 JiRiGaLa 命名为 OperationCode。 
    ///		2007.12.08 版本：1.0 JiRiGaLa 添加 Config、UpLoad、DownLoad 权限。 
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.08</date>
    /// </author> 
    /// </remarks>
    public enum OperationCode
    {
        Access = 1,     // 访问权限
        Add = 2,        // 新增权限
        Edit = 3,       // 编辑权限
        View = 4,       // 浏览权限
        Delete = 5,     // 删除权限
        Search = 6,     // 查询权限
        Import = 7,     // 导入权限
        Export = 8,     // 导出权限
        Print = 9,      // 打印权限
        Auditing = 10,  // 审核权限
        Admin = 11,     // 管理权限
        Config = 12,    // 配置权限
        UpLoad = 13,    // 上传权限
        DownLoad = 14   // 下载权限
    }
    #endregion
}