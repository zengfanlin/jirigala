//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// 本系统生成的类库
using DotNet.Business;
using DotNet.Utilities;

/// <summary>
/// FrmUserRoleOrganizeSelect.cs
/// 选择组织机构、角色、用户窗体
///		
/// 修改记录
///
///     2012.04.25 版本：1.0 LiangMingMing  创建代码。
///		
/// 版本：1.0
///
/// <author>
///		<name>LiangMingMing</name>
///		<date>2012.04.25</date>
/// </author> 
/// </summary>
namespace DotNet.WinForm
{
    public partial class FrmUserRoleOrganizeSelect : BaseForm
    {
        /// <summary>
        /// 是否允许多项选择
        /// </summary>
        private bool allowMultiSelect = false;
        /// <summary>
        /// 是否允许多项选择（可以同时选择组织机构、角色、用户）
        /// </summary>
        public bool AllowMultiSelect
        {
            get
            {
                return this.allowMultiSelect;
            }
            set
            {
                this.allowMultiSelect = value;
            }
        }

        /// <summary>
        /// 单项操作时 当前操作选择（默认是组织机构）
        /// </summary>
        private string currentSelect = "ByOrganize";
        /// <summary>
        /// 单项操作时 当前操作选择（组织机构 ByOrganize、角色 ByRole、用户 ByUser）
        /// </summary>
        public string CurrentSelect
        {
            get
            {
                return this.currentSelect;
            }
            set
            {
                this.currentSelect = value;
            }
        }

        /// <summary>
        /// 检查转移
        /// </summary>
        /// <param name="selectedId">选择的主键数组</param>
        /// <returns>是否成功</returns>
        public delegate bool OnSelectedEventHandler(string[] selectedIds);


        //----------------------------------------
        //                组织机构属性
        //----------------------------------------

