using System.ComponentModel;

namespace LifeEnterpot.Core.Enums
{
    /// <summary>
    /// 新版API採用的API處理狀況之回覆，所有的TYPE依據類型做大分類的區別如下
    /// 1000~1999:共用類型
    /// 2000~2999:會員相關
    /// 3000~3999:團購相關
    /// 4000~4999:優惠券相關
    /// 5000~5999:pcp相關
    /// 6000~6999:Skm相關
    /// 7000~7999:台新行動錢包支付相關
    /// 8000~8999:17Pay相關 
    /// </summary>
    public enum ApiResultCode
    {
        Ready = 0,

        #region (1000) 共用類型
        /// <summary>
        /// 呼叫成功，未發生錯誤
        /// </summary>
        [Description("ApiResultCodeSuccess")]
        Success = 1000,
        /// <summary>
        /// 未明確定義之錯誤
        /// </summary>
        [Description("ApiResultCodeError")]
        Error = 1010,
        /// <summary>
        /// 輸入參數錯誤
        /// </summary>
        [Description("ApiResultCodeInputError")]
        InputError = 1020,
        /// <summary>
        /// Token已過期
        /// </summary>
        [Description("ApiResultCodeOAuthTokenExpired")]
        OAuthTokenExpired = 1100,
        /// <summary>
        /// 查無此OAuthToken
        /// </summary>
        [Description("ApiResultCodeOAuthTokerNotFound")]
        OAuthTokerNotFound = 1110,
        /// <summary>
        /// Token未授權
        /// </summary>
        [Description("ApiResultCodeOAuthTokerNoAuth")]
        OAuthTokerNoAuth = 1120,
        /// <summary>
        /// 系統繁忙中，請30秒後再試一次。
        /// </summary>
        [Description("ApiResultCodeSystemBusy")]
        SystemBusy = 1130,
        /// <summary>
        /// 查無資料
        /// </summary>
        [Description("查無資料")]
        DataNotFound = 1140,
        /// <summary>
        /// 新增更新失敗
        /// </summary>
        [Description("ApiResultCodeDataSaveFail")]
        SaveFail = 1150,
        /// <summary>
        /// 登入成功請修改密碼
        /// </summary>
        [Description("ApiResultCodeLoginSuccessNeedChangePassword")]
        LoginSuccessNeedChangePassword = 1160,
        /// <summary>
        /// 資料已存在
        /// </summary>
        [Description("ApiResultCodeDataIsExist")]
        DataIsExist = 1170,
        #endregion 共用類型

