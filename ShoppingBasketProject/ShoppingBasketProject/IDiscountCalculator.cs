using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketProject
{
    public interface IDiscountCalculator
    {
        public double CalculateDiscount(List<Item> items);
    }
}
