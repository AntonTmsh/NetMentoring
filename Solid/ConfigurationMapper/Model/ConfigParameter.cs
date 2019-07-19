using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.ConfigurationMapper.Model
{
    public class ConfigParameter
    {
        public string ClassNameWithNamespace { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
}
