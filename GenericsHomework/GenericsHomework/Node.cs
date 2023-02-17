using System;
namespace GenericsHomework;

public class Node<TValue>
{
    public TValue? Value { get; set; }
    private Node<TValue>? _Next;
    public Node<TValue> Next { get => _Next!; private set => _Next = value ?? throw new ArgumentNullException(nameof(value)); }

    public Node(TValue? value)
    {
        Value = value;
        Next = this;
    }

    public void Append(TValue? value)
    {
        if (Exists(value)) throw new ArgumentException("Value already exists.");
        Node<TValue> newNode = new(value) { Next = this.Next };
        Next = newNode;
    }

    public void Clear()
    {
        Next = this;
        /*
        * Setting next to itself is sufficient because there is no longer a root reference to the deleted nodes.
        * It's irrelevant whether or not the deleted nodes point to each other because they're no longer accessible. 
        * The garbage collector wont be able to find any pointers to the deleted nodes, making it sufficient.
        */
    }

    public bool Exists(TValue? value)
    {
        if (Equals(Value, value)) return true;
        Node<TValue> iterator = Next;
        while (iterator != this)
        {
            if (Equals(iterator.Value, value)) return true;
            iterator = iterator.Next;
        }
        return false;
    }

    public override string ToString()
    {
        if (Value is null) return string.Empty;
        else return Value.ToString() ?? string.Empty;
    }
}