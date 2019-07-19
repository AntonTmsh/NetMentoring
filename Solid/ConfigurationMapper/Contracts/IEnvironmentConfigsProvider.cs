using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IEnvironmentConfigsProvider
    {
        /// <summary>
        /// Create a collection of paths to config files for a specific environments
        /// </summary>
        /// <param name="environmentNames">Collection of environment names</param>
        /// <returns>Collection of paths to config files</returns>
        IEnumerable<string> GetEnvironmentConfigPaths(IEnumerable<string> environmentNames);
    }
}