using System.ComponentModel;

namespace VendingMachine.Domain
{
    /// <summary>
    /// お金クラス
    /// </summary>
    public enum MoneyKind
    {
        [Description("1円")]
        [Price(1)]
        ONE = 0,
        [Description("5円")]
        [Price(5)]
        FIVE,
        [Description("10円")]
        [Price(10)]
        TEN,
        [Description("50円")]
        [Price(50)]
        FIFTY,
        [Description("100円")]
        [Price(100)]
        ONE_HUNDRED,
        [Description("500円")]
        [Price(500)]
        FIVE_HUNDRED,
        [Description("1000円")]
        [Price(1000)]
        THOUSAND,
        [Description("2000円")]
        [Price(2000)]
        TWO_THOUSAND,
        [Description("5000円")]
        [Price(5000)]
        FIVE_THOUSAND,
        [Description("10000円")]
        [Price(10000)]
        TEN_THOUSAND,

        MAX
    }
}
