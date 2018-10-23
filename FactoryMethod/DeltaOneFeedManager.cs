namespace Epam.NetMentoring.FactoryMethod
{
    internal class DeltaOneFeedManager : FeedManager
    {
        public override IFeedProcessor FeedProcessor { get => new DeltaOneFeedProcessor(); }
    }
}