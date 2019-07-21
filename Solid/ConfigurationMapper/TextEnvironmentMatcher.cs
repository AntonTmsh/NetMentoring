using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class TextEnvironmentMatcher : IEnvironmentMatcher
    {
        public IEnumerable<string> Match(IEnumerable<string> fileNames, IEnumerable<string> environmentNames)
        {
            if (fileNames == null || !fileNames.Any())
                throw new ArgumentException(nameof(fileNames));
            var pattern = CreatePattern(environmentNames);
            return fileNames.Where(x => PatternMatch(pattern, x));
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