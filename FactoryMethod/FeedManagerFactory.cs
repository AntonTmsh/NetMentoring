using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.FactoryMethod
{
    public class FeedManagerFactory : IFeedManagerFactory
    {
        public FeedManager CreateFeedManager(string feedType)
        {
            if (feedType == "DeltaOne")
            {
                return new DeltaOneFeedManager();
            }
            else if (feedType == "EM")
            {
                return new EMFeedManager();
            }
            throw new Exception("Unsupported feed type");
        }
    }
}
