using System;

namespace ABS.BL
{
    /// <summary>
    /// Holds information about airport.
    /// </summary>
    public class Airport
    {
        public Airport()
        {

        }
        public Airport(string airportName)
        {
            AirportName = airportName;
        }
        private string _airportName;

        public string AirportName
        {
            get { return _airportName; }
            set 
            {
                if (value.Length == 3)
                {
                    _airportName = value;
                }
                else
                {
                    ValidationMessage = "Airport Name must be 3 characters long";
                }
            }
        }

        public string ValidationMessage { get; private set; }

        public override string ToString()
        {
            return AirportName;
        }
        
        // Theese overrides are for the HashSet.
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Airport airport = (Airport)obj;
                return this.AirportName == airport.AirportName;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            if (AirportName != null)
                return AirportName.GetHashCode();
            else return 0;
        }
    }
    
}
