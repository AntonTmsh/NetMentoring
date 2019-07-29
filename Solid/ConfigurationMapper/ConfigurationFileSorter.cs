using Epam.NetMentoring.ConfigurationMapper.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationFileSorter: IConfigurationFileSorter
    {
        public IEnumerable<string> Sort(IEnumerable<string> configFiles)
        {
            return  configFiles.OrderBy(x => x);
        }
    }
}