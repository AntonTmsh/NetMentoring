using Epam.NetMentoring.ConfigurationMapper.Contracts;
using System.Collections.Generic;
using System.IO;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class FileReader : IFileReader
    {
        private const string CommentSymbol = "#";
        public IEnumerable<string> Read(string pathToConfigFile)
        {
            using (var fr = new StreamReader(pathToConfigFile))
            {
                while (!fr.EndOfStream)
                {
                    var line = fr.ReadLine();
                if (ValidateConfigString(line))
                    continue;
                yield return line;
                }
            }         
        }
        private static bool ValidateConfigString(string line)
        {
            line = line.Trim();
            return string.IsNullOrWhiteSpace(line) || line.StartsWith(CommentSymbol);
        }
    }
}