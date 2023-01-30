using System;

namespace CanHazFunny;

public class Jester
{
    private readonly IJokeOutput _jokeOutput;
    private readonly IJokeService _jokeService;

    public Jester(IJokeOutput output, IJokeService service)
    {
        _jokeOutput = output ?? throw new ArgumentNullException(nameof(output));
        _jokeService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = _jokeService.GetJoke();
        } while (joke.Contains("Chuck") || joke.Contains("Norris"));

        _jokeOutput.WriteJoke(joke);
    }
}

