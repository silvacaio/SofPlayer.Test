using SoftPlayer.Handlers;
using SoftPlayer.Domain.Interest.Commands;

namespace SoftPlayer.Domain.Interest.Handlers
{
    public interface IGetInterestRateCommandHandler : IHandler<GetInterestRateCommand, Event<decimal>>
    {

    }
}
