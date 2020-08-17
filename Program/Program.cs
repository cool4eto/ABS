using System;
using ABS.BL;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
            {
            SystemManager res = new SystemManager();
            res.CreateAirport("DEN");
            res.CreateAirport("DFW");
            res.CreateAirport("LON");
            res.CreateAirport("JPN");
            // Invalid.
            res.CreateAirport("DE"); 
            res.CreateAirport("DEH");
            res.CreateAirport("DEN");
            res.CreateAirport("NCE");
            // Invalid.
            res.CreateAirport("TRIord9"); 
            res.CreateAirport("DEN");
         
            res.CreateAirline("DELTA");
            res.CreateAirline("AMER");
            res.CreateAirline("JET");
            // Already exists.
            res.CreateAirline("DELTA");
            res.CreateAirline("SWEST");
            // Already exists.
            res.CreateAirline("AMER");
            res.CreateAirline("FRONT");
            // Invalid
            res.CreateAirline("FRONTIER"); 

            res.CreateFlight("DELTA", "DEN", "LON", 2009, 10, 10, "123");
            res.CreateFlight("DELTA", "DEN", "DEH", 2009, 8, 8, "567");
            // Invalid.
            res.CreateFlight("DELTA", "DEN", "NCE", 2010, 9, 8, "567");
            res.CreateFlight("JET", "LON", "DEN", 2009, 5, 7, "123");
            res.CreateFlight("AMER", "DEN", "LON", 2010, 10, 1, "123");
            res.CreateFlight("JET", "DEN", "LON", 2010, 6, 10, "786");
            res.CreateFlight("JET", "DEN", "LON", 2009, 1, 12, "909");

            // Create sections.
            res.CreateSection("JET", "123", 2, 2, SeatClass.Economy);
            // Invalid for me.
            res.CreateSection("JET", "123", 1, 3, SeatClass.Economy);
            res.CreateSection("JET", "123", 2, 3, SeatClass.First);
            res.CreateSection("DELTA", "123", 1, 1, SeatClass.Business);
            res.CreateSection("DELTA", "123", 1, 2, SeatClass.Economy);
            // Invalid.
            res.CreateSection("SWSERTT", "123", 5, 5, SeatClass.Economy);

            res.DisplaySystemDetails();

            res.FindAvailableFlights("DEN", "LON");

            res.BookSeat("DELTA", "123", SeatClass.Business, 1, 'A');
            res.BookSeat("DELTA", "123", SeatClass.Economy, 1, 'A');
            res.BookSeat("DELTA", "123", SeatClass.Economy, 1, 'B');
            // Already booked.
            res.BookSeat("DELTA", "123", SeatClass.Business, 1, 'A');

            res.DisplaySystemDetails();

            res.FindAvailableFlights("DEN", "LON");
            Console.ReadKey();
            
        }
        }
}
