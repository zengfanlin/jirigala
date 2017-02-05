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
    /// FormRightAdd.cs
    /// 项目详细资料管理-添加项目详细资料窗体
    ///		
    /// 修改记录
    /// 
    ///     
    ///     2007.05.11 版本：1.0 JiRiGaLa  添加项目详细资料功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.15</date>
    /// </author> 
    /// </summary>    
    public partial class FrmItemDetailsAdd : BaseForm
    {
        /// <summary>
        /// 基础实体
        /// </summary>
        public BaseItemDetailsEntity itemDetailsEntity = null;

        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        /// <summary>
        /// 基础主键父节点
        /// </summary>
        public string ParentId = null;

        public FrmItemDetailsAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加的用户
        /// </summary>
        /// <returns>是否成功</returns>
        public delegate bool OnAddedEventHandler();

        public event OnAddedEventHandler OnAdded;

        #region public FrmItemDetailsAdd(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmItemDetailsAdd(string id) : this()
        {
            this.EntityId = id;
        }
        #endregion

        public FrmItemDetailsAdd(BaseItemDetailsEntity entity)
            : this()
        {
            this.itemDetailsEntity = entity;
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
            if (this.itemDetailsEntity != null)
            {               
                this.txtCode.Text = itemDetailsEntity.ItemCode;
                this.txtFullName.Text = itemDetailsEntity.ItemName;
                this.txtItemValue.Text = itemDetailsEntity.ItemValue;
                this.chkEnabled.Checked = itemDetailsEntity.Enabled == 1;
                this.txtDescription.Text = itemDetailsEntity.Description;
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

        #region private BaseItemDetailsEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseItemDetailsEntity GetEntity()
        {
            BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity();
            if (string.IsNullOrEmpty(this.ParentId))
            {
                itemDetailsEntity.ParentId = null;
            }
            else
            {
                itemDetailsEntity.ParentId = int.Parse(this.ParentId);
            }
            itemDetailsEntity.ItemCode = this.txtCode.Text;
            itemDetailsEntity.ItemName = this.txtFullName.Text;
            itemDetailsEntity.ItemValue = this.txtItemValue.Text;
            itemDetailsEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            itemDetailsEntity.Description = this.txtDescription.Text;
            itemDetailsEntity.AllowDelete = 1;
            itemDetailsEntity.AllowEdit = 1;
            return itemDetailsEntity;
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
            this.txtItemValue.Text = string.Empty;
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
            BaseItemDetailsEntity itemDetailsEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.ItemDetailsService.Add(UserInfo, this.TargetTableName, itemDetailsEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
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
                            if (this.OnAdded != null)
                            {
                                this.OnAdded();
                            }
                            this.Changed = true;
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

        ///// <summary>
        ///// 添加
        ///// </summary>
        //public delegate void OnDataChangedEventHandler();

        //public event OnDataChangedEventHandler OnDataChanged;

        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            this.txtFullName.Text = this.txtCode.Text;
            this.txtItemValue.Text = this.txtCode.Text;
        }

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