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
        int money = 0;

        List<MoneyKind> cache = new List<MoneyKind>();

        /// <summary>
        /// お金を追加する
        /// </summary>
        /// <param name="amount"></param>
        public void Add(int amount)
        {
            money += amount;
        }

        /// <summary>
        /// プールしているお金の金額を教える
        /// </summary>
        /// <returns></returns>
        public int Amount()
        {
            return money;
        }

        /// <summary>
        /// プールしているお金を返す
        /// </summary>
        /// <returns></returns>
        public int Refund()
        {
            int amount = money;

            money = 0;
            
            return amount;
        }

        public void Minus(int amount)
        {
            money -= amount;
        }
    }
}
