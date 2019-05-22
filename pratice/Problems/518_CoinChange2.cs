using impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice.Problems
{
    public static class CoinChange2
    {
        /* 
         * https://leetcode.com/problems/coin-change-2
         The idea of sovling this problem with DP is creating a 2D table
         for example, if we were given the coins[] = [1,2,3,5] and the amount = 6
         we can construct the following table
                        0   1   2   3   4   5   6    
                        -------------------------
            [1]         1   1   1   1   1   1   1
            [1,2]       1   1   2   2   3   3   4
            [1,2,3]     1   1   2   3   4   5   7
            [1,2,3,5]   1   1   2   3   4   6   8

            so we know that the number of distinct ways to get change is 8
        
             */
        public static int GetChangeIterativeDP(int amount, int[] coins)
        {
            // the run time complexity of this solution is O(m*n) where m is the number of coins in array and n is the amount
            // space complexity is O(m*n)
            if (coins.Length == 0 && amount == 0)
                return 1;
            if (coins.Length == 0 && amount != 0)
                return 0;
            int n = coins.Length;
            int[,] table = new int[n, amount+1];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j <= amount; j++)
                {
                    if (j == 0)
                    {
                        //prepopulate table
                        table[i, j] = 1;
                    }
                    else if(i == 0)
                    {
                        //prepopulate table
                        if(j % coins[i] != 0)
                        {
                            table[i, j] = 0;
                        }
                        else
                        {
                            table[i, j] = 1;
                        }
                    }
                    else
                    {
                        if(j < coins[i])
                        {
                            //copy values in the previous row
                            table[i, j] = table[i - 1, j];
                        }
                        else
                        {
                            table[i, j] = table[i - 1, j] + table[i, j - coins[i]];
                        }

                    }
                }
            }

            return table[n-1, amount];
        }

        public static int GetChangeOptimizedIterativeDP(int amount, int[] coins)
        {
            // the run time complexity of this solution is O(m*n) where 'm' is the number of coins in array and 'n' is the amount
            // space complexity is O(n)
            if (coins.Length == 0 && amount == 0)
                return 1;
            if (coins.Length == 0 && amount != 0)
                return 0;

            int[] table = new int[amount + 1];

            table[0] = 1;

            for(int i = 0; i < coins.Length; i++)
            {
                for(int j = coins[i]; j <= amount; j++)
                {
                    table[j] = table[j] + table[j - coins[i]];
                }
            }

            return table[amount];
        }

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
