using System;
using System.Collections.Generic;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    /// <summary>
    /// OAuth Token使用權限
    /// </summary>
    public enum TokenScope
    {
        Undefined = 0,
        /// <summary>
        /// 對內網站功能
        /// </summary>
        SystemManagement = 100,
        /// <summary>
        /// 訪客API存取權限
        /// </summary>
        QuestAccess = 200,
        User = 1000 /*user*/,
        UserProfile = 1010,
        UserCash = 1020 /*user*/,
        UserPublish = 1030 /*user*/,
        Pay = 1040 /*user*/,
        VourcherPublish = 1050, /*user*/
        Deal = 2000, /*app*/
        Vourcher = 2010, /*app*/
        Verification = 2020, /*app*/

        /// <summary>
        /// app 基本參數、共用參數
        /// </summary>
        Publish = 2030,
        /// <summary>
        /// 雄獅旅行合作
        /// </summary>
        LionTravel = 2040,
        /// <summary>
        /// 新光三越 APP
        /// </summary>
        Skm = 2050,
        /// <summary>
        /// 新光三越 Umall專用API
        /// </summary>
        SkmUmall = 2051,
        /// <summary>
        /// POS 核銷串接
        /// </summary>
        PosVerify = 2060,
        /// <summary>
        /// 導購商
        /// </summary>
        ShoppingGuide = 2070,
        /// <summary>
        /// app 產生超長時間的 access_token (10年) ，方便我們自行產生 token 給合作廠商，
        /// 他們不需要顧慮token過期，也不用先用 client_id, client_secret 取得 token，簡化他們合作的流程
        /// </summary>
        LongLived = 3000,
        /// <summary>
        /// 產生時效一天的 access_token
        /// </summary>
        OnedayLived = 3010,
        /// <summary>
        /// 產生時效七天的 access_token
        /// </summary>
        OneWeekLived = 3020,
        /// <summary>
        /// 重取token
        /// </summary>
        RefreshToken = 3100
    }
}
