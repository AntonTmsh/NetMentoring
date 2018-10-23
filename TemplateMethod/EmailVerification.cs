using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public abstract class EmailVerification
    {

        private readonly Template _template;

        public EmailVerification(Template template)
        {
            _template = template;
        }

        public void Verification()
        {
            CheckUserAccess(_template);
            CheckEmails(_template);
            CheckEmailsRegistration(_template);
            CheckEmailContent(_template);
            CheckTemplateVariables(_template);
            Save(_template);
        }

        protected abstract void CheckUserAccess(Template template);
        protected abstract void CheckEmails(Template template);
        protected abstract void CheckEmailsRegistration(Template template);
        protected abstract void CheckEmailContent(Template template);
        protected abstract void CheckTemplateVariables(Template template);
        protected virtual void Save(Template template)
        {
            Console.WriteLine("Template: {_template.Name} has been saved");
        }
    }


}
