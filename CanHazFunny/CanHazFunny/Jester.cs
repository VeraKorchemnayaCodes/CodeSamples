using System;

namespace CanHazFunny;

public class Jester
{
    private readonly IJokeOutput _JokeOutput;
    private readonly IJokeService _JokeService;

    public Jester(IJokeOutput output, IJokeService service)
    {
        _JokeOutput = output ?? throw new ArgumentNullException(nameof(output));
        _JokeService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public void TellJoke()
    {
        string joke = _JokeService.GetJoke();
        while (joke.ToLower().Contains("chuck") || joke.ToLower().Contains("norris"))
        {
            joke = _JokeService.GetJoke();
        }

        _JokeOutput.WriteJoke(joke);
    }
}

