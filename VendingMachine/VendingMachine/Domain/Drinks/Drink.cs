using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.Domain
{
    /// <summary>
    /// 飲み物を表す抽象クラス
    /// </summary>
    public class Drink
    {
        /// <summary>
        /// ドリンクの種類
        /// </summary>
        public DrinkKind Kind { get; protected set; }

        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; protected set; }

        public Drink(DrinkKind kind)
        {
            this.Kind = kind;
        }

        /// <summary>
        /// ドリンクの種類名を取得
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Kind.GetEnumDescription();
        }
    }
}
