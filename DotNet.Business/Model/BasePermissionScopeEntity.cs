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
    /// BasePermissionScopeEntity
    /// 数据权限表
    ///
    /// 修改纪录
    ///
    ///		2011-03-07 版本：1.1 JiRiGaLa 改名。
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BasePermissionScopeEntity : BaseEntity
    {
        private int? id = null;
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string resourceCategory = null;
        /// <summary>
        /// 什么类型的
        /// </summary>
        public string ResourceCategory
        {
            get
            {
                return this.resourceCategory;
            }
            set
            {
                this.resourceCategory = value;
            }
        }

        private string resourceId = null;
        /// <summary>
        /// 什么资源
        /// </summary>
        public string ResourceId
        {
            get
            {
                return this.resourceId;
            }
            set
            {
                this.resourceId = value;
            }
        }

        private string targetCategory = null;
        /// <summary>
        /// 对什么类型的
        /// </summary>
        public string TargetCategory
        {
            get
            {
                return this.targetCategory;
            }
            set
            {
                this.targetCategory = value;
            }
        }

        private string targetId = null;
        /// <summary>
        /// 对什么资源
        /// </summary>
        public string TargetId
        {
            get
            {
                return this.targetId;
            }
            set
            {
                this.targetId = value;
            }
        }

        private int? permissionId = null;
        /// <summary>
        /// 有什么权限
        /// </summary>
        public int? PermissionId
        {
            get
            {
                return this.permissionId;
            }
            set
            {
                this.permissionId = value;
            }
        }

        private string permissionConstraint = null;
        /// <summary>
        /// 有什么权限
        /// </summary>
        public string PermissionConstraint
        {
            get
            {
                return this.permissionConstraint;
            }
            set
            {
                this.permissionConstraint = value;
            }
        }


        private DateTime? startDate = null;
        /// <summary>
        /// 開始生效日期
        /// </summary>
        public DateTime? StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }


        private DateTime? endDate = null;
        /// <summary>
        /// 结束生效日期
        /// </summary>
        public DateTime? EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }


        private int? enabled = 1;
        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private string description = null;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private string createBy = null;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private string createUserId = null;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        private string modifiedBy = null;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        private string modifiedUserId = null;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BasePermissionScopeEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BasePermissionScopeEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BasePermissionScopeEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BasePermissionScopeEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BasePermissionScopeEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BasePermissionScopeEntity> GetList(DataTable dataTable)
        {
            List<BasePermissionScopeEntity> entites = new List<BasePermissionScopeEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BasePermissionScopeEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionScopeEntity.FieldId]);
            this.ResourceCategory = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldResourceCategory]);
            this.ResourceId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldResourceId]);
            this.TargetCategory = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldTargetCategory]);
            this.TargetId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldTargetId]);
            this.PermissionId = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionScopeEntity.FieldPermissionItemId]);
            this.PermissionConstraint = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldPermissionConstraint]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionScopeEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionScopeEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionScopeEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionScopeEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionScopeEntity.FieldModifiedUserId]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BasePermissionScopeEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionScopeEntity.FieldId]);
            this.ResourceCategory = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldResourceCategory]);
            this.ResourceId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldResourceId]);
            this.TargetCategory = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldTargetCategory]);
            this.TargetId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldTargetId]);
            this.PermissionId = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionScopeEntity.FieldPermissionItemId]);
            this.PermissionConstraint = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldPermissionConstraint]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionScopeEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionScopeEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionScopeEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionScopeEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionScopeEntity.FieldModifiedUserId]);
            return this;
        }
    }
}
