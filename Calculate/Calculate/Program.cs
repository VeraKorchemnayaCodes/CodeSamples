using System;

namespace Calculate;

public class Program
{

    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program() { }

    public Program(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    static void Main()
    {
        Calculator calc = new();
        Program prog = new();
        bool running = true;
        prog.WriteLine("Calculator at your service! [<int> <operator> <int>] format only!\nEnter \"quit\" to exit the program.");
        while (running)
        {
            prog.WriteLine("Enter expression:");
            string? input = prog.ReadLine();
            switch (input)
            {
                case null:
                    prog.WriteLine("No expression found.");
                    break;
                case "quit":
                    prog.WriteLine("Quiting.");
                    running = false;
                    break;
                default:
                    if (calc.TryCalculate(input, out int result))
                    {
                        prog.WriteLine($"= {result}");
                    }
                    else
                    {
                        prog.WriteLine("Invalid expression.");
                    }
                    break;
            }
        }
    }
}