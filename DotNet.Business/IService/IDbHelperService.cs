//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IDbHelperService
    /// 数据库访问通用类标准接口。
    /// 
    /// 修改纪录
    /// 
    ///		2008.08.26 版本：2.0 JiRiGaLa 将主键进行精简整理。
    ///		2008.08.25 版本：1.3 JiRiGaLa 将标准数据库接口方法进行分离、分离为标准接口方法与扩展接口方法部分。
    ///		2008.06.03 版本：1.2 JiRiGaLa 增加 DbParameter[] dbParameters 方法。
    ///		2008.05.07 版本：1.1 JiRiGaLa 增加GetWhereString定义。
    ///		2008.03.20 版本：1.0 JiRiGaLa 创建标准接口，这次应该算是一次飞跃。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.08.26</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IDbHelperService
    {
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <returns>影响行数</returns>
        [OperationContract(Name = "ExecuteNonQuery")]
        int ExecuteNonQuery(BaseUserInfo userInfo, string commandText);
        
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        [OperationContract(Name = "ExecuteNonQuery2")]
        int ExecuteNonQuery(BaseUserInfo userInfo, string commandText, DbParameter[] dbParameters);

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>Object</returns>
        [OperationContract(Name = "ExecuteScalar")]
        object ExecuteScalar(BaseUserInfo userInfo, string commandText);
        
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        [OperationContract(Name = "ExecuteScalar2")]
        object ExecuteScalar(BaseUserInfo userInfo, string commandText, DbParameter[] dbParameters);
        
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        [OperationContract(Name = "Fill")]
        DataTable Fill(BaseUserInfo userInfo, string commandText);

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        [OperationContract(Name = "Fill2")]
        DataTable Fill(BaseUserInfo userInfo, string commandText, DbParameter[] dbParameters);
    }
}