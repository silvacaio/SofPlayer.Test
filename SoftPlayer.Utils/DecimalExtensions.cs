using System;

namespace SoftPlayer.Utils
{
    public static class DecimalExtensions
    {
        public static decimal Truncate(this decimal valor)
        {
            return Convert.ToDecimal(valor.ToString("0.00"));
        }
    }
}
