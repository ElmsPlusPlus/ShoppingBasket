using System.Diagnostics;
using FluentAssertions;
using ShoppingBasketProject;
using Xunit.Abstractions;

namespace ShoppingBasketTestProject
{
    public class InputProcessingTests
    {
        [Theory]
        [InlineData("Water,0.99,3","Water", 0.99f, 3)]
        public void AdditionInputTests(string input, string name, double price, int quantity)
        {
            ShoppingItemInputProcessor processor = new ShoppingItemInputProcessor();

            processor.ProcessAddItemParameters(input, out string procName, out double procPrice, out int procQuantity);

            procName.Should().Be(name);
            Math.Round(procPrice, 2).Should().Be(Math.Round(price,2));
            procQuantity.Should().Be(quantity);
        }

        [Theory]
        [InlineData("Water,3", "Water", 3)]
        public void RemovalInputTests(string input, string name, int quantity)
        {
            ShoppingItemInputProcessor processor = new ShoppingItemInputProcessor();

            processor.ProcessRemoveItemParameters(input, out string procName, out int procQuantity);

            procName.Should().Be(name);
            procQuantity.Should().Be(quantity);
        }
    }
}
