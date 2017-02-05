//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BUBaseParameterDefine
    /// 参数表的基类结构定义
    ///
    /// 修改纪录
    ///     2011.07.05 版本：2.1 zgl        修改enable  默认值为true
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
    [Serializable]
    public partial class BaseParameterEntity : BaseEntity
    {
        #region public void ClearProperty(BaseParameterEntity ParameterEntity)
        /// <summary>
        /// 清除内容
        /// <param name="ParameterEntity">实体</param>
        /// </summary>
        public void ClearProperty(BaseParameterEntity ParameterEntity)
        {
            ParameterEntity.Id = string.Empty;
            ParameterEntity.CategoryId = string.Empty;
            ParameterEntity.ParameterId = string.Empty;
            ParameterEntity.ParameterCode = string.Empty;
            ParameterEntity.ParameterContent = string.Empty;
            ParameterEntity.Worked = false;
            ParameterEntity.Enabled = false;
            ParameterEntity.SortCode = string.Empty;
            ParameterEntity.Description = string.Empty;
            ParameterEntity.CreateUserId = string.Empty;
            ParameterEntity.CreateOn = string.Empty;
            ParameterEntity.ModifiedUserId = string.Empty;
            ParameterEntity.ModifiedOn = string.Empty;
        }
        #endregion

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseParameterEntity> GetList(DataTable dataTable)
        {
            List<BaseParameterEntity> entites = new List<BaseParameterEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        #region public BaseParameterEntity GetFrom(DataRow dataRow)
        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <returns>BaseParameterEntity</returns>
        public BaseParameterEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldId]);
            this.CategoryId = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldCategoryId]);
            this.ParameterId = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldParameterId]);
            this.ParameterCode = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldParameterCode]);
            this.ParameterContent = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldParameterContent]);
            this.Worked = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseParameterEntity.FieldWorked]);
            this.Enabled = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseParameterEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldDescription]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldCreateUserId]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldCreateOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldModifiedUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToString(dataRow[BaseParameterEntity.FieldModifiedOn]);
            return this;
        }
        #endregion

        public BaseParameterEntity GetSingle(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        private string id = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
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

        private string categoryId = string.Empty;
        /// <summary>
        /// 类别主键
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

        private string parameterId = string.Empty;
        /// <summary>
        /// 标记主键
        /// </summary>
        public string ParameterId
        {
            get
            {
                return this.parameterId;
            }
            set
            {
                this.parameterId = value;
            }
        }

        private string parameterCode = string.Empty;
        /// <summary>
        /// 标记编码
        /// </summary>
        public string ParameterCode
        {
            get
            {
                return this.parameterCode;
            }
            set
            {
                this.parameterCode = value;
            }
        }

        private string parameterContent = string.Empty;
        /// <summary>
        /// 标记编码
        /// </summary>
        public string ParameterContent
        {
            get
            {
                return this.parameterContent;
            }
            set
            {
                this.parameterContent = value;
            }
        }

        private bool worked = false;
        /// <summary>
        /// 处理状态
        /// </summary>
        public bool Worked
        {
            get
            {
                return this.worked;
            }
            set
            {
                this.worked = value;
            }
        }

        private bool enabled = true;
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

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标志
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
        /// 创建者
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
        /// 创建时间
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
        /// 最后修改者
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
        /// 最后修改日期
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
    }
}