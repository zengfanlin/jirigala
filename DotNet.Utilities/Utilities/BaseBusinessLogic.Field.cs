//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotNet.Utilities
{
    /// <summary>
    ///	BaseBusinessLogic
    /// 通用基类
    /// 
    /// 这个类可是修改了很多次啊，已经比较经典了，随着专业的提升，人也会不断提高，技术也会越来越精湛。
    /// 
    /// 修改纪录
    /// 
    ///		2012.04.05 版本：1.0	JiRiGaLa 改进 GetPermissionScope(string[] organizeIds)。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.05</date>
    /// </author> 
    /// </summary>
    public partial class BaseBusinessLogic
    {
        #region Field 静态字段
        /// <summary>
        /// 主键字段
        /// </summary>
        public static string FieldId = "Id"; 
       
        /// <summary>
        /// 上级字段
        /// </summary>
        public static string FieldParentId = "ParentId"; 
        
        /// <summary>
        /// 编号字段
        /// </summary>
        public static string FieldCode = "Code";  
        
        /// <summary>
        /// 名称字段
        /// </summary>
        public static string FieldFullName = "FullName";  
       
        /// <summary>
        /// 类别字段
        /// </summary>
        public static string FieldCategoryId = "CategoryId";   
        
        /// <summary>
        /// 有效字段
        /// </summary>
        public static string FieldEnabled = "Enabled";   
        
        /// <summary>
        /// 删除标志
        /// </summary>
        public static string FieldDeletionStateCode = "DeletionStateCode"; 

        /// <summary>
        /// 排序码
        /// </summary>
        public static string FieldSortCode = "SortCode";     
        
        /// <summary>
        /// 创建者主键
        /// </summary>
        public static string FieldCreateUserId = "CreateUserId"; 
  
        /// <summary>
        /// 创建人
        /// </summary>
        public static string FieldCreateBy = "CreateBy";  
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public static string FieldCreateOn = "CreateOn";

        /// <summary>
        /// 最后修改者主键
        /// </summary>
        public static string FieldModifiedUserId = "ModifiedUserId";  
        
        /// <summary>
        /// 最后修改者
        /// </summary>
        public static string FieldModifiedBy = "ModifiedBy";
        
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static string FieldModifiedOn = "ModifiedOn";

        /// <summary>
        /// 审核状态 
        /// </summary>
        public static string FieldAuditStatus = "AuditStatus";

        /// <summary>
        /// AND查询逻辑
        /// </summary>
        public static string SQLLogicConditional = " AND ";  
        
        /// <summary>
        /// 选择列 Selected 
        /// </summary>
        public static string SelectedColumn = "Selected";        
        #endregion
    }
}