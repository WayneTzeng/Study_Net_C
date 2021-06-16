using System;
using System.Collections.Generic;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    /// <summary>
    /// 商品排序
    /// </summary>
    public enum CategorySortType
    {
        /// <summary>
        /// 預設
        /// </summary>
        Default,
        /// <summary>
        /// 最新
        /// </summary>
        TopNews,
        /// <summary>
        /// 銷量
        /// </summary>
        TopOrderTotal,
        /// <summary>
        /// 折數(低到高)
        /// </summary>
        DiscountAsc,
        /// <summary>
        /// 價格(高到低)
        /// </summary>
        PriceDesc,
        /// <summary>
        /// 價格(低到高)
        /// </summary>
        PriceAsc,
        /// <summary>
        /// 收藏數量(高到低)
        /// </summary>
        MemberCollectDesc,
        /// <summary>
        /// 收藏數量(低到高)
        /// </summary>
        MemberCollectAsc
    }

    public enum ChannelCategoryType
    {
        /// <summary>
        /// 未設定
        /// </summary>
        None = -1,
        /// <summary>
        /// 店家
        /// </summary>
        Seller = 0,
        /// <summary>
        /// 好康首頁分類
        /// </summary>
        PponFix = 1,
        /// <summary>
        /// 旅遊區域
        /// </summary>
        Travel = 2,
        /// <summary>
        /// 商圈
        /// </summary>
        CommercialCircle = 3,
        /// <summary>
        /// 團購頻道
        /// </summary>
        PponChannel = 4,
        /// <summary>
        /// 頻道區域分區
        /// </summary>
        PponChannelArea = 5,
        /// <summary>
        /// 檔次分類(新版分類2)
        /// </summary>
        DealCategory = 6,
        /// <summary>
        /// 取貨類型
        /// </summary>
        DeliveryType = 7,
        /// <summary>
        /// 商品特殊類型，會於頁面顯示ICON的
        /// </summary>
        DealSpecialCategory = 8,
        /// <summary>
        /// 優惠券
        /// </summary>
        Voucher = 9,
        /// <summary>
        /// 優惠券區域
        /// </summary>
        VoucherArea = 10,
        /// <summary>
        /// 優惠券類別
        /// </summary>
        VoucherCategory = 11,
        /// <summary>
        /// 區域(行政區)分類
        /// </summary>
        StandardRegion = 12,
        /// <summary>
        /// 區域(商圈、景點)分類
        /// </summary>
        SpecialRegion = 13,
        /// <summary>
        /// 熟客卡分類
        /// </summary>
        MembershipCard = 14,
        /// <summary>
        /// MRT 捷運附近店家 分類
        /// </summary>
        MRTLocation = 15,
    }

    public enum MemberAddressType
    {
        Add = 1,
        Deleted = 2
    }

    public enum CoffeeCouponType
    {
        Dante=2,
        Family=3,
        Hilife=4,

    }

    public enum DealDepositTtype
    {
        Coffee = 1,
        Coupon = 2,
    }
}
