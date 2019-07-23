using System;

namespace Epam.NetMentoring.Disposable
{
    class Program
    {
        private static void Main(string[] args)
        {
            var fileWriter = new FileWriter("log.txt");

            fileWriter.Write("First test string");

            Console.ReadKey();
        }
    }
}
