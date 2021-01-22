using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket
{
    public class DiscountInformation
    {
        public Dictionary<int, decimal> AvailableDiscounts;

        public DiscountInformation()
        {
            AvailableDiscounts = new Dictionary<int, decimal>();
            AvailableDiscounts.Add(2, 0.05m);
            AvailableDiscounts.Add(3, 0.1m);
            AvailableDiscounts.Add(4, 0.2m);
            AvailableDiscounts.Add(5, 0.25m);
        }
    }
}