        #region (2000) 會員相關
        /// <summary>
        /// Token 無效或過期
        /// </summary>
        [Description("ApiResultCodeUserNoSignIn")]
        TokenInvalid = 2010,
        /// <summary>
        /// Token 過期
        /// </summary>
        [Description("token_info was expired")]
        TokenExpired = 2012,
        /// <summary>
        /// 使用者未登入
        /// </summary>
        [Description("使用者未登入")]
        UserNoSignIn = 2015,
        /// <summary>
        /// 錯誤的使用者資訊
        /// </summary>
        [Description("ApiResultCodeBadUserInfo")]
        BadUserInfo = 2020,
        /// <summary>
        /// 會員註冊失敗
        /// </summary>
        [Description("ApiResultUserRegisterFail")]
        UserRegisterFail = 2030,
        /// <summary>
        /// 帳號停權
        /// </summary>
        [Description("ApiResultAccountDisable")]
        AccountDisable = 2040,
        /// <summary>
        /// 會員資料不存在
        /// </summary>
        [Description("AccountNotFound")]
        AccountNotFound = 2050,
        /// <summary>
        /// 手機認證傳送認證簡訊-成功
        /// </summary>
        [Description("ApiResultMobileAuthSendSmsSuccess")]
        MobileAuthSendSmsSuccess = 2110,
        /// <summary>
        /// 手機認證傳送認證簡訊-號碼認證過了
        /// </summary>
        [Description("ApiResultMobileAuthUsedByOtherMember")]
        MobileAuthUsedByOtherMember = 2120,
        /// <summary>
        /// 手機認證傳送認證簡訊-發送次數超過上限
        /// </summary>
        [Description("ApiResultMobileAuthTooManySmsSent")]
        MobileAuthTooManySmsSent = 2130,
        /// <summary>
        /// 手機認證傳送認證簡訊-失敗
        /// </summary>
        [Description("ApiResultMobileAuthSendSmsFail")]
        MobileAuthSendSmsFail = 2140,
        /// <summary>
        /// 手機認證驗證碼-成功
        /// </summary>
        [Description("MobileValidateSuccess")]
        MobileValidateSuccess = 2210,
        /// <summary>
        /// 手機認證驗證碼-驗證碼輸入有誤
        /// </summary>
        [Description("MobileValidateCodeError")]
        MobileValidateCodeError = 2220,
        /// <summary>
        /// 手機認證驗證碼-驗證碼已過有效時間
        /// </summary>
        [Description("MobileValidateTimeError")]
        MobileValidateTimeError = 2230,
        /// <summary>
        /// 手機認證驗證碼-手機號碼己經被使用了
        /// </summary>
        [Description("MobileValidateUsedByOtherMember")]
        MobileValidateUsedByOtherMember = 2240,
        /// <summary>
        /// 手機認證驗證碼-其他問題
        /// </summary>
        [Description("MobileValidateError")]
        MobileValidateError = 2250,
        /// <summary>
        /// 手機認證設定密碼-成功
        /// </summary>
        [Description("MobileSetPasswordSuccess")]
        MobileSetPasswordSuccess = 2310,
        /// <summary>
        /// 手機認證設定密碼-驗證碼輸入有誤
        /// </summary>
        [Description("MobileSetPasswordEmptyError")]
        MobileSetPasswordEmptyError = 2320,
        /// <summary>
        /// 手機認證設定密碼-驗證碼已過有效時間
        /// </summary>
        [Description("MobileSetPasswordDataError")]
        MobileSetPasswordDataError = 2330,
        /// <summary>
        /// 手機認證設定密碼-手機號碼己經被使用
        /// </summary>
        [Description("MobileSetPasswordOtherError")]
        MobileSetPasswordOtherError = 2340,
        /// <summary>
        /// 手機認證設定密碼-密碼格式錯誤
        /// </summary>
        [Description("MobileSetPasswordFormatError")]
        MobileSetPasswordFormatError = 2350,
        /// <summary>
        /// 沒有建立手機會員
        /// </summary>
        [Description("MobileMemberNotFound")]
        MobileMemberNotFound = 2360,
        /// <summary>
        /// 只有會員在待設定密碼的狀態下，才能使用此API設定密碼
        /// </summary>
        [Description("MobileDisallowSetPasswordByKey")]
        MobileDisallowSetPasswordByKey = 2370,
        /// <summary>
        /// 重設密碼的金鑰錯誤
        /// </summary>
        [Description("MobileResetPasswordKeyError")]
        MobileResetPasswordKeyError = 2380,
        /// <summary>
        /// 到達每日重送認證信的上限
        /// </summary>
        ReachingReSendAuthMailLimit = 2390,
        /// <summary>
        /// email會員 已註冊但未開通
        /// </summary>
        MailRegisterInactive = 2340,

        #endregion 會員相關

        #region (3000) 核銷相關

        /// <summary>
        /// 不支援此核銷方式
        /// </summary>
        [Description("ApiResultCodeNotSupportThisWayToVerify")]
        NotSupportThisWayToVerify = 3010,

        #endregion 核銷相關

        #region (4000) 優惠券相關
        /// <summary>
        /// 無效憑證
        /// </summary>
        [Description("ApiResultCodeInvalidCoupon")]
        InvalidCoupon = 4000,
        /// <summary>
        /// 此憑證已退貨
        /// </summary>
        [Description("ApiResultCodeCouponReturned")]
        CouponReturned = 4010,
        /// <summary>
        /// 此憑證已使用
        /// </summary>
        [Description("ApiResultCodeCouponUsed")]
        CouponUsed = 4020,
        /// <summary>
        /// 此憑證不在使用期限內
        /// </summary>
        [Description("ApiResultCodeInvalidInterval")]
        InvalidInterval = 4030,
        /// <summary>
        /// 此批憑證部分失敗
        /// </summary>
        [Description("ApiResultCouponPartialFail")]
        CouponPartialFail = 4040,
        /// <summary>
        /// 此批憑證數量不足需核銷數
        /// </summary>
        [Description("ApiResultCouponQtyNotEnough")]
        CouponQtyNotEnough = 4050,
        /// <summary>
        /// 憑證未使用
        /// </summary>
        [Description("ApiResultCouponUnused")]
        CouponUnused = 4060,

