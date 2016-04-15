using Fluttert.Utils.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UtilsTests.Math
{
    [TestClass]
    public class DivisorTest
    {
        [TestMethod]
        public void FactorsTest()
        {
            // based on https://en.wikipedia.org/wiki/Table_of_divisors
            CollectionAssert.AreEqual(
                new List<long>() { 1 },
                Divisor.Factors(1));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 2 },
                Divisor.Factors(2));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 3 },
                Divisor.Factors(3));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 2, 3, 4, 6, 12 },
                Divisor.Factors(12));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 3, 7, 21 },
                Divisor.Factors(21));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 5, 25 },
                Divisor.Factors(25));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 2, 4, 7, 14, 28 },
                Divisor.Factors(28));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 587 },
                Divisor.Factors(587));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 2, 3, 4, 6, 7, 12, 14, 21, 28, 42, 49, 84, 98, 147, 196, 294, 588 },
                Divisor.Factors(588));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 2, 3, 5, 6, 9, 10, 11, 15, 18, 22, 30, 33, 45, 55, 66, 90, 99, 110, 165, 198, 330, 495, 990 },
                Divisor.Factors(990));
            CollectionAssert.AreEqual(
                new List<long>() { 1, 3, 9, 27, 37, 111, 333, 999 },
                Divisor.Factors(999));
        }

        [TestMethod]
        public void AmountOfDivisorsExceptionTest()
        {
            try
            {
                Divisor.AmountOfDivisors(0);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception)
            {
                // not the right kind of exception
                Assert.Fail();
            }

            try
            {
                Divisor.AmountOfDivisors(4611686014132420610);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception)
            {
                // not the right kind of exception
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AmountOfDivisorsTest()
        {
            Assert.AreEqual(1, Divisor.AmountOfDivisors(1));
            Assert.AreEqual(2, Divisor.AmountOfDivisors(2));
            Assert.AreEqual(2, Divisor.AmountOfDivisors(3));
            Assert.AreEqual(3, Divisor.AmountOfDivisors(4));
            Assert.AreEqual(2, Divisor.AmountOfDivisors(5));
            Assert.AreEqual(4, Divisor.AmountOfDivisors(6));
            Assert.AreEqual(2, Divisor.AmountOfDivisors(7));
            Assert.AreEqual(4, Divisor.AmountOfDivisors(8));
            Assert.AreEqual(3, Divisor.AmountOfDivisors(9));
            Assert.AreEqual(60, Divisor.AmountOfDivisors(5040));
            Assert.AreEqual(240, Divisor.AmountOfDivisors(720720));
            Assert.AreEqual(896, Divisor.AmountOfDivisors(147026880));
        }

        [TestMethod]
        public void HighestPrimeFactorTest()
        {
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