namespace Observer.Interfaces
{
    public interface IObserver<in TData>
    {
        void Update(TData data);
    }
}
