//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
	/// <summary>
    /// BaseParameterEntity
	/// 参数表的基类结构定义
	///
	/// 修改纪录
    ///     2007.06.07 版本：2.0 JiRiGaLa   字段名变更
	///		2006.02.05 版本：1.1 JiRiGaLa	重新调整主键的规范化。
	///		2004.08.29 版本：1.0 JiRiGaLa	主键ID需要进行倒序排序，这样数据库管理员很方便地找到最新的纪录及被修改的纪录。
	///										CategoryId 需要进行外键数据库完整性约束。
	///										CreateOn 需要进行有默认值，不需要赋值也能获得当前的系统时间。
	///										CreateUserId、ModifiedUserId 需要有外件数据库完整性约束。
	///										Content、CreateUserId 不可以为空，减少垃圾数据。
	///		2005.08.13 版本：1.0 JiRiGaLa	增加版权信息。
	/// 
	/// 版本：1.1
	///
	/// <author>
	///		<name>JiRiGaLa</name>
	///		<date>2006.02.05</date>
	/// </author> 
	/// </summary>
    public partial class BaseParameterEntity
	{
        /// <summary>
        /// 表名
        /// </summary>
        [NonSerialized]
        public static string TableName = "BaseParameter";

        /// <summary>
        /// 主键
        /// </summary>
        [NonSerialized]
        public static string FieldId = "Id";

        /// <summary>
        /// 类别主键
        /// </summary>
        [NonSerialized]
        public static string FieldCategoryId = "CategoryId";

        /// <summary>
        /// 标记主键
        /// </summary>
        [NonSerialized]
        public static string FieldParameterId = "ParameterId";

        /// <summary>
        /// 标记编码
        /// </summary>
        [NonSerialized]
        public static string FieldParameterCode = "ParameterCode";

        /// <summary>
        /// 标记内容
        /// </summary>
        [NonSerialized]
        public static string FieldParameterContent = "ParameterContent";

        /// <summary>
        /// 处理状态
        /// </summary>
        [NonSerialized]
        public static string FieldWorked = "Worked";

        /// <summary>
        /// 有效性
        /// </summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        /// <summary>
        /// 描述
        /// </summary>
        [NonSerialized]
        public static string FieldDescription = "Description";
        
        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        /// <summary>
        /// 排序码
        /// </summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        /// <summary>
        /// 创建者
        /// </summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        /// <summary>
        /// 创建者主键
        /// </summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        /// <summary>
        /// 创建时间
        /// </summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        /// <summary>
        /// 最后修改者主键
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        /// <summary>
        /// 最后修改者
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";
	}
}