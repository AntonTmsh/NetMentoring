using System.Collections.Generic;
using System.Linq;
using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;

namespace ConfigurationMapper.Tests
{
    [TestFixture]
    public class TestConfigurationSourceProvider
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
        [Test]
        public void GetSource_ProvideConfigSource_Source()
        {
            var sp = new ConfigurationSourceProvider(_path);
            var source = sp.GetSource(_tags);
            Assert.IsTrue(source.Contains( $"{_path}\\Default.txt" ));
        }


        #region noy used
           

        //public void FindNPartalamespace_FindCorrectPartailNamespace_CorrectNamespace()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.ClassName.ParaName";
        //    var result = tc.FindNamespace(nameSpace);
        //    Assert.AreEqual("ClassName.ParaName", result);
        //}

        //[Test]
        //public void FindNPartalamespace_FindCorrectPartailNamespace1_CorrectNamespace()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.Namespace2.ClassName.ParaName";
        //    var result = tc.FindNamespace(nameSpace);
        //    Assert.AreEqual("Namespace1.Namespace2.ClassName.ParaName", result);
        //}

        //[Test]
        //public void FindNPartalamespace_FindCorrectPartailNamespace2_CorrectNamespace()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "ClassName1.ParaName";
        //    var result = tc.FindNamespace(nameSpace);
        //    Assert.AreEqual("", result);
        //}

        //[Test]
        //public void FindNPartalamespace_FindCorrectPartailNamespace3_CorrectNamespace()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.ClassName.ParaName2";
        //    var result = tc.FindNamespace(nameSpace);
        //    Assert.AreEqual("ClassName.ParaName2", result);
        //}

        //[Test]
        //public void FindNPartalamespace_FindCorrectPartailNamespace4_CorrectNamespace()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.ClassName2.ParaName1";
        //    var result = tc.FindNamespace(nameSpace);
        //    Assert.AreEqual("", result);
        //}

        //[Test]
        //public void Find_FindCorrectValue_CorrectValue()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.Namespace2.Namespace3.ClassName.ParaName";
        //    var result = tc.Find(nameSpace);
        //    Assert.AreEqual("Value1", result);
        //}

        //[Test]
        //public void Find_FindCorrectValue_CorrectValue1()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.ClassName.ParaName";
        //    var result = tc.Find(nameSpace);
        //    Assert.AreEqual("Value2", result);
        //}

        //[Test]
        //public void Find_FindCorrectValue_CorrectValue2()
        //{
        //    var tc = new ConfigurationSourceProvider(InitializeSourceConfigs());
        //    var nameSpace = "Namespace1.Namespace2.ClassName.ParaName1";
        //    var result = tc.Find(nameSpace);
        //    Assert.AreEqual("", result);
        //}
        #endregion


    }
}