namespace KnockKnockDataConsole
{
    using System;
    using System.Diagnostics;

    using KnockKnock.Data;
    using KnockKnock.Data.Models;
    using KnockKnock.Models;

    internal sealed class Program
    {
        private static readonly IDataRepository database = DataRepository.Singleton;

        private static void Main(string[] args)
        {
            // Uncomment to insert the data (make sure not to insert it more than once)...
            //database.SaveFeed(SampleFeedFactory.CampusMartius);
            //database.SaveFeed(SampleFeedFactory.WholeFoods);
            //database.SaveFeed(SampleFeedFactory.Firebird);
            //database.SaveFeed(SampleFeedFactory.HenryFordMuseum);

            var criteria = new FeedCriteria();
            criteria.FeedName = "Qube";
            criteria.Location = new Location { Latitude = 42.331563, Longitude = -83.046588 };
            criteria.Radius = 10;

            foreach (var feed in database.GetFeeds(criteria))
            {
                Console.WriteLine($"{feed.Id} - {feed.Name}");
            }

            PressEnterToExit();
        }

        [Conditional("DEBUG")]
        private static void PressEnterToExit()
        {
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to exit...");

            Console.ReadLine();
        }
    }

    public static class SampleFeedFactory
    {
        private static readonly Feed CampusMartius   = new Feed { Name = "Campus Martius",    Location = new Location { Latitude = 42.331563, Longitude = -83.046588 } };
        private static readonly Feed WholeFoods      = new Feed { Name = "Whole Foods",       Location = new Location { Latitude = 42.348455, Longitude = -83.056737 } };
        private static readonly Feed Firebird        = new Feed { Name = "Firebird",          Location = new Location { Latitude = 42.334695, Longitude = -83.043266 } };
        private static readonly Feed HenryFordMuseum = new Feed { Name = "Henry Ford Museum", Location = new Location { Latitude = 42.302896, Longitude = -83.233259 } };
    }
}