using System;
using System.Linq;
using Epam.NetMentoring.ConfigurationMapper;
using Epam.NetMentoring.ConfigurationTypes;
using NUnit.Framework;

namespace ConfigurationMapper.Tests.IntegrationTests
{
    [TestFixture]
    public class TestEnvironmentConfigsProvider
    {
        private readonly string _path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Data";
        private readonly string[] _tags = { "prod", "ny" };
        [Test]
        public void GetEnvironmentConfigPaths_GetConfigPathsWithDefault_HavePathToDefaultOnFirst()
        {
            var ecp = new EnvironmentConfigsProvider(_path);
            var paths= ecp.GetEnvironmentConfigFiles(_tags);
            Assert.AreEqual(paths.First(), $"{_path}\\Default.txt");
        }
        [Test]
        public void GetEnvironmentConfigPaths_GetConfigPathsForEnvTags_HaveOrderedPathForEnv()
        {
            var ecp = new EnvironmentConfigsProvider(_path);
            var paths = ecp.GetEnvironmentConfigFiles(_tags);
            Assert.AreEqual(paths,new [] { $"{_path}\\Default.txt", $"{_path}\\PROD.txt", $"{_path}\\PROD-NY-1.txt", $"{_path}\\PROD-NY-2.txt", $"{_path}\\PROD-NY-3.txt" });
        }
    }
}