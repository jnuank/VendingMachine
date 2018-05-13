namespace VendingMachine.Domain
{
    /// <summary>
    /// 在庫を表すクラス
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// 数量
        /// </summary>
        private int quantity;

        public int Count()
        {
            return quantity;
        }

        public Stock(int quantity)
        {
            Add(quantity);
        }

        /// <summary>
        /// 在庫追加
        /// </summary>
        /// <param name="quantity"></param>
        public void Add(int quantity)
        {
            this.quantity += quantity;
        }

        /// <summary>
        /// 在庫切れか
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return quantity == 0;
        }

        /// <summary>
        /// 在庫を1つ減らす
        /// </summary>
        public void Decrement()
        {
            quantity--;
        }
    }
}
