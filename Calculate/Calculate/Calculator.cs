namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } =
        new Dictionary<char, Func<int, int, int>>()
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiple,
            ['/'] = Divide
        };

    public static int Add(int parameter1, int parameter2) => parameter1 + parameter2;
    public static int Subtract(int parameter1, int parameter2) => parameter1 - parameter2;
    public static int Multiple(int parameter1, int parameter2) => parameter1 * parameter2;
    public static int Divide(int parameter1, int parameter2) => parameter1 / parameter2;

    public bool TryCalculate(string calculation, out int result)
    {
        // Can still be refactored
        result = default;
        string[] calculationArray = calculation.Split(" ");

        if (calculationArray.Length != 3 || calculationArray[1].Length != 1) return false;

        if (int.TryParse(calculationArray[0], out int a) &&
            char.TryParse(calculationArray[1], out char key) &&
            int.TryParse(calculationArray[2], out int b))
        {
            if (!MathematicalOperations.ContainsKey(key)) return false;
            try
            {
                result = MathematicalOperations[key](a, b);
            } catch (DivideByZeroException)
            {
                return false;
            }
            return true;
        }

        return false;
    }
}
