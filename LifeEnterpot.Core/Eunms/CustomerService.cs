using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    public enum ServiceStatus
    {
        [Description("未認領")]
        Wait = 0,
        [Description("處理中")]
        Process = 1,
        /// <summary>
        /// 客服轉商訊息
        /// </summary>
        [Description("轉單")]
        Transfer = 2,
        /// <summary>
        /// 商家回覆
        /// </summary>
        [Description("轉單回覆")]
        Transferback = 3,
        [Description("已結案")]
        Complete = 4,
        /// <summary>
        /// 通知第二客服
        /// </summary>
        [Description("通知第二客服")]
        SecServiceNotify = 5,
        /// <summary>
        /// 通知第一客服
        /// </summary>
        [Description("通知第一客服")]
        ServiceNotify = 6,
    }

    public enum ReplyType
    {
        None = -1,
        [Description("使用者詢問")]
        User = 0,
        [Description("線上回覆")]
        Online = 1,
        [Description("Mail回覆")]
        Mail = 2,
        [Description("簡訊回覆")]
        Mobile = 3

    }

    public enum MessageConvert
    {
        [Description("線上詢問")]
        online = 0,
        [Description("來電")]
        mobile = 1,
        [Description("Mail")]
        mail = 2,
    }

    public enum Priority
    {
        [Description("一般")]
        Normal = 0,
        [Description("急")]
        Quick = 1,
        [Description("特急")]
        Fast = 2,
    }

    public enum CategoryType
    {
        [Description("一般問題")]
        Normal = 0,
        [Description("訂單問題")]
        Order = 1
    }

    public enum PayEasyIssueType
    {
        [Description("訂單問題")]
        ORDER = 0,
        [Description("配送問題")]
        SHIP = 1,
        [Description("退貨問題")]
        RETURN_GOODS = 2,
        [Description("換貨問題")]
        EXCHANGE = 3,
        [Description("商品問題")]
        PRODUCT = 4,
        [Description("行銷活動問題")]
        MARKETING = 5,
        [Description("其他")]
        OTHER = 6
    }

    public enum IssueFromTypeByChannel
    {
        [Description("台新_Richart Life")]
        Cardaily = 1,
        [Description("台新_Richart")]
        Richart = 3,
        [Description("台新_行動銀行")]
        Tsbank = 4
    }
}
