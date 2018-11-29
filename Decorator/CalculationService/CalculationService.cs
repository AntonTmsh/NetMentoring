using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
    public class CalculationService : ICalculationService
    {
        public virtual decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            Thread.Sleep(1000);
            return firstParameter * firstParameter + 2 * firstParameter
                   * secondParameter * secondParameter * secondParameter;
        }
    }
}
