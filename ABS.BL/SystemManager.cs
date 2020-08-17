using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ABS.BL
{
    public class SystemManager
    {
        public SystemManager()
        {
            _airlineRepository = new AirlineRepository();
            _airportRepository = new AirportRepository();
            _flightRepository = new FlightRepository();
        }
        private AirlineRepository _airlineRepository;
        private  AirportRepository _airportRepository;
        private FlightRepository _flightRepository;
        public void CreateAirport(string n)
        {
            var airport = new Airport(n);
            if (String.IsNullOrEmpty(airport.ValidationMessage))
            {
                _airportRepository.AddNewAirport(airport);
            }
            else
            {
                Console.WriteLine(airport.ValidationMessage + "Airport: " + n);
            }
        }
        public void CreateAirline(string n)
        {
            var airline = new Airline();
            try
            {
                airline.AirlineName=n;
                _airlineRepository.AddNewAirline(airline);

            }catch(Exception e)
            {
                // That formats the exception without the full description.
                Console.WriteLine(e.Message+" :"+n);
            } 
        }
        public void CreateFlight(string aName,string orig,string dest,int year,int month,int day,string id)
        {
            Airline airline = _airlineRepository.Retreive(aName);
            Airport origin = _airportRepository.Retreive(orig);
            Airport destination = _airportRepository.Retreive(dest);
            try
            {
                Flight flight = new Flight(airline, origin, destination, year, month, day, id);
                _flightRepository.AddNewFlight(flight);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+" "+id+" "+airline.AirlineName);
            }
        }
        public void CreateSection(string aName,string flightId,int rows, int cols,SeatClass s)
        {
            try
            {
                Airline airline = _airlineRepository.Retreive(aName);
                Flight flight = _flightRepository.Retreive(flightId, airline);
                FlightSection section = new FlightSection(s, rows, cols);
                if (flight == null) throw new ArgumentNullException("Flight is not found in database");
                flight.AddFlightSection(section);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplaySystemDetails()
        {
            Console.WriteLine("List of all airports: ");
            Console.WriteLine(_airportRepository.DisplayAirportsDetails());
            // I like this one more, because it shows the airline and the flights assigned with it.
            Console.WriteLine("List of all airlines:");
            foreach (Airline airline in _airlineRepository.RetreiveAllAirlines())
            {
                Console.WriteLine(airline.AirlineName);
                Console.WriteLine(_flightRepository.DisplayFlightDetailsForAirline(airline));
            }

        }
        public void FindAvailableFlights(string orig,string dest)
        {
            try
            {
                Airport origin = _airportRepository.Retreive(orig);
                Airport destination = _airportRepository.Retreive(dest);
                if (origin == null || destination == null) throw new ArgumentNullException();
                Console.WriteLine($"All available flights from: {orig} to: {dest} are: \n\n");
                foreach (Flight flight in _flightRepository.Retreive())
                {
                    if(flight.Origin.Equals(origin)&&flight.Destination.Equals(destination)&&flight.hasAvailableSeats())
                        // Im not sure if i have to print it or send it as list.
                        Console.WriteLine(flight);
                }
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void BookSeat(string aName, string flightId, SeatClass s, int row, char col)
        {
            try
            {
                Airline airline = _airlineRepository.Retreive(aName);
                Flight flight = _flightRepository.Retreive(flightId, airline);
                if (airline == null || flight == null) throw new ArgumentNullException();
                if (!flight.BookSeat(s, row, col)) throw new Exception("couldn't book");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
