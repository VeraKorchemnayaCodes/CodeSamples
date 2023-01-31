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
        string joke = "The pen is mighter than the sword, but only if the pen is held by Chuck Norris.";
        JokeOutput jokeOutput = new();
        StringWriter consoleOutput = new();
        Console.SetOut(consoleOutput);

        // Act
        jokeOutput.WriteJoke(joke);

        // Assert
        Assert.AreEqual(joke + Environment.NewLine, consoleOutput.ToString());
    }
}
