using ConsoleUtilities;
using System;

namespace Calculate;

public class Program : ProgramBase
{
    public Program() { } // following instructions
    static void Main()
    {
        Calculator calc = new();
        Program prog = new();
        bool isRunning = true;
        prog.WriteLine("Calculator at your service! (<int> <operator> <int>) format only!\nEnter \"quit\" to exit the program.");
        while (isRunning)
        {
            prog.WriteLine("Enter expression:");
            string? input = prog.ReadLine();
            switch (input)
            {
                case null or "":
                    prog.WriteLine("No expression found.");
                    break;
                case "quit":
                    prog.WriteLine("Quiting.");
                    isRunning = false;
                    break;
                default:
                    if (calc.TryCalculate(input, out double result))
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