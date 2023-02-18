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

    public bool TryCalculate(string calculation)
    {
        Dictionary<char, Func<int, int, int>>.KeyCollection keyColl =
            (Dictionary<char, Func<int, int, int>>.KeyCollection)MathematicalOperations.Keys;

        foreach (char s in keyColl)
        {
            if (calculation.Contains(s))
            {
                string[] calcs = calculation.Split($" {s} ");

                if (calcs.Length is 2)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        

        //int[] calc = new int[2] { TryParse(calculation.Split(" ")) };
        //if (calculation.Split(" ") is [int operand1, int operand2])
        //{
        //}
        return false;
    }
}
