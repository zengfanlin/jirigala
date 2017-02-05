//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <remarks>
    ///	BaseUserBillManager
    ///	新闻类单据
    ///	
    ///	修改记录
    /// 
    ///     2011.09.06 版本：1.0 JiRiGaLa    工作流部分独立化。
    ///		
    /// 版本：2.5
    /// </remarks>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.10.04</date>
    /// </author> 
    /// </remarks>
    public partial class BaseUserBillManager : BaseNewsManager, IWorkFlowManager
    {
        public IDbHelper GetDbHelper()
        {
            return this.DbHelper;
        }

        public BaseUserInfo GetUserInfo()
        {
            return this.UserInfo;
        }

        public void SetUserInfo(BaseUserInfo userInfo)
        {
            this.UserInfo = userInfo;
        }

        /// <summary>
        /// 获取待审核单据的网址
        /// </summary>
        /// <param name="userId">发送给哪个用户</param>
        /// <param name="currentId">工作流当前主键</param>
        /// <returns>获取网址</returns>
        public virtual string GetUrl(string currentId)
        {
            // BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            // string openId = userManager.GetEntity(userId).OpenId;
            string webHostUrl = BaseSystemInfo.WebHostUrl;
            if (string.IsNullOrEmpty(webHostUrl))
            {
                webHostUrl = "WebHostUrl";
            }

            //return webHostUrl + "Work.aspx?ModuleCode=WorkFlow&Left=LeftMenu.aspx&Page=Modules/Common/WorkFlow/AuditBillDetails.aspx?"
            //    + "Id=" + currentId
            //    + "&OpenId={OpenId}";

            // 直接导向到待审核页面
            return "{" + webHostUrl + "}" + "Work.aspx?OpenId={OpenId}&ModuleCode=WorkFlow&Left=LeftMenu.aspx";
        }

        /// <summary>
        /// 发送即时通讯提醒
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审核流实体信息</param>
        /// <param name="auditStatus">审核状态</param>
        /// <param name="auditIdea">审核意见</param>
        /// <param name="userIds">发送给用户主键</param>
        /// <param name="roleIds">发送给角色主键</param>
        /// <returns>影响行数</returns>
        public virtual int SendRemindMessage(BaseWorkFlowCurrentEntity workFlowCurrentEntity, AuditStatus auditStatus, string[] userIds, string organizeId, string roleId)
        {
            // string currentId, string objectId, string objectFullName
            int returnValue = 0;
            // 不用给自己发消息了，消息多了也烦恼
            userIds = StringUtil.Remove(userIds, this.UserInfo.Id);
            // BaseUserEntity userEntity = userManager.GetEntity(userId);
            // 发送请求审核的信息
            BaseMessageEntity messageEntity = new BaseMessageEntity();
            messageEntity.Id = BaseBusinessLogic.NewGuid();
            // 这里是回调的类，用反射要回调的
            messageEntity.FunctionCode = MessageFunction.Remind.ToString();
            // messageEntity.FunctionCode = this.GetType().ToString();
            messageEntity.ObjectId = workFlowCurrentEntity.ObjectId;
            // 这里是网页上的显示地址
            // messageEntity.Title = this.GetUrl(id);
            string auditIdea = string.Empty;
            if (!string.IsNullOrEmpty(workFlowCurrentEntity.AuditIdea))
            {
                auditIdea = " 批示: " + workFlowCurrentEntity.AuditIdea;
            }
            // messageEntity.Contents = userEntity.DepartmentName + " " + userEntity.RealName
            messageEntity.Contents
                = workFlowCurrentEntity.CreateBy + " 发出审批申请： " + "<a title='点击这里，直接查看单据' target='_blank' href='" + this.GetUrl(workFlowCurrentEntity.Id) + "'>" + workFlowCurrentEntity.ObjectFullName + "</a> "
                + Environment.NewLine
                + this.UserInfo.RealName + " " + BaseBusinessLogic.GetAuditStatus(auditStatus) + " "
                + Environment.NewLine
                + auditIdea;

            messageEntity.Contents = "有单据" + BaseBusinessLogic.GetAuditStatus(auditStatus);
            messageEntity.IsNew = 1;
            messageEntity.ReadCount = 0;
            messageEntity.Enabled = 1;
            messageEntity.DeletionStateCode = 0;
            BaseMessageManager messageManager = new BaseMessageManager(this.UserInfo);
            returnValue = messageManager.BatchSend(userIds, organizeId, roleId, messageEntity, false);
            return returnValue;
        }

        public virtual bool BeforeAutoStatr(string id)
        {
            // 3：按年生成单据编号。
            string sequenceCode = string.Empty;
            // 1：状态为空的、草稿状态、被退回状态的，才可以启动工作流
            string auditStatus = this.GetProperty(id, BaseBusinessLogic.FieldAuditStatus);
            if (string.IsNullOrEmpty(auditStatus)
                    || auditStatus.Equals(AuditStatus.Draft.ToString()))
            {
                /*
                if (!string.IsNullOrEmpty(entity.Source))
                {
                    if (newsEntity.Source.Equals("html"))
                    {
                        if (newsEntity.Contents.IndexOf("#DayCode#") > 0)
                        {
                            sequenceName = DateTime.Now.ToString("yyyyMMdd") + "_" + newsEntity.CategoryCode;
                            sequenceCode = DateTime.Now.ToString("yyyyMMdd") + "_" + sequenceManager.GetSequence(sequenceName, 1, 3, true);
                            entity.Contents = newsEntity.Contents.Replace("#DayCode#", sequenceCode);
                            entity.Code = sequenceCode;
                        }
                    }
                }
                */
                string sequenceName = this.CurrentTableName;
                BaseSequenceManager sequenceManager = new BaseSequenceManager(this.DbHelper, this.UserInfo);
                // 没系统编号，自己生成一个编号
                if (string.IsNullOrEmpty(sequenceCode))
                {
                    sequenceCode = sequenceManager.GetSequence(sequenceName, 1, 6, true);
                    // newsEntity.Code = sequenceCode;
                }
            }

            // 4：修改单据表的状态,这里是成功了,才可以修改状态
            // newsEntity.AuditStatus = AuditStatus.StartAudit.ToString();
            // newsEntity.AuditStatusName = AuditStatus.StartAudit.ToDescription();
            // 5：这里需要重新走流程后才可以生效
            // newsEntity.Enabled = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldEnabled, 0));
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 0));
            parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldAuditStatus, AuditStatus.StartAudit.ToString()));
            if (!string.IsNullOrEmpty(sequenceCode))
            {
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, sequenceCode));
            }
            this.SetProperty(new KeyValuePair<string, object>(this.PrimaryKey, id), parameters);
            return true;
        }


        /// <summary>
        /// 当工作流开始启动之后需要做的工作
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public virtual int AfterAutoStatr(string id)
        {
            return 0;
        }

        /// <summary>
        /// 重置单据
        /// （发出单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public virtual int Reset(string id, string auditIdea)
        {
            int returnValeu = 0;
            // 只有还在审核中的才可以废弃
            string auditStatus = this.GetProperty(id, BaseBusinessLogic.FieldAuditStatus);
            if (!string.IsNullOrEmpty(auditStatus))
            {
                if (!(auditStatus.Equals(AuditStatus.StartAudit.ToString())
                    || auditStatus.Equals(AuditStatus.WaitForAudit.ToString())))
                {
                    return returnValeu;
                }
            }

            // 若能撤销流程中的单据，才可以撤销本地的单据
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(id);
            // 工作流里会进行撤销的工作
            return workFlowCurrentManager.Reset(workFlowCurrentEntity);
        }

        /// <summary>
        /// 废弃单据
        /// （发出单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public int AuditQuash(string id, string auditIdea)
        {
            int returnValeu = 0;
            // 只有还在审核中的才可以废弃
            string auditStatus = this.GetProperty(id, BaseBusinessLogic.FieldAuditStatus);
            if (!string.IsNullOrEmpty(auditStatus))
            {
                if (!(auditStatus.Equals(AuditStatus.StartAudit.ToString())
                    || auditStatus.Equals(AuditStatus.WaitForAudit.ToString())))
                {
                    return returnValeu;
                }
            }

            // 若能撤销流程中的单据，才可以撤销本地的单据
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            // 工作流里会进行撤销的工作
            return workFlowCurrentManager.AuditQuash(this, this.CurrentTableName, id, auditIdea);
        }

        /// <summary>
        /// 批量废弃单据
        /// （批量废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public int AuditQuash(string[] ids, string auditIdea)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += this.AuditQuash(ids[i], auditIdea);
            }
            return returnValue;
        }

        /// <summary>
        /// 批量重置单据
        /// （批量废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public virtual int Reset(string[] ids, string auditIdea)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += this.Reset(ids[i], auditIdea);
            }
            return returnValue;
        }

        /// <summary>
        /// (点通过时)当审核通过时
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流</param>
        /// <returns>成功失败</returns>
        public virtual bool OnAutoAuditPass(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            if (!string.IsNullOrEmpty(workFlowCurrentEntity.ObjectId))
            {
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                sqlBuilder.BeginUpdate(this.CurrentTableName);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldAuditStatus, AuditStatus.AuditPass.ToString());
                sqlBuilder.SetDBNow(BaseBusinessLogic.FieldModifiedOn);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedBy, this.UserInfo.RealName);
                sqlBuilder.SetWhere(BaseBusinessLogic.FieldId, workFlowCurrentEntity.ObjectId);
                sqlBuilder.EndUpdate();
            }
            return true;
        }

        /// <summary>
        /// (点退回时)当审核退回时
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流</param>
        /// <returns>成功失败</returns>
        public virtual bool OnAuditReject(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            if (!string.IsNullOrEmpty(workFlowCurrentEntity.ObjectId))
            {
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                sqlBuilder.BeginUpdate(this.CurrentTableName);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldAuditStatus, AuditStatus.AuditReject.ToString());
                sqlBuilder.SetValue(BaseBusinessLogic.FieldEnabled, 0);
                sqlBuilder.SetDBNow(BaseBusinessLogic.FieldModifiedOn);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedBy, this.UserInfo.RealName);
                sqlBuilder.SetWhere(BaseBusinessLogic.FieldId, workFlowCurrentEntity.ObjectId);
                sqlBuilder.EndUpdate();
            }
            return true;
        }

        /// <summary>
        /// 废弃单据
        /// （废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流</param>
        /// <returns>影响行数</returns>
        public virtual bool OnAuditQuash(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            // 审核通过后，需要把有效状态修改过来
            if (!string.IsNullOrEmpty(workFlowCurrentEntity.ObjectId))
            {
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                sqlBuilder.BeginUpdate(this.CurrentTableName);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldAuditStatus, AuditStatus.AuditQuash.ToString());
                sqlBuilder.SetValue(BaseBusinessLogic.FieldDeletionStateCode, 1);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldEnabled, 0);
                sqlBuilder.SetDBNow(BaseBusinessLogic.FieldModifiedOn);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedBy, this.UserInfo.RealName);
                sqlBuilder.SetWhere(BaseBusinessLogic.FieldId, workFlowCurrentEntity.ObjectId);
                sqlBuilder.EndUpdate();
            }
            // 若还需要有其他处理，就这后面继续处理
            return true;
        }


        /// <summary>
        /// 流程完成时
        /// 结束审核时，需要回调写入到表里，调用相应的事件
        /// 若成功可以执行完成的处理
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流程</param>
        /// <returns>成功失败</returns>
        public virtual bool OnAuditComplete(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            // 审核通过后，需要把有效状态修改过来
            if (!string.IsNullOrEmpty(workFlowCurrentEntity.ObjectId))
            {
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                sqlBuilder.BeginUpdate(this.CurrentTableName);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldAuditStatus, AuditStatus.AuditComplete.ToString());
                sqlBuilder.SetValue(BaseBusinessLogic.FieldEnabled, 1);
                sqlBuilder.SetDBNow(BaseBusinessLogic.FieldModifiedOn);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedBy, this.UserInfo.RealName);
                sqlBuilder.SetWhere(BaseBusinessLogic.FieldId, workFlowCurrentEntity.ObjectId);
                sqlBuilder.EndUpdate();
            }
            // 若还需要有其他处理，就这后面继续处理
            return true;
        }


        /// <summary>
        /// 重置单据
        /// （单据发生错误时）紧急情况下实用
        /// </summary>
        /// <param name="currentId">审批流当前主键</param>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public virtual bool OnReset(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            // 审核通过后，需要把有效状态修改过来
            if (!string.IsNullOrEmpty(workFlowCurrentEntity.ObjectId))
            {
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                sqlBuilder.BeginUpdate(this.CurrentTableName);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldAuditStatus, AuditStatus.Draft.ToString());
                sqlBuilder.SetValue(BaseBusinessLogic.FieldEnabled, 1);
                sqlBuilder.SetDBNow(BaseBusinessLogic.FieldModifiedOn);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedUserId, this.UserInfo.Id);
                sqlBuilder.SetValue(BaseBusinessLogic.FieldModifiedBy, this.UserInfo.RealName);
                sqlBuilder.SetWhere(BaseBusinessLogic.FieldId, workFlowCurrentEntity.ObjectId);
                sqlBuilder.EndUpdate();
            }
            // 若还需要有其他处理，就这后面继续处理
            return true;
        }
    }
}