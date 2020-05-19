using SoftPlayer.Handlers;

namespace SoftPlayer.Domain.Interest.Commands
{

    public interface ICalculateInterestRateHandler : IHandler<CalculateInterestRateCommand, Event<decimal>>
    {

    }
    public class CalculateInterestRateCommandHandler : ICalculateInterestRateHandler
    {
        public Event<decimal> Handler(CalculateInterestRateCommand command)
        {
            var calc = InterestRate.InterestRateFactory.Create(command.Value, command.Time);
            if (!calc.IsValid())
                return Event<decimal>.CreateError("Valores inválidos.");

            return Event<decimal>.CreateSuccess(calc.Calculate());
        }
    }
}
