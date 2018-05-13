using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 貨幣在庫クラス
    /// </summary>
    public class MoneyStorage
    {
        private Dictionary<MoneyKind, Stock> stocker = new Dictionary<MoneyKind, Stock>();

        public MoneyStorage()
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
        public void Stock(MoneyKind kind, int amount = 1)
        {
            stocker[kind].Add(amount);
        }

        #region 両替できるか

        public bool CanExchangeTo100Yen(int amount)
        {
            int count = amount / MoneyKind.ONE_HUNDRED.GetPrice();
            return (Count(MoneyKind.ONE_HUNDRED) - count) >= 0;
        }

        public bool CanExchangeTo50Yen(int amount)
        {
            int count = amount / MoneyKind.FIFTY.GetPrice();
            return (Count(MoneyKind.FIFTY) - count) >= 0;
        }

        public bool CanExchangeTo10Yen(int amount)
        {
            int count = amount / MoneyKind.TEN.GetPrice();
            return (Count(MoneyKind.TEN) - count) >= 0;
        }
        #endregion
    }
}
