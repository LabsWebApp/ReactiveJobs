using System;
using static System.Console;

namespace NativeObserver
{
    public sealed class Reader : IObserver<News>
    {
        public string Name { get; set; }

        public void OnNext(News value)
        {
            WriteLine($"Новость для {Name}");
            WriteLine(value.Title);
            WriteLine(value.Body);
            WriteLine("******************************\n");
        }

        public void OnError(Exception error)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(error.Message);
            ResetColor();
        }

        public void OnCompleted() { }
    }
}
