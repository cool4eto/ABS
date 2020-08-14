using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ABS.BL
{
    public static class FlightRepository
    {
        private static List<Flight> flights = new List<Flight>();
        public static bool Save(Flight flight)
        {
            foreach (Flight flight1 in flights)
            {
                if (flight.FlightId == flight1.FlightId && flight.Airline==flight1.Airline)
                    throw new Exception("Such flight already exists");
            }
            flights.Add(flight);
            return true;
        }
        public static Flight Retreive(string flightId,Airline airline)
        {
            foreach (Flight flight in flights)
            {
                if (flight.FlightId == flightId&&flight.Airline.Equals(airline))
                    return flight;
            }
            return null;
        }
        /// <summary>
        /// 
        /// retreives all flights for an airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public static List<Flight> Retreive(Airline airline)
        {
            List<Flight> flightsFromAirline = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (flight.Airline.Equals(airline))
                    flightsFromAirline.Add(flight);
            }
            return flightsFromAirline;
        }
        public static List<Flight> Retreive()
        {
            return flights;
        }
        
    }
}
