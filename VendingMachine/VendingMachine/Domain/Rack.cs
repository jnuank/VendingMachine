using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 飲み物を収納する棚
    /// </summary>
    public class Rack
    {
        private Dictionary<DrinkKind, Stock> drinks = new Dictionary<DrinkKind, Stock>();

        public Rack()
        {
            // 初期処理として、すべての飲み物を5本ずつ補充する
            for(int index=0; index<(int)DrinkKind.MAX; index++)
            {
                drinks.Add((DrinkKind)index, new Stock(5));
            }
        }

        /// <summary>
        /// 飲み物をストックする
        /// </summary>
        /// <param name="kind">飲み物の種類</param>
        /// <param name="stockOfNumber">ストックする本数(デフォルト=1)</param>
        public void Stock(DrinkKind kind, int stockOfNumber = 1)
        {
            drinks[kind].Add(stockOfNumber); 
        }

        /// <summary>
        /// 在庫数を取得する
        /// </summary>
        /// <returns></returns>
        public int Count(DrinkKind kind)
        {
            return drinks[kind].Count();
        }

        /// <summary>
        /// 在庫切れかどうか
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty(DrinkKind kind)
        {
            return drinks[kind].IsEmpty();
        }

        /// <summary>
        /// 在庫から1本取り出す
        /// </summary>
        /// <returns></returns>
        public Drink TakeOutDrink(DrinkKind kind)
        {
            drinks[kind].Decrement();
            return new Drink(kind);
        }
    }
}
