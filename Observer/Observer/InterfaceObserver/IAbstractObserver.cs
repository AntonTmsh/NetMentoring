using Net.Mentoring.Patterns.InterfaceObserver;

namespace InterfaceObserver
{
    internal interface IAbstractObserver
    {
        void Notify(Stock st);
    }
}