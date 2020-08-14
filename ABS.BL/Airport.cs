using System;

namespace ABS.BL
{
    /// <summary>
    /// holds information about airport
    /// </summary>
    public class Airport
    {
        private string airportName;

        public string AirportName
        {
            get { return airportName; }
            set 
            {
                if (value.Length == 3)
                {
                    airportName = value;
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
    }
}
