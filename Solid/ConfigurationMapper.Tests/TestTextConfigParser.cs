using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;
using System;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestTextConfigParser
    {
        [Test]
        public void Parse_PassNullConfig_ThrowArgumentException()
        {
            var tcp = new TextConfigParser();           
            Assert.Throws<ArgumentException>(() => tcp.Parse(null));
        }

        [Test]
        public void Parse_PassEmptyStringConfig_ThrowArgumentException()
        {
            var tcp = new TextConfigParser();
            Assert.Throws<ArgumentException>(() => tcp.Parse(""));
        }
        [Test]
        public void Parse_PassConfigWithoutEqualsSign_ThrowArgumentException()
        {
            var tcp = new TextConfigParser();
            Assert.Throws<ArgumentException>(() => tcp.Parse("IncorrectConfig"));
        }

        [Test]
        public void Parse_PassConfigWithoutClassName_ThrowArgumentException()
        {
            var tcp = new TextConfigParser();
            Assert.Throws<ArgumentException>(() => tcp.Parse("Incorrect="));
        }

        [Test]
        public void Parse_PassConfigCorrectFormat_HaveCorrectParseConfigParam()
        {
            var tcp = new TextConfigParser();
            var param = tcp.Parse("namespace.class.param=value");
            Assert. AreEqual("namespace.class", param.ClassNameWithNamespace);
            Assert.AreEqual("param", param.Parameter);
            Assert.AreEqual("value", param.Value);
        }

        [Test]
        public void Parse_PassConfigCorrectFormat_HaveCorrectParseConfigParam1()
        {
            var tcp = new TextConfigParser();
            Assert.Throws<ArgumentException>(() => tcp.Parse("namespace. class.  param=value"));
        }
    }
}