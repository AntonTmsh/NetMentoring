using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper.Storage;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IEnvironmentConfigsProvider
    {
        /// <summary>
        /// Get a collection of config file names for a specific environment
        /// </summary>
        /// <param name="environmentNames">Collection of environment names.It uses for an environment specification for getting config names</param>
        /// <param name="pathToConfigsFolder">Path to folder with configs</param>
        /// <param name="configFileType">Configuration type</param>
        /// As example {{prod},{ny}} get configs like PROD,PROD-NY,PROD-NY-1 etc.
        /// <returns>Collection of config file names</returns>
        IEnumerable<string> GetEnvironmentConfigFiles(IEnumerable<string> environmentNames, string pathToConfigsFolder, ConfigFileType configFileType);
    }
}