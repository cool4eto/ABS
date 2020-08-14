using System;
using ABS.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.BLTest
{
    [TestClass]
    public class FlightTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void addFlightSectionTest()
        {
            //Arrange
            Airline airline = new Airline();
            airline.AirlineName = "ABC";
            Airport origin = new Airport();
            Airport destination = new Airport();
            origin.AirportName = "HAM";
            destination.AirportName = "DAM";
            Flight flight = new Flight(airline, origin, destination, 2020, 8, 13, "123");
            FlightSection section = new FlightSection(SeatClass.business, 5, 5);
            //Act
            var actual =flight.addFlightSection(section);//ok
            flight.addFlightSection(section);//throws exception because the section is already in
            //Assert
            Assert.AreEqual(actual, true);
        }
        [TestMethod]
        public void availableSeatsTest()
        {
            //Arrange
            Airline airline = new Airline();
            airline.AirlineName = "ABC";
            Airport origin = new Airport();
            Airport destination = new Airport();
            origin.AirportName = "HAM";
            destination.AirportName = "DAM";
            Flight flight = new Flight(airline, origin, destination, 2020, 8, 13, "123");
            FlightSection section = new FlightSection(SeatClass.business, 1, 1);
            flight.addFlightSection(section);
            //Act
            var actual=flight.hasAvailableSeats();//true becuse there is one seat available
            flight.bookSeat(SeatClass.business,1,'A');//books the only avaiable seat
            var actual1 = flight.hasAvailableSeats();//
            //Assert
            Assert.AreEqual(true, actual);
            Assert.AreEqual(false, actual1);
        }
        [TestMethod]
        public void bookingTest()
        {
            //Arrange
            Airline airline = new Airline();
            airline.AirlineName = "ABC";
            Airport origin = new Airport();
            Airport destination = new Airport();
            origin.AirportName = "HAM";
            destination.AirportName = "DAM";
            Flight flight = new Flight(airline, origin, destination, 2020, 8, 13, "123");
            FlightSection section = new FlightSection(SeatClass.business, 1, 1);
            flight.addFlightSection(section);
            //Act
            var actual=flight.bookSeat(SeatClass.business, 1, 'A');
            var actual1 = flight.bookSeat(SeatClass.business, 1, 'A');//tries to book already booked seat
            var actual2 = flight.bookSeat(SeatClass.economy, 2, 'C');//tries to book non existing seat
            //Assert
            Assert.AreEqual(true, actual);
            Assert.AreEqual(false, actual1);
            Assert.AreEqual(false, actual2);
        }
    }
}
