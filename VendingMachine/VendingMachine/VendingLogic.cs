using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain;

namespace VendingMachine
{
    /// <summary>
    /// 自動販売機のインターフェース
    /// </summary>
    interface IVending
    {
        /// <summary>
        /// お金を入金する
        /// </summary>
        /// <param name="amount"></param>
        void PutMoney(MoneyKind kind);

        /// <summary>
        /// 飲み物を買う
        /// </summary>
        /// <param name=""></param>
        Drink BuyDrink(DrinkKind kind);

        /// <summary>
        /// お釣りを返す
        /// </summary>
        /// <returns></returns>
        int ReturnChange();

    }

    /// <summary>
    /// 自動販売機のロジック
    /// </summary>
    public class VendingLogic : IVending
    {
        #region メンバフィールド

        /// <summary>
        /// 入金している金額
        /// </summary>
        private CacheMoney cacheMoney = new CacheMoney();

        /// <summary>
        /// ストックしている硬貨
        /// </summary>
        private CoinStocker coinStocker = new CoinStocker();

        /// <summary>
        /// 飲み物在庫
        /// </summary>
        public DrinkStocker stocker = new DrinkStocker();

        #endregion


        #region 公開メソッド

        public void PutMoney(MoneyKind kind)
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

            // お金をプールする。
            cacheMoney.Add(kind);
        }

        /// <summary>
        /// 飲み物を買う
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public Drink BuyDrink(DrinkKind kind)
        {
            // お金が足りなかったら買えない
            if (cacheMoney.Amount() < 120)
                return null;

            // お釣りが足りなかったら買えない

            // 在庫が無かったら何も無し
            if (stocker.IsEmpty(kind))
                return null;

            // 種類を渡すだけで、飲み物が買える
            return stocker.TakeOutDrink(kind);
        }

        /// <summary>
        /// お釣りを返す
        /// </summary>
        /// <returns></returns>
        public int ReturnChange()
        {
            return 1;
        }


        #endregion

        private int Amount(List<Money> money)
        {
            int amount = 0;

            foreach (var item in money)
            {
                amount += item.GetAmount();
            }
            return amount;
        }

        /// <summary>
        /// 自販機に入金している金額を取得する
        /// </summary>
        /// <returns></returns>
        public int GetPoolMoneyAmount()
        {
            return cacheMoney.Amount();
        }

    }
}
