using System;
using ABS.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.BLTest
{
    [TestClass]
    public class FlightSectionTest
    { 
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void invalidConstructorInput()
        {
        //Arrange
        FlightSection flightSection = new FlightSection(SeatClass.First, 100, 100);
            //Act

            //Assert

        }
        [TestMethod]
        public void validConstructorHighInput()
        {
            //Arrange
            FlightSection flightSection = new FlightSection(SeatClass.First, 100, 10);
            //Act

            //Assert
        }
        [TestMethod]
        public void validConstructorLowInput()
        {
            //Arrange
            FlightSection flightSection = new FlightSection(SeatClass.First);
            //Act

            //Assert
        }
        [TestMethod]
        public void findAvailableSeat()
        {
            //Arrange
            FlightSection flightSection = new FlightSection(SeatClass.First, 1, 1);
            //Act
            bool actual=flightSection.HasAvailableSeats();
            //Assert
            Assert.AreEqual(true, actual);
        }
        [TestMethod]
        public void bookAvailableSeat()
        {
            //Arrange
            FlightSection flightSection = new FlightSection(SeatClass.First, 1, 1);
            //Act
            bool actual = flightSection.BookSeat();//books the only available seat
            bool actual1 = flightSection.BookSeat();//tries to book non available seat
            //Assert
            Assert.AreEqual(true, actual);
            Assert.AreEqual(false, actual1);
        }
    }
}
