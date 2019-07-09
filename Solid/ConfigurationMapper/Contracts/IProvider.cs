namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IProvider
    {
        T Get<T>();
    }
}