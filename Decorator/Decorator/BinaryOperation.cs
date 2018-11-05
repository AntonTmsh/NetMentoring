using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Calculator
{
    public abstract class BinaryOperation : IOperation
    {
        protected IOperation _leftOperand;
        protected IOperation _rightOperand;
        protected BinaryOperation (IOperation leftOperand, IOperation rightOperand)
        {
            if (leftOperand == null || rightOperand== null)
                throw new ArgumentNullException(); 
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
        }
        public abstract double GetResult();

    }
}
