using System.Collections;
using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationReader
    {
        /// <summary>
        /// Return a ConfigurationSource class
        /// </summary>
        /// <param name="environmentNames">Collection of environment names</param>
        /// <returns>ConfigurationSource class</returns>
        IConfigurationSource Read(IEnumerable<string> environmentNames);
    }
}