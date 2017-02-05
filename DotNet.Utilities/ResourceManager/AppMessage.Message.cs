//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Globalization;

namespace DotNet.Utilities
{
    /// <summary>
    ///	AppMessage
    /// 通用讯息控制基类
    /// 
    /// 修改纪录
    ///		2007.05.17 版本：1.0	JiRiGaLa 建立，为了提高效率分开建立了类。
    ///	
    /// 版本：3.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.17</date>
    /// </author> 
    /// </summary>
    public partial class AppMessage
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        public static string MSG0000 = "提示信息";

        /// <summary>
        /// 发生未知错误。
        /// </summary>
        public static string MSG0001 = "发生未知错误。";

        /// <summary>
        /// 数据库连接不正常。
        /// </summary>
        public static string MSG0002 = "数据库连接不正常。";

        /// <summary>
        /// WebService连接不正常。
        /// </summary>
        public static string MSG0003 = "WebService连接不正常。";

        /// <summary>
        /// 无任何数据被修改。
        /// </summary>
        public static string MSG0004 = "无任何数据被修改。";

        /// <summary>
        /// 记录未找到，可能已被其他人删除。
        /// </summary>
        public static string MSG0005 = "记录未找到，可能已被其他人删除。";

        /// <summary>
        /// 数据已被其他人修改，请按F5键重新更新取得数据。
        /// </summary>
        public static string MSG0006 = "数据已被其他人修改，请按F5键重新更新取得数据。";

        /// <summary>
        /// 请输入{0}，不允许为空。
        /// </summary>
        public static string MSG0007 = "请输入 {0} ，不允许为空。";

        /// <summary>
        /// {0} 已重复。
        /// </summary>
        public static string MSG0008 = "{0} 已重复。";

        /// <summary>
        /// 新增成功。
        /// </summary>
        public static string MSG0009 = "新增成功。";

        /// <summary>
        /// 更新成功。
        /// </summary>
        public static string MSG0010 = "更新成功。";

        /// <summary>
        /// 保存成功。
        /// </summary>
        public static string MSG0011 = "保存成功。";

        /// <summary>
        /// 批量储存成功。
        /// </summary>
        public static string MSG0012 = "批量保存成功。";

        /// <summary>
        /// 删除成功。
        /// </summary>
        public static string MSG0013 = "删除成功。";

        /// <summary>
        /// 批量删除成功。
        /// </summary>
        public static string MSG0014 = "批量删除成功。";

        /// <summary>
        /// 您确认删除吗？
        /// </summary>
        public static string MSG0015 = "您确认删除吗？";

        /// <summary>
        /// 您确认删除 '{0}' 吗？
        /// </summary>
        public static string MSG0016 = "您确认删除 {0} 吗？";

        /// <summary>
        /// 当前记录不允许被删除。
        /// </summary>
        public static string MSG0017 = "当前记录不允许被删除。";

        /// <summary>
        /// 当前记录 '{0}' 不允许被删除。
        /// </summary>
        public static string MSG0018 = "当前记录 {0} 不允许被删除。";

        /// <summary>
        /// 当前记录不允许被编辑,请按F5键重新获得最新资料。
        /// </summary>
        public static string MSG0019 = "当前记录不允许被编辑，请按F5键重新获得最新资料。";

        /// <summary>
        /// 当前记录 '{0}' 不允许被编辑，请按F5键重新获得最新资料。
        /// </summary>
        public static string MSG0020 = "当前记录 {0} 不允许被编辑，请按F5键重新获得最新资料。";

        /// <summary>
        /// 当前记录已是第一笔记录。
        /// </summary>
        public static string MSG0021 = "当前记录已是第一笔记录。";

        /// <summary>
        /// 当前记录已是最后一笔记录。
        /// </summary>
        public static string MSG0022 = "当前记录已是最后一笔记录。";

        /// <summary>
        /// 请至少选择一项。
        /// </summary>
        public static string MSGC023 = "请至少选择一项。";

        /// <summary>
        /// 只能选择一笔数据。
        /// </summary>
        public static string MSGC024 = "只能选择一笔数据。";

        /// <summary>
        /// 请至少选择一项 '{0}'。
        /// </summary>
        public static string MSG0024 = "请至少选择一项 {0}。";

        /// <summary>
        /// '{0}' 不能大于 '{1}'。
        /// </summary>
        public static string MSG0025 = "{0} 不能大于 {1}。";

