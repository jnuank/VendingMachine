using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain;

namespace VendingMachine.Domain.Moneys
{
    /// <summary>
    /// 硬貨を管理するクラス
    /// </summary>
    public class CoinMech
    {
        private CacheMoney cache = new CacheMoney();

        private CoinStocker coinStocker = new CoinStocker();


        /// <summary>
        /// コインメックにお金を追加する
        /// </summary>
        /// <param name="kind"></param>
        public void Add(MoneyKind kind)
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

            cache.Add(kind);
        }

        public int Amount()
        {
            return cache.Amount();
        }
    }
}
