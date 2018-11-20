using System;

namespace Epam.NetMentoring.Singleton
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var singelton = Singleton.Instance;
            singelton.ServiceContextMethod();
            Console.ReadKey();
            var treadSafeSingl = ThreadSafeSingleton.Instance;
            treadSafeSingl.ServiceContextMethod();
            Console.ReadKey();
        }
    }
}
