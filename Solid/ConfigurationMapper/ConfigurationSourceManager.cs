using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;
using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationSourceManager : IConfigurationSourceManager
    {
        private readonly IConfigurationSource _configurationSource;
        private readonly IFileReader _fileReader;
        private readonly IEnvironmentConfigsProvider _environmentConfigs;
        private readonly IConfigurationParser _configurationParser;
        private readonly IConfigurationFileSorter _configurationFileSorter;
        public ConfigurationSourceManager(IEnvironmentConfigsProvider environmentConfigs, IConfigurationFileSorter configurationFileSorter,
                                                    IConfigurationSource configurationSource, IFileReader fileReader, 
                                                    IConfigurationParser configurationParser)
                                                    
        {
            _environmentConfigs = environmentConfigs;
            _configurationSource = configurationSource;
            _fileReader = fileReader;
            _configurationParser = configurationParser;
            _configurationFileSorter = configurationFileSorter;
        }

        public IConfigurationSource GetConfigSource(IEnumerable<string> environmentNames)
        {
            foreach (var path in _configurationFileSorter.Sort(_environmentConfigs.GetEnvironmentConfigFiles(environmentNames)))
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