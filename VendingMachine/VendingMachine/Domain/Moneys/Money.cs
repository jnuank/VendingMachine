using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.Domain
{
    public class Money
    {
        // いくら持っているか
        private int amount;

        public Money(int amount)
        {
            this.amount = amount;
        }

        /// <summary>
        /// お金を足す
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>追加後Moneyインスタンス</returns>
        public Money Add(int amount)
        {
            int addedAmount = this.amount + amount;
            return new Money(addedAmount);
        }

        public Money Minus(int amount)
        {
            int minus = this.amount - amount;
            return new Money(minus);
        }

        /// <summary>
        /// 金額を取得する
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            return amount;
        }

    }
}
