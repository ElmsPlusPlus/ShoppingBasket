using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketProject
{
    public class PriceCalculator
    {
        IDiscountCalculator DiscountCalculator;

        public PriceCalculator(IDiscountCalculator discountCalculator)
        {
            DiscountCalculator = discountCalculator;
        }

        public double CalculateTotalPrice(List<Item> items)
        {
            double total = 0.0f;

            foreach (Item item in items)
            {
                total += (item.Quantity * item.Price);
            }

            total -= DiscountCalculator.CalculateDiscount(items);

            return total;
        }
    }
}
