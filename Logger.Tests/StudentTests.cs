using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void IsEqual_DifferentId_ReturnsFalse()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"));
        Student student2 = new(new FullName("Jordan", "Peterson"));

        // Assert
        Assert.IsFalse(student1.Equals(student2));
    }

    [TestMethod]
    public void IsEqual_SameIdDifferentProperties_ReturnsTrue()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"), Department.Dentistry);
        Student student2 = new(new FullName("Jordan", "Peterson")) { Id = student1.Id };

        // Assert
        Assert.IsTrue(student1.Equals(student2));
    }

    [TestMethod]
    public void IsEqual_DifferentIdSameProperties_ReturnsFalse()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"));
        Student student2 = new(new FullName("Jordan", "Peterson"));

        // Assert
        Assert.IsFalse(student1.Equals(student2));
    }

    [TestMethod]
    public void Create_Success()
    {
        _ = new Student(new FullName("Johny", "Appleseed"), Department.Chemistry);
    }

    [TestMethod]
    public void Name_ReturnsExpected()
    {
        // Arrange
        Student student = new(new FullName("Johny", "Appleseed"), Department.Theatre);

        // Assert
        Assert.AreEqual<string>(student.Name, "Johny Appleseed, Theatre");
    }

    [TestMethod]
    public void GetHashCode_SameId_SameHashCode()
    {
        // Arrange
        Student student1 = new(new FullName("Jordan", "Peterson"));
        Student student2 = new(new FullName("Jordan", "Peterson", "B")) { Id = student1.Id };

        // Assert
        Assert.AreEqual<int>(student1.GetHashCode(), student2.GetHashCode());
    }
}
