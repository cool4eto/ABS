using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ABS.BL
{
    public class SystemManager
    {

        public void createAirport(string n)
        {
            var airport = new Airport();
            airport.AirportName = n;
            if (String.IsNullOrEmpty(airport.ValidationMessage))
            {
                AirportRepository.Save(airport);
            }
            else
            {
                Console.WriteLine(airport.ValidationMessage + "Airport: " + n);
            }
        }
        public void createAirline(string n)
        {
            var airline = new Airline();
            try
            {
                airline.AirlineName=n;
                AirlineRepository.Save(airline);

            }catch(Exception e)
            {
                Console.WriteLine(e.Message+" :"+n);//that formats the exception without the full description
            } 
        }
        public void createFlight(string aname,string orig,string dest,int year,int month,int day,string id)
        {
            Airline airline = AirlineRepository.Retreive(aname);
            Airport origin = AirportRepository.Retreive(orig);
            Airport destination = AirportRepository.Retreive(dest);
            try
            {
                Flight flight = new Flight(airline, origin, destination, year, month, day, id);
                FlightRepository.Save(flight);
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
        public void createSection(string aname,string flightId,int rows, int cols,SeatClass s)
        {
            try
            {
                Airline airline = AirlineRepository.Retreive(aname);
                Flight flight = FlightRepository.Retreive(flightId, airline);
                FlightSection section = new FlightSection(s, rows, cols);
                if (flight == null) throw new ArgumentNullException("Flight is not found in database");
                flight.addFlightSection(section);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void displaySystemDetails()
        {
            Console.WriteLine("List of all airports: ");
            foreach (Airport airport in AirportRepository.RetreiveAllAirports())
            {
                Console.WriteLine(airport.AirportName);
            }
            Console.WriteLine("List of all airlines:");
            foreach (Airline airline in AirlineRepository.RetreiveAllAirlines())
            {
                Console.WriteLine(airline.AirlineName);
                List<Flight> flights = FlightRepository.Retreive(airline);
                foreach (Flight flight in flights)
                {
                    Console.WriteLine(flight.ToString());
                }
            }
        }
        public void findAvailableFlights(string orig,string dest)
        {
            try
            {
                Airport origin = AirportRepository.Retreive(orig);
                Airport destination = AirportRepository.Retreive(dest);
                if (origin == null || destination == null) throw new ArgumentNullException();
                Console.WriteLine($"All available flights from: {orig} to: {dest} are: \n\n");
                foreach (Flight flight in FlightRepository.Retreive())
                {
                    if(flight.Origin.Equals(origin)&&flight.Destination.Equals(destination)&&flight.hasAvailableSeats())
                        Console.WriteLine(flight);//Im not sure if i have to print it or send it as list
                }
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void bookSeat(string aname, string flightId, SeatClass s, int row, char col)
        {
            try
            {
                Airline airline = AirlineRepository.Retreive(aname);
                Flight flight = FlightRepository.Retreive(flightId, airline);
                if (airline == null || flight == null) throw new ArgumentNullException();
                if (!flight.bookSeat(s, row, col)) throw new Exception("couldn't book");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
