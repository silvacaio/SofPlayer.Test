using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPlayer.Domain.Interest.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlayer.Domain.Test.Interest.Commands
{
    [TestClass()]
    public class GetInterestRateCommandTest
    {
        GetInterestRateCommand _command;

        [TestMethod]
        public void GetInterestRateCommand_WithoutUrl_Invalid()
        {
            //Arrange
            _command = GetInterestRateCommand.GetInterestRateCommandFactory.Create(null);

            //Act
            var isValid = _command.IsValid();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void GetInterestRateCommand_WithoutUrl_Valid()
        {
            //Arrange
            _command = GetInterestRateCommand.GetInterestRateCommandFactory.Create("url");

            //Act
            var isValid = _command.IsValid();

            //Assert
            Assert.IsTrue(isValid);
        }
    }
}
