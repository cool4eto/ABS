using System;
using ABS.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.BLTest
{
    [TestClass]
    public class AirportTest
    {
        [TestMethod]
        public void AirlineName_Valid()
        {
            //Arrange
            var airline = new Airport("ABC");
            var actual = airline.AirportName;
            var expected = "ABC";
            //Act

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(null, airline.ValidationMessage);
        }
        [TestMethod]
        public void AirlineName_TooLong()
        {
            //Arrange
            var airline = new Airport("ABCD");
            var actual = airline.AirportName;

            //Act

            //Assert
            Assert.AreEqual(null, actual);
            Assert.AreEqual("Airport Name must be 3 characters long", airline.ValidationMessage);
        }
    }
}
