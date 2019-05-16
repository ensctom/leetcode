using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Test.TestData
{
    public class WordSearchTestData : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { 
                new char[][]
                {
                    new char[] { 'c', 'a', 'a' },
                    new char[] { 'a' , 'a', 'a'},
                    new char[] { 'b', 'c', 'd'} 
                }, "aab" ,true
            },
            new object[] {
                new char[][]
                {
                    new char[] { 'a', 'b', 'c', 'e' },
                    new char[] { 's' , 'f', 'e', 's'},
                    new char[] { 'a', 'd', 'e' , 'e'}
                }, "abceseeefs" ,true
            },
            new object[] {
                new char[][]
                {
                    new char[] { 'a', 'b', 'c', 'e' },
                    new char[] { 's' , 'f', 'c', 's'},
                    new char[] { 'a', 'd', 'e' , 'e'}
                }, "abcced" ,true
            },
            new object[] {
                new char[][]
                {
                    new char[] { 'a', 'b', 'c', 'e' },
                    new char[] { 's' , 'f', 'c', 's'},
                    new char[] { 'a', 'd', 'e' , 'e'}
                }, "abccede" , false
            },
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

    }
}
