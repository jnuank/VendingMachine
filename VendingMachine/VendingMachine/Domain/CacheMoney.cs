﻿using System;
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
        /// プールしているお金を渡す
        /// </summary>
        /// <returns></returns>
        public int Amount()
        {
            int amount = 0;
            foreach (var money in cache)
            {
                amount += (int)money;
            }
            return amount;
        }
    }
}