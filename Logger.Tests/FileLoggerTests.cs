using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_WritesMessageToFile()
    {
        // Arrange
        string filePath = Path.GetTempFileName();
        FileLogger logger = new FileLogger(filePath);
        logger.ClassName = nameof(FileLoggerTests);

        // Act
        logger.Log(LogLevel.Warning, "Test message");

        // Assert
        string fileContent = File.ReadAllText(filePath);
        Assert.IsTrue(fileContent.Contains($"{logger.ClassName} Warning: Test message"));

        // Cleanup
        File.Delete(filePath);
    }
}
