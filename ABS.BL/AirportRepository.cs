using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ABS.BL
{
    /// <summary>
    /// Holds repository with airports.
    /// </summary>
    public class AirportRepository
    {
        private HashSet<Airport> _airports = new HashSet<Airport>();
        public bool AddNewAirport(Airport a)
        {
            if(!_airports.Contains(a))
            _airports.Add(a);
            return true;
        }
        /// <summary>
        /// Retreives an airport with name from the parameter.
        /// </summary>
        public Airport Retreive(string airportName)
        {
            foreach (Airport airport in _airports)
            {
                if (airport.AirportName.Equals(airportName))
                    return airport;
            }
            return null;
        }
        /// <summary>
        /// Retreives all airports.
        /// </summary>
        /// <returns></returns>
        public HashSet<Airport> RetreiveAllAirports()
        {
            return _airports;
        }
        public string DisplayAirportsDetails()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Airport airport in _airports)
            {
                builder.Append(airport.ToString());
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
