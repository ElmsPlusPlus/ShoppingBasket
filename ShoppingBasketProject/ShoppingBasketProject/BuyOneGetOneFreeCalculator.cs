using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketProject
{
    public class BuyOneGetOneFreeCalculator : IDiscountCalculator
    {
        public double CalculateDiscount(List<Item> items)
        {
            double discount = 0.0f;

            foreach (Item item in items)
            {
                int freeQuantity = item.Quantity / 2;
                discount += (item.Price * freeQuantity);       
            }

            return discount;
        }
    }
}
