using System;

namespace CanHazFunny;

class Program
{
    static void Main()
    {
        Jester jester = new(new JokeOutput(), new JokeService());
        do
        {
            jester.TellJoke();
        } while (Console.ReadLine().Contains("more"));
    }
}
