using System;
using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationSource :ISource
    {
        public Dictionary<string, Dictionary<string, string>> Source { get; }

        public ConfigurationSource()
        {
            Source = new Dictionary<string, Dictionary<string, string>>();
        }

        public void AddNode(string node)
        {
            if (string.IsNullOrEmpty(node))
            {
                throw new ArgumentException(nameof(node));
            }
            var keyValue = node.Split('=');
            if (keyValue.Length != 2)
                throw new ArgumentException("Invalid configuration file format");
            var value = keyValue[1].Trim();
            var fullKey = keyValue[0].Trim();
            var fullKeyParam = SplitByLastDot(fullKey);
            var param = fullKeyParam[1];
            var key = fullKeyParam[0];
            if (Source.ContainsKey(key))
            {
                if (Source[key].ContainsKey(param))
                {
                    Source[key][param] = value;
                }
                else
                    Source[key].Add(param, value);
            }
            else
            {
                var innerDic = new Dictionary<string, string> { { param, value } };
                Source.Add(key, innerDic);
            }
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