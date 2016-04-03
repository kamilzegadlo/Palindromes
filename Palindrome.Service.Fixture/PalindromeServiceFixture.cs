using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Palindrome.Service;

namespace Palindrome.Service.Fixture
{
    [TestFixture]
    public class PalindromeServiceFixture
    {
        [Test]
        public void SimpleTest()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop", 3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult=results.First();
            Assert.AreEqual("hijkllkjih",firstResult.text);
            Assert.AreEqual(23,firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("defggfed", secondResult.text);
            Assert.AreEqual(13, secondResult.startIndex);
            Assert.AreEqual(8, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("abccba", thirdResult.text);
            Assert.AreEqual(5, thirdResult.startIndex);
            Assert.AreEqual(6, thirdResult.length);
        }

        //hijkllkjih twice
        [Test]
        public void SamePalindromTwice()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpophijkllkjihaa",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("hijkllkjih", firstResult.text);
            Assert.AreEqual(23, firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("defggfed", secondResult.text);
            Assert.AreEqual(13, secondResult.startIndex);
            Assert.AreEqual(8, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("abccba", thirdResult.text);
            Assert.AreEqual(5, thirdResult.startIndex);
            Assert.AreEqual(6, thirdResult.length);
        }

        //abccba starts from index 0
        [Test]
        public void PalindromFromIndex0()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("abccbatudefggfedvwhijkllkjihxymnnmzpop",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("hijkllkjih", firstResult.text);
            Assert.AreEqual(18, firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("defggfed", secondResult.text);
            Assert.AreEqual(8, secondResult.startIndex);
            Assert.AreEqual(8, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("abccba", thirdResult.text);
            Assert.AreEqual(0, thirdResult.startIndex);
            Assert.AreEqual(6, thirdResult.length);
        }

        //hijkllkjih at the very end of input
        [Test]
        public void PalindromAtTheEndOfInput()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sqrrqabccbatudefggfedvwhijkllkjih",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("hijkllkjih", firstResult.text);
            Assert.AreEqual(23, firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("defggfed", secondResult.text);
            Assert.AreEqual(13, secondResult.startIndex);
            Assert.AreEqual(8, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("abccba", thirdResult.text);
            Assert.AreEqual(5, thirdResult.startIndex);
            Assert.AreEqual(6, thirdResult.length);
        }

        //coma in hij,kllkjih and space in defg gfed
        [Test]
        public void NonAlphabeticChars()
        {
            IPalindromeService palindromService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromService.GetLongestUniquePalindromes("sqrrqabccbatudefg gfedvwhij,kllkjih",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("hij,kllkjih", firstResult.text);
            Assert.AreEqual(24, firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("defg gfed", secondResult.text);
            Assert.AreEqual(13, secondResult.startIndex);
            Assert.AreEqual(8, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("abccba", thirdResult.text);
            Assert.AreEqual(5, thirdResult.startIndex);
            Assert.AreEqual(6, thirdResult.length);
        }

        //defGgfed contains one Capital letter
        [Test]
        public void MixedCapitalAndNormalLetters()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sqrrqabccbatudefGgfedvwhiJkllkjih",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("hiJkllkjih", firstResult.text);
            Assert.AreEqual(23, firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("defGgfed", secondResult.text);
            Assert.AreEqual(13, secondResult.startIndex);
            Assert.AreEqual(8, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("abccba", thirdResult.text);
            Assert.AreEqual(5, thirdResult.startIndex);
            Assert.AreEqual(6, thirdResult.length);
        }

        //sijkllkjis, oijkllkjio, uijkllkjiu, hijkllkjih all with length equal 10.
        [Test]
        public void MoreThanThreeWithSameTheBigestSize()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sqrrqabccbasijkllkjistoijkllkjioudefggfedvuijkllkjiuwhijkllkjihxymnnmzpop",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("sijkllkjis", firstResult.text);
            Assert.AreEqual(11, firstResult.startIndex);
            Assert.AreEqual(10, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("oijkllkjio", secondResult.text);
            Assert.AreEqual(22, secondResult.startIndex);
            Assert.AreEqual(10, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("uijkllkjiu", thirdResult.text);
            Assert.AreEqual(42, thirdResult.startIndex);
            Assert.AreEqual(10, thirdResult.length);
        }

        //brbolobrb contains brb
        [Test]
        public void PalindromeInsideOtherOne()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sabrbolobrbp",3);

            Assert.AreEqual(1, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("brbolobrb", firstResult.text);
            Assert.AreEqual(2, firstResult.startIndex);
            Assert.AreEqual(9, firstResult.length);
        }

        //brbetytolotytebrb contains: brb, tyt, brbetyt
        [Test]
        public void ManyPalindromesInsideOtherOne()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sabrbetytolotytebrbp",3);

            Assert.AreEqual(1, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("brbetytolotytebrb", firstResult.text);
            Assert.AreEqual(2, firstResult.startIndex);
            Assert.AreEqual(17, firstResult.length);
        }

        //first brbetytolotytebrb, next brb. We should get in result only: brbetytolotytebrb
        [Test]
        public void SubPalindromeAfterBigPalindrome()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sabrbetytolotytebrbpibrbo",3);

            Assert.AreEqual(1, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("brbetytolotytebrb", firstResult.text);
            Assert.AreEqual(2, firstResult.startIndex);
            Assert.AreEqual(17, firstResult.length);
        }

        //If algorithm keeps in memory only 3 biggest palindromes, for input: sbybtuiuvioyyobtrrtptrrtboyyo it will work: 
        //add byb
        //add uiu
        //add oyyo
        //remove byb, add trrt
        //remove oyyo, remove trrt, add obtrrtptrrtboyyo
        //so the result would be: obtrrtptrrtboyyo, uiu
        //but should be: obtrrtptrrtboyyo, byb, uiu
        [Test]
        public void CheckNumberAfterRemovingSubPalindromes()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("sbybtuiuvioyyobtrrtptrrtboyyo",3);

            Assert.AreEqual(3, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("oyyobtrrtptrrtboyyo", firstResult.text);
            Assert.AreEqual(10, firstResult.startIndex);
            Assert.AreEqual(19, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("byb", secondResult.text);
            Assert.AreEqual(1, secondResult.startIndex);
            Assert.AreEqual(3, secondResult.length);

            IPalindrome thirdResult = results.Skip(2).First();
            Assert.AreEqual("uiu", thirdResult.text);
            Assert.AreEqual(5, thirdResult.startIndex);
            Assert.AreEqual(3, thirdResult.length);
        }

        //obtrrtptrrtboyyo overlaps on boyyoiuytrprtyuioyyob
        [Test]
        public void OverlappingPalindromes()
        {
            IPalindromeService palindromeService = new PalindromeService();

            IEnumerable<IPalindrome> results = palindromeService.GetLongestUniquePalindromes("oyyobtrrtptrrtboyyoiuytrprtyuioyyob",3);

            Assert.AreEqual(2, results.Count());

            IPalindrome firstResult = results.First();
            Assert.AreEqual("boyyoiuytrprtyuioyyob", firstResult.text);
            Assert.AreEqual(14, firstResult.startIndex);
            Assert.AreEqual(21, firstResult.length);

            IPalindrome secondResult = results.Skip(1).First();
            Assert.AreEqual("oyyobtrrtptrrtboyyo", secondResult.text);
            Assert.AreEqual(0, secondResult.startIndex);
            Assert.AreEqual(19, secondResult.length);
        }
    }
}
