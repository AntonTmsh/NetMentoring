using System.Collections;
using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface ISourceProvider
    {
        IEnumerable<string> GetSource(IEnumerable<string> tags);
    }
}