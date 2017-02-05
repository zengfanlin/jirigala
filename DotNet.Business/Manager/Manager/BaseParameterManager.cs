//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
	using DotNet.Utilities;

	/// <summary>
	/// BaseParameterManager
	/// 参数类
	/// 
	/// 修改纪录
	///     2011.04.05 版本：2.2 zgl        修改AddEntity 为public 方法，ip限制功能中使用
	///     2009.04.01 版本：2.1 JiRiGaLa   创建者、修改者进行完善。
	///     2008.04.30 版本：2.0 JiRiGaLa   按面向对象，面向服务进行改进。
	///     2007.06.08 版本：1.4 JiRiGaLa   重新调整方法。
	///		2006.02.05 版本：1.3 JiRiGaLa	重新调整主键的规范化。
	///		2006.01.28 版本：1.2 JiRiGaLa	对一些方法进行改进，主键整理，调用性能也进行了修改，主键顺序进行整理。
	///		2005.08.13 版本：1.1 JiRiGaLa	主键整理好。
	///		2004.11.12 版本：1.0 JiRiGaLa	主键进行了绝对的优化，这是个好东西啊，平时要多用，用得要灵活些。
	///
	/// 版本：2.0
	///
	/// <author>
	///		<name>JiRiGaLa</name>
	///		<date>2008.04.30</date>
	/// </author> 
	/// </summary>
    public partial class BaseParameterManager : BaseManager
	{
		#region public string Add(string categoryId, string parameterId, string parameterCode, string parameterContent, bool worked, bool enabled)
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="parameterId">标记主键</param>
		/// <param name="parameterCode">标记编码</param>
		/// <param name="parameterContent">标记内容</param>
		/// <param name="worked">工作状态</param>
		/// <param name="enabled">有效</param>
		/// <returns>主键</returns>
		public string Add(string categoryId, string parameterId, string parameterCode, string parameterContent, bool worked, bool enabled)
		{
			BaseParameterEntity parameterEntity = new BaseParameterEntity();
			parameterEntity.CategoryId = categoryId;
			parameterEntity.ParameterId = parameterId;
			parameterEntity.ParameterCode = parameterCode;
			parameterEntity.ParameterContent = parameterContent;
			parameterEntity.Worked = worked;
			parameterEntity.Enabled = enabled;
			return this.Add(parameterEntity);
		}
		#endregion

		#region public string Add(BaseParameterEntity parameterEntity)
		/// <summary>
		/// 添加内容
		/// </summary>
		/// <param name="parameterEntity">内容</param>
		/// <returns>主键</returns>
		public string Add(BaseParameterEntity parameterEntity)
		{
            string returnValue = string.Empty;
			// 此处检查this.exist()
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, parameterEntity.CategoryId));
			parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterEntity.ParameterId));
			parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterCode, parameterEntity.ParameterCode));
            if (this.Exists(parameters))
			{
				// 编号已重复
				this.ReturnStatusCode = StatusCode.ErrorCodeExist.ToString();                
			}
			else
			{
				returnValue = this.AddEntity(parameterEntity);
				// 运行成功
				this.ReturnStatusCode = StatusCode.OKAdd.ToString();
			}
			return returnValue;
		}
		#endregion

		#region public int Update(BaseParameterEntity parameterEntity) 更新
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="parameterEntity">参数基类表结构定义</param>
		/// <returns>影响行数</returns>
		public int Update(BaseParameterEntity parameterEntity)
		{
			int returnValue = 0;
			// 检查是否已被其他人修改
			//if (DbLogic.IsModifed(DbHelper, BaseParameterEntity.TableName, parameterEntity.Id, parameterEntity.ModifiedUserId, parameterEntity.ModifiedOn))
			//{
			//    // 数据已经被修改
			//    this.ReturnStatusCode = StatusCode.ErrorChanged.ToString();
			//}
			//else
			//{
				// 检查编号是否重复
				if (this.Exists(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterCode, parameterEntity.ParameterCode), parameterEntity.Id))
				{
					// 文件夹名已重复
					this.ReturnStatusCode = StatusCode.ErrorCodeExist.ToString();
				}
				else
				{
					// 进行更新操作
					returnValue = this.UpdateEntity(parameterEntity);
					if (returnValue == 1)
					{
						this.ReturnStatusCode = StatusCode.OKUpdate.ToString();
					}
					else
					{
						// 数据可能被删除
						this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
					}
				}
			// }
			return returnValue;
		}
		#endregion

		#region public string GetParameter(string categoryId, string parameterId, string parameterCode)
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="flagID">标志主键</param>
		/// <param name="paramFlagCode">编码</param>
		/// <returns>参数值</returns>
		public string GetParameter(string categoryId, string parameterId, string parameterCode)
		{
			List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, categoryId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterCode, parameterCode));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldDeletionStateCode, 0));
            return this.GetProperty(parameters, BaseParameterEntity.FieldParameterContent).ToString();
		}
		#endregion

		#region public int SetParameter(string categoryId, string parameterId, string parameterCode, string parameterContent)
		/// <summary>
		/// 更新参数设置
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="parameterId">标志主键</param>
		/// <param name="parameterCode">编码</param>
		/// <param name="parameterContent">参数内容</param>
		/// <returns>影响行数</returns>
		public int SetParameter(string categoryId, string parameterId, string parameterCode, string parameterContent)
		{
			int returnValue = 0;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, categoryId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterCode, parameterCode));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldDeletionStateCode, 0));
			// 检测是否无效数据
			if ((parameterContent == null) || (parameterContent.Length == 0))
			{
                returnValue = this.Delete(parameters);
			}
			else
			{
				// 检测是否存在
                returnValue = this.SetProperty(parameters, new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterContent, parameterContent));
				if (returnValue == 0)
				{
					// 进行增加操作
					BaseParameterEntity parameterEntity = new BaseParameterEntity();
					parameterEntity.CategoryId = categoryId;
					parameterEntity.ParameterId = parameterId;
					parameterEntity.ParameterCode = parameterCode;
					parameterEntity.ParameterContent = parameterContent;
					parameterEntity.Enabled = true;
					parameterEntity.DeletionStateCode = 0;
					this.AddEntity(parameterEntity);
					returnValue = 1;
				}
			}
			return returnValue;
		}
		#endregion

		#region public DataTable GetDataTableByParameter(string categoryId, string parameterId)
		/// <summary>
		/// 获取记录
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="flagID">标志主键</param>
		/// <param name="paramFlagCode">编码</param>
		/// <returns>数据表</returns>
		public DataTable GetDataTableByParameter(string categoryId, string parameterId)
		{
			List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, categoryId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterId));
            return this.GetDataTable(parameters);
		}
		#endregion

		#region public DataTable GetDataTableParameterCode(string categoryId, string parameterId, string parameterCode)
		/// <summary>
		/// 获取记录
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="parameterId">标志主键</param>
		/// <param name="parameterCode">编码</param>
		/// <returns>数据表</returns>
		public DataTable GetDataTableParameterCode(string categoryId, string parameterId, string parameterCode)
		{
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, categoryId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterCode, parameterCode));
            return this.GetDataTable(parameters, BaseParameterEntity.FieldCreateOn);
		}
		#endregion

		#region public int DeleteByParameter(string categoryId, string parameterId)
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="flagID">标志主键</param>
		/// <returns>影响行数</returns>
		public int DeleteByParameter(string categoryId, string parameterId)
		{
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, categoryId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterId));
            return this.Delete(parameters);
		}
		#endregion

		#region public int DeleteByParameterCode(string categoryId, string parameterId, string parameterCode)
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="categoryId">类别主键</param>
		/// <param name="parameterId">标志主键</param>
		/// <param name="parameterCode">标志编号</param>
		/// <returns>影响行数</returns>
		public int DeleteByParameterCode(string categoryId, string parameterId, string parameterCode)
		{
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, categoryId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, parameterId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterCode, parameterCode));
            return this.Delete(parameters);
		}
		#endregion
	}
}