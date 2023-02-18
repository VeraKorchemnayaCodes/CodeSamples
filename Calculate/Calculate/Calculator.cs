namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations {get => _MathematicalOperations;} 
    Dictionary<char, Func<int, int, int>> _MathematicalOperations =
            new Dictionary<char, Func<int, int, int>>
            {
                ['+'] = Add,
                ['-'] = Subtract,
                ['*'] = Multiple,
                ['/'] = Divide
            };

    public static int Add(int parameter1, int parameter2)
    {
        return 0;
    }
    public static int Subtract(int parameter1, int parameter2)
    {
        return 0;
    }

    public static int Multiple(int parameter1, int parameter2)
    {
        return 0;
    }

    public static int Divide(int parameter1, int parameter2)
    {
        return 0;
    }
}
