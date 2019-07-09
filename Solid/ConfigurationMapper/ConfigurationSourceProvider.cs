using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationSourceProvider : ISourceProvider
    {
        private readonly string _path;
        private const string Extension = "txt";
        private const string RequiredFile = "Default";
        public ConfigurationSourceProvider(string path)
        {
            _path = path;
        }

        public IEnumerable<string> GetSource(IEnumerable<string> tags)
        {
            if (!tags.Any())
            {
                throw new ArgumentException("Must be at least one tag");
            }

            if (tags.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Empty tag do not allowed");
            }

            var fullnames = Directory.GetFiles(_path, $"*.{Extension}") ;
            var names = GetFileNames(fullnames);
            if (!names.Contains(RequiredFile))
            {
                throw new FileNotFoundException($"File {RequiredFile} must be exist in {_path} folder");
            }
            var pattern = CreatePattern(tags);
            var namesByTags = names.Where(x => PatternMatch(pattern, x)).OrderBy(x => x);
            var defaultEnum = new[] { RequiredFile };
            var namesByTagsWithDefault = defaultEnum.Concat(namesByTags);

            foreach (var nameByTag in namesByTagsWithDefault)
            {
                yield return $"{_path}\\{nameByTag}.{Extension}";
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