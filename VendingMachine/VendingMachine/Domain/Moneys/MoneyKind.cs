using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain
{
    /// <summary>
    /// お金クラス
    /// </summary>
    public enum MoneyKind
    {
        // Todo: 列挙型はやっぱり連番じゃないとあかんな。
        // for文で回すことも出来ないし。MAXとか付けられないし。

        [Description("1円")]
        ONE = 1,
        [Description("5円")]
        FIVE = 5,
        [Description("10円")]
        TEN = 10,
        [Description("50円")]
        FIFTY = 50,
        [Description("100円")]
        ONE_HUNDRED = 100,
        [Description("500円")]
        FIVE_HUNDRED = 500,
        [Description("1000円")]
        THOUSAND = 1000,
        [Description("2000円")]
        TWO_THOUSAND = 2000,
        [Description("5000円")]
        FIVE_THOUSAND = 5000,
        [Description("10000円")]
        TEN_THOUSAND = 10000,
    }
}
