using System;
using System.Threading;

namespace Epam.NetMentoring.Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log("Starting program");

            var thread = new Thread(() =>
            {                
                var zoo = new Zoo();
                var elt = new EarthLiveTicker();
                elt.Subscribe(zoo);
                //EarthLiveTicker.LiveTicker.Subscribe(zoo);
                var animalProvider = new AnimalProvider(zoo);
                elt.Subscribe(animalProvider);
                //EarthLiveTicker.LiveTicker.Subscribe(animalProvider);
            });
            thread.Start();

            Logger.Log("Animan provider started working");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
