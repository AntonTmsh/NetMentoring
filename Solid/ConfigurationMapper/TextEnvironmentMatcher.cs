using Epam.NetMentoring.ConfigurationMapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class TextEnvironmentMatcher : IEnvironmentMatcher
    {
        public bool Match(string fileName, IEnumerable<string> environmentNames)
        {
            if (fileName == null || !fileName.Any())
                throw new ArgumentException(nameof(fileName));
            var pattern = CreatePattern(environmentNames);
            return PatternMatch(pattern, fileName);
        }

        private static string CreatePattern(IEnumerable<string> inputs)
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

        private static bool PatternMatch(string pattern, string input)
        {
            return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success;
        }
    }
}