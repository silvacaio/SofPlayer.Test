using SoftPlayer.Handlers;

namespace SoftPlayer.Domain.Interest.Commands
{
    public sealed class CalculateInterestRateCommand : Command
    {
        public CalculateInterestRateCommand() { }
        public CalculateInterestRateCommand(decimal value, int time)
        {
            Value = value;
            Time = time;
        }

        public decimal Value { get; set; }
        public int Time { get; set; }
    }
}
