using System;
namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_DuplicateValue_Throws()
    {
        // Arrange
        Node<int> testNode = new(42);

        // Act
        testNode.Append(42);
    }

    [TestMethod]
    public void Append_AppendsNewNodeAfterCurrentNode()
    {
        // Arrange
        Node<int> testNode = new(int.MaxValue);

        // Act
        testNode.Append(int.MinValue);

        // Assert
        Assert.AreEqual<int>(testNode.Next.Value, int.MinValue);
    }

    [TestMethod]
    public void Exists_NodeDoesNotExist_ReturnsFalse()
    {
        // Arrange
        Node<double> testNode = new(4.0);

        // Assert
        Assert.IsFalse(testNode.Exists(3.0));
    }

    [TestMethod]
    public void Exist_NodeExists_ReturnsTrue()
    {
        // Arrange
        Node<double> testNode = new(4.0);

        // Act
        testNode.Append(2.0);
        testNode.Append(double.MaxValue);
        testNode.Append(double.MinValue);

        // Assert
        Assert.IsTrue(testNode.Exists(4.0));
        Assert.IsTrue(testNode.Exists(2.0));
        Assert.IsTrue(testNode.Exists(double.MaxValue));
        Assert.IsTrue(testNode.Exists(double.MinValue));
    }

    [TestMethod]
    public void ToString_ReturnsExpected()
    {
        // Arrange
        Node<long> testNode = new(long.MinValue);

        // Act
        string ret = testNode.ToString();

        // Assert
        Assert.AreEqual<string>(ret, long.MinValue.ToString());
    }

    [TestMethod]
    public void Next_NoOtherNodesInList_RefersToSelf()
    {
        // Arrange
        Node<int> testNode = new(0);

        // Assert
        Assert.IsTrue(testNode.Next == testNode);
    }

    [TestMethod]
    public void Clear_Success()
    {
        // Arrange
        Node<int> testNode = new(1);
        testNode.Append(2);
        testNode.Append(3);

        // Act
        testNode.Clear();

        // Assert
        Assert.IsTrue(testNode.Next == testNode);
    }

    [TestMethod]
    public void Create_Success()
    {
        _ = new Node<byte>(byte.MaxValue);
    }

}