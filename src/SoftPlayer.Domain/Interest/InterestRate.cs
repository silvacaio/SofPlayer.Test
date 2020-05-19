using System;

namespace SoftPlayer.Domain.Interest
{
    public class InterestRate
    {
        private InterestRate()
        {

        }

        public decimal Value { get; private set; }
        public int Time { get; private set; }

        public static readonly decimal _valueInterest = 0.01M;

        public decimal Calculate()
        {
            
            var interest = (decimal)Math.Pow((double)(1 + _valueInterest), Time);
            var result = Value * interest;
            result = Math.Truncate(result * 100) / 100; //trunc

            return result;
        }

        public bool IsValid() => Value > 0 && Time > 0;

        public static class InterestRateFactory
        {
            public static InterestRate Create(decimal value, int time)
            {
                return new InterestRate
                {
                    Value = value,
                    Time = time
                };
            }
        }

    }
}
