using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public class Template
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<string> Email { get; set; }
        public IEnumerable<int> AllowedUserIds { get; set; }
        public string MsgContent { get; set; }
        public bool IsRegistered { get; set; }
    }
}
