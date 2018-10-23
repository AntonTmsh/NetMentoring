using System;

namespace Epam.NetMentoring.FactoryMethod
{
    public class FeedItem
    {
        public int StagingId { get; set; }
        public string SourceTradeRef { get; set; }
        public int CounterpartyId { get; set; }
        public int PrincipalId { get; set; }
        public string ValuationDate { get; set; }
        public int CurrentPrice { get; set; }
        public int SourceAccountId { get; set; }
    }
    public class DeltaOneFeed : FeedItem
    {
        public int Isin { get; set; }
        public DateTime MaturityDate { get; set; }

        public int FeedItemId { get => base.CounterpartyId + base.PrincipalId; }

    }

    public class EmFeed : FeedItem
    {
        public string Sedol { get; set; }
        public int AssetValue { get; set; }
        public int FeedItemId { get => base.SourceAccountId; }
    }
}