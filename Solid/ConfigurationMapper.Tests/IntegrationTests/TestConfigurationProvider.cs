using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;
using Epam.NetMentoring;
using Epam.NetMentoring.ConfigurationTypes;

namespace ConfigurationMapper.Tests.IntegrationTests
{
    [TestFixture]
    public class TestConfigurationProvider
    {
        private string _path = "C:\\Git\\NetMentoring\\Solid\\ConfigurationMapper.Tests\\Data";
        private readonly string[] _tags = { "prod", "ny" };
        [Test]
        public void Get_SetValueInClass_InitializedClass()
        {
            var cr = new ConfigurationReader(_path);
            var cp = new ConfigurationProvider(cr.Read(_tags));
            var config = cp.Get<ServiceSettings>();
 
            Assert.AreEqual(3, config.Port);
            Assert.AreEqual("Default/dba", config.ConnectionString);
            Assert.AreEqual(2, config.BatchSize);
        }
    }
}