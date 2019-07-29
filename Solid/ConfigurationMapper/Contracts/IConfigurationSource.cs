using System.Collections.Generic;
using Epam.NetMentoring.ConfigurationMapper.Model;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationSource
    {
        /// <summary>
        /// This class contains config info from configuration files.
        ///It has an internal storage structure a dictionary of dictionary grouped by class with namespace and params.
        ///Also, all value is overridden
        /// </summary>
        /// <param name="classNameWithNamespace">Class name with namespace</param>
        /// <param name="parameterName">Parameter name</param>
        /// <returns>Configuration value</returns>
        string GetValue(string classNameWithNamespace, string parameterName);
        /// <summary>
        /// Add a configuration string in internal storage structure.
        /// </summary>
        /// <param name="configLine">Config line from config file</param>
        void Add(ConfigParameter configLine);
    }
}