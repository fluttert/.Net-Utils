using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace UtilsTests.Math
{
    [TestClass]
    public class MathExtensionTests
    {
        /// <summary>
        /// Values are from wikipedia: https://en.wikipedia.org/wiki/Factorial
        /// and WolframAlpha: http://www.wolframalpha.com/input/?i=120!
        /// </summary>
        [TestMethod]
        public void FactorialTest()
        {
            Assert.AreEqual(1, ChallengeUtils.Math.MathExtension.Factorial(0));
            Assert.AreEqual(1, ChallengeUtils.Math.MathExtension.Factorial(1));
            Assert.AreEqual(2, ChallengeUtils.Math.MathExtension.Factorial(2));
            Assert.AreEqual(6, ChallengeUtils.Math.MathExtension.Factorial(3));
            Assert.AreEqual(24, ChallengeUtils.Math.MathExtension.Factorial(4));
            Assert.AreEqual(120, ChallengeUtils.Math.MathExtension.Factorial(5));
            Assert.AreEqual(720, ChallengeUtils.Math.MathExtension.Factorial(6));
            Assert.AreEqual(5040, ChallengeUtils.Math.MathExtension.Factorial(7));
            Assert.AreEqual(40320, ChallengeUtils.Math.MathExtension.Factorial(8));
            Assert.AreEqual(362880, ChallengeUtils.Math.MathExtension.Factorial(9));
            Assert.AreEqual(3628800, ChallengeUtils.Math.MathExtension.Factorial(10));
            Assert.AreEqual(39916800, ChallengeUtils.Math.MathExtension.Factorial(11));
            Assert.AreEqual(479001600, ChallengeUtils.Math.MathExtension.Factorial(12));
            Assert.AreEqual(6227020800, ChallengeUtils.Math.MathExtension.Factorial(13));
            Assert.AreEqual(87178291200, ChallengeUtils.Math.MathExtension.Factorial(14));
            Assert.AreEqual(1307674368000, ChallengeUtils.Math.MathExtension.Factorial(15));
            Assert.AreEqual(20922789888000, ChallengeUtils.Math.MathExtension.Factorial(16));
            Assert.AreEqual(355687428096000, ChallengeUtils.Math.MathExtension.Factorial(17));
            Assert.AreEqual(6402373705728000, ChallengeUtils.Math.MathExtension.Factorial(18));
            Assert.AreEqual(121645100408832000, ChallengeUtils.Math.MathExtension.Factorial(19));
            Assert.AreEqual(2432902008176640000, ChallengeUtils.Math.MathExtension.Factorial(20));
            Assert.AreEqual(BigInteger.Parse("6689502913449127057588118054090372586752746333138029810295671352301633557244962989366874165271984981308157637893214090552534408589408121859898481114389650005964960521256960000000000000000000000000000"), ChallengeUtils.Math.MathExtension.Factorial(120));
        }

        [TestMethod]
        public void BinomialTest() {
            Assert.AreEqual(1, ChallengeUtils.Math.MathExtension.Binomial(10, 0));
            Assert.AreEqual(10, ChallengeUtils.Math.MathExtension.Binomial(10, 1));
            Assert.AreEqual(45, ChallengeUtils.Math.MathExtension.Binomial(10, 2));
            Assert.AreEqual(120, ChallengeUtils.Math.MathExtension.Binomial(10, 3));
            Assert.AreEqual(210, ChallengeUtils.Math.MathExtension.Binomial(10, 4));
            Assert.AreEqual(252, ChallengeUtils.Math.MathExtension.Binomial(10, 5));
            Assert.AreEqual(210, ChallengeUtils.Math.MathExtension.Binomial(10, 6));
            Assert.AreEqual(120, ChallengeUtils.Math.MathExtension.Binomial(10, 7));
            Assert.AreEqual(45, ChallengeUtils.Math.MathExtension.Binomial(10, 8));
            Assert.AreEqual(10, ChallengeUtils.Math.MathExtension.Binomial(10, 9));
            Assert.AreEqual(1, ChallengeUtils.Math.MathExtension.Binomial(10, 10));

        }
    }
}
