using System;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleReader conReader = new ConsoleReader();
            EventObserver eventObserver = new EventObserver(conReader);
            Console.WriteLine("Inpute quit to stop");
            do
            {
                conReader.InputString = Console.ReadLine();
            }
            while (conReader.Flag);
        }
    }
}
