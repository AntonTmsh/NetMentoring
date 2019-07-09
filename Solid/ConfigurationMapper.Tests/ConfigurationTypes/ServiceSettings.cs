using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Epam.NetMentoring.ConfigurationTypes
{
    public class ServiceSettings
    {
        public string ConnectionString { get; set; }
        public int Port { get; set; }
        public int BatchSize { get; set; }
        public string HostName { get; set; }
    }
}
