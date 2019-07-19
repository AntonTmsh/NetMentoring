using System;
using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationTypes;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationProvider
    {
        private Dictionary<string, Dictionary<string, string>> InitializeSourceConfigsWrongValue()
        {
            var dic = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "Epam.NetMentoring.ConfigurationTypes.ServiceSettings", new Dictionary<string, string>
                    {
                        {"BatchSize", ""},
                        {"HostName", "Host"}
                    }
                }
            };

            return dic;
        }

        private Dictionary<string, Dictionary<string, string>> InitializeSourceConfigs()
        {
            var dic = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "Epam.NetMentoring.ConfigurationTypes.ServiceSettings", new Dictionary<string, string>
                    {
                        {"ConnectionString", "sql/dba"},
                        {"Port", "1"},
                        {"BatchSize", ""},
                        {"HostName", ""}
                    }
                },
                {
                    "Epam.NetMentoring.ConfigurationTypes.ServiceSettingsWrong",
                    new Dictionary<string, string> {{"ConnectionString", "###"}, {"Port", "2.1"}}
                }
            };

            return dic;
        }

        //[Test]
        //public void SetParameter_SetValueForEmptyIntParameter_Initialized_Class()
        //{
        //    var cp = new ConfigurationProvider(InitializeSourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.AreEqual(0, someClass.BatchSize);
        //}

        //[Test]
        //public void SetParameter_SetValueForEmptyStringParameter_Initialized_Class()
        //{
        //    var cp = new ConfigurationProvider(InitializeSourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.IsNull(someClass.HostName);
        //}

        //[Test]
        //public void SetParameter_SetValueForSpecificIntParameter_GetExeption()
        //{
        //    var cp = new ConfigurationProvider(InitializeSourceConfigs());
        //    Assert.Throws<ArgumentException>(() => cp.Get<ServiceSettingsWrong>());
        //}

        //[Test]
        //public void SetParameter_SetValueForSpecificIntParameter_Initialized_Class()
        //{
        //    var cp = new ConfigurationProvider(InitializeSourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.AreEqual(1, someClass.Port);
        //}

        //[Test]
        //public void SetParameter_SetValueForSpecificStringParameter_Initialized_Class()
        //{
        //    var cp = new ConfigurationProvider(InitializeSourceConfigs());
        //    var someClass = cp.Get<ServiceSettings>();
        //    Assert.AreEqual("sql/dba", someClass.ConnectionString);
        //}

        //[Test]
        //public void SetParameter_SkipValueForOnlyGetParameter_Initialized_Class()
        //{
        //    var cp = new ConfigurationProvider(InitializeSourceConfigsWrongValue());
        //    var someClass = cp.Get<ServiceSettingsWrong>();
        //    Assert.IsNull(someClass.HostName);
        //}
    }
}