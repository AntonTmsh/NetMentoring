using Epam.NetMentoring.ConfigurationMapper;
using NUnit.Framework;
using System;
using System.Linq;

namespace ConfigurationMapper.Tests.IntegrationTests
{
    [TestFixture]
    public class TestEnvironmentConfigsProvider
    {
        private readonly string _path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Data";
        private readonly string[] _tags = { "prod", "ny" ,"2"};
        [Test]
        public void GetEnvironmentConfigPaths_GetConfigPathsWithDefault_HavePathToDefaultOnFirst()
        {
            var ecp = new TextEnvironmentConfigsProvider(_path);
            var paths= ecp.GetEnvironmentConfigFiles(_tags);
            Assert.AreEqual(paths.First(), $"{_path}\\Default.txt");
        }
        [Test]
        public void GetEnvironmentConfigPaths_GetConfigPathsForEnvTags_HaveOrderedPathForEnv()
        {
            var ecp = new TextEnvironmentConfigsProvider(_path);
            var paths = ecp.GetEnvironmentConfigFiles(_tags);
            Assert.That(paths, Is.EquivalentTo(new[] { $"{_path}\\Default.txt", $"{_path}\\PROD.txt", $"{_path}\\PROD-NY.txt", $"{_path}\\PROD-NY-2.txt" }));
        }
    }
}