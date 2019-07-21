using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IEnvironmentMatcher
    {
        IEnumerable<string> Match(IEnumerable<string> fileNames, IEnumerable<string> environmentNames);
    }
}