using System;

namespace Epam.NetMentoring.FactoryMethod
{
    public class FeedManagerFactory : IFeedManagerFactory
    {
        internal const string DeltaOneFeedType = "DeltaOne";
        internal const string EMFeedType = "EM";

        public FeedManager CreateFeedManager(string feedType)
        {
            if (feedType == DeltaOneFeedType)
            {
                return new DeltaOneFeedManager();
            }
            else if (feedType == EMFeedType)
            {
                return new EMFeedManager();
            }
            throw new ArgumentException($"{ feedType } unknow / not - supported");
        }
    }
}
