using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;

[TestClass]
public class JokeOutputTests
{
    [TestMethod]
    public void WriteJoke_OutputsJokeToConsole()
    {
        // Arrange
        string joke = "Why did the scarecrow win an award? Because he was outstanding in his field!";
        JokeOutput jokeOutput = new();
        StringWriter consoleOutput = new();
        Console.SetOut(consoleOutput);

        // Act
        jokeOutput.WriteJoke(joke);

        // Assert
        Assert.AreEqual(joke + Environment.NewLine, consoleOutput.ToString());
    }
}
