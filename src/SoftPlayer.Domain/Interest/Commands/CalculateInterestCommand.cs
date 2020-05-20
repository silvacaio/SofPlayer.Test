using SoftPlayer.Handlers;

namespace SoftPlayer.Domain.Interest.Commands
{
    public sealed class CalculateInterestCommand : Command
    {
        private CalculateInterestCommand(decimal value, int time, string urlInterestRate)
        {
            Value = value;
            Time = time;
            UrlInterestRate = urlInterestRate;
        }

        private CalculateInterestCommand() { }
        public decimal Value { get; set; }
        public int Time { get; set; }
        public string UrlInterestRate { get; set; }

        public override bool IsValid()
        {
            return Value > 0 && Time > 0 && !string.IsNullOrWhiteSpace(UrlInterestRate);
        }

        public static class CalculateInterestRateCommandFactory
        {
            public static CalculateInterestCommand Create(decimal value, int time, string urlInterestRate)
            {
                return new CalculateInterestCommand(value, time, urlInterestRate);
            }
        }
    }
}
