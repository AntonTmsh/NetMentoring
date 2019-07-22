using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class EnvironmentConfigsProvider : IEnvironmentConfigsProvider
    {
        private readonly IEnvironmentMatcher _environmentMatcher;
        private readonly string _pathToConfigsFolder;
        private readonly string _extension;
        private const string RequiredFile = "Default";

        public EnvironmentConfigsProvider(string pathToConfigsFolder, ConfigFileType configFileType = ConfigFileType.txt, IEnvironmentMatcher environmentMatcher = null)
        {
            if (String.IsNullOrWhiteSpace(pathToConfigsFolder))
                throw new ArgumentException(nameof(pathToConfigsFolder));
            _pathToConfigsFolder = pathToConfigsFolder;
            _extension = configFileType.ToString();
            _environmentMatcher = environmentMatcher ?? new TextEnvironmentMatcher();
        }

        public IEnumerable<string> GetEnvironmentConfigFiles(IEnumerable<string> environmentNames)
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

            var fullnames = Directory.GetFiles(_pathToConfigsFolder, $"*.{_extension}");
            var names = GetFileNames(fullnames).ToList();
            if (!IsRequiredFileExist(names))
            {
                throw new FileNotFoundException($"File {RequiredFile} must be exist in {_pathToConfigsFolder} folder");
            }

            var matchedNames = names.Where(n => _environmentMatcher.Match(n, environmentNames)).OrderBy(x => x);
            var defaultEnum = new[] { RequiredFile };
            var namesByTagsWithDefault = defaultEnum.Concat(matchedNames);

            foreach (var nameByTag in namesByTagsWithDefault)
            {
                yield return $"{_pathToConfigsFolder}\\{nameByTag}.{_extension}";
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
    }
}