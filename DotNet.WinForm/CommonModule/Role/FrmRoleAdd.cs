//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    // 这个按规范的做法，是不能引用的，需要实现瘦客户端（商业逻辑写在服务器上）
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmRoleAdd.cs
    /// 角色管理 - 添加角色管理
    ///		
    /// 修改记录
    /// 
    ///     2010.09.16 版本：2.0 JiRiGaLa  多种调用方法的例子说明编写。
    ///     2010.03.15 版本：1.8 JiRiGaLa  改进接口、以传递对象方式实现添加功能。
    ///     2007.06.05 版本：1.7 JiRiGaLa  整理主键。
    ///     2007.06.01 版本：1.3 JiRiGaLa  整体整理主键
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  角色添加功能页面编写。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.09.16</date>
    /// </author> 
    /// </summary>
    public partial class FrmRoleAdd : BaseForm
    {
        /// <summary>
        /// 角色实体
        /// </summary>
        public BaseRoleEntity roleEntity = null;

        private string roleCategory = string.Empty;
        /// <summary>
        /// 角色分类
        /// </summary>
        public string RoleCategory
        {
            get
            {
                return roleCategory;
            }
            set
            {
                roleCategory = value;
            }
        }

        public FrmRoleAdd()
        {
            InitializeComponent();
        }

        public FrmRoleAdd(string roleCategory) : this()
        {
            this.RoleCategory = roleCategory;
        }

        public FrmRoleAdd(BaseRoleEntity entity) : this()
        {
            this.roleEntity = entity;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获取分类列表
            this.BindItemDetails();
            // 显示实体
            this.ShowEntity();
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "RoleCategory");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRoleCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbRoleCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbRoleCategory.DataSource = dataTable.DefaultView;
            // 提高友善性，默认能选中角色类别
            if (!string.IsNullOrEmpty(this.RoleCategory))
            {
                this.cmbRoleCategory.SelectedValue = this.RoleCategory;
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 焦点定位
            this.chkEnabled.Checked = this.UserInfo.IsAdministrator;
            this.ActiveControl = this.txtRealName;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            if (this.roleEntity != null)
            {
                // 将类转显示到页面
                this.txtRealName.Text = this.roleEntity.RealName;
                this.txtCode.Text = this.roleEntity.Code;
                if (!string.IsNullOrEmpty(roleEntity.CategoryCode))
                {
                    this.cmbRoleCategory.SelectedValue = roleEntity.CategoryCode;
                }
                this.chkEnabled.Checked = this.roleEntity.Enabled == 1;
                this.txtDescription.Text = this.roleEntity.Description;
            }
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
            this.txtRealName.Text = this.txtRealName.Text.TrimEnd();
            if (string.IsNullOrEmpty(this.txtRealName.Text))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRealName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseRoleEntity GetEntity()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>角色实体</returns>
        private BaseRoleEntity GetEntity()
        {
            roleEntity = new BaseRoleEntity();
            roleEntity.RealName = this.txtRealName.Text;
            roleEntity.Code = this.txtCode.Text;
            roleEntity.Description = this.txtDescription.Text;
            roleEntity.Enabled = this.chkEnabled.Checked ? 1:0;
            roleEntity.CategoryCode = this.cmbRoleCategory.SelectedValue.ToString();
            roleEntity.AllowDelete = 1;
            roleEntity.AllowEdit = 1;
            roleEntity.DeletionStateCode = 0;
            roleEntity.IsVisible = 1;
            return roleEntity;
        }
        #endregion

        #region public override bool SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 读取角色实体
            this.GetEntity();

            // 直接操作数据库，拼接sql语句的。

            // 有参数化的、能防sql注入攻击等的。

            // 有数据库访问组建的。

            // 【入门级别、兴趣爱好者用】
            // 添加方法一：直接通过添加实体的方式添加数据（入门级的方法，胖客户端，没有逻辑判断的，本地数据库连接）
            // BaseRoleManager roleManager = new BaseRoleManager(this.UserInfo);
            // 判断是否存在重复数据
            // if (!roleManager.Exists(BaseRoleEntity.FieldRealName, roleEntity.RealName, BaseRoleEntity.FieldDeletionStateCode, 0))
            // {
            //     this.EntityId = roleManager.AddEntity(roleEntity);
            // }
            
            // 【推荐、开发效率高，B/S项目建议写法】
            // 添加方法二：通过管理器的，有业务逻辑的，判断是否重复等方式添加数据（推荐的做法，胖客户端，最高效的做法，本地数据库连接）
            // BaseRoleManager roleManager = new BaseRoleManager(this.UserInfo);
            // this.EntityId = roleManager.Add(roleEntity, out statusCode);

            // 【直接调用服务的方式，技术要求低，以后有扩展WCF、Remoting、WebService的余地】
            // 添加方法三：直接调用服务器（胖客户端，商业逻辑在服务层上，本地数据库连接）
            // RoleService roleService = new RoleService();
            // this.EntityId = roleService.Add(this.UserInfo, roleEntity, out statusCode, out statusMessage);

            // 【架构完美、开发成本高，真正分布式运行的推荐写法】
            // 添加方法四：最标准的通过服务工厂来调用添加方法（可以适应多种运行模式，为了实现完美架构，最完美的架构，服务器上连接数据库，非本地数据库连接）
            this.EntityId = DotNetService.Instance.RoleService.Add(UserInfo, roleEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                this.roleEntity.Id = int.Parse(this.EntityId);
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
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtRealName.SelectAll();
                    this.txtRealName.Focus();
                }
            }
            return returnValue;
        }
        #endregion

        #region private void ClearForm()
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtCode.Text = string.Empty;
            this.txtRealName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtRealName.Focus();
        }
        #endregion

        #region private void AddRole(bool close)
        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void AddRole(bool close)
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
                        // 数据发生了变化
                        this.Changed = true;
                        if (close)
                        {
                            this.DialogResult = DialogResult.OK;
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearForm();
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
            this.AddRole(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AddRole(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}