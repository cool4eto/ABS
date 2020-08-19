using System;
using System.Text.RegularExpressions;

namespace ABS.BL
{
    /// <summary>
    /// Holds information about airport.
    /// </summary>
    public class Airport
    {
        private string _name;

        public Airport(string airportName)
        {
            Name = airportName;
        }
        
        public string Name
        {
            get { return _name; }
            set
            {
                // Matches the passed string against regex to ensure that it is exactly three upper case letters.
                if (value.Length != 3 || !Regex.IsMatch(value, @"[A-Z]{3}"))
                    throw new Exception(ExceptionHelper.InvalidAirportName);

                _name = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
    
}
