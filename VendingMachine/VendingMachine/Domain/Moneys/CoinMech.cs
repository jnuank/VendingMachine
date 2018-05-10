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

            // 貨幣在庫にお金を保管する
            coinStocker.Stock(kind);

            // todo:kind.value();みたいにする
            // 入れた貨幣の金額をキャッシュする
            cache.Add((int)kind);
        }

        public int Amount()
        {
            return cache.Amount();
        }

        // お釣りを返す
        public Change Refund()
        {
            int amount = cache.Refund();

            return Exchange(amount);
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

        #region お金


        #endregion
        public Change Exchange(int amount)
        {
            int rem = 0;
            int dev = 0;
            // 500円が何枚必要か
            dev = Math.DivRem(amount, 500, out rem);

            int count = coinStocker.Count(MoneyKind.FIVE_HUNDRED) - dev;

            // お釣りケース作成
            Change changeCase = Change.Create(new List<MoneyKind>());

            // 足りなかった場合
            if (count < 0)
            {
                int abs = Math.Abs(count);
                if (coinStocker.IsChange100(abs))
                {
                    changeCase.Add(MoneyKind.ONE_HUNDRED, 5);

                }
                else if (coinStocker.IsChange50(abs))
                {
                    changeCase.Add(MoneyKind.FIFTY, 10);
                }
                else if (coinStocker.IsChange10(abs))
                {
                    changeCase.Add(MoneyKind.TEN, 50);
                }
                else
                {
                    return null;
                }
            }

            // 足りた場合
            changeCase.Add(MoneyKind.FIVE_HUNDRED, dev);

            dev = Math.DivRem(rem, 100, out rem);
            count = coinStocker.Count(MoneyKind.ONE_HUNDRED) - dev;

            if (count < 0)
            {
                int abs = Math.Abs(count);
                if (coinStocker.IsChange50(abs))
                {
                    changeCase.Add(MoneyKind.FIFTY, 2);
                }
                else if (coinStocker.IsChange10(abs))
                {
                    changeCase.Add(MoneyKind.TEN, 10);
                }
                else
                {
                    return null;
                }
            }

            // 足りた場合
            changeCase.Add(MoneyKind.ONE_HUNDRED, dev);

            dev = Math.DivRem(rem, 50, out rem);
            count = coinStocker.Count(MoneyKind.FIFTY) - dev;

            if (count < 0)
            {
                int abs = Math.Abs(count);
                if (coinStocker.IsChange10(abs))
                {
                    changeCase.Add(MoneyKind.TEN, 5);
                }
                else
                {
                    return null;
                }
            }

            // 足りた場合
            changeCase.Add(MoneyKind.FIFTY, dev);


            dev = Math.DivRem(rem, 10, out rem);
            count = coinStocker.Count(MoneyKind.TEN) - dev;

            if (count < 0)
            {
                return null;
            }

            // 足りた場合
            changeCase.Add(MoneyKind.TEN, dev);

            // お釣りのストックは充分
            return changeCase;

        }



        public bool IsChange(int amount)
        {
            if (Exchange(amount) == null)
                return false;

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

        /// <summary>
        /// キャッシュしたお金から支払う
        /// </summary>
        /// <param name="price"></param>
        public void Pay(int price)
        {
            cache.Minus(price);
        }
    }

    
}
