namespace Epam.NetMentoring.ConfigurationTypes
{
    public class ServiceSettingsWrong
    {
        public string ConnectionString { get; set; }
        public int Port { get; set; }
        public int BatchSize { get; set; }
        public string HostName { get; }
    }
}