using System;

namespace NetPresentValue.Service.CalcUtilty
{
    public static class CalculationHelper
    {
        public static decimal Pow(decimal x, int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n");
            }

            decimal result = 1;
            decimal multiplier = x;

            while (n > 0)
            {
                if ((n & 1) > 0) result *= multiplier;
                multiplier *= multiplier;
                n >>= 1;
            }

            return result;
        }
    }
}
