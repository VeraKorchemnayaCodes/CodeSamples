using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class EmployeeTests
{
    [TestMethod]
    public void IsEqual_DifferentId_ReturnsFalse()
    {
        // Arrange
        Employee employee1 = new(new FullName("Jordan", "Peterson"), 0);
        Employee employee2 = new(new FullName("Jordan", "Peterson"), 0);

        // Assert
        Assert.IsFalse(employee1.Equals(employee2));
    }

    [TestMethod]
    public void IsEqual_SameIdDifferentProperties_ReturnsTrue()
    {
        // Arrange
        Employee employee1 = new(new FullName("Jordan", "Peterson", "B"), 100);
        Employee employee2 = new(new FullName("Jordan", "Peterson"), 0) { Id = employee1.Id };

        // Assert
        Assert.IsTrue(employee1.Equals(employee2));
    }

    [TestMethod]
    public void IsEqual_DifferentIdSameProperties_ReturnsFalse()
    {
        // Arrange
        Employee employee1 = new(new FullName("Jordan", "Peterson"), 0);
        Employee employee2 = new(new FullName("Jordan", "Peterson"), 0);

        // Assert
        Assert.IsFalse(employee1.Equals(employee2));
    }

    [TestMethod]
    public void Create_Success()
    {
        _ = new Employee(new FullName("Johny", "Appleseed"), 200);
    }

    [TestMethod]
    public void Name_ReturnsExpected()
    {
        // Arrange
        Employee employee = new(new FullName("Johny", "Appleseed"), 2000);

        // Assert
        Assert.AreEqual<string>(employee.Name, "Johny Appleseed, $2000");
    }

    [TestMethod]
    public void Salary_SetSalay_Success()
    {
        // Arrange
        uint salary = 2000;
        Employee employee = new(new FullName("Johny", "Appleseed"), salary);

        // Act
        salary += 1000;
        employee.Salary = salary;

        // Assert 
        Assert.AreEqual<uint>(employee.Salary, salary);
    }

    [TestMethod]
    public void GetHashCode_SameId_SameHashCode()
    {
        // Arrange
        Employee employee1 = new(new FullName("Marilyn", "Monroe"), 100000);
        Employee employee2 = new(new FullName("Marilyn", "Monroe"), 10000) { Id = employee1.Id };

        // Assert
        Assert.AreEqual<int>(employee1.GetHashCode(), employee2.GetHashCode());
    }
}
