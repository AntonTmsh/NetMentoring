namespace Epam.NetMentoring.Factory
{
    public interface IFilterFactory
    {
        IFilter CreateFilter(string filtername);
    }
}
