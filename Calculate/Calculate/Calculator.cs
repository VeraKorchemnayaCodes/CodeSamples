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

    public static int Add(int parameter1, int parameter2) => parameter1 + parameter2;
    public static int Subtract(int parameter1, int parameter2) => parameter1 - parameter2;

    public static int Multiple(int parameter1, int parameter2) => parameter1 * parameter2;

    public static int Divide(int parameter1, int parameter2)
    {
            if (parameter2 is 0) throw new DivideByZeroException();
            return parameter1 / parameter2;
    }

    public bool TryCalculate(string calculation, out int result)
    {
        // Can still be refactored
        result = -1;
        string[] calculationArray = calculation.Split(" ");

        if (calculationArray.Length != 3) return false;

        char key = calculationArray[1].First();

        if (int.TryParse(calculationArray[0], out int a) 
            && int.TryParse(calculationArray[2], out int b))
        {
            if (MathematicalOperations.ContainsKey(key))
            {
                result = MathematicalOperations[key](a, b);
            }

        }

        return false;
    }
}
