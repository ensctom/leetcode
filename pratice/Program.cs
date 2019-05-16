using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace practice
{
    class Program
    {

        static void Main(string[] args)
        {

        }


        public static bool NeedleInHayStack(string needle, string haystack)
        {
            if (needle.Length > haystack.Length) return false;
            else
            {
                for (int i = 0; i < haystack.Length; i++)
                {
                    if (haystack[i] == needle[0] && i + needle.Length - 1 < haystack.Length)
                    {
                        for (int j = 0; j < needle.Length; j++)
                        {
                            if (j + 1 == needle.Length) return true;

                            if (haystack[i + j + 1] == needle[j + 1])
                            {
                                continue;
                            }
                            break;
                        }
                    }
                }
                return false;

            }


        }


        public static void KMPSubStringSearch()
        {
            //https://www.youtube.com/watch?v=GTJr8OvyEVQ

        }
        public static void FindElementInMatrixTest()
        {
            Tuple<int, int> results;
            int key;
            int[,] mat = new int[4, 4] {    {1, 2 , 11 ,17},
                                            {3, 7 , 23, 43},
                                            {5, 29, 41, 47},
                                            {31,37, 53, 59}  };
            key = 47;

            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(2, 3))) Console.WriteLine("Found {0}", key);

            key = 53;
            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(3, 2))) Console.WriteLine("Found {0}", key);

            key = 1;
            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(0, 0))) Console.WriteLine("Found {0}", key);

            key = 31;
            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(3, 0))) Console.WriteLine("Found {0}", key);

            key = 61;
            results = FindElementInMatrix(key, mat);
            if (results == null) Console.WriteLine("Found {0}", key);

            mat = new int[2, 4] {    {1, 2 , 11 ,17},
                                     {3, 7 , 23, 43}, };

            key = 3;
            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(1, 0))) Console.WriteLine($"Found {0}", key);

            key = 1;
            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(1, 0))) Console.WriteLine($"Found {0}", key);

            key = 25;
            results = FindElementInMatrix(key, mat);
            if (results.Equals(Tuple.Create(1, 0))) Console.WriteLine($"Found {0}", key);

        }
        public static Tuple<int, int> FindElementInMatrix(int element, int[,] matrix)
        {

            int i = 0, j = matrix.GetLength(1) - 1;

            while (i < matrix.GetLength(0) && j >= 0)
            {
                if (element == matrix[i, j]) return Tuple.Create(i, j);

                if (element > matrix[i, j])
                {
                    i++;
                }
                else
                {
                    j--;
                }

            }

            return null;

        }

    }
}



