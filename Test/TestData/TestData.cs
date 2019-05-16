using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestData
{
    public class TestData
    {
        public class MergeTwoArrayTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 1,2,3 }, new int[] { 1,2,3 }, new int[]{ 1,1,2,2,3,3 }},
                new object[] { new int[]{ 1,4,6 }, new int[] { 1,2,3 }, new int[]{ 1,1,2,3,4,6 }}
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }

        }
        public class MergeKArrayTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new List<int[]> {
                    new int[]{ 1,4,7 },
                    new int[]{ 2,5,8 },
                    new int[]{ 3,6,9 }} , /* expected */new int[]{ 1,2,3,4,5,6,7,8,9 }
                },
                new object[] { new List<int[]> {
                    new int[]{ 1,2,3 },
                    new int[]{ 1,5,6 },
                    new int[]{ 1,8,9 }} , /* expected */new int[]{ 1,1,1,2,3,5,6,8,9 }
                },
                new object[] { new List<int[]> {
                    new int[]{ 1, 3 },
                    new int[]{ 2, 4, 6 },
                    new int[]{ 0, 9, 10, 11}} , /* expected */new int[]{ 0, 1, 2, 3, 4, 6, 9, 10, 11 }
                }

            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }

        }
        
        public class FindNumberOfSetsThatAddUpToASumTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 2,4,6,10 }, 16 , 2},
                new object[] { new int[]{ 1,1,1,1,1 }, 5, 1},
                new object[] { new int[]{ 1,1,1,1,1 }, 10, 0},
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }

        }

        public class FindTwoNumberThatAddUpToASumTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 2,4,6,10 }, 16 , 2},
                new object[] { new int[]{ 1,1,1,1,1 }, 5, 1},
                new object[] { new int[]{ 1,1,1,1,1 }, 10, 0},
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

        public class CoinAdjTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 1,0 }, 1},
                new object[] { new int[]{ 0,0 }, 0},
                new object[] { new int[]{ 1,1,0,1,0,0 }, 4 },
                new object[] { new int[]{ 1,1,1,1,1 }, 3},
                new object[] { new int[]{ 1,1,1,0,1 }, 4},
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }


        /// <summary>
        /// Given an array a, find the total number of hills and and valleys
        /// For example a = [ 1, 2, 2, 0]
        ///
        ///   _ _
        /// _|   |
        ///      |_
        ///  your function should return '3' ( there are 2 valleys and 1 hill)
        /// </summary>
        public class HillAndValleyTestData : IEnumerable<object[]>
        {

            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 1, 2, 2, 0 }, 3},
                new object[] { new int[]{ 1 }, 1},
                new object[] { new int[]{ -1 }, 1},
                new object[] { new int[]{ 0 }, 1},
                new object[] { new int[]{ 0 }, 1},
                new object[] { new int[]{ -3,3 }, 2},
                new object[] { new int[]{ 2,2,3,4,3,3,2,2,1,1,2,5 }, 4 },
                new object[] { new int[]{ 5,0 }, 2},
                new object[] { new int[]{ 1,-1,1,-1,1 }, 5},
                new object[] { new int[]{ -1,-1,1,-1,-3,-5,-2,1,-1 }, 5},
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/new-year-chaos/problem
        /// </summary>
        public class MinimumBribesTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 1, 2, 3, 4 }, 0},
                new object[] { new int[]{ 1 }, 0},
                new object[] { new int[]{ 3, 4, 2, 1 }, 5},
                new object[] { new int[]{ 4, 3, 2, 1 }, -1},
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }
        public class MinimumSwapsTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{ 4, 3, 1, 2 }, 3},
                new object[] { new int[]{ 2, 3, 4, 1, 5 }, 3},
                new object[] { new int[]{ 1, 3, 5, 2, 4, 6, 7 }, 3},
                new object[] { new int[]{ 3, 7, 6, 9, 1, 8, 10, 4, 2, 5 }, 9},
                new object[] { new int[]{ 2, 31, 1, 38, 29, 5, 44, 6, 12,
                                          18, 39, 9, 48, 49, 13, 11,
                                          7, 27, 14, 33, 50, 21, 46, 23,
                                          15, 26, 8, 47, 40, 3, 32, 22,
                                          34, 42, 16, 41, 24, 10, 4, 28,
                                          36, 30, 37, 35, 20, 17, 45, 43, 25, 19 }, 46},


            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

        public class LongestPalidromeTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { "taco", 1},
                new object[] { "geek", 2},
                new object[] { "tacocat", 7},
                new object[] { "", null},
                new object[] { "t", 1},

            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

        public class CountDistinctPalidromicSubstringTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { "abaaa", 5}, // a, b, aa, aaa, aba
                new object[] { "ee", 2}, // e, ee
                new object[] { "geek", 4}, // g, e, k , ee
                new object[] { "tacocat", 7}, // t, a, c, o, coc, acoca, tacocat
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

        public class CustomSubstringByIndexMethod : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { "tacocat", "t", 0, 1},
                new object[] { "geek", "gee", 0, 3},

            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }
    
        public class BuyAndSellStocksAsManyTimesTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[] {10, 2, 1, 8, 14, 3, 5}, 15},  //max profit is 15 becuase you buy@1, sell@14, buy@3, sell@5
                new object[] { new int[] {3, 10, 5, 8, 14, 3, 5}, 18},
                new object[] { new int[] { 2, 3, 5, 6, 10}, 8}, //max profit is 8 buy@2, sell@10
                new object[] { new int[] { 10, 5, 1}, 0},
                new object[] { new int[] { 10, 10, 10}, 0}//maxprofit is 0

            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

        public class NumberOfIslandTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new char[][] {
                    new char[]{'1', '1'},
                    new char[]{'1', '1'}, }, 1 },
                new object[] { new char[][] {
                    new char[]{'0', '1', '1'} }, 1 },
                new object[] { new char[][] {
                    new char[]{'1', '1', '1', '0' },
                    new char[]{'1', '1', '1', '0' },
                    new char[]{'1', '1', '1', '0' },
                    new char[]{'1', '1', '1', '0' } }, 1},
                new object[] { new char [][] {
                    new char[]{ '1','1','1','1','0' },
                    new char[]{ '1','1','0','1','0'},
                    new char[]{ '1','1','0','0','0' },
                    new char[]{ '0','0','0','0','0' },} , 1 }


            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)_data).GetEnumerator();
            }
        }

    }
}
