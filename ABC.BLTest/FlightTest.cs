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
            Airline airline = new Airline("ABC");
            Airport origin = new Airport("HAM");
            Airport destination = new Airport("DAM");
            Flight flight = new Flight(airline, origin, destination, 2020, 8, 13, "123");
            FlightSection section = new FlightSection(SeatClass.Business, 5, 5);
            //Act
            var actual =flight.AddFlightSection(section);//ok
            flight.AddFlightSection(section);//throws exception because the section is already in
            //Assert
            Assert.AreEqual(actual, true);
        }
        [TestMethod]
        public void availableSeatsTest()
        {
            //Arrange
            Airline airline = new Airline("ABC");
            Airport origin = new Airport("HAM");
            Airport destination = new Airport("DAM");
            Flight flight = new Flight(airline, origin, destination, 2020, 8, 13, "123");
            FlightSection section = new FlightSection(SeatClass.Business, 1, 1);
            flight.AddFlightSection(section);
            //Act
            var actual=flight.hasAvailableSeats();//true becuse there is one seat available
            flight.BookSeat(SeatClass.Business,1,'A');//books the only avaiable seat
            var actual1 = flight.hasAvailableSeats();//
            //Assert
            Assert.AreEqual(true, actual);
            Assert.AreEqual(false, actual1);
        }
        [TestMethod]
        public void bookingTest()
        {
            //Arrange
            Airline airline = new Airline("ABC");
            Airport origin = new Airport("HAM");
            Airport destination = new Airport("DAM");
            Flight flight = new Flight(airline, origin, destination, 2020, 8, 13, "123");
            FlightSection section = new FlightSection(SeatClass.Business, 1, 1);
            flight.AddFlightSection(section);
            //Act
            var actual=flight.BookSeat(SeatClass.Business, 1, 'A');
            var actual1 = flight.BookSeat(SeatClass.Business, 1, 'A');//tries to book already booked seat
            var actual2 = flight.BookSeat(SeatClass.Economy, 2, 'C');//tries to book non existing seat
            //Assert
            Assert.AreEqual(true, actual);
            Assert.AreEqual(false, actual1);
            Assert.AreEqual(false, actual2);
        }
    }
}
