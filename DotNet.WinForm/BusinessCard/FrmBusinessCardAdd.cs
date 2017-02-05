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
    /// FrmBusinessCardAdd.cs
    /// 名片管理 - 添加窗体
    ///		
    /// 修改记录
    /// 
    ///     2008.11.07 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.07</date>
    /// </author> 
    /// </summary>
    public partial class FrmBusinessCardAdd : BaseForm
    {
        /// <summary>
        /// 名片实体
        /// </summary>
        public BaseBusinessCardEntity businessCardEntity = null;

        public FrmBusinessCardAdd()
        {
            InitializeComponent();
        }

        public FrmBusinessCardAdd(bool personal)
        {
            InitializeComponent();
            this.chkPersonal.Checked = personal;
        }

        #region public override void GetPermission()
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.ucCompany.CanEdit = true;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (this.businessCardEntity != null)
            {
                this.txtFullName.Text = businessCardEntity.FullName;
                this.txtTitle.Text = businessCardEntity.Title;
                this.txtPhone.Text = businessCardEntity.Phone;
                this.txtQQ.Text = businessCardEntity.QQ;
                this.ucCompany.SelectedFullName = businessCardEntity.Company;
                this.txtAddress.Text = businessCardEntity.Address;
                this.txtPostalcode.Text = businessCardEntity.Postalcode;
                this.txtOfficePhone.Text = businessCardEntity.OfficePhone;
                this.txtFax.Text = businessCardEntity.Fax;
                this.txtMobile.Text = businessCardEntity.Mobile;
                this.txtWeb.Text = businessCardEntity.Web;
                this.txtEmail.Text = businessCardEntity.Email;
                this.txtBankName.Text = businessCardEntity.BankName;
                this.txtBankAccount.Text = businessCardEntity.BankAccount;
                this.txtTaxAccount.Text = businessCardEntity.TaxAccount;
                this.chkPersonal.Checked = businessCardEntity.Personal;
                this.txtDescription.Text = businessCardEntity.Description;
            }
        }
        #endregion

        #region public override void FormOnLoad()
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
        }
        #endregion

        public FrmBusinessCardAdd(BaseBusinessCardEntity entity)
            : this()
        {
            this.businessCardEntity = entity;
        }

        #region public override bool CheckInput()
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.txtFullName.Text = this.txtFullName.Text.TrimEnd();
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseBusinessCardEntity GetEntity()
        /// <summary>
        /// 获取输入的信息
        /// </summary>
        /// <returns>名片类</returns>
        private BaseBusinessCardEntity GetEntity()
        {
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity();
            // 这里提高主键产生速度
            businessCardEntity.Id = System.Guid.NewGuid().ToString();
            businessCardEntity.FullName = this.txtFullName.Text;
            businessCardEntity.Title = this.txtTitle.Text;
            businessCardEntity.Company = this.ucCompany.SelectedFullName;
            businessCardEntity.Phone = this.txtPhone.Text;
            businessCardEntity.Postalcode = this.txtPostalcode.Text;
            businessCardEntity.Mobile = this.txtMobile.Text;
            businessCardEntity.Address = this.txtAddress.Text;
            businessCardEntity.Email = this.txtEmail.Text;
            businessCardEntity.OfficePhone = this.txtOfficePhone.Text;
            businessCardEntity.QQ = this.txtQQ.Text;
            businessCardEntity.Fax = this.txtFax.Text;
            businessCardEntity.Web = this.txtWeb.Text;
            businessCardEntity.BankName = this.txtBankName.Text;
            businessCardEntity.BankAccount = this.txtBankAccount.Text;
            businessCardEntity.TaxAccount = this.txtTaxAccount.Text;
            businessCardEntity.Personal = this.chkPersonal.Checked;
            businessCardEntity.Description = this.txtDescription.Text;
            return businessCardEntity;
        }
        #endregion

        #region private void ClearScreen()
        /// <summary>
        /// 清除屏幕
        /// </summary>
        private void ClearScreen()
        {
            this.txtFullName.Text = string.Empty;
            this.txtTitle.Text = string.Empty;
            this.ucCompany.SelectedFullName = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.txtPostalcode.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtOfficePhone.Text = string.Empty;
            this.txtQQ.Text = string.Empty;
            this.txtFax.Text = string.Empty;
            this.txtWeb.Text = string.Empty;
            this.txtBankName.Text = string.Empty;
            this.txtBankAccount.Text = string.Empty;
            this.txtTaxAccount.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtFullName.Focus();
        }
        #endregion

        #region public override void SaveEntity()
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = true;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            BusinessCardService businessCardService = new BusinessCardService();
            this.EntityId = businessCardService.AddEntity(UserInfo, this.GetEntity(), out statusCode, out statusMessage);
            returnValue = !String.IsNullOrEmpty(EntityId);
            this.Changed = returnValue;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region private void SaveEntity(bool close)
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SaveEntity(bool close)
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
                        if (close)
                        {
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearScreen();
                        }
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
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.SaveEntity(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveEntity(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}