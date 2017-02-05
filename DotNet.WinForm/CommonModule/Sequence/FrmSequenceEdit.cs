//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmSequenceEdit.cs
    /// 序列管理 - 编辑窗体
    ///		
    /// 修改记录
    /// 
    ///     2008.11.08 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.08</date>
    /// </author> 
    /// </summary>
    public partial class FrmSequenceEdit : BaseForm
    {
        public new string EntityId = string.Empty;

        BaseSequenceEntity SequenceEntity = null;

        public FrmSequenceEdit()
        {
            InitializeComponent();
        }

        public FrmSequenceEdit(string id)
            : this()
        {
            this.EntityId = id;
        }

        #region public override void GetPermission()
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
        }
        #endregion

        #region private void ShowEntity(BaseSequenceEntity sequenceEntity)
        /// <summary>
        /// 显示内容
        /// </summary>
        private void ShowEntity(BaseSequenceEntity sequenceEntity)
        {
            this.txtFullName.Text = sequenceEntity.FullName;
            this.txtPrefix.Text = sequenceEntity.Prefix;
            this.txtSeparator.Text = sequenceEntity.Separator;
            this.txtSequence.Text = sequenceEntity.Sequence.ToString();
            this.txtReduction.Text = sequenceEntity.Reduction.ToString();
            this.txtStep.Text = sequenceEntity.Step.ToString();
            this.txtDescription.Text = sequenceEntity.Description;
            this.chkEnabled.Checked = sequenceEntity.IsVisible == 1 ? true : false;
        }
        #endregion

        #region public override void FormOnLoad()
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.SequenceEntity = DotNetService.Instance.SequenceService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity(this.SequenceEntity);
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
        }
        #endregion

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
            long sequence = 0;
            if (this.txtSequence.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0215), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSequence.Focus();
                return false;
            }
            else
            {
                if (!long.TryParse(this.txtSequence.Text, out sequence))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0030, AppMessage.MSG0215), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSequence.Focus();
                    return false;
                }
            }
            long reduction = 0;
            if (this.txtReduction.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0216), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtReduction.Focus();
                return false;
            }
            else
            {
                if (!long.TryParse(this.txtReduction.Text, out reduction))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0030, AppMessage.MSG0216), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtReduction.Focus();
                    return false;
                }
            }
            if (sequence <= reduction)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0025, AppMessage.MSG0216, AppMessage.MSG0215), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSequence.Focus();
                return false;
            }
            int step = 0;
            if (this.txtStep.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0217), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtStep.Focus();
                return false;
            }
            else
            {
                if (!int.TryParse(this.txtStep.Text, out step))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0030, AppMessage.MSG0217), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSequence.Focus();
                    return false;
                }
            }
            return returnValue;
        }
        #endregion

        #region private BaseSequenceEntity GetEntity(BaseSequenceEntity sequenceEntity)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns>名片类</returns>
        private BaseSequenceEntity GetEntity(BaseSequenceEntity sequenceEntity)
        {
            sequenceEntity.FullName = this.txtFullName.Text;
            sequenceEntity.Prefix = this.txtPrefix.Text;
            sequenceEntity.Separator = this.txtSeparator.Text;
            sequenceEntity.Sequence = int.Parse(this.txtSequence.Text);
            sequenceEntity.Reduction = int.Parse(this.txtReduction.Text);
            sequenceEntity.Step = int.Parse(this.txtStep.Text);
            sequenceEntity.Description = this.txtDescription.Text;
            sequenceEntity.IsVisible = this.chkEnabled.Checked ? 1 : 0;
            return sequenceEntity;
        }
        #endregion

        #region public override SaveEntity()
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetEntity(this.SequenceEntity);
            int rowCount = DotNetService.Instance.SequenceService.Update(UserInfo, this.SequenceEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 编辑成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Changed = true;
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFullName.SelectAll();
                    this.txtFullName.Focus();
                }
                returnValue = false;
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