using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Contains flight information
    /// </summary>
    public class Flight
    {
        public string FlightId { get; set; }
        public Airport Origin { get; set; }
        public Airport Destination { get; set; }
        public Airline Airline { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public List<FlightSection> sections;
        public Flight()
        {
            sections = new List<FlightSection>();
        }
        public Flight(Airline airline,Airport originAirport,Airport destinationAirport,int year, int month, int day,string id):this()
        {
            if (airline == null) 
                throw new ArgumentNullException(nameof(airline));
            if(originAirport == null)
                throw new ArgumentNullException(nameof(originAirport));
            if(destinationAirport == null)
                throw new ArgumentNullException(nameof(destinationAirport));
            this.FlightId = id;
            this.Airline = airline;
            this.Origin = originAirport;
            this.Destination = destinationAirport;
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
        public bool addFlightSection(FlightSection sectionToAdd)
        {
            foreach (FlightSection section in sections)
            {
                if (sectionToAdd.SeatClass.Equals(section.SeatClass))
                    throw new Exception("Such seatclass is already asociated with this flight");
            }
            sections.Add(sectionToAdd);
            return true;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Flight ID: {FlightId} ");
            builder.Append($"Origin: {Origin.AirportName} ");
            builder.Append($"Destination:  {Destination.AirportName} ");
            builder.Append($"Airline:  {Airline.AirlineName} ");
            builder.Append($"Date: {Day}.{Month}.{Year} ");
            builder.Append("Seats: \n");
            foreach (FlightSection section in sections)
            {
                builder.Append(section.ToString());
                builder.Append("\n");
            }
            return builder.ToString();
        }
        /// <summary>
        /// check if flight have available seats
        /// </summary>
        /// <returns></returns>
        public bool hasAvailableSeats()
        {
            foreach (FlightSection section in sections)
            {
                if (section.hasAvailableSeats()) return true;
            }
            return false;
        }
        /// <summary>
        /// books available seat
        /// </summary>
        /// <param name="s"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool bookSeat(SeatClass s,int row,char col)
        {
            bool booked = false;
            foreach (FlightSection section in sections)
            {
                if(section.SeatClass.Equals(s))
                {
                    booked = section.bookSeat(row, col);
                }
            }
            return booked;
        }
    }
}
