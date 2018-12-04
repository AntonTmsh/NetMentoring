using System;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public abstract class EmailVerificatior
    {

        protected readonly Template _template;
        protected readonly User _user;

        public EmailVerificatior(Template template, User user)
        {
            _template = template;
            _user = user;
        }

        public void Verification()
        {
            if (CheckUserAccess(_template, _user))
            {
                CheckEmails(_template);
                CheckEmailsRegistration(_template);
                CheckEmailContent(_template);
                CheckTemplateVariables(_template);
                Save(_template);
            }
        }

        protected abstract bool CheckUserAccess(Template template, User user);
        protected abstract void CheckEmails(Template template);
        protected abstract void CheckEmailsRegistration(Template template);
        protected abstract void CheckEmailContent(Template template);
        protected abstract void CheckTemplateVariables(Template template);
        protected virtual void Save(Template template)
        {
            Console.WriteLine($"Template: {_template.Name} has been saved");
        }
    }


}
