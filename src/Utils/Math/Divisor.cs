using System;
using System.Collections.Generic;

namespace ChallengeUtils.Math
{
    public class Divisor
    {
        /// <summary>
        /// Get all factors for a composite number, excluding 1 and itself
        /// </summary>
        /// <param name="candidate">The number to be factored</param>
        /// <returns>List of factors in ascending order, excluding 1 and itself</returns>
        /// <remarks>Primes will give an empty list</remarks>
        public static List<long> Factors(long candidate)
        {
            var result = new List<long>();

            // early exit on negative numbers and zero
            if (candidate <= 0) { return result; }

            // get the maximum factor, eg the max factor of 10 should be 4
            long maxFactor = Convert.ToInt64(System.Math.Sqrt(candidate)) + 1;
            for (long i = 2; i < maxFactor; i++)
            {
                // found a factor? also include the inverse. Example: 10/2 = 5, both 2 and 5 are factors
                if (candidate % i == 0)
                {
                    result.Add(i);

                    // add the inverse factor if not the same
                    if (i != candidate / i)
                    {
                        result.Add(candidate / i);
                    }
                }
            }
            result.Sort(); // sort in ascending order
            return result;
        }


        /// <summary>
        /// Determine the amount of divisors for a number
        /// </summary>
        /// <param name="candidate">Number to be factored</param>
        /// <returns>Long </returns>
        /// <remarks>Based on (p1+1)*(p2+1)*...(pn+1) where pX. See also: https://en.wikipedia.org/wiki/Integer_factorization and https://en.wikipedia.org/wiki/Highly_composite_number
        /// Is the prime-exponent. Depends on the primes, sieve of Erosthenes</remarks>
        public static long AmountOfDivisors(long candidate) {
            if (candidate <= 0) { throw new ArgumentOutOfRangeException("Number must be greater then 0");  }
            if (candidate == 1) { return 1; }

            // generate primes
            int maxPrime = (int)System.Math.Sqrt(candidate);
            List<int> primes = ChallengeUtils.Math.Primes.SieveOfEratosthenes(maxPrime + 1);

            // trial division by primes
            // example 1: 6 = 2*3 = 2^1 * 3*1 -> (1+1) * (1+1) = 4. 6 {1, 2, 3 ,6}
            // example 2: 12 = 2^2 * 3^1 -> (2+1) * (1+1) = 6. 12{1,2,3,4,6,12}
            long totalDivisors = 1;
            for (int k = 0; k < primes.Count; k++)
            {
                int curPrimeExp = 0;
                while (candidate % primes[k] == 0)
                {
                    curPrimeExp++;
                    candidate /= primes[k];
                }
                if (curPrimeExp > 0)
                {
                    // if there is an exponent, add 1 and multiply
                    totalDivisors *= (curPrimeExp + 1);
                }
            }
            return totalDivisors;
        }

        /// <summary>
        /// Return the highest primefactor from a number
        /// </summary>
        /// <param name="candidate">the number to be tested</param>
        /// <returns>Highest prime factor; or 0 on no primes (candidate<2)</returns>
        public static long HighestPrimeFactor(long candidate)
        {
            if (candidate < 2) { return 0; }

            long primeFactor = 0;
            // get rid of even numbers
            while (candidate % 2 == 0)
            {
                primeFactor = 2;
                candidate = candidate / 2;
            }

            // all exactly even 2^N / 4^N etc, will have highest prime factor 2
            if (candidate == 1) { return 2; }

            // the rest can be divided by 3+2N, up to the maxFactor of Sqrt(candidate)
            long j = 3;
            long maxFactor = Convert.ToInt64(System.Math.Sqrt(candidate));
            while (candidate > 1 && j <= maxFactor)
            {
                if (candidate % j == 0)
                {
                    // YEAH DIVISOR! adjust candidate, primefactor and maxfactor
                    if (primeFactor < j) { primeFactor = j; }
                    candidate = candidate / j;
                    maxFactor = Convert.ToInt64(System.Math.Sqrt(candidate));
                    // start over again with division
                    j = 3;
                }
                else {
                    // no joy, just keep on trying
                    j += 2;
                }
            }

            // number itself is prime if no factors have been found
            // also if the remainder is higher then the candidate, it will be the highest primefactor (eg: 34 -> 34/2 = 17 )
            if (primeFactor == 0 || candidate > primeFactor) { primeFactor = candidate; }
            return primeFactor;
        }

        /// <summary>Get all common divisors between 2 numbers (long/int64)</summary>
        /// <param name="a">Number</param>
        /// <param name="b">Number</param>
        /// <returns>List of common divisors (empty on 0 or negative numbers)</returns>
        public static List<long> CommonDivisors(long a, long b)
        {
            // enforce a <= b
            if (a > b) { long tmp = a; a = b; b = tmp; }
            List<long> commonDivisors = new List<long>();
            // do a zero check and negativity check
            if (a <= 0 || b <= 0) { return commonDivisors; }
            // a>0 and b>0 so it will be divisble by 1 :D
            commonDivisors.Add(1);
            // if a == 1, return
            if (a == 1) { return commonDivisors; }
            // if a is a divisor, add it. eg a=3, b=6
            if (b % a == 0) { commonDivisors.Add(a); }
            // start at halve the range
            for (long i = (a / 2) + 1; i > 1; i--)
            {   // it is a common divisor if both a and b are divisible by it (duh)
                if (a % i == 0 && b % i == 0)
                {   // this is our lucky day!
                    commonDivisors.Add(i);
                }
            }
            // sort the common divisors in ascending order
            commonDivisors.Sort();
            return commonDivisors;
        }

        /// <summary>Classic GCD, using Euclidian algorithm</summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Long: biggest common divisor, or 0 (zero) on negative numbers and 0</returns>
        /// <remarks>https://en.wikipedia.org/wiki/Euclidean_algorithm</remarks>
        public static long GreatestCommonDivisor(long a, long b)
        {
            // do a zero check and negativity check
            if (a <= 0 || b <= 0) { return 0; }

            // force a = biggest, b = smallest
            if (b > a) { long t = a; a = b; b = t; }

            // Divide the remainders, until the first factor is found. This first factor will be the biggest factor
            while (b != 0)
            {
                long temp = a % b;  // Keep substracting b from a, untill the remainder is smaller then b
                a = b;              // b is now the biggest factor, so it becomes a
                b = temp;           // the smaller factor will be b (or 0 when a common divider is found)
            }
            return a;
        }
    }
}