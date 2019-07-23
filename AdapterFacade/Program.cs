using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.AdapterFacade
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var information = new Information<int>(new List<int>() { 1, 2, 3, 4, 5 });
            var printer = new Printer();
            printer.Print<int>(new InformationAdapter<int>(information));
            Console.ReadKey();
        }
    }
}
