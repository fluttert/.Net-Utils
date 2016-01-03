using System.Numerics;

namespace ChallengeUtils.Math
{
    public class PascalTriangle
    {
        /// <summary>
        /// Create a pascal triangle, usefull for combinatorics
        /// </summary>
        /// <param name="n">The total amount of rows (LONG, max = Int64.MaxValue)</param>
        /// <returns>Jagged matrix of BigIntegers[][], where (n choose r) -> [n][r]</returns>
        /// <remarks>Depends on BigInteger from System.Numerics namespace</remarks>
        /// <seealso cref="https://en.wikipedia.org/wiki/Pascals_triangle"/>
        public static BigInteger[][] Create(long n)
        {
            //  (the zero'th row will have 1 element)
            var triangle = new BigInteger[n + 1][];
            for (long i = 0; i <= n; i++)
            {
                for (long j = 0; j <= i; j++)
                {
                    // create new jagged array (minimum) and set first element to 1
                    if (j == 0)
                    {
                        triangle[i] = new BigInteger[i + 1];
                        triangle[i][j] = 1;
                        continue;
                    }
                    // last element is always 1 (just like the first
                    if (j == i) { triangle[i][i] = 1; continue; }

                    // in all other cases, just add the 2 digits in the upper row
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }
            return triangle;
        }

        /// <summary>
        /// Create a pascal triangle modulo a number, usefull for combinatorics
        /// </summary>
        /// <param name="n">The total amount of rows (LONG, max = Int64.MaxValue)</param>
        /// <param name="modulo">Modulo the triangle by this number (max = Int64.MaxValue /2 )</param>
        /// <returns>Jagged matrix long[][], truncated by the modulo, where (n choose r) -> [n][r]</returns>
        /// <seealso cref="https://en.wikipedia.org/wiki/Pascals_triangle"/>
        public static long[][] CreateModulo(long n, long modulo)
        {
            if (modulo >= long.MaxValue / 2) { throw new System.ArgumentOutOfRangeException("Modulo is too big"); }
            
            //  (the zero'th row will have 1 element)
            var triangle = new long[n + 1][];
            for (long i = 0; i <= n; i++)
            {
                for (long j = 0; j <= i; j++)
                {
                    // create new jagged array (minimum) and set first element to 1
                    if (j == 0)
                    {
                        triangle[i] = new long[i + 1];
                        triangle[i][j] = 1;
                        continue;
                    }
                    // last element is always 1 (just like the first
                    if (j == i) { triangle[i][i] = 1; continue; }

                    // in all other cases, just add the 2 digits in the upper row
                    triangle[i][j] = (triangle[i - 1][j - 1] + triangle[i - 1][j]) % modulo;
                }
            }
            return triangle;
        }
    }
}