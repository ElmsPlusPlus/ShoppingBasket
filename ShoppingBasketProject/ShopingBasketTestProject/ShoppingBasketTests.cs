using FluentAssertions;
using ShoppingBasketProject;
using Xunit.Abstractions;

namespace ShoppingBasketTestProject
{
    public class ShoppingBasketTests
    {
        public static IEnumerable<object[]> ItemsToAddToBaskets = new List<object[]>
        {
            new object[] { "Water", 0.99f, 3 },
            new object[] { "Coke", 1.99f, 4}
        };

        [Theory]
        [MemberData(nameof(ItemsToAddToBaskets))]
        public void AddItemsToBasketTest(string name, double price, int quantity)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            shoppingBasket.AddItem(name, price, quantity);

            Item item = shoppingBasket.GetShoppingBasketItems().FirstOrDefault(x => x.Name == name);

            item.Name.Should().Be(name);
            item.Price.Should().Be(price);
            item.Quantity.Should().Be(quantity);
        }

        public static IEnumerable<object[]> ItemsToRemoveFromBaskets = new List<object[]>
        {
            new object[] { "Water", 0.99f, 3, "Water", 2, 1 },
            new object[] { "Coke", 1.99f, 4, "Coke", 5, 0}
        };

        [Theory]
        [MemberData(nameof(ItemsToRemoveFromBaskets))]
        public void RemoveItemsFromBasketTest(string name, double price, int quantity, string removeName, int removeQuanity, int finalQuantity)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            shoppingBasket.AddItem(name, price, quantity);

            bool success = shoppingBasket.RemoveItem(removeName, removeQuanity);        

            Item item = shoppingBasket.GetShoppingBasketItems().FirstOrDefault(x => x.Name == name);

            success.Should().BeTrue();
            item.Quantity.Should().Be(finalQuantity);
        }

        public static IEnumerable<object[]> TotalCostTestBaskets = new List<object[]>
        {
            new object[] { 2.97f, new List<Item> { new Item("Water", 0.99f, 3) } },
            new object[] { 7.96f, new List<Item> { new Item("Coke", 1.99f, 4) } },
            new object[] { 2.98f, new List<Item> { new Item("Water", 0.99f, 1), new Item("Coke", 1.99f, 1) } }
        };

        [Theory]
        [MemberData(nameof(TotalCostTestBaskets))]
        public void CalculateTotalCostTest(double totalPrice, List<Item> items)
        {
            PriceCalculator priceCalculator = new PriceCalculator(new NoDiscountDiscounter());

            priceCalculator.CalculateTotalPrice(items).Should().Be(totalPrice);
        }

        public static IEnumerable<object[]> BuyOneGetOneFreeTestShoppingBaskets = new List<object[]>
        {
            new object[] { 0.99f, new List<Item> { new Item("Water", 0.99f, 3) } },
            new object[] { 3.98f, new List<Item> { new Item("Coke", 1.99f, 4) } },
            new object[] { 0.00f, new List<Item> { new Item("Water", 0.99f, 1), new Item("Coke", 1.99f, 1) } }
        };

        [Theory]
        [MemberData(nameof(BuyOneGetOneFreeTestShoppingBaskets))]
        public void CalculateBuyOneGetFromDiscountTest(double discount, List<Item> items)
        {
            IDiscountCalculator discountCalculator = new BuyOneGetOneFreeCalculator();

            discountCalculator.CalculateDiscount(items).Should().Be(discount);
        }

        public static IEnumerable<object[]> TotalCostWithDiscountTestBaskets = new List<object[]>
        {
            new object[] { 1.98f, new List<Item> { new Item("Water", 0.99f, 3) } },
            new object[] { 3.98f, new List<Item> { new Item("Coke", 1.99f, 4) } },
            new object[] { 2.98f, new List<Item> { new Item("Water", 0.99f, 1), new Item("Coke", 1.99f, 1) } }
        };

        [Theory]
        [MemberData(nameof(TotalCostWithDiscountTestBaskets))]
        public void CalculateTotalCostWithDiscountTest(double totalPrice, List<Item> items)
        {
            PriceCalculator priceCalculator = new PriceCalculator(new BuyOneGetOneFreeCalculator());

            priceCalculator.CalculateTotalPrice(items).Should().Be(totalPrice);
        }
    }
}