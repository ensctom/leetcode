using impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice.Problems
{
    public static class CoinChange2
    {
        public static int GetChangeRecursive(int amount, int[] coins) {
            return GetChangeHelper(coins, amount, 0, new Dictionary<string, int>());
        }

        private static int GetChangeHelper(int[] coins, int amount, int k, Dictionary<string, int> dictionary)
        {
            if (amount == 0)
                return 1;
            if (k == coins.Length)
                return 0;
            string key = amount + "-" + k;
            if (dictionary.ContainsKey(key))
                return dictionary[key];

            int res = 0;
            int curAmount = 0;
            while ( amount >= curAmount)
            {
                int remaining = amount - curAmount;
                res += GetChangeHelper(coins, remaining, k + 1, dictionary);
                curAmount += coins[k];
            }
            dictionary.Add(key, res);
            return res;
        }

        public static int GetChangeDp(int amount, int[] coins)
        {
            return 0;
        }

    }
}
