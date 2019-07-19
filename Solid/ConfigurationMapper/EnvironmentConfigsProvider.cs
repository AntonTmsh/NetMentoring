using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class EnvironmentConfigsProvider : IEnvironmentConfigsProvider
    {
        private readonly string _pathToConfigsFolder;
        private readonly string _extension;
        private const string RequiredFile = "Default";

        public EnvironmentConfigsProvider(string pathToConfigsFolder, ConfigFileType configFileType = ConfigFileType.txt)
        {
            _pathToConfigsFolder = pathToConfigsFolder;
            _extension = configFileType.ToString();
        }

        public IEnumerable<string> GetEnvironmentConfigPaths(IEnumerable<string> environmentTags)
        {
            if (!environmentTags.Any())
            {
                throw new ArgumentException("Must be at least one tag");
            }

            if (environmentTags.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Empty tag do not allowed");
            }

            var fullnames = Directory.GetFiles(_pathToConfigsFolder, $"*.{_extension}");
            var names = GetFileNames(fullnames);
            if (!names.Contains(RequiredFile))
            {
                throw new FileNotFoundException($"File {RequiredFile} must be exist in {_pathToConfigsFolder} folder");
            }
            var pattern = CreatePattern(environmentTags);
            var namesByTags = names.Where(x => PatternMatch(pattern, x)).OrderBy(x => x);
            var defaultEnum = new[] { RequiredFile };
            var namesByTagsWithDefault = defaultEnum.Concat(namesByTags);

            foreach (var nameByTag in namesByTagsWithDefault)
            {
                yield return $"{_pathToConfigsFolder}\\{nameByTag}.{_extension}";
            }
        }


        private IEnumerable<string> GetFileNames(IEnumerable<string> fullnames)
        {
            foreach (string file in fullnames)
                yield return Path.GetFileNameWithoutExtension(file);
        }

        private string CreatePattern(IEnumerable<string> inputs)
        {
            StringBuilder pattern = new StringBuilder();
            if (inputs.Count() == 1)
                return $"^{inputs.First()}$";
            foreach (var input in inputs)
            {
                pattern.Append($"({input}|)(-|)");
            }

            pattern.Append(@"(\d*|)");
            return $"^{pattern}$";
        }

        private bool PatternMatch(string pattern, string input)
        {
            return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success;
        }
    }
}