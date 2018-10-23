using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader conReader = new ConsoleReader();
            EventObserver eventObserver = new EventObserver(conReader);
            Console.WriteLine("Inpute quit to stop");
            do
            {
                conReader.InputString = Console.ReadLine();
            } while (conReader.Flag);
        }
    }
}
