using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftPlayer.Domain.Interest;

namespace SoftPlayer.Domain.Tests.Interest
{
    [TestClass]
    public class InterestRateTest
    {
        InterestRate _interest;

        [TestMethod]
        public void InterestRate_Success()
        {
            //Arrange         
            _interest = InterestRate.InterestRateFactory.Create(100, 5);

            //Act
            var result = _interest.Calculate();

            //Assert            
            Assert.AreEqual(result, 105.1M);
        }


        [TestMethod]
        public void InterestRate_ValueZero_Invalid()
        {
            //Arrange
            _interest = InterestRate.InterestRateFactory.Create(0, 5);
            //Act
            var valid = _interest.IsValid();

            //Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void Calc_TimeZero_Invalid()
        {
            //Arrange
            _interest = InterestRate.InterestRateFactory.Create(100, 0);
            //Act
            var valid = _interest.IsValid();

            //Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void Calc_IsValid()
        {
            //Arrange
            _interest = InterestRate.InterestRateFactory.Create(100, 5);
            //Act
            var valid = _interest.IsValid();

            //Assert
            Assert.IsTrue(valid);
        }
    }
}
