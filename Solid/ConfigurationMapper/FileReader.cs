using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class FileReader : IFileReader
    {
        private const string CommentSymbol = "#";
        public IEnumerable<string> ReadLine(string pathToConfigFile)
        {
            using (var fr = new StreamReader(pathToConfigFile))
            {
                while (!fr.EndOfStream)
                {
                    var line = fr.ReadLine();
                if (ValidateLine(line))
                    continue;
                yield return line;
                }
            }         
        }
        private bool ValidateLine(string line)
        {
            line = line.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith(CommentSymbol))
                return true;

            return false;
        }
    }
}