using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain;

namespace VendingMachine.Domain.Moneys
{
    /// <summary>
    /// 硬貨を管理するクラス
    /// </summary>
    public class CoinMech
    {
        private CacheMoney cache = new CacheMoney();

        private CoinStocker coinStocker = new CoinStocker();


        /// <summary>
        /// コインメックにお金を追加する
        /// </summary>
        /// <param name="kind"></param>
        public void Add(MoneyKind kind)
        {
            // 1円、2000円、5000円、10000円は受け付けない
            // これは業務ルール

            if (kind == MoneyKind.ONE)
                return;
            if (kind == MoneyKind.TWO_THOUSAND)
                return;
            if (kind == MoneyKind.FIVE_THOUSAND)
                return;
            if (kind == MoneyKind.TEN_THOUSAND)
                return;

            cache.Add(kind);
        }

        public int Amount()
        {
            return cache.Amount();
        }

        public int ReturnChange()
        {
            return cache.Return();
        }

        private int CalcChange(int price)
        {
            return Amount() - price;
        }

        private bool IsEnough(int price)
        {
            return (Amount() - price) >= 0;
        }

        private bool IsChange(int price)
        {
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
        /// 購入可能である
        /// </summary>
        /// <returns></returns>
        public bool IsPurchase(int price)
        {
            // プール金と価格が足りるか
            if (IsEnough(price))
                return false;

            // お釣りを返せるか
            
            


        }

        
    }
}
