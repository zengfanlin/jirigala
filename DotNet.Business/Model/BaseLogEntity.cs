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
    /// BaseLogEntity
    /// 日志的基类（程序OK）
	/// 
	/// 想在这里实现访问记录、继承以前的比较好的思路。
	///
	/// 修改纪录
    /// 
    ///     2011.03.24 版本：2.6 JiRiGaLa   讲程序转移到DotNet.BaseManager命名空间中。
    ///     2007.12.03 版本：2.3 JiRiGaLa   进行规范化整理。
    ///     2007.11.08 版本：2.2 JiRiGaLa   整理多余的主键（OK）。
    ///		2007.07.09 版本：2.1 JiRiGaLa   程序整理，修改 Static 方法，采用 Instance 方法。
    ///		2006.12.02 版本：2.0 JiRiGaLa   程序整理，错误方法修改。
	///		2004.07.28 版本：1.0 JiRiGaLa   进行了排版、方法规范化、接口继承、索引器。
	///		2004.11.12 版本：1.0 JiRiGaLa   删除了一些方法。
	///		2005.09.30 版本：1.0 JiRiGaLa   又进行一次飞跃，把一些思想进行了统一。
	/// 
	/// 版本：2.3
	///
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.03</date>
	/// </author> 
	/// </summary>
    [Serializable]
    public partial class BaseLogEntity : BaseEntity
    {
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

        private string processId = string.Empty;
        /// <summary>
        /// 服务主键
        /// </summary>
        public string ProcessId
        {
            get
            {
                return this.processId;
            }
            set
            {
                this.processId = value;
            }
        }

        private string processName = string.Empty;
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ProcessName
        {
            get
            {
                return this.processName;
            }
            set
            {
                this.processName = value;
            }
        }

        private string methodId = string.Empty;
        /// <summary>
        /// 方法
        /// </summary>
        public string MethodId
        {
            get
            {
                return this.methodId;
            }
            set
            {
                this.methodId = value;
            }
        }

        private string methodName = string.Empty;
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName
        {
            get
            {
                return this.methodName;
            }
            set
            {
                this.methodName = value;
            }
        }

        private string parameters = string.Empty;
        /// <summary>
        /// 操作记录,添加,编辑,删除参数
        /// </summary>
        public string Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
            }
        }

        private string userId = string.Empty;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId
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

        private string userRealName = string.Empty;
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserRealName
        {
            get
            {
                return this.userRealName;
            }
            set
            {
                this.userRealName = value;
            }
        }

        private string ipAddress = string.Empty;
        /// <summary>
        /// IP地址
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

        private string urlReferrer = string.Empty;
        /// <summary>
        /// 上一网络地址
        /// </summary>
        public string UrlReferrer
        {
            get
            {
                return this.urlReferrer;
            }
            set
            {
                this.urlReferrer = value;
            }
        }

        private string webUrl = string.Empty;
        /// <summary>
        /// 网络地址
        /// </summary>
        public string WebUrl
        {
            get
            {
                return this.webUrl;
            }
            set
            {
                this.webUrl = value;
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

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseLogEntity> GetList(DataTable dataTable)
        {
            List<BaseLogEntity> entites = new List<BaseLogEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        #region public BaseLogEntity GetFrom(DataRow dataRow)
        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseLogEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldId]);
            this.ProcessId = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldProcessId]);
            this.ProcessName = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldProcessName]);
            this.MethodName = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldMethodName]);
            this.Parameters = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldParameters]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldIPAddress]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldUserId]);
            this.UrlReferrer = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldUrlReferrer]);
            this.WebUrl = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldWebUrl]);
            this.UserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldUserRealName]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseLogEntity.FieldCreateOn]);
            return this;
        }
        #endregion
    }
}