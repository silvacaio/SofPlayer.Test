using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPlayer.Domain.Interest.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlayer.Domain.Test.Interest.Commands
{
    [TestClass()]
    public class CalculateInterestCommandTest
    {
        CalculateInterestCommand _command;

        [TestMethod]
        public void CalculateInterestCommand_WithoutValue_Invalid()
        {
            //Arrange
            _command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(0, 5, "url");

            //Act
            var isValid = _command.IsValid();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CalculateInterestCommand_WithoutTime_Invalid()
        {
            //Arrange
            _command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(100, 0, "url");

            //Act
            var isValid = _command.IsValid();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CalculateInterestCommand_WithoutUrl_Invalid()
        {
            //Arrange
            _command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(100, 5, null);

            //Act
            var isValid = _command.IsValid();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CalculateInterestCommand_WithoutUrl_Valid()
        {
            //Arrange
            _command = CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(100, 5, "url");

            //Act
            var isValid = _command.IsValid();

            //Assert
            Assert.IsTrue(isValid);
        }
    }
}
