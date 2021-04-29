using System.Threading;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main()
        {
            NewsAggregator newsAggregator = new();
            
            Reader peter = new() {Name = "Петя"};
            Reader masha = new() {Name = "Маша"};

            newsAggregator.Subscribe(peter);
            newsAggregator.Subscribe(masha);

            

            Thread.Sleep(1000);

            News news1 = new() { Title = "Title1", Body = "Content1" };

            newsAggregator.Notify(news1);
            Thread.Sleep(3000);

            News news2 = new() { Title = "Title2", Body = "Content2" };
            newsAggregator.Notify(news2);
            Thread.Sleep(500);

            newsAggregator.Unsubscribe(masha);
            News news3 = new() { Title = "Title3", Body = "Content3" };
            newsAggregator.Notify(news3);

            //Что это напоминает?

            ReadKey();
        }
    }
}
