using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationTypes;
using NUnit.Framework;
using System;
using Epam.NetMentoring.ConfigurationMapper.Storage;

namespace ConfigurationMapper.Tests.IntegrationTests
{
    [TestFixture]
    public class TestConfigurationProvider
    {
        private readonly string _path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Data";
        private readonly string[] _EnvironmentTags = { "prod", "ny" };
        private readonly string[] _EnvironmentTags2 = { "prod", "ny" ,"2"};
        private readonly string[] _EnvironmentTags3 = { "prod", "ny", "4" };
        [Test]
        public void Get_CreateInstanceOfSpecifiedClassForEnvironment_CreatedInstanceWithCorrectConfiguration()
        {
            var csp = new ConfigurationSourceManager(new TextEnvironmentConfigsProvider(new TextEnvironmentMatcher()),new ConfigurationHierarchyManager(), 
                                                        new ConfigurationSource(), new TextFileReader(), new TextConfigParser());
            var cp = new ConfigurationProvider(csp);
            var config = cp.Get<ServiceSettings>(_EnvironmentTags, _path,ConfigFileType.txt);
            Assert.AreEqual(3, config.Port);
            Assert.AreEqual("prodny/dba", config.ConnectionString);
        }

        [Test]
        public void Get_CreateInstanceOfSpecifiedClassForEnvironment2_CreatedInstanceWithCorrectConfiguration()
        {
            var csp = new ConfigurationSourceManager(new TextEnvironmentConfigsProvider(new TextEnvironmentMatcher()), new ConfigurationHierarchyManager(),
                new ConfigurationSource(), new TextFileReader(), new TextConfigParser());
            var cp = new ConfigurationProvider(csp);
            var config = cp.Get<ServiceSettings>(_EnvironmentTags2, _path, ConfigFileType.txt);
            Assert.AreEqual(5, config.Port);
            Assert.AreEqual("prodny/dba", config.ConnectionString);
            Assert.AreEqual(2, config.BatchSize);
        }
        [Test]
        public void Get_CreateInstanceOfSpecifiedClassForEnvironment3_CreatedInstanceWithCorrectConfiguration()
        {
            var csp = new ConfigurationSourceManager(new TextEnvironmentConfigsProvider(new TextEnvironmentMatcher()), new ConfigurationHierarchyManager(),
                new ConfigurationSource(), new TextFileReader(), new TextConfigParser());
            var cp = new ConfigurationProvider(csp);
            var config = cp.Get<ServiceSettings>(_EnvironmentTags3, _path, ConfigFileType.txt);
            Assert.AreEqual(3, config.Port);
            Assert.AreEqual("prodny/dba", config.ConnectionString);
        }

    }
}