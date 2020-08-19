using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ABS.BL
{
    public class FlightRepository
    {
        private Dictionary<string,Flight> _flights = new Dictionary<string, Flight>();
        public void AddNewFlight(Flight flight)
        {
            _flights.Add(flight.FlightId,flight);
        }
        public Flight Retreive(string flightId)
        {
            if (_flights.ContainsKey(flightId))
                return _flights[flightId];

            return null;
        }

        public Dictionary<string,Flight> Retreive()
        {
            return _flights;
        }

        public string DisplayFlightsDetails()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Flight flight in _flights.Values)
            {
                builder.Append(flight.ToString());
            }

            return builder.ToString();
        }
    }
}
