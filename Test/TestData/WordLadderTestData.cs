using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class WordLadderTestData : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "cat", "tag",
                new List<string>(new string[]{"pat", "fat", "pad", "fad", "lad", "lay", "lab", "tay", "tab", "tag"}),
                new List<List<string>>
                {
                    new List<string>( new string[] { "cat", "fat", "fad", "lad", "lab", "tab", "tag" } ),
                    new List<string>( new string[] { "cat", "fat", "fad", "lad", "lay", "tay", "tag" } ),
                    new List<string>( new string[] { "cat", "pat", "pad", "lad", "lab", "tab", "tag" } ),
                    new List<string>( new string[] { "cat", "pat", "pad", "lad", "lay", "tay", "tag" } ),
                }
            },
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        
    }
}
