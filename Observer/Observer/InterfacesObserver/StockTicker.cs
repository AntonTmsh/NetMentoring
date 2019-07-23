using System;
using System.Collections.Generic;

namespace Net.Mentoring.Patterns.NetInterfacesObserver
{
    internal class StockTicker : IObservable<Stock>
    {
        private readonly List<IObserver<Stock>> _observers = new List<IObserver<Stock>>();

        private Stock stock;

        public Stock Stock
        {
            get => stock;
            set
            {
                stock = value;
                Notify(stock);
            }
        }

        public IDisposable Subscribe(IObserver<Stock> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        private void Notify(Stock s)
        {
            foreach (var o in _observers)
                if (s.Symbol == null || s.Price < 0)
                    o.OnError(new Exception("Bad Stock Data"));
                else
                    o.OnNext(s);
        }

        private void Stop()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();

            _observers.Clear();
        }

        private class Unsubscriber : IDisposable
        {
            private readonly IObserver<Stock> _observer;
            private readonly List<IObserver<Stock>> _observers;

            public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer)) _observers.Remove(_observer);
            }
        }
    }
}