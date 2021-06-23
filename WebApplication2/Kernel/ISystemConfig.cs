using LifeEnterpot.Core.ModelCustom;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeEnterpot.Core.Kernel
{
    public interface ISystemConfig
    {
        string ImagesBaseUrl { get; set; }
        int Port { get; set; }
        string ConnectionString { get; set; }
        string ContentsFolder { get; set; }
        string ImagesFolder { get; set; }
        bool LaunchBrowser { get; set; }
        string PdfFile { get; set; }
        string BackendSiteUrl { get; set; }
        string LocalhostAsChannel { get; set; }
        int NoneCreditRefundPeriod { get; set; }
        int SendUnitNo { get; set; }
        int ReceiveUnitNo { get; set; }
        string TriggerBankAndBranchNo { get; set; }
        string TriggerAccountNo { get; set; }
        string TriggerCompanyId { get; set; }
        string WindowServiceToken { get; set; }
        string GoogleAnalyticsDataViewId { get; set; }
        PayeasyConfig Payeasy { get; set; }
        E7lifeConfig E7life { get; set; }
        string TemplateFolder { get; set; }
        string TemplateExcelFolder { get; set; }
        PaymentConfig Payment { get; set; }
        AppLayoutChannelConfig AppLayoutChannel { get; set; }
        SmtpConfig SmtpSetting { get; set; }
        bool EnableFakePay { get; set; }
        S3ServiceConfig S3Service { get; set; }
        BypassCreditcardPaymentConfig BypassCreditcardPayment { get; set; }
        HomepageChannelConfig HomepageChannel { get; set; }
        SearchApiConfig SearchApi { get; set; }
        SeachBiConfig SearchBi { get; set; }
        int CardailyMonthlyOrderReportDay { get; set; }
        int DefaultCacheMinute { get; set; }
        int TaishinDefaultCacheMinute { get; set; }
        List<TaishinProductDealList> APP_TodayHotDeals { get; set; }
    }
    public class S3ServiceConfig
    {
        public string AwsAccessKeyID { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string BucketName { get; set; }
        public string S3Uri { get; set; }
        public string PdfBucketName { get; set; }
    }
    public class PayeasyConfig
    {
        public PayeasyOperationWebServiceConfig OperationWebService { get; set; }
    }
    public class AppLayoutChannelConfig
    {
        public AppLayoutChannelImageConfig Shopping { get; set; }
        public AppLayoutChannelImageConfig Food { get; set; }
        public AppLayoutChannelImageConfig Travel { get; set; }
        public AppLayoutChannelImageConfig Beauty { get; set; }
    }
    public class AppLayoutChannelImageConfig
    {
        public string Name { get; set; }
        public string ChannelId { get; set; }
        public string ImageUrl { get; set; }
    }

    public class PayeasyOperationWebServiceConfig
    {
        public string Host { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class E7lifeConfig
    {
        public E7lifeCategoryApiServiceConfig CategoryApiService { get; set; }
        public string AuthToken { get; set; }
        public string MakeOrderApiUrl { get; set; }
        public string DealStoreApiUrl { get; set; }
        public string OrderInfoApiUrl { get; set; }
        public string FamiStoreApiUrl { get; set; }
        public string BankInfoList { get; set; }
        public string CityTownApiUrl { get; set; }
        public string VacationApiUrl { get; set; }
        public string CheckCouponStatus { get; set; }
        public string CreateTsIssueUrl { get; set; }
        public string CreateTsOrderIssueUrl { get; set; }
        public string RefundUrl { get; set; }
        public string GetReturnFormStatusUrl { get; set; }
        public string CouponDownloadUrl { get; set; }
        public string CreditNoteDownloadUrl { get; set; }
        public string GetMobileAuthCodeCheckUrl { get; set; }
        public string ServiceTel { get; set; }
        public string ServiceMail { get; set; }
        public string ReportMail { get; set; }
        public string IT_ServiceMail { get; set; }
        public string CustomerServiceMail { get; set; }
        public string ECPayEinvoiceSetUrl { get; set; }
        public string ECPayEinvoiceCancelUrl { get; set; }
        public string ECPayEinvoiceGetUrl { get; set; }
        public string ECPayWinnerEinvoiceGetUrl { get; set; }
        public string EcPayCheckCarrierIdUrl { get; set; }
        public string EcPayCheckLoveCodeUrl { get; set; }
    }
    public class E7lifeCategoryApiServiceConfig
    {
        public string RootCategoriesApiUrl { get; set; }
        public string SubCategoriesApiUrl { get; set; }
        public string DealListApiUrl { get; set; }
        public string DealApiUrl { get; set; }
    }

    public class PaymentConfig
    {
        public string LetsPayWSMID { get; set; }
        public string LetsPayGetAuthAPIUrl { get; set; }
        public string LetsPayRefundAPIUrl { get; set; }
        public string LetsPayToken { get; set; }
        public string TaiShinMerchantID { get; set; }
        public string TaiShinTerminalID { get; set; }
        public string TaiShin3DTerminalID { get; set; }
        public string TaiShinPaymentUrl { get; set; }
        public string TaiShinPaymentRedeem { get; set; }
        public int ReturnDelayDays { get; set; }
    }

    public class SmtpConfig
    {
        public string SmtpServerHost { get; set; }
        public int SmtpServerPort { get; set; }
        public string ServiceSendEmail { get; set; }
        public string ServiceSendName { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool UsingLocalhost { get; set; }
    }

    public class BypassCreditcardPaymentConfig
    {
        public bool Enabled { get; set; }
        public string CardNumber { get; set; }
    }

    public class HomepageChannelConfig
    {
        public HomepageChannelImageConfig Electronic { get; set; }
        public HomepageChannelImageConfig Appliances { get; set; }
        public HomepageChannelImageConfig Home { get; set; }
        public HomepageChannelImageConfig Sports { get; set; }
        public HomepageChannelImageConfig Travel { get; set; }
        public HomepageChannelImageConfig Food { get; set; }
        public HomepageChannelImageConfig Beauty { get; set; }
        public HomepageChannelImageConfig Shopping { get; set; }
    }

    public class HomepageChannelImageConfig
    {
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }

    public class SearchApiConfig
    {

        public string DevSite { get; set; }
        public string AuthToken { get; set; }
    }

    public class SeachBiConfig
    {
        public string BiSite { get; set; }
        public string AuthToken { get; set; }
    }


    public class SystemConfig : ISystemConfig
    {
        static ILog logger = LogManager.GetLogger(typeof(SystemConfig));
        public string ImagesBaseUrl { get; set; }
        public int Port { get; set; }
        public string ConnectionString { get; set; }
        public string ContentsFolder { get; set; }
        public string ImagesFolder { get; set; }
        public string PdfFile { get; set; }
        public string BackendSiteUrl { get; set; }
        public bool LaunchBrowser { get; set; }
        public string LocalhostAsChannel { get; set; }
        public int NoneCreditRefundPeriod { get; set; }
        public int SendUnitNo { get; set; }
        public int ReceiveUnitNo { get; set; }
        public string TriggerBankAndBranchNo { get; set; }
        public string TriggerAccountNo { get; set; }
        public string TriggerCompanyId { get; set; }
        public string WindowServiceToken { get; set; }
        public string GoogleAnalyticsDataViewId { get; set; }
        public PayeasyConfig Payeasy { get; set; }
        public E7lifeConfig E7life { get; set; }
        public string TemplateFolder { get; set; }
        public string TemplateExcelFolder { get; set; }
        public PaymentConfig Payment { get; set; }
        public AppLayoutChannelConfig AppLayoutChannel { get; set; }
        public SmtpConfig SmtpSetting { get; set; }
        public bool EnableFakePay { get; set; }
        public string GetMobileAuthCodeCheckUrl { get; set; }
        public string ServiceTel { get; set; }
        public string ServiceMail { get; set; }
        public S3ServiceConfig S3Service { get; set; }
        public BypassCreditcardPaymentConfig BypassCreditcardPayment { get; set; }
        public HomepageChannelConfig HomepageChannel { get; set; }
        public SearchApiConfig SearchApi { get; set; }
        public SeachBiConfig SearchBi { get; set; }
        public int CardailyMonthlyOrderReportDay { get; set; }
        public int DefaultCacheMinute { get; set; }
        public int TaishinDefaultCacheMinute { get; set; }
        public List<TaishinProductDealList> APP_TodayHotDeals { get; set; }

        //public static SystemConfig Reload()
        //{
        //    string configFile = Helper.MapPath(string.Format("config.{0}.json", System.Environment.MachineName));
        //    if (File.Exists(configFile) == false)
        //    {
        //        configFile = Helper.MapPath("config.json");
        //    }
        //    logger.Warn("載入 " + configFile);
        //    string json = File.ReadAllText(configFile);
        //    return JsonConvert.DeserializeObject<SystemConfig>(json);
        //}
    }
}
