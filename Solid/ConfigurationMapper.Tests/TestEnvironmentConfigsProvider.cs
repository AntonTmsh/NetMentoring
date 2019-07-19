using System.Collections.Generic;
using System.Linq;
using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestEnvironmentConfigsProvider
    {
        private string _path = "C:\\Git\\NetMentoring\\Solid\\ConfigurationMapper.Tests\\Data";
        private string[] _tags = {"prod", "ny"};

        private Dictionary<string, string> InitializeSourceConfigs()
        {
            var dic = new Dictionary<string, string>()
            {
                {"ClassName.ParaName","Value2" },
                {"ClassName.ParaName2","Value2" },
                {"Namespace1.Namespace2.ClassName.ParaName","Value5" },
                {"Namespace1.Namespace2.Namespace3.ClassName.ParaName","Value1" },
                {"Namespace1.Namespace2.Namespace3.ClassName.ParaName1","Value1" },
                {"Namespace1.Namespace2.Namespace3.ClassName2.ParaName1","Value1" },
                {"Namespace2.ClassName.ParaName","Value2" },
                {"Namespace3.Namespace1.Namespace2.ClassName.ParaName","Value4" },
            };

            return dic;
        }
        //[Test]
        //public void GetSource_ProvideConfigSource_Source()
        //{
        //    var sp = new ConfigurationSourceProvider(_path);
        //    var source = sp.GetSource(_tags);
        //    Assert.IsTrue(source.Contains( $"{_path}\\Default.txt" ));
        //}
    }
}