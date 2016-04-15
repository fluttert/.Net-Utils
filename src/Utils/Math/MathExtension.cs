using System;
using System.Numerics;

namespace Fluttert.Utils.Math
{
    public class MathExtension
    {
        /// <summary>
        /// Returns a Factorial, like 10! = Factorial(10)
        /// </summary>
        /// <param name="number">Number to be factorialized (long/int64)</param>
        /// <returns>BigInteger</returns>
        /// <exception cref="ArgumentOutOfRangeException">Range is 0 to int64.maxValue</exception>
        public static BigInteger Factorial(long number)
        {
            if (number < 0) { throw new ArgumentOutOfRangeException("No negative value is allowed"); }
            if (number == 0 || number == 1)
            {
                return 1;
            }
            BigInteger res = number;
            for (long i = number - 1; i > 1; i--)
            {	
                // multiply fac-1 * fac-2 * .. 2
                res *= i;
            }
            return res;
        }

        /// <summary>
        /// Binomial coefficient AKA Combinatorial Choose, (n k)
        /// Example: how many ways can you take 3(k) items from a total of 5 (n)
        /// Formula:  n! / (k! * (n-k)!)
        /// </summary>
        /// <param name="total">Total amount of items</param>
        /// <param name="take">Total amount to take, needs to be smaller then total</param>
        /// <remarks>https://en.wikipedia.org/wiki/Binomial_coefficient</remarks>
        /// <returns></returns>
        public static BigInteger Binomial(long total, long take)
        {
            if (take > total) { return 0; }	// you cannot choose 4 if there are only 3 (r=4, n=3)
            if (take == total || take == 0) { return 1; }
            BigInteger facn = MathExtension.Factorial(total);
            BigInteger fack = MathExtension.Factorial(take);
            BigInteger facnr = MathExtension.Factorial(total - take);
            BigInteger res = BigInteger.Divide(facn, BigInteger.Multiply(fack, facnr));
            return res;
        }
    }
}