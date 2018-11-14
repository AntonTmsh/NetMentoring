using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
    public class CalculationServiceWithCacheDecorated : CalculationServiceDecorator
    {
        IDictionary<string, decimal> _cache = new Dictionary<string, decimal>();

        public CalculationServiceWithCacheDecorated(ICalculationService calculationService) : base(calculationService)
        {
        }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            var key = GetKey(firstParameter, secondParameter);
            if (_cache.TryGetValue(key, out var value))
            {
                return value;
            }
            value = _calculationService.Calculate(firstParameter, secondParameter);
            _cache[key] = value;
            return value;
        }

        string GetKey(decimal param1, decimal param2)
        {
            return $"{param1}-{param2}";
        }
    }
}