        #endregion 優惠券相關

        #region (5000) pcp相關
        /// <summary>
        /// 無法取得身份識別碼
        /// </summary>
        [Description("ApiResultCodeVerifyIdentityFail")]
        VerifyIdentityFail = 5000,
        /// <summary>
        /// 抵用券驗證失敗
        /// </summary>
        [Description("ApiResultCodeDiscountCodeError")]
        DiscountCodeError = 5010,
        /// <summary>
        /// Pcp交易失敗
        /// </summary>
        [Description("ApiResultCodePcpTransactionFail")]
        PcpTransactionFail = 5020,
        /// <summary>
        /// 消費者沒有足夠的紅利點數
        /// </summary>
        [Description("ApiResultCodePcpNotEnoughBonus")]
        PcpNotEnoughBonus = 5030,
        /// <summary>
        /// 超級紅利點折抵不可大於結帳金額
        /// </summary>
        [Description("ApiResultCodePcpSuperBonusOverAmount")]
        PcpSuperBonusOverAmount = 5031,
        /// <summary>
        /// 找不到會員卡資訊
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardNotFound")]
        MembershipCardNotFound = 5040,
        /// <summary>
        /// 會員卡星期六日不可使用
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardNotUsingSaturdayOrSunday")]
        MembershipCardNotUsingSaturdayOrSunday = 5041,
        /// <summary>
        /// 會員卡特殊假日無法使用
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardCanNotUsingExceptSpecialHoliday")]
        MembershipCardCanNotUsingExceptSpecialHoliday = 5042,
        /// <summary>
        /// 會員卡未啟用
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardUnable")]
        MembershipCardUnable = 5043,
        /// <summary>
        /// 會員卡未上架
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardUnopened")]
        MembershipCardUnopened = 5044,
        /// <summary>
        /// 會員卡不在上架期間
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardWithoutOpenTime")]
        MembershipCardWithoutOpenTime = 5045,
        /// <summary>
        /// 會員卡不在有效期間
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardWithoutTimeOfEffect")]
        MembershipCardWithoutTimeOfEffect = 5046,
        /// <summary>
        /// 會員卡不可在這間店使用
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardCanNotUsingThisStore")]
        MembershipCardCanNotUsingThisStore = 5047,
        /// <summary>
        /// Pcp identity code 已過期
        /// </summary>
        [Description("ApiResultCodePcpPcpCodeIsExpired")]
        PcpCodeIsExpired = 5050,
        /// <summary>
        /// Pcp identity code 已使用過
        /// </summary>
        [Description("ApiResultCodePcpPcpCodeIsUsed")]
        PcpCodeIsUsed = 5051,
        /// <summary>
        /// Pcp identity code 已作廢
        /// </summary>
        [Description("ApiResultCodePcpPcpCodeIsCancel")]
        PcpCodeIsCancel = 5052,
        /// <summary>
        /// 熟客卡已發行
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardWasIssued")]
        MembershipCardWasIssued = 5060,
        /// <summary>
        /// 熟客卡已作廢
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardWasCancelled")]
        MembershipCardWasCancelled = 5061,
        /// <summary>
        /// 熟客卡已過有效期限
        /// </summary>
        [Description("ApiResultCodePcpMembershipCardExpire")]
        MembershipCardExpire = 5062,
        /// <summary>
        /// 熟客卡分店寫入錯誤
        /// </summary>
        [Description("ApiResultCodeMembershipCardStoreSaveError")]
        MembershipCardStoreSaveError = 5063,
        /// <summary>
        /// 商家沒有足夠的熟客點
        /// </summary>
        [Description("ApiResultCodeStoreRegularsPointNotEnough")]
        StoreRegularsPointNotEnough = 5070,
        /// <summary>
        /// 商家沒有足夠的公關點
        /// </summary>
        [Description("ApiResultCodeStoreFavorPointNotEnough")]
        StoreFavorPointNotEnough = 5071,
        /// <summary>
        /// 商家沒有足夠的Pcp點數
        /// </summary>
        [Description("ApiResultCodeStorePcpPointNotEnough")]
        StorePcpPointNotEnough = 5072,
        /// <summary>
        /// 推播產生名單失敗
        /// </summary>
        [Description("ApiResultCodePushPcpInsertUserListFail")]
        PushPcpInsertUserListFail = 5080,
        /// <summary>
        /// 目前停止推播功能
        /// </summary>
        [Description("ApiResultCodePushPcpDisable")]
        PushPcpDisable = 5081,
        /// <summary>
        /// 推播失敗
        /// </summary>
        [Description("ApiResultCodePushPcpFail")]
        PushPcpFail = 5082,
        /// <summary>
        /// 找不到核銷記錄
        /// </summary>
        [Description("ApiResultCodePcpOrderNotFound")]
        PcpOrderNotFound = 5090,
        /// <summary>
        /// 已取消核銷過
        /// </summary>
        [Description("ApiResultCodePcpVerifyCancelled")]
        PcpVerifyCancelled = 5091,
        /// <summary>
        /// 找不到賣家資訊
        /// </summary>
        [Description("ApiResultCodePcpSellerNotFound")]
        PcpSellerNotFound = 5092,
        /// <summary>
        /// 找不到分店
        /// </summary>
        [Description("ApiResultCodePcpStoreNotFound")]
        PcpStoreNotFound = 5093,
        /// <summary>
        /// 不是當初核銷的分店
        /// </summary>
        [Description("ApiResultCodePcpStoreNotMatch")]
        PcpStoreNotMatch = 5094,
        /// <summary>
        /// 找不到熟客卡資訊
        /// </summary>
        [Description("ApiResultCodePcpVbsSellerMemberNotFound")]
        PcpVbsSellerMemberNotFound = 5095,
        /// <summary>
        /// 找不到賣家階層關聯資料
        /// </summary>
        [Description("ApiResultCodePcpSellerTreeNotFound")]
        PcpSellerTreeNotFound = 5096,
        /// <summary>
        ///不是廠商提供序號的檔次
        /// </summary>
        [Description("ApiResultCodePcpPezEventNotFound")]
        PcpPezEventNotFound = 5097,
        /// <summary>
        ///找不到此序號
        /// </summary>
        [Description("ApiResultCodePcpSerialNotFound")]
        PcpSerialNotFound = 5098,
        /// <summary>
        ///同意條款尚未同意
        /// </summary>
        [Description("ApiResultCodePcpSerialNotFound")]
        PcpAgreementNotAccept = 5099,
        /// <summary>
        ///尚未領卡成功
        /// </summary>
        [Description("PcpApplyCardFail")]
        PcpApplyCardFail = 5100,
        /// <summary>
        ///所有序號並非存在同一張訂單
        /// </summary>
        [Description("PcpSerialsNotSameOrder")]
        PcpSerialsNotSameOrder = 5101,
        /// <summary>
        ///所有序號並非同個店家所核銷
        /// </summary>
        [Description("PcpSerialsNotSameStore")]
        PcpSerialsNotSameStore = 5102,
        #endregion pcp相關

