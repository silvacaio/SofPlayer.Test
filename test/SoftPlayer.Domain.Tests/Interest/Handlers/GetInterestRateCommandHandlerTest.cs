using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SoftPlayer.Application.Handlers;
using SoftPlayer.Application.Handlers.Interest;
using SoftPlayer.Domain.Core.Handler;
using SoftPlayer.Domain.Interest.Commands;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftPlayer.Application.Tests.Interest.Handlers
{
    [TestClass()]
    public class GetInterestRateCommandHandlerTest
    {
        private readonly Mock<IHttpHandler> _httpClient;
        private readonly GetInterestRateCommandHandler _handler;

        public GetInterestRateCommandHandlerTest()
        {
            _httpClient = new Mock<IHttpHandler>();
            _handler = new GetInterestRateCommandHandler(_httpClient.Object);
        }

        [TestMethod]
        public async Task Get_UrlInvalid_Error()
        {
            //Arrange

            //Act
            var result = await _handler.Handler(GetInterestRateCommand.GetInterestRateCommandFactory.Create(""));

            //Assert
            Assert.IsFalse(result.Valid);
        }

        [TestMethod]
        public async Task Get_Success()
        {
            //Arrange            
            var command = GetInterestRateCommand.GetInterestRateCommandFactory.Create("url");
            _httpClient.Setup(a => a.GetStringAsync(command.Url)).ReturnsAsync("0.01");

            //Act
            var result = await _handler.Handler(command);

            //Assert
            Assert.IsTrue(result.Valid);
            Assert.AreEqual(result.Value, 0.01M);
        }
    }
}
