using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ABS.BL
{
    public class SystemManager
    {
        private AirlineRepository _airlineRepository = new AirlineRepository();
        private AirportRepository _airportRepository = new AirportRepository();
       
        public void CreateAirport(string name)
        {
            try
            {
                var airport = new Airport(name);
                _airportRepository.AddNewAirport(airport);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message} Airport name: {name}");
            }
        }

        public void CreateAirline(string name)
        {
            try
            {
                var airline = new Airline(name);
                _airlineRepository.AddNewAirline(airline);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message} Airline name: {name}");
            } 
        }

        public void CreateFlight(string aName, string orig, string dest, int year, int month, int day, string id)
        {
            Airline airline = _airlineRepository.Retreive(aName);
            Airport origin = _airportRepository.Retreive(orig);
            Airport destination = _airportRepository.Retreive(dest);
            try
            {
                Flight flight = new Flight(airline, origin, destination, year, month, day, id);
                airline.Flights.AddNewFlight(flight);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}- {airline.Name}");
            }
        }

        public void CreateSection(string aName, string flightId, int rows, int cols, SeatClass s)
        {
            try
            {
                Airline airline = _airlineRepository.Retreive(aName);
                Flight flight = airline.Flights.Retreive(flightId);
                FlightSection section = new FlightSection(s, rows, cols);
                if (airline == null)
                    throw new Exception(ExceptionHelper.NonExistentAirline);
                if (flight == null) 
                    throw new Exception(ExceptionHelper.FlightNotFound);
                flight.AddFlightSection(section);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {aName}");
            }
        }

        public void DisplaySystemDetails()
        {
            Console.WriteLine("List of all airports: ");
            Console.WriteLine(_airportRepository.DisplayAirportsDetails());
            Console.WriteLine("List of all airlines:");
            Console.WriteLine(_airlineRepository.DisplayAirlinesDetails());
        }

        public void FindAvailableFlights(string orig, string dest)
        {
            try
            {
                Airport origin = _airportRepository.Retreive(orig);
                Airport destination = _airportRepository.Retreive(dest);
                if (origin == null || destination == null) 
                    throw new Exception(ExceptionHelper.NonExistentAirport);
                Console.WriteLine($"All available flights from: {orig} to: {dest} are: \n\n");
                foreach (Airline airline in _airlineRepository.RetreiveAllAirlines().Values)
                {
                    foreach (Flight flight in airline.Flights.Retreive().Values)
                    {
                        if (flight.Origin.Equals(origin) && flight.Destination.Equals(destination) && flight.hasAvailableSeats())
                            // I'm not sure if i have to print it or send it as list.
                            Console.WriteLine(flight);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void BookSeat(string aName, string flightId, SeatClass s, int row, char col)
        {
            try
            {
                Airline airline = _airlineRepository.Retreive(aName);
                Flight flight = airline.Flights.Retreive(flightId);
                if (airline == null) 
                    throw new Exception(ExceptionHelper.NonExistentAirline);
                if (flight == null) 
                    throw new Exception(ExceptionHelper.NonExistentFlight);
                if (!flight.BookSeat(s, row, col)) 
                    throw new Exception(ExceptionHelper.SeatAlreadyBooked);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}- Airline: {aName} : {flightId} Seat: {row} {col}");
            }
        }
    }
}
