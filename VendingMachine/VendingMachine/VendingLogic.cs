using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void PutMoney(int amount);
        
        /// <summary>
        /// 飲み物を買う
        /// </summary>
        /// <param name=""></param>
        void BuyDrink(int )

    }


    /// <summary>
    /// 自動販売機のロジック
    /// </summary>
    public class VendingLogic
    {


    }
}
