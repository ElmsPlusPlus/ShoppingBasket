using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBasketProject;

namespace ShoppingBasketTestProject
{
    public class NoDiscountDiscounter : IDiscountCalculator
    {
        public double CalculateDiscount(List<Item> items)
        {
            return 0.0f;
        }
    }
}
