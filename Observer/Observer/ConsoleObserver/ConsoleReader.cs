namespace Net.Mentoring.Patterns.ConsoleObserver
{
    public class ConsoleReader : AbstractSubject
    {
        private string _inputString;
        public bool Flag { get; set; }

        public string InputString
        {
            get => _inputString;
            set
            {
                _inputString = value;
                if (_inputString == "quit")
                    this.Notify();
            }
        }

        public ConsoleReader()
        {
            Flag = true;
        }
    }
}