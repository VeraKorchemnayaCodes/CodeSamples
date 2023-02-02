using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Constructor_GivenNullIJokeOutput_Throws()
    {
        Mock<IJokeService> service = new Mock<IJokeService>();
        new Jester(null, service.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Constructor_GivenNullIJokeService_Throws()
    {
        IJokeOutput output = new Mock<IJokeOutput>().Object;
        new Jester(output, null);
    }

    [TestMethod]
    public void Constructor_GivenIJokeOutputAndIJokeService_Success()
    {
        IJokeOutput output = new Mock<IJokeOutput>().Object;
        IJokeService service = new Mock<IJokeService>().Object;
        new Jester(output, service);
    }


    [TestMethod]
    public void TellJoke_Called_ReturnsJoke()
    {
        
        string joke = "Beware of programmers that carry screwdrivers.";
        Mock<IJokeService> mockService = new Mock<IJokeService>();
        mockService.Setup(service => service.GetJoke()).Returns(joke);

        Assert.AreEqual<string>(joke, mockService.Object.GetJoke());
    }


    [TestMethod]
    public void TellJoke_CallsGetJoke()
    {
        // Arrange
        Mock<IJokeOutput> mockJokeOutput = new();
        Mock<IJokeService> mockJokeService = new();
        Jester jester = new(mockJokeOutput.Object, mockJokeService.Object);
        mockJokeService.Setup(x => x.GetJoke()).Returns("");

        // Act
        jester.TellJoke();

        // Assert
        mockJokeService.Verify(x => x.GetJoke(), Times.Once);
    }

    [TestMethod]
    public void TellJoke_CallsWriteLine()
    {
        // Arrange
        Mock<IJokeOutput> mockJokeOutput = new Mock<IJokeOutput>();
        Mock<IJokeService> mockJokeService = new Mock<IJokeService>();
        Jester jester = new Jester(mockJokeOutput.Object, mockJokeService.Object);
        mockJokeService.Setup(x => x.GetJoke()).Returns("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table.");

        // Act
        jester.TellJoke();

        // Assert
        mockJokeOutput.Verify(x => x.WriteJoke("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table."), Times.Once);
    }

    [TestMethod]
    public void TellJoke_GivenChuckNorrisJoke_FiltersJoke()
    {
        // Arrange
        Mock<IJokeOutput> mockJokeOutput = new Mock<IJokeOutput>();
        Mock<IJokeService> mockJokeService = new Mock<IJokeService>();
        Jester jester = new Jester(mockJokeOutput.Object, mockJokeService.Object);
        mockJokeService.SetupSequence(x => x.GetJoke())
            .Returns("Chuck Norris once shot down a German fighter plane with his finger. By yelling 'Bang!")
            .Returns("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table.");

        // Act
        jester.TellJoke();

        // Assert
        mockJokeOutput.Verify(x => x.WriteJoke("Chuck Norris once shot down a German fighter plane with his finger. By yelling 'Bang!"), Times.Never);
        mockJokeOutput.Verify(x => x.WriteJoke("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table."), Times.Once);
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
