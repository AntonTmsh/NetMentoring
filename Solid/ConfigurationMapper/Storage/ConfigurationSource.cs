using System;
using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Model;

namespace Epam.NetMentoring.ConfigurationMapper.Storage
{
    public class ConfigurationSource :IConfigurationSource
    {
        private readonly Dictionary<string, Dictionary<string, string>> _source;

        public ConfigurationSource()
        {
            _source = new Dictionary<string, Dictionary<string, string>>();
        }

        public ConfigurationSource(IEnumerable<ConfigParameter> configParams)
        {
            _source = new Dictionary<string, Dictionary<string, string>>();
            foreach (var param in configParams)
                Add(param);
        }

        public string GetValue(string classNameWithNamespace, string parameterName)
        {
            string value = null;
            if (_source.ContainsKey(classNameWithNamespace))
            {
                var sourceConfiguration = _source[classNameWithNamespace];
                if (sourceConfiguration.ContainsKey(parameterName))
                    value = sourceConfiguration[parameterName];
            }

            return value;
        }

        public void Add(ConfigParameter configParam)
        {  
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