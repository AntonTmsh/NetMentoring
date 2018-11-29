using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Calculator
{
    public class Divide : BinaryOperation
    {
        public Divide(IOperation operator1, IOperation operator2) : base(operator1, operator2)
        {

        }
        public override double GetResult()
        {
            if (_rightOperand.GetResult() == 0)
                throw new DivideByZeroException();
            return _leftOperand.GetResult() / _rightOperand.GetResult();
        }
    }
}
