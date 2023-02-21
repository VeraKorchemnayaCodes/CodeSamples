using System.Collections.Generic;
using System.Linq;

namespace CalculateTests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void WriteLine_AcceptsDelegate_Success()
    {
        // Arrange
        TestConsole testConsole = new();
        Program prog = new(testConsole.WriteLine, TestConsole.ReadLine);
        string message = "0 / 0";

        // Act
        prog.WriteLine(message);

        // Assert
        Assert.AreEqual<string>(message, testConsole.Buffer.First());
    }

    [TestMethod]
    public void ReadLine_AcceptsDelegate_Success()
    {
        // Arrange
        TestConsole testConsole = new();
        Program prog = new(testConsole.WriteLine, TestConsole.ReadLine);

        // Act
        string message = prog.ReadLine()!;

        // Assert
        Assert.AreEqual<string>(message, "Custom ReadLine");
    }
}

public class TestConsole
{
    public List<string> Buffer { get; } = new List<string>();

    public void WriteLine(string message)
    {
        Buffer.Add(message);
    }

    public static string ReadLine()
    {
        return "Custom ReadLine";
    }
}