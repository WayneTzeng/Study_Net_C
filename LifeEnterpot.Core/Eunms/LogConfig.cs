using System.ComponentModel;

namespace LifeEnterpot.Core.Enums
{
    public enum AuditType
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Add = 1,
        /// <summary>
        /// 編輯
        /// </summary>
        [Description("編輯")]
        Edit = 2,
        /// <summary>
        /// 刪除
        /// </summary>
        [Description("刪除")]
        Delete = 3,
        /// <summary>
        /// 審核中
        /// </summary>
        [Description("送審")]
        Review = 20,
        /// <summary>
        /// 通過
        /// </summary>
        [Description("通過")]
        Approved = 30,
        /// <summary>
        /// 拒絕
        /// </summary>
        [Description("拒絕")]
        Rejected = 40,
        /// <summary>
        /// ATM帳戶修改
        /// </summary>
        [Description("ATM帳戶修改")]
        ATMEdit = 50,
    }

    public enum AuditProcessing
    {
        /// <summary>
        /// 無流程
        /// </summary>
        None = -1,
        /// <summary>
        /// 待審核
        /// </summary>
        Processing = 0,
        /// <summary>
        /// 完成
        /// </summary>
        Complete = 1
    }
}
