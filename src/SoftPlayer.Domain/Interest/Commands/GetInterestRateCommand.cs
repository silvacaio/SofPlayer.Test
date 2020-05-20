using SoftPlayer.Handlers;

namespace SoftPlayer.Domain.Interest.Commands
{
    public sealed class GetInterestRateCommand : Command
    {
        private GetInterestRateCommand(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Url);
        }

        public static class GetInterestRateCommandFactory
        {
            public static GetInterestRateCommand Create(string urlInterestRate)
            {
                return new GetInterestRateCommand(urlInterestRate);
            }
        }
    }
}
