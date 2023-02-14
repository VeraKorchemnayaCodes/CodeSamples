namespace GenericsHomework;

public class Node<T> where T : struct
{
    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public T Value { get; set; }
    public Node<T> Next
    {
        get => _Next!;
        private set => _Next = value ?? throw new ArgumentNullException(nameof(value));
    }

    private Node<T>? _Next;

    public void Append(T value)
    {
        if (Exists(value)) throw new ArgumentException("Value already exists.");
        Node<T> newNode = new(value) { Next = this.Next };
        Next = newNode;
    }

    public void Clear()
    {
        Next = this;
    }

    /*
     * Setting next to itself is sufficient because there is no longer a root reference to the deleted nodes.
     * It's irrelevant whether or not the deleted nodes point to eachother because they're no longer accessible by the code. 
     * The garbage collector wont be able to find any pointers to the deleted nodes, making it sufficient.
     */

    public bool Exists(T value)
    {
        Node<T> currentNode = this.Next;
        while (currentNode != this)
        {
            if (currentNode.Value.Equals(value))
                return true;
            currentNode = currentNode.Next;
        }
        return false;
    }

    public override string ToString() => Value.ToString() ?? "null";
}