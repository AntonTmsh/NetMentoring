using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationReader : IConfigurationReader
    {
        private readonly IConfigurationSource _configurationSource;
        private readonly IFileReader _fileReader;
        private readonly IEnvironmentConfigsProvider _environmentConfigs;
        private readonly IConfigurationParser _configurationParser;
        public ConfigurationReader(IEnvironmentConfigsProvider environmentConfigs, IConfigurationSource configurationSource = null, 
                                                    IFileReader fileReader = null, IConfigurationParser configurationParser = null)
        {
            _environmentConfigs = environmentConfigs;
            _configurationSource = configurationSource ?? new ConfigurationSource();
            _fileReader = fileReader ?? new FileReader();
            _configurationParser = configurationParser ?? new TextConfigParser();
        }

        public IConfigurationSource Read(IEnumerable<string> environmentNames)
        {
            foreach (var path in _environmentConfigs.GetEnvironmentConfigFiles(environmentNames) )
            {
                foreach (var line in _fileReader.Read(path))
                {
                    var configParam = _configurationParser.Parse(line);
                    _configurationSource.Add(configParam);
                }
            }

            return _configurationSource;
        }
    }
}