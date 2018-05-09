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
        /// <summary>
        /// お金の種類
        /// </summary>
        private MoneyKind kind;


        private Money(MoneyKind kind)
        {
            this.kind = kind;
        }

        public static Money Add(MoneyKind kind)
        {
            return new Money(kind);
        }

        /// <summary>
        /// 金額を取得する
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            return (int)kind;
        }

    }
}
