using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Calculator
{
    public abstract class BinaryOperation : IOperation
    {
        protected IOperation _operator1;
        protected IOperation _operator2;
        protected BinaryOperation (IOperation operator1, IOperation operator2)
        {
            _operator1 = operator1;
            _operator2 = operator2;
        }
        public abstract double GetResult();

    }
}
