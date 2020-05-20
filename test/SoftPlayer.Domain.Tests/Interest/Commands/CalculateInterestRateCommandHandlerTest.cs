using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SoftPlayer.Domain.Interest.Commands;
using SoftPlayer.Handlers;
using System.Threading.Tasks;

namespace SoftPlayer.Domain.Tests.Interest.Commands
{
    [TestClass()]
    public class CalculateInterestRateCommandHandlerTest
    {
        private readonly CalculateInterestCommandHandler handler;
        private readonly Mock<IGetInterestRateCommandHandler> _getInterestRateCommandHandler;
        public CalculateInterestRateCommandHandlerTest()
        {
            _getInterestRateCommandHandler = new Mock<IGetInterestRateCommandHandler>();

            _getInterestRateCommandHandler.Setup(a => a.Handler(It.IsAny<GetInterestRateCommand>()))
              .ReturnsAsync(Event<decimal>.CreateSuccess(0.01M));

            handler = new CalculateInterestCommandHandler(_getInterestRateCommandHandler.Object);
        }

        [TestMethod()]
        public async Task Calculate_ReturnCorrectValue_Success()
        {
            //Arrange
            var command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(100, 5, "url");

            //Act
            var result = await handler.Handler(command);

            //Assert
            Assert.IsTrue(result.Valid);
            Assert.AreEqual(result.Value, 105.1M);
        }

        [TestMethod()]
        public async Task Calculate_InitialValueInvalid_Error()
        {
            //Arrange
            var command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(0, 5, "url");

            //Act
            var result = await handler.Handler(command);

            //Assert
            Assert.IsFalse(result.Valid);
            Assert.IsNotNull(result.Error);
        }

        [TestMethod()]
        public async Task Calculate_TimeInvalid_Error()
        {
            //Arrange
            var command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(100, 0, "url");

            //Act
            var result = await handler.Handler(command);

            //Assert
            Assert.IsFalse(result.Valid);
            Assert.IsNotNull(result.Error);
        }

        [TestMethod()]
        public async Task Calculate_UrlInvalid_Error()
        {
            //Arrange
            var command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(100, 5, "");

            //Act
            var result = await handler.Handler(command);

            //Assert
            Assert.IsFalse(result.Valid);
            Assert.IsNotNull(result.Error);
        }
    }
}

