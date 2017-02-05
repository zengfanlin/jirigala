//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Utilities;
    using DotNet.Business;
    

    /// <summary>
    /// FrmStaffChangeDepartment.cs
    /// 员工管理-部门变更
    ///		
    /// 修改记录     
    /// 
    ///     2008.05.15 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.15</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffChangeDepartment : BaseForm
    {
        private DataTable DTStaff = new DataTable(BaseStaffEntity.TableName);    // 员工 DataSet
        
        BaseStaffEntity staffEntity = new BaseStaffEntity();
        BaseUserEntity userEntity = new BaseUserEntity();

        public FrmStaffChangeDepartment()
        {
            InitializeComponent();
        }

        #region public FrmStaffChangeDepartment(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmStaffChangeDepartment(string id) : this()
        {
            this.EntityId = id;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 从数据权限获得类
            // this.userEntity.GetFrom(this.DSStaff.Tables[BaseUserEntity.TableName]);
            this.staffEntity.GetSingle(this.DTStaff);

            this.txtRealName.Tag = this.staffEntity.Id;
            this.txtRealName.Text = this.staffEntity.RealName;
            this.txtCompany.Tag = this.staffEntity.CompanyId;
            // this.txtCompany.Text = this.staffEntity.CompanyName;
            this.txtDepartment.Tag = this.staffEntity.DepartmentId;
            // this.txtDepartment.Text = this.staffEntity.DepartmentName;
            this.txtDuty.Tag = this.staffEntity.DutyId;
            // this.txtDuty.Text = this.staffEntity.DutyName;
            this.txtDescription.Text = this.staffEntity.Description;

            this.ucCompany.SelectedId = this.staffEntity.CompanyId;
            // this.ucCompany.SelectedFullName = this.staffEntity.CompanyName;
            this.ucDepartment.SelectedId = this.staffEntity.DepartmentId;
            // this.ucDepartment.SelectedFullName = this.staffEntity.DepartmentName;
            
            // 获取图片部分，显示图片部分
            string fileId = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", this.staffEntity.Id.ToString(), "UserPictureId");
            if (!String.IsNullOrEmpty(fileId))
            {
                this.ucPicture.PictureId = fileId;
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucCompany.AllowNull = false;
            this.ucDepartment.AllowNull = false;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 显示内容
            this.ShowEntity();
        }
        #endregion

        private void SetCompany(string CompanyId)
        {
            // 设置部门与公司的联动功能
            this.ucDepartment.OpenId = CompanyId;
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            if (String.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9900), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucCompany.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9901), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucDepartment.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region public override void SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // DotNetService.Instance.StaffService.UpdateStaff(UserInfo, this.EntityId, this.staffEntity.UserName, this.ucCompany.SelectedId, this.ucDepartment.SelectedId, this.staffEntity.DutyId, this.staffEntity.RealName, this.staffEntity.Code, this.userEntity.Role, this.staffEntity.Enabled, this.staffEntity.Enabled, this.txtDescription.Text, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                // 添加员工的照片
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", this.EntityId, "UserPictureId", this.ucPicture.Upload("StaffPicture", this.EntityId));
                // 发送提示信息
                DotNetService.Instance.MessageService.Send(UserInfo, this.EntityId, UserInfo.RealName + " 提示您：" + this.txtRealName.Text + "的公司被设置为：" + this.ucCompany.SelectedFullName + "　部门设置为：" + this.ucDepartment.SelectedFullName);
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        // 关闭窗口
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
    }
}