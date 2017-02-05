//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    ///  BaseProjectEntity
    /// 
    ///  修改记录
    /// 
    ///     2008.05.20 版本:1.0 吉日嘎拉 主键创建
    /// 
    /// 版本1.0
    /// <author>
    ///     <name>吉日嘎拉</name>
    ///     <date>2008.05.20</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseProjectEntity : BaseEntity
    {
        private string id = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public string ID
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

        private string organizeId = string.Empty;
        /// <summary>
        /// 部门主键
        /// </summary>
        public string OrganizeId
        {
            get
            {
                return this.organizeId;
            }
            set
            {
                this.organizeId = value;
            }
        }

        private string code = string.Empty;
        /// <summary>
        /// 编号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string fullName = string.Empty;
        /// <summary>
        /// 全称
        /// </summary>
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        private string categoryId = string.Empty;
        /// <summary>
        /// 分类主键
        /// </summary>
        public string CategoryId
        {
            get
            {
                return this.categoryId;
            }
            set
            {
                this.categoryId = value;
            }
        }

        private string managerId = string.Empty;
        /// <summary>
        /// 主管主键
        /// </summary>
        public string ManagerId
        {
            get
            {
                return this.managerId;
            }
            set
            {
                this.managerId = value;
            }
        }

        private bool enabled = false;
        /// <summary>
        /// 有效
        /// </summary>
        public bool Enabled
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

        private string description = string.Empty;
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

        private string sortCode = string.Empty;
        /// <summary>
        /// 排序
        /// </summary>
        public string SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private string createUserId = string.Empty;
        /// <summary>
        /// 创建者主键
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

        private string createOn = string.Empty;
        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateOn
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

        private string modifiedUserId = string.Empty;
        /// <summary>
        /// 修改者主键
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

        private string modifiedOn = string.Empty;
        /// <summary>
        /// 修改日期
        /// </summary>
        public string ModifiedOn
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

        /*
         
        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseProjectEntity> GetList(DataTable dataTable)
        {
            List<BaseProjectEntity> entites = new List<BaseProjectEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }
        */
    }
}