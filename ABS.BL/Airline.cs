using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Holds information about an Airline.
    /// </summary>
    public class Airline
    {
        private string _name = String.Empty;
        private FlightRepository _flightRepository = new FlightRepository();

        public Airline(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return _name; }
            set 
            {
                if (value.Length > 6)
                    throw new Exception(ExceptionHelper.InvalidAirlineName);

                _name = value;
            }
        }
        public FlightRepository Flights { get => _flightRepository; set => _flightRepository = value; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name}\n");
            builder.Append(Flights.DisplayFlightsDetails());

            return builder.ToString();
        }
    }
}