        /// <summary>
        /// '{0}' 不能小于 '{1}'。
        /// </summary>
        public static string MSG0026 = "{0} 不能小于 {1}。";

        /// <summary>
        /// '{0}' 不能等于 '{1}'。
        /// </summary>
        public static string MSG0027 = "{0} 不能等于 {1}。";

        /// <summary>
        ///'{0}' 不是有效的日期。
        /// </summary>
        public static string MSG0028 = "{0} 不是有效的日期。";

        /// <summary>
        /// '{0}' 不是有效的字符。
        /// </summary>
        public static string MSG0029 = "{0} 不是有效的字符。";

        /// <summary>
        /// '{0}' 不是有效的数字。
        /// </summary>
        public static string MSG0030 = "{0} 不是有效的数字。";

        /// <summary>
        /// '{0}' 不是有效的金额。
        /// </summary>
        public static string MSG0031 = "{0} 不是有效的金额。";

        /// <summary>
        /// '{0}'名不能包含：\ / : * ? " < > |
        /// </summary>
        public static string MSG0032 = "{0} 名包含非法字符。";

        /// <summary>
        /// 数据已经被引用，有关联资料在。
        /// </summary>
        public static string MSG0033 = "资料已经被引用，有关联资料在。";

        /// <summary>
        /// 数据已经被引用，有关联资料在，是否强制删除资料？
        /// </summary>
        public static string MSG0034 = "资料已经被引用，有关联资料在，是否强制删除资料？";

        /// <summary>
        /// {0} 有子节点不允许被删除，有子节点还未被删除。
        /// </summary>
        public static string MSG0035 = "{0} 有子节点不允许被删除，有子节点还未被删除。";

        /// <summary>
        /// {0} 不能移动到 {1}。
        /// </summary>
        public static string MSG0036 = "{0} 不能移动到 {1}。";

        /// <summary>
        /// {0} 下的子节点不能移动到 {1}。
        /// </summary>
        public static string MSG0037 = "{0} 下的子节点不能移动到 {1}。";

        /// <summary>
        /// 确认移动 {0} 到 {1} 吗？
        /// </summary>
        public static string MSG0038 = "确认移动 {0} 到 {1} 吗？";

        /// <summary>
        /// '{0}' 不等于 '{1}'。
        /// </summary>
        public static string MSG0039 = "{0} 不等于 {1}。";

        /// <summary>
        /// {0} 错误。
        /// </summary>
        public static string MSG0040 = "{0} 错误。";

        /// <summary>
        /// 确认审核通过吗？
        /// </summary>
        public static string MSG0041 = "确认审核通过吗？";

        /// <summary>
        /// 确认审核退回吗？
        /// </summary>
        public static string MSG0042 = "确认审核退回吗？";

        /// <summary>
        /// 不能锁定数据。
        /// </summary>
        public static string MSG0043 = "不能锁定数据。";

        /// <summary>
        /// 成功锁定数据。
        /// </summary>
        public static string MSG0044 = "成功锁定数据。";

        /// <summary>
        /// 数据已经改变，想储存数据吗？
        /// </summary>
        public static string MSG0045 = "数据已经改变，想储存数据吗？";

        /// <summary>
        /// 最近 {0} 次内密码不能重复。。
        /// </summary>
        public static string MSG0046 = "最近 {0} 次内密码不能重复。。";

        /// <summary>
        /// 密码已过期，账号被锁定，请联系系统管理员。
        /// </summary>
        public static string MSG0047 = "密码已过期，账号被锁定，请联系系统管理员。";

        /// <summary>
        /// 拒绝登入，用户已经在在线。
        /// </summary>
        public static string MSG0048 = "拒绝登入，用户已经在在线。";

        /// <summary>
        /// 拒绝登入，网卡Mac位置不符合限制条件。
        /// </summary>
        public static string MSG0049 = "拒绝登入，网卡Mac位置不符合限制条件。";

        /// <summary>
        /// 拒绝登入，IP位置不符限制条件。
        /// </summary>
        public static string MSG0050 = "拒绝登入，IP位置不符限制条件。";

        /// <summary>
        /// 已到在线用户最大数量限制。
        /// </summary>
        public static string MSG0051 = "已到在线用户最大数量限制。";

