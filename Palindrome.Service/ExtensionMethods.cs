using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Service
{
    static class ExtensionMethods
    {
        public static int GetNextAlphaCharIndex(this string source, int currentCharIndex)
        {
            int nextCharIndex = currentCharIndex;
            for (; nextCharIndex < source.Length; ++nextCharIndex)
                if (source[nextCharIndex].IsAplhaChar())
                    break;

            return nextCharIndex;
        }

        public static int GetPrevAlphaCharIndex(this string source, int currentCharIndex)
        {
            int prevCharIndex = currentCharIndex;
            for (; prevCharIndex > -1; --prevCharIndex)
                if (source[prevCharIndex].IsAplhaChar())
                    break;

            return prevCharIndex;
        }

        public static bool IsAplhaChar(this char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        public static bool isEqualToIgnoreCase(this char c1, char c2)
        {
            return char.ToLower(c1) == char.ToLower(c2);
        }
    }
}
