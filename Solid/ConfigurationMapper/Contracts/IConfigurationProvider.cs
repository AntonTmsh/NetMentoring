using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper.Storage;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Create instance of T and set properties value from a configuration file.
        /// </summary>
        /// <typeparam name="T">Instance type</typeparam>
        /// <returns>Instance from T with seted values</returns>
        T Get<T>(IEnumerable<string> environmentNames, string pathToConfigsFolder, ConfigFileType configFileType) where T:new();
    }
}