        /// <summary>
        /// IP位置格式不正确。
        /// </summary>
        public static string MSG0052 = "IP位置格式不正确。";

        /// <summary>
        /// MAC位置格式不正确。
        /// </summary>
        public static string MSG0053 = "MAC位置格式不正确。";

        /// <summary>
        /// 请填写IP位置或MAC位置信息。
        /// </summary>
        public static string MSG0054 = "请填写IP位置或MAC位置信息。";

        /// <summary>
        /// 存在相同的IP位置。
        /// </summary>
        public static string MSG0055 = "存在相同的IP位置。";

        /// <summary>
        /// IP位置新增成功。
        /// </summary>
        public static string MSG0056 = "IP位置新增成功。";

        /// <summary>
        /// IP位置新增失败。
        /// </summary>
        public static string MSG0057 = "IP位置新增失败。";

        /// <summary>
        /// 存在相同的MAC位置。
        /// </summary>
        public static string MSG0058 = "存在相同的MAC位置。";

        /// <summary>
        /// MAC位置新增成功。
        /// </summary>
        public static string MSG0059 = "  MAC位置新增成功。";

        /// <summary>
        /// 请先新增该职员的登入系统用户信息。
        /// </summary>
        public static string MSG0060 = "请先新增该职员的登入系统用户信息。";

        /// <summary>
        /// MAC位置新增失败。
        /// </summary>
        public static string MSG0061 = "  MAC位置新增失败。";

        /// <summary>
        /// 请设定新密码，原始密码未曾修改过。
        /// </summary>
        public static string MSG0062 = "请设定新密码，原始密码未曾修改过。";

        /// <summary>
        /// 请设定新密码，30天内未曾修改过密码。
        /// </summary>
        public static string MSG0063 = "请设定新密码，30天内未曾修改过密码。";

        /// <summary>
        /// 您输入的分钟数值不正确，请检查。
        /// </summary>
        public static string MSG0064 = "您输入的分钟数值不正确，请检查。";

        /// <summary>
        /// 数据已经改变，不储存数据？
        /// </summary>
        public static string MSG0065 = "数据已经改变，不储存数据？";

        /// <summary>
        /// 您确认移除吗？
        /// </summary>
        public static string MSG0075 = "您确认移除吗？";

        /// <summary>
        /// 您确认移除 {0} 吗？
        /// </summary>
        public static string MSG0076 = "您确认移除 {0} 吗？";

        /// <summary>
        /// 成功删除 {0} 笔记录。
        /// </summary>
        public static string MSG0077 = "成功删除 {0} 笔记录。";

        /// <summary>
        /// 用户登入被拒，用户审核中。
        /// </summary>
        public static string MSG0078 = "用户登入被拒，用户审核中。";

        /// <summary>
        /// 用户被锁定，登入被拒绝，请联系系统管理员。
        /// </summary>
        public static string MSG0079 = "用户被锁定，登入被拒绝，请联系系统管理员。";

        /// <summary>
        /// 用户账号未被激活，请及时激活用户账号。
        /// </summary>
        public static string MSG0080 = "用户账号未被激活，请及时激活用户账号。";

        /// <summary>
        /// 用户被锁定，登入被拒绝，不可早于：
        /// </summary>
        public static string MSG0081 = "用户被锁定，登入被拒绝，不可早于：";

        /// <summary>
        /// 用户被锁定，登入被拒绝，不可晚于：
        /// </summary>
        public static string MSG0082 = "用户被锁定，登入被拒绝，不可晚于：";

        /// <summary>
        /// 用户被锁定，登入被拒绝，锁定开始日期：
        /// </summary>
        public static string MSG0083 = "用户被锁定，登入被拒绝，锁定开始日期：";

        /// <summary>
        /// 用户被锁定，登入被拒绝，锁定结束日期：
        /// </summary>
        public static string MSG0084 = "用户被锁定，登入被拒绝，锁定结束日期：";

        /// <summary>
        /// IP Address 不正确。
        /// </summary>
        public static string MSG0085 = "IP Address 不正确。";

        /// <summary>
        /// MAC Address 不正确。
        /// </summary>
        public static string MSG0086 = "MAC Address 不正确。";

        /// <summary>
        /// 用户已经上线，不允许重复登入。
        /// </summary>
        public static string MSG0087 = "用户已经上线，不允许重复登入。";

