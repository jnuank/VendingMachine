using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class CoinStocker
    {
        private Dictionary<MoneyKind, Stock> stocker = new Dictionary<MoneyKind, Stock>();

        public CoinStocker()
        {
            // 硬貨をストックしておく
            stocker.Add(MoneyKind.TEN, new Stock(10));
            stocker.Add(MoneyKind.ONE_HUNDRED, new Stock(10));
            stocker.Add(MoneyKind.FIFTY, new Stock(10));
            stocker.Add(MoneyKind.FIVE_HUNDRED, new Stock(1));
            stocker.Add(MoneyKind.THOUSAND, new Stock(10));
        }

        /// <summary>
        /// 現在ストックしている硬貨の全金額を取得する
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            int amount = 0;

            amount += MoneyKind.TEN.GetPrice() * stocker[MoneyKind.TEN].Count();
            amount += MoneyKind.ONE_HUNDRED.GetPrice() * stocker[MoneyKind.ONE_HUNDRED].Count();
            amount += MoneyKind.FIFTY.GetPrice() * stocker[MoneyKind.FIFTY].Count();
            amount += MoneyKind.FIVE_HUNDRED.GetPrice() * stocker[MoneyKind.FIVE_HUNDRED].Count();

            return amount;
        }

        /// <summary>
        /// 指定した種類のお金があるか
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public bool IsStock(MoneyKind kind, int count = 1)
        {
            return stocker[kind].Count() >= count;
        }

        public int Count(MoneyKind kind)
        {
            return stocker[kind].Count();   
        }

        /// <summary>
        /// 指定した金額をストックする
        /// </summary>
        /// <param name="kind"></param>
        public void Stock(MoneyKind kind)
        {
            stocker[kind].Add(1);
        }

        #region 両替できるか

        // Todo:名称とかひどいから後で直す
        public bool IsChange100(int amount)
        {
            int count = amount / 100;
            return (Count(MoneyKind.ONE_HUNDRED) - count) >= 0;
        }

        public bool IsChange50(int amount)
        {
            int count = amount / 50;
            return (Count(MoneyKind.FIFTY) - count) >= 0;
        }

        public bool IsChange10(int amount)
        {
            int count = amount / 10;
            return (Count(MoneyKind.TEN) - count) >= 0;
        }
        #endregion
    }
}
