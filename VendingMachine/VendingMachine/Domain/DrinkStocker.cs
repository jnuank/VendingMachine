using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 飲み物在庫クラス
    /// </summary>
    public class DrinkStocker
    {
        private Queue<Drink> drinks = new Queue<Drink>();

        /// <summary>
        /// 在庫があるか
        /// </summary>
        /// <returns></returns>
        public bool IsStock()
        {
            return drinks.Any();
        }

        public DrinkKind GetKind()
        {
            // Todo:テスト
            return DrinkKind.Cider;
        }

    }
}
