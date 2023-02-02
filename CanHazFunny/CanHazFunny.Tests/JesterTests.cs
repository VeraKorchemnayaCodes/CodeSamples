using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    protected Mock<IJokeOutput> MockJokeOutput { get; set; }
    protected Mock<IJokeService> MockJokeService { get; set; }

    [TestInitialize]
    public void CreateMocks()
    {
        MockJokeOutput = new();
        MockJokeService = new();
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Constructor_GivenNullIJokeOutput_Throws()
    {
        new Jester(null, MockJokeService.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Constructor_GivenNullIJokeService_Throws()
    {
        new Jester(MockJokeOutput.Object, null);
    }

    [TestMethod]
    public void Constructor_GivenIJokeOutputAndIJokeService_Success()
    {
        new Jester(MockJokeOutput.Object, MockJokeService.Object);
    }


    [TestMethod]
    public void TellJoke_Called_ReturnsJoke()
    {
        // Arrange
        string joke = "Beware of programmers that carry screwdrivers.";

        // Act
        MockJokeService.Setup(x => x.GetJoke()).Returns(joke);

        // Assert
        Assert.AreEqual<string>(joke, MockJokeService.Object.GetJoke());
    }


    [TestMethod]
    public void TellJoke_CallsGetJoke()
    {
        // Arrange
        Jester jester = new(MockJokeOutput.Object, MockJokeService.Object);
        MockJokeService.Setup(x => x.GetJoke()).Returns("");

        // Act
        jester.TellJoke();

        // Assert
        MockJokeService.Verify(x => x.GetJoke(), Times.Once);
    }

    [TestMethod]
    public void TellJoke_CallsWriteLine()
    {
        // Arrange
        Jester jester = new(MockJokeOutput.Object, MockJokeService.Object);
        MockJokeService.Setup(x => x.GetJoke()).Returns("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table.");

        // Act
        jester.TellJoke();

        // Assert
        MockJokeOutput.Verify(x => x.WriteJoke("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table."), Times.Once);
    }

    [TestMethod]
    public void TellJoke_GivenChuckNorrisJoke_FiltersJoke()
    {
        // Arrange
        Jester jester = new Jester(MockJokeOutput.Object, MockJokeService.Object);
        MockJokeService.SetupSequence(x => x.GetJoke())
            .Returns("Chuck Norris once shot down a German fighter plane with his finger. By yelling 'Bang!")
            .Returns("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table.");

        // Act
        jester.TellJoke();

        // Assert
        MockJokeOutput.Verify(x => x.WriteJoke("Chuck Norris once shot down a German fighter plane with his finger. By yelling 'Bang!"), Times.Never);
        MockJokeOutput.Verify(x => x.WriteJoke("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table."), Times.Once);
    }

    [TestMethod]
    public void TellJoke_GivenLowerCaseChuckNorrisJoke_FiltersJoke()
    {
        // Arrange
        Mock<IJokeOutput> mockJokeOutput = new Mock<IJokeOutput>();
        Mock<IJokeService> mockJokeService = new Mock<IJokeService>();
        Jester jester = new Jester(mockJokeOutput.Object, mockJokeService.Object);
        mockJokeService.SetupSequence(x => x.GetJoke())
            .Returns("chuck norris once shot down a German fighter plane with his finger. By yelling 'Bang!")
            .Returns("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table.");

        // Act
        jester.TellJoke();

        // Assert
        mockJokeOutput.Verify(x => x.WriteJoke("chuck norris once shot down a German fighter plane with his finger. By yelling 'Bang!"), Times.Never);
        mockJokeOutput.Verify(x => x.WriteJoke("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table."), Times.Once);
    }
}
