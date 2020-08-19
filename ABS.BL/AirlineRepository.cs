using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Holds repository with airlines.
    /// </summary>
    public class AirlineRepository
    {
        private Dictionary<string,Airline> _airlines = new Dictionary<string, Airline>();
        
        public void AddNewAirline(Airline airline)
        {
            if (_airlines.ContainsKey(airline.Name))
                throw new Exception(ExceptionHelper.AlreadyExistentAirline);

            _airlines.Add(airline.Name,airline);
        } 

        /// <summary>
        /// Рetreives and airline by airline name.
        /// </summary>
        /// <param name="airlineName"></param>
        /// <returns></returns>
        public  Airline Retreive(string airlineName)
        {
            if (String.IsNullOrEmpty(airlineName)) 
                throw new Exception(ExceptionHelper.NullAirlineName);

            if (!_airlines.Keys.Contains(airlineName))
                throw new Exception(ExceptionHelper.NonExistentAirline);

            return _airlines[airlineName];
        }

        /// <summary>
        /// Retreives all airlines
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,Airline> RetreiveAllAirlines() => _airlines;
 
        public string DisplayAirlinesDetails()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Airline airline in _airlines.Values)
                builder.Append($"{airline.ToString()}\n");
           
            return builder.ToString();
        }
    }
}
