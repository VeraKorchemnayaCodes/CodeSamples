namespace Calculate;

public class Program
{
    public WriteLineDelegate WriteLine { get; init; } = Console.WriteLine;
    public ReadLineDelegate ReadLine { get; init; } = Console.ReadLine;


    public delegate void WriteLineDelegate(string message);
    public delegate string ReadLineDelegate();


    public Program() { }

    public Program(WriteLineDelegate writeLine, ReadLineDelegate readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }



    static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");
    }
}