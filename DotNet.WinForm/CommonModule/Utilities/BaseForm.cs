//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// BaseForm
    /// 
    /// 修改纪录
    /// 
    ///     2011.12.15 版本：1.3 zgl       修改public DataTable GetUserScope(string permissionItemScopeCode)方法，适应数据集权限的实施。
    ///     2011.04.05 版本：1.2 24 3 8   增加DataGridViewOnLoad方法。
    ///		2008.04.21 版本：1.1 JiRiGaLa 用户重新登录，扮演时的错误进行修正。
    ///		2008.01.11 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.21</date>
    /// </author> 
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// 只按对话框方式显示窗体
        /// </summary>
        public bool ShowDialogOnly = false;

        /// <summary>
        /// 是否记录窗体日志
        /// </summary>
        public bool RecordFormLog = false;

        /// <summary>
        /// 是否加在用户配置参数（表格）
        /// </summary>
        public bool LoadUserParameters = true;

        /// <summary>
        /// 访问权限
        /// </summary>
        public bool permissionAccess = false;                  

        /// <summary>
        /// 新增权限
        /// </summary>
        public bool permissionAdd = false;  
        
        /// <summary>
        /// 编辑权限
        /// </summary>
        public bool permissionEdit = false;
        
        /// <summary>
        /// 删除权限
        /// </summary>
        public bool permissionDelete = false;
        
        /// <summary>
        /// 导出权限
        /// </summary>
        public bool permissionExport = false;

        /// <summary>
        /// 查询权限
        /// </summary>
        public bool permissionSearch = false;
        

        public BaseForm()
        {
            if (!this.DesignMode)
            {
                // 必须放在初始化组件之前
                // this.GetIcon(); 
            }
            InitializeComponent();
        }

        public virtual void GetIcon()
        {
            if (System.IO.File.Exists(BaseSystemInfo.AppIco))
            {
                // XP 系统下这个程序会出错
                // this.Icon = new Icon(BaseSystemInfo.FormIco);
                this.Icon = new Icon(BaseSystemInfo.AppIco);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BaseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);

        }

        #region public virtual void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public virtual void GetPermission()
        {
        }
        #endregion

        #region public virtual void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public virtual void SetControlState()
        {
        }
        #endregion

        #region public virtual void SetControlState(bool enabled) 设置按钮状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="enabled">有效</param>
        public virtual void SetControlState(bool enabled)
        {
        }
        #endregion

        #region public virtual void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public virtual void SetHelp()
        {
        }
        #endregion

        #region public virtual void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public virtual void ShowEntity()
        {
        }
        #endregion

        #region public virtual void GetList() 获得列表数据
        /// <summary>
        /// 获得列表数据
        /// </summary>
        public virtual void GetList()
        {
        }
        #endregion

        #region public virtual bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public virtual bool CheckInput()
        {
            return true;
        }
        #endregion

        #region public virtual bool SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public virtual bool SaveEntity()
        {
            return true;
        }
        #endregion

        #region public virtual int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public virtual int BatchDelete()
        {
            return 0;
        }
        #endregion

        #region public virtual bool CheckInputDelete() 检查批量删除
        /// <summary>
        /// 检查批量删除
        /// </summary>
        /// <returns>允许删除</returns>
        public virtual bool CheckInputDelete()
        {
            return true;
        }
        #endregion

        #region public bool IsAuthorized(string permissionItemCode, string permissionItemName = string.Empty) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>有权限</returns>
        public bool IsAuthorized(string permissionItemCode, string permissionItemName = null)
        {
            // 默认为了安全起见、设置为无权限比较好
            bool returnValue = false;
            // 先判断用户是否超级管理员，若是超级管理员，就不用判断操作权限了（这个是有点儿C/S的特色）

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                if (UserInfo.IsAdministrator)
                {
                    return true;
                }
            #endif

            // 若不使用操作权限项定义，那就所有操作权限都是不用生效了
            if (!BaseSystemInfo.UsePermissionItem)
            {
                return true;
            }

            /*            
            // 这里是判断本地缓存里，操作权限是否为空？
            if (ClientCache.Instance.DTPermission == null)
            {
                // return false;
                // 重新读取本地缓存里的操作权限
                ClientCache.Instance.GetPermission(this.UserInfo);
            }            
            // 直接判断是否有相应的操作权限
            returnValue = BaseBusinessLogic.IsAuthorized(ClientCache.Instance.DTPermission, permissionItemCode);
            if (returnValue))
            {
                return true;
            }            
            returnValue = BaseBusinessLogic.IsAuthorized(ClientCache.Instance.DTPermission, permissionItemCode);

            // 查看看是否设置了操作权限映射关系表
            string fileName = Application.StartupPath + "\\" + "PermissionMapping.xml";
            if (System.IO.File.Exists(fileName))
            {
                // 获得映射的操作权限编号
                string code = ConfigHelper.GetValue(fileName, permissionItemCode);
                if (!String.IsNullOrEmpty(code))
                {
                    permissionItemCode = code;
                }
            }
            */

            // 虽然这样读取权限效率低一些，但是会及时性高一些，例如这个时候正好权限被调整了
            // 这里是在服务器上进行权限判断，远程进行权限判断（B/S的都用这个方法直接判断权限）
            if (!returnValue)
            {
                DotNetService dotNetService = new DotNetService();
                returnValue = dotNetService.PermissionService.IsAuthorizedByUser(this.UserInfo, this.UserInfo.Id, permissionItemCode, permissionItemName);
                if (dotNetService.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionService).Close();
                }
            }
            return returnValue;
        }
        #endregion

        public void WriteException(Exception ex)
        {
            // 在本地记录异常
            FileUtil.WriteException(UserInfo, ex);
        }

        /// <summary>
        /// 处理异常信息
        /// </summary>
        /// <param name="exception">异常</param>
        public void ProcessException(Exception ex)
        {
            this.WriteException(ex);
            // 显示异常页面
            FrmException frmException = new FrmException(ex);
            frmException.ShowDialog();
        }

        private string entityId = string.Empty;
        /// <summary>
        /// 实体主键
        /// </summary>
        public virtual string EntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }        

        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        public bool ExitApplication = false;

        /// <summary>
        /// 窗体已经加载完毕
        /// </summary>
        public bool FormLoaded      = false;

        /// <summary>
        /// 是否忙碌状态
        /// </summary>
        public bool Busyness        = false;
        
        /// <summary>
        /// 数据发生过变化
        /// </summary>
        public bool Changed         = false;

        /// <summary>
        /// 当前日志主键
        /// </summary>
        public string LogId = string.Empty;

        /// <summary>
        /// 设置按钮的可用状态
        /// </summary>
        /// <param name="setTop">置顶</param>
        /// <param name="setUp">上移</param>
        /// <param name="setDown">下移</param>
        /// <param name="setBottom">置底</param>
        /// <param name="add">添加</param>
        /// <param name="edit">编辑</param>
        /// <param name="batchDelete">批量删除</param>
        /// <param name="batchSave">批量保存</param>
        public delegate void SetControlStateEventHandler(bool setTop, bool setUp, bool setDown, bool setBottom, bool add, bool edit, bool batchDelete, bool batchSave);

        /// <summary>
        /// 当前用户信息
        /// 这里表示是只读的
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        #region public void Localization(Form form) 多语言国际化加载
        /// <summary>
        /// 多语言国际化加载
        /// </summary>
        public void Localization(Form form)
        {
            BaseInterfaceLogic.SetLanguageResource(form);
        }
        #endregion

        #region public void LoadUserParameter(Form form) 客户端页面配置加载
        /// <summary>
        /// 客户端页面配置加载
        /// </summary>
        public void LoadUserParameter(Form form)
        {
            BaseInterfaceLogic.LoadDataGridViewColumnWidth(form);
        }
        #endregion

        public virtual void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // 按键事件
            if (e.KeyCode == Keys.F5)
            {
                // F5刷新，重新加载窗体
                this.FormOnLoad();
            }
            else
            {
                // 按了回车按钮处理光标焦点
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    if ((this.ActiveControl is TextBox) || (this.ActiveControl is ComboBox) || (this.ActiveControl is CheckBox))
                    {
                        if ((this.ActiveControl is TextBox) && ((TextBox)this.ActiveControl).Multiline)
                        {
                            return;
                        }
                        SendKeys.Send("{TAB}");
                    }
                }
            }
            if (e.KeyCode == Keys.F10)
            {
                Image iA = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(iA);
                g.CopyFromScreen(new Point(this.Location.X, this.Location.Y), new Point(0, 0), new Size(this.Width, this.Height));
                Clipboard.SetImage(iA);
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.ShowDialog();
            }
        }
        
        #region public virtual void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public virtual void FormOnLoad()
        {            
        }
        #endregion

        public virtual void Form_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                try
                {
                    if (!this.DesignMode)
                    {
                        // 是否记录访问日志
                        if (BaseSystemInfo.RecordLog)
                        {
                            // 已经登录了系统了，才记录日志
                            if (BaseSystemInfo.UserIsLogOn)
                            {
                                // 调用服务事件
                                if (this.RecordFormLog)
                                {
                                    // 调用服务事件
                                    // this.LogId = DotNetService.Instance.LogService.WriteLog(UserInfo, this.Name, this.Text, "FormLoad");
                                    DotNetService dotNetService = new DotNetService();
                                    dotNetService.LogService.WriteLog(UserInfo, this.Name, AppMessage.GetMessage(this.Name), "FormLoad", AppMessage.LoadWindow);
                                    if (dotNetService.LogService is ICommunicationObject)
                                    {
                                        ((ICommunicationObject)dotNetService.LogService).Close();
                                    }
                                }
                            }
                        }
                    }

                    // 必须放在初始化组件之前
                    this.GetIcon();
                    // 获得页面的权限
                    this.GetPermission();
                    // 加载窗体
                    this.FormOnLoad();
                    // 设置按钮状态
                    this.SetControlState();
                    if (BaseSystemInfo.MultiLanguage)
                    {
                        // 多语言国际化加载
                        if (ResourceManagerWrapper.Instance.GetLanguages() != null)
                        {
                            this.Localization(this);
                        }
                    }
                    if (this.LoadUserParameters)
                    {
                        // 客户端页面配置加载
                        this.LoadUserParameter(this);
                    }
                    // 设置帮助
                    this.SetHelp();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    this.FormLoaded = true;
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }

        /// <summary>
        /// 获取组织机构权限域数据
        /// </summary>
        public DataTable GetOrganizeScope(string permissionItemScopeCode, bool isInnerOrganize)
        {
            // 获取部门数据，不启用权限域
            DataTable dataTable = new DataTable(BaseOrganizeEntity.TableName);
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!BaseSystemInfo.UsePermissionScope)))
            {
                dataTable = ClientCache.Instance.GetOrganizeDT(UserInfo).Copy();
                if (isInnerOrganize)
                {
                    BaseBusinessLogic.SetFilter(dataTable, BaseOrganizeEntity.FieldIsInnerOrganize, "1");
                    BaseInterfaceLogic.CheckTreeParentId(dataTable, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
                }
                dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            }
            else
            {
                DotNetService dotNetService = new DotNetService();
                dataTable = dotNetService.PermissionService.GetOrganizeDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                if (dotNetService.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionService).Close();
                }
                if (isInnerOrganize)
                {
                    BaseBusinessLogic.SetFilter(dataTable, BaseOrganizeEntity.FieldIsInnerOrganize, "1");
                    BaseInterfaceLogic.CheckTreeParentId(dataTable, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
                }
                dataTable.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;                
            }
            return dataTable;
        }

        /// <summary>
        /// 获取用户权限域数据
        /// </summary>
        public DataTable GetUserScope(string permissionItemScopeCode)
        {
            // 是否有用户管理权限，若有用户管理权限就有所有的用户类表，这个应该是内置的操作权限
            bool userAdmin = false;
            userAdmin = this.IsAuthorized("UserAdmin");
            DataTable returnValue = new DataTable(BaseUserEntity.TableName);
            // 获取用户数据
            DotNetService dotNetService = new DotNetService();
            if (userAdmin)
            {
                if (this.UserInfo.IsAdministrator||(String.IsNullOrEmpty(permissionItemScopeCode)))
                {
                    returnValue = dotNetService.UserService.GetDataTable(UserInfo);
                    if (dotNetService.UserService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.UserService).Close();
                    }
                }
                else
                {
                    returnValue = dotNetService.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                    if (dotNetService.PermissionService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.PermissionService).Close();
                    }
                }
                    
            }
            return returnValue;
        }

        /// <summary>
        /// 获取员工权限域数据
        /// </summary>
        public DataTable GetRoleScope(string permissionItemScopeCode)
        {
            // 获取部门数据
            DataTable returnValue = new DataTable(BaseOrganizeEntity.TableName);
            DotNetService dotNetService = new DotNetService();
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode)))
            {
                returnValue = dotNetService.RoleService.GetDataTable(UserInfo);
                if (dotNetService.RoleService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.RoleService).Close();
                }
            }
            else
            {
                returnValue = dotNetService.PermissionService.GetRoleDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                if (dotNetService.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionService).Close();
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 获取模块菜单限域数据
        /// </summary>
        public DataTable GetModuleScope(string permissionItemScopeCode)
        {
            DotNetService dotNetService = new DotNetService();
            // 获取部门数据
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode)))
            {
                DataTable dtModule = dotNetService.ModuleService.GetDataTable(UserInfo);
                if (dotNetService.ModuleService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.ModuleService).Close();
                }
                // 这里需要只把有效的模块显示出来
                // BaseBusinessLogic.SetFilter(dtModule, BaseModuleEntity.FieldEnabled, "1");
                // 未被打上删除标标志的
                // BaseBusinessLogic.SetFilter(dtModule, BaseModuleEntity.FieldDeletionStateCode, "0");
                return dtModule;
            }
            else
            {
                DataTable dataTable = dotNetService.PermissionService.GetModuleDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                if (dotNetService.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionService).Close();
                }
                BaseInterfaceLogic.CheckTreeParentId(dataTable, BaseModuleEntity.FieldId, BaseModuleEntity.FieldParentId);
                return dataTable;
            }            
        }

        /// <summary>
        /// 获取授权范围数据 （按道理，应该是在某个数据区域上起作用）
        /// </summary>
        public DataTable GetPermissionItemScop(string permissionItemScopeCode)
        {
            // 获取部门数据
            DataTable dtPermissionItem = new DataTable(BasePermissionItemEntity.TableName);
            DotNetService dotNetService = new DotNetService();
            if (UserInfo.IsAdministrator)
            {
                dtPermissionItem = dotNetService.PermissionItemService.GetDataTable(UserInfo);
                if (dotNetService.PermissionItemService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionItemService).Close();
                }
                // 这里需要只把有效的模块显示出来
                // BaseBusinessLogic.SetFilter(dtPermissionItem, BasePermissionItemEntity.FieldEnabled, "1");
                // 未被打上删除标标志的
                // BaseBusinessLogic.SetFilter(dtPermissionItem, BasePermissionItemEntity.FieldDeletionStateCode, "0");
                
            }
            else
            {
                dtPermissionItem = dotNetService.PermissionService.GetPermissionItemDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                if (dotNetService.PermissionService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.PermissionService).Close();
                }
                BaseInterfaceLogic.CheckTreeParentId(dtPermissionItem, BasePermissionItemEntity.FieldId, BasePermissionItemEntity.FieldParentId);
            }
            return dtPermissionItem;
        }

        #region public bool ModuleIsVisible(string formName) 模块是否可见
        /// <summary>
        /// 模块是否可见
        /// </summary>
        /// <param name="formName">模块编号</param>
        /// <returns>有权限</returns>
        public bool ModuleIsVisible(string formName)
        {
            bool returnValue = false;
            foreach (DataRow dataRow in ClientCache.Instance.DTMoule.Rows)
            {
                if (dataRow[BaseModuleEntity.FieldCode].ToString().Equals(formName) 
                    || dataRow[BaseModuleEntity.FieldFormName].ToString().Equals(formName))
                {
                    returnValue = dataRow[BaseModuleEntity.FieldEnabled].ToString().Equals("1");
                    break;
                }
            }
            // 模块是否可见;
            return returnValue;
        }
        #endregion

        #region public bool IsModuleAuthorized(string formName) 模块是否有权限访问
        /// <summary>
        /// 模块是否有权限访问
        /// </summary>
        /// <param name="formName">模块编号</param>
        /// <returns>有权限</returns>
        public bool IsModuleAuthorized(string formName)
        {
            bool returnValue = false;
            // 1：是否超级管理员？若是超级管理员，什么模块都是能访问的，这是为了提高判断程序的执行效率
            if (this.UserInfo.IsAdministrator)
            {
                returnValue = true;
                return returnValue;
            }
            // 2：是否已经设置为公开？公开的模块谁都可以访问的
            foreach (DataRow dataRow in ClientCache.Instance.DTMoule.Rows)
            {
                if (dataRow[BaseModuleEntity.FieldFormName].ToString().Equals(formName))
                {
                    returnValue = dataRow[BaseModuleEntity.FieldIsPublic].ToString().Equals("1");
                    break;
                }
            }
            // 3：当前用户是否有模块访问权限？（已包含用户的、角色的模块访问权限）
            if (!returnValue)
            {
                foreach (DataRow dataRow in ClientCache.Instance.DTUserMoule.Rows)
                {
                    if (dataRow[BaseModuleEntity.FieldFormName].ToString().Equals(formName))
                    {
                        returnValue = true;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region private bool FileExist(string fileName) 检查文件是否存在
        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>是否存在</returns>
        private bool FileExist(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                string targetFileName = System.IO.Path.GetFileName(fileName);
                if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0236, targetFileName), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.IO.File.Delete(fileName);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region private void ExportExcel(DataGridView dataGridView, DataView dataView, string directory, string fileName) 导出Excel
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dataGridView">表格控件</param>
        /// <param name="dataView">数据表格</param>
        /// <param name="directory">目录</param>
        /// <param name="fileName">文件名</param>
        public void ExportExcel(DataGridView dataGridView, DataView dataView, string directory, string fileName)
        {
            string directoryName = BaseSystemInfo.StartupPath + directory;
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            // 这里显示选择文件的对话框，可以取消导出可以确认导出，可以修改文件名。
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            fileName = BaseSystemInfo.StartupPath + directory + fileName;
            saveFileDialog.InitialDirectory = directoryName;
            //saveFileDialog.Filter = "导出数据文件(*.csv)|*.csv|所有文件|*.*";
            saveFileDialog.Filter = "Excel(*.xls)|*.xls|所有文件|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出数据文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;   
                fileName = saveFileDialog.FileName;

                // 2012.04.02 Pcsky 增加 判断文件是否被打开
                //if (BaseExportExcel.CheckIsOpened(fileName))
                //{
                //    MessageBox.Show("Excel文件已经打开,请关闭后重试!", "提示");
                //    return;
                //}

                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                // BaseExportCSV.ExportCSV(dataGridView, dataView, fileName);
                // 2012.04.02 Pcsky 增加新的导出Excel方法，非Com+方式，改用.Net控件
                //BaseExportExcel.ExportXlsByNPOI(dataGridView, dataView, fileName);

                // 已经忙完了
                this.Cursor = holdCursor;
                Process.Start(fileName);
            }
        }
        #endregion


        #region private void ExportExcel(System.Data.DataTable dataTable, Dictionary<string,string> fieldList, string directory, string fileName) 导出Excel
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dataGridView">表格控件</param>
        /// <param name="dataTable">数据表格</param>
        /// <param name="fieldList">数据表字段名-说明对应列表</param>
        /// <param name="directory">目录</param>
        /// <param name="fileName">文件名</param>
        public void ExportExcel(System.Data.DataTable dataTable, System.Collections.Generic.Dictionary<string, string> fieldList, string directory, string fileName)
        {
            string directoryName = BaseSystemInfo.StartupPath + directory;
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            // 这里显示选择文件的对话框，可以取消导出可以确认导出，可以修改文件名。
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            fileName = BaseSystemInfo.StartupPath + directory + fileName;
            saveFileDialog.InitialDirectory = directoryName;
            //saveFileDialog.Filter = "导出数据文件(*.csv)|*.csv|所有文件|*.*";
            saveFileDialog.Filter = "Excel(*.xls)|*.xls|所有文件|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出数据文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                fileName = saveFileDialog.FileName;

                // 2012.04.02 Pcsky 增加 判断文件是否被打开
                //if (BaseExportExcel.CheckIsOpened(fileName))
                //{
                //    MessageBox.Show("Excel文件已经打开,请关闭后重试!", "提示");
                //    return;
                //}

                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                // BaseExportCSV.ExportCSV(dataGridView, dataView, fileName);
                // 2012.04.02 Pcsky 增加新的导出Excel方法，非Com+方式，改用.Net控件
                //BaseExportExcel.ExportXlsByNPOI(dataTable, fieldList, fileName);

                // 已经忙完了
                this.Cursor = holdCursor;
                Process.Start(fileName);
            }
        }
        #endregion

        public void ExportExcel(DataGridView dataGridView, string directory, string fileName)
        {
            ExportExcel(dataGridView, (DataView)(dataGridView.DataSource), directory, fileName);
        }

        #region private void FormOnClosed() 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void FormOnClosed()
        {
            if (!this.DesignMode)
            {
                // 是否记录访问日志，已经登录了系统了，才记录日志
                if (BaseSystemInfo.RecordLog && BaseSystemInfo.UserIsLogOn)
                {
                    // 保存列宽
                    BaseInterfaceLogic.SaveDataGridViewColumnWidth(this);
                    // 调用服务事件
                    if (this.RecordFormLog)
                    {
                        DotNetService dotNetService = new DotNetService();
                        dotNetService.LogService.WriteExit(UserInfo, this.LogId);
                        if (dotNetService.LogService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.LogService).Close();
                        }
                    }
                }
            }
        }
        #endregion

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.FormOnClosed();
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

        #region private void DataGridViewOnLoad(object sender, DataGridViewRowPostPaintEventArgs e) DGV加载
        /// <summary>
        /// DataGridView加载
        /// </summary>
        public void DataGridViewOnLoad(DataGridView grd)
        {
            grd.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView_RowPostPaint);
        }

        public void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号右对齐
            //Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            //    e.RowBounds.Location.Y,
            //    (sender as DataGridView).RowHeadersWidth - 4,
            //    e.RowBounds.Height);

            //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            //    (sender as DataGridView).RowHeadersDefaultCellStyle.Font,
            //    rectangle,
            //    (sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor,
            //    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            //序号居中
            //定义一个画笔，颜色用行标题的前景色填充
            SolidBrush solidBrush = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            //得到当前行的行号
            int rowIndex = e.RowIndex + 1;
            //DataGridView的RowHeadersWidth 为了算中间位置
            int rowHeadersWidth = (sender as DataGridView).RowHeadersWidth;
            //根据宽度与显示的字符数计算中间位置
            int rowHeadersX = (rowHeadersWidth - rowIndex.ToString().Length * 6) / 2;
            int rowHeadersY = e.RowBounds.Location.Y + 4;
            e.Graphics.DrawString((rowIndex).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, solidBrush, rowHeadersX, rowHeadersY);
        }
        #endregion

        /// <summary>
        /// 业务数据库部分
        /// </summary>
        private IDbHelper dbHelper = null;

        /// <summary>
        /// 业务数据库部分
        /// </summary>
        protected IDbHelper DbHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    // 当前数据库连接对象
                    dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType, BaseSystemInfo.BusinessDbConnection);
                }
                return dbHelper;
            }
        }

        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        private IDbHelper userCenterDbHelper = null;

        /// <summary>
        /// 用户中心数据库部分
        /// </summary>
        protected IDbHelper UserCenterDbHelper
        {
            get
            {
                if (userCenterDbHelper == null)
                {
                    // 当前数据库连接对象
                    userCenterDbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
                }
                return userCenterDbHelper;
            }
        }

        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        private IDbHelper workFlowDbHelper = null;

        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        protected IDbHelper WorkFlowDbHelper
        {
            get
            {
                if (workFlowDbHelper == null)
                {
                    // 当前数据库连接对象
                    workFlowDbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
                }
                return workFlowDbHelper;
            }
        }
    }
}