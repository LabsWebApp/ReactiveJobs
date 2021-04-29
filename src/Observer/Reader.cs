using Observer.Interfaces;
using static System.Console;

namespace Observer
{
    public sealed class Reader : IObserver<News>
    {
        public string Name { get; set; }

        public void Update(News news)
        {
            WriteLine($"Новость для {Name}");
            WriteLine(news.Title);
            WriteLine(news.Body);
            WriteLine("******************************\n");
        }
    }
}
