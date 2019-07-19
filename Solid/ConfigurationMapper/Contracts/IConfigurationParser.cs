using Epam.NetMentoring.ConfigurationMapper.Model;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationParser
    {
        /// <summary>
        /// Parse configuration line 
        /// </summary>
        /// <param name="configLine">String with configuration info</param>
        /// <returns>ConfigParameter</returns>
        ConfigParameter Parse(string configLine);
    }
}