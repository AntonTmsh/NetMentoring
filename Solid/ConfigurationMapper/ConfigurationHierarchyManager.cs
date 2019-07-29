using Epam.NetMentoring.ConfigurationMapper.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationHierarchyManager : IConfigurationHierarchyManager
    {
        public IEnumerable<string> BuildHierarchy(IEnumerable<string> configFiles)
        {
            return  configFiles.OrderBy(x => x);
        }
    }
}