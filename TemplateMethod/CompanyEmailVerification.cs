using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public class CompanyEmailVerification : EmailVerification
    {
        private readonly Template _template;

        public CompanyEmailVerification(Template template) : base(template)
        {
            _template = template;
        }
        protected override void CheckEmailContent(Template template)
        {
            Console.WriteLine("Template: {_template.Name} email content has been checked");
        }

        protected override void CheckEmails(Template template)
        {
            Console.WriteLine("Template: {_template.Name} emails has been checked");
        }

        protected override void CheckEmailsRegistration(Template template)
        {
            Console.WriteLine("Template: {_template.Name} emails registration has been checked");
        }

        protected override void CheckTemplateVariables(Template template)
        {
            Console.WriteLine("Template: {_template.Name} template variables has been checked");
        }

        protected override void CheckUserAccess(Template template)
        {
            Console.WriteLine("Template: {_template.Name} has been checked");
        }
    }
}
