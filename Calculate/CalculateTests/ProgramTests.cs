using System.Linq;

namespace CalculateTests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void WriteLine_AcceptsCustomDelegate_Success()
    {
        // Arrange
        TestConsole testConsole = new();
        Program prog = new() { WriteLine = testConsole.WriteLine };
        string message = "0 / 0";

        // Act
        prog.WriteLine(message);

        // Assert
        Assert.AreEqual<string>(message, testConsole.Buffer.First());
    }

    [TestMethod]
    public void ReadLine_AcceptsCustomDelegate_Success()
    {
        // Arrange
        TestConsole testConsole = new();
        Program prog = new() { ReadLine = testConsole.ReadLine };

        // Act
        string? message = prog.ReadLine();

        // Assert
        Assert.IsFalse(string.IsNullOrEmpty(message));
        Assert.AreEqual<string>(message, testConsole.ReadLineResult);
    }
}