using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Holds information about an Airline
    /// </summary>
    public class Airline
    {
        private string airlineName;

        public string AirlineName
        {
            get { return airlineName; }
            set 
            {
                if (value.Length <= 6)
                {
                    airlineName = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }
      
    }
}
