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
        private Dictionary<string,Airport> _airports = new Dictionary<string, Airport>();

        public void AddNewAirport(Airport airport)
        {
            if (_airports.ContainsKey(airport.Name))
                throw new Exception(ExceptionHelper.AlreadyExistentAirport);

            _airports.Add(airport.Name, airport);
        }

        /// <summary>
        /// Retreives an airport with name from the parameter.
        /// </summary>
        public Airport Retreive(string airportName)
        {
            if (String.IsNullOrEmpty(airportName))
                throw new Exception(ExceptionHelper.NullAirportName);
            if (!_airports.ContainsKey(airportName))
                throw new Exception(ExceptionHelper.NonExistentAirport);

            return _airports[airportName];
        }

        /// <summary>
        /// Retreives all airports.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,Airport> RetreiveAllAirports() => _airports;

        public string DisplayAirportsDetails()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Airport airport in _airports.Values)
                builder.Append($"{airport.ToString()}\n");

            return builder.ToString();
        }
    }
}
