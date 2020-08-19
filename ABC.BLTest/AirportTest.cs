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
            var actual = airline.Name;
            var expected = "ABC";
            //Act

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AirlineName_TooLong()
        {
            //Arrange
            var airline = new Airport("ABCD");
            var actual = airline.Name;

            //Act

            //Assert
            Assert.AreEqual(null, actual);
        }
    }
}
