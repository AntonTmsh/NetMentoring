using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.NetMentoring.Calculator;
using NUnit.Framework;

namespace Decorator.Tests
{
    [TestFixture]
    public class BinaryOperationTests
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            var result = new Add(new Const(2), new Const(3)).GetResult();

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ShouldSubTwoNumbers()
        {
            var result = new Sub(new Const(5), new Const(3)).GetResult();

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void ShouldDivideTwoNumbers()
        {
            var result = new Divide(new Const(10), new Const(5)).GetResult();

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void ShouldMultiplyTwoNumbers()
        {
            var result = new Multiply(new Const(10), new Const(5)).GetResult();

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void ShouldDoSimplyOperations()
        {
            var result = new Multiply(new Add(new Const(10), new Const(5)), new Divide(new Sub(new Const(20), new Const(5)), new Const(3))).GetResult();

            Assert.That(result, Is.EqualTo(75));
        }
    }
}
