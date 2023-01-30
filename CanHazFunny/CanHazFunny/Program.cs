using System;

namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            JokeOutput jokeOutput = new();
            JokeService jokeService = new();
            Jester jester = new(jokeOutput, jokeService);
            do
            {
                jester.TellJoke();
            } while (Console.ReadLine().Contains("more"));
        }
    }
}
