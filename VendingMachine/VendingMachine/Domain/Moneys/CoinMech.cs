using System;
using System.Collections.Generic;
using VendingMachine.Utility;

namespace VendingMachine.Domain.Moneys
{
    /// <summary>
    /// 硬貨を管理するクラス
    /// </summary>
    public class CoinMech
    {
        /// <summary>
        /// 入金したお金
        /// </summary>
        private CacheMoney cache = new CacheMoney();

        /// <summary>
        /// 硬貨在庫
        /// </summary>
        private CoinStocker coinStocker = new CoinStocker();


        /// <summary>
        /// コインメックにお金を追加する
        /// </summary>
        /// <param name="kind"></param>
        public void Add(MoneyKind kind)
        {
            // 1円、5円、2000円、5000円、10000円は受け付けない
            // これは業務ルール

            if (kind == MoneyKind.ONE)
                return;
            if (kind == MoneyKind.FIVE)
                return;
            if (kind == MoneyKind.TWO_THOUSAND)
                return;
            if (kind == MoneyKind.FIVE_THOUSAND)
                return;
            if (kind == MoneyKind.TEN_THOUSAND)
                return;

            // Todo:
            // プール金の方は、int amountだけ持つようにする。
            // 実際のMoneyKindはCoinStockerに入れてしまう。
            cache.Add(kind);
        }

        public int Amount()
        {
            return cache.Amount();
        }

        // お釣りを返す
        public Change Refund()
        {
            return cache.Refund();
        }

        private int CalcChange(int price)
        {
            return Amount() - price;
        }

        /// <summary>
        /// お金が足りているか
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private bool IsEnough(int price)
        {
            return (Amount() - price) >= 0;
        }

        public bool IsChange(int price)
        {
            int rem = 0;
            int dev = 0;
            // 500円が何枚必要か
            dev = Math.DivRem(price, 500, out rem);

            int count = coinStocker.Count(MoneyKind.FIVE_HUNDRED) - dev;

            // お釣りケース作成
            Change changeCase = Change.Create(new List<MoneyKind>());

            // 足りなかった場合
            if(count < 0)
            {
                int abs = Math.Abs(count);
                if(coinStocker.IsChange100(abs))
                {
                    changeCase.Add(MoneyKind.ONE_HUNDRED, 5);
                }
                if(coinStocker.IsChange50(abs))
                {
                    changeCase.Add(MoneyKind.FIFTY, 10);
                }
                if(coinStocker.IsChange10(abs))
                {
                    changeCase.Add(MoneyKind.TEN, 50);
                }
            }

            // 足りた場合
            changeCase.Add(MoneyKind.FIVE_HUNDRED, dev);


            dev = Math.DivRem(rem, 100, out rem);
            dev = Math.DivRem(rem, 50, out rem);
            dev = Math.DivRem(rem, 10, out rem);


            // Todo: このやり方だと、500円が無かった時点で、もう終了してしまう。
            // 600円のお釣りを払う時に、500円がなくても、100円6枚出すといったお釣り計算が不可能。

            int FiveHundredCount = price / (int)MoneyKind.FIVE_HUNDRED;
            int RemainderFiveHundred = price % (int)MoneyKind.FIVE_HUNDRED;

            if (!coinStocker.IsStock(MoneyKind.FIVE_HUNDRED, FiveHundredCount))
                return false;

            int OneHundredCount = RemainderFiveHundred / (int)MoneyKind.ONE_HUNDRED;
            int RemainderOneHundred = RemainderFiveHundred % (int)MoneyKind.ONE_HUNDRED;

            if (!coinStocker.IsStock(MoneyKind.ONE_HUNDRED, OneHundredCount))
                return false;

            int FiftyCount = RemainderOneHundred / (int)MoneyKind.FIFTY;
            int RemainderFifty = RemainderOneHundred / (int)MoneyKind.FIFTY;

            if (!coinStocker.IsStock(MoneyKind.FIFTY, FiftyCount))
                return false;

            int TenCount = RemainderFifty / (int)MoneyKind.TEN;
            int RemainderTenCount = RemainderFifty % (int)MoneyKind.TEN;

            if (!coinStocker.IsStock(MoneyKind.TEN, TenCount))
                return false;

            // お釣りのストックは充分
            return true;
        }
        /// <summary>
        /// 購入可能であるか
        /// </summary>
        /// <returns></returns>
        public bool IsPurchase(int price)
        {
            // プール金と価格が足りるか
            if (!IsEnough(price))
                return false;

            // お釣りを返せるか
            return true;

        }

        // キャッシュしているお金を在庫に加える
        public void StockMoney()
        {
            // キャッシュしているお金を取得　List
            var pool = cache.TakeOut();

            // 硬貨別に保存 引数:List
            foreach (var moneyKind in pool)
            {
                coinStocker.Stock(moneyKind);
            }
        }

        public void StockMoney(int price)
        {
            price 

            
        }
    }

    
}
