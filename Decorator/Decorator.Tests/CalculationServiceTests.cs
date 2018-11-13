using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.NetMentoring.Calculator;
using NUnit.Framework;
using Epam.NetMentoring.CalculationService;

namespace Decorator.Tests
{
    [TestFixture]
    class CalculationServiceTests
    {
        private const decimal expectedResult = 112;
        [Test]
        public void ShouldCheckCalculation()
        {
            var sut = new CalculationServiceWithCache();
            var result = sut.Calculate(2, 3);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldCheckCalculationWithCorrection()
        {
            var calculationService = new CalculationServiceWithCache();
            var sut = new CalculationServiceWithCorrection(calculationService);
            var result = sut.Calculate(2, 3);

            Assert.That(result, Is.EqualTo(expectedResult + 10));
        }
    }
}
