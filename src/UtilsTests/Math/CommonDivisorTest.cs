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
            Assert.AreEqual(0, Divisor.HighestPrimeFactor(1));
            Assert.AreEqual(2, Divisor.HighestPrimeFactor(2));
            Assert.AreEqual(3, Divisor.HighestPrimeFactor(3));
            Assert.AreEqual(2, Divisor.HighestPrimeFactor(4));
            Assert.AreEqual(5, Divisor.HighestPrimeFactor(5));
            Assert.AreEqual(3, Divisor.HighestPrimeFactor(6));
            Assert.AreEqual(7, Divisor.HighestPrimeFactor(7));
            Assert.AreEqual(2, Divisor.HighestPrimeFactor(8));
            Assert.AreEqual(3, Divisor.HighestPrimeFactor(9));
            Assert.AreEqual(5, Divisor.HighestPrimeFactor(10));
            Assert.AreEqual(3, Divisor.HighestPrimeFactor(864));
            Assert.AreEqual(17, Divisor.HighestPrimeFactor(830297));
            Assert.AreEqual(909091, Divisor.HighestPrimeFactor(10000001));
            Assert.AreEqual(6857, Divisor.HighestPrimeFactor(600851475143));

            
        }

        [TestMethod]
        public void CommonDivisorsTest()
        {
            // empty list on zero
            CollectionAssert.AreEqual(new List<long>(), Divisor.CommonDivisors(0, 1));

            // empty list on negative number
            CollectionAssert.AreEqual(new List<long>(), Divisor.CommonDivisors(-1, 1));

            // a or b = 1
            CollectionAssert.AreEqual(new List<long>() { 1 }, Divisor.CommonDivisors(18, 1));

            // When a is a factor of b
            CollectionAssert.AreEqual(new List<long>() { 1, 3 }, Divisor.CommonDivisors(3, 6));

            // normal mode with multiple elements (tests the sorting)
            CollectionAssert.AreEqual(new List<long>() { 1, 2, 3, 6 }, Divisor.CommonDivisors(6, 18));
        }

        [TestMethod]
        public void GreatestCommonDivisorTest()
        {
            Assert.AreEqual(0, Divisor.GreatestCommonDivisor(-1, 1));  // edgecase negative numbers
            Assert.AreEqual(0, Divisor.GreatestCommonDivisor(0, 1));  // edgecase with zero
            Assert.AreEqual(1, Divisor.GreatestCommonDivisor(1, 1));  // edgecase 1
            Assert.AreEqual(2, Divisor.GreatestCommonDivisor(2, 4));  // regular numbers
            Assert.AreEqual(2, Divisor.GreatestCommonDivisor(4, 2));  // reverse order of input
            Assert.AreEqual(33, Divisor.GreatestCommonDivisor(33, 33)); // same numbers, highest = number it self
            Assert.AreEqual(1, Divisor.GreatestCommonDivisor(5, 11)); // primes, no common divisor
            Assert.AreEqual(1, Divisor.GreatestCommonDivisor(6, 35)); // co-primes (2*3 and 5*7), no common divisor
            Assert.AreEqual(15, Divisor.GreatestCommonDivisor(30, 45));
            Assert.AreEqual(21, Divisor.GreatestCommonDivisor(1071, 462)); // wikipedia example
        }
    }
}