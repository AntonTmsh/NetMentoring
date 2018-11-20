using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.FactoryMethod
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<List<FeedItem>> listOfFeeds = FeedInitializer.FeedInitialize();
            var managerFactory = new FeedManagerFactory();
            foreach (List<FeedItem> feeds in listOfFeeds)
            {
                var feedmanager = managerFactory.CreateFeedManager(CheckFeedType(feeds));
                feedmanager.Process(feeds);
                Console.ReadKey();
            }
        }

        private static string CheckFeedType(List<FeedItem> feed)
        {
            var item = feed.FirstOrDefault();

            if (item.GetType() == typeof(EmFeed))
            {
                return FeedManagerFactory.EMFeedType;
            }
            if (item.GetType() == typeof(DeltaOneFeed))
            {
                return FeedManagerFactory.DeltaOneFeedType;
            }
            return "Unknown Type";
        }
    }
}
