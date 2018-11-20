using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    internal static class FeedInitializer
    {
        internal static List<List<FeedItem>> FeedInitialize()
        {

            var deltaOneFeeds = new List<FeedItem>()
            {
            new DeltaOneFeed() { CounterpartyId = 1, CurrentPrice = 2, Isin =3, MaturityDate = DateTime.Now ,PrincipalId = 4,SourceAccountId = 5, SourceTradeRef = "7", StagingId = 8, ValuationDate = "1990/11/10" },
            new DeltaOneFeed() { CounterpartyId = 2, CurrentPrice = 10, Isin =2, MaturityDate = DateTime.Now ,PrincipalId = 8,SourceAccountId = 3, SourceTradeRef = "3", StagingId = 6, ValuationDate = "1993/9/10" },
            new DeltaOneFeed() { CounterpartyId = 4, CurrentPrice = 22, Isin =6, MaturityDate = DateTime.Now ,PrincipalId = 7,SourceAccountId = 8, SourceTradeRef = "11", StagingId = 9, ValuationDate = "1992/3/10" },
            new DeltaOneFeed() { CounterpartyId = 9, CurrentPrice = 22, MaturityDate = DateTime.Now ,PrincipalId = 7,SourceAccountId = 8, SourceTradeRef = "11", StagingId = 9, ValuationDate = "1992/3/10" },
            };

            var emFeedFeeds = new List<FeedItem>()
            {
            new EmFeed() { CounterpartyId = 1, CurrentPrice = 2, AssetValue =3, Sedol = "3" ,PrincipalId = 4,SourceAccountId = 5, SourceTradeRef = "7", StagingId = 8, ValuationDate = "1990/11/10" },
            new EmFeed() { CounterpartyId = 2, CurrentPrice = 10, AssetValue =2, Sedol = "7" ,PrincipalId = 8,SourceAccountId = 3, SourceTradeRef = "3", StagingId = 6, ValuationDate = "1993/9/10" },
            new EmFeed() { CounterpartyId = 4, CurrentPrice = 22, AssetValue =6, Sedol = "9" ,PrincipalId = 7,SourceAccountId = 8, SourceTradeRef = "11", StagingId = 9, ValuationDate = "1992/3/10" },
            };

            return new List<List<FeedItem>>() { deltaOneFeeds, emFeedFeeds }; ;
        }
    }
}
