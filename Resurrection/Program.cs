using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Resurrection
{
    class Program
    {
        static void Main(string[] args)
        {
            ResurrectedStaticObj liveReference = new ResurrectedStaticObj();
            liveReference = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
