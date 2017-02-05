//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace DotNet.WinForm
{    
    using DotNet.Utilities;
    using DotNet.Business;   

    /// <summary>
    /// FrmBusinessCardEdit.cs
    /// 名片管理 - 编辑窗体
    ///		
    /// 修改记录
    /// 
    ///     2008.11.07 版本：1.0 JiRiGaLa 创建。
    ///		2012.04.22 版本：1.0 zwd 修改添加 增加类似
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.19</date>
    /// </author> 
    /// </summary>
    public partial class FrmBusinessCardEdit : BaseForm
    {
        BaseBusinessCardEntity BusinessCardEntity = null;

        public FrmBusinessCardEdit()
        {
            InitializeComponent();
        }

        public FrmBusinessCardEdit(string id) : this()
        {
            this.EntityId = id;
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

        #region private void ShowEntity(BaseBusinessCardEntity businessCardEntity)
        /// <summary>
        /// 显示内容
        /// </summary>
        private void ShowEntity(BaseBusinessCardEntity businessCardEntity)
        {
            this.txtFullName.Text = businessCardEntity.FullName;
            this.txtTitle.Text = businessCardEntity.Title;
            this.ucCompany.SelectedFullName = businessCardEntity.Company;
            this.txtPhone.Text = businessCardEntity.Phone;
            this.txtPostalcode.Text = businessCardEntity.Postalcode;
            this.txtMobile.Text = businessCardEntity.Mobile;
            this.txtAddress.Text = businessCardEntity.Address;
            this.txtEmail.Text = businessCardEntity.Email;
            this.txtOfficePhone.Text = businessCardEntity.OfficePhone;
            this.txtQQ.Text = businessCardEntity.QQ;
            this.txtFax.Text = businessCardEntity.Fax;
            this.txtWeb.Text = businessCardEntity.Web;
            this.txtBankName.Text = businessCardEntity.BankName;
            this.txtBankAccount.Text = businessCardEntity.BankAccount;
            this.txtTaxAccount.Text = businessCardEntity.TaxAccount;
            this.chkPersonal.Checked = businessCardEntity.Personal;
            this.txtDescription.Text = businessCardEntity.Description;
        }
        #endregion

        #region public override void FormOnLoad()
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            BusinessCardService businessCardService = new BusinessCardService();
            this.BusinessCardEntity = businessCardService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity(this.BusinessCardEntity);
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
        }
        #endregion

        private void FrmBusinessCardEdit_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 加载窗体
                    this.FormOnLoad();
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
                // this.rpvBusinessCard.RefreshReport();
            }
        }

        #region private BaseBusinessCardEntity GetEntity()
        /// <summary>
        /// 获取输入的信息
        /// </summary>
        /// <returns>名片类</returns>
        private BaseBusinessCardEntity GetEntity()
        {
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity();
            // 这里提高主键产生速度
            businessCardEntity.Id = System.Guid.NewGuid().ToString(); //产生一个新的ID
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

        #region private bool AddEntity() 新建
        /// <summary>
        /// 新建
        /// </summary>
        /// <returns>新建成功</returns>
        private bool AddEntity()
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

        private void btnLikeAdd_Click(object sender, EventArgs e)
        {
            BaseBusinessCardEntity entity = GetEntity();
            entity.Id = null;
            FrmBusinessCardAdd frmBusinessCardAdd = new FrmBusinessCardAdd(entity);
            frmBusinessCardAdd.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // List<BaseBusinessCardEntity> businessCards = new List<BaseBusinessCardEntity>();
            // businessCards.Add(this.BusinessCardEntity);
            // this.rpvBusinessCard.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            // this.rpvBusinessCard.LocalReport.ReportEmbeddedResource = "BusinessCard.rdlc";
            // this.rpvBusinessCard.LocalReport.ReportPath = BaseSystemInfo.StartupPath + "\\BusinessCard.rdlc";

            // ReportParameter rpFullName = new ReportParameter("FullName", this.txtFullName.Text);
            // this.rpvBusinessCard.LocalReport.SetParameters(new ReportParameter[] { rpFullName });
            
            // this.rpvBusinessCard.LocalReport.DataSources.Clear();
            // this.rpvBusinessCard.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("BusinessCard", businessCards));
            // this.rpvBusinessCard.Visible = true;
            // ReportViewer.ExportContentDisposition            
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

        #region private BaseBusinessCardEntity GetEntity(BaseBusinessCardEntity businessCardEntity)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns>名片类</returns>
        private BaseBusinessCardEntity GetEntity(BaseBusinessCardEntity businessCardEntity)
        {
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

        #region public override bool SaveEntity()
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetEntity(this.BusinessCardEntity);
            BusinessCardService businessCardService = new BusinessCardService();
            int rowCount = businessCardService.UpdateEntity(UserInfo, this.BusinessCardEntity, out statusCode, out statusMessage);
            returnValue = rowCount > 0;
            this.Changed = returnValue;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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
                        this.DialogResult = DialogResult.OK;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }        
    }
}