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
        private readonly IConfigurationHierarchyManager _configurationFileSorter;
        public ConfigurationSourceManager(IEnvironmentConfigsProvider environmentConfigs, IConfigurationHierarchyManager configurationFileSorter,
                                                    IConfigurationSource configurationSource, IFileReader fileReader, 
                                                    IConfigurationParser configurationParser)
                                                    
        {
            _environmentConfigs = environmentConfigs;
            _configurationSource = configurationSource;
            _fileReader = fileReader;
            _configurationParser = configurationParser;
            _configurationFileSorter = configurationFileSorter;
        }

        public IConfigurationSource GetConfigSource(IEnumerable<string> environmentNames, string pathToConfigsFolder, ConfigFileType configFileType)
        {
            foreach (var path in _configurationFileSorter.BuildHierarchy(_environmentConfigs.GetEnvironmentConfigFiles(environmentNames, pathToConfigsFolder, configFileType)))
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