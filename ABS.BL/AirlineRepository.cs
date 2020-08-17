using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Holds repository with airlines.
    /// </summary>
    public class AirlineRepository
    {
        private HashSet<Airline> _airlines = new HashSet<Airline>();
        public  bool AddNewAirline(Airline airlineForSaving)
        {
            _airlines.Add(airlineForSaving);
            return true;
        } 

        /// <summary>
        /// Рetreives and airline by airline name.
        /// </summary>
        /// <param name="airlineName"></param>
        /// <returns></returns>
        public  Airline Retreive(string airlineName)
        {
            foreach (Airline airline in _airlines)
            {
                if (airline.AirlineName.Equals(airlineName)) 
                    return airline;
            }
            return null;
        }
        /// <summary>
        /// Retreives all airlines
        /// </summary>
        /// <returns></returns>
        public HashSet<Airline> RetreiveAllAirlines()
        {
            return _airlines;
        }
        public string DisplayAirlinesDetails()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Airline airline in _airlines)
            {
                builder.Append(airline.ToString());
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
