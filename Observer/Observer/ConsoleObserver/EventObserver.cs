using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Mentoring.Patterns.ConsoleObserver
{
    public class EventObserver : AbstractObserver
    {
        public EventObserver(ConsoleReader reader)
        {
            this.DataSource = reader;
            reader.Register(this);
        }
        private ConsoleReader DataSource { get; set; }
        public override void Update()
        {
            string impStr = DataSource.InputString;
            if (impStr == "quit")
            {
                Console.WriteLine("We inpute new quit world");
                Console.ReadKey();
                DataSource.Flag = false;
            }
        }
    }
}
