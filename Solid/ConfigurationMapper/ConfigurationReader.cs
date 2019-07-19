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
    public class ConfigurationReader : IConfigurationReader
    {
        private readonly IConfigurationSource _configurationSource;
        private readonly IFileReader _fileReader;
        private readonly IEnvironmentConfigsProvider _environmentConfigs;
        public ConfigurationReader(IEnvironmentConfigsProvider environmentConfigs, IConfigurationSource configurationSource = null, IFileReader fileReader = null)
        {
            _configurationSource = configurationSource ?? new ConfigurationSource();
            _fileReader = fileReader ?? new FileReader();
            _environmentConfigs = environmentConfigs;
        }

        public IConfigurationSource Read(IEnumerable<string> environmentNames)
        {
            foreach (var path in _environmentConfigs.GetEnvironmentConfigPaths(environmentNames) )
            {
                foreach (var line in _fileReader.ReadLine(path))
                {
                    _configurationSource.Add(line);
                }
            }

            return _configurationSource;
        }























        //public IEnumerable<string> GetSource(IEnumerable<string> environmentTags)
        //{
        //    if (!environmentTags.Any())
        //    {
        //        throw new ArgumentException("Must be at least one tag");
        //    }

        //    if (environmentTags.Any(string.IsNullOrWhiteSpace))
        //    {
        //        throw new ArgumentException("Empty tag do not allowed");
        //    }

        //    var fullnames = Directory.GetFiles(_pathToConfigsStore, $"*.{Extension}") ;
        //    var names = GetFileNames(fullnames);
        //    if (!names.Contains(RequiredFile))
        //    {
        //        throw new FileNotFoundException($"File {RequiredFile} must be exist in {_pathToConfigsStore} folder");
        //    }
        //    var pattern = CreatePattern(environmentTags);
        //    var namesByTags = names.Where(x => PatternMatch(pattern, x)).OrderBy(x => x);
        //    var defaultEnum = new[] { RequiredFile };
        //    var namesByTagsWithDefault = defaultEnum.Concat(namesByTags);

        //    foreach (var nameByTag in namesByTagsWithDefault)
        //    {
        //        yield return $"{_pathToConfigsStore}\\{nameByTag}.{Extension}";
        //    }
        //}

        //private IEnumerable<string> GetFileNames(IEnumerable<string> fullnames)
        //{
        //    foreach (string file in fullnames)
        //        yield return Path.GetFileNameWithoutExtension(file);
        //}

        //private string CreatePattern(IEnumerable<string> inputs)
        //{
        //    StringBuilder pattern = new StringBuilder();
        //    if (inputs.Count() == 1)
        //        return $"^{inputs.First()}$";
        //    foreach (var input in inputs)
        //    {
        //        pattern.Append($"({input}|)(-|)");
        //    }

        //    pattern.Append(@"(\d*|)");
        //    return $"^{pattern}$";
        //}

        //private bool PatternMatch(string pattern, string input)
        //{
        //    return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success;
        //}

    }
}