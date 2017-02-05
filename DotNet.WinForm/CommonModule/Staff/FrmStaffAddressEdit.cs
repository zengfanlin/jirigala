//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmStaffAddressAdmin.cs
    /// 内部通讯录编辑
    ///		
    /// 修改记录
    ///     2011.12.07 版本：1.1 zgl       修改图片保存时的bug
    ///     2007.06.15 版本：1.0 JiRiGaLa  内部通讯录窗体编辑。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.15</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffAddressEdit : BaseForm
    {
        BaseStaffEntity staffEntity = null;
        BaseUserEntity userEntity = null;

        public FrmStaffAddressEdit()
        {
            InitializeComponent();
            // 若是没有
            if (this.EntityId.Length == 0)
            {
                this.EntityId = DotNetService.Instance.StaffService.GetId(UserInfo, BaseStaffEntity.FieldUserId, UserInfo.Id);
            }
        }

        public FrmStaffAddressEdit(string id) : this()
        {
            this.EntityId = id;
        }

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (string.IsNullOrEmpty(this.EntityId))
            {
                return;
            }
            staffEntity = DotNetService.Instance.StaffService.GetEntity(UserInfo, this.EntityId);
            userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, staffEntity.UserId.ToString());
            // 将类转显示到页面
            this.txtRealName.Tag = staffEntity.Id;
            this.txtRealName.Text = staffEntity.RealName;
            this.txtCompany.Tag = staffEntity.CompanyId;
            if (staffEntity.CompanyId != null)
            {
                BaseOrganizeEntity organizeEntity = DotNetService.Instance.OrganizeService.GetEntity(this.UserInfo, staffEntity.CompanyId);
                this.txtCompany.Text = organizeEntity.FullName;
            }
            this.txtDepartment.Tag = staffEntity.DepartmentId;
            if (staffEntity.DepartmentId != null)
            {
                BaseOrganizeEntity organizeEntity = DotNetService.Instance.OrganizeService.GetEntity(this.UserInfo, staffEntity.DepartmentId);
                this.txtDepartment.Text = organizeEntity.FullName;
            }

            this.txtDuty.Tag = staffEntity.DutyId;
            if (staffEntity.DutyId != null)
            {
                BaseItemDetailsEntity itemDetailsEntity = DotNetService.Instance.ItemDetailsService.GetEntity(this.UserInfo, "ItemsDuty", staffEntity.DutyId.ToString());
                this.txtDuty.Text = itemDetailsEntity.ItemName;
            }

            this.txtOfficeTel.Text = staffEntity.OfficePhone;
            this.txtMobile.Text = staffEntity.Mobile;
            this.txtShortNumber.Text = staffEntity.ShortNumber;
            this.txtOICQ.Text = staffEntity.OICQ;
            this.txtEmail.Text = staffEntity.Email;
            this.txtDescription.Text = staffEntity.Description;
            this.txtSignature.Text = userEntity.Signature;
            // 获取图片部分，显示图片部分
            string fileId = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "Staff", staffEntity.Id.ToString(), "StaffPictureId");
            if (!String.IsNullOrEmpty(fileId))
            {
                this.ucPicture.PictureId = fileId;
            }
            this.btnSave.Enabled = false;
            this.txtOfficeTel.Focus();
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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            if (!string.IsNullOrEmpty(this.txtEmail.Text))
            {
                if (ValidateUtil.CheckEmail(this.txtEmail.Text))
                {
                    if (!BaseCheckInput.CheckEmail(this.txtEmail, AppMessage.MSG0234))
                    {
                        return false;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region private BaseStaffEntity GetStaffEntity() 转换员工数据
        /// <summary>
        /// 转换员工数据
        /// </summary>
        private BaseStaffEntity GetStaffEntity()
        {
            staffEntity.RealName = this.txtRealName.Text;
            staffEntity.OfficePhone = this.txtOfficeTel.Text;
            staffEntity.Mobile = this.txtMobile.Text;
            staffEntity.ShortNumber = this.txtShortNumber.Text;
            staffEntity.OICQ = this.txtOICQ.Text;
            staffEntity.Email = this.txtEmail.Text;
            staffEntity.Description = this.txtDescription.Text;
            return staffEntity;
        }
        #endregion

        #region private BaseUserEntity GetUserEntity() 转换用户数据
        /// <summary>
        /// 转换用户数据
        /// </summary>
        private BaseUserEntity GetUserEntity()
        {
            userEntity.Signature = this.txtSignature.Text;
            return userEntity;
        }
        #endregion

        #region public override void SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;

            string statusCode1 = string.Empty;
            string statusMessage1 = string.Empty;

            this.GetStaffEntity();
            this.GetUserEntity();
            
            DotNetService.Instance.StaffService.UpdateAddress(UserInfo, staffEntity, out statusCode, out statusMessage);
            DotNetService.Instance.UserService.UpdateUser(UserInfo, userEntity, out statusCode1, out statusMessage1);

            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                // 更新员工的照片，若新照片被更新时FileId会变空，所以照片更换了，才会执行下面的代码，若照片不更换就不执行这个代码。
                if (string.IsNullOrEmpty(this.ucPicture.PictureId))
                {
                    string pictureContent = string.Empty;
                    pictureContent = this.ucPicture.Upload("StaffPicture", this.EntityId);
                    //判断图片是否为空，如果为空不对图片过行更新
                    if (pictureContent != "")
                    {
                        DotNetService.Instance.ParameterService.SetParameter(UserInfo, "Staff", this.EntityId, "StaffPictureId", pictureContent);
                    }
                }
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
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}