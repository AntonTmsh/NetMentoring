namespace Epam.NetMentoring.ConfigurationTypes
{
    public struct ServiceSettingsWrong
    {
        public int ConnectionString { get; set; }
        public int Port { get; set; }
        public int BatchSize { get; set; }
        public string HostName { get; }
    }
}