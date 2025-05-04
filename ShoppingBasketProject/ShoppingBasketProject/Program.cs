using System.Linq.Expressions;
using ShoppingBasketProject;

internal class Program
{
    private static void Main(string[] args)
    {
        ShoppingBasket shoppingBasket = new ShoppingBasket();
        PriceCalculator priceCalculator = new PriceCalculator(new BuyOneGetOneFreeCalculator());
        ShoppingItemInputProcessor inputProcessor = new ShoppingItemInputProcessor();

        while(true)
        {
            Console.WriteLine("Type Add for adding an item, Type Remove for removing an item or type Total for the total cost");
            Console.WriteLine("Type exit to leave the program when you are done.");

            string input = Console.ReadLine();

            switch(input.ToLower())
            {
                case "add":
                    Console.WriteLine("Please enter the item you wish to add, price and quanity, sperated by commas");
                    string addInput = Console.ReadLine();                   
                    if(inputProcessor.ProcessAddItemParameters(addInput, out string name, out double price, out int quantity))
                    {
                        shoppingBasket.AddItem(name, price, quantity);
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse inputs, please try again");
                    }
                    break;

                case "remove":
                    Console.WriteLine("Please enter the item and quantity you wish to remove, sperated by commas");
                    string removeInput = Console.ReadLine();
                    if (inputProcessor.ProcessRemoveItemParameters(removeInput, out string remName, out int remQuantity))
                    {
                        shoppingBasket.RemoveItem(remName, remQuantity);
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse inputs, please try again");
                    }
                    break;

                case "total":
                    double total = priceCalculator.CalculateTotalPrice(shoppingBasket.GetShoppingBasketItems());
                    Console.WriteLine(string.Format("Total Price: £{0}", Math.Round(total,2).ToString()));
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Command not recognised, please enter Add, Remove or Total");
                    break;
            }
        }
    }
}