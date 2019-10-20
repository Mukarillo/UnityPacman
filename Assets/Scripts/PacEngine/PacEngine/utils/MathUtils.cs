using System;
namespace PacEngine.utils
{
    public class MathUtils
    {
        public static int Clamp(int n, int min, int max)
        {
            if (n < min)
                return min;
            if (n > max)
                return max;

            return n;
        }
    }
}
