using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain;
using VendingMachine.Domain.Moneys;

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
        /// お金の管理をするフィールド
        /// </summary>
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
            // お金が足りなかったら買えない
            if (coinMech.Amount() < 120)
                return null;

            // お釣りが足りなかったら買えない

            // 在庫が無かったら何も無し
            if (rack.IsEmpty(kind))
                return null;

            // 種類を渡すだけで、飲み物が買える
            return rack.TakeOutDrink(kind);
        }

        /// <summary>
        /// お釣りを返す
        /// </summary>
        /// <returns></returns>
        public int ReturnChange()
        {
            // TODO:int型になっているので、これを直したい
            return coinMech.ReturnChange();
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
            return coinMech.Amount();
        }

    }
}
