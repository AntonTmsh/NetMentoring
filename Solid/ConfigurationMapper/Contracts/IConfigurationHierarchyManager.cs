using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationHierarchyManager
    {   /// <summary>
        /// Build hierarchy for config files
        /// </summary>
        /// <param name="configString">String with configuration info which we read from config file</param>
        /// <returns>Path to configs</returns>
        IEnumerable<string> BuildHierarchy(IEnumerable<string> configFiles);
    }
}
