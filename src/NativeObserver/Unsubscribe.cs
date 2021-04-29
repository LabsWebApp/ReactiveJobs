using System;
using System.Collections.Generic;

namespace NativeObserver
{
    public sealed class Unsubscribe<TData> : IDisposable
    {
        public List<IObserver<TData>> Observers { private get; init; }
        public IObserver<TData> Observer { private get; init; }
        
        public void Dispose()
        {
            if (Observers.Contains(Observer)) 
                Observers.Remove(Observer);
        }
    }
}
