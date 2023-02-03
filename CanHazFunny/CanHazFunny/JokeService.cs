using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;

#pragma warning disable IDE1006 // Suppressing naming rule violation because the parameter name must match the json key
public readonly record struct JokeJson(string joke);
#pragma warning restore IDE1006

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string jokeJson = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        JokeJson? joke = JsonSerializer.Deserialize<JokeJson>(jokeJson);
        return joke?.joke;
    }
}

