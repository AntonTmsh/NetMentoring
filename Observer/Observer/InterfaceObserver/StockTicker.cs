using System.Collections.Generic;
using InterfaceObserver;

namespace Net.Mentoring.Patterns.InterfaceObserver
{
    internal class StockTicker
    {
        private readonly List<IAbstractObserver> _observers = new List<IAbstractObserver>();
        private Stock _stock;

        public Stock Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                foreach (var observer in _observers) observer.Notify(_stock);
            }
        }

        public void Register(IAbstractObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IAbstractObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}