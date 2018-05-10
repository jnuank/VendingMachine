using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.Domain.Moneys
{
    /// <summary>
    /// お釣りクラス
    /// </summary>
    public class Change
    {
        List<MoneyKind> moneys = new List<MoneyKind>();

        // コンストラクタを隠す
        public Change(List<MoneyKind> moneys)
        {
            this.moneys = moneys;
        }

        public void Add(MoneyKind kind, int amount = 1)
        {
            for(int i=0; i<amount; i++)
            {
                moneys.Add(kind);
            }
        }

        public int Amount()
        {
            return moneys.Sum(money => money.GetPrice());
        }
    }
}
