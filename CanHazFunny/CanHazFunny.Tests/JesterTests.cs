using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Constructor_GivenNullIJokeOutput_Throws()
        {
            IJokeService service = new Mock<IJokeService>().Object;
            new Jester(null, service);
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
            IJokeService service = new Mock<IJokeService>().Object;
            IJokeOutput output = new Mock<IJokeOutput>().Object;
            new Jester(output, service);
        }


        [TestMethod]
        public void TellJoke_Called_ReturnsJoke()
        {
            string tmp = "joke";
            Mock<IJokeService> mock = new Mock<IJokeService>();
            mock.Setup(JokeService => JokeService.GetJoke()).Returns("joke");
            Assert.AreEqual<string>(tmp, mock.Object.GetJoke());
        }

    }
}
