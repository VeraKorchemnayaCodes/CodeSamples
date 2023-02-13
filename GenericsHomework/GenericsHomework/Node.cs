namespace GenericsHomework;

public class Node<TNode>
{
    public Node(TNode value)
    {
        Value = value;
    }

    public TNode Value
    {
        get => _Value!;
        set => _Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    public Node<TNode> Next
    {
        get => _Next!;
        private set => _Next = value ?? throw new ArgumentNullException(nameof(value));
    }

    private Node<TNode>? _Next;
    private TNode? _Value;

    public override string ToString() => Value.ToString();
}