using System.IO;
using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationSource
    {
        private string _path = "C:\\Git\\NetMentoring\\Solid\\ConfigurationMapper.Tests\\Data";
        private readonly string nodeWithNamespane = "Epam.NetMentoring.ServiceSettings.ConnectionString=sqlserver/dba";
        private string nodeWithoutNamespace = "ServiceSettings.ConnectionString=sqlserver/dba";

        //private ConfigurationReader cr = new ConfigurationReader();
        private string[] text =
            File.ReadAllLines("c:\\Git\\NetMentoring\\Solid\\ConfigurationMapper.Tests\\Data\\Default.txt");

        private static readonly string[] _sourceLists =
        {
            "Epam.NetMentoring.ServiceSettings.ConnectionString=sqlserver/dba",
            "ServiceSettings.ConnectionString=sqlserver/dba",
            "Epam.NetMentoring.ServiceSettings.Port=123",
            "Epam.NetMentoring.ServiceSettings.ConnectionString=oracle/dba"
        };

        [Test]
        public void AddNode_Add5CorrectNode_DicWith5Node()
        {
            var cs = new ConfigurationSource();
            foreach (var list in _sourceLists)
                cs.AddNode(list);
            Assert.AreEqual(2, cs.Source.Count);
        }

        [Test]
        public void AddNode_AddOneCorrectNode_DicWithOneNode()
        {
            var cs = new ConfigurationSource();
            cs.AddNode(nodeWithNamespane);
            Assert.AreEqual(1, cs.Source.Count);
        }
    }
}