using System.Collections.Generic;
using System.Linq;
using Observer.Interfaces;

namespace Observer
{
    public sealed class NewsAggregator : IObservable<News>
    {
        private readonly List<IObserver<News>> _observers;

        public NewsAggregator()
        {
            _observers = new();
        }

        public void Notify(News data)
        {
            foreach (var item in _observers)
                item.Update(data);
        }

        public void Subscribe(IObserver<News> observer) =>
            _observers.Add(observer);

        public void Unsubscribe(IObserver<News> observer) =>
            _observers.Remove(observer);
    }
}
