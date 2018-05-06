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
        void BuyDrink(DrinkKind kind);

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
        private List<Money> poolMoney = new List<Money>();

        /// <summary>
        /// ストックしている金額
        /// </summary>
        private List<Money> stockMoney = new List<Money>();

        //private Drink coke = new Drink(DrinkKind.Coke, 10);

        //private Drink tea = new Drink(DrinkKind.Tea, 10);

        //private Drink cider = new Drink(DrinkKind.Cider, 10);

        private Queue<Drink> cokeStocker = Drink.Stock(DrinkKind.Coke, 10);

        private Queue<Drink> teaStocker = Drink.Stock(DrinkKind.Tea, 10);

        private Queue<Drink> ciderStocker = Drink.Stock(DrinkKind.Cider, 10);

        private Drink coke = null;

        private Drink tea = null;

        private Drink cider = null;

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
            poolMoney.Add(Money.Add(kind));

        }

        public void BuyDrink(DrinkKind kind)
        {
            // このままだと、種類が増えるたびにスイッチ文が増える
            switch (kind)
            {
                case DrinkKind.Coke:
                    if (coke.Price <= Amount(poolMoney))
                        cokeStocker.Dequeue();
                    break;
                case DrinkKind.Tea:
                    if (tea.Price <= Amount(poolMoney))
                        tea.Decrement();
                    break;
                case DrinkKind.Cider:
                    if (cider.Price <= Amount(poolMoney))
                        cider.Decrement();
                    break;
                default:
                    break;
            }
        }

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

        private Drink Takeout(Queue<Drink> stocker)
        {
            return stocker.Dequeue();
        }

        /// <summary>
        /// 自販機に入金している金額を取得する
        /// </summary>
        /// <returns></returns>
        public int GetPoolMoneyAmount()
        {
            return Amount(this.poolMoney);
        }

    }
}
