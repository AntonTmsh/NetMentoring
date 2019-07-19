using System;
using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Model;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class TextConfigParser : IConfigurationParser
    {
        public ConfigParameter Parse(string configLine)
        {
            var configParam = new ConfigParameter();
            if (string.IsNullOrEmpty(configLine))
            {
                throw new ArgumentException($"Parameter {nameof(configLine)} can't be null or empty");
            }
            var keyValue = configLine.Split('=');
            if (keyValue.Length != 2)
                throw new ArgumentException("Invalid configuration line format");
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

            return new string[] { input.Substring(0, idx), input.Substring(idx + 1) };
        }
    }
}