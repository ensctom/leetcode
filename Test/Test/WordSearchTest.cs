using practice.Problems;
using Test.TestData;
using Xunit;

namespace Test
{
    public class WordSearchTest
    {
        [Theory, ClassData(typeof(WordSearchTestData))]
        public void DoesWordExistTestDFSRecursive(char[][] board, string word, bool expected)
        {
            Assert.Equal(expected, WordSearch.DoesWordExist(board, word));
        }

        [Theory, ClassData(typeof(WordSearchTestData))]
        public void DoesWordExistTestDFSIterative(char[][] board, string word, bool expected)
        {
            Assert.Equal(expected, WordSearch.DoesWordExistIterative(board, word));
        }
    }
}
