using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Point
{
    class Program
    {
       static void Main()
        {
            var points = new List<Point>(Enumerable.Range(1, 10).Select(p => new Point()));
            foreach (var p in points)
            {
                p.IncX();
            }
            foreach (var p in points)
            {
                Console.WriteLine(p.X);
            }
            Console.ReadKey();
        }
    }
}