        #region (6000) skm return code 

        /// <summary>
        /// 驗證 skm 會員失敗
        /// </summary>
        [Description("ApiResultSkmMemberVaildateFail")]
        SkmMemberVaildateFail = 6000,
        /// <summary>
        /// skm 總館不存在
        /// </summary>
        [Description("ApiResultSkmSellerIsNull")]
        SkmSellerIsNull = 6010,
        /// <summary>
        /// 燒點失敗
        /// </summary>
        [Description("ApiResultSkmBurningFail")]
        SkmBurningFail = 6020,
        /// <summary>
        /// 燒點失敗 - 未傳APP卡號
        /// </summary>
        [Description("ApiResultSkmBurningFailCardNoIsNull")]
        SkmBurningFailCardNoIsNull = 6021,
        /// <summary>
        /// 燒點失敗 - 新增燒點Log失敗
        /// </summary>
        [Description("ApiResultSkmBurningFailOrderLogError")]
        SkmBurningFailOrderLogError = 6022,
        /// <summary>
        /// 活動獎項抽完
        /// </summary>
        [Description("ApiResultDrawEventDrawOut")]
        DrawEventDrawOut = 6030,
        /// <summary>
        /// 活動異常
        /// </summary>
        [Description("ApiResultDrawEventError")]
        DrawEventError = 6031,
        /// <summary>
        /// 超過活動(單日)參與次數上限
        /// </summary>
        [Description("ApiResultDrawEventOverDailyLimit")]
        DrawEventOverDailyLimit = 6032,
        /// <summary>
        /// 超過活動(總)參與次數上限
        /// </summary>
        [Description("ApiResultDrawEventOverTotailLimit")]
        DrawEventOverTotailLimit = 6033,
        /// <summary>
        /// 抽獎建立零元檔失敗(MakeOrder)
        /// </summary>
        [Description("ApiResultMakePrizeDrawOrderFail")]
        MakePrizeDrawOrderFail = 6034,
        /// <summary>
        /// 更新抽獎紀錄兌換館別失敗
        /// </summary>
        [Description("ApiResultUpdatePrizeDrawExchangeShopCodeFail")]
        UpdatePrizeDrawExchangeShopCodeFail = 6035,
        /// <summary>
        /// 傳送中獎紀錄API失敗
        /// </summary>
        [Description("ApiResultSendPrizeDataFail")]
        SendPrizeDataFail = 6036,
        /// <summary>
        /// 傳送中獎紀錄API失敗 - 參數有誤
        /// </summary>
        [Description("ApiResultSendPrizeDataFailInputError")]
        SendPrizeDataFailInputError = 6037,
        /// <summary>
        /// SKM PAY 建立訂單異常
        /// </summary>
        [Description("ApiResultSkmPayOrderAddError")]
        SkmPayOrderAddError = 6040,
        /// <summary>
        /// Wallet server 授權交易失敗
        /// </summary>
        [Description("ApiResultSkmPayAuthPaymentError")]
        SkmPayAuthPaymentError = 6041,
        /// <summary>
        /// Wallet server 等待OTP回傳驗證狀態
        /// </summary>
        [Description("ApiResultSkmPayWaitingOTPResult")]
        SkmPayWaitingOTPResult = 6050,
        /// <summary>
        /// Wallet server OTP驗證失敗
        /// </summary>
        [Description("ApiResultSkmPayOTPError")]
        SkmPayOTPError = 6051,
        /// <summary>
        /// OTP驗證逾時(超過config設定的訪問次數上限)
        /// </summary>
        [Description("ApiResultSkmPayOTPTimeout")]
        SkmPayOTPTimeout = 6052,

