using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindrome.Service;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            IPalindromeService palindromeService = new PalindromeService();

            foreach(IPalindrome palindrome in palindromeService.GetLongestUniquePalindromes(input, 3))
                Console.WriteLine(String.Format("Text: {0}, Start index: {1}, Length: {2}", palindrome.text, palindrome.startIndex, palindrome.length));

            Console.Read();

        }
    }
}
