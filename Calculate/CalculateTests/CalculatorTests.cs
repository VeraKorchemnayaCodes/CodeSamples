using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;

namespace CalculateTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TryCalculate_CanParseStringWithValidOperator_Success()
        {
            Calculator calculator = new();
            calculator.TryCalculate("4 + 6", out int result);
            Assert.AreEqual<int>(10, result);
        }
        
        [TestMethod]
        [DataRow("4 - 6", -2)]
        [DataRow("10 - 3", 7)]
        [DataRow("10 + 5", 15)]
        [DataRow("4 * 5", 20)]
        [DataRow("30 / 5", 6)]
        [DataRow("2 / 0", 0)]

        public void TryCalculate_Calculations_Success(string calculation, int expected)
        {
            Calculator calculator = new();
            calculator.TryCalculate(calculation, out int result);
            Assert.AreEqual<int>(expected, result);
        }
    }
}