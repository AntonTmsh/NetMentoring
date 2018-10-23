using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public class Template
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<string> Email { get; set; }
        public IEnumerable<string> User { get; set; }
        public string MsgContent { get; set; }
        public bool isRegistered { get; set; }
    }
}
