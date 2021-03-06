﻿using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    internal class EMFeedProcessor : IFeedProcessor
    {
        private List<ValidationError> _validationerror = new List<ValidationError>();
        public FeedItem Match(FeedItem feeditem)
        {
            Account.GetAccount(feeditem.SourceAccountId);
            return feeditem;
        }

        public void Save(FeedItem matchedaccount)
        {
            Console.WriteLine($"EMFeed {matchedaccount.SourceAccountId} successfully saved");
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
            if (feeditem.GetType() != typeof(EmFeed))
            {
                throw new Exception("Incorrect type detected");
            }

            if (feeditem.SourceAccountId == default(int))
            {
                _validationerror.Add(new ValidationError(((EmFeed)feeditem).FeedItemId, "SourceAccountId is empty!"));
            }

            if (((EmFeed)feeditem).Sedol == default(string))
            {
                _validationerror.Add(new ValidationError(((EmFeed)feeditem).FeedItemId, "Sedol is empty!"));
            }

            if (((EmFeed)feeditem).AssetValue == default(int))
            {
                _validationerror.Add(new ValidationError(((EmFeed)feeditem).FeedItemId, "AssetValue is empty!"));
            }

            return _validationerror;
        }
    }
}