using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    //ConfigurationSource
    public class ConfigurationReader : Reader
    {
        private const string CommentSymbol = "#";

        public ConfigurationReader(string path) : base(path)
        {
        }

        public override IDictionary Read(IEnumerable<string> tags)
        {
            var csp = GetSourceProvider();
            var sources = csp.GetSource(tags);
            foreach (var source in sources)
            {
                var lines = File.ReadLines(source)
                    .Where(x => !(string.IsNullOrWhiteSpace(x) || x.StartsWith(CommentSymbol)));
                foreach (var line in lines) SourceConfigs.AddNode(line);
            }

            return SourceConfigs.Source;
        }

        protected override ISourceProvider GetSourceProvider()
        {
            return new ConfigurationSourceProvider(PathToSource);
        }

        protected override ISource GetSource()
        {
            return new ConfigurationSource();
        }
    }
}