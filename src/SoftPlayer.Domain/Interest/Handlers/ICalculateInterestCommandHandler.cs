using SoftPlayer.Domain.Interest.Commands;
using SoftPlayer.Handlers;

namespace SoftPlayer.Domain.Interest.Handlers
{
    public interface ICalculateInterestRateHandler : IHandler<CalculateInterestCommand, Event<decimal>>
    {

    }  
}
