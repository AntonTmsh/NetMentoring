using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Singleton
{
    public class ThreadSafeSingleton
    {
        private ThreadSafeSingleton()
        {

        }

        private static Lazy<ThreadSafeSingleton> _instance = new Lazy<ThreadSafeSingleton>(()=>new ThreadSafeSingleton());
        public static ThreadSafeSingleton Instance => _instance.Value;

        public void ServiceContextMethod()
        {
            Console.WriteLine($"{GetType().Name}: Do somthing");
        }
    }
}
