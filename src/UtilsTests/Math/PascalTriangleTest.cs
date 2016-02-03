using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace UtilsTests.Math
{
    [TestClass]
    public class PascalTriangleTest
    {
        /// <summary>
        /// Test a common triangle
        /// </summary>
        [TestMethod]
        public void PascalTriangleCreateTest()
        {
            var expected = new BigInteger[7][] {
                new BigInteger[] { 1 },
                new BigInteger[] { 1, 1 },
                new BigInteger[] { 1, 2, 1 },
                new BigInteger[] { 1, 3, 3, 1 },
                new BigInteger[] { 1, 4, 6, 4, 1 },
                new BigInteger[] { 1, 5, 10, 10, 5, 1 },
                new BigInteger[] { 1, 6, 15, 20, 15, 6, 1 }
            };
            var actual = ChallengeUtils.Math.PascalTriangle.Create(7);

            // TESTING!
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void PascalTriangleCreateModuloTest()
        {
            var expected = new long[7][] {
                new long[] { 1 },
                new long[] { 1, 1 },
                new long[] { 1, 2, 1 },
                new long[] { 1, 3, 3, 1 },
                new long[] { 1, 4, 6, 4, 1 },
                new long[] { 1, 5, 0, 0, 5, 1 },
                new long[] { 1, 6, 5, 0, 5, 6, 1 }
            };
            var actual = ChallengeUtils.Math.PascalTriangle.CreateModulo(7, 10);

            // TESTING!
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        // Test modulo method, where modulo is bigger then the output requires (no truncate)
        [TestMethod]
        public void PascalTriangleCreateModuloNotNecessaryTest()
        {
            var expected = new long[5][] {
                new long[] { 1 },
                new long[] { 1, 1 },
                new long[] { 1, 2, 1 },
                new long[] { 1, 3, 3, 1 },
                new long[] { 1, 4, 6, 4,1 }
            };
            var actual = ChallengeUtils.Math.PascalTriangle.CreateModulo(4, 10);

            // TESTING!
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}