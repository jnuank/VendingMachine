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
        Money money = new Money(0);

        List<MoneyKind> cache = new List<MoneyKind>();

        /// <summary>
        /// お金を追加する
        /// </summary>
        /// <param name="amount"></param>
        public void Add(int amount)
        {
            money = money.Add(amount);
        }

        /// <summary>
        /// プールしているお金の金額を教える
        /// </summary>
        /// <returns></returns>
        public int Amount()
        {
            return money.GetAmount();
        }

        /// <summary>
        /// プールしているお金を返す
        /// </summary>
        /// <returns></returns>
        public int Refund()
        {
            return money.GetAmount();
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

        public void Minus(int amount)
        {
            money = money.Minus(amount);
        }
    }
}
