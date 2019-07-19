using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationSource
    {
        /// <summary>
        /// Return a value for parameter in specific class
        /// </summary>
        /// <param name="classNameWithNamespace">Class name with namespace</param>
        /// <param name="parameterName">Parameter name</param>
        /// <returns>Configuration value</returns>
        string GetValue(string classNameWithNamespace, string parameterName);
        /// <summary>
        /// Add a configuration line in internal storage structure 
        /// </summary>
        /// <param name="configLine">Config line from config file</param>
        void Add(string configLine);
    }
}