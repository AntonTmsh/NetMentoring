using System;
using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using Epam.NetMentoring.ConfigurationTypes;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationProvider
    {
        private IConfigurationSource SourceConfigs()
        {
            var sc= new ConfigurationSource();
            sc.Add("Epam.NetMentoring.ConfigurationTypes.ServiceSettings.ConnectionString=sql/dba");
            sc.Add("Epam.NetMentoring.ConfigurationTypes.ServiceSettings.Port=1");
            sc.Add("Epam.NetMentoring.ConfigurationTypes.ServiceSettings.BatchSize=");
            sc.Add("Epam.NetMentoring.ConfigurationTypes.ServiceSettings.HostName=1");
            return sc;
        }

        [Test]
        public void Get_CreateInstanceWithIntParameter_CorrectIntParameter()
        {
            var cp = new ConfigurationProvider(SourceConfigs());
            var someClass = cp.Get<ServiceSettings>();
            Assert.IsInstanceOf<int>(someClass.BatchSize);
        }

        [Test]
        public void Get_CreateInstanceWithStringParameter_CorrectStringParameter()
        {
            var cp = new ConfigurationProvider(SourceConfigs());
            var someClass = cp.Get<ServiceSettings>();
            Assert.IsInstanceOf<string>(someClass.ConnectionString);
        }

        [Test]
        public void Get_CreateInstanceWithEmptyParameter_SetDefaultValueForParameter()
        {
            var cp = new ConfigurationProvider(SourceConfigs());
            var someClass = cp.Get<ServiceSettings>();
            Assert.AreEqual(0,someClass.BatchSize);
        }

        [Test]
        public void Get_CreateInstanceWithIncorrectParameterValue_ThrowArgumentException()
        {
            var cp = new ConfigurationProvider(new ConfigurationSource(new []{ "Epam.NetMentoring.ConfigurationTypes.ServiceSettings.Port=string" }));
            Assert.Throws<ArgumentException>(() => cp.Get<ServiceSettings>());
        }

        [Test]
        public void Get_CreateInstanceWithIncorrectParameterType_SkipThisParameter()
        {
            var cp = new ConfigurationProvider(SourceConfigs());
            var someClass = cp.Get<ServiceSettings>();
            Assert.AreEqual(new ServiceSettingsWrong(), someClass.ServiceSettingsWrong);
        }

        [Test]
        public void ConfigurationProvider_CreateConfigurationProviderWithNull_ThrowArgumentException1()
        {
            Assert.Throws<ArgumentException>(() => new ConfigurationProvider(null));
        }

    }
}