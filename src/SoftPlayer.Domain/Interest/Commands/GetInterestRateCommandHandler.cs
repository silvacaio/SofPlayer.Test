using SoftPlayer.Handlers;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SoftPlayer.Domain.Core.Handler;

namespace SoftPlayer.Domain.Interest.Commands
{
    public interface IGetInterestRateCommandHandler : IHandler<GetInterestRateCommand, Event<decimal>>
    {

    }


    public class GetInterestRateCommandHandler : IGetInterestRateCommandHandler
    {
        private readonly IHttpHandler _httpClient;

        public GetInterestRateCommandHandler(IHttpHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Event<decimal>> Handler(GetInterestRateCommand command)
        {
            try
            {
                if (!command.IsValid())
                    return Event<decimal>.CreateError("Valores inválidos.");

                var responseString = await _httpClient.GetStringAsync(command.Url);

                var result = JsonSerializer.Deserialize<decimal>(responseString);

                return Event<decimal>.CreateSuccess(result);   

            }
            catch (Exception ex)
            {
                return Event<decimal>.CreateError($"Erro ao encontrar a taxa de juros: {ex.Message}");

            };
        }
    }
}
