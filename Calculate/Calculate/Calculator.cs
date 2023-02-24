using System;
using System.Collections.Generic;

namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; } =
        new Dictionary<char, Func<int, int, double>>()
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiple,
            ['/'] = Divide
        };

    public static double Add(int parameter1, int parameter2) => (double)parameter1 + parameter2;
    public static double Subtract(int parameter1, int parameter2) => (double)parameter1 - parameter2;
    public static double Multiple(int parameter1, int parameter2) => (double)parameter1 * parameter2;
    public static double Divide(int parameter1, int parameter2) => (double)parameter1 / parameter2;

    public bool TryCalculate(string expression, out double result)
    {
        result = default;
        if (expression.Split(" ") is string[] args and { Length: 3 } &&
            int.TryParse(args[0], out int p1) && char.TryParse(args[1], out char op) && int.TryParse(args[2], out int p2))
        {
            if (MathematicalOperations.ContainsKey(op)) 
            {
                result = MathematicalOperations[op](p1, p2);
                return true;
            }
        }
        return false;
    }
}
