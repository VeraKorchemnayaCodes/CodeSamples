using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        return HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
    }
}