        /// <summary>
        /// 密码错误，登入被拒绝。
        /// </summary>
        public static string MSG0088 = "密码错误，登入被拒绝。";

        /// <summary>
        /// 已超出用户在线数量上限：
        /// </summary>
        public static string MSG0089 = "已超出用户在线数量上限：";

        /// <summary>
        /// 登入被拒绝。
        /// </summary>
        public static string MSG0090 = "登入被拒绝。";

        /// <summary>
        /// 新增操作权限项。
        /// </summary>
        public static string MSG0091 = "新增操作权限项。";

        /// <summary>
        /// 登入开始时间
        /// </summary>
        public static string MSG0092 = "登入开始时间";

        /// <summary>
        /// 登入结束时间
        /// </summary>
        public static string MSG0093 = "登入结束时间";

        /// <summary>
        /// 暂停开始时间
        /// </summary>
        public static string MSG0094 = "暂停开始时间";

        /// <summary>
        /// 暂停结束日期
        /// </summary>
        public static string MSG0095 = "暂停结束日期";

        /// <summary>
        /// {0} 在在线，不允许删除。
        /// </summary>
        public static string MSG0100 = "{0} 在在线，不允许删除。";

        /// <summary>
        /// 目前用户 {0} 不允许删除自己。
        /// </summary>
        public static string MSG0101 = "目前用户 {0} 不允许删除自己。";

        /// <summary>
        /// 不允许使用连续重复密码。
        /// </summary>
        public static string MSG0102 = "不允许使用连续重复密码。";

        /// 您确认清除权限吗？
        /// </summary>
        public static string MSG0600 = "您确认清除权限吗？";

        /// <summary>
        /// 已经成功连接到目标数据。
        /// </summary>
        public static string MSG0700 = "已经成功连接到目标数据。";

        /// <summary>
        /// 调用被拒绝，未经授权的访问。
        /// </summary>
        public static string MSG0800 = "调用被拒绝，未经授权的访问。";

        /// <summary>
        /// 服务调用被拒绝，用户未登入。
        /// </summary>
        public static string MSG0900 = "服务调用被拒绝，用户未登入。";

        /// <summary>
        /// 系统设定讯息错误，请与软件开发商联系。
        /// </summary>
        public static string MSG1000 = "系统设定讯息错误，请与软件开发商联系。";

        /// <summary>
        /// 您确认重置功能选单吗？
        /// </summary>
        public static string MSG1001 = "您确认重置功能选单吗？";

        /// <summary>
        /// {0} 不正确，请重新输入。
        /// </summary>
        public static string MSG2000 = "{0} 不正确，请重新输入。";

        public static string MSG3000 = "您确认初始化系统吗？";
        public static string MSG3010 = "操作成功。";
        public static string MSG3020 = "操作失败。";

        public static string MSG9800 = "值";
        public static string MSG9900 = "公司";
        public static string MSG9901 = "部门";

        public static string MSG9910 = "用户未设置电子邮件地址。";
        public static string MSG9911 = "用户账号被锁定。";
        public static string MSG9912 = "用户还未激活账号。";
        public static string MSG9913 = "用户账号已被激活。";
        public static string MSG9914 = "用户关联。";
        public static string MSG9915 = "请设置约束条件。";
        public static string MSG9916 = "显示   ▽";
        public static string MSG9917 = "隐藏   △";
        public static string MSG9918 = "验证表达式成功。";
        public static string MSG9919 = "请输入条件。";
        public static string MSG9920 = "请输入内容。";
        public static string MSG9921 = "缺少（ 符号。";
        public static string MSG9922 = "缺少 ）符号。";

        public static string MSGS857 = "签名私钥。";
        public static string MSGS864 = "签名密码。";

        public static string MSGS957 = "通讯用户名称。";
        public static string MSGS964 = "通讯密码。";

        public static string MSGS965 = "验证码";


        public static string MSG8000 = "密码强度不符合要求，密码至少为6位数，且为数字加字母的组合。";

