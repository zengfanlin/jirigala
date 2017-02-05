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
    ///	BaseExceptionEntity
    /// 异常记录（程序OK）
    ///
    /// 修改纪录
    /// 
    ///     2008.06.18 版本：3.3 JiRiGaLa   按标准格式建立表结构。
    ///     2008.04.22 版本：3.2 JiRiGaLa   在新的数据库连接里保存异常，不影响其它程序逻辑的事务处理。
    ///     2007.12.03 版本：3.1 JiRiGaLa   吉日整理主键规范化。
    ///		2007.08.25 版本：3.0 JiRiGaLa   WriteException 本地写入异常信息。
    ///		2007.08.01 版本：2.0 JiRiGaLa   LogException 时判断 ConnectionStat，对函数方法进行优化。
    ///		2007.06.07 版本：1.3 JiRiGaLa   进行EventLog主键优化。
    ///     2007.06.07 版本：1.2 JiRiGaLa   重新整理主键。
    ///		2006.02.06 版本：1.1 JiRiGaLa   重新调整主键的规范化。
    ///		2004.11.04 版本：1.0 JiRiGaLa   建立表结构，准备着手记录系统中的异常处理部分。
    ///		2005.08.13 版本：1.0 JiRiGaLa   整理主键。
    /// 
    /// 版本：3.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.1</date>
    /// </author> 
    /// </summary>
    [Serializable]
    public partial class BaseExceptionEntity : BaseEntity
    {
        public BaseExceptionEntity()
        {
        }

        public BaseExceptionEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        public BaseExceptionEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
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

        private string title = string.Empty;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private string message = string.Empty;
        /// <summary>
        /// 消息
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        private string formattedMessage = string.Empty;
        /// <summary>
        /// 格式化消息
        /// </summary>
        public string FormattedMessage
        {
            get
            {
                return this.formattedMessage;
            }
            set
            {
                this.formattedMessage = value;
            }
        }

        private string ipAddress = string.Empty;
        /// <summary>
        /// IPAddress
        /// </summary>
        public string IPAddress
        {
            get
            {
                return this.ipAddress;
            }
            set
            {
                this.ipAddress = value;
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

        private string createBy = string.Empty;
        /// <summary>
        /// 创建者
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

        #region public void ClearProperty()
        /// <summary>
        /// 清除内容
        /// </summary>
        public void ClearProperty()
        {
            this.Id = string.Empty;
            this.CreateBy = string.Empty;
        }
        #endregion

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseExceptionEntity> GetList(DataTable dataTable)
        {
            List<BaseExceptionEntity> entites = new List<BaseExceptionEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        #region public BaseExceptionEntity GetFrom(DataRow dataRow) 从数据行读取
        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <returns>异常的基类表结构定义</returns>
        public BaseExceptionEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldId]);
            this.Message = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldMessage]);
            this.FormattedMessage = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldFormattedMessage]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldIPAddress]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseExceptionEntity.FieldCreateBy]);
            return this;
        }
        #endregion

        public BaseExceptionEntity GetSingle(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }
    }
}