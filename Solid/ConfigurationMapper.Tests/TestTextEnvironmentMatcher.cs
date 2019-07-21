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
        private static readonly string[] ConfigFileNames =
        {
            "PROD-NY-3",
            "PROD-NY-1",
            "PROD",
            "UAT"
        };


        [Test]
        public void Match_MatchFileNamesToOneEnvironmentNames_GetCorrectName()
        {
            var matcher = new TextEnvironmentMatcher();
            var source = matcher.Match(ConfigFileNames, _uat);
            Assert.IsTrue(source.Contains("UAT"));
        }

        [Test]
        public void Match_MatchFileNamesTo2EnvironmentNames_GetCorrectNames()
        {
            var matcher = new TextEnvironmentMatcher();
            var source = matcher.Match(ConfigFileNames, _prod_ny);
            CollectionAssert.AreEquivalent(new[] { "PROD", "PROD-NY-1", "PROD-NY-3" }, source);
        }

        [Test]
        public void Match_NullFirstParameter_ThrowArgumentException()
        {
            var matcher = new TextEnvironmentMatcher();
            Assert.Throws<ArgumentException>(() => matcher.Match(null, _prod_ny));
        }
    }
}