        public static string MSG8900 = "工号";
        public static string MSG9000 = "用户名称或密码错误。";
        public static string MSG9955 = "资料。";
        public static string MSG9956 = "未找到满足条件的记录。";
        public static string MSG9957 = "用户名";
        public static string MSG9958 = "数据验证错误。";
        public static string MSG9959 = "新密码";
        public static string MSG9960 = "确认密码";
        public static string MSG9961 = "原密码";
        public static string MSG9962 = "修改 {0} 成功。";
        public static string MSG9963 = "设置 {0} 成功。";
        public static string MSG9964 = "密码";
        public static string MSG9965 = "执行成功。";
        public static string MSG9966 = "用户没有找到，请注意大小写。";
        public static string MSG9967 = "密码错误，请注意大小写。";
        public static string MSG9968 = "登入被拒绝，请与管理员联系。";
        public static string MSG9969 = "基础编码";
        public static string MSG9970 = "职员";
        public static string MSG9971 = "组织机构";
        public static string MSG9972 = "角色";
        public static string MSG9973 = "选单";
        public static string MSG9974 = "文件夹";
        public static string MSG9975 = "权限";
        public static string MSG9976 = "主键";
        public static string MSG9977 = "编号";
        public static string MSG9978 = "名称";
        public static string MSG9979 = "父节点主键";
        public static string MSG9980 = "父节点名称";
        public static string MSG9981 = "功能分类主键";
        public static string MSG9982 = "唯一识别主键";
        public static string MSG9983 = "主题";
        public static string MSG9984 = "内容";
        public static string MSG9985 = "状态代码";
        public static string MSG9986 = "次数";
        public static string MSG9987 = "有效";
        public static string MSG9988 = "描述";
        public static string MSG9989 = "排序码";
        public static string MSG9990 = "建立者主键";
        public static string MSG9991 = "建立时间";
        public static string MSG9992 = "最后修改者主键";
        public static string MSG9993 = "最后修改时间";
        public static string MSG9994 = "排序";
        public static string MSG9995 = "主键";
        public static string MSG9996 = "索引";
        public static string MSG9997 = "字段";
        public static string MSG9998 = "数据表";
        public static string MSG9999 = "数据库";

