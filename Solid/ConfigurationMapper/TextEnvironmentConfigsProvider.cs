using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class TextEnvironmentConfigsProvider : IEnvironmentConfigsProvider
    {
        private readonly IEnvironmentMatcher _environmentMatcher;
        private const string RequiredFile = "Default";

        public TextEnvironmentConfigsProvider(IEnvironmentMatcher environmentMatcher)
        {
            _environmentMatcher = environmentMatcher;
        }

        public IEnumerable<string> GetEnvironmentConfigFiles(IEnumerable<string> environmentNames, string pathToConfigsFolder, ConfigFileType configFileType)
        {
            if (environmentNames == null)
            {
                throw new ArgumentException(nameof(environmentNames));
            }
            if (!environmentNames.Any())
            {
                throw new ArgumentException($"Must be at least one {nameof(environmentNames)}");
            }

            if (environmentNames.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException($"Empty {nameof(environmentNames)} do not allowed");
            }

            var fullnames = Directory.EnumerateFiles(pathToConfigsFolder, $"*.{configFileType}");
            var names = GetFileNames(fullnames);
            if (!IsRequiredFileExist(names))
            {
                throw new FileNotFoundException($"File {RequiredFile} must be exist in {pathToConfigsFolder} folder");
            }

            var matchedNames = names.Where(n => _environmentMatcher.Match(n, environmentNames));
            var defaultEnum = new[] { RequiredFile };
            var namesByTagsWithDefault = defaultEnum.Concat(matchedNames);

            foreach (var nameByTag in namesByTagsWithDefault)
            {
                yield return $"{pathToConfigsFolder}\\{nameByTag}.{configFileType}";
            }
        }

        private static IEnumerable<string> GetFileNames(IEnumerable<string> fullnames)
        {
            foreach (string file in fullnames)
                yield return Path.GetFileNameWithoutExtension(file);
        }

        private static bool IsRequiredFileExist(IEnumerable<string> names)
        {
            return names.Contains(RequiredFile);
        }

        private static bool ValidateConfigsFolder(string pathToConfigsFolder)
        {
            return string.IsNullOrWhiteSpace(pathToConfigsFolder) || !Directory.Exists(pathToConfigsFolder);
        }
    }
}