Write an application that finds the N longest unique palindromes in a supplied string. 
Report the palindrome, start index and length, in descending order of length.

Example Output

Given the input string: sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop , the output should be:
Text: hijkllkjih, Index: 23, Length: 10
Text: defggfed, Index: 13, Length: 8
Text: abccba, Index: 5 Length: 6

-----------------------

To run the solution just donwload it, open in a visual studio and build. The console application should be the startup project.

This solution will fail on very big data, where the whole input is bigger than the available memory.
I assume that our input will be rather small. In other case i will have to split it on chunks.
I also keep all unique palindromes in the memory not only the N longest. The reason is in unit test: CheckNumberAfterRemovingSubPalindromes


As a container I considered using: HashSet or SortedSet
1. HashSet is better to check if palindorme already was added. It would be best for inputs with many repeted palindromes.
But it is implemented in .NET using arrays and extending/shrinking an array is very expensive. 
Hashset uses fixed primes for the array size. The first two values are: 3 and 7.
So if i kept only 3 longest palindromes and remove before add, I could avoid the array extending/shrinking. 
2. SortedSet is better to find the smallest one. It would be the best for inputs with small number of repeated palindromes.
it is implemented in .NET as black-red tree. In size of elements equal 3 we might avoid tree rebalancing. 

In my implmentation I keep all uniq palindromes in the memory (not only the N longest) so benefits of sortedset wouldn't be used. That's why i decided to use HashSet.
