using System.Collections.Generic;
using VendingMachine.Domain;
using VendingMachine.Domain.Moneys;
using VendingMachine.Utility;

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
        Change ReturnChange();

        /// <summary>
        /// 入金している金額を表示する
        /// </summary>
        /// <returns></returns>
        int DisplayCache();
    }

    /// <summary>
    /// 自動販売機のロジック
    /// </summary>
    public class VendingMachine : IVending
    {
        #region メンバフィールド

        /// <summary>
        /// お金の管理をするフィールド
        /// </summary>s
        private CoinMech coinMech = new CoinMech();

        /// <summary>
        /// 飲み物在庫
        /// </summary>
        public Rack rack = new Rack();

        #endregion


        #region 公開メソッド

        /// <summary>
        /// 入金する
        /// </summary>
        /// <param name="kind"></param>
        public void PutMoney(MoneyKind kind)
        {
            coinMech.Add(kind);
        }

        /// <summary>
        /// 飲み物を買う
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public Drink BuyDrink(DrinkKind kind)
        {
            // お金の都合で購入出来ない状態
            if (!coinMech.IsPurchase(kind.GetPrice()))
                return null;
                
            // 在庫が無かったら何も無し
            if (rack.IsEmpty(kind))
                return null;

            // ドリンクの代金分、プール金から引く
            coinMech.Pay(kind.GetPrice());

            // 種類を渡すだけで、飲み物が買える
            return rack.TakeOutDrink(kind);
        }

        /// <summary>
        /// お釣りを返す
        /// </summary>
        /// <returns></returns>
        public Change ReturnChange()
        {
            // Todo:返却後、Cacheを消し忘れている。直す
            return coinMech.Refund();
        }
        /// <summary>
        /// 自販機に入金している金額を取得する
        /// </summary>
        /// <returns></returns>
        public int DisplayCache()
        {
            return coinMech.Amount();
        }

        #endregion


    }
}
