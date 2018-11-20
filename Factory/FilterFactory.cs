namespace Epam.NetMentoring.Factory
{
    public class FilterFactory : IFilterFactory
    {
        internal const string BofaFilter = "BOFA";
        internal const string ConnacordFilter = "Connacord";
        internal const string BarclaysFilter = "Barclays";
        public virtual IFilter CreateFilter(string filtername)
        {

            switch (filtername)
            {
                case BofaFilter:
                    return new BOFAFilter();
                case ConnacordFilter:
                    return new ConnacordFilter();
                case BarclaysFilter:
                    return new BarclaysFilter();
                default:
                    return new DefaultFilter();
            }
        }
    }
}
