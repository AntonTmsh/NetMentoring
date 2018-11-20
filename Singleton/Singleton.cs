using System;

namespace Epam.NetMentoring.Singleton
{
    internal class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void ServiceContextMethod()
        {
            Console.WriteLine($"{GetType().Name}: Do somthing");
        }
    }
}
