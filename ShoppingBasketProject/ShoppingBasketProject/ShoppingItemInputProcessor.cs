using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketProject
{
    public class ShoppingItemInputProcessor
    {
        public bool ProcessAddItemParameters(string input, out string name, out double price, out int quantity)
        {
            bool success = true;

            string[] inputs = input.Split(',');

            if(inputs.Length < 3)
            {
                name = ""; price = 0.0f; quantity = 0;
                return false;
            }

            name = inputs[0];

            success &= double.TryParse(inputs[1], out price);

            success &= int.TryParse(inputs[2], out quantity);

            return success;
        }

        public bool ProcessRemoveItemParameters(string input, out string name, out int quantity)
        {
            string[] inputs = input.Split(',');

            if (inputs.Length < 2)
            {
                name = ""; quantity = 0;
                return false;
            }

            name = inputs[0];

            return int.TryParse(inputs[1], out quantity);
        }
    }
}
