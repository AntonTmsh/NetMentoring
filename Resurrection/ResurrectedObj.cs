using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Resurrection
{
    class ResurrectedObj
    {
        private List<ResurrectedObj> pool;
        private int resurrectionCount = 0;
        public ResurrectedObj(List<ResurrectedObj> pool)
        {
            Console.WriteLine("Expensive MyClass::ctor");
            this.pool = pool;
        }

        public void DoWork()
        {
            Console.WriteLine("{0} Did some work", this.resurrectionCount);
        }

        ~ResurrectedObj()
        {
            resurrectionCount++;
            pool.Add(this);
            GC.ReRegisterForFinalize(this);
        }
    }
}
