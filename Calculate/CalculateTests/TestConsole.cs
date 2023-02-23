namespace CalculateTests;
using System.Collections.Generic;

public class TestConsole
{
    public List<string> Buffer { get; } = new List<string>();
    public string ReadLineResult { get; } = "Custom ReadLine";

    public void WriteLine(string message)
    {
        Buffer.Add(message);
    }

    public string ReadLine()
    {
        return ReadLineResult;
    }
}