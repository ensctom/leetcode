using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Test
{
    public class WordLadderTest
    {
        [Theory, ClassData(typeof(WordLadderTestData))]
        public void FindLaddersTest(string startWord, string endword, List<string> wordList, List<List<string>> answers)
        {

            var results = practice.Problems.WordLadder.FindLadders(startWord, endword, wordList);
            foreach (var answer in answers)
            {
                Assert.Contains(results, x => x.SequenceEqual(answer));
            }

            Assert.Equal(answers.Count, results.Count);
        }
    }

}
