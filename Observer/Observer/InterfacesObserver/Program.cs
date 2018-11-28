namespace Net.Mentoring.Patterns.InterfaceObserver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var st = new StockTicker();

            var gf = new GoogleMonitor();
            var mf = new MicrosoftMonitor();

            using (st.Subscribe(gf))
            using (st.Subscribe(mf))
            {
                foreach (var s in SampleData.getNext()) st.Stock = s;
            }
        }
    }
}