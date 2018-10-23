namespace Epam.NetMentoring.FactoryMethod
{
    internal class EMFeedManager : FeedManager
    {
        public override IFeedProcessor FeedProcessor {get => new EMFeedProcessor(); }
    }
}