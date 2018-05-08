﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            stocker.Add(MoneyKind.FIVE_HUNDRED, new Stock(10));
        }

        /// <summary>
        /// 現在ストックしている硬貨の全金額を取得する
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            int amount = 0;

            amount += (int)MoneyKind.TEN * stocker[MoneyKind.TEN].Count();
            amount += (int)MoneyKind.ONE_HUNDRED * stocker[MoneyKind.ONE_HUNDRED].Count();
            amount += (int)MoneyKind.FIFTY * stocker[MoneyKind.FIFTY].Count();
            amount += (int)MoneyKind.FIVE_HUNDRED * stocker[MoneyKind.FIVE_HUNDRED].Count();

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
        /// 指定した種類のお金を返す
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public Money Pop(MoneyKind kind)
        {
            return Money.Add(kind);
        }

        
    }
}
