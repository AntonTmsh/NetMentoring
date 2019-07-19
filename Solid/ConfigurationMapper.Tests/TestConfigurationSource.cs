using System.IO;
using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationSource
    {
        private static readonly string[] ConfigLines =
        {
            "Epam.NetMentoring.ServiceSettings.ConnectionString=sqlserver/dba",
            "ServiceSettings.ConnectionString=sqlserver/dba",
            "Epam.NetMentoring.ServiceSettings.Port=123",
            "Epam.NetMentoring.ServiceSettings.HostName=",
            "Epam.NetMentoring.ServiceSettings.ConnectionString=oracle/dba"
        };

        [Test]
        public void Add_AddSomeConfigLinesWithParamValue_HaveCorrectParamValue()
        {
            var cs = new ConfigurationSource();
            foreach (var line in ConfigLines)
                cs.Add(line);
            Assert.AreEqual("sqlserver/dba", cs.GetValue("ServiceSettings", "ConnectionString"));
        }

        [Test]
        public void Add_AddSomeConfigLinesWithParamOverrideValue_HaveCorrectParamOverriddenValue()
        {
            var cs = new ConfigurationSource();
            foreach (var line in ConfigLines)
                cs.Add(line);
            Assert.AreEqual("oracle/dba", cs.GetValue("Epam.NetMentoring.ServiceSettings", "ConnectionString"));
        }

        [Test]
        public void Add_AddSomeConfigLinesWithParamEmptyValue_HaveParamEmptyStringValue()
        {
            var cs = new ConfigurationSource();
            foreach (var line in ConfigLines)
                cs.Add(line);
            Assert.AreEqual(string.Empty, cs.GetValue("Epam.NetMentoring.ServiceSettings", "HostName"));
        }

        [Test]
        public void Add_AddSomeConfigLinesWithParamEmptyValue_HaveParamEmptyStringValue2()
        {
            var cs = new ConfigurationSource();
            foreach (var line in ConfigLines)
                cs.Add(line);
            Assert.AreEqual(string.Empty, cs.GetValue("Epam.NetMentoring.ServiceSettings", "HostName"));
        }
    }
}