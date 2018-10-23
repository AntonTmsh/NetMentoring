using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<FeedItem>> listOfFeeds = new List<List<FeedItem>>();
            var managerFactory = new FeedManagerFactory();
            foreach (List<FeedItem> feeds in listOfFeeds)
            {
                var feedmanager =  managerFactory.CreateFeedManager(CheckFeedType(feeds));
                feedmanager.Process(feeds);
            }
        }

        private static string CheckFeedType(List<FeedItem> feed)
        {
            var item = feed.First();

            if (item.GetType() == typeof(EmFeed))
            {
                return "EM";
            }
            if (item.GetType() == typeof(DeltaOneFeed))
            {
                return "DeltaOne";
            }
            return "Unknown Type";
        }
    }
}
