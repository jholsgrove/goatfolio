using GoatPortfolio.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void ProfitCalculation()
        {
            // Arrange
            decimal expectedProfit = 1.00m;
            Asset position = new Asset
            {
                EntryPrice = 1.00m,
                Volume = 1,
                ExitPrice = 2.00m
            };

            // Act
            var positionValue = position.Volume * position.ExitPrice - position.EntryPrice;

            // Assert
            Assert.AreEqual(expectedProfit, positionValue);
        }
    }
}