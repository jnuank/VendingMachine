using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 入金したお金をプールする
    /// </summary>
    public class CacheMoney
    {
        List<MoneyKind> cache = new List<MoneyKind>();

        public void Add(MoneyKind kind)
        {
            cache.Add(kind);
        }

        /// <summary>
        /// プールしているお金の金額を教える
        /// </summary>
        /// <returns></returns>
        public int Amount()
        {
            return cache.Sum(money => (int)money);
        }

        /// <summary>
        /// プールしているお金を返す
        /// </summary>
        /// <returns></returns>
        public int Return()
        {
            int amount = this.Amount();
            cache.Clear();

            return amount;
        }


    }
}
