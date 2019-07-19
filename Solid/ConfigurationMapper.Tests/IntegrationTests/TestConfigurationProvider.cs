using System;
using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;
using Epam.NetMentoring;
using Epam.NetMentoring.ConfigurationTypes;
using Epam.NetMentoring.ConfigurationMapper.Storage;

namespace ConfigurationMapper.Tests.IntegrationTests
{
    [TestFixture]
    public class TestConfigurationProvider
    {
        private readonly string _path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Data";
        private readonly string[] _tags = { "prod", "ny" };
        [Test]
        public void Get_CreateInstanceOfSpecifiedClass_CreatedInstanceWithCorrectConfiguration()
        {
            var csp = new ConfigurationReader(new EnvironmentConfigsProvider(_path));
            var cp = new ConfigurationProvider(csp.Read(_tags));
            var config = cp.Get<ServiceSettings>();
 
            Assert.AreEqual(3, config.Port);
            Assert.AreEqual("Default/dba", config.ConnectionString);
            Assert.AreEqual(2, config.BatchSize);
        }
    }
}