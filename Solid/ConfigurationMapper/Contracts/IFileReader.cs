using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IFileReader
    {
        /// <summary>
        /// Create a collection of string from a config file
        /// </summary>
        /// <param name="pathToConfigFile">Path to a config file</param>
        /// <returns>Collection of string from a config file</returns>
        IEnumerable<string> Read(string pathToConfigFile);
    }
}