using System.Collections.Generic;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    public abstract class AbstractSubject
    {
        private readonly List<IAbstractObserver> _observers = new List<IAbstractObserver>();

        public void Register(IAbstractObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IAbstractObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in _observers) o.Update();
        }
    }
}