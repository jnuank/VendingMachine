using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace VendingMachine.Domain
{
    /// <summary>
    /// ドリンクの種類
    /// </summary>
    public enum DrinkKind
    {
        [Description("コーラ")]
        Coke = 0,
        [Description("お茶")]
        Tea,
        [Description("サイダー")]
        Cider
    }
}
