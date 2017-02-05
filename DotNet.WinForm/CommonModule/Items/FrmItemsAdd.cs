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
    /// FrmItemsAdd.cs
    /// 项目详细资料管理-添加项目详细资料窗体
    ///		
    /// 修改记录
    ///     
    ///     2009.04.20 版本：1.0 JiRiGaLa  添加项目详细资料功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.04.20</date>
    /// </author> 
    /// </summary>    
    public partial class FrmItemsAdd : BaseForm
    {
        /// <summary>
        /// 选项实体
        /// </summary>
        public BaseItemsEntity itemsEntity = null;

        public FrmItemsAdd()
        {
            InitializeComponent();
        }

        #region public FrmItemsAdd(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmItemsAdd(string id) : this()
        {
            this.EntityId = id;
        }
        #endregion

        public FrmItemsAdd(BaseItemsEntity entity)
            : this()
        {
            this.itemsEntity = entity;
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (this.itemsEntity != null)
            {
                // 将类转显示到页面
                this.txtCode.Text = itemsEntity.Code;
                this.txtFullName.Text = itemsEntity.FullName;
                this.txtTargetTable.Text = itemsEntity.TargetTable;
                this.txtUseItemCode.Text = itemsEntity.UseItemCode;
                this.txtUseItemName.Text = itemsEntity.UseItemName;
                this.txtUseItemValue.Text = itemsEntity.UseItemValue;
                this.chkIsTree.Checked = itemsEntity.IsTree == 1;
                this.chkEnabled.Checked = itemsEntity.Enabled == 1;                            
                this.txtDescription.Text = itemsEntity.Description;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtCode;
            this.txtCode.Focus();
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
            this.txtCode.Text = this.txtCode.Text.TrimEnd();
            if (this.txtCode.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9977), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCode.Focus();
                return false;
            }
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

        #region private BaseItemsEntity GetEntity()
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseItemsEntity GetEntity()
        {
            BaseItemsEntity itemsEntity = new BaseItemsEntity();
            itemsEntity.ParentId = null;
            itemsEntity.Code = this.txtCode.Text;
            itemsEntity.FullName = this.txtFullName.Text;
            itemsEntity.TargetTable = this.txtTargetTable.Text;
            itemsEntity.IsTree = this.chkIsTree.Checked ? 1 : 0;
            itemsEntity.UseItemCode = this.txtUseItemCode.Text;
            itemsEntity.UseItemName = this.txtUseItemName.Text;
            itemsEntity.UseItemValue = this.txtUseItemValue.Text;
            itemsEntity.Description = this.txtDescription.Text;
            itemsEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            itemsEntity.AllowDelete = 1;
            itemsEntity.AllowEdit = 1;
            itemsEntity.DeletionStateCode = 0;
            return itemsEntity;
        }
        #endregion

        #region private void ClearScreen()
        /// <summary>
        /// 清除屏幕
        /// </summary>
        private void ClearScreen()
        {
            this.txtCode.Text = string.Empty;
            this.txtFullName.Text = string.Empty;
            this.txtTargetTable.Text = "Items";
            this.txtUseItemCode.Text = "编号";
            this.txtUseItemName.Text = "名称";
            this.txtUseItemValue.Text = "值";
            this.txtDescription.Text = string.Empty;
            this.txtCode.Focus();
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
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 转换数据
            BaseItemsEntity itemsEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.ItemsService.Add(UserInfo, itemsEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 创建配套的表
                if (this.chkCreateTable.Checked)
                {
                     DotNetService.Instance.ItemsService.CreateTable(UserInfo, this.txtTargetTable.Text, out statusCode, out statusMessage);
                }
                
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
                else
                {
                    if (statusCode == StatusCode.ErrorNameExist.ToString())
                    {
                        this.txtFullName.SelectAll();
                        this.txtFullName.Focus();
                    }
                }
            }
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
                            this.DialogResult = DialogResult.OK;
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.Changed = true;
                            this.OnDataChanged();
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

        /// <summary>
        /// 添加
        /// </summary>
        public delegate void OnDataChangedEventHandler();

        public event OnDataChangedEventHandler OnDataChanged;

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
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }       
    }
}