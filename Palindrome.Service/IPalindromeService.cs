using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Service
{
    public interface IPalindromeService
    {
        IEnumerable<IPalindrome> GetLongestUniquePalindromes(string source, int count);


    }
}
