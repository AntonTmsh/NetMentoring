using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = new Add(new Add(new Const(2), new Const(3)), new Const(5)).GetResult();
            var test = GetCacheKey(5, 2);
        }
        static string GetCacheKey(decimal p1, decimal p2)
        {
            return $"{p1}-{p2}";
        }
    }
}
