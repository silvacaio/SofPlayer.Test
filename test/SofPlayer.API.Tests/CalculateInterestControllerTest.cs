using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SofPlayer.API.Controllers;
using SoftPlayer.Domain.Interest.Commands;
using SoftPlayer.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SofPlayer.API.Tests
{
    [TestClass]
    public class CalculateInterestControllerTest
    {
        Mock<ICalculateInterestRateHandler> _calculateInterestHandler;
        CalculateInterestController _controller;

        public CalculateInterestControllerTest()
        {
            _calculateInterestHandler = new Mock<ICalculateInterestRateHandler>();
            _controller = new CalculateInterestController(_calculateInterestHandler.Object);
        }

        [TestMethod]
        public async Task CalculateInterestRate_Success()
        {
            //Arrange
            string endValue = "105,10";           

            _calculateInterestHandler.Setup(s => s.Handler(It.IsAny<CalculateInterestCommand>()))
                .ReturnsAsync(Event<decimal>.CreateSuccess(105.1M));

            //Act
            var value = await _controller.CalculateInterestRate(It.IsAny<decimal>(), It.IsAny<int>());

            //Assert
            var okResult = value as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode.GetValueOrDefault());

            Assert.AreEqual((string)okResult.Value, endValue);            
        }

        [TestMethod]
        public async Task CalculateInterestRate_Error()
        {
            //Arrange                        
            string error = "error";
            _calculateInterestHandler.Setup(s => s.Handler(It.IsAny<CalculateInterestCommand>()))
                .ReturnsAsync(Event<decimal>.CreateError(error));

            //Act
            var value = await _controller.CalculateInterestRate(It.IsAny<decimal>(), It.IsAny<int>());

            //Assert
            var errorResult = value as BadRequestObjectResult;

            Assert.IsNotNull(errorResult);
            Assert.AreEqual(StatusCodes.Status400BadRequest, errorResult.StatusCode);

            Assert.AreEqual((string)errorResult.Value, error);            
        }
    }
}
