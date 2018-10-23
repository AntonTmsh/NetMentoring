using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Calculator
{
    class Divide : BinaryOperation
    {
        public Divide(IOperation operator1, IOperation operator2) : base(operator1, operator2)
        {

        }
        public override double GetResult()
        {
            if (_operator2.GetResult() == 0)
                throw new ArgumentException("Division is unacceptable");
            return _operator1.GetResult() / _operator2.GetResult();
        }
    }
}
