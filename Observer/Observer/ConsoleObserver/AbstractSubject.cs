using System.Collections.Generic;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    public abstract class AbstractSubject
    {
        private List<AbstractObserver> observers = new List<AbstractObserver>();

        public void Register(AbstractObserver observer)
        {
            observers.Add(observer);
        }

        public void Unregister(AbstractObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in observers)
            {
                o.Update();
            }
        }
    }
}