        /// <summary>
        /// 開立發票失敗
        /// </summary>
        [Description("ApiResultSkmPayCreateInvoiceFail")]
        CreateInvoiceFail = 6101,
        /// <summary>
        /// SKM更新庫存失敗
        /// </summary>
        [Description("ApiResultSkmUpdateGiftInventoryFail")]
        SkmUpdateGiftInventoryFail = 6051,
        #endregion

        #region (7000) 台新行動錢包支付 wallet pay 

        /// <summary>
        /// 查無資料
        /// </summary>
        [Description("ApiResultCodeWpNotFound")]
        WpNotFound = 7000,
        /// <summary>
        /// 手機號碼格式錯誤
        /// </summary>
        [Description("ApiResultCodeWpMobileError")]
        WpMobileError = 7100,
        /// <summary>
        /// 信用卡號輸入錯誤
        /// </summary>
        [Description("ApiResultCodeWpCreditCardError")]
        WpCreditCardError = 7101,
        /// <summary>
        /// 信用卡到期年月輸入錯誤
        /// </summary>
        [Description("ApiResultCodeWpCardExpireDateError")]
        WpCardExpireDateError = 7102,
        /// <summary>
        /// 信用卡後三碼輸入錯誤
        /// </summary>
        [Description("ApiResultCodeWpCardCvvError")]
        WpCardCvvError = 7103,
        /// <summary>
        /// 信用卡名稱輸入錯誤
        /// </summary>
        [Description("ApiResultCodeWpCardNameError")]
        WpCardNameError = 7104,
        /// <summary>
        /// CheckSum驗證失敗
        /// </summary>
        [Description("ApiResultCodeWpCheckSumError")]
        WpCheckSumError = 7105,
        /// <summary>
        /// Token已過期
        /// </summary>
        [Description("ApiResultCodeWpTokenExpired")]
        WpTokenExpired = 7106,
        /// <summary>
        /// 信用卡交易失敗
        /// </summary>
        [Description("ApiResultCodeWpTradeFailure")]
        WpTradeFailure = 7200,
        /// <summary>
        /// 信用卡交易成功
        /// </summary>
        [Description("ApiResultCodeWpTradeSuccess")]
        WpTradeSuccess = 7201,
        /// <summary>
        /// CardToken過期
        /// </summary>
        [Description("ApiResultCodeWpCardTokenError")]
        WpCardTokenError = 7202,
        /// <summary>
        /// 條碼驗證失敗
        /// </summary>
        [Description("ApiResultCodeWpBarcodeError")]
        WpBarcodeError = 7300,
        /// <summary>
        /// 條碼驗證失敗
        /// </summary>
        [Description("ApiResultCodeWpTspgRtnError")]
        WpTspgRtnError = 7400,

