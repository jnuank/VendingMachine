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
        COKE = 0,
        [Description("お茶")]
        TEA,
        [Description("サイダー")]
        CIDER,
        MAX,
    }
}
