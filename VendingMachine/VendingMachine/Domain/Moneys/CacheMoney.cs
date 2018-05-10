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
        // 金額
        private int moneyAmount = 0;

        /// <summary>
        /// お金を追加する
        /// </summary>
        /// <param name="amount"></param>
        public void Add(int amount)
        {
            moneyAmount += amount;
        }

        /// <summary>
        /// プールしているお金の金額を教える
        /// </summary>
        /// <returns></returns>
        public int Amount()
        {
            return moneyAmount;
        }

        /// <summary>
        /// プールしているお金を返す
        /// </summary>
        /// <returns></returns>
        public int Refund()
        {
            int amount = moneyAmount;

            moneyAmount = 0;
            
            return amount;
        }

        public void Minus(int amount)
        {
            moneyAmount -= amount;
        }
    }
}
