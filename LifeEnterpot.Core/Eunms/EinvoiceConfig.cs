using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LifeEnterpot.Core.Enums
{
    public enum EinvoiceFromType
    {
        System = 0,
        Contact = 1,
        Payeasy = 2,
    }

    public enum EinvoiceType
    {
        NotComplete = -1,
        Initial = 0,
        [Description("開立")]
        C0401 = 1,
        [Description("折讓")]
        D0401 = 2,
        [Description("作廢")]
        C0501 = 3,
        D0501 = 4,
        [Description("註銷")]
        C0701 = 11,
    }

    public enum InvoiceMode2
    {
        /// <summary>
        /// 三聯式
        /// </summary>
        [Description("三聯式")]
        Triplicate = 1,
        /// <summary>
        /// 二聯式
        /// </summary>
        [Description("二聯式")]
        Duplicate = 2
    }

    /// <summary>
    /// 載具類型
    /// </summary>
    public enum CarrierType
    {
        /// <summary>
        /// 無(個人紙本發票(二聯式)/捐贈發票/公司式紙本發票(三聯式))
        /// </summary>
        [Description("無(紙本)")]
        None = 0,
        /// <summary>
        /// 平台載具 EJ0018
        /// </summary>
        [Description("平台載具")]
        Member = 1,
        /// <summary>
        /// 手機條碼載具 3J0002
        /// </summary>
        [Description("手機條碼")]
        Phone = 2,
        /// <summary>
        /// 自然人憑證載具 CQ0001
        /// </summary>
        [Description("自然人憑證")]
        PersonalCertificate = 3
    }

    public enum AllowanceStatus
    {
        /// <summary>
        /// 紙本折讓
        /// </summary>
        [Description("紙本折讓")]
        PaperAllowance = 1,
        /// <summary>
        /// 電子折讓
        /// </summary>
        [Description("電子折讓")]
        ElecAllowance = 2,
        /// <summary>
        /// 不需折讓
        /// </summary>
        [Description("不需折讓")]
        None = 3,
    }
}
