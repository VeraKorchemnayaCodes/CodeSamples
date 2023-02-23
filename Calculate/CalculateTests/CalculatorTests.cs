namespace CalculateTests
{
    [TestClass]
    public class CalculatorTests
    {   
        [TestMethod]
        [DataRow("4 - 6", -2)]
        [DataRow("10 - 3", 7)]
        [DataRow("10 + 5", 15)]
        [DataRow("4 * 5", 20)]
        [DataRow("30 / 5", 6)]
        [DataRow("2 / 3", 2.0 / 3)]
        public void TryCalculate_ValidExpressions_Success(string calculation, double expected)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool isSuccessful = calculator.TryCalculate(calculation, out double result);
            
            // Assert
            Assert.AreEqual<double>(expected, result);
            Assert.AreEqual<bool>(true, isSuccessful);
        }

        [TestMethod]
        [DataRow("4 -- 6", 0)]
        [DataRow("10- 3", 0)]
        [DataRow("10 +5", 0)]
        [DataRow("10 + --5", 0)]
        [DataRow("  4 * 5", 0)]
        [DataRow("3 0 / 5", 0)]
        [DataRow("a / b", 0)]
        [DataRow("2 / /1", 0)]
        public void TryCalculate_InvalidExpressions_Fail(string calculation, double expected)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool isSuccessful = calculator.TryCalculate(calculation, out double result);

            // Assert
            Assert.AreEqual<double>(expected, result);
            Assert.AreEqual<bool>(false, isSuccessful);
        }
    }
}