//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmTableScopeConstraint.cs
    /// 表数据权限
    ///		
    /// 修改记录
    /// 
    ///     2011.10.19 版本：2.1 JiRiGaLa  表达式优化。
    ///     2011.10.15 版本：2.0 JiRiGaLa  优化调用方式。
    ///     2011.05.16 版本：1.0 JiRiGaLa  模块配置。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.19</date>
    /// </author> 
    /// </summary>
    public partial class FrmTableScopeConstraint : BaseForm
    {
        public FrmTableScopeConstraint()
        {
            InitializeComponent();
        }

        public FrmTableScopeConstraint(string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission")
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.TableName = tableName;
            this.PermissionCode = permissionCode;
            this.TableConstraint = null;
        }

        public FrmTableScopeConstraint(string resourceCategory, string resourceId, string tableName, string tableConstraint, bool enabled = true)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.TableName = tableName;
            this.TableConstraint = tableConstraint;
            this.chkEnabled.Checked = enabled;
        }

        private string permissionCode = "Resource.AccessPermission";
        ///<summary>
        /// 什么操作权限
        ///</summary>
        public string PermissionCode
        {
            get
            {
                return permissionCode;
            }
            set
            {
                permissionCode = value;
            }
        }

        private string resourceCategory = string.Empty;
        ///<summary>
        /// 什么类型的
        ///</summary>
        public string ResourceCategory
        {
            get
            {
                return resourceCategory;
            }
            set
            {
                resourceCategory = value;
            }
        }

        private string resourceId = string.Empty;
        ///<summary>
        /// 什么资源
        ///</summary>
        public string ResourceId
        {
            get
            {
                return resourceId;
            }
            set
            {
                resourceId = value;
            }
        }

        private string tableName = string.Empty;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        private string tableRealName = string.Empty;
        /// <summary>
        /// 表全名
        /// </summary>
        public string TableRealName
        {
            get
            {
                return tableRealName;
            }
            set
            {
                tableRealName = value;
            }
        }


        private string tableConstraint = string.Empty;
        /// <summary>
        /// 条件表达式
        /// </summary>
        public string TableConstraint
        {
            get
            {
                return tableConstraint;
            }
            set
            {
                tableConstraint = value;
            }
        }

        // 表字段的绑定(有效的，未必删除的，是采用约束条件的)
        DataTable DTColumns = new DataTable(BaseTableColumnsEntity.TableName);

        private void GetTableRealName()
        {
            if (!string.IsNullOrEmpty(this.TableName))
            {
                DataTable dt = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, "ItemsTablePermissionScope");
                this.TableRealName = BaseBusinessLogic.GetProperty(dt, BaseItemDetailsEntity.FieldItemCode, this.TableName, BaseItemDetailsEntity.FieldItemName);
                this.Text = this.Text + " " + TableRealName;
            }
        }

        private void GetConstraint()
        {
            if (string.IsNullOrEmpty(this.TableConstraint))
            {
                BasePermissionScopeEntity permissionScopeEntity = DotNetService.Instance.TableColumnsService.GetConstraintEntity(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TableName, this.PermissionCode);
                if (permissionScopeEntity != null)
                {
                    this.TableConstraint = permissionScopeEntity.PermissionConstraint;
                    this.chkEnabled.Checked = (permissionScopeEntity.Enabled == 1);
                }
            }
            if (!string.IsNullOrEmpty(this.TableConstraint))
            {
                this.txtTableConstraint.Text = this.TableConstraint;
            }
        }

        private void GetResourceInfo()
        {
            if (this.ResourceCategory == BaseRoleEntity.TableName)
            {
                this.txtUserOrRole.Text = DotNetService.Instance.RoleService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            if (this.ResourceCategory == BaseUserEntity.TableName)
            {
                this.txtUserOrRole.Text = DotNetService.Instance.UserService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetResourceInfo();
            this.GetTableRealName();
            this.GetConstraint();
            // 获取分类列表
            this.BindItemDetails();
            // 显示表达式
            this.ShowConstraint(this.TableConstraint);
            // 参数参考
            this.txtParameterReference.Text = ConstraintUtil.ParameterReference;
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定条件数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Condition");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);

            this.cmbCondition0.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCondition0.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbCondition0.DataSource = dataTable.Copy().DefaultView;

            this.cmbCondition1.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCondition1.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbCondition1.DataSource = dataTable.Copy().DefaultView;

            this.cmbCondition2.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCondition2.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbCondition2.DataSource = dataTable.Copy().DefaultView;

            this.cmbCondition3.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCondition3.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbCondition3.DataSource = dataTable.Copy().DefaultView;

            this.cmbCondition4.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbCondition4.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbCondition4.DataSource = dataTable.Copy().DefaultView;

            if (!string.IsNullOrEmpty(this.TableName))
            {
                // 表字段的绑定(有效的，未必删除的，是采用约束条件的)
                DTColumns = DotNetService.Instance.TableColumnsService.GetDataTableByTable(UserInfo, this.TableName);

                DataRow dataRowColumns = DTColumns.NewRow();
                DTColumns.Rows.InsertAt(dataRowColumns, 0);
                this.cmbColumn0.DisplayMember = BaseTableColumnsEntity.FieldColumnName;
                this.cmbColumn0.ValueMember = BaseTableColumnsEntity.FieldColumnCode;
                this.cmbColumn0.DataSource = DTColumns.Copy().DefaultView;

                this.cmbColumn1.DisplayMember = BaseTableColumnsEntity.FieldColumnName;
                this.cmbColumn1.ValueMember = BaseTableColumnsEntity.FieldColumnCode;
                this.cmbColumn1.DataSource = DTColumns.Copy().DefaultView;

                this.cmbColumn2.DisplayMember = BaseTableColumnsEntity.FieldColumnName;
                this.cmbColumn2.ValueMember = BaseTableColumnsEntity.FieldColumnCode;
                this.cmbColumn2.DataSource = DTColumns.Copy().DefaultView;

                this.cmbColumn3.DisplayMember = BaseTableColumnsEntity.FieldColumnName;
                this.cmbColumn3.ValueMember = BaseTableColumnsEntity.FieldColumnCode;
                this.cmbColumn3.DataSource = DTColumns.Copy().DefaultView;

                this.cmbColumn4.DisplayMember = BaseTableColumnsEntity.FieldColumnName;
                this.cmbColumn4.ValueMember = BaseTableColumnsEntity.FieldColumnCode;
                this.cmbColumn4.DataSource = DTColumns.Copy().DefaultView;
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnDelete.Enabled = true;
            this.btnTestConstraint.Enabled = true;
            this.btnSave.Enabled = true;
        }
        #endregion

        private void ShowConstraint(string constraint)
        {
            // 这里需要把字符解析出来。
            string subConstraint0 = string.Empty;
            string subConstraint1 = string.Empty;
            string subConstraint2 = string.Empty;
            string subConstraint3 = string.Empty;
            string subConstraint4 = string.Empty;

            if (!string.IsNullOrEmpty(constraint))
            {
                string[] constraints = constraint.Split(new string[] { "  " }, StringSplitOptions.None);
                if (constraints != null)
                {
                    if (constraints.Length > 4)
                    {
                        subConstraint4 = constraints[4].Trim();
                    }
                    if (constraints.Length > 3)
                    {
                        subConstraint3 = constraints[3].Trim();
                    }
                    if (constraints.Length > 2)
                    {
                        subConstraint2 = constraints[2].Trim();
                    }
                    if (constraints.Length > 1)
                    {
                        subConstraint1 = constraints[1].Trim();
                    }
                    if (constraints.Length > 0)
                    {
                        subConstraint0 = constraints[0].Trim();
                    }
                }
            }

            this.ShowSubCondition(subConstraint0, this.cmbLeftBrackets0, this.cmbColumn0, this.cmbCondition0, this.txtValue0, this.cmbValue0, this.cmbRightBrackets0, this.cmbAnd0);
            this.ShowSubCondition(subConstraint1, this.cmbLeftBrackets1, this.cmbColumn1, this.cmbCondition1, this.txtValue1, this.cmbValue1, this.cmbRightBrackets1, this.cmbAnd1);
            this.ShowSubCondition(subConstraint2, this.cmbLeftBrackets2, this.cmbColumn2, this.cmbCondition2, this.txtValue2, this.cmbValue2, this.cmbRightBrackets2, this.cmbAnd2);
            this.ShowSubCondition(subConstraint3, this.cmbLeftBrackets3, this.cmbColumn3, this.cmbCondition3, this.txtValue3, this.cmbValue3, this.cmbRightBrackets3, this.cmbAnd3);
            this.ShowSubCondition(subConstraint4, this.cmbLeftBrackets4, this.cmbColumn4, this.cmbCondition4, this.txtValue4, this.cmbValue4, this.cmbRightBrackets4);
        }

        private void SetColumValue(ComboBox cmbColumn, string selectedValue)
        {
            selectedValue = selectedValue.Trim();
            for (int i = 0; i < cmbColumn.Items.Count; i++)
            {
                DataRowView dataRowView = (DataRowView)cmbColumn.Items[i];
                if (dataRowView[cmbColumn.ValueMember].ToString().Equals(selectedValue))
                {
                    cmbColumn.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ShowSubCondition(string subConstraint, ComboBox cmbLeftBrackets, ComboBox cmbColumn, ComboBox cmbCondition, TextBox txtValue, ComboBox cmbValue, ComboBox cmbRightBrackets, ComboBox cmbAnd = null)
        {
            // 这里是需要把每个解析出来的条件显示出来
            if (string.IsNullOrEmpty(subConstraint))
            {
                return;
            }

            if (cmbAnd != null)
            {
                if (subConstraint.EndsWith(" or"))
                {
                    subConstraint = subConstraint.Substring(0, subConstraint.Length - 3);
                    cmbAnd.Text = "or";
                }
                else if (subConstraint.EndsWith(" and"))
                {
                    subConstraint = subConstraint.Substring(0, subConstraint.Length - 4);
                    cmbAnd.Text = "and";
                }
            }

            if (subConstraint.Substring(0, 1).Equals("("))
            {
                cmbLeftBrackets.Text = "(";
                subConstraint = subConstraint.Substring(1);
            }

            if (subConstraint.Substring(subConstraint.Length - 1).Equals(")"))
            {
                cmbRightBrackets.Text = ")";
                subConstraint = subConstraint.Substring(0, subConstraint.Length - 1);
            }

            string[] constraints = subConstraint.Split(new string[] { " " }, StringSplitOptions.None);
            if (constraints != null && constraints.Length > 2)
            {
                // 这里是字段
                this.SetColumValue(cmbColumn, constraints[0]);
                // 这里是条件
                this.SetColumValue(cmbCondition, constraints[1]);
                // 这里是处理显示下拉框还是文本框
                string selectedValue = subConstraint.Substring(constraints[0].Length + constraints[1].Length + 2).Trim('\'');
                this.ColumnSelected(cmbColumn, selectedValue);
                // 这里是值
                if (txtValue.Visible)
                {
                    txtValue.Text = selectedValue;
                }
            }
        }

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
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                }
            }
            return returnValue;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 左边括号
            this.cmbLeftBrackets0.SelectedIndex = -1;
            this.cmbLeftBrackets1.SelectedIndex = -1;
            this.cmbLeftBrackets2.SelectedIndex = -1;
            this.cmbLeftBrackets3.SelectedIndex = -1;
            this.cmbLeftBrackets4.SelectedIndex = -1;
            // 清除字段
            this.cmbColumn0.SelectedIndex = -1;
            this.cmbColumn1.SelectedIndex = -1;
            this.cmbColumn2.SelectedIndex = -1;
            this.cmbColumn3.SelectedIndex = -1;
            this.cmbColumn4.SelectedIndex = -1;
            // 清除条件
            this.cmbCondition0.SelectedIndex = -1;
            this.cmbCondition1.SelectedIndex = -1;
            this.cmbCondition2.SelectedIndex = -1;
            this.cmbCondition3.SelectedIndex = -1;
            this.cmbCondition4.SelectedIndex = -1;
            // 清除内容
            this.txtValue0.Text = string.Empty;
            this.txtValue1.Text = string.Empty;
            this.txtValue2.Text = string.Empty;
            this.txtValue3.Text = string.Empty;
            this.txtValue4.Text = string.Empty;
            // 右边括号
            this.cmbRightBrackets0.SelectedIndex = -1;
            this.cmbRightBrackets1.SelectedIndex = -1;
            this.cmbRightBrackets2.SelectedIndex = -1;
            this.cmbRightBrackets3.SelectedIndex = -1;
            this.cmbRightBrackets4.SelectedIndex = -1;
            // 条件表达式
            this.cmbAnd0.SelectedIndex = -1;
            this.cmbAnd1.SelectedIndex = -1;
            this.cmbAnd2.SelectedIndex = -1;
            this.cmbAnd3.SelectedIndex = -1;
            // 约束条件
            this.txtTableConstraint.Text = string.Empty;
        }

        /// <summary>
        /// 获取子条件表达式
        /// </summary>
        /// <param name="cmbColumn">字段</param>
        /// <param name="cmbCondition">条件</param>
        /// <param name="txtValue">值</param>
        /// <returns>条件限制</returns>
        private string GetSubConstraint(ComboBox cmbLeftBrackets, ComboBox cmbColumn, ComboBox cmbCondition, TextBox txtValue, ComboBox cmbValue, ComboBox cmbRightBrackets, ComboBox cmbAnd = null)
        {
            string subConstraint = string.Empty;
            if (cmbColumn.SelectedValue == null)
            {
                return subConstraint;
            }
            string columnCode = cmbColumn.SelectedValue.ToString();
            if (string.IsNullOrEmpty(columnCode))
            {
                return subConstraint;
            }

            string constraintValue = string.Empty;
            string dataType = BaseBusinessLogic.GetProperty(DTColumns, BaseTableColumnsEntity.FieldColumnCode, columnCode, BaseTableColumnsEntity.FieldDataType);
            if (string.IsNullOrEmpty(dataType))
            {
                dataType = "string";
            }
            if (txtValue.Visible)
            {
                if (cmbColumn.SelectedValue != null && (!string.IsNullOrEmpty(cmbColumn.SelectedValue.ToString()))
                   && cmbCondition.SelectedValue != null && (!string.IsNullOrEmpty(cmbCondition.SelectedValue.ToString()))
                   && (!string.IsNullOrEmpty(txtValue.Text)))
                {
                    if (dataType.ToUpper() == "INT"
                        || dataType.ToUpper() == "DOUBLE"
                        || dataType.ToUpper() == "INTEGER")
                    {
                        constraintValue = txtValue.Text;
                    }
                    else
                    {
                        constraintValue = "\'" + txtValue.Text + "\'";
                    }
                }
            }
            if (cmbValue.Visible)
            {
                if (cmbColumn.SelectedValue != null && (!string.IsNullOrEmpty(cmbColumn.SelectedValue.ToString()))
                   && cmbCondition.SelectedValue != null && (!string.IsNullOrEmpty(cmbCondition.SelectedValue.ToString()))
                   && (!string.IsNullOrEmpty(cmbValue.SelectedValue.ToString())))
                {
                    // 如果是数值的、真假类型的？（将来有时间了改进）
                    // subConstraint = cmbColumn.SelectedValue.ToString() + " " + cmbCondition.SelectedValue.ToString() + " " + cmbValue.SelectedValue.ToString();
                    // 如果是字符类型的，需要补充加单引号的
                    if (dataType.ToUpper() == "INT"
                        || dataType.ToUpper() == "DOUBLE"
                        || dataType.ToUpper() == "INTEGER")
                    {
                        constraintValue = cmbValue.SelectedValue.ToString();
                    }
                    else
                    {
                        constraintValue = "\'" + cmbValue.SelectedValue.ToString() + "\'";
                    }
                }
            }

            string leftBrackets = "";
            if (cmbLeftBrackets.SelectedItem != null)
            {
                leftBrackets = cmbLeftBrackets.SelectedItem.ToString();
            }
            string rightBrackets = "";
            if (cmbRightBrackets.SelectedItem != null)
            {
                rightBrackets = cmbRightBrackets.SelectedItem.ToString();
            }
            string and = " and  ";
            if (cmbAnd != null)
            {
                if (cmbAnd.SelectedItem != null)
                {
                    and = " " + cmbAnd.SelectedItem.ToString() + "  ";
                }
            }

            subConstraint = leftBrackets + cmbColumn.SelectedValue.ToString() + " " + cmbCondition.SelectedValue.ToString() + " " + constraintValue + rightBrackets + and;
            return subConstraint;
        }

        /// <summary>
        /// 获取条件表达式
        /// </summary>
        /// <returns>条件限制</returns>
        private string GetConstraintExpression()
        {
            string condition = string.Empty;
            string subConstraint = string.Empty;
            subConstraint = this.GetSubConstraint(this.cmbLeftBrackets0, this.cmbColumn0, this.cmbCondition0, this.txtValue0, this.cmbValue0, this.cmbRightBrackets0, this.cmbAnd0);
            if (!string.IsNullOrEmpty(subConstraint))
            {
                condition += subConstraint;
            }
            subConstraint = this.GetSubConstraint(this.cmbLeftBrackets1, this.cmbColumn1, this.cmbCondition1, this.txtValue1, this.cmbValue1, this.cmbRightBrackets1, this.cmbAnd1);
            if (!string.IsNullOrEmpty(subConstraint))
            {
                condition += subConstraint;
            }
            subConstraint = this.GetSubConstraint(this.cmbLeftBrackets2, this.cmbColumn2, this.cmbCondition2, this.txtValue2, this.cmbValue2, this.cmbRightBrackets2, this.cmbAnd2);
            if (!string.IsNullOrEmpty(subConstraint))
            {
                condition += subConstraint;
            }
            subConstraint = this.GetSubConstraint(this.cmbLeftBrackets3, this.cmbColumn3, this.cmbCondition3, this.txtValue3, this.cmbValue3, this.cmbRightBrackets3, this.cmbAnd3);
            if (!string.IsNullOrEmpty(subConstraint))
            {
                condition += subConstraint;
            }
            subConstraint = this.GetSubConstraint(this.cmbLeftBrackets4, this.cmbColumn4, this.cmbCondition4, this.txtValue4, this.cmbValue4, this.cmbRightBrackets4);
            if (!string.IsNullOrEmpty(subConstraint))
            {
                condition += subConstraint;
            }
            if (!string.IsNullOrEmpty(condition))
            {
                if (condition.Substring(condition.Length - 7, 7).Equals("  and  "))
                {
                    condition = condition.Substring(0, condition.Length - 7);
                }
                else
                {
                    // "  or  "
                    condition = condition.Substring(0, condition.Length - 6);
                }
            }
            return condition;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.TableConstraint = this.GetConstraintExpression();
                    DotNetService.Instance.TableColumnsService.SetConstraint(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TableName, this.PermissionCode, this.TableConstraint, this.chkEnabled.Checked);
                    this.DialogResult = DialogResult.OK;
                    // 关闭窗口
                    this.Close();
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

        private void ColumnSelected(ComboBox cmbColumn, string selectedValue)
        {
            string columnCode = string.Empty;
            if (cmbColumn.SelectedValue != null)
            {
                columnCode = cmbColumn.SelectedValue.ToString();
            }
            if (string.IsNullOrEmpty(columnCode))
            {
                return;
            }
            string targetTable = BaseBusinessLogic.GetProperty(DTColumns, BaseTableColumnsEntity.FieldColumnCode, columnCode, BaseTableColumnsEntity.FieldTargetTable);
            // 2: 若是有目标表是空的。
            // 2: 若是有目标表，那就需要把文本隐藏、下拉选项显示出来。
            if (string.IsNullOrEmpty(targetTable))
            {
                if (cmbColumn == this.cmbColumn0)
                {
                    this.txtValue0.Visible = true;
                    this.cmbValue0.Visible = false;
                }
                else if (cmbColumn == this.cmbColumn1)
                {
                    this.txtValue1.Visible = true;
                    this.cmbValue1.Visible = false;
                }
                else if (cmbColumn == this.cmbColumn2)
                {
                    this.txtValue2.Visible = true;
                    this.cmbValue2.Visible = false;
                }
                else if (cmbColumn == this.cmbColumn3)
                {
                    this.txtValue3.Visible = true;
                    this.cmbValue3.Visible = false;
                }
                else if (cmbColumn == this.cmbColumn4)
                {
                    this.txtValue4.Visible = true;
                    this.cmbValue4.Visible = false;
                }
            }
            else
            {
                // 这里获取绑定的数据，并且把控件的属性设置好
                ComboBox targetColumn = null;
                if (cmbColumn == this.cmbColumn0)
                {
                    this.txtValue0.Visible = false;
                    this.cmbValue0.Visible = true;
                    targetColumn = this.cmbValue0;
                }
                else if (cmbColumn == this.cmbColumn1)
                {
                    this.txtValue1.Visible = false;
                    this.cmbValue1.Visible = true;
                    targetColumn = this.cmbValue1;
                }
                else if (cmbColumn == this.cmbColumn2)
                {
                    this.txtValue2.Visible = false;
                    this.cmbValue2.Visible = true;
                    targetColumn = this.cmbValue2;
                }
                else if (cmbColumn == this.cmbColumn3)
                {
                    this.txtValue3.Visible = false;
                    this.cmbValue3.Visible = true;
                    targetColumn = this.cmbValue3;
                }
                else if (cmbColumn == this.cmbColumn4)
                {
                    this.txtValue4.Visible = false;
                    this.cmbValue4.Visible = true;
                    targetColumn = this.cmbValue4;
                }
                // 3: 需要读取数据，绑定到下拉框上。
                // 绑定条件数据，这里先按简单的处理，直接指向下拉框选项表
                DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, targetTable);
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                targetColumn.DisplayMember = BaseItemDetailsEntity.FieldItemName;
                targetColumn.ValueMember = BaseItemDetailsEntity.FieldItemValue;
                targetColumn.DataSource = dataTable.DefaultView;
                if (!string.IsNullOrEmpty(selectedValue))
                {
                    // 这里是设定默认值
                    SetColumValue(targetColumn, selectedValue);
                }
            }
        }

        private void cmbColumnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.FormLoaded)
            {
                return;
            }
            // 1：获取当前下拉框的值。
            ComboBox cmbColumn = (ComboBox)sender;
            this.ColumnSelected(cmbColumn, string.Empty);
        }

        /// <summary>
        /// 检查表达式
        /// </summary>
        /// <param name="cmbLeftBrackets">左括号</param>
        /// <param name="cmbColumn">列</param>
        /// <param name="cmbCondition">条件</param>
        /// <param name="txtValue">值</param>
        /// <param name="cmbValue">选项值</param>
        /// <param name="cmbRightBrackets">右括号</param>
        /// <returns>正确</returns>
        private bool SubCheckInput(ComboBox cmbLeftBrackets, ComboBox cmbColumn, ComboBox cmbCondition, TextBox txtValue, ComboBox cmbValue, ComboBox cmbRightBrackets)
        {
            bool returnValue = true;
            if (cmbColumn.SelectedIndex > 0)
            {
                if (cmbCondition.SelectedItem == null)
                {
                    MessageBox.Show(AppMessage.MSG9919, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCondition.Focus();
                    returnValue = false;
                }
                if (cmbValue.Visible)
                {
                    if (cmbValue.SelectedItem == null)
                    {
                        MessageBox.Show(AppMessage.MSG9920, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbValue.Focus();
                        returnValue = false;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtValue.Text))
                    {
                        MessageBox.Show(AppMessage.MSG9920, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtValue.Focus();
                        returnValue = false;
                    }
                }
            }

            return returnValue;
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;

            int leftBrackets = 0;
            if (cmbLeftBrackets0.SelectedItem != null)
            {
                leftBrackets++;
            }
            if (cmbLeftBrackets1.SelectedItem != null)
            {
                leftBrackets++;
            }
            if (cmbLeftBrackets2.SelectedItem != null)
            {
                leftBrackets++;
            }
            if (cmbLeftBrackets3.SelectedItem != null)
            {
                leftBrackets++;
            }
            if (cmbLeftBrackets4.SelectedItem != null)
            {
                leftBrackets++;
            }

            int rightBrackets = 0;
            if (cmbRightBrackets0.SelectedItem != null)
            {
                rightBrackets++;
            }
            if (cmbRightBrackets1.SelectedItem != null)
            {
                rightBrackets++;
            }
            if (cmbRightBrackets2.SelectedItem != null)
            {
                rightBrackets++;
            }
            if (cmbRightBrackets3.SelectedItem != null)
            {
                rightBrackets++;
            }
            if (cmbRightBrackets4.SelectedItem != null)
            {
                rightBrackets++;
            }

            if (leftBrackets < rightBrackets)
            {
                MessageBox.Show(AppMessage.MSG9921, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            else if (leftBrackets > rightBrackets)
            {
                MessageBox.Show(AppMessage.MSG9922, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }

            // 检查表达式
            if (!this.SubCheckInput(this.cmbLeftBrackets0, this.cmbColumn0, this.cmbCondition0, this.txtValue0, this.cmbValue0, this.cmbRightBrackets0))
            {
                return returnValue;
            }
            if (!this.SubCheckInput(this.cmbLeftBrackets1, this.cmbColumn1, this.cmbCondition1, this.txtValue1, this.cmbValue1, this.cmbRightBrackets1))
            {
                return returnValue;
            }
            if (!this.SubCheckInput(this.cmbLeftBrackets2, this.cmbColumn2, this.cmbCondition2, this.txtValue2, this.cmbValue2, this.cmbRightBrackets2))
            {
                return returnValue;
            }
            if (!this.SubCheckInput(this.cmbLeftBrackets3, this.cmbColumn3, this.cmbCondition3, this.txtValue3, this.cmbValue3, this.cmbRightBrackets3))
            {
                return returnValue;
            }
            if (!this.SubCheckInput(this.cmbLeftBrackets4, this.cmbColumn4, this.cmbCondition4, this.txtValue4, this.cmbValue4, this.cmbRightBrackets4))
            {
                return returnValue;
            }

            return returnValue;
        }
        #endregion

        private void btnTestCondition_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!this.CheckInput())
                {
                    return;
                }
                this.TableConstraint = this.GetConstraintExpression();
                if (string.IsNullOrEmpty(this.TableConstraint))
                {
                    MessageBox.Show(AppMessage.MSG9915, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string commandText = string.Empty;
                    commandText = " SELECT COUNT(*) FROM " + this.TableName + " WHERE " + this.TableConstraint;
                    UserCenterDbHelperService dbHelperService = new UserCenterDbHelperService();
                    // BusinessDbHelperService dbHelperService = new BusinessDbHelperService();
                    dbHelperService.ExecuteNonQuery(UserInfo, commandText);
                    this.txtTableConstraint.Text = this.TableConstraint;
                }
                // 是否需要有提示信息？
                if (BaseSystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBox.Show(AppMessage.MSG9918, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnShowConstraint_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!this.CheckInput())
                {
                    return;
                }
                this.TableConstraint = this.GetConstraintExpression();
                if (string.IsNullOrEmpty(this.TableConstraint))
                {
                    MessageBox.Show(AppMessage.MSG9915, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string assemblyName = "DotNet.WinForm";
                    string formName = "FrmShowConstraint" + this.TableName;
                    Type assemblyType = null;
                    try
                    {
                        assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                    }
                    catch
                    {
                    }

                    Form frmTableShowConstraint = null;
                    if (assemblyType != null)
                    {
                        frmTableShowConstraint = (Form)Activator.CreateInstance(assemblyType, this.TableRealName, this.TableName, this.TableConstraint);
                    }
                    else
                    {
                        frmTableShowConstraint = new FrmShowConstraintTable(this.TableRealName, this.TableName, this.TableConstraint);
                    }
                    frmTableShowConstraint.ShowDialog(this);
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

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (this.Height != 406)
            {
                this.Height = 406;
                this.btnShowHide.Text = AppMessage.MSG9916;
            }
            else
            {
                this.Height = 572;
                this.btnShowHide.Text = AppMessage.MSG9917;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}