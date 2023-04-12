using System;
using System.Linq;

namespace NDDD.Domain.Helpers
{
    public static class FloatHelper
    {
        public static string RoundString(
            this float value,
            int decimalPoint)
        {
            value = Convert.ToSingle(Math.Round(value, decimalPoint));
            return value.ToString(decimalPoint == 0 ?
                string.Empty : "." +
                string.Concat(Enumerable.Repeat("0", decimalPoint)));
        }
    }
}
