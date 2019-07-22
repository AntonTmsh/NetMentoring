using System.Collections;
using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationReader
    {
        /// <summary>
        /// Return a ConfigurationSource class.This class contains config info from configuration files.
        ///It has an internal storage structure a dictionary of dictionary grouped by class with namespace and params.
        ///Also, all value is overridden
        /// </summary>
        /// <param name="environmentNames">Collection of environment names.It uses for an environment specification for getting configs</param>
        /// As example {{prod},{ny}} get configs like PROD,PROD-NY,PROD-NY-1 etc.
        /// <returns>ConfigurationSource class</returns>
        IConfigurationSource Read(IEnumerable<string> environmentNames);
    }
}