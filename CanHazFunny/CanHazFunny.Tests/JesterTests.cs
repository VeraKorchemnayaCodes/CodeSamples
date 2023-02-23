using Moq;

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
        _ = new Jester(MockJokeOutput.Object, MockJokeService.Object);
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
        Jester jester = new(MockJokeOutput.Object, MockJokeService.Object);
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
    public void TellJoke_FiltersChuckNorrisJokes_CaseInsensitive()
    {
        // Arrange
        Jester jester = new(MockJokeOutput.Object, MockJokeService.Object);
        MockJokeService.SetupSequence(x => x.GetJoke())
            .Returns("All browsers support the hex definitions #chuCK and #Norris for the colors black and blue.")
            .Returns("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table.");

        // Act
        jester.TellJoke();

        // Assert
        MockJokeOutput.Verify(x => x.WriteJoke("All browsers support the hex definitions #chuCK and #Norris for the colors black and blue."), Times.Never);
        MockJokeOutput.Verify(x => x.WriteJoke("3 Database SQL walked into a NoSQL bar. A little while later they walked out, because they couldn't find a table."), Times.Once);
    }
}
