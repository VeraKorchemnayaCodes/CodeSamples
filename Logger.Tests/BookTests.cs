using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class BookTests
{
    private readonly FullName author = new("Jordan", "Peterson");

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_GivenNullTitle_ThrowsExpected()
    {
        _ = new Book(null!, author, "ISBN 978-321");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Book_GivenNullISBN_ThrowsExpected()
    {
        _ = new Book("Beyond Order", author, null!);
    }

    [TestMethod]
    public void IsEqual_DifferentInstancesIdenticalISBN_ReturnsTrue()
    {
        // Arrange
        Book book1 = new("Beyond", author, "ISBN 978-321");
        Book book2 = new("Beyond Order", author, "ISBN 978-321");

        // Assert
        Assert.IsTrue(book1.Equals(book2));
    }

    [TestMethod]
    public void IsEqual_DifferentISBN_ReturnsFalse()
    {
        // Arrange
        Book book1 = new("Beyond Order", author, "ISBN 978-32");
        Book book2 = new("Beyond Order", author, "ISBN 978-321");

        // Assert
        Assert.IsFalse(book1.Equals(book2));
    }

    [TestMethod]
    public void Name_ReturnsExpectedBookName()
    {
        // Arrange
        string title = "Beyond Order";
        string isbn = "ISBN 978-321";

        Book book = new(title, author, isbn);

        // Act
        string expected = $"{title} by {author} ({isbn})";

        // Assert
        Assert.AreEqual<string>(expected, book.Name);
    }
}
