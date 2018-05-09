using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Drinks
{
    public class PriceAttribute : Attribute
    {
        public int Price { get; private set; }

        public PriceAttribute(int price)
        {
            Price = price;
        }
    }
}
