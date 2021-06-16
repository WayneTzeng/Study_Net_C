using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LifeEnterpot.Core.Enums
{

    public enum PayTransType
    {
        /// <summary>
        /// 授權
        /// </summary>
        Authorization = 0,
        /// <summary>
        /// 請款
        /// </summary>
        Charging = 1,
        /// <summary>
        /// 退貨
        /// </summary>
        Refund = 2,
    }

    public enum PayStatus
    {
        /// <summary>
        /// 初始
        /// </summary>
        [Description("初始")]
        Created = 0,
        /// <summary>
        /// 付款成功
        /// </summary>
        [Description("付款成功")]
        Successful = 1,
        /// <summary>
        /// 付款失敗
        /// </summary>
        [Description("付款失敗")]
        Failed = 2,
        /// <summary>
        /// 付款取消、取消授權
        /// </summary>
        [Description("付款取消、取消授權")]
        Cancel = 3,
        /// <summary>
        /// OTP逾期
        /// </summary>
        [Description("OTP逾期")]
        Expire = 4,
    }

    public enum PaymentAPIProvider
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,
        /// <summary>
        /// 台新-一般刷卡
        /// </summary>
        TaishinPaymnetGateway = 1,
        /// <summary>
        /// 台新-OTP
        /// </summary>
        TaishinPaymnetOTPGateway = 2,
        /// <summary>
        /// LetsPay
        /// </summary>
        LetsPayPaymnetGateway = 3,
        /// <summary>
        /// 測試用
        /// </summary>
        ByPass = 9,
    }

    /// <summary>
    /// 台新支付類型
    /// </summary>
    public enum TaishinPayType
    {
        CredidCard = 1
    }

    /// <summary>
    /// 台新交易類別
    /// </summary>
    public enum TaishinPaymentType
    {
        /// <summary>
        /// 授權
        /// </summary>
        Auth = 1,
        /// <summary>
        /// 請款
        /// </summary>
        Capture = 3,
        /// <summary>
        /// 取消請款
        /// </summary>
        CaptureReverse = 4,
        /// <summary>
        /// 退貨
        /// </summary>
        Refund = 5,
        /// <summary>
        /// 取消退貨
        /// </summary>
        RefundReverse = 6,
        /// <summary>
        /// 查詢
        /// </summary>
        Query = 7,
        /// <summary>
        /// 取消授權
        /// </summary>
        AuthReverse = 8,
    }

        
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PaymentType
    {
        [Description("信用卡")]
        CreditCard = 1,
        [Description("台新Pay")]
        LetsPay = 2,
        [Description("ATM")]
        ATM = 3,
        [Description("優惠券")]
        CouponCode = 4,
    }
}
