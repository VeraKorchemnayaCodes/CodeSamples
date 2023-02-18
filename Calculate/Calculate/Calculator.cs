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
        result = -1;
        string[] calculationArray = calculation.Split(" ");

        if (calculationArray.Length != 3) return false;

        int a;
        int b;

        if (int.TryParse(calculationArray[0], out a) 
            && int.TryParse(calculationArray[2], out b))
        {
            if (MathematicalOperations.ContainsKey(calculationArray[1].First()))
            {
                result = MathematicalOperations[calculationArray[1].First()](a, b);
            }

        }

        //Dictionary<char, Func<int, int, int>>.KeyCollection keyColl =
        //    (Dictionary<char, Func<int, int, int>>.KeyCollection)MathematicalOperations.Keys;

        //foreach (char s in keyColl)
        //{
        //    if (calculation.Contains(s))
        //    {
        //        string[] calcs = calculation.Split($" {s} ");
        //        int[] intcalcs = new int[2] ;
        //        int.TryParse(calcs[0], out intcalcs[0]);
        //        int.TryParse(calcs[1], out intcalcs[1]);

        //        result = MathematicalOperations[s](intcalcs[0], intcalcs[1]);
        //        return true;
        //    }
        //}

        //result = -1;
        return false;
    }
}