        /// <summary>
        /// 组织机构
        /// </summary>
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);
        /// <summary>
        /// 当前选择主键
        /// </summary>
        private string currentOrganizeEntityId = string.Empty;

        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentOrganizeEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.currentOrganizeEntityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.currentOrganizeEntityId;
            }
            set
            {
                this.currentOrganizeEntityId = value;
            }
        }

        public event BaseBusinessLogic.CheckMoveEventHandler OnButtonConfirmClick;

        /// <summary>
        /// 存取权限变量（组织机构）
        /// </summary>
        private string byOrganizePermission = string.Empty;
        /// <summary>
        /// 按什么权限域获取组织列表（组织机构）
        /// </summary>
        public string OrganizePermissionItemScopeCode
        {
            get
            {
                return this.byOrganizePermission;
            }
            set
            {
                this.byOrganizePermission = value;
            }
        }

        /// <summary>
        /// 是否允许组织机构选择(组织机构)
        /// </summary>
        private bool allowOrganizeSelect = false;
        /// <summary>
        /// 是否允许组织机构选择(组织机构)
        /// </summary>
        public bool AllowOrganizeSelect
        {
            get
            {
                return this.allowOrganizeSelect;
            }
            set
            {
                this.allowOrganizeSelect = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 是否允许选择空(组织机构)
        /// </summary>
        private bool allowOrganizeNull = false ;
        /// <summary>
        /// 是否允许选择空(组织机构)
        /// </summary>
        public bool AllowOrganizeNull
        {
            get
            {
                return this.allowOrganizeNull;
            }
            set
            {
                this.allowOrganizeNull = value;
            }
        }

        /// <summary>
        /// 是否允许多个选择(组织机构)
        /// </summary>
        private bool multiOrganizeSelect = false;
        /// <summary>
        /// 是否允许多个选择(组织机构)
        /// </summary>
        public bool MultiOrganizeSelect
        {
            get
            {
                return this.multiOrganizeSelect;
            }
            set
            {
                this.multiOrganizeSelect = value;
            }
        }

        /// <summary>
        /// 存取检查移动变量(组织机构)
        /// </summary>
        private bool checkOrganizeMove = false;
        /// <summary>
        /// 检查移动(组织机构)
        /// </summary>
        public bool CheckOrganizeMove
        {
            get
            {
                return this.checkOrganizeMove;
            }
            set
            {
                this.checkOrganizeMove = value;
            }
        }

        /// <summary>
        /// 存取被选中的组织主键变量(组织机构)
        /// </summary>
        private string selectedOrganizeId = string.Empty;
        /// <summary>
        /// 被选中的组织主键(组织机构)
        /// </summary>
        public string SelectedOrganizeId
        {
            get
            {
                return this.selectedOrganizeId;
            }
            set
            {
                this.selectedOrganizeId = value;
            }
        }

        /// <summary>
        /// 存取被选中的组织主键变量组(组织机构)
        /// </summary>
        private string[] selectedOrganizeIds = new string[0];
        /// <summary>
        /// 被选中的组织主键组(组织机构)
        /// </summary>
        public string[] SelectedOrganizeIds
        {
            get
            {
                return this.selectedOrganizeIds;
            }
            set
            {
                this.selectedOrganizeIds = value;
            }
        }

        /// <summary>
        /// 存取被选中的组织全名变量(组织机构)
        /// </summary>
        private string selectedOrganizeFullName = string.Empty;
        /// <summary>
        /// 被选中的组织全名(组织机构)
        /// </summary>
        public string SelectedOrganizeFullName
        {
            get
            {
                return this.selectedOrganizeFullName;
            }
            set
            {
                this.selectedOrganizeFullName = value;
            }
        }

        /// <summary>
        /// 存取组织机构打开节点变量(组织机构)
        /// </summary>
        private string openOrganizeId = string.Empty;
        /// <summary>
        /// 打开节点(组织机构)
        /// </summary>
        public string OpenOrganizeId
        {
            get
            {
                return this.openOrganizeId;
            }
            set
            {
                this.openOrganizeId = value;
            }
        }

        public event OnSelectedEventHandler OnOrganizeSelected;

        //----------------------------------------
        //                角色属性
        //----------------------------------------

        /// <summary>
        /// 角色表
        /// </summary>
        private DataTable DTRole = new DataTable(BaseRoleEntity.TableName);

        /// <summary>
        /// 移出的主键数组（角色）
        /// </summary>
        private string[] removeRoleIds = null;
        /// <summary>
        /// 移出的主键数组（角色）
        /// </summary>
        public string[] RemoveRoleIds
        {
            get
            {
                return this.removeRoleIds;
            }
            set
            {
                this.removeRoleIds = value;
            }
        }

        /// <summary>
        /// 只显示角色 （角色）
        /// </summary>
        private bool showRoleOnly = false;
        /// <summary>
        /// 只显示角色（角色）
        /// </summary>
        public bool ShowRoleOnly
        {
            get
            {
                return this.showRoleOnly;
            }
            set
            {
                this.showRoleOnly = value;
            }
        }

        /// <summary>
        /// 是否允许选择空（角色）
        /// </summary>
        private bool allowRoleNull = false;
        /// <summary>
        /// 是否允许选择空（角色）
        /// </summary>
        public bool AllowRoleNull
        {
            get
            {
                return this.allowRoleNull;
            }
            set
            {
                this.allowRoleNull = value;
            }
        }

        /// <summary>
        /// 是否允许选择（角色）
        /// </summary>
        private bool allowRoleSelect = false;
        /// <summary>
        /// 是否允许选择（角色）
        /// </summary>
        public bool AllowRoleSelect
        {
            get
            {
                return this.allowRoleSelect;
            }
            set
            {
                this.allowRoleSelect = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 是否允许多个选择（角色）
        /// </summary>
        private bool multiRoleSelect = false;
        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiRoleSelect
        {
            get
            {
                return this.multiRoleSelect;
            }
            set
            {
                this.multiRoleSelect = value;
            }
        }

        /// <summary>
        /// 按什么权限域获取角色列表（角色）
        /// </summary>
        private string byRolePermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取角色列表
        /// </summary>
        public string RolePermissionItemScopeCode
        {
            get
            {
                return this.byRolePermissionCode;
            }
            set
            {
                this.byRolePermissionCode = value;
            }
        }

        /// <summary>
        /// 被选中的角色主键(角色)
        /// </summary>
        private string selectedRoleId = string.Empty;
        /// <summary>
        /// 被选中的角色主键(角色)
        /// </summary>
        public string SelectedRoleId
        {
            get
            {
                return this.selectedRoleId;
            }
            set
            {
                this.selectedRoleId = value;
            }
        }

        /// <summary>
        /// 被选中的角色全名(角色)
        /// </summary>
        private string selectedRoleFullName = string.Empty;
        /// <summary>
        /// 被选中的角色全名(角色)
        /// </summary>
        public string SelectedRoleFullName
        {
            get
            {
                return this.selectedRoleFullName;
            }
            set
            {
                this.selectedRoleFullName = value;
            }
        }

        /// <summary>
        /// 打开节点(角色)
        /// </summary>
        private string openRoleId = string.Empty;
        /// <summary>
        /// 打开节点(角色)
        /// </summary>
        public string OpenRoleId
        {
            get
            {
                return this.openRoleId;
            }
            set
            {
                this.openRoleId = value;
            }
        }

        /// <summary>
        /// 被选中的主键集(角色)
        /// </summary>
        private string[] selectedRoleIds = new string[0];
        /// <summary>
        /// 被选中的员工主键(角色)
        /// </summary>
        public string[] SelectedRoleIds
        {
            get
            {
                return this.selectedRoleIds;
            }
            set
            {
                this.selectedRoleIds = value;
            }
        }

        public event OnSelectedEventHandler OnRoleSelected;

        //----------------------------------------
        //                用户属性
        //----------------------------------------

        /// <summary>
        /// 用户数据表
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        /// <summary>
        /// 是否选择另一个
        /// </summary>
        public bool AllowSelectOther = true;

        /// <summary>
        /// 检查什么模块
        /// </summary>
        public string CheckPermissionFullName = string.Empty;
        /// <summary>
        /// 检查什么模块
        /// </summary>
        public string CheckModuleCode = string.Empty;
        /// <summary>
        /// 检查什么权限
        /// </summary>
        public string CheckOperationCode = string.Empty;

        /// <summary>
        /// 移出的主键数组（用户）
        /// </summary>
        private string[] removeUserIds = null;
        /// <summary>
        /// 移出的主键数组（用户）
        /// </summary>
        public string[] RemoveUserIds
        {
            get
            {
                return this.removeUserIds;
            }
            set
            {
                this.removeUserIds = value;
            }
        }

        /// <summary>
        /// 选中的主键数组（用户）
        /// </summary>
        private string[] setSelectUserIds = null;
        /// <summary>
        /// 选中的主键数组（用户）
        /// </summary>
        public string[] SetSelectUserIds
        {
            get
            {
                return this.setSelectUserIds;
            }
            set
            {
                this.setSelectUserIds = value;
            }
        }

        /// <summary>
        /// 是否允许多个选择（用户）
        /// </summary>
        private bool multiUserSelect = false;
        /// <summary>
        /// 是否允许多个选择（用户）
        /// </summary>
        public bool MultiUserSelect
        {
            get
            {
                return this.multiUserSelect;
            }
            set
            {
                this.multiUserSelect = value;
            }
        }

        /// <summary>
        /// 是否允许选择空（用户）
        /// </summary>
        private bool allowUserNull = false;
        /// <summary>
        /// 是否允许选择空（用户）
        /// </summary>
        public bool AllowUserNull
        {
            get
            {
                return this.allowUserNull;
            }
            set
            {
                this.allowUserNull = value;
            }
        }

        /// <summary>
        ///  是否允许选择（用户）
        /// </summary>
        private bool allowUserSelect = false ;
        /// <summary>
        /// 是否允许选择（用户）
        /// </summary>
        public bool AllowUserSelect
        {
            get
            {
                return this.allowUserSelect;
            }
            set
            {
                this.allowUserSelect = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 按什么权限域获取员工列表（用户）
        /// </summary>
        private string byUserPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取员工列表（用户）
        /// </summary>
        public string UserPermissionItemScopeCode
        {
            get
            {
                return this.byUserPermissionCode;
            }
            set
            {
                this.byUserPermissionCode = value;
            }
        }

        /// <summary>
        /// 被选中的员工主键（用户）
        /// </summary>
        private string selectedUserId = string.Empty;
        /// <summary>
        /// 被选中的员工主键（用户）
        /// </summary>
        public string SelectedUserId
        {
            get
            {
                return this.selectedUserId;
            }
            set
            {
                this.selectedUserId = value;
            }
        }

        /// <summary>
        /// 被选中的员工全名（用户）
        /// </summary>
        private string selectedUserFullName = string.Empty;
        /// <summary>
        /// 被选中的员工全名（用户）
        /// </summary>
        public string SelectedUserFullName
        {
            get
            {
                return this.selectedUserFullName;
            }
            set
            {
                this.selectedUserFullName = value;
            }
        }

        /// <summary>
        /// 打开节点（用户）
        /// </summary>
        private string openUserId = string.Empty;
        /// <summary>
        /// 打开节点（用户）
        /// </summary>
        public string OpenUserId
        {
            get
            {
                return this.openUserId;
            }
            set
            {
                this.openUserId = value;
            }
        }

        /// <summary>
        /// 被选中的员工主键（用户）
        /// </summary>
        private string[] selectedUserIds = null;
        /// <summary>
        /// 被选中的员工主键（用户）
        /// </summary>
        public string[] SelectedUserIds
        {
            get
            {
                return this.selectedUserIds;
            }
            set
            {
                this.selectedUserIds = value;
            }
        }

        public event OnSelectedEventHandler OnUserSelected;

        // **********************************************************************************************
        // *                                                                                            * 
        // *                             InitializeComponent  初始化                                    * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region  public FrmUserRoleOrganizeSelect() 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        public FrmUserRoleOrganizeSelect()
        {
            InitializeComponent();
        }
        #endregion

        #region public FrmUserRoleOrganizeSelect(string currentOrganizeId, bool roleOnly) 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        /// <param name="currentId">当前组织机构代码</param>
        public FrmUserRoleOrganizeSelect(string currentOrganizeId, bool roleOnly)
            : this()
        {
            this.CurrentOrganizeEntityId = currentOrganizeId;
            this.OpenOrganizeId = currentOrganizeId;
        }
        #endregion

        #region  public FrmUserRoleOrganizeSelect(string currentOrganizeId, bool isInnerOrganize, bool roleOnly) 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        /// <param name="currentOrganizeId">当前组织机构代码</param>
        /// <param name="isInnerOrganize">是否内部组织机构</param>
        public FrmUserRoleOrganizeSelect(string currentOrganizeId, bool isInnerOrganize, bool roleOnly)
            : this()
        {
            this.chkInnerOrganize.Checked = isInnerOrganize;
        }
        #endregion

        #region public FrmUserRoleOrganizeSelect(string currentOrganizeId, string parentOrganizeId, bool roleOnly) 重构函数
        /// <summary>
        /// 重构函数
        /// </summary>
        /// <param name="currentOrganizeId">当前组织机构代码</param>
        /// <param name="parentOrganizeId">组织机构父节点</param>
        public FrmUserRoleOrganizeSelect(string currentOrganizeId, string parentOrganizeId, bool roleOnly)
            : this()
        {
            this.OpenOrganizeId = currentOrganizeId;
            this.CurrentOrganizeEntityId = parentOrganizeId;
        }
        #endregion

        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       Method   操作方法                                    * 
        // *                                                                                            * 
        // **********************************************************************************************

        #region private void Localization() 多语言国际化加载
        /// <summary>
        /// 多语言国际化加载
        /// </summary>
        private void Localization()
        {
            BaseInterfaceLogic.SetLanguageResource(this);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 加载组织机构
            LoadOrganize();
            // 加载角色数据
            LoadRole();
            // 加载用户
            LoadUser();
            // 初始化时选择为空
            this.tvOrganize.SelectedNode = null;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.AllowOrganizeSelect)
            {
                this.tcOrganizeTree.Enabled = true; 
            }
            else 
            {
                this.tcOrganizeTree.Enabled = false ; 
            }
            if (this.AllowRoleSelect)
            {
                this.grdRole.Enabled = true;
                this.cmbRoleCategory.Enabled = true;
            }
            else
            {
                this.grdRole.Enabled = false;
                this.cmbRoleCategory.Enabled = false;
            }
            if (this.AllowUserSelect)
            {
                this.grdUser.Enabled = true;
                this.cmbRole.Enabled = true;
                this.txtSearch1.Enabled = true;
                this.btnSearch1.Enabled = true;
            }
            else
            {
                this.grdUser.Enabled = false;
                this.cmbRole.Enabled = false;
                this.txtSearch1.Enabled = false;
                this.btnSearch1.Enabled = false ;
            }
            // 组织机构选项卡
            if (this.tbcSelect.SelectedIndex == 0)
            {
                this.chkInnerOrganize.Enabled = this.tcOrganizeTree.Enabled;
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                // 组织机构下按钮状态
                this.btnSetNull.Enabled = this.AllowOrganizeNull ? this.tcOrganizeTree.Enabled : false;
                // 首先是需要能多选，其次是还有委托不是空的
                this.btnSelect.Enabled = this.MultiOrganizeSelect && this.OnOrganizeSelected != null;
                if (this.DTOrganize.Rows.Count == 0)
                {
                    this.btnConfirm.Enabled = false;
                }
                else
                {
                    this.btnSelectAll.Enabled = this.tcOrganizeTree.Enabled;
                    this.btnInvertSelect.Enabled = this.tcOrganizeTree.Enabled;
                    this.btnConfirm.Enabled = this.tcOrganizeTree.Enabled;
                }
                if (!this.MultiOrganizeSelect)
                {
                    this.btnSelectAll.Enabled = false;
                    this.btnInvertSelect.Enabled = false;
                }
            }           
            // 角色选项卡
            if (this.tbcSelect.SelectedIndex == 1)
            {
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                this.btnSetNull.Enabled = this.AllowRoleNull ? this.grdRole.Enabled : false;
                // 首先是需要能多选，其次是还有委托不是空的
                this.btnSelect.Enabled = this.MultiRoleSelect && this.OnRoleSelected != null;
                if (this.DTRole.DefaultView.Count == 0)
                {
                    this.btnConfirm.Enabled = false;
                }
                else
                {
                    this.btnSelectAll.Enabled = this.grdRole.Enabled;
                    this.btnInvertSelect.Enabled = this.grdRole.Enabled;
                    this.btnConfirm.Enabled = this.grdRole.Enabled;
                }
                if (!this.MultiRoleSelect)
                {
                    this.btnSelectAll.Enabled = false;
                    this.btnInvertSelect.Enabled = false;
                }
            }
            // 用户选项卡
            if (this.tbcSelect.SelectedIndex == 2)
            {
                this.btnSearch.Enabled = !BaseSystemInfo.LoadAllUser;
                this.btnSetNull.Enabled = this.AllowUserNull ? this.grdUser.Enabled : false;
                this.btnSelectAll.Enabled = false;
                this.btnInvertSelect.Enabled = false;
                // 首先是需要能多选，其次是还有委托不是空的
                this.btnSelect.Enabled = this.MultiUserSelect && this.OnUserSelected != null;
                if (!this.MultiUserSelect)
                {
                    this.btnSelectAll.Enabled = false;
                    this.btnInvertSelect.Enabled = false;
                }
                this.btnConfirm.Enabled = false;

                if (this.DTUser.Rows.Count > 0)
                {
                    if (this.MultiUserSelect)
                    {
                        this.btnSelectAll.Enabled = this.grdUser.Enabled;
                        this.btnInvertSelect.Enabled = this.grdUser.Enabled;
                    }
                    this.btnConfirm.Enabled = this.grdUser.Enabled;
                }
                this.txtSearch.Enabled = this.AllowSelectOther ? this.tcOrganizeTree.Enabled : false;
                this.btnSearch.Enabled = this.AllowSelectOther ? this.tcOrganizeTree.Enabled : false;
                if ((this.btnSearch.Enabled) && (!UserInfo.IsAdministrator))
                {
                    // 若是进行了权限范围过滤了，那就不能在数据库里进行查询了
                    this.btnSearch.Enabled = String.IsNullOrEmpty(this.UserPermissionItemScopeCode);
                }
            }
        }
        #endregion

        #region private bool CheckInputMultiSelect() 检查多选至少有一个选项需要选择的
        /// <summary>
        /// 检查多选至少有一个选项需要选择的
        /// </summary>
        /// <returns></returns>
        private bool CheckInputMultiSelect(bool showMessage)
        {
            bool organize = false, role = false, user = false, returnValue = false,otherCode=false;
            // 选择组织机构
            if (this.MultiOrganizeSelect)
            {
                // 检查多选是否至少选择一条以上记录
                organize = BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdOrganize, "colSelected", showMessage);
            }
            else
            {
                // 检查单选有效
                organize = this.CheckOrganizeInput(showMessage, out otherCode);
                if (otherCode)
                {
                    this.tbcSelect.SelectedIndex = 0;
                    this.tcOrganizeTree.SelectedIndex = 1;
                    return false ;
                }
            }
            // 选择角色
            if (this.MultiRoleSelect)
            {
                // 检查多选是否至少选择一条以上记录
                role = BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected1", showMessage);
            }
            else
            {
                // 检查单选有效
                role = BaseInterfaceLogic.CheckInputSelectOne(this.grdRole, "colSelected1", showMessage, out otherCode);
                if (otherCode)
                {
                    this.tbcSelect.SelectedIndex = 1;
                    return false;
                }
            }
            // 选择用户
            if (this.MultiUserSelect)
            {
                // 检查多选是否至少选择一条以上记录
                user = BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected2", showMessage);
            }
            else
            {
                // 检查单选有效
                user = BaseInterfaceLogic.CheckInputSelectOne(this.grdUser, "colSelected2", showMessage, out otherCode);
                if (otherCode)
                {
                    this.tbcSelect.SelectedIndex = 2;
                    return false;
                }
            }
            if (organize || role || user)
            {
                returnValue = true;
            }
            else
            {                
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);                
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region private void ConfirmMutiSelect(bool showMessage) 确认多项选择
        /// <summary>
        /// 确认多项选择
        /// </summary>
        /// <param name="showMessage">是否显示提示信息</param>
        private void ConfirmMutiSelect(bool showMessage)
        {
            if (this.CheckInputMultiSelect(showMessage))
            {
                // 组织机构选择
                if (!this.MultiOrganizeSelect)
                {
                    this.SelectOrganize(showMessage, false);
                }
                else
                {
                    this.SelectOrganizeMulti(showMessage, false, false);
                }
                // 角色选择
                if (!this.MultiRoleSelect)
                {
                    this.SelectRole(showMessage, false);
                }
                else
                {
                    this.SelectRoleMulti(showMessage, false, false);
                }
                // 用户选择
                if (!this.MultiUserSelect)
                {
                    this.SelectUser(showMessage, false);
                }
                else
                {
                    this.SelectUserMulti(showMessage, false, false);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        //---------------------------------------------------------------
        //                     组织机构方法
        //---------------------------------------------------------------

        #region private void LoadOrganize() 加载组织机构
        /// <summary>
        /// 加载组织机构
        /// </summary>
        private void LoadOrganize()
        {
            // 获取组织机构列表
            this.DTOrganize = this.GetOrganizeScope(this.OrganizePermissionItemScopeCode, this.chkInnerOrganize.Checked);
            // 只要有效的数据
            BaseBusinessLogic.SetFilter(this.DTOrganize, BaseOrganizeEntity.FieldEnabled, "1");
            // 排序
            this.DTOrganize.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            // 列表邦定
            this.grdOrganize.AutoGenerateColumns = false;
            this.grdOrganize.DataSource = this.DTOrganize.DefaultView;
            // 加载树
            this.BindData(true);
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvOrganize.SelectedNode == null)
            {
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    if (this.CurrentOrganizeEntityId.Length == 0)
                    {
                        this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                    }
                    else
                    {
                        BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.CurrentOrganizeEntityId);
                        if (BaseInterfaceLogic.TargetNode != null)
                        {
                            this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                        }
                    }
                }
                if (this.tvOrganize.SelectedNode != null)
                {
                    // 让选中的节点可视，并用展开方式
                    this.tvOrganize.SelectedNode.Expand();
                    this.tvOrganize.SelectedNode.EnsureVisible();
                    // 防止只有一个父节点的情况下，无法展开情况发生
                    this.GetOrganizeList();
                }
            }
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.OpenOrganizeId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                this.tvOrganize.SelectedNode.EnsureVisible();
                this.tvOrganize.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            if ((BaseSystemInfo.UsePermissionScope) && !UserInfo.IsAdministrator)
            {
                BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            }
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        #region private void GetSelecteOrganizeId() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        private void GetSelecteOrganizeId()
        {
            // 是否已有选中的
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdOrganize, "colSelected");
            if (dataRow == null)
            {
                // 默认当前的行
                dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdOrganize);
            }
            if (dataRow != null)
            {
                this.SelectedOrganizeId = dataRow[BaseOrganizeEntity.FieldId].ToString();
                this.SelectedOrganizeFullName = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
            }
        }
        #endregion

        #region private string[] GetSelecteOrganizeIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteOrganizeIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseOrganizeEntity.FieldId, "colSelected1", true);
        }
        #endregion

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove(bool showMessage)
        {
            bool returnValue = true;
            // 单个移动检查
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.OpenOrganizeId);
            TreeNode treeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.CurrentOrganizeEntityId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                if (showMessage)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                DataTable DTOrganizeList = DotNetService.Instance.OrganizeService.GetDataTableByParent(UserInfo, (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString());
                DTOrganizeList.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
                foreach (DataRow dataRow in DTOrganizeList.Rows)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    treeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
                this.tvOrganize.SelectedNode.Expand();
                // 设置按钮状态
                this.SetControlState();
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void SetSearch() 设置查询条件
        /// <summary>
        /// 设置查询条件
        /// </summary>
        private void SetSearch()
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                // this.DTOrganizeList.DefaultView.RowFilter = string.Empty;
                this.grdOrganize.DataSource = this.DTOrganize.DefaultView;

            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTOrganize.DefaultView.RowFilter = BaseOrganizeEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseOrganizeEntity.FieldFullName + " LIKE '" + search + "'"
                    + " OR " + BaseOrganizeEntity.FieldDescription + " LIKE '" + search + "'";
                this.grdOrganize.DataSource = this.DTOrganize.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void RemoveOrganize(string[] ids) 移除组织机构
        /// <summary>
        /// 移除组织机构
        /// </summary>
        /// <param name="ids"></param>
        private void RemoveOrganize(string[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow dataRow = this.DTOrganize.Rows.Find(ids[i]);
                    if (dataRow != null)
                    {
                        dataRow.Delete();
                    }
                }
                this.DTOrganize.AcceptChanges();
            }
        }
        #endregion

        #region public bool CheckOrganizeInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <returns>bool</returns>
        public bool CheckOrganizeInput(bool showMessage,out bool otherCode )
        {
            otherCode = false;
            bool returnValue = false;
            if (this.tcOrganizeTree.SelectedIndex == 0)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    returnValue = true;
                }
                if (!returnValue)
                {
                    if (showMessage)
                    {
                        MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (this.tcOrganizeTree.SelectedIndex == 1)
            {
                return BaseInterfaceLogic.CheckInputSelectOne(this.grdOrganize, "colSelected", showMessage, out otherCode);
            }
            return returnValue;
        }
        #endregion

        #region private void SelectOrganize(bool showMessage, bool isEndDialog) 单选组织机构
        /// <summary>
        /// 单选组织机构
        /// </summary>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <param name="isEndDialog">是否结束对话</param>
        private void SelectOrganize(bool showMessage, bool isEndDialog)
        {
            bool otherCode =false;
            // 检查组织机构是否有选择
            if (this.CheckOrganizeInput(showMessage, out otherCode))
            {
                // 当前选择的部门
                if (this.tcOrganizeTree.SelectedIndex == 0)
                {
                    this.SelectedOrganizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                    this.SelectedOrganizeFullName = this.tvOrganize.SelectedNode.Text;
                }
                if (this.tcOrganizeTree.SelectedIndex == 1)
                {
                    this.GetSelecteOrganizeId();
                }
                // 检查移动的有效性
                if (this.CheckOrganizeMove)
                {
                    if (!this.CheckInputMove(showMessage))
                    {
                        return;
                    }
                }
                if (this.OnButtonConfirmClick != null)
                {
                    if (this.OnButtonConfirmClick(this.SelectedOrganizeId))
                    {
                        if (isEndDialog)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (isEndDialog)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
        #endregion

        #region private void SelectOrganizeMulti(bool showMessage, bool isEndDialog) 单选组织机构
        /// <summary>
        /// 单选组织机构
        /// </summary>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <param name="isEndDialog">是否结束对话</param>
        private void SelectOrganizeMulti(bool showMessage, bool isEndDialog, bool close = true)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdOrganize, "colSelected", showMessage))
            {
               this.SelectedOrganizeIds = this.GetSelecteOrganizeIds();
               this.SelectedOrganizeFullName = BaseBusinessLogic.ObjectsToList(BaseInterfaceLogic.GetSelecteIds(this.grdOrganize, BaseOrganizeEntity.FieldFullName, "colSelected", true));
                if (!close)
                {
                    if (this.OnOrganizeSelected != null)
                    {
                        // 进行委托处理
                        if (this.OnOrganizeSelected(this.SelectedOrganizeIds))
                        {
                            this.RemoveOrganize(this.SelectedOrganizeIds);
                            this.SelectedOrganizeIds = null;
                        }
                        // 清除选中的数据
                        return;
                    }
                }
                if (isEndDialog)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        //---------------------------------------------------------------
        //                     角色方法
        //---------------------------------------------------------------

        #region private void LoadRole()加载角色数据
        /// <summary>
        /// 加载角色数据
        /// </summary>
        private void LoadRole()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdRole);

            // 调用接口方式实现
            if (!String.IsNullOrEmpty(this.RolePermissionItemScopeCode))
            {
                this.DTRole = DotNetService.Instance.PermissionService.GetRoleDTByPermissionScope(UserInfo, UserInfo.Id, this.RolePermissionItemScopeCode);
            }
            else
            {
                this.DTRole = DotNetService.Instance.RoleService.GetDataTable(UserInfo);
            }

            // 设置表主键
            DataColumn[] primaryKey = new DataColumn[] { this.DTRole.Columns[BaseRoleEntity.FieldId] };
            this.DTRole.PrimaryKey = primaryKey;
            // 检查是否需要移出
            this.RemoveRole(this.RemoveRoleIds);

            this.grdRole.AutoGenerateColumns = false;
            this.DTRole.DefaultView.Sort = BaseRoleEntity.FieldSortCode;
            this.grdRole.DataSource = this.DTRole;
            // 获取分类列表
            this.BindItemDetails();
            // 设置数据过滤
            this.SetRowFilter();
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cmbRoleCategory.Items.Count == 0)
            {
                DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, "ItemsRoleCategory");
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbRoleCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
                this.cmbRoleCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;
                this.cmbRoleCategory.DataSource = dataTable.DefaultView;
            }
        }
        #endregion

        #region private void RemoveRole(string[] ids) 移除角色主键组
        /// <summary>
        /// 移除角色主键组
        /// </summary>
        /// <param name="ids"></param>
        private void RemoveRole(string[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow dataRow = this.DTRole.Rows.Find(ids[i]);
                    if (dataRow != null)
                    {
                        dataRow.Delete();
                    }
                }
                this.DTRole.AcceptChanges();
            }
        }
        #endregion

        #region private string GetCategoryFilter() 设置条件好获取角色分类值
        /// <summary>
        /// 设置条件好获取角色分类值
        /// </summary>
        /// <returns></returns>
        private string GetCategoryFilter()
        {
            string returnValue = string.Empty;
            if (this.cmbRoleCategory.SelectedValue != null)
            {
                if (this.cmbRoleCategory.SelectedValue.ToString().Length > 0)
                {
                    returnValue = BaseRoleEntity.FieldCategoryCode + " = '" + this.cmbRoleCategory.SelectedValue + "' ";
                }
            }
            return returnValue;
        }
        #endregion

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            this.DTRole.DefaultView.RowFilter = this.GetCategoryFilter();
        }
        #endregion

        #region private void GetSelectedRoleId(DataRow dataRow) 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// <param name="dataRow">数据行</param>
        /// </summary>
        private void GetSelectedRoleId(DataRow dataRow)
        {
            // 获得当前选中的行 
            BaseRoleEntity roleEntity = new BaseRoleEntity();
            roleEntity.GetFrom(dataRow);
            // 获得具体选中的内容
            if (roleEntity.Id > 0)
            {
                this.SelectedRoleId = roleEntity.Id.ToString();
                this.SelectedRoleFullName = roleEntity.RealName;
            }
        }
        #endregion

        #region private string[] GetSelectedRoleIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedRoleIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseRoleEntity.FieldId, "colSelected1", true);
        }
        #endregion

        #region private void SelectRoleMulti(bool showMessage,bool isEndDialog,bool close = true) 多选角色
        /// <summary>
        /// 多选角色
        /// </summary>
        /// <param name="showMessage">是否显示信息</param>
        /// <param name="isEndDialog">是否结束对话</param>
        /// <param name="close">关闭窗体</param>
        private void SelectRoleMulti(bool showMessage, bool isEndDialog, bool close = true)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdRole, "colSelected1", showMessage))
            {
                this.SelectedRoleIds = this.GetSelectedRoleIds();
                this.SelectedRoleFullName = BaseBusinessLogic.ObjectsToList(BaseInterfaceLogic.GetSelecteIds(this.grdRole, BaseRoleEntity.FieldRealName, "colSelected1", true));
                if (!close)
                {
                    if (this.OnRoleSelected != null)
                    {
                        // 进行委托处理
                        if (this.OnRoleSelected(this.SelectedRoleIds))
                        {
                            this.RemoveRole(this.SelectedRoleIds);
                            this.SelectedRoleIds = null;
                        }
                        // 清除选中的数据
                        return;
                    }
                }
                if (isEndDialog)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        #region private void SelectRole(bool showMessage, bool isEndDialog) 单选角色
        /// <summary>
        /// 单选角色
        /// </summary>
        /// <param name="showMessage">是否显示信息</param>
        /// <param name="isEndDialog">是否结束对话</param>
        private void SelectRole(bool showMessage, bool isEndDialog)
        {
            if (BaseInterfaceLogic.CheckInputSelectOne(this.grdRole, "colSelected1", showMessage ))
            {
                DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdRole, "colSelected1");
                if (dataRow == null)
                {
                    // 默认当前的行
                    dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
                }
                if (dataRow != null)
                {
                    this.GetSelectedRoleId(dataRow);
                    if (isEndDialog)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
        #endregion

        //---------------------------------------------------------------
        //                     用户方法
        //---------------------------------------------------------------

        #region private void GetList(string searchValue) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void GetList(string searchValue)
        {
            if (String.IsNullOrEmpty(searchValue))
            {
                // 不是管理员，并且需要按权限过滤数据
                if ((UserInfo.IsAdministrator) || String.IsNullOrEmpty(this.UserPermissionItemScopeCode))
                {
                    // 这里是获取所有的用户
                    this.DTUser = DotNetService.Instance.UserService.GetDataTable(UserInfo);
                }
                else
                {
                    // 这里是按权限范围进行过滤后的用户
                    this.DTUser = DotNetService.Instance.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id, this.UserPermissionItemScopeCode);
                }
            }
            else
            {
                this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, searchValue, string.Empty, null);
            }
            this.grdUser.AutoGenerateColumns = false;
            this.DTUser.PrimaryKey = new DataColumn[] { this.DTUser.Columns[BaseUserEntity.FieldId] };
            this.DTUser.AcceptChanges();
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.grdUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        #region private void FormOnLoad(bool loadUser) 加载用户数据
        /// <summary>
        /// 加载用户数据
        /// </summary>
        /// <param name="loadUser"></param>
        private void FormOnLoad(bool loadUser)
        {
            this.FormOnLoad(loadUser, string.Empty);
        }
        #endregion

        #region private void RemoveUser(string[] ids) 移除用户
        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="ids"></param>
        private void RemoveUser(string[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow dataRow = this.DTUser.Rows.Find(ids[i]);
                    if (dataRow != null)
                    {
                        dataRow.Delete();
                    }
                }
                this.DTUser.AcceptChanges();
            }
        }
        #endregion

        #region private void FormOnLoad(bool loadUser, string searchValue) 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        private void FormOnLoad(bool loadUser, string searchValue)
        {
            if (loadUser)
            {
                // 加载数据
                this.GetList(searchValue);

                // 检查是否需要移出
                this.RemoveUser(this.RemoveUserIds);

                // 检查选中状态
                if (this.SetSelectUserIds != null && this.SetSelectUserIds.Length > 0)
                {
                    foreach (DataGridViewRow dgvRow in this.grdUser.Rows)
                    {
                        DataRowView dataRowView = dgvRow.DataBoundItem as DataRowView;
                        if (dataRowView.Row.RowState == DataRowState.Deleted)
                        {
                            continue;
                        }
                        string id = dataRowView.Row[BaseUserEntity.FieldId].ToString();
                        // 是否已经发了消息
                        if (Array.Exists(SetSelectUserIds, element => element.Equals(id)))
                        {
                            dgvRow.Cells["colSelected2"].Value = true;
                        }
                    }
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region  private void LoadUser() 加载用户数据
        /// <summary>
        /// 加载用户数据
        /// </summary>
        private void LoadUser()
        {
            // 获取角色列表
            this.GetRoles();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdUser);
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            this.FormOnLoad(BaseSystemInfo.LoadAllUser);
        }
        #endregion

        #region private void GetRoles() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dataTable = DotNetService.Instance.UserService.GetRoleDT(UserInfo);
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldDeletionStateCode, "0");
            BaseBusinessLogic.SetFilter(dataTable, BaseRoleEntity.FieldEnabled, "1");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region private string[] GetUserSelectedUserIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns>主键组</returns>
        private string[] GetSelectedUserIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldId, "colSelected2", true);
        }
        #endregion

        #region private bool CheckPermission(string userId, string userFullName) 检查权限
        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="userFullName">员工姓名</param>
        /// <returns>是否有权限</returns>
        private bool CheckPermission(string userId, string userFullName)
        {
            bool returnValue = true;
            //if ((this.CheckModuleCode.Length > 0) && (this.CheckOperationCode.Length > 0))
            //{
            //    if (ModuleOperationCheckService.Instance.IsAuthorized(UserInfo, userId, this.CheckModuleCode, this.CheckOperationCode))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show(userFullName + "无权限：" + this.CheckPermissionFullName, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
            return returnValue;
        }
        #endregion

        #region public override bool CheckUserInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public bool CheckUserInput()
        {
            bool returnValue = false;
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdUser, "colSelected2");
            if (dataRow != null)
            {
                if ((dataRow[BaseUserEntity.FieldId].ToString().Length > 0) && (dataRow[BaseUserEntity.FieldRealName].ToString().Length > 0))
                {
                    string userId = dataRow[BaseUserEntity.FieldId].ToString();
                    string userFullName = dataRow[BaseUserEntity.FieldRealName].ToString();
                    if (this.CheckPermission(userId, userFullName))
                    {
                        returnValue = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private void GetSelectedUserId() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        private void GetSelectedUserId()
        {
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdUser, "colSelected2");
            if (dataRow == null)
            {
                // 默认当前的行
                dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
            }
            if (dataRow != null)
            {
                this.SelectedUserId = dataRow[BaseUserEntity.FieldId].ToString();
                this.SelectedUserFullName = dataRow[BaseUserEntity.FieldRealName].ToString();
            }
        }
        #endregion

        #region private void SelectUser(bool showMessage) 单选用户
        /// <summary>
        /// 单选用户
        /// </summary>
        /// <param name="showMessage">是否显示信息</param>
        /// <param name="isEndDiglog">是否结束对话</param>
        private void SelectUser(bool showMessage, bool isEndDiglog)
        {
            if (BaseInterfaceLogic.CheckInputSelectOne(this.grdUser, "colSelected2", showMessage))
            {
                DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdUser, "colSelected2");
                if (dataRow == null)
                {
                    // 默认当前的行
                    dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
                }
                if (dataRow != null)
                {
                    this.GetSelectedUserId();
                    if (isEndDiglog)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
        #endregion

        #region private void SelectUserMulti(bool showMessage,bool isEndDialog,bool close = true) 多选用户
        /// <summary>
        /// 多选用户
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SelectUserMulti(bool showMessage, bool isEndDialog, bool close = true)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdUser, "colSelected2", showMessage))
            {
                this.SelectedUserIds = this.GetSelectedUserIds();
                this.SelectedUserFullName = BaseBusinessLogic.ObjectsToList(this.GetSelectedFullNames());
                if (!close)
                {
                    if (this.OnUserSelected != null)
                    {
                        // 进行委托处理
                        if (this.OnUserSelected(this.SelectedUserIds))
                        {
                            this.RemoveUser(this.SelectedUserIds);
                            this.SelectedUserIds = null;
                        }
                        // 清除选中的数据
                        return;
                    }
                }
                if (isEndDialog)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        // **********************************************************************************************
        // *                                                                                            * 
        // *                                       EventArgs    事件方法                                * 
        // *                                                                                            * 
        // **********************************************************************************************

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            // 设置选择的组织机构为空
            this.selectedOrganizeIds = null;
            this.SelectedOrganizeId = null;
            this.SelectedOrganizeFullName = null;
            // 设置选择的角色为空
            this.selectedRoleIds = null;
            this.SelectedRoleId = null;
            this.SelectedRoleFullName = null;
            // 设置选择的用户为空
            this.selectedUserIds = null;
            this.SelectedUserId = null;
            this.SelectedUserFullName = null;
            // 返回OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 可以多项选择的
            if (this.AllowMultiSelect)
            {
                this.ConfirmMutiSelect(false);
            }
            else
            {
                // 当前选择的是组织机构选项卡
                if (this.tbcSelect.SelectedIndex == 0)
                {
                    // 设置当前操作对象类型
                    this.CurrentSelect = "ByOrganize";
                    if (this.MultiOrganizeSelect)
                    {
                        // 多选
                        this.SelectOrganizeMulti(true, true, true);
                    }
                    else
                    {
                        // 单选
                        this.SelectOrganize(true, true);
                    }
                }
                // 当前选择的是角色选项卡
                else if (this.tbcSelect.SelectedIndex == 1)
                {
                    // 设置当前操作对象类型
                    this.CurrentSelect = "ByRole";
                    // 是否多选角色
                    if (this.MultiRoleSelect)
                    {
                        // 选择好后，关闭窗体
                        this.SelectRoleMulti(true, true,true);
                    }
                    else
                    {
                        this.SelectRole(true, true);
                    }
                }
                // 当前选择的是用户选项卡
                else if (this.tbcSelect.SelectedIndex == 2)
                {
                    // 设置当前操作对象类型
                    this.CurrentSelect = "ByUser";
                    // 是否多选用户
                    if (this.MultiUserSelect)
                    {
                        // 选择好后，关闭窗体
                        this.SelectUserMulti(true,true, true);
                    }
                    else
                    {
                        this.SelectUser(true, true);
                    }
                }
            }
        }            

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            // 当前选项卡在组织机构列表中
            if (this.tbcSelect.SelectedIndex == 0)
            {
                if (this.tcOrganizeTree.SelectedIndex == 1)
                {
                    foreach (DataGridViewRow dgvRow in grdOrganize.Rows)
                    {
                        dgvRow.Cells["colSelected"].Value = true;
                    }
                }
            }
            // 当前选项卡在角色列表中
            if (this.tbcSelect.SelectedIndex == 1)
            {

                foreach (DataGridViewRow dgvRow in this.grdRole.Rows)
                {
                    dgvRow.Cells["colSelected1"].Value = true;
                }
            }
            // 当前选项卡在用户列表中
            if (this.tbcSelect.SelectedIndex == 2)
            {
                foreach (DataGridViewRow dgvRow in this.grdUser.Rows)
                {
                    dgvRow.Cells["colSelected2"].Value = true;
                }
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            // 当前选项卡在组织机构列表中
            if (this.tbcSelect.SelectedIndex == 0)
            {
                if (this.tcOrganizeTree.SelectedIndex == 1)
                {
                    foreach (DataGridViewRow dgvRow in grdOrganize.Rows)
                    {
                        dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
                    }
                }
            }
            // 当前选项卡在角色列表中
            if (this.tbcSelect.SelectedIndex == 1)
            {

                foreach (DataGridViewRow dgvRow in grdRole.Rows)
                {
                    dgvRow.Cells["colSelected1"].Value = true;
                }
            }
            // 当前选项卡在用户列表中
            if (this.tbcSelect.SelectedIndex == 2)
            {
                foreach (DataGridViewRow dgvRow in grdUser.Rows)
                {
                    dgvRow.Cells["colSelected2"].Value = true;
                }
            }

        }

        //---------------------------------------------------------------
        //                     组织机构事件
        //---------------------------------------------------------------

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            this.DTOrganize = null;
            // 点击了F5按钮
            ClientCache.Instance.DTOrganize = null;
            this.FormOnLoad();
            // 设置查询条件
            this.SetSearch();
            this.FormLoaded = true;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void grdOrganize_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdOrganize);
            if (dataRow != null)
            {
                this.SelectedOrganizeId = dataRow[BaseOrganizeEntity.FieldId].ToString();
                this.SelectedOrganizeFullName = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    this.GetOrganizeList();
                }
            }
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            /*
            这里这么写了，性能太低了一些，会有重复执行情况发生
            if (this.FormLoaded)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    this.GetOrganizeList();
                }
            }
            */
        }

        private void chkInnerOrganize_CheckedChanged(object sender, EventArgs e)
        {
            //this.OnLoad(e);
            this.LoadOrganize();
        }

        private void tvOrganize_DoubleClick(object sender, EventArgs e)
        {
            //if (!BaseSystemInfo.OrganizeDynamicLoading)
            //{
            this.btnConfirm.PerformClick();
            //}
        }

        //---------------------------------------------------------------
        //                     角色事件
        //---------------------------------------------------------------

        private void rbtnDuty_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void cmbRoleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void grdRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiRoleSelect)
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdRole);
                if (dataRow != null)
                {
                    this.CurrentSelect = "ByRole";
                    this.GetSelectedRoleId(dataRow);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }


        //---------------------------------------------------------------
        //                     用户事件
        //---------------------------------------------------------------

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.MultiUserSelect)
            {
                // 不要关闭窗体
                this.SelectUserMulti(true,true,true);
            }
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch1.Text;
            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Rows.Count > 0)
                {
                    search = StringUtil.GetSearchString(search);
                    this.DTUser.DefaultView.RowFilter = StringUtil.GetLike(BaseUserEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldQuickQuery, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldCompanyName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDepartmentName, search)
                        + " OR " + StringUtil.GetLike(BaseUserEntity.FieldDescription, search);
                }
            }
            this.grdUser.DataSource = this.DTUser.DefaultView;
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            this.btnSearch1.Enabled = false;
            this.FormOnLoad(true, this.txtSearch1.Text);
            this.btnSearch1.Enabled = true;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] roleIds = (this.cmbRole.SelectedValue.ToString().Length == 0) ? null : new string[] { this.cmbRole.SelectedValue.ToString() };
            // 用户信息
            this.DTUser = DotNetService.Instance.UserService.Search(UserInfo, string.Empty, string.Empty, roleIds);

            this.grdUser.AutoGenerateColumns = false;
            this.DTUser.PrimaryKey = new DataColumn[] { this.DTUser.Columns[BaseUserEntity.FieldId] };
            this.DTUser.AcceptChanges();
            this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            this.grdUser.DataSource = this.DTUser.DefaultView;
            this.SetControlState();
        }

        private void grdUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: 若是单选功能，双击就表示选定了当前的数据了。
            if (!this.MultiUserSelect)
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdUser);
                if (dataRow != null)
                {
                    this.CurrentSelect = "ByUser";
                    this.SelectedUserId = dataRow[BaseUserEntity.FieldId].ToString();
                    this.SelectedUserFullName = dataRow[BaseUserEntity.FieldRealName].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private string[] GetSelectedFullNames()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdUser, BaseUserEntity.FieldRealName, "colSelected2", true);
        }

        private void tbcSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetControlState();
        }

        private void tcOrganizeTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetControlState();
        }

       
























    }
}
