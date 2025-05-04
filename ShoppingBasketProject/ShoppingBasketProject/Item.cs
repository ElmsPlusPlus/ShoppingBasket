using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketProject
{
    public class Item
    {
        public Item(string name, double price, int quanity)
        {
            Name        = name;
            Price       = price;
            Quantity    = quanity;
        }

        public string   Name        { get; set; }
        public double   Price       { get; set; }
        public int      Quantity    { get; set; }
    }
}
