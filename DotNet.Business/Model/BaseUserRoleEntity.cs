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
    /// BaseUserRoleEntity
    /// 用户角色表
    ///
    /// 修改纪录
    ///
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
    public partial class BaseUserRoleEntity : BaseEntity
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

        private int? userId = null;
        /// <summary>
        /// 用户主键
        /// </summary>
        public int? UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private int? roleId = null;
        /// <summary>
        /// 角色主键
        /// </summary>
        public int? RoleId
        {
            get
            {
                return this.roleId;
            }
            set
            {
                this.roleId = value;
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

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserRoleEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseUserRoleEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserRoleEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserRoleEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserRoleEntity GetSingle(DataTable dataTable)
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
        public List<BaseUserRoleEntity> GetList(DataTable dataTable)
        {
            List<BaseUserRoleEntity> entites = new List<BaseUserRoleEntity>();
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
        public BaseUserRoleEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserRoleEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserRoleEntity.FieldUserId]);
            this.RoleId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserRoleEntity.FieldRoleId]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserRoleEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseUserRoleEntity.FieldDescription]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserRoleEntity.FieldDeletionStateCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserRoleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserRoleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserRoleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserRoleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserRoleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserRoleEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserRoleEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserRoleEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserRoleEntity.FieldUserId]);
            this.RoleId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserRoleEntity.FieldRoleId]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserRoleEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseUserRoleEntity.FieldDescription]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserRoleEntity.FieldDeletionStateCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserRoleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserRoleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserRoleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserRoleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserRoleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserRoleEntity.FieldModifiedBy]);
            return this;
        }
    }
}
