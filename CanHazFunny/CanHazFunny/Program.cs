namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            new Jester(new JokeOutput(), new JokeService()).TellJoke();
        }
    }
}
