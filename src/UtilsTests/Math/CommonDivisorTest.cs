using ChallengeUtils.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UtilsTests.Math
{
    [TestClass]
    public class CommonDivisorTest
    {
        [TestMethod]
        public void CommonDivisorsTest()
        {
            // empty list on zero
            CollectionAssert.AreEqual(new List<long>(), CommonDivisor.CommonDivisors(0, 1));

            // empty list on negative number
            CollectionAssert.AreEqual(new List<long>(), CommonDivisor.CommonDivisors(-1, 1));

            // a or b = 1
            CollectionAssert.AreEqual(new List<long>() { 1 }, CommonDivisor.CommonDivisors(18, 1));

            // When a is a factor of b
            CollectionAssert.AreEqual(new List<long>() { 1, 3 }, CommonDivisor.CommonDivisors(3, 6));

            // normal mode with multiple elements (tests the sorting)
            CollectionAssert.AreEqual(new List<long>() { 1, 2, 3, 6 }, CommonDivisor.CommonDivisors(6, 18));
        }

        [TestMethod]
        public void GreatestCommonDivisorTest()
        {
            Assert.AreEqual(0, CommonDivisor.GreatestCommonDivisor(-1, 1));  // edgecase negative numbers
            Assert.AreEqual(0, CommonDivisor.GreatestCommonDivisor(0, 1));  // edgecase with zero
            Assert.AreEqual(1, CommonDivisor.GreatestCommonDivisor(1, 1));  // edgecase 1
            Assert.AreEqual(2, CommonDivisor.GreatestCommonDivisor(2, 4));  // regular numbers
            Assert.AreEqual(2, CommonDivisor.GreatestCommonDivisor(4, 2));  // reverse order of input
            Assert.AreEqual(1, CommonDivisor.GreatestCommonDivisor(5, 11)); // primes, no common divisor
            Assert.AreEqual(1, CommonDivisor.GreatestCommonDivisor(6, 35)); // co-primes (2*3 and 5*7), no common divisor
            Assert.AreEqual(15, CommonDivisor.GreatestCommonDivisor(30, 45));
            Assert.AreEqual(21, CommonDivisor.GreatestCommonDivisor(1071, 462)); // wikipedia example
        }
    }
}