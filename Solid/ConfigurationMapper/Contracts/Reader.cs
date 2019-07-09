using System.Collections;
using System.Collections.Generic;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public abstract class Reader
    {
        protected string PathToSource { get; }
        protected ISource SourceConfigs { get; }

        protected Reader(string pathToSource)
        {
            SourceConfigs = GetSource();
            PathToSource = pathToSource;
        }

        public abstract IDictionary Read(IEnumerable<string> tags);
        protected abstract ISourceProvider GetSourceProvider();
        protected abstract ISource GetSource();
    }
}