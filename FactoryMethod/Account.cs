using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.FactoryMethod
{
    public class Account
    {
        private static readonly Dictionary<int, Account> _accaunts = new Dictionary<int, Account>();
        public FeedItem FeedItem { get; }
        public int Id { get; }
        public Account(int id)
        {
            Id = id;
        }

        public static Account GetAccount(int id)
        {
            if (!_accaunts.ContainsKey(id))
            {
                _accaunts.Add(id, new Account(id));
            }
            return _accaunts[id];
        }
    }
    //public class AccountDB
    //{
    //    public static Dictionary<int, Account> Accounts { get; set; }
    //}
}
