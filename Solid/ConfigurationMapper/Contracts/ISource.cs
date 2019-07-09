using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface ISource
    {
        Dictionary<string, Dictionary<string, string>> Source { get; }
        void AddNode(string node);
    }
}