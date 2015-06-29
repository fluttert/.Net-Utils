using System.Collections.Generic;

namespace Fluttert.Utils.Math
{
	internal class CommonDivisor
	{
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
			return commonDivisors;
		}

		/// <summary>Classic GCD</summary>
		/// <param name="a">First number</param>
		/// <param name="b">Second number</param>
		/// <returns>Long: biggest common divisor, or 0 (zero) on negative numbers and 0</returns>
		public static long GreatestCommonDivisor(long a, long b)
		{
			// do a zero check and negativity check
			if (a <= 0 || b <= 0) { return 0; }
			// biggest divisor possible, when numbers are the same
			if (a == b) { return a; }
			// when a or b =1, then it will always be the biggest
			if (a == 1 || b == 1) { return 1; }

			// else do the classic Euclidean GCD algorithm make sure a = biggest, b = smallest
			if (b > a) { long t = a; a = b; b = t; }

			// https://en.wikipedia.org/wiki/Euclidean_algorithm. Divide the remainders, until the
			// first factor is found. This first factor will be the biggest factor
			while (b != 0)
			{
				long temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}
	}
}