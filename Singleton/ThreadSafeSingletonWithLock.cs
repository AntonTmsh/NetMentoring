using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Singleton
{
    class ThreadSafeSingletonWithLock
    {
        private static volatile ThreadSafeSingletonWithLock instance;
        private static object lockObject = new Object();

        private ThreadSafeSingletonWithLock() { }

        public static ThreadSafeSingletonWithLock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                            instance = new ThreadSafeSingletonWithLock();
                    }
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
