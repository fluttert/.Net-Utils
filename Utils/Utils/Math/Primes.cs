using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils.Math
{
	public class Primes
	{
		/// <summary>Determines if a candidate is Prime</summary>
		/// <param name="candidate">Long/int64</param>
		/// <returns>Boolean, true on prime</returns>
		/// <remarks>Only works on Int32 and Int64</remarks>
		public static bool IsPrime(long candidate)
		{
			// rule out 2 and 3
			if (candidate == 2 || candidate == 3) { return true; }
			// Even number check
			if (candidate % 2 == 0 || candidate % 3 == 0 || candidate < 4) { return false; }
			long maxFactor = (long)System.Math.Sqrt(candidate);
			for (int p = 5; p <= maxFactor; p += 6)
			{   // all primes are 6n+1 or 6n-1 , see wikipedia; Only applies if 2 and 3 are already ruled out
				if (candidate % p == 0 || candidate % (p + 2) == 0)
				{   // number is divisible, thus not prime
					return false;
				}
			}
			return true; // not divisible, thus prime
		}

		/// <summary>
		/// Returns a list of primes, based on the Sieve of Erastosthenes
		/// </summary>
		/// <param name="exclusiveMax">Exclusive upperlimit, for example 100 would give primes up to 99</param>
		/// <returns>A list of primes, or empty list otherwise</returns>
		/// <remarks>Exclusive max, must be lower then Int32.maxValue</remarks>
		public static List<int> SieveOfEratosthenes(int exclusiveMax)
		{
			List<int> primes = new List<int>();
			// Sieve works from 2 and up, return empty on negative, zero, or 1 as max. Returns empty list
			if (exclusiveMax < 2) { return primes; }

			// SIEVE!
			BitArray nonPrimes = new BitArray(exclusiveMax);                // iterate on list, false = prime, true is nonprime
			int maxDivisor = Convert.ToInt32(System.Math.Sqrt(exclusiveMax)) + 1;  // maximum divisor/factor is the squareroot of exclusivemax
			for (int i = 2; i < maxDivisor; i++)
			{   // checking out all factors
				if (!nonPrimes[i])
				{   // this number is still set as a prime, strike off all multiples of this number
					for (int j = i + i; j < exclusiveMax; j = j + i) { nonPrimes[j] = true; }
				}
			}
			for (int i = 2; i < exclusiveMax; i++)
			{   // iterate on list, 0 = prime, 1 is nonprime
				if (!nonPrimes[i]) { primes.Add(i); }
			}
			return primes;
		}
	}
}