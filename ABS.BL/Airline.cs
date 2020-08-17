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
        public Airline()
        {

        }
        public Airline(string aName)
        {
            AirlineName = aName;
        }

        private string _airlineName;

        public string AirlineName
        {
            get { return _airlineName; }
            set 
            {
                if (value.Length <= 6)
                {
                    _airlineName = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        // Тheese overrides are for the HashSet.
        public override bool Equals(object obj)
        {
            if (obj != null)
            { 
                Airline airline = (Airline)obj;
                return this.AirlineName == airline.AirlineName;
            }
            return false;
        }
        public override int GetHashCode()
        {
            if (AirlineName != null)
                return AirlineName.GetHashCode();
            else return 0;
        }
        public override string ToString()
        {
            return AirlineName;
        }
    }
}
