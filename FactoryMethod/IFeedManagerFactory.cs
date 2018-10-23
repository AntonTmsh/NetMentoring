using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.FactoryMethod
{
    public interface IFeedManagerFactory
    {
        FeedManager CreateFeedManager(string feedType);
    }
}
