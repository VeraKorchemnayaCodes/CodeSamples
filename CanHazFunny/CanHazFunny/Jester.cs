namespace CanHazFunny;

public class Jester : IJokeService, IJokeOutput
{
    public Jester(JokeOutput output, JokeService service)
    {
        Output = output;
        Service = service;
    }

    public JokeService Service { get; }
    public JokeOutput Output { get; }

    public void TellJoke()
    {

    }
}
