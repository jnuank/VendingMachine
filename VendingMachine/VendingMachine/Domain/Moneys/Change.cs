using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Moneys
{
    /// <summary>
    /// お釣りクラス
    /// </summary>
    public class Change
    {
        List<MoneyKind> moneys = new List<MoneyKind>();


        private Change(List<MoneyKind> moneys)
        {
            this.moneys = moneys;
            // Do Nothing
        }

        public static Change Create(List<MoneyKind> moneys)
        {
            return new Change(moneys);
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
            return moneys.Sum(money => (int)money);
        }
    }
}
