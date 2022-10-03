using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetPresentValue.Service.CalcUtilty;

namespace NetPresentValue.Test
{
    [TestClass]
    public class NpvCalculatorTests
    {
        [TestMethod]
        public void CalculatePerYear_Year1_ProvideValueDate_ShouldReturnOneYearData()
        {
            // Arrange
            decimal cashValue = 123456;
            decimal lowBoundDiscRate = 1;
            decimal upBoundDiscRate = 5;
            decimal discRateIncrement = 2;
            int year = 1;
            NpvCalculator npvCalculator = new NpvCalculator();

            // Act
            var result = npvCalculator.CalculatePerYear(cashValue, lowBoundDiscRate, upBoundDiscRate, discRateIncrement, year);

            // Assert
            Assert.AreEqual(1, result["id"]);
            Assert.AreEqual(cashValue, result["cashvalue"]);
            Assert.AreEqual(122233.66M, result["1%"]);
            Assert.AreEqual(119860.19M, result["3%"]);
            Assert.AreEqual(117577.14M, result["5%"]);
        }

        [TestMethod]
        public void CalculatePerYear_Year2_ProvideValueDate_ShouldReturnOneYearData()
        {
            // Arrange
            decimal cashValue = 7897987;
            decimal lowBoundDiscRate = 1;
            decimal upBoundDiscRate = 10;
            decimal discRateIncrement = 2;
            int year = 2;
            NpvCalculator npvCalculator = new NpvCalculator();

            // Act
            var result = npvCalculator.CalculatePerYear(cashValue, lowBoundDiscRate, upBoundDiscRate, discRateIncrement, year);

            // Assert
            Assert.AreEqual(2, result["id"]);
            Assert.AreEqual(cashValue, result["cashvalue"]);
            Assert.AreEqual(7742365.45M, result["1%"]);
            Assert.AreEqual(7444610.24M, result["3%"]);
            Assert.AreEqual(7163707.03M, result["5%"]);
            Assert.AreEqual(6898407.72M, result["7%"]);
            Assert.AreEqual(6647577.64M, result["9%"]);
        }
    }
}
