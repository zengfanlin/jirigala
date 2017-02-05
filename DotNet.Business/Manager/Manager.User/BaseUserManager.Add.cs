//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.17 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.17</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        #region public void BeforeAdd(BaseUserEntity userEntity, out string statusCode) 用户添加之前执行的方法
        /// <summary>
        /// 用户添加之前执行的方法
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        public void BeforeAdd(BaseUserEntity userEntity, out string statusCode)
        {
            // 检测成功，可以添加用户
            statusCode = StatusCode.OK.ToString();
            if (this.Exists(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userEntity.UserName)
                , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0)))
            {
                // 用户名已重复
                statusCode = StatusCode.ErrorUserExist.ToString();
            }
            else
            {
                // 检查编号是否重复
                if (!string.IsNullOrEmpty(userEntity.Code) 
                    && this.Exists(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, userEntity.Code)
                    , new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0)))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }

                if (userEntity.IsStaff == 1)
                {
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldUserName, userEntity.UserName));
                    parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldDeletionStateCode, 0));
                    if (DbLogic.Exists(DbHelper, BaseStaffEntity.TableName, parameters))
                    {
                        // 编号已重复
                        statusCode = StatusCode.ErrorNameExist.ToString();
                    }
                    if (!string.IsNullOrEmpty(userEntity.Code))
                    {
                        parameters = new List<KeyValuePair<string, object>>();
                        parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldCode, userEntity.Code));
                        parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldDeletionStateCode, 0));
                        if (DbLogic.Exists(DbHelper, BaseStaffEntity.TableName, parameters))
                        {
                            // 编号已重复
                            statusCode = StatusCode.ErrorCodeExist.ToString();
                        }
                    }
                }
            }
        }
        #endregion
        
        #region public string Add(BaseUserEntity userEntity, out string statusCode) 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>主键</returns>
        public string Add(BaseUserEntity userEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            this.BeforeAdd(userEntity, out statusCode);
            if (statusCode == StatusCode.OK.ToString())
            {
                returnValue = this.AddEntity(userEntity);
                this.AfterAdd(userEntity, out statusCode);
            }
            return returnValue;
        }
        #endregion

        #region public void AfterAdd(BaseUserEntity userEntity, out string statusCode) 用户添加后执行的方法
        /// <summary>
        /// 用户添加之后执行的方法
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        public void AfterAdd(BaseUserEntity userEntity, out string statusCode)
        {
            // 运行成功
            statusCode = StatusCode.OKAdd.ToString();
        }
        #endregion
    }
}