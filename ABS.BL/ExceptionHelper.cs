using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{
    public static class ExceptionHelper
    {
        public const string InvalidAirlineName = "Airline name must be less than 6 characters!";
        public const string NullAirlineName = "Airline name can't be null or empty!";
        public const string NonExistentAirline = "Airline does not exist!";
        public const string AlreadyExistentAirline = "Airline already exists!";
        public const string InvalidAirportName = "Airport name must be exactly 3 Characters!";
        public const string NullAirportName = "Airport name can't be null or empty!";
        public const string NonExistentAirport = "Airport does not exist!";
        public const string NonExistentFlight = "Flight does not exist!";
        public const string AlreadyExistentAirport = "Airport already exists!";
        public const string FlightSectionTooBig = "Flight section can have at most 100 rows and 10 columns!";
        public const string ColumnOutOfBound = "Column value must be uppercase letter in the range A-J!";
        public const string RowOutOfBouund = "Row value must be number in the range 0-100!";
        public const string FlightNotFound = "Flight with this id cannot be found!";
        public const string ExistingSection = "Such seatclass is already asociated with this flight!";
        public const string SeatAlreadyBooked = "Seat you want to book is already booked!";
    }
}
