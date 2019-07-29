using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationFileSorter
    {
        IEnumerable<string> Sort(IEnumerable<string> configFiles);
    }
}
