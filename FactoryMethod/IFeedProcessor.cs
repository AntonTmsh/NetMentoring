using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    public interface IFeedProcessor
    {
        IEnumerable<ValidationError> Validate(FeedItem feeditem);
        FeedItem Match(FeedItem feeditem);
        void Save(FeedItem matchedaccount);
        void SaveErrors(IEnumerable<ValidationError> validationError);
    }
}