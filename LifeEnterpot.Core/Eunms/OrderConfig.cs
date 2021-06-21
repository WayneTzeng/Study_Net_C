using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    public enum OrderStatus
    {
        Initial = 0,
        /// <summary>
        /// 訂單成立
        /// </summary>
        [Description("訂單成立")]
        Complete = 8,
        /// <summary>
        /// 取消訂單
        /// </summary>
        [Description("取消訂單")]
        Cancel = 512,
    }

    /// <summary>
    /// 信用卡別
    /// </summary>
    public enum CreditCardType
    {
        None = 0,
        VisaCard = 1,
        MasterCard = 2,
        AmericanExpress = 3,
        JCBCard = 4,
        UCard = 5,
        UnionPay = 6,
        SmartPay = 7
    }

    /// <summary>
    /// 憑證使用狀態
    /// </summary>
    public enum OrderRedemptionStatus
    {
        NotUse = 0,
        Used = 1,
        Returned = 2,
        Sending = 3,
    }

    public enum VerifyOrderRedemptionResult 
    {
        Fail = 0,
        Success = 1,
        DataNotFound = 2,
        DataComparisonError = 3
    }

    public enum NotifyVoucherStatus 
    {
        None = 0,
        Verifing = 1,
        UndoVerified = 2
    }

    public enum ProductDeliveryType
    {
        [Description("")]
        None = 0,
        /// <summary>
        /// 一般宅配
        /// </summary>
        [Description("宅配")]
        Normal = 1,
        /// <summary>
        /// Family店取
        /// </summary>
        [Description("超商取貨")]
        ISP = 10,
        /// <summary>
        /// Wms (Pchome)
        /// </summary>
        [Description("Wms宅配")]
        WMS = 20,

    }

    public enum GoodsStatus
    {
        /// <summary>
        /// 未成立
        /// </summary>
        [Description("未成立")]
        Fail = -1,
        /// <summary>
        /// 訂單處理中
        /// </summary>
        [Description("訂單處理中")]
        Processing = 0,
        /// <summary>
        /// 收到訂單 
        /// </summary>
        [Description("收到訂單")]
        GotOrder = 1,
        /// <summary>
        /// 撿貨 
        /// </summary>
        [Description("撿貨")]
        Picking = 2,
        /// <summary>
        /// 理貨
        /// </summary>
        [Description("理貨")]
        Arranging = 3,
        /// <summary>
        /// 出貨 
        /// </summary>
        [Description("出貨")]
        Shipping = 6,
        /// <summary>
        /// 送達未遇 
        /// </summary>
        [Description("送達未遇")]
        Missed = 11,
        /// <summary>
        /// 出貨完成 
        /// </summary>
        [Description("出貨完成")]
        Arrived = 12,
        /// <summary>
        /// 訂單取消
        /// </summary>
        [Description("訂單已取消，商家尚未出貨")]
        Cancel = 19,
        /// <summary>
        /// 退貨初始
        /// </summary>
        [Description("初始")]
        ReturnInitial = 20,
        /// <summary>
        /// 退貨成立
        /// </summary>
        [Description("退貨成立")]
        ReturnExamine = 21,
        /// <summary>
        /// 退貨處理中
        /// </summary>
        [Description("退貨處理中")]
        ReturnProcessing = 22,
        /// <summary>
        /// 退貨取件配送中
        /// </summary>
        [Description("退貨取件配送中")]
        ReturnDelivering = 23,
        /// <summary>
        /// 退貨配達(已退回)
        /// </summary>
        [Description("退貨配達(已退回)")]
        ReturnArrived = 24,
        /// <summary>
        /// 取不到貨
        /// </summary>
        [Description("取不到貨")]
        PickupFail = 25,
        /// <summary>
        /// 客人不退貨
        /// </summary>
        [Description("客人不退貨")]
        RefundNotRefund = 26,
    }
    public enum RedemptionOrderGroupType
    {
        /// <summary>
        /// 可使用
        /// </summary>
        [Description("可使用")]
        Unused = 0,
        /// <summary>
        /// 已使用
        /// </summary>
        [Description("已使用")]
        RunOut = 1,
        /// <summary>
        /// 已過期
        /// </summary>
        [Description("已過期")]
        Expired = 2,
        /// <summary>
        /// 退款
        /// </summary>
        [Description("退款")]
        Refund = 3,
        /// <summary>
        /// 客服處理中
        /// </summary>
        [Description("客服處理中")]
        OpenIssue = 4
    }

    /// <summary>
    /// for 商城
    /// </summary>
    public enum RedemptionOrderGroupTypeForTaishin
    {
        /// <summary>
        /// 可使用
        /// </summary>
        [Description("可使用")]
        Unused = 1,
        /// <summary>
        /// 已使用
        /// </summary>
        [Description("已使用")]
        RunOut = 2,
        /// <summary>
        /// 已過期
        /// </summary>
        [Description("已過期")]
        Expired = 3,
        /// <summary>
        /// 退款
        /// </summary>
        [Description("退款")]
        Refund = 4,
        /// <summary>
        /// 客服處理中
        /// </summary>
        [Description("客服處理中")]
        OpenIssue = 5
    }

    /// <summary>
    /// 退貨單進度
    /// </summary>
    public enum ReturnProgressStatus
    {
        /// <summary>
        /// 未申請退貨
        /// </summary>
        NotRefound = -1,
        Unknown = 0,
        /// <summary>
        /// 退貨處理中
        /// </summary>
        Processing = 1,
        /// <summary>
        /// 退貨已完成
        /// </summary>
        Completed = 2,
        /// <summary>
        /// 退貨失敗 (憑證14天內已核銷; 其他退款失敗狀況)
        /// </summary>
        Unreturnable = 3,
        /// <summary>
        /// 取消退貨
        /// </summary>
        Canceled = 4,
        /// <summary>
        /// 立即刷退型
        /// </summary>
        CompletedWithCreditCardQueued = 7,
        /// <summary>
        /// 已前往收件(PC訂單使用,商品在消費者手上)
        /// </summary>
        Retrieving = 9,
        /// <summary>
        /// 客服待處理(PC訂單使用,商品不在消費者手上,待客服確認 || 客服建立)
        /// </summary>
        ConfirmedForCS = 10,
        /// <summary>
        /// 前往PC倉庫收件(PC訂單使用)
        /// </summary>
        RetrieveToPC = 11,
        /// <summary>
        /// 前往消費者處收件(PC訂單使用)
        /// </summary>
        RetrieveToCustomer = 12,
        /// <summary>
        /// 廠商待確認(PC訂單使用,逆物流取貨3天內已配送完成,待商家確認)
        /// </summary>
        ConfirmedForVendor = 13,
        /// <summary>
        /// 客服待處理(逆物流取貨日超過天數尚未送達,待客服確認)
        /// </summary>
        ConfirmedForUnArrival = 14,

    }

    public enum VendorProgressStatus
    {
        Unknown = 0,
        /// <summary>
        /// 待處理
        /// </summary>
        Processing = 1,
        /// <summary>
        /// 待處理-已前往收件 
        /// </summary>
        Retrieving = 2,
        /// <summary>
        /// 待處理-無法退貨
        /// </summary>
        Unreturnable = 3,
        /// <summary>
        /// 退貨已完成-已收回商品
        /// </summary>
        CompletedAndRetrievied = 4,
        /// <summary>
        /// 退貨已完成-不收回商品
        /// </summary>
        CompletedAndNoRetrieving = 5,
        /// <summary>
        /// 退貨已完成-未出貨
        /// </summary>
        CompletedAndUnShip = 6,
        /// <summary>
        /// 待處理-無法退貨(客服已處理)
        /// </summary>
        UnreturnableProcessed = 7,
        /// <summary>
        /// 退貨已完成-客服已處理
        /// </summary>
        CompletedByCustomerService = 8,
        /// <summary>
        /// 退貨已完成-系統自動退
        /// </summary>
        Automatic = 9,
        /// <summary>
        /// 待確認收件(PC訂單使用,逆物流取貨3天內已配送完成,待商家確認)
        /// </summary>
        ConfirmedForVendor = 10,
        /// <summary>
        /// 客服待處理(PC訂單使用,商品不在消費者手上,待客服確認 || 客服建立)
        /// </summary>
        ConfirmedForCS = 11,
        /// <summary>
        /// 客服待處理(逆物流取貨日超過天數尚未送達,待客服確認)
        /// </summary>
        ConfirmedForUnArrival = 12
    }

    public enum ReturnReasonOption
    {
        /// <summary>
        /// 商品品質不佳
        /// </summary>
        PoorQuality = 1,
        /// <summary>
        /// 看到更優惠的商品
        /// </summary>
        Expensive = 2,
        /// <summary>
        /// 商品與描述預期不符
        /// </summary>
        NotMatch = 3,
        /// <summary>
        /// 商品瑕疵
        /// </summary>
        Defect = 4,
        /// <summary>
        /// 商品錯發漏發
        /// </summary>
        Missing = 5,
        /// <summary>
        /// 延遲出貨
        /// </summary>
        Delay = 6,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 7
    }

    public enum PayeasyReturnOption
    {
        /// <summary>
        /// 有更優惠的價格
        /// </summary>
        EXPENSIVE = 1,
        /// <summary>
        /// 等太久
        /// </summary>
        LONG_TIME = 2,
        /// <summary>
        /// 收到商品描述不符
        /// </summary>
        NOT_MATCH = 3,
        /// <summary>
        /// 商品瑕疵
        /// </summary>
        DEFECT = 4,
        /// <summary>
        /// 其他
        /// </summary>
        OTHER = 5
    }

    public enum DeliveryOrderGroupType
    {
        /// <summary>
        /// 待出貨
        /// </summary>
        [Description("待出貨")]
        WaitingShipment = 0,
        /// <summary>
        /// 待收貨
        /// </summary>
        [Description("待收貨")]
        Shipping = 1,
        /// <summary>
        /// 確認收貨
        /// </summary>
        [Description("確認收貨")]
        Delivered = 2,
        /// <summary>
        /// 退貨
        /// </summary>
        [Description("退貨")]
        Refund = 3,
        /// <summary>
        /// 客服處理中
        /// </summary>
        [Description("客服處理中")]
        OpenIssue = 4
    }

    public enum OrderReturnStatus
    {
        [Description("")]
        None = 0,
        [Description("退貨處理中")]
        Processing = 1,
        [Description("退貨完成")]
        Completed = 2,
        [Description("退貨失敗")]
        Fail = 3,
        [Description("取消退貨")]
        Cancel = 4,
        [Description("物品退貨完成，金流退貨失敗請洽客服")]
        MoneyRefundFail =5
    }

    /// <summary>
    /// barcode 形態
    /// </summary>
    public enum RedemptionCodeType
    {
        None = 0,
        Barcode128 = 1,
        BarcodeEAN13 = 2,
        /// <summary>
        /// 全家三段式條碼 barcode 39
        /// </summary>
        Pincode = 3,
        /// <summary>
        /// 全家指定商品四段式條碼 EAN13(1) + barcode39(3)
        /// </summary>
        FamiItemCode = 4,
        /// <summary>
        /// HiLife兩段式條碼 (ode39與barcode 128皆可)
        /// </summary>
        HiLifeItemCode = 5,
        /// <summary>
        /// 全家一段式條碼 
        /// </summary>
        FamiSingleBarcode = 6,
        /// <summary>
        ///  Barcode39(共用，不需再分哪裡來的商品)
        /// </summary>
        Barcode39 = 7,
        /// <summary>
        ///  QRCode(共用，不需再分哪裡來的商品)
        /// </summary>
        QRCode = 8,
    }

    /// <summary>
    /// Table CT_ATM_Refund using
    /// </summary>
    public enum AtmRefundStatus
    {
        [Description("退貨申請")]
        Initial = -1,
        [Description("提出退貨需求")]
        Request = 0,
        [Description("產生ACH P01中")]
        AchProcess = 1,
        [Description("產生完成")]
        AchSend = 2,
        [Description("退貨完成")]
        RefundSuccess = 3,
        [Description("退貨失敗")]
        RefundFail = 4,
    };

    /// <summary>
    /// 訂單建檔來源(Web,IOS,Android)
    /// </summary>
    public enum OrderFromType
    {
        [Description("web")]
        ByWeb = 1,
        [Description("ios")]
        ByIOS = 2,
        [Description("android")]
        ByAndroid = 3,

    }

    ///// <summary>
    ///// Table CT_ATM using
    ///// </summary>
    //public enum AtmStatus
    //{
    //    //Order成立
    //    Initial = 0,
    //    //已付款
    //    Paid = 1,
    //    //退貨完成
    //    Refund = 2,
    //    //過期
    //    Expired = 3,
    //    //使用者提出退貨
    //    RefundRequest = 4,
    //    //退貨ACH送出
    //    RefundSend = 5,
    //    //退貨失敗
    //    RefundFail = 6,
    //};
}
