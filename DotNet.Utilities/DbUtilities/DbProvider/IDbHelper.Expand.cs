//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , yanziSoft , Ltd. 
//-----------------------------------------------------------------

using System.Data;

namespace DotNet.Utilities
{
    /// <summary>
    /// IDbHelperExpand
    /// 数据库访问扩展接口
    /// 
    /// 修改纪录
    /// 
    ///		2010.7.13 版本：1.0 yanzi 数据库访问扩展接口。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>yanzi</name>
    ///		<date>2010.07.13</date>
    /// </author> 
    /// </summary>
    public interface IDbHelperExpand
    {
        /// <summary>
        /// 利用Net SqlBulkCopy 批量导入数据库,速度超快
        /// </summary>
        /// <param name="dataTable">源内存数据表</param>
        void SqlBulkCopyData(DataTable dataTable);
    }
}
