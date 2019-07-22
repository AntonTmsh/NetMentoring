using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class TextConfigParser : IConfigurationParser
    {
        private const char ParamValueSeparator = '=';
        public ConfigParameter Parse(string configLine)
        {
            var configParam = new ConfigParameter();
            if (string.IsNullOrEmpty(configLine))
            {
                throw new ArgumentException($"Parameter {nameof(configLine)} can't be null or empty");
            }
            var keyValue = configLine.Split(ParamValueSeparator);
            if (ValidateConfigString(keyValue))
                throw new ArgumentException("Configuration string has an invalid format");
            configParam.Value = keyValue[1].Trim();
            var fullKey = keyValue[0].Trim();
            var fullKeyParam = SplitByLastDot(fullKey);
            configParam.Parameter = fullKeyParam[1];
            configParam.ClassNameWithNamespace = fullKeyParam[0];
            return configParam;
        }

        private string[] SplitByLastDot(string input)
        {
            int idx = input.LastIndexOf('.');
            if (idx == -1)
                throw new ArgumentException(nameof(input));

            return new[] { input.Substring(0, idx), input.Substring(idx + 1) };
        }
        private static bool ValidateConfigString(IReadOnlyList<string> keyValue)
        {
            return keyValue.Count() != 2 || keyValue[0].Contains(" ");
        }
    }
}