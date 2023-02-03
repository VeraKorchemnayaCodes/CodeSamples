using System;

namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        Jester jester = new(new JokeOutput(), new JokeService());
        do
        {
            jester.TellJoke();
        } while (Console.ReadLine().Contains("more"));
    }
}
