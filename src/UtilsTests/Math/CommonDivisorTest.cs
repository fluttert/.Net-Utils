using ChallengeUtils.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UtilsTests.Math
{
    [TestClass]
    public class CommonDivisorTest
    {
        [TestMethod]
        public void HighestPrimeFactorTest() {
            Assert.AreEqual(0, CommonDivisor.HighestPrimeFactor(1));
            Assert.AreEqual(2, CommonDivisor.HighestPrimeFactor(2));
            Assert.AreEqual(3, CommonDivisor.HighestPrimeFactor(3));
            Assert.AreEqual(2, CommonDivisor.HighestPrimeFactor(4));
            Assert.AreEqual(5, CommonDivisor.HighestPrimeFactor(5));
            Assert.AreEqual(3, CommonDivisor.HighestPrimeFactor(6));
            Assert.AreEqual(7, CommonDivisor.HighestPrimeFactor(7));
            Assert.AreEqual(2, CommonDivisor.HighestPrimeFactor(8));
            Assert.AreEqual(3, CommonDivisor.HighestPrimeFactor(9));
            Assert.AreEqual(5, CommonDivisor.HighestPrimeFactor(10));
            Assert.AreEqual(3, CommonDivisor.HighestPrimeFactor(864));
            Assert.AreEqual(17, CommonDivisor.HighestPrimeFactor(830297));
            Assert.AreEqual(909091, CommonDivisor.HighestPrimeFactor(10000001));
        }

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
            Assert.AreEqual(33, CommonDivisor.GreatestCommonDivisor(33, 33)); // same numbers, highest = number it self
            Assert.AreEqual(1, CommonDivisor.GreatestCommonDivisor(5, 11)); // primes, no common divisor
            Assert.AreEqual(1, CommonDivisor.GreatestCommonDivisor(6, 35)); // co-primes (2*3 and 5*7), no common divisor
            Assert.AreEqual(15, CommonDivisor.GreatestCommonDivisor(30, 45));
            Assert.AreEqual(21, CommonDivisor.GreatestCommonDivisor(1071, 462)); // wikipedia example
        }
    }
}