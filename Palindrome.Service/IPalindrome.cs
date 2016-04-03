using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Service
{
    public interface IPalindrome
    {
        string text { get; }
        string formattedText { get; }
        int startIndex { get; }
        int endIndex { get; }
        int length { get; }
        bool IsASubPalindromeTo(IPalindrome bigPalindrome);
        bool IsASubPalindromeToAnyOf(IEnumerable<IPalindrome> palindromes);
    }
}
