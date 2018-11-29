namespace Epam.NetMentoring.FactoryMethod
{
    public class ValidationError
    {
        public int FeedId { get; }
        public string ErrorMessage { get; }
        public ValidationError(int id, string message)
        {
            FeedId = id;
            ErrorMessage = message;
        }
    }
}