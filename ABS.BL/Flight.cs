using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    /// <summary>
    /// Contains flight information.
    /// </summary>
    public class Flight
    {
        public string FlightId { get; set; }
        public Airport Origin { get; set; }
        public Airport Destination { get; set; }
        public Airline Airline { get; set; }
        public DateTime FlightDate { get; set; }

        public List<FlightSection> sections = new List<FlightSection>();

        public Flight(Airline airline, Airport originAirport, Airport destinationAirport, int year, int month, int day, string id)
        {
            if (airline == null) 
                throw new Exception(ExceptionHelper.NonExistentAirline);
            if(originAirport == null)
                throw new Exception(ExceptionHelper.NonExistentAirport);
            if(destinationAirport == null)
                throw new Exception(ExceptionHelper.NonExistentAirport);
            this.FlightId = id;
            this.Airline = airline;
            this.Origin = originAirport;
            this.Destination = destinationAirport;
            this.FlightDate = new DateTime(year, month, day);
        }

        public bool AddFlightSection(FlightSection sectionToAdd)
        {
            foreach (FlightSection section in sections)
            {
                if (sectionToAdd.SeatClass.Equals(section.SeatClass))
                    throw new Exception(ExceptionHelper.ExistingSection);
            }
            sections.Add(sectionToAdd);
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Flight ID: {FlightId} ");
            builder.Append($"Origin: {Origin.Name} ");
            builder.Append($"Destination:  {Destination.Name} ");
            builder.Append($"Airline:  {Airline.Name} ");
            builder.Append($"Date: {FlightDate.Day}.{FlightDate.Month}.{FlightDate.Year} ");
            builder.Append("Seats: \n");
            foreach (FlightSection section in sections)
                builder.Append($"{section.ToString()}\n");

            return builder.ToString();
        }

        /// <summary>
        /// Check if flight have available seats.
        /// </summary>
        /// <returns></returns>
        public bool hasAvailableSeats()
        {
            foreach (FlightSection section in sections)
                if (section.HasAvailableSeats()) return true;

            return false;
        }

        /// <summary>
        /// Books available seat.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool BookSeat(SeatClass s, int row, char col)
        {
            bool booked = false;
            foreach (FlightSection section in sections)
            {
                if(section.SeatClass.Equals(s))
                {
                    booked = section.BookSeat(row, col);
                }
            }

            return booked;
        }
    }
}
