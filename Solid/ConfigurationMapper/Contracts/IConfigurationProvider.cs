namespace Epam.NetMentoring.ConfigurationMapper.Contracts
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Create instance of T and set properties value from file configuration.
        /// </summary>
        /// <typeparam name="T">instance type</typeparam>
        /// <returns>Instance from T with seted values</returns>
        T Get<T>() where T:new();
    }
}