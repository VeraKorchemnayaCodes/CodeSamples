using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    [DataRow(nameof(LogFactoryTests))]
    public void CreateLogger_NotConfigured_ReturnsNull(string className)
    {
        // Arrange
        LogFactory factory = new();

        // Act
        BaseLogger logger = factory.CreateLogger(className);

        // Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    [DataRow(nameof(LogFactoryTests))]
    public void CreateLogger_Configured_ReturnsNotNull(string className)
    {
        // Arrange
        LogFactory factory = new();
        factory.ConfigureFileLogger(Path.GetTempFileName());

        // Act
        BaseLogger logger = factory.CreateLogger(className);

        // Assert
        Assert.IsNotNull(logger);
    }
}
