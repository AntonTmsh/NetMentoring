using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Calculator
{
    public class Const : IOperation
    {
        private readonly double _const;
        public Const(double value)
        {
            _const = value;
        }

        public double GetResult()
        {
            return _const;
        }
    }
}
