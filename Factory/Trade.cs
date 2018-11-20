namespace Epam.NetMentoring.Factory
{
    public class Trade
    {
        public int Amount { get; }
        public string Type { get; }
        public string SybType { get; }

        public Trade(int amount, string type, string sybType)
        {
            Amount = amount;
            Type = type;
            SybType = sybType;
        }
    }
}
