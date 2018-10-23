using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
    public abstract class CalculationServiceDecorator : ICalculationService
    {
        protected readonly ICalculationService _calculationService;
        public CalculationServiceDecorator(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public abstract decimal Calculate(decimal firstParameter, decimal secondParameter);

    }
}
