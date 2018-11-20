namespace Epam.NetMentoring.FactoryMethod
{
    public interface IFeedManagerFactory
    {
        FeedManager CreateFeedManager(string feedType);
    }
}
