using System;
using System.Collections.Generic;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    public enum DeliveryType
    {
        /// <summary>
        /// 憑證消費(到店)
        /// </summary>
        ToShop = 1,
        /// <summary>
        /// 宅配(到府)
        /// </summary>
        ToHouse = 2,

    }
    public enum ProductSearchKeyUseMode
    {
        NONE = 0,
        WEB = 1,
        RWD = 2,
        APP = 3,
        Mobile = 4
    }

    public enum PaymentRestrict
    {
        //[Description("純點數")]
        PointOnly = 1,
        //[Description("純現金")]
        CashOnly = 2,
        //[Description("點數+現金")]
        PointOrCash = 3
    }

    public enum CacheDataStatus
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        OK,
        /// <summary>
        /// 
        /// </summary>
        Expired
    }
}
