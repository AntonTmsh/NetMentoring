using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    internal class DeltaOneFeedProcessor : IFeedProcessor
    {
        public FeedItem Match(FeedItem feeditem)
        {
            Account.GetAccount(feeditem.CounterpartyId + feeditem.PrincipalId);
            return feeditem;
        }

        public void Save(FeedItem matchedaccount)
        {
            Console.WriteLine($"DeltaOneFeed {((DeltaOneFeed)matchedaccount).FeedItemId } successfully saved");
        }

        public void SaveErrors(IEnumerable<ValidationError> validationError)
        {
            foreach (ValidationError error in validationError)
            {
                Console.WriteLine($"Feed Item id {error.FeedId} has a following error {error.ErrorMessage}");
            }
        }

        public IEnumerable<ValidationError> Validate(FeedItem feeditem)
        {
            if (feeditem.GetType() != typeof(DeltaOneFeed))
                throw new Exception("Incorrect type detected");
            if (feeditem.CounterpartyId == default(int))
                ValidationError.AddValidationError(new ValidationError(((DeltaOneFeed)feeditem).FeedItemId, "CounterpartyId is empty!"));
            if (feeditem.PrincipalId == default(int))
                ValidationError.AddValidationError(new ValidationError(((DeltaOneFeed)feeditem).FeedItemId, "PrincipalId is empty!"));
            if (((DeltaOneFeed)feeditem).Isin == default(int))
                ValidationError.AddValidationError(new ValidationError(((DeltaOneFeed)feeditem).FeedItemId, "Isin is empty!"));
            if (((DeltaOneFeed)feeditem).MaturityDate == default(DateTime))
                ValidationError.AddValidationError(new ValidationError(((DeltaOneFeed)feeditem).FeedItemId, "MaturityDate is empty!"));
            return ValidationError.GetValidationError();
        }
    }
}