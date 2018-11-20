using System.Collections.Generic;

namespace Epam.NetMentoring.Factory
{
    internal static class TradeInitializer
    {
        internal static List<Trade> TradeInitialize()
        {

            var trades = new List<Trade>()
            {
            new Trade(79, ConnacordFilter.ConnacordType, "testSubType"),
            new Trade(732, ConnacordFilter.ConnacordType, "testSubType2"),
            new Trade(34, ConnacordFilter.ConnacordType, BarclaysFilter.BarclaysSybType),
            new Trade(18, BarclaysFilter.BarclaysType, BarclaysFilter.BarclaysSybType),
            new Trade(8, ConnacordFilter.ConnacordType, "testSubType3"),
            new Trade(18, ConnacordFilter.ConnacordType, "testSubType4"),
            new Trade(194, ConnacordFilter.ConnacordType, "testSubType5"),
            new Trade(743, "testType", "testSubType"),
            new Trade(23, ConnacordFilter.ConnacordType, "testSubType6"),
            new Trade(83, BarclaysFilter.BarclaysType, BarclaysFilter.BarclaysSybType),
            new Trade(93, ConnacordFilter.ConnacordType, "testSubType7"),
            };

            return trades;
        }
    }
}
