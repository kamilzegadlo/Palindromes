using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Palindrome.Service
{
    public class Palindrome : IPalindrome
    {
        public string text {get; private set;}
        public string formattedText { get; private set; }
        public int startIndex { get; private set; }
        public int endIndex { get; private set; }
        public int length 
        { 
            get 
            { 
                if(String.IsNullOrEmpty(formattedText)) 
                    return 0; 
                return formattedText.Length; 
            } 
        }
        public Palindrome(string text, int startIndex, int endIndex)
        {
            this.text = text;
            this.formattedText = new String(text.Where(c => c.IsAplhaChar()).ToArray());
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public int CompareTo(object obj)
        {
            return this.length.CompareTo(((IPalindrome)obj).length);
        }

        public override bool Equals(object obj)
        {
            return ((IPalindrome)obj).text == this.text;
        }

        public override int GetHashCode()
        {
            return this.text.GetHashCode();
        }

        public bool IsASubPalindromeTo(IPalindrome bigPalindrome)
        {
            return bigPalindrome.formattedText.Contains(this.formattedText);
        }

        public bool IsASubPalindromeToAnyOf(IEnumerable<IPalindrome> palindromes)
        {
            return palindromes.Any(p => this.IsASubPalindromeTo(p));
        }
    }
}
