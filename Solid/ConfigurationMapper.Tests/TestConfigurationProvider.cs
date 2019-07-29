using System;
using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Model;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using Epam.NetMentoring.ConfigurationTypes;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationProvider
    {
        private static IConfigurationSource SourceConfigs()
        {
            var sc= new ConfigurationSource();
            sc.Add(new ConfigParameter("Epam.NetMentoring.ConfigurationTypes.ServiceSettings", "ConnectionString", "sql/dba"));
            sc.Add(new ConfigParameter("Epam.NetMentoring.ConfigurationTypes.ServiceSettings", "BatchSize", "1"));
            sc.Add(new ConfigParameter("Epam.NetMentoring.ConfigurationTypes.ServiceSettings", "HostName", "1"));
            return sc;
        }

        private static IConfigurationSource InCorrectSourceConfigs()
        {
            var sc = new ConfigurationSource();
            sc.Add(new ConfigParameter("Epam.NetMentoring.ConfigurationTypes.ServiceSettings", "Port", "sql/dba"));
            return sc;
        }

        [Test]
        public void Get_CreateInstanceWithIntParameter_CorrectIntParameter()
        {
            mock.Setup(x => x.Method(It.IsAny<int>(), It.IsAny<int>()))
                .Returns<int, int>((a, b) => a < b);
            var csp = new ConfigurationSourceManager(new TextEnvironmentConfigsProvider(new TextEnvironmentMatcher()), new ConfigurationHierarchyManager(),
                new ConfigurationSource(), new TextFileReader(), new TextConfigParser());
            var cp = new ConfigurationProvider(csp);
            var someClass = cp.Get<ServiceSettings>(null);
            Assert.IsInstanceOf<int>(someClass.BatchSize);
        }

        //[Test]
        //public void Get_CreateInstanceWithStringParameter_CorrectStringParameter()
        //{
        //    var cp = new ConfigurationProvider(SourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.IsInstanceOf<string>(someClass.ConnectionString);
        //}

        //[Test]
        //public void Get_CreateInstanceWithEmptyParameter_SetDefaultValueForParameter()
        //{
        //    var cp = new ConfigurationProvider(SourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.AreEqual(0,someClass.Port);
        //}

        //[Test]
        //public void Get_CreateInstanceWithIncorrectParameterValue_ThrowArgumentException()
        //{
        //    var cp = new ConfigurationProvider(InCorrectSourceConfigs());
        //    Assert.Throws<ArgumentException>(() => cp.Get<ServiceSettings>());
        //}

        //[Test]
        //public void Get_CreateInstanceWithIncorrectParameterType_SkipThisParameter()
        //{
        //    var cp = new ConfigurationProvider(SourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.AreEqual(new ServiceSettingsWrong(), someClass.ServiceSettingsWrong);
        //}

        //[Test]
        //public void ConfigurationProvider_CreateConfigurationProviderWithNull_ThrowArgumentException1()
        //{
        //    Assert.Throws<ArgumentException>(() => new ConfigurationProvider(null));
        //}

    }
}