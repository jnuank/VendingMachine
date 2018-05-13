using System.Collections.Generic;
using System.Linq;
using VendingMachine.Utility;

namespace VendingMachine.Domain.Moneys
{
    /// <summary>
    /// お釣りクラス
    /// </summary>
    public class Change
    {
        List<MoneyKind> moneys = new List<MoneyKind>();

        public Change(List<MoneyKind> moneys)
        {
            this.moneys = moneys;
        }

        /// <summary>
        /// お釣りに追加する
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="amount"></param>
        public void Add(MoneyKind kind, int amount = 1)
        {
            for(int i=0; i<amount; i++)
            {
                moneys.Add(kind);
            }
        }

        /// <summary>
        /// お釣りの金額を取得する
        /// </summary>
        /// <returns></returns>
        public int Amount()
        {
            return moneys.Sum(money => money.GetPrice());
        }
    }
}
