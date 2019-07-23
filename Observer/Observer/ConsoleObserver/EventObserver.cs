using System;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    public class EventObserver : IAbstractObserver
    {
        public EventObserver(ConsoleReader reader)
        {
            this.DataSource = reader;
            reader.Register(this);
        }

        private ConsoleReader DataSource { get; set; }

        public void Update()
        {
            string impStr = DataSource.InputString;

            Console.WriteLine("We input new quiet word");
            Console.ReadKey();
            DataSource.Flag = false;
        }
    }
}