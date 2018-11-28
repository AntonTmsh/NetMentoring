using System;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var conReader = new ConsoleReader();
            var eventObserver = new EventObserver(conReader);
            Console.WriteLine("Inpute quit (case-sensitive) to stop");
            do
            {
                conReader.InputString = Console.ReadLine();
            }
            while (conReader.Flag);
        }
    }
}
