using System.Collections.Generic;
using System.IO;
using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationMapper.Model;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationSource
    {
        private static readonly List<ConfigParameter> ConfigParameters = new List<ConfigParameter>()
        {
            { new  ConfigParameter("Epam.NetMentoring.ServiceSettings","ConnectionString","sqlserver/dba")},
            { new  ConfigParameter("ServiceSettings","ConnectionString","sqlserver/dba")},
            { new  ConfigParameter("Epam.NetMentoring.ServiceSettings","Port","123")},
            { new  ConfigParameter("Epam.NetMentoring.ServiceSettings","HostName","")},
            { new  ConfigParameter("Epam.NetMentoring.ServiceSettings","ConnectionString","oracle/dba")},

        };

        [Test]
        public void GetValue_GetConfigStringValue_HaveCorrectStringValue()
        {
            var cs = new ConfigurationSource();
            foreach (var param in ConfigParameters)
                cs.Add(param);
            var value = cs.GetValue("ServiceSettings", "ConnectionString");
            Assert.AreEqual("sqlserver/dba", value);
        }

        [Test]
        public void GetValue_GetConfigOverriddenValue_HaveCorrectConfigOverriddenValue()
        {
            var cs = new ConfigurationSource();
            foreach (var param in ConfigParameters)
                cs.Add(param);
            var value = cs.GetValue("Epam.NetMentoring.ServiceSettings", "ConnectionString");
            Assert.AreEqual("oracle/dba", value);
        }

        [Test]
        public void GetValue_GetConfigWithEmptyValue_HaveParamEmptyStringValue()
        {
            var cs = new ConfigurationSource();
            foreach (var param in ConfigParameters)
                cs.Add(param);
            var value = cs.GetValue("Epam.NetMentoring.ServiceSettings", "HostName");
            Assert.AreEqual(string.Empty, value);
        }
    }
}