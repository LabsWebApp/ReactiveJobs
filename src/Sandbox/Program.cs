using System;
using System.Reactive;
using System.Reactive.Subjects;
using static System.Console;

namespace Sandbox
{
    class Program
    {
        private record Reader(string Name):IObserver<int>
        {
            public void OnCompleted()
            {
                WriteLine($"{Name}: последовательность завершена.");
            }

            public void OnError(Exception error)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"{Name}: {error.Message}");
                ResetColor();
            }

            public void OnNext(int value)
            {
                WriteLine($"{Name}: {++value}");
            }
        }

        static void Main()
        {
            ISubject<int> numbers = new Subject<int>();
            int i = 0;
            numbers.OnNext(++i);
            numbers.OnNext(++i);
            numbers.OnNext(++i);

            numbers.Subscribe(new Reader("Петя"));

            numbers.OnNext(++i);
            numbers.OnNext(++i); 
            numbers.Subscribe(new Reader("Маша"));
            numbers.OnNext(++i);
            numbers.OnCompleted();
            numbers.OnNext(++i);

            numbers.OnNext(++i);
            numbers.OnError(new Exception("Шеф, шеф! Всё пропало!"));
            numbers.OnNext(++i);

            numbers = new ReplaySubject<int>(2); //TimeSpan.FromMilliseconds(1000) 3
            i = 0;
            numbers.OnNext(++i);
            numbers.OnNext(++i);
            numbers.OnNext(++i);

            numbers.Subscribe(WriteLine);

            numbers.OnNext(++i);
            numbers.OnNext(++i);

            numbers = new BehaviorSubject<int>(99); 
            i = 0;
            numbers.Subscribe(WriteLine);
            numbers.OnNext(++i);
            numbers.OnNext(++i);
            numbers.Subscribe(WriteLine);

            numbers.OnNext(++i);
            numbers.OnNext(++i);

            numbers = new AsyncSubject<int>();
            i = 0;
            numbers.Subscribe(WriteLine);
            numbers.OnCompleted();
            //numbers.OnNext(++i);
            //numbers.OnNext(++i);

            ReadKey();
        }
    }
}
