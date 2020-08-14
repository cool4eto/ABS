using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Holds repository with airlines
    /// </summary>
    public static class AirlineRepository
    {

        private static List<Airline> airlines = new List<Airline>();
        public static bool Save(Airline airlineForSaving)
        {
            foreach (Airline airline in airlines)
            {
                if(airline.AirlineName== airlineForSaving.AirlineName)
                {
                    throw new Exception("Such airline already exists");
                }
            }
            airlines.Add(airlineForSaving);
            return true;
        }
        /// <summary>
        /// retreives and airline by airline name
        /// </summary>
        /// <param name="airlineName"></param>
        /// <returns></returns>
        public static Airline Retreive(string airlineName)
        {
            foreach (Airline airline in airlines)
            {
                if (airline.AirlineName.Equals(airlineName)) 
                    return airline;
            }
            return null;
        }
        /// <summary>
        ///Retreives all airlines
        /// </summary>
        /// <returns></returns>
        public static List<Airline> RetreiveAllAirlines()
        {
            return airlines;
        }
    }
}