        #endregion

        #region (8000) 17Life Payment Result Code

        /// <summary>
        /// 驗證訂單資料錯誤
        /// </summary>
        [Description("ApiResultCodePaymentCheckOrderFail")]
        PaymentCheckOrderFail = 8000,
        /// <summary>
        /// 取得憑證失敗
        /// </summary>
        [Description("ApiResultCodePaymentGetCouponFail")]
        PaymentGetCouponFail = 8010,
        /// <summary>
        /// 檔次尚未開賣
        /// </summary>
        [Description("ApiResultCodePaymentCanNotOrderDeal")]
        PaymentCanNotOrderDeal = 8020,
        /// <summary>
        /// 信用卡資訊有誤
        /// </summary>
        [Description("ApiResultCodePaymentCreditcardInfoError")]
        PaymentCreditcardInfoError = 8030,
        /// <summary>
        /// Masterpass 資訊錯誤
        /// </summary>
        [Description("ApiResultCodeMasterpassDataError")]
        MasterpassDataError = 8040,
        /// <summary>
        /// Get Masterpass Data Fail
        /// </summary>
        [Description("ApiResultCodeMasterpassDataNotFound")]
        MasterpassDataNotFound = 8041,
        /// <summary>
        /// Masterpass 資料已使用
        /// </summary>
        [Description("ApiResultCodeMasterpassDataIsUsed")]
        MasterpassDataIsUsed = 8042,
        /// <summary>
        /// 付款發生錯誤
        /// </summary>
        [Description("ApiResultCodePaymentError")]
        PaymentError = 8050,
        /// <summary>
        /// 商品庫存不足
        /// </summary>
        [Description("ApiResultCodeOutofLimitOrderError")]
        OutofLimitOrderError = 8060,
        /// <summary>
        /// 很抱歉，您所購買的好康已結束！
        /// </summary>
        [Description("ApiResultCodeDealClosed")]
        DealClosed = 8070,
        /// <summary>
        /// 折價券已使用過
        /// </summary>
        [Description("ApiResultCodeDiscountCodeIsUsed")]
        DiscountCodeIsUsed = 8080,
        /// <summary>
        /// 折價券更新狀態時發生錯誤
        /// </summary>
        [Description("ApiResultCodeDiscountCodeUsingError")]
        DiscountCodeUsingError = 8090,
        /// <summary>
        /// 查無記憶信用卡
        /// </summary>
        [Description("ApiResultCodeCreditcardNotFound")]
        CreditcardNotFound = 8100,
        /// <summary>
        /// ATM可訂購商品已額滿
        /// </summary>
        [Description("ApiResultCodeATMDealsFull")]
        ATMDealsFull = 8110,

        #endregion

        #region 贈禮相關

        /// <summary>
        /// 查無贈禮
        /// </summary>
        [Description("查無贈禮")]
        GiftNotFound = 9201,
        /// <summary>
        /// 兌換連結已失效
        /// </summary>
        [Description("兌換連結已失效")]
        UrlExpired = 9202,
        /// <summary>
        /// 您已經領取
        /// </summary>
        [Description("您已經領取")]
        AllreadyReceived = 9203,
        /// <summary>
        /// 贈禮已被領取
        /// </summary>
        [Description("贈禮已被領取")]
        AllreadyReceived2 = 9204,
        /// <summary>
        /// 查無訂單(E01)
        /// </summary>
        [Description("查無訂單(E01)")]
        OrderNotFound = 9205,
        /// <summary>
        /// 查無訂單(E01)
        /// </summary>
        [Description("查無訂單(E02)")]
        NotOrderOwner = 9206,
        #endregion
    }
}
