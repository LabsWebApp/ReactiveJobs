using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;
using System.Threading;

namespace NativeObserver
{
    class Program
    {
        static void Main()
        {
            NewsAggregator newsAggregator = new();

            Reader peter = new() { Name = "Петя" };
            Reader masha = new() { Name = "Маша" };

            //newsAggregator.Subscribe(peter);
            //newsAggregator.Subscribe(masha);

            var peterSubscribe = newsAggregator.Subscribe(peter);
            var mashaSubscribe = newsAggregator.Subscribe(masha);


            Thread.Sleep(1000);

            News news1 = new("Title1", "Content1");
            newsAggregator.Notify(news1);
            Thread.Sleep(3000);

            News news2 = new("Title2", "Content2");
            newsAggregator.Notify(news2);
            Thread.Sleep(500);

            //newsAggregator.Unsubscribe(masha);
            mashaSubscribe.Dispose();

            News news3 = new("Title3", "Content3");
            newsAggregator.Notify(news3);

            peterSubscribe.Dispose();

            ReadKey();
        }
    }
}
