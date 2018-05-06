using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 飲み物を表すクラス
    /// </summary>
    public class Drink
    {
        /// <summary>
        /// ドリンクの種類
        /// </summary>
        private DrinkKind kind;

        /// <summary>
        /// 在庫数
        /// </summary>
        private int stockAmount;

        /// <summary>
        /// 料金
        /// </summary>
        public int Price { get; private set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="kind"></param>
        private Drink(DrinkKind kind, int stockAmount, int price)
        {
            this.kind = kind;
            this.stockAmount = stockAmount;
            this.Price = price;
        }

        private Drink(DrinkKind kind, int price)
        {
            this.kind = kind;
            this.Price = price;
        }

        /// <summary>
        /// 飲み物を補充するメソッド（Drinkインスタンスを生成する)
        /// </summary>
        /// <returns></returns>
        public static Queue<Drink> Stock(DrinkKind kind, int stockAmount)
        {
            int price = 0;
            switch (kind)
            {
                case DrinkKind.Coke:
                    price = 120;
                    break;
                case DrinkKind.Tea:
                    price = 120;
                    break;
                case DrinkKind.Cider:
                    price = 130;
                    break;
                default:
                    price = 120;
                    break;
            }


            Queue<Drink> queue = new Queue<Drink>();

            for(int i = 0; i<stockAmount; i++)
            {
                queue.Enqueue(new Drink(kind, price));
            }

            return queue;
        }

        /// <summary>
        /// ドリンクの種類名を取得
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return kind.GetEnumDescription();
        }

        /// <summary>
        /// 量を減らす
        /// </summary>
        public void Decrement()
        {
            this.stockAmount--;
        }

        public bool IsCoke()
        {
            return this.kind == DrinkKind.Coke;
        }

        public bool IsTea()
        {
            return this.kind == DrinkKind.Tea;
        }

        public bool IsCider()
        {
            return this.kind == DrinkKind.Cider;
        }

    }
}
