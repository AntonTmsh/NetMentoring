﻿namespace Net.Mentoring.Patterns.ConsoleObserver
{
    public class ConsoleReader : AbstractSubject
    {
        private string inputString;
        public bool Flag { get; set; }

        public string InputString
        {
            get { return inputString; }
            set
            {
                inputString = value;
                this.Notify();
            }
        }

        public ConsoleReader()
        {
            Flag = true;
        }
    }
}