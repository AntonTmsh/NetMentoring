using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
    public class CalculationServiceWithCorrection : CalculationServiceDecorator
    {
        private const int _corretion = 10;
        public CalculationServiceWithCorrection(ICalculationService calculationService) : base(calculationService)
        { }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return _calculationService.Calculate(firstParameter, secondParameter) + _corretion;
        }
    }
}
