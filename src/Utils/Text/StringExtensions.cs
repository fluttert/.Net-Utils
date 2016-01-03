using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeUtils.Text
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines if a certain text is palindromic. example: 12321 is a palindrome, just like LoL
        /// </summary>
        /// <param name="text">The text to check</param>
        /// <returns>true on palindrome</returns>
        /// <remarks>input text is limited to Int32.MaxValue</remarks>
        public static bool IsPalindrome(this string text)
        {
            int charAmount = text.Length;
            if (charAmount == 1) { return true; }
            // else iterate over string
            for (int i = 0; i < (charAmount / 2); i++)
            {
                if (text[i] != text[(charAmount - i - 1)])
                {   // quit on first sign of non palindrome
                    return false;
                }
            }
            return true;
            // 	return text == text.Reverse().ToString(); // == slower then above
        }
    }
}
