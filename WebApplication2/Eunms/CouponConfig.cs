using System.ComponentModel;

namespace LifeEnterpot.Core.Enums
{
    public enum CouponCodeStatus
    {
        [Description("未啟用")]
        Init = 0,
        [Description("啟用")]
        Used = 1,
        [Description("作廢")]
        Void = 2,
        Delete = 3,
    }

    public enum CouponCodeType
    {
        [Description("手動歸戶(系統產)")]
        ManualImport = 0,
        [Description("不歸戶(系統產)")]
        PublicCode = 1,
        [Description("手動歸戶(自定義)")]
        ManualImportForCustom = 2,
        [Description("不歸戶(自定義)")]
        PublicCodeForCustom = 3
    }


    public enum SaleStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = 0,
        /// <summary>
        /// 等待中
        /// </summary>
        [Description("等待中")]
        Waiting = 1,
        /// <summary>
        /// 銷售中
        /// </summary>
        [Description("銷售中")]
        Sales = 2,
        /// <summary>
        /// 已結檔
        /// </summary>
        [Description("已結檔")]
        Closed = 3,
    }

    public enum GradeCondition
    {
        /// <summary>
        /// 請選擇
        /// </summary>
        [Description("請選擇")]
        Default = 0,
        /// <summary>
        /// 檔次BID
        /// </summary>
        [Description("檔次BID")]
        BID = 1,
        /// <summary>
        /// 訂單短標
        /// </summary>
        [Description("訂單短標")]
        Short = 2,
    }

	public enum OrderOperator
    {
        [Description(">")]
        Greater = 1,
        [Description(">=")]
        GreaterAndEqual = 2,
        [Description("=")]
        Equal = 3,
        [Description("<")]
        Less = 4,
        [Description("<=")]
        LessAndEqual = 5
    }

    public enum CouponUsePolicy
    {
        [Description("無門檻")]
        None = 0,
        [Description("訂單金額")]
        OrderAmt = 1,
        [Description("Richart Life錢包")]
        Cardaliy = 2,
    }
}
