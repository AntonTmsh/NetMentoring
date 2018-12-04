using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter.TemplateMethod
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var template = new Template
            {
                Name = "TestTemplate",
                CustomerName = "TestCustomer",
                Email = new List<string>() { "test@test.com" },
                IsRegistered = true,
                MsgContent = "Hello",
                AllowedUserIds = new int[] { 1, 3, 5, 7, 9 }
        };

            var validUser = new User
            {
                UserName = "ValidTestUser",
                UserId = 1
            };

            var verification = new CompanyEmailVerification(template, validUser);
            verification.Verification();
            Console.ReadKey();


            var invalidUser = new User
            {
                UserName = "InvalidTestUser1",
                UserId = 100
            };

            verification = new CompanyEmailVerification(template, invalidUser);
            verification.Verification();
            Console.ReadKey();
        }
    }
}
