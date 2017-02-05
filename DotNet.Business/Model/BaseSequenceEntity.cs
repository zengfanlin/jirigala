//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseSequenceEntity
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
    [Serializable]
    public partial class BaseSequenceEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String FullName { get; set; }

        /// <summary>
        /// 序列号前缀
        /// </summary>
        public String Prefix { get; set; }

        /// <summary>
        /// 序列号分隔符
        /// </summary>
        public String Separator { get; set; }

        /// <summary>
        /// 升序序列
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// 倒序序列
        /// </summary>
        public int? Reduction { get; set; }

        /// <summary>
        /// 步骤
        /// </summary>
        public int? Step { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsVisible { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseSequenceEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseSequenceEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseSequenceEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseSequenceEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseSequenceEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取返回实体列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public List<BaseSequenceEntity>  GetList(DataTable dataTable)
        {
            List<BaseSequenceEntity> entities=new List<BaseSequenceEntity>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                entities.Add(GetFrom(dataRow));
            }
            return entities;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseSequenceEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldId]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldFullName]);
            this.Prefix = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldPrefix]);
            this.Separator = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldSeparator]);
            this.Sequence = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldSequence]);
            this.Reduction = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldReduction]);
            this.Step = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldStep]);
            this.IsVisible = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldIsVisible]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseSequenceEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseSequenceEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseSequenceEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldId]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldFullName]);
            this.Prefix = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldPrefix]);
            this.Separator = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldSeparator]);
            this.Sequence = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldSequence]);
            this.Reduction = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldReduction]);
            this.Step = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldStep]);
            this.IsVisible = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldIsVisible]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseSequenceEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseSequenceEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldModifiedBy]);
            return this;
        }
    }
}
