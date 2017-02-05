//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <remarks>
    ///	UserReportManager
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
    public partial class UserReportManager : BaseUserBillManager, IWorkFlowManager
    {
        public UserReportManager()
        {
        }

        public UserReportManager(BaseUserInfo userInfo)
        {
            this.UserInfo = userInfo;
        }

        public new IDbHelper GetDbHelper()
        {
            return this.DbHelper;
        }

        public new BaseUserInfo GetUserInfo()
        {
            return this.UserInfo;
        }

        public new void SetUserInfo(BaseUserInfo userInfo)
        {
            this.UserInfo = userInfo;
        }

        /// <summary>
        /// (点通过时)当审核通过时
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流</param>
        /// <returns>成功失败</returns>
        public override bool OnAutoAuditPass(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            string objectId = workFlowCurrentEntity.ObjectId;
            if (!string.IsNullOrEmpty(objectId))
            {
                // 这里写自己的方法(审核 过程中的回调),通过审核时 
                IDbHelper dbHelper = new DotNet.Utilities.SqlHelper(BaseSystemInfo.BusinessDbConnection);
                dbHelper.Open();
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                sqlBuilder.BeginUpdate("WL物品申购");
                sqlBuilder.SetDBNow("审核日期");
                sqlBuilder.SetValue("审核员", BaseSystemInfo.UserInfo.Code);
                sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditPass.ToString());
                sqlBuilder.SetWhere("申请单号", objectId);
                sqlBuilder.EndUpdate();
                dbHelper.Close();
            }
            return true;
        }


        /// <summary>
        /// (点退回时)当审核退回时
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流</param>
        /// <returns>成功失败</returns>
        public override bool OnAuditReject(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            string objectId = workFlowCurrentEntity.ObjectId;
            if (!string.IsNullOrEmpty(objectId))
            {
                // 这里写自己的方法(审核 过程中的回调),退回审核时
                IDbHelper dbHelper = new DotNet.Utilities.SqlHelper(BaseSystemInfo.BusinessDbConnection);
                dbHelper.Open();
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                //sqlBuilder.BeginUpdate("WL物品申购");
                //sqlBuilder.SetDBNow("审核日期");
                //sqlBuilder.SetValue("审核员", BaseSystemInfo.UserInfo.Code);
                //sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditReject.ToString());
                //sqlBuilder.SetWhere("申请单号", objectId);
                //sqlBuilder.EndUpdate();
                switch (workFlowCurrentEntity.CategoryCode)
                {
                    case "PuTongCaiGouDan":
                    case "GuoNeiCaiGouHeTong":
                    case "PutongCaiGouDanDGM":
                    case "PutongCaiGouDanManager":
                        sqlBuilder.BeginUpdate("WL物品申购");
                        sqlBuilder.SetDBNow("审核日期");
                        sqlBuilder.SetValue("审核员", BaseSystemInfo.UserInfo.Code);
                        sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditReject.ToString());
                        sqlBuilder.SetWhere("申请单号", objectId);
                        sqlBuilder.EndUpdate();
                        break;
                    case "YuanFuCaiLiaoShenQingDan":
                        sqlBuilder.BeginUpdate("WL部门物品申购");
                        sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditReject.ToString());
                        sqlBuilder.SetWhere("申购单号", objectId);
                        sqlBuilder.EndUpdate();
                        break;
                    case "MoJuCaiGouHeTongP":
                    case "MoJuCaiGouHeTongGM":
                        sqlBuilder.BeginUpdate("GCMJ模具申请");
                        sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditReject.ToString());
                        sqlBuilder.SetWhere("申请单号", objectId);
                        sqlBuilder.EndUpdate();
                        break;
                }
                dbHelper.Close();
            }
            return true;
        }

        /// <summary>
        /// 废弃单据
        /// （废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流</param>
        /// <returns>影响行数</returns>
        public override bool OnAuditQuash(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            // 审核通过后，需要把有效状态修改过来
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            string objectId = workFlowCurrentManager.GetEntity(workFlowCurrentEntity.Id).ObjectId;
            if (!string.IsNullOrEmpty(objectId))
            {
                // 这里写自己的方法(审核 过程中的回调),废弃审核时
                IDbHelper dbHelper = new DotNet.Utilities.SqlHelper(BaseSystemInfo.BusinessDbConnection);
                dbHelper.Open();
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                switch (workFlowCurrentEntity.CategoryCode)
                {
                    case "PuTongCaiGouDan":
                    case "GuoNeiCaiGouHeTong":
                    case "PutongCaiGouDanDGM":
                    case "PutongCaiGouDanManager":
                    sqlBuilder.BeginUpdate("WL物品申购");
                    sqlBuilder.SetDBNow("审核日期");
                    sqlBuilder.SetValue("审核员", BaseSystemInfo.UserInfo.Code);
                    sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditQuash.ToString());
                    sqlBuilder.SetWhere("申请单号", objectId);
                    sqlBuilder.EndUpdate();
                    break;
                    case "YuanFuCaiLiaoShenQingDan":
                    sqlBuilder.BeginUpdate("WL部门物品申购");
                    sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditQuash.ToString());
                    sqlBuilder.SetWhere("申购单号", objectId);
                    sqlBuilder.EndUpdate();
                    break;
                    case "MoJuCaiGouHeTongP":
                    case "MoJuCaiGouHeTongGM":
                    sqlBuilder.BeginUpdate("GCMJ模具申请");
                    sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditQuash.ToString());
                    sqlBuilder.SetWhere("申请单号", objectId);
                    sqlBuilder.EndUpdate();
                    break;
                }
                dbHelper.Close();
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
        public override bool OnAuditComplete(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            // 审核通过后，需要把有效状态修改过来
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            //string objectId = workFlowCurrentManager.GetEntity(workFlowCurrentEntity.Id).ObjectId;
            string objectId = workFlowCurrentEntity.ObjectId;
            if (!string.IsNullOrEmpty(objectId))
            {
                // 这里写自己的方法(审核 过程中的回调),完成审核时
                IDbHelper dbHelper = new DotNet.Utilities.SqlHelper(BaseSystemInfo.BusinessDbConnection);
                dbHelper.Open();
                SQLBuilder sqlBuilder = new SQLBuilder(dbHelper);
                switch (workFlowCurrentEntity.CategoryCode)
                {
                    case "PuTongCaiGouDan":
                    case "GuoNeiCaiGouHeTong":
                    case "PutongCaiGouDanDGM":
                    case "PutongCaiGouDanManager":
                        sqlBuilder.BeginUpdate("WL物品申购");
                        sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditComplete.ToString());
                        sqlBuilder.SetValue("审核", 1);
                        sqlBuilder.SetDBNow("审核日期");
                        sqlBuilder.SetValue("审核员", BaseSystemInfo.UserInfo.Code);
                        sqlBuilder.SetWhere("申请单号", objectId);
                        sqlBuilder.EndUpdate();
                        break;
                    case "YuanFuCaiLiaoShenQingDan":
                        sqlBuilder.BeginUpdate("WL部门物品申购");
                        sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditComplete.ToString());
                        sqlBuilder.SetValue("审核", 1);
                        sqlBuilder.SetValue("总审核", 1);
                        sqlBuilder.SetDBNow("审核日期");
                        sqlBuilder.SetDBNow("总审核日期");
                        sqlBuilder.SetValue("审核员", BaseSystemInfo.UserInfo.Code);
                        sqlBuilder.SetWhere("申购单号", objectId);
                        sqlBuilder.EndUpdate();
                        break;
                    case "MoJuCaiGouHeTongP":
                    case "MoJuCaiGouHeTongGM":
                        sqlBuilder.BeginUpdate("GCMJ模具申请");
                        sqlBuilder.SetValue("AuditStatus", AuditStatus.AuditComplete.ToString());
                        sqlBuilder.SetValue("审核", 1);
                        sqlBuilder.SetWhere("申请单号", objectId);
                        sqlBuilder.EndUpdate();
                        break;
                }
                dbHelper.Close();
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
        public override bool OnReset(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            // 若还需要有其他处理，就这后面继续处理
            return true;
        }
    }
}