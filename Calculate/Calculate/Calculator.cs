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

    public bool TryCalculate(string calculation, out double result)
    {
        result = default;
        string[] calculationArray = calculation.Split(" ");

        if (calculationArray.Length != 3 || calculationArray[1].Length != 1) return false;

        if (int.TryParse(calculationArray[0], out int a) &&
            char.TryParse(calculationArray[1], out char key) &&
            int.TryParse(calculationArray[2], out int b))
        {
            if (!MathematicalOperations.ContainsKey(key)) return false;
            result = MathematicalOperations[key](a, b);
            return true;
        }

        return false;
    }
}
