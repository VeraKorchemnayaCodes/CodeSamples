using System;

namespace CanHazFunny;

public class JokeOutput : IJokeOutput
{
    public void WriteJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}