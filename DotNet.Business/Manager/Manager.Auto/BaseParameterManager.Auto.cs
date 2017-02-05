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
		public BaseParameterManager()
		{
			if (base.dbHelper == null)
			{
				base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
			}
			base.CurrentTableName = BaseParameterEntity.TableName;
		}

		public BaseParameterManager(IDbHelper dbHelper) : this()
		{
			DbHelper = dbHelper;
		}

		public BaseParameterManager(BaseUserInfo userInfo) : this()
		{
			UserInfo = userInfo;
		}

		public BaseParameterManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this()
		{
			DbHelper = dbHelper;
			UserInfo = userInfo;
		}

		#region public string AddEntity(BaseParameterEntity parameterEntity)
		/// <summary>
		/// 添加实体
		/// </summary>
		/// <param name="parameterEntity">实体对象</param>
		/// <returns>主键</returns>
		public string AddEntity(BaseParameterEntity parameterEntity)
		{
			if (string.IsNullOrEmpty(parameterEntity.Id))
			{
				parameterEntity.Id = Guid.NewGuid().ToString();
			}
			SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
			sqlBuilder.BeginInsert(this.CurrentTableName);
			sqlBuilder.SetValue(BaseParameterEntity.FieldId, parameterEntity.Id);
			sqlBuilder.SetValue(BaseParameterEntity.FieldCategoryId, parameterEntity.CategoryId);
			sqlBuilder.SetValue(BaseParameterEntity.FieldParameterId, parameterEntity.ParameterId);
			sqlBuilder.SetValue(BaseParameterEntity.FieldParameterCode, parameterEntity.ParameterCode);
			sqlBuilder.SetValue(BaseParameterEntity.FieldWorked, parameterEntity.Worked ? 1 : 0);
			sqlBuilder.SetValue(BaseParameterEntity.FieldParameterContent, parameterEntity.ParameterContent);
			sqlBuilder.SetValue(BaseParameterEntity.FieldEnabled, parameterEntity.Enabled ? 1 : 0);
			sqlBuilder.SetValue(BaseParameterEntity.FieldDeletionStateCode, parameterEntity.DeletionStateCode);
			sqlBuilder.SetValue(BaseParameterEntity.FieldDescription, parameterEntity.Description);
			if (UserInfo != null)
			{
				sqlBuilder.SetValue(BaseParameterEntity.FieldCreateUserId, UserInfo.Id);
				sqlBuilder.SetValue(BaseParameterEntity.FieldCreateBy, UserInfo.RealName);
			}
			sqlBuilder.SetDBNow(BaseParameterEntity.FieldCreateOn);
			return sqlBuilder.EndInsert() > 0 ? parameterEntity.Id : string.Empty;
		}
		#endregion

		#region protected int UpdateEntity(BaseParameterEntity parameterEntity) 更新
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="parameterEntity">实体</param>
		/// <returns>影响行数</returns>
		protected int UpdateEntity(BaseParameterEntity parameterEntity)
		{
			SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
			sqlBuilder.BeginUpdate(this.CurrentTableName);
			sqlBuilder.SetValue(BaseParameterEntity.FieldCategoryId, parameterEntity.CategoryId);
			sqlBuilder.SetValue(BaseParameterEntity.FieldParameterCode, parameterEntity.ParameterCode);
			sqlBuilder.SetValue(BaseParameterEntity.FieldParameterId, parameterEntity.ParameterId);
			sqlBuilder.SetValue(BaseParameterEntity.FieldParameterContent, parameterEntity.ParameterContent);
			sqlBuilder.SetValue(BaseParameterEntity.FieldWorked, parameterEntity.Worked ? 1 : 0);
			sqlBuilder.SetValue(BaseParameterEntity.FieldEnabled, parameterEntity.Enabled ? 1 : 0);
			sqlBuilder.SetValue(BaseParameterEntity.FieldDeletionStateCode, parameterEntity.DeletionStateCode);
			sqlBuilder.SetValue(BaseParameterEntity.FieldModifiedUserId, UserInfo.Id);
			sqlBuilder.SetValue(BaseParameterEntity.FieldModifiedBy, UserInfo.RealName);
			sqlBuilder.SetDBNow(BaseParameterEntity.FieldModifiedOn);
			sqlBuilder.SetWhere(BaseParameterEntity.FieldId, parameterEntity.Id);
			return sqlBuilder.EndUpdate();
		}
		#endregion
	}
}