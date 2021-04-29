using System;
using System.Collections.Generic;

namespace NativeObserver
{
    public sealed class NewsAggregator : IObservable<News>
    {
        private readonly List<IObserver<News>> _observers;

        //public long СтоВКвадрате => 100 * 100;

        public NewsAggregator()
        {
            _observers = new();
        }

        //public IDisposable Subscribe(IObserver<News> observer)
        //{
        //    _observers.Add(observer);
        //    return null!;
        //}

        public IDisposable Subscribe(IObserver<News> observer)
        {
            _observers.Add(observer);
            return new Unsubscribe<News>
            {
                Observers = _observers,
                Observer = observer
            };
        }

        public void Notify(News data)
        {
            foreach (var item in _observers)
                item.OnNext(data);
        }
    }
}
