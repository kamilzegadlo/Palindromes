using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Service
{
    public class PalindromeService : IPalindromeService
    {
        //This solution will fail on very big data, where the whole input is bigger than available memory.
        //I assume that our input will be rather small. In other case i will have to split it on chunks.
        //I also keep all unique palindromes in the memory not only 3 biggest. The reason is in unit test: CheckNumberAfterRemovingSubPalindromes
        public IEnumerable<IPalindrome> GetLongestUniquePalindromes(string source, int count)
        {
            //I considered using: HashSet or SortedSet
            //1. HashSet is better to check if palindorme already was added. It would be best for inputs with many repeted palindromes.
            //But it is implemented in .NET using arrays and extending/shrinking an array is very expensive. 
            //2. SortedSet is better to find the smallest one. It would be the best for inputs with small number of repeated palindromes.
            //it is implemented in .NET as black-red tree. 
            //
            //There is no clear winner for this task. 
            ICollection<IPalindrome> longestPalindromes = new HashSet<IPalindrome>();

            int sourceCurrentIndex = 0;

            while(true)
            {
                IPalindrome nextPalindromeCenter = GetNextPalindromCenter(source, sourceCurrentIndex);
                if (nextPalindromeCenter == null)
                    break ;

                IPalindrome nextPalindrome=GetPalindromFromGivenCenter(source, nextPalindromeCenter);

                longestPalindromes = AddPalindrome(longestPalindromes, nextPalindrome);

                sourceCurrentIndex = nextPalindromeCenter.endIndex;
            }

            return longestPalindromes.OrderByDescending(p => p.length).ThenBy(p=>p.startIndex).Take(count);
        }

        private ICollection<IPalindrome> AddPalindrome(ICollection<IPalindrome> palindromes, IPalindrome nextPalindrome)
        {
            if (!palindromes.Contains(nextPalindrome) && !nextPalindrome.IsASubPalindromeToAnyOf(palindromes))
            {
                palindromes = RemoveSubPalindromesIfTheyAlreadyAdded(palindromes, nextPalindrome).ToList();

                palindromes.Add(nextPalindrome);
            }

            return palindromes;
        }

        private IEnumerable<IPalindrome> RemoveSubPalindromesIfTheyAlreadyAdded(IEnumerable<IPalindrome> palindromes, IPalindrome nextPalindram)
        {
            return palindromes.Where(p => !(p.IsASubPalindromeTo(nextPalindram)));
        }

        //check if char[i]==char[i+2] OR char[i]==char[i+1] if yes return next palindrome center
        private IPalindrome GetNextPalindromCenter(string source, int startIndex)
        {
            for (int nextPalindromCenterStartIndex = source.GetNextAlphaCharIndex(startIndex); nextPalindromCenterStartIndex < source.Length - 2; )
            {
                int nextAlphaCharIndex = source.GetNextAlphaCharIndex(nextPalindromCenterStartIndex + 1);
                int nextNextAlphaCharIndex = source.GetNextAlphaCharIndex(nextAlphaCharIndex + 1);

                char newStartChar=source[nextPalindromCenterStartIndex];
                char nextAlphaChar = source[nextAlphaCharIndex];
                char nextNextAlphaChar = source[nextNextAlphaCharIndex];

                if (newStartChar.isEqualToIgnoreCase(nextNextAlphaChar))
                {
                    int length = nextNextAlphaCharIndex - nextPalindromCenterStartIndex + 1;
                    string text = source.Substring(nextPalindromCenterStartIndex, length);
                    return new Palindrome(text, nextPalindromCenterStartIndex, nextNextAlphaCharIndex);
                }
                if (newStartChar.isEqualToIgnoreCase(nextAlphaChar))
                {
                    int length = nextAlphaCharIndex - nextPalindromCenterStartIndex + 1;
                    string text = source.Substring(nextPalindromCenterStartIndex, length);
                    return new Palindrome(text, nextPalindromCenterStartIndex, nextAlphaCharIndex);
                }

                nextPalindromCenterStartIndex = nextAlphaCharIndex;
            }

            return null;
        }

        private IPalindrome GetPalindromFromGivenCenter(string source, IPalindrome palindromCenter)
        {
            int startIndex = palindromCenter.startIndex;
            int endIndex = palindromCenter.endIndex;

            while(true)
            {
                int newStartIndex = source.GetPrevAlphaCharIndex(startIndex-1);
                int newEndIndex = source.GetNextAlphaCharIndex(endIndex+1);

                if (newStartIndex > -1 && newEndIndex < source.Length && source[newStartIndex].isEqualToIgnoreCase(source[newEndIndex]))
                {
                    startIndex=newStartIndex;
                    endIndex=newEndIndex;
                }
                else
                    break;
            }

            int length = endIndex - startIndex + 1;
            String palindrome = source.Substring(startIndex, length);

            return new Palindrome(palindrome, startIndex, endIndex);
        }

    }
}
