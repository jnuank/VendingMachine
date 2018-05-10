using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Moneys;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 入金したお金をプールする
    /// </summary>
    public class CacheMoney
    {
        Money money = new Money();

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
        public Change Refund()
        {
            return Change.Create(new List<MoneyKind>());
        }

        /// <summary>
        /// プールしているお金を取り出す
        /// </summary>
        /// <returns></returns>
        public List<MoneyKind> TakeOut()
        {
            List<MoneyKind> moneys = this.cache.ToList();
            cache.Clear();
            return moneys;
        }

        /// <summary>
        /// 指定した金額分、プールしているお金を取り出す
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public List<MoneyKind> TakeOut(int price)
        {
            price
        }

    }
}
