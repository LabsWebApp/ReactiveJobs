namespace Observer.Interfaces
{
    public interface IObservable<TData>
    {
        void Notify(TData data);
        void Subscribe(IObserver<TData> observer);
        void Unsubscribe(IObserver<TData> observer);
    }
}
