using System;
using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper.Storage
{
    public class ConfigurationSource :IConfigurationSource
    {
        private readonly Dictionary<string, Dictionary<string, string>> _source;
        private readonly IConfigurationParser _configurationParser;

        public ConfigurationSource(IConfigurationParser configurationParser = null)
        {
            _source = new Dictionary<string, Dictionary<string, string>>();
            _configurationParser = configurationParser ?? new TextConfigParser();
        }

        public ConfigurationSource(IEnumerable<string> lines,IConfigurationParser configurationParser = null)
        {
            _source = new Dictionary<string, Dictionary<string, string>>();
            _configurationParser = configurationParser ?? new TextConfigParser();
            foreach (var line in lines)
                Add(line);
        }

        public string GetValue(string classNameWithNamespace, string parameterName)
        {
            var value = string.Empty;
            if (_source.ContainsKey(classNameWithNamespace))
            {
                var sourceConfiguration = _source[classNameWithNamespace];
                if (sourceConfiguration.ContainsKey(parameterName))
                    value = sourceConfiguration[parameterName];
            }

            return value;
        }

        public void Add(string configurationLine)
        {  
            var configParam = _configurationParser.Parse(configurationLine);
            if (_source.ContainsKey(configParam.ClassNameWithNamespace))
            {
                if (_source[configParam.ClassNameWithNamespace].ContainsKey(configParam.Parameter))
                {
                    _source[configParam.ClassNameWithNamespace][configParam.Parameter] = configParam.Value;
                }
                else
                    _source[configParam.ClassNameWithNamespace].Add(configParam.Parameter, configParam.Value);
            }
            else
            {
                var innerDic = new Dictionary<string, string> { { configParam.Parameter, configParam.Value } };
                _source.Add(configParam.ClassNameWithNamespace, innerDic);
            }
        }
    }
}