//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseSequenceTable
    /// 序列产生器表
    /// 
    /// 修改纪录
    /// 
    /// 2012-04-23 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-04-23</date>
    /// </author>
    /// </summary>
    public partial class BaseSequenceEntity
    {
        ///<summary>
        /// 序列产生器表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseSequence";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 名称
        ///</summary>
        [NonSerialized]
        public static string FieldFullName = "FullName";

        ///<summary>
        /// 序列号前缀
        ///</summary>
        [NonSerialized]
        public static string FieldPrefix = "Prefix";

        ///<summary>
        /// 序列号分隔符
        ///</summary>
        [NonSerialized]
        public static string FieldSeparator = "Separator";

        ///<summary>
        /// 升序序列
        ///</summary>
        [NonSerialized]
        public static string FieldSequence = "Sequence";

        ///<summary>
        /// 倒序序列
        ///</summary>
        [NonSerialized]
        public static string FieldReduction = "Reduction";

        ///<summary>
        /// 步骤
        ///</summary>
        [NonSerialized]
        public static string FieldStep = "Step";

        ///<summary>
        /// 是否显示
        ///</summary>
        [NonSerialized]
        public static string FieldIsVisible = "IsVisible";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