        //韩峰修改20101106
        public static string MSG0200 = "您确认清除用户角色关联吗？";
        public static string MSG0201 = "您选择的档案不存在，请重新选择。";
        public static string MSG0202 = "提示信息";
        public static string MSG0203 = "您确认移动 \" {0} \" 到 \" {1} \" 吗？";
        public static string MSG0204 = "您确认退出应用程序吗？";
        public static string MSG0205 = "档案 {0} 已存在，要覆盖服务器上的档案吗？";
        public static string MSG0206 = "已经超过了上传限制，请检查要上传的档案大小。";
        public static string MSG0207 = "您确认要删除图片吗？";
        public static string MSG0208 = "开始时间不能大于结束时间。";
        public static string MSG0209 = "清除成功。";
        public static string MSG0210 = "重置成功。";
        public static string MSG0211 = "已输入 {0} 次错误密码，不再允许继续登入，请重新启动程序进行登入。";
        public static string MSG0212 = "查询内容";
        public static string MSG0213 = "编号总长度不要超过40位。";
        public static string MSG0214 = "编号产生成功。";
        public static string MSG0215 = "增序列";
        public static string MSG0216 = "减序列";
        public static string MSG0217 = "步调";
        public static string MSG0218 = "序列重置成功。";
        public static string MSG0219 = "您确认重置序列吗？";
        public static string MSG0223 = "用户名称不允许为空，请输入。";
        public static string MSG0225 = "目前节点上有资料。";
        public static string MSG0226 = "无法删除自己。";
        public static string MSG0228 = "设置关联用户成功。";
        public static string MSG0229 = "所在单位不允许为空，请选择。";
        public static string MSG0230 = "申请账号更新成功，请等待审核。";
        public static string MSG0231 = "密码不等于确认密码，请确认后重新输入。";
        public static string MSG0232 = "用户名称";
        public static string MSG0233 = "姓名";
        public static string MSG0234 = "E-mail 格式不正确，请重新输入。";
        public static string MSG0235 = "申请账号成功，请等待审核。";
        public static string MSG0236 = "导出的目标文件已存在，要覆盖 \"{0}\" 吗？";
        public static string MSG0237 = "发送电子邮件成功。";
        public static string MSG0238 = "清除异常信息成功。";
        public static string MSG0239 = "您确认清除异常信息吗？";
        public static string MSG0240 = "内容不能为空";
        public static string MSG0241 = "发送电子邮件失败。";
        public static string MSG0242 = "移动成功。";
        public static string MSG0243 = "程序异常报告";
        public static string MSG0244 = "您选择的文档不存在，请重新选择。";
        public static string MSG0245 = "用户、角色必须选择一个。";
        public static string MSG0246 = "没有要复制的数据！";
        public static string MSG0247 = "审核通过 {0} 项。";
        public static string MSG0248 = "审核通过失败。";
        public static string MSG0249 = "请选需要处理的数据。";
        public static string MSG0250 = "您确认审核通过此单据吗？";
        public static string MSG0251 = "成功退回单据。";
        public static string MSG0252 = "请选需要处理的数据。";
        public static string MSG0253 = "您确认不输入退回理由吗？";
        public static string MSG0255 = "您确认退回此单据吗？";
        public static string MSG0256 = "工作流程发送成功。";
        public static string MSG0257 = "工作流程发送失败。";
        public static string MSG0258 = "审核通过单据。";
        public static string MSG0259 = "请选需要处理的数据。";
        public static string MSG0260 = "请选择提交给哪位用户。";
        public static string MSG0261 = "最终审核通过 {0} 项。";
        public static string MSG0262 = "最终审核失败。";
        public static string MSG0263 = "请选需要处理的数据。";
        public static string MSG0264 = "成功退回单据。";
        public static string MSG0265 = "请选择需要处理的数据。";
        public static string MSG0266 = "您确认不输入退回理由吗？";
        public static string MSG0267 = "您确认退回此单据吗？";
        public static string MSG0268 = "审核流程发送成功。";
        public static string MSG0269 = "请选需要处理的数据。";
        public static string MSG0270 = "请选择提交给哪位用户。";
        public static string MSG0271 = "您确认提交给 {0} 吗？";
        public static string MSG0272 = "审核流程撤销成功 {0} 项。";
        public static string MSG0273 = "审核流程撤销失败。";
        public static string MSG0274 = "请选需要处理的数据。";
        public static string MSG0275 = "您确认不输入退回理由吗？";
        public static string MSG0276 = "您确认撤销撤销审核流程中的单据吗？";
        public static string MSG0277 = "请选择提交给哪个用户审核。";
        public static string MSG0278 = "您确认提交给用户 {0} 审核吗？";
        public static string MSG0279 = "工作流程发送成功。";
        public static string MSG0280 = "工作流程发送失败。";
        public static string MSG0281 = "您确认替换文件 {0} 吗？";
        public static string MSG0282 = "上级机构";
        public static string MSG0283 = "编号产生成功";
        public static string MSG0284 = "已修改配置信息，需要保存吗？";
        public static string MSG0285 = "没有要保存的资料！";
        public static string MSG0286 = "单位名称";
        public static string MSG0287 = "请选择提交给哪个部门审核。";
        public static string MSG0288 = "您确认提交给部门 {0} 审核吗？";
        public static string MSG0289 = "请选择提交给哪个角色审核。";
        public static string MSG0290 = "您确认提交给角色 {0} 审核吗？";
        public static string MSG0291 = "请选择提交给哪个角色或部门或人员审核。";
        public static string MSG0292 = "成功退回 {0} 项。";
        public static string MSG0293 = "退回失败。";
        public static string MSG0294 = "您确认要转发给 {0} 审核吗？";
        public static string MSG0295 = "转发成功 {0} 项。";
        public static string MSG0296 = "转发失败。";
        public static string MSG0300 = "下线通知，您的账号在另一地点登录，您被迫下线。";
        public static string MSG0400 = "您的帐户登录异常，被系统锁定 {0} 分钟，若有疑问请联系系统管理员。";

        // 2012.05.24 Pcsky 新增
        /// <summary>
        /// 您确定保存吗？
        /// </summary>
        public static string MSG0301 = "您确定保存吗？";
        public static string MSG0302 = "分类。";
        public static string MSG0303 = "请选择{0}。";
        public static string MSG0304 = "用户、组织机构、角色必须选择一个。";

        // 重新登入时，登入窗口名称改变为重新登入”
        public static string MSGReLogOn = "重新登入";

        // BaseUserManager登入服务讯息参数
        public static string BaseUserManager = "登入服务";
        public static string BaseUserManager_LogOn = "登入操作";
        public static string BaseUserManager_LogOnSuccess = "登入成功";

        // DataGridView右键选单
        public static string clickToolStripMenuItem = "数据列设置";

        // BaseForm加载窗口
        public static string LoadWindow = "加载窗口";
    }
}