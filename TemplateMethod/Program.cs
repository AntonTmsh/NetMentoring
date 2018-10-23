using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var template = new Template
            {
                Name = "Test",
                CustomerName = "TestCustomer",
                Email = new List<string>() { "test@test.com" },
                isRegistered = true,
                MsgContent = "Hello",
                User = new List<string>() { "TestUser" }
            };

            var verification = new CompanyEmailVerification(template);
            verification.Verification();
        }
    }
}
