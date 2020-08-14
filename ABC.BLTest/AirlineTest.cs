using System;
using ABS.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.BLTest
{
    [TestClass]
    public class AirlineTest
    {
        [TestMethod]
        public void airlineValidName()
        {
            //Arrange
            Airline airline = new Airline();
            airline.AirlineName="ABC";
            //Act

            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void airlineInValidName()
        {
            //Arrange
            Airline airline = new Airline();
            airline.AirlineName = "ABCDEFG";
            //Act

            //Assert
        }
    }
}
