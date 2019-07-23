using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public class CompanyEmailVerification : EmailVerificatior
    {
        public CompanyEmailVerification(Template template, User user) : base(template,user)
        {
        }
        protected override void CheckEmailContent(Template template)
        {
            Console.WriteLine($"Template: {_template.Name} email content has been checked");
        }

        protected override void CheckEmails(Template template)
        {
            Console.WriteLine($"Template: {_template.Name} emails has been checked");
        }

        protected override void CheckEmailsRegistration(Template template)
        {
            Console.WriteLine($"Template: {_template.Name} emails registration has been checked");
        }

        protected override void CheckTemplateVariables(Template template)
        {
            Console.WriteLine($"Template: {_template.Name} template variables has been checked");
        }

        protected override bool CheckUserAccess(Template template, User user)
        {
            if (template.AllowedUserIds.Contains<int>(user.UserId))
            {
                Console.WriteLine($"User: {user.UserName} have accsess to a template: {_template.Name}");
                return true;
            }
            else
            {
                Console.WriteLine($"User: {user.UserName} haven't accsess to a template: {_template.Name}");
                return false;
            }
        }
    }
}
