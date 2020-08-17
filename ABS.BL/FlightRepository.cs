using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ABS.BL
{
    public class FlightRepository
    {
        private HashSet<Flight> _flights = new HashSet<Flight>();
        public bool AddNewFlight(Flight flight)
        {
            _flights.Add(flight);
            return true;
        }
        public Flight Retreive(string flightId,Airline airline)
        {
            foreach (Flight flight in _flights)
            {
                if (flight.FlightId == flightId&&flight.Airline.Equals(airline))
                    return flight;
            }
            return null;
        }
        /// <summary>
        /// Retreives all flights for an airline.
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public HashSet<Flight> Retreive(Airline airline)
        {
            HashSet<Flight> flightsFromAirline = new HashSet<Flight>();
            foreach (Flight flight in _flights)
            {
                if (flight.Airline.Equals(airline))
                    flightsFromAirline.Add(flight);
            }
            return flightsFromAirline;
        }
        public HashSet<Flight> Retreive()
        {
            return _flights;
        }

        public string DisplayFlightsDetails()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Flight flight in _flights)
            {
                builder.Append(flight.ToString());
            }
            return builder.ToString();
        }
        
        /// <summary>
        /// Prints all flight information for airline received as parameter.
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public string DisplayFlightDetailsForAirline(Airline airline)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Flight flight in Retreive(airline))
            {
                builder.Append(flight.ToString());
            }
            return builder.ToString();
        }
        
    }
}
