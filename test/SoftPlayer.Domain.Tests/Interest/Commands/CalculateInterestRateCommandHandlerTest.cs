using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPlayer.Domain.Interest.Commands;

namespace SoftPlayer.Domain.Tests.Interest.Commands
{
    [TestClass()]
    public class CalculateInterestRateCommandHandlerTest
    {
        readonly CalculateInterestRateCommandHandler handler;
        public CalculateInterestRateCommandHandlerTest()
        {
            handler = new CalculateInterestRateCommandHandler();
        }

        [TestMethod()]
        public void Calculate_ReturnCorrectValue()
        {
            //Arrange
            var command = new CalculateInterestRateCommand(100, 5);          

            //Act
            var result = handler.Handler(command);

            //Assert
            Assert.IsTrue(result.Valid);
            Assert.AreEqual(result.Value, 105.1M);
        }

        [TestMethod()]
        public void Calculate_InitialValueInvalid()
        {
            //Arrange
            var command = new CalculateInterestRateCommand(0, 5);

            //Act
            var result = handler.Handler(command);

            //Assert
            Assert.IsFalse(result.Valid);
            Assert.IsNotNull(result.Error);
        }

        [TestMethod()]
        public void Calculate_TimeInvalid()
        {
            //Arrange
            var command = new CalculateInterestRateCommand(100, 0);

            //Act
            var result = handler.Handler(command);

            //Assert
            Assert.IsFalse(result.Valid);
            Assert.IsNotNull(result.Error);
        }
    }
}

