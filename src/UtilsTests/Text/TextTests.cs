using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeUtils.Text;

namespace Utils.StringExtensions
{
	[TestClass()]
	public class TextTests
	{
		[TestMethod()]
		public void IsPalindromicTest()
		{
			string p1 = "";
			string p2 = "a";
			string p3 = "aa";
			string p4 = "ab";
			string p5 = "abcabcbacba";
			string p6 = "abcaccbacba";

			Assert.IsTrue(p1.IsPalindrome());
			Assert.IsTrue(p2.IsPalindrome());
			Assert.IsTrue(p3.IsPalindrome());
			Assert.IsFalse(p4.IsPalindrome());
			Assert.IsTrue(p5.IsPalindrome());
			Assert.IsFalse(p6.IsPalindrome());
		}
	}
}