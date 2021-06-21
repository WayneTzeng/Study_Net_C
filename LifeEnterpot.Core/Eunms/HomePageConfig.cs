using System;
using System.Collections.Generic;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    public enum ReviewStatus
    {
        /// <summary>
        /// 退回
        /// </summary>
        Return = -1,
        /// <summary>
        /// 送審中
        /// </summary>
        Submit = 0,
        /// <summary>
        /// 送審通過
        /// </summary>
        Pass = 1,
        /// <summary>
        /// 預覽
        /// </summary>
        Preview = 99
    }

    public enum BlockLatest
    {
        /// <summary>
        /// 送審
        /// </summary>
        Submit = -1,
        /// <summary>
        /// 舊的
        /// </summary>
        Past = 0,
        /// <summary>
        /// 最新的
        /// </summary>
        Latest = 1,
        /// <summary>
        /// 預覽
        /// </summary>
        Preview = 99
    }

    public enum SectionSeq
    {
        /// <summary>
        /// 商城名稱
        /// </summary>
        Name = 1,
        /// <summary>
        /// 輪播Banner
        /// </summary>
        Banner = 2,
        /// <summary>
        /// 頻道
        /// </summary>
        Channel = 3,
        /// <summary>
        /// 本週熱賣
        /// </summary>
        Hot = 4,
        /// <summary>
        /// 策展版型一
        /// </summary>
        Version1 = 5,
        /// <summary>
        /// 策展版型二
        /// </summary>
        Version2 = 6,
        /// <summary>
        /// 策展版型三
        /// </summary>
        Version3 = 7,
        /// <summary>
        /// 策展活動banner
        /// </summary>
        ActiveBanner = 8
    }

    public enum HamePageChannel
    {
        /// <summary>
        /// 3C
        /// </summary>
        Electronic = 200029663,
        /// <summary>
        /// 家電
        /// </summary>
        Appliances = 200029664,
        /// <summary>
        /// 居家/餐廚/寢飾
        /// </summary>
        Home = 200029659,
        /// <summary>
        /// 運動/戶外/休閒
        /// </summary>
        Sports = 200029662,
        /// <summary>
        /// 旅遊
        /// </summary>
        Travel = 100000090,
        /// <summary>
        /// 美食
        /// </summary>
        Food = 100000087,
        /// <summary>
        /// 玩美休閒
        /// </summary>
        Beauty = 100000089,
        /// <summary>
        /// 宅配
        /// </summary>
        Shopping = 200000000
    }

    public enum HamePageMemo
    {
        /// <summary>
        /// 策展過期
        /// </summary>
        CurationExpired = 1,
        /// <summary>
        /// 檔次不足
        /// </summary>
        ProductShortage = 2
    }
}
