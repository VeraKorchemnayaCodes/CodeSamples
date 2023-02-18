using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CalculateTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TryCalculate_CanParseStringWithValidOperator_Success()
        {
            Calculator calculator = new Calculator();
            Assert.IsTrue(calculator.TryCalculate("4 + 6"));

        }
    }
}