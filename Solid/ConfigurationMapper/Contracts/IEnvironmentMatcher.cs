using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IEnvironmentMatcher
    {
        /// <summary>
        /// Match a filename to a specific environment
        /// </summary>
        /// <param name="fileName">Config file name</param>
        /// <param name="environmentNames">Environment name</param>
        /// <returns>True if a file name matched to a specific environment</returns>
        bool Match(string fileName, IEnumerable<string> environmentNames);
    }
}