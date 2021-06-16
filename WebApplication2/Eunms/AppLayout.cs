
using System.ComponentModel;

namespace LifeEnterpot.Core.Enums
{
    public enum AppLayoutSectionEnum
    {
        [Description("挑品")]
        Product = 1,
        [Description("策展")]
        Curation = 2,
        [Description("頻道")]
        Channel = 3,
        [Description("文章")]
        Article = 4
    }

    public enum AppLayoutStatus
    {
        /// <summary>
        /// 草稿
        /// </summary>
        [Description("草稿")]
        Draft = 0,
        /// <summary>
        /// 審核中
        /// </summary>
        [Description("審核中")]
        Review = 1,
        /// <summary>
        /// 通過
        /// </summary>
        [Description("通過")]
        Approved = 2,
        /// <summary>
        /// 拒絕
        /// </summary>
        [Description("退回")]
        Rejected = 3,
        /// <summary>
        /// 過期版本
        /// </summary>
        [Description("過期版本")]
        ExpiredVersion = 4
    }
}
