using System;
using System.Collections.Generic;
using System.Linq;
using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestTextEnvironmentMatcher
    {
        private readonly string[] _uat = {"uat"};
        private readonly string[] _prod_ny = { "Prod","ny" };

        [Test]
        public void Match_MatchFileNamesToOneEnvironmentNames_GetCorrectName()
        {
            var matcher = new TextEnvironmentMatcher();
            var source = matcher.Match("UAT", _uat);
            Assert.IsTrue(source);
        }

        [Test]
        public void Match_MatchFileNamesTo2EnvironmentNames_GetCorrectNames()
        {
            var matcher = new TextEnvironmentMatcher();
            var source = matcher.Match("PROD-NY", _prod_ny);
            Assert.IsTrue(source);
        }

        [Test]
        public void Match_NullFirstParameter_ThrowArgumentException()
        {
            var matcher = new TextEnvironmentMatcher();
            Assert.Throws<ArgumentException>(() => matcher.Match(null, _prod_ny));
        }
    }
}