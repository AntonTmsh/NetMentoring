using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    public abstract class FeedManager
    {
        public abstract IFeedProcessor FeedProcessor { get; }

        public void Process(IEnumerable<FeedItem> feeditems)
        {
            foreach (var item in feeditems)
            {
                FeedProcessor.Validate(item);
                FeedProcessor.Save(FeedProcessor.Match(item));
            }
        }
    }
}