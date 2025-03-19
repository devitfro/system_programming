namespace jokeDLL
{
    public class JokeGenerator
    {
        private readonly List<string> Jokes = new List<string>
    {
        "Программист — это машина, преобразующая кофе в код.",
        "В магазине: — У вас есть книги по депрессии? — Да, но они не продаются.",
        "Почему программисты не любят природу? — В ней слишком много багов.",
        "Алкоголь не решает проблем... но и вода тоже!",
        "Какое любимое занятие айтишника? — Перезагружаться!"
    };

        private readonly Random Random = new Random();

        public string GetRandomJoke()
        {
            int index = Random.Next(Jokes.Count);
            return Jokes[index];
        }
    }
}
