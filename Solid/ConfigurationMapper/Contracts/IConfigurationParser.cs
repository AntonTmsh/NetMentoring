using Epam.NetMentoring.ConfigurationMapper.Model;

namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationParser
    {
        /// <summary>
        /// Parse configuration string
        /// </summary>
        /// <param name="configString">String with configuration info which we read from config file</param>
        /// <returns>ConfigParameter class that contain parse strings as fields</returns>
        ConfigParameter Parse(string configString);
    }
}