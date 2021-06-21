using System.ComponentModel;

namespace LifeEnterpot.Core.Enums
{
    public enum TemplateConfig
    {
        [Description("付款成功-宅配")]
        Payment_HomeDelivery = 0,
        [Description("付款成功-憑證")]
        Payment_Certificate = 1,
        [Description("退貨申請-宅配-三聯式")]
        RefundApply_HomeDelivery_Triple = 2,
        [Description("退貨申請-宅配-非三聯式")]
        RefundApply_HomeDelivery_AntiTriple = 3,
        [Description("退貨申請-憑證-三聯式")]
        RefundApply_Certificate_Triple = 4,
        [Description("退貨申請-憑證-非三聯式")]
        RefundApply_Certificate_AntiTriple = 5,
        [Description("退貨成功")]
        Refund = 6,
        [Description("客服回覆")]
        CustomerService = 7,
        [Description("結清帳號")]
        CloseAccount = 8,
        [Description("月報表提醒")]
        MonthlyReportRemind = 9,
        [Description("系統通知信")]
        SystemNotify = 10,
    }

    public enum CardailyReportType
    {
        [Description("Richart Life平台日報表")]
        CardailyDailyReport = 1,
        [Description("Richart Life軟文平台日報表")]
        CardailyArticleDailyReport = 2,
        [Description("客服客訴量日報表")]
        CardailyCustomerDailyReport = 3,
        [Description("Richart Life平台運營月報表")]
        CardailyMonthlyOrderReport = 4,
        [Description("Richart Life平台運營月報表")]
        CardailyAnalyzeReport = 5
    }
}
