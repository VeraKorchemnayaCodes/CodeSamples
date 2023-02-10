namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    private Storage? storage;
    private readonly Student student = new(new FullName("Princess", "Peach"));
    private readonly Employee employee = new(new FullName("Fred", "Michealson"), 0);
    private readonly Book book = new ("Beyond Order", new FullName("Jordan", "Peterson"), "2222");

    [TestInitialize]
    public void Initialize()
    {
        storage = new Storage();
    }

    [TestMethod]
    public void Add_AnyEntity_Success()
    {
        // Act
        storage!.Add(student);
        storage.Add(employee);
        storage.Add(book);


        // Assert
        Assert.IsTrue(storage.Contains(student));
        Assert.IsTrue(storage.Contains(employee));
        Assert.IsTrue(storage.Contains(book));
    }

    [TestMethod]
    public void AddAndRemove_AnyEntity_Success()
    {
        // Act
        storage!.Add(student);
        storage.Add(employee);
        storage.Add(book);
        storage.Remove(student);
        storage.Remove(employee);
        storage.Remove(book);

        // Assert
        Assert.IsFalse(storage.Contains(student));
        Assert.IsFalse(storage.Contains(employee));
        Assert.IsFalse(storage.Contains(book));
    }

    [TestMethod]
    public void Get_ReturnsFirstEntity()
    {
        // Act
        storage!.Add(student);
        storage.Add(employee);
        storage.Add(book);

        // Arrange
        Assert.IsTrue((Book)storage.Get(book.Id)! == book);
    }

}
