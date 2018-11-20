using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    public class Account
    {
        private static readonly Dictionary<int, Account> _accounts = new Dictionary<int, Account>();
        public FeedItem FeedItem { get; }
        public int Id { get; }
        public Account(int id)
        {
            Id = id;
        }

        public static Account GetAccount(int id)
        {
            if (!_accounts.ContainsKey(id))
            {
                _accounts.Add(id, new Account(id));
            }
            return _accounts[id];
        }
    }
}
