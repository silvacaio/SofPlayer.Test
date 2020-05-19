using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofPlayer.API.Controllers;
using SoftPlayer.Domain.Interest;

namespace SofPlayer.API.Tests
{
    [TestClass]
    public class InterestControllerTest
    {
        InterestController _controller;

        public InterestControllerTest()
        {
            _controller = new InterestController();
        }

        [TestMethod]
        public void InterestRate_Success()
        {
            //Arrange

            //Act
            var value = _controller.GetInterestRate();

            //Assert
            Assert.AreEqual(value, InterestRate._valueInterest);
        }
    }
}
