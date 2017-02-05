//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmRoleUserAdmin.cs
    /// 添加角色－用户窗体
    ///		
    /// 修改记录
    ///
    ///     2012.07.08 版本：1.0 hld 角色－员工添加。
    ///		
    /// 版本：1.20
    ///
    /// <author>
    ///		<name>hld</name>
    ///		<date>2012.07.08</date>
    /// </author> 
    /// </summary>   
    public partial class FrmRoleWithUser : BaseForm
    {
        /// <summary>
        /// 角色实体
        /// </summary>
        public BaseRoleEntity roleEntity = null;

        // 用户列表 DataTable
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

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

        public FrmRoleWithUser()
        {
            InitializeComponent();
        }

        public FrmRoleWithUser(string roleCategory) : this()
        {
            this.RoleCategory = roleCategory;
        }

        public FrmRoleWithUser(BaseRoleEntity entity)
            : this()
        {
            this.roleEntity = entity;
        }

        /// <summary>
        /// 添加的用户
        /// </summary>
        /// <returns>是否成功</returns>
        public delegate bool OnAddedEventHandler();

        public event OnAddedEventHandler OnAdded;

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获取分类列表
            this.BindItemDetails();
            // 显示实体
            //this.ShowEntity();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
            // 获得员工数据
            //if (this.roleEntity != null)
            //{
            //    this.DTUser = DotNetService.Instance.UserService.GetDataTableByRole(UserInfo, this.roleEntity.Id.ToString());
            //    // 绑定屏幕数据
            //    this.BindData();
            //}
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            // 加载员工数据主键
            this.grdUser.AutoGenerateColumns = false;
            this.grdUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("RoleAdmin");   // 访问权限
            this.permissionAdd = this.IsAuthorized("RoleAdmin.Add");      // 新增权限
            this.permissionEdit = this.IsAuthorized("RoleAdmin.Edit");     // 编辑权限
            this.permissionDelete = this.IsAuthorized("RoleAdmin.Delete");   // 删除权限
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

            this.btnRemove.Enabled = false;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnSave.Enabled = (roleEntity == null ? this.permissionAdd : this.permissionEdit);
            this.btnAdd.Enabled = this.permissionAdd;

            if (this.DTUser.DefaultView.Count > 0)
            {
                this.btnSelectAll.Enabled = this.permissionEdit;
                this.btnInvertSelect.Enabled = this.permissionEdit;
                this.btnRemove.Enabled = this.permissionDelete;
                // this.btnSearch.Enabled = true;
                // this.txtSearch.Enabled = true;
            }

            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("userEntites");
            this.btnPaste.Enabled = (clipboardData != null);
            this.btnCopy.Enabled = this.grdUser.Rows.Count > 0;
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
            roleEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
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
            DotNetService.Instance.RoleService.AddUserToRole(UserInfo, this.EntityId, this.GetIds());
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
            this.grdUser.DataSource = null;
            DTUser = new DataTable(BaseUserEntity.TableName);
            this.SetControlState();
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
                            if (this.OnAdded != null)
                            {
                                this.OnAdded();
                            }
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

        private bool OnSelected(string[] selectedIds)
        {
            //DotNetService.Instance.RoleService.AddUserToRole(UserInfo, this.roleEntity.Id.ToString(), selectedIds);
            // 加载窗体
            //this.FormOnLoad();
            // 设置按钮状态
            string[] allIds = unionStrArr(selectedIds, GetIds());
            this.DTUser = DotNetService.Instance.UserService.GetDataTableByIds(UserInfo, allIds);
            this.BindData();
            this.SetControlState();
            return true;
        }

        /// <summary>
        /// 合并数组去掉重复
        /// </summary>
        /// <param name="str1">数组1</param>
        /// <param name="str2">数组2</param>
        /// <returns></returns>
        private string[] unionStrArr(string[] str1,string[] str2)
        {
            List<string> listStr =new List<string>();
            foreach (string s1 in str1)
            {
                listStr.Add(s1);
            }
            foreach (string s2 in str2)
            {
                if (!listStr.Contains(s2))
                    listStr.Add(s2);
            }
            return listStr.ToArray();
        }

        /// <summary>
        /// 删除当前数组中的另一数组的值
        /// </summary>
        /// <param name="str1">数组1</param>
        /// <param name="str2">数组2</param>
        /// <returns></returns>
        private string[] delStrArr(string[] str1, string[] str2)
        {
            List<string> listStr = new List<string>();
            foreach (string s1 in str1)
            {
                listStr.Add(s1);
            }
            foreach (string s2 in str2)
            {
                if (listStr.Contains(s2))
                    listStr.Remove(s2);
            }
            return listStr.ToArray();
        }

        #region private string[] GetIds() 获得所有主键数组
        /// <summary>
        /// 获得所有主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetIds()
        {
            return BaseBusinessLogic.FieldToArray(this.DTUser, BaseUserEntity.FieldId);
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldId, "colSelected", true);
        }
        #endregion

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            FrmUserSelect frmUserSelect = new FrmUserSelect();
            frmUserSelect.OnSelected += new FrmUserSelect.OnSelectedEventHandler(this.OnSelected);
            frmUserSelect.AllowNull = false;
            frmUserSelect.MultiSelect = true;
            frmUserSelect.PermissionItemScopeCode = this.PermissionItemScopeCode;
            frmUserSelect.RemoveIds = this.GetIds();
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                string[] selectedIds = ((FrmUserSelect)frmUserSelect).SelectedIds;
                if (selectedIds != null)
                {
                    this.OnSelected(selectedIds);
                }
            }
        }

        #region private int BatchRemove() 批量移出
        /// <summary>
        /// 批量移出
        /// </summary>
        /// <returns>影响行数</returns>
        private int BatchRemove()
        {
            int returnValue = 0;
            this.FormLoaded = false;
            //returnValue = DotNetService.Instance.RoleService.RemoveUserFromRole(UserInfo, this.roleEntity.Id.ToString(), this.GetSelecteIds());
            // 绑定数据
            //this.FormOnLoad();
            // 设置按钮状态
            string[] allIds = delStrArr(this.GetIds(), this.GetSelecteIds());
            this.DTUser = DotNetService.Instance.UserService.GetDataTableByIds(UserInfo, allIds);
            this.BindData();
            this.SetControlState();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected"))
            {
                if (MessageBox.Show(AppMessage.MSG0075, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.BatchRemove();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddRole(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AddRole(true);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdUser.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            List<BaseUserEntity> userEntites = new List<BaseUserEntity>();
            for (int i = 0; i < this.DTUser.Rows.Count; i++)
            {
                BaseUserEntity userEntity = new BaseUserEntity(this.DTUser.Rows[i]);
                userEntites.Add(userEntity);
            }
            // 复制到剪切板
            Clipboard.SetData("userEntites", userEntites);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userEntites");
            if (clipboardData != null)
            {
                List<BaseUserEntity> userEntites = (List<BaseUserEntity>)clipboardData;
                string[] addUserIds = new string[userEntites.Count];
                for (int i = 0; i < userEntites.Count; i++)
                {
                    addUserIds[i] = userEntites[i].Id.ToString();
                }
                // 添加用户到角色
                //DotNetService.Instance.RoleService.AddUserToRole(this.UserInfo, this.EntityId, addUserIds);
                // 加载窗体
                //this.OnLoad(e);
                string[] allIds = unionStrArr(this.GetIds(), addUserIds);
                this.DTUser = DotNetService.Instance.UserService.GetDataTableByIds(this.UserInfo, allIds);
                this.grdUser.DataSource = this.DTUser;
            }
        }
    }
}
