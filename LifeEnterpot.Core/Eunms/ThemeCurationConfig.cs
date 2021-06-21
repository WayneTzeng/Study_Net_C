using System.ComponentModel;

namespace LifeEnterpot.Core.Enums
{
    public enum ThemeCurationStatus
    {
        [Description("未啟用")]
        Init = 0,
        [Description("啟用")]
        Used = 1,
        [Description("作廢")]
        Delete = 2,
    }

    public enum ThemeCurationType
    {
        [Description("版型一")]
        Type001 = 1,
        //[Description("版型二")]
        //Type002 = 2,
        [Description("自訂版型")]
        TypeCustomize = 999,
    }

    public enum ThemeCurationStyle
    {
        [Description("沈穩酒紅")]
        Style001 = 5,
        [Description("喜慶紅彩")]
        Style002 = 6,
        [Description("粉紅佳人")]
        Style003 = 7,
        [Description("商務幽藍")]
        Style004 = 8,
    }

    public enum ThemeCurationSource
    {
        [Description("手動建立")]
        Manual = 1,
        [Description("匯入")]
        Import = 2,
    }

    //public enum ThemeCurationCategoryType
    //{
    //    [Description("主題")]
    //    Theme = 0,
    //    [Description("活動")]
    //    Activity = 1,
    //}

    public enum ThemeCurationApplyType
    {
        [Description("草稿")]
        Init = 0,
        [Description("送審")]
        Apply = 1,
        [Description("審核")]
        Audit = 2,
        [Description("退回")]
        Return = 4
    }
}
