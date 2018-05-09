using System.ComponentModel;
using VendingMachine.Domain.Drinks;

namespace VendingMachine.Domain
{
    /// <summary>
    /// ドリンクの種類
    /// </summary>
    public enum DrinkKind
    {
        [Description("コーラ")]
        [Price(120)]
        COKE = 0,
        [Description("お茶")]
        [Price(110)]
        TEA,
        [Description("サイダー")]
        [Price(130)]
        CIDER,
        MAX,
    }
}
