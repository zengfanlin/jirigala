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
    /// BasePermissionEntity
    /// 操作权限表
    ///
    /// 修改纪录
    ///
    ///		2011-03-07 版本：1.1 JiRiGaLa 表名修正。
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
    public partial class BasePermissionEntity : BaseEntity
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

        private string resourceId = null;
        /// <summary>
        /// 资源主键
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

        private string resourceCategory = null;
        /// <summary>
        /// 资料类别
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

        private int? permissionId = null;
        /// <summary>
        /// 权限主键
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
        /// 权限条件限制
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
        public BasePermissionEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BasePermissionEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BasePermissionEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BasePermissionEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BasePermissionEntity GetSingle(DataTable dataTable)
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
        public List<BasePermissionEntity> GetList(DataTable dataTable)
        {
            List<BasePermissionEntity> entites = new List<BasePermissionEntity>();
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
        public BasePermissionEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionEntity.FieldId]);
            this.ResourceId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldResourceId]);
            this.ResourceCategory = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldResourceCategory]);
            this.PermissionId = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionEntity.FieldPermissionItemId]);
            this.PermissionConstraint = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldPermissionConstraint]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionEntity.FieldModifiedUserId]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BasePermissionEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionEntity.FieldId]);
            this.ResourceId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldResourceId]);
            this.ResourceCategory = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldResourceCategory]);
            this.PermissionId = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionEntity.FieldPermissionItemId]);
            this.PermissionConstraint = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldPermissionConstraint]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionEntity.FieldModifiedUserId]);
            return this;
        }
    }
}
