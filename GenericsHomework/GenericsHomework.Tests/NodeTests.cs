using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Create_Success()
    {
        _ = new Node<byte>(byte.MaxValue);
    }

    [TestMethod]
    public void Create_WithNullValue_Success()
    {
        _ = new Node<string>(null);
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
    [ExpectedException(typeof(ArgumentException))]
    public void Append_DuplicateValue_Throws()
    {
        // Arrange
        Node<int> testNode = new(42);

        // Act
        testNode.Append(42);
    }

    [TestMethod]
    public void Append_AppendsNewNodeAfterCurrentNode_Success()
    {
        // Arrange
        Node<int> testNode = new(int.MaxValue);

        // Act
        testNode.Append(int.MinValue);

        // Assert
        Assert.AreEqual<int>(testNode.Next.Value, int.MinValue);
    }

    [TestMethod]
    public void Append_AcceptsNullValue_Success()
    {
        // Arrange
        Node<string> testNode = new("");

        // Act
        testNode.Append(null);
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
    public void Exists_NodeDoesNotExist_ReturnsFalse()
    {
        // Arrange
        Node<double> testNode = new(4.0);

        // Assert
        Assert.IsFalse(testNode.Exists(3.0));
    }

    [TestMethod]
    public void Exists_NodeExists_ReturnsTrue()
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
    public void Exists_NullValueNode_ReturnsTrue()
    {
        // Arrange
        Node<string> testNode = new("");

        // Act
        testNode.Append(null);
        
        // Assert
        Assert.IsTrue(testNode.Exists(null));
    }

    [TestMethod]
    public void ToString_ReturnsExpected()
    {
        // Arrange
        Node<long> testNode = new(long.MinValue);

        // Assert
        Assert.AreEqual<string>(testNode.ToString(), long.MinValue.ToString());
    }

    [TestMethod]
    public void ToString_NodeHasNullValue_ReturnsEmpty()
    {
        // Arrange
        Node<string> node = new(null);

        // Assert
        Assert.AreEqual<string>(node.ToString(), string.Empty);
    }
}