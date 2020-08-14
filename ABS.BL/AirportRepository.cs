using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ABS.BL
{
    /// <summary>
    /// Holds repository with airports
    /// </summary>
    public static class AirportRepository
    {
        private static List<Airport> airports = new List<Airport>();
        public static bool Save(Airport a)
        {
            airports.Add(a);
            return true;
        }
        /// <summary>
        /// retreives an airport with name from the parameter
        /// </summary>
        public static Airport Retreive(string airportName)
        {
            foreach (Airport airport in airports)
            {
                if (airport.AirportName.Equals(airportName))
                    return airport;
            }
            return null;
        }
        /// <summary>
        /// retreives all airports
        /// </summary>
        /// <returns></returns>
        public static List<Airport> RetreiveAllAirports()
        {
            return airports;
        }
    }
}
