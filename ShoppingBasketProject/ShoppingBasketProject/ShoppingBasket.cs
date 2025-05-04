using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketProject
{
    public class ShoppingBasket
    {
        Dictionary<string, Item> BasketItems;
        public ShoppingBasket() 
        {
            BasketItems = new Dictionary<string, Item>();
        }

        public void AddItem(string itemName, double price, int quantity)
        {
            if(BasketItems.ContainsKey(itemName))
            {
                BasketItems[itemName].Quantity += quantity;
            }
            else
            {
                BasketItems.Add(itemName, new Item(itemName, price, quantity));
            }
        }

        public bool RemoveItem(string itemName, int quanity)
        {
            if(BasketItems.ContainsKey(itemName))
            {
                BasketItems[itemName].Quantity -= quanity;

                BasketItems[itemName].Quantity = Math.Max(0, BasketItems[itemName].Quantity);

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Item> GetShoppingBasketItems()
        {
            return BasketItems.Values.ToList();
        }
    }
}
