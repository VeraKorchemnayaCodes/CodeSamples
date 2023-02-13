namespace GenericsHomework;

public class Node<TNode> where TNode : struct
{
    public Node(TNode value)
    {
        Value = value;
    }

    public TNode Value { get; set; }
    public Node<TNode> Next
    {
        get => _Next!;
        private set => _Next = value ?? throw new ArgumentNullException(nameof(value));
    }

    private Node<TNode>? _Next;

    public override string? ToString() => Value.ToString();
}