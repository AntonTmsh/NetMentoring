using System;

namespace Epam.NetMentoring.Singleton
{
    internal class ThreadSafeSingleton
    {
        private ThreadSafeSingleton()
        {

        }

        private static Lazy<ThreadSafeSingleton> _instance = new Lazy<ThreadSafeSingleton>(() => new ThreadSafeSingleton());
        public static ThreadSafeSingleton Instance => _instance.Value;

        public void ServiceContextMethod()
        {
            Console.WriteLine($"{GetType().Name}: Do somthing");
        }
    }
}
