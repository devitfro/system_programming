using jokeDLL;

namespace testJokeDLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JokeGenerator jokeGenerator = new JokeGenerator();
            Console.WriteLine(jokeGenerator.GetRandomJoke());
        }
    }
}
