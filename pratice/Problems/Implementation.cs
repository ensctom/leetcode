using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Specialized;
using practice.DataStructure;

namespace impl
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class LRUCache
    {

        private int capacity;
        private Dictionary<int, int> cache = new Dictionary<int, int>();
        private List<int> order = new List<int>();


        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                var index = order.IndexOf(key);
                order.RemoveAt(index);
                order.Add(key);
                return cache[key];
            }
            else
            {
                return -1;
            }

        }

        public void Put(int key, int value)
        {

            if (cache.ContainsKey(key))
            {
                //update value
                //move it to end of orer
                var index = order.IndexOf(key);
                order.RemoveAt(index);
                order.Add(key);

            }
            else
            {
                //insert
                cache.Add(key, value);
                //order.Add(key);
                if (cache.Count > capacity)
                {
                    var keyToDelete = order[0];
                    order.RemoveAt(0);
                    cache.Remove(keyToDelete);
                }
            }

        }
    }
    public class CustomHashMap{

        public ListNode[] list;
        int size = 0;
        public CustomHashMap(int capacity)
        {
            list = new ListNode[capacity];
        }
        public void Put(int key)
        {
            int index = Hash(key, list.Length);
            if(size >= list.Length)
            {
                list = DynamicResizing(list);
            }
            //check if listNode 
            InsertNode(list, index, key);
            size++;
        }
        public ListNode[] DynamicResizing(ListNode[] a)
        {
            if (a == null)
                return null;
            int newSize = a.Length * 2;

            ListNode[] newList = new ListNode[newSize];

            for(int i = 0; i < a.Length; i++)
            {
                if( a[i] != null)
                {
                    ListNode curNode = a[i];

                    while (curNode != null)
                    {
                        int key = curNode.val;
                        int index = Hash(key, newSize);

                        InsertNode(newList, index, key);

                        curNode = curNode.next;
                    }
                }        
            }

            return newList;

        }
        public int Hash(int key, int capacity)
        {
            //very simple hashing function
            return key % capacity;
        }
        private void InsertNode(ListNode[] list, int index, int key)
        {
            if (list[index] == null)
            {
                list[index] = new ListNode(key);
            }
            else
            {
                //traverse to the end of that bucket
                ListNode x = list[index];
                while (x.next != null)
                {
                    x = x.next;
                }
                x.next = new ListNode(key);
            }
        }
    }
    public class Implementation
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            //trival to sort the array and then return the kth largest 
            // runtime nlogn
            /*
            Array.Sort(nums);
            return nums[nums.Length-k];
            */

            //use max heap and return element 
            //in c# there is no priority queue or default heap class, so we can use a sortedlist or sortedset

            SortedList pq = new SortedList();
            SortedSet<int> heap = new SortedSet<int>();
            foreach (var num in nums)
            {
                heap.Add(num);
                pq.Add(num, num);
                if( heap.Count > k)
                {
                    heap.Remove(heap.First());
                }
                if( pq.Count > k)
                {
                    pq.RemoveAt(0);
                }
            }
            return (int)pq.GetByIndex(0);
            //return heap.First();
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {

            List<IList<int>> sol = new List<IList<int>>();

            if (root == null)
                return sol;

            Queue<TreeNode> q = new Queue<TreeNode>();
            int level = 0;
            q.Enqueue(root);
            //BFS
            while (q.Count != 0)
            {

                sol.Add(new List<int>());
                int qSize = q.Count;
                Console.WriteLine("count" + q.Count);
                for (int i = 0; i < qSize; i++)
                {
                    TreeNode currNode = q.Dequeue();
                    Console.WriteLine(string.Format("i:{0} level:{1} Node.Val {2}", i, level, currNode.val));
                    sol[level].Add(currNode.val);

                    if (currNode.left != null)
                        q.Enqueue(currNode.left);
                    if (currNode.right != null)
                        q.Enqueue(currNode.right);

                }

                level++;


            }

            return sol;
        }
        public bool IsValidBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            double minVal = double.MinValue;

            while (stack.Count != 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();

                if (root.val <= minVal)
                    return false;
                minVal = root.val;
                root = root.right;
            }

            return true;
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                char[] c = str.ToCharArray();
                Array.Sort(c);

                string key = new String(c);
                if (!map.ContainsKey(key))
                    map.Add(key, new List<string>());
                map[key].Add(str);
            }

            return new List<IList<string>>(map.Values);

        }
        public static bool BalancedBraces(string str)
        {
            Stack<char> s = new Stack<char>();

            foreach (var c in str)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    s.Push(c);
                }
                else
                {
                    if (s.Count > 0)
                    {
                        var x = s.Pop();
                        if (c == ')' && x != '(')
                            return false;
                        if (c == ']' && x != '[')
                            return false;
                        if (c == '}' && x != '{')
                            return false;
                    }
                    else
                        return false;
                }
            }
            if (s.Count != 0)
                return false;
            return true;
        }
        public static int[] ProductExceptSelfNoDivision(int[] nums)
        {
            //https://leetcode.com/problems/product-of-array-except-self/
            //a posisble follow up question is requiring you to solve this without using /
            //take for example [1,2,3,4,5,6]
            //the idea is to look at each element and expand left and right
            // 1, 2, 3, 4
            // ^
            // product 2, 3, 4
            // 1, 2, 3, 4
            //    ^
            // product 1, 3, 4
            // however this would be O(n * n-1) in time complexity
            // to make it run O(n) we run can store the previous product in an array (dp)
            // left array =  [1,    1,     2,   6, 24, 120] start at i = 0
            // right array = [720, 360,  120,  30,  6,   1]  start at i = n-1

            // output aray is [720,360,240,180, 144,120]

            int[] resLeft = new int[nums.Length];
            resLeft[0] = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                resLeft[i] = resLeft[i - 1] * nums[i - 1];
            }

            int right = 1;
            int[] resRight = new int[nums.Length];
            for (int i = nums.Length -1; i >=0; i--)
            {
                resRight[i] = right;
                right *= nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                resLeft[i] = resLeft[i] * resRight[i];
            }

            return resLeft;

        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            //Given an array nums of n integers where n > 1, 
            //return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
            //https://leetcode.com/problems/product-of-array-except-self/
            //a posisble follow up question is requiring you to solve this without using /
            int sum = 1;
            int zero = 1;
            int numZero = 0;

            foreach (var num in nums)
            {
                if (num == 0)
                {
                    zero = 0;
                    numZero++;
                }

                else
                    sum *= num;
            }

            if (numZero > 1) return new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    nums[i] = sum;
                else
                    //nums[i] = (int) (zero * sum * Math.Pow(nums[i], -1));
                    nums[i] = zero * sum / nums[i];
            }
            return nums;

        }
        public static int BasicCalculator(string s)
        {
            Stack<int> stack = new Stack<int>();
            int sum = 0;
            int number = 0;
            int sign = 1;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (char.IsDigit(c))
                {
                    //to take care of multi digit number eg. 100
                    number = 10 * number + Convert.ToInt32(c) - 48;  //48 is the ascii eq of '0'
                }
                else if (c == '+')
                {
                    sum += sign * number;
                    number = 0;
                    sign = 1;
                }
                else if (c == '-')
                {
                    sum += sign * number;
                    number = 0;
                    sign = -1;
                }
                else if (c == '(')
                {
                    //we push the result first, then sign;
                    stack.Push(sum);
                    stack.Push(sign);
                    //reset the sign and result for the value in the parenthesis
                    sign = 1;
                    sum = 0;
                }
                else if (c == ')')
                {
                    sum += sign * number;
                    number = 0;
                    sum *= stack.Pop();    //stack.pop() is the sign before the parenthesis
                    sum += stack.Pop();   //stack.pop() now is the result calculated before the parenthesis

                }
            }
            if (number != 0) sum += sign * number;
            return sum;
        }
        public static int FirstUniqChar(string s)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (var c in s)
            {
                map.TryGetValue(c, out int value);
                map[c] = value + 1;
            }

            char[] arr = s.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (map[arr[i]] == 1)
                    return i;
            }

            return -1;
        }

        public int MinPathSum(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;
            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    if (i == 0)
                    {
                        matrix[i, j] = ValueLeft(matrix, i, j) + grid[i][j];
                    }
                    else if (j == 0)
                    {
                        matrix[i, j] = ValueTop(matrix, i, j) + grid[i][j];
                    }
                    else
                    {
                        matrix[i, j] = Math.Min(ValueLeft(matrix, i, j), ValueTop(matrix, i, j)) + grid[i][j];
                    }

                }
            }
            return matrix[row - 1, col - 1];
        }

        int ValueLeft(int[,] matrix, int i, int j)
        {
            //if value exists
            if (j - 1 >= 0)           
                return matrix[i, j - 1];
            else
                return 0;
        }
        int ValueTop(int[,] matrix, int i, int j)
        {
            //if value exists
            if (i - 1 >= 0)
                return matrix[i - 1, j];
            else
                return 0;
        }
        public static int NumIsland(char[][] grid)
        {
            //https://leetcode.com/problems/number-of-islands
            //run time o(n*m) where n = #rows and m = #columns
            //space is o(min(n,m))
            int numIsland = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            for(int r = 0; r< rows; r++)
            {
                for(int c = 0; c< cols; c++)
                {
                    if( grid[r][c] == '1')
                    {
                        numIsland++;
                        grid[r][c] = '0';

                        Queue<int> neighbours = new Queue<int>();
                        neighbours.Enqueue(cols * r + c);//add current position interms of an 1d array
                        while (neighbours.Count != 0)
                        {
                            int item = neighbours.Dequeue();
                            //find current row and column
                            int cur_row = item / cols;
                            int cur_col = item % cols;

                            //chk down and up
                            if( cur_row + 1 < rows && grid[cur_row+1][cur_col] == '1')
                            {
                                grid[cur_row + 1][cur_col] = '0';
                                neighbours.Enqueue(cols * (cur_row + 1) + cur_col);
                            }
                            if (cur_row -1 >= 0 && grid[cur_row - 1][cur_col] == '1')
                            {
                                grid[cur_row - 1][cur_col] = '0';
                                neighbours.Enqueue(cols * (cur_row - 1) + cur_col);
                            }

                            //chk right and left
                            if (cur_col + 1 < cols && grid[cur_row][cur_col + 1] == '1')
                            {
                                grid[cur_row][cur_col + 1] = '0';
                                neighbours.Enqueue(cols * cur_row + cur_col + 1);
                            }
                            if (cur_col - 1 >= 0 && grid[cur_row][cur_col - 1] == '1')
                            {
                                grid[cur_row][cur_col - 1] = '0';
                                neighbours.Enqueue(cols * cur_row + cur_col -1);
                            }
                        }
                    }
                }
            }
            return numIsland;
        }
        public static int NumUniqueEmails(string[] emails)
        {
            //https://leetcode.com/problems/unique-email-addresses/
            // given a list of email addresses
            // get local/domain strings for each email
            // in each local, if + exists, local = local.Split(location of +)[0]
            // in each local, if . exists, remove all .
            // store local@domain in new list of string[] finalEmails if it doesn't exist in finalEmails
            HashSet<string> set = new HashSet<string>();
            foreach (string email in emails)
            {
                string local = email.Split('@')[0];
                string domain = email.Split('@')[1];

                if(local.IndexOf('+') > 0)
                {
                    local = local.Split('+')[0];
                }
                if(local.IndexOf('.') > 0)
                {
                    local = local.Replace(".", string.Empty);
                }
                string _email = local + "@" + domain;

                if(!set.Contains(_email))
                {
                    set.Add(_email);
                }              
            }
            return set.Count;
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            string a = "", b = "";

            //traverse l1
            ListNode currNode = l1;
            while (currNode != null)
            {
                a += currNode.val.ToString();
                currNode = currNode.next;
            }

            currNode = l2;
            while (currNode != null)
            {
                b += currNode.val.ToString();
                currNode = currNode.next;
            }

            char[] temp = a.ToCharArray();
            Array.Reverse(temp);
            a = new string(temp);

            temp = b.ToCharArray();
            Array.Reverse(temp);
            b = new string(temp);

            temp = (Int32.Parse(a) + Int32.Parse(b)).ToString().ToCharArray();
            Array.Reverse(temp);
            string c = new string(temp);
               
            ListNode head = currNode = null;
            int i = 0;

            foreach(char x in c.ToCharArray())
            {

                if (i == 0)
                {
                    head = currNode = new ListNode(Int32.Parse(x.ToString()));
                }
                else
                {
                    ListNode newNode = new ListNode((int)x);
                    currNode.next = newNode;
                    currNode = newNode;
                }
                i++;
            }

            return head;

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m">number of non zero element</param>
        /// <param name="nums2"></param>
        /// <param name="n">number of element in nums2</param>
        /// <returns></returns>
        public static int[] MergeTwoArrayVariation(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = n + m - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }

            }

            while (i >= 0)
            {
                nums1[k--] = nums1[i--];
            }

            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
            return nums1;

        }
        public static int CoinChange(int[] arr, int sum)
        {
            //assuming arr is always = [1, 5, 10, 25]
            //todo: generalize solution
            int solution = 0;
            int n = arr.Length - 1;

            for(int a = (sum / arr[n]); a >=0; a--)
            {
                for(int b = ((sum - a * arr[n])/arr[n-1]); b >= 0; b--)
                {
                    for(int c = ((sum - a * arr[n] - b * arr[n-1]) / arr[n - 2]); c >= 0; c-- )
                    {
                        int d = sum - ((sum - a * arr[n] - b * arr[n - 1]) - c * arr[n-2] / arr[n - 3]);
                        solution++;
                    }
                }
            }

            return solution;
        }
        public static int MaxSubarray(int[] a)
        {
            //Kadane's algo DP solution
            int maxCurrent = 0, maxSum = 0;

            for (int i = 0; i < a.Length -1; i++)
            {
                maxCurrent = Math.Max(a[i], maxCurrent + a[i]);

                if (maxCurrent > maxSum)
                    maxSum = maxCurrent;

            }

            return maxSum;
        }

        public static int[] ZeroSumSubarray()
        {
            return null;
        }

        public static int[] FindKMissingNumbersSortedArray(int[] a, int b)
        {
            //Assumption 'a' is a sorted array starting from 1....n
            int[] missingNums = new int[b-1];
            int j = 0, i = 0, n = 0;
            
            while(i < a[a.Length - 1])
            {
                if( a[n] != j)
                {
                    //found missing 
                    missingNums[j++] = a[n];
                }

                i++;
            }

            return null;
        }

        public static int[] FindKMissingNumbersUnsortedArray(int[] a, int k)
        {
            return null;
        }

        public static int BuyAndSellStockOnce(int[] a)
        {
            if (a.Length <= 1)
                return 0;

            int profit = 0;
            int lowestPrice = a[0];

            for (int i = 0; i< a.Length - 1; i++)
            {
                if(a[i] < lowestPrice)
                    lowestPrice = a[i];
                if (a[i+1] - lowestPrice > profit)
                    profit = a[i+1] - lowestPrice;
            }

            return profit;
        }
        public static int BuyAndSellStocksAsManyTimes(int[] a)
        {
            //time complexity O(n)
            //similar to max hills and valleys
            int maxProfit = 0, buyPrice = 0;
            bool localTop = true, localBot = true, sold = false; 

            for(int i = 0; i < a.Length-1; i++)
            {
                if(a[i+1] - a[i] > 0)
                {
                    if (localTop)
                    {
                        buyPrice = a[i];
                        localBot = true;
                        localTop = false;
                        sold = false;
                    }
                }
                else if(a[i+1] - a[i] < 0)
                {
                    if (buyPrice != 0 && localBot)
                    {
                        maxProfit += a[i] - buyPrice;
                        localBot = false;
                        localTop = true;
                        sold = true;
                    }
                }

            }

            if (!sold && buyPrice != 0)
                maxProfit += a[a.Length - 1] - buyPrice;

            return maxProfit;
        }
        public static int CountDistinctPalidromicSubstringDP(string s)
        {
            // time and space complexity is O(n^2)
            
            int n = s.Length;
            if (n == 0) return 0;

            HashSet<string> set = new HashSet<string>();
            bool[,] table = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if( s[i] == s[j] && (i-j <= 1 || table[i - 1, j + 1 ]))
                    {
                        table[i, j] = true;
                        set.Add(s.Substring(j, i - j + 1));
                    }
                }
            }

            return set.Count;

        }

        //This can be done in linear time using manacher's algorithm
        public static int LongestPalidromicSubstringDP(string s)
        {
            int n = s.Length;
            string res = "";

            bool[,] table = new bool[n, n];

            for(int i = n -1; i >=0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    //  <-   i--
                    //  _ _ (a) b b (a) _  currently evalulating s[a] == s[a] && (was the last seen element a palindrome
                    //            -> j++
                    table[i, j] = s[i] == s[j] && (j - i <= 1 || table[i + 1, j - 1]);
                    
                    if(table[i,j] && (j - i +1 > res.Length))
                    {
                        //res = s.SubstringByIndex(i, j + 1); for java
                        res = s.Substring(i, j - i + 1);
                    }
                }
            }
           
            return res.Length;
        }


        public static int MinimumSwaps(int[] arr)
        {
            int swaps = 0;
            
            int i = 0;
            int tmp, newIndex = 0;

            while(i < arr.Length)
            {
                if (arr[i] != i + 1)
                {
                    newIndex = arr[i] - 1;
                    tmp = arr[newIndex];
                    arr[newIndex] = arr[i];
                    arr[i] = tmp;
                    swaps++;
                }
                else
                {
                    i++;
                }
            }

            return swaps;
        }

        public static int MinimumBribes(int[] a)
        {
            int maxBribes = 2;
            int minBribes = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] > maxBribes + i + 1)
                {
                    return -1;
                }

                for (int j = Math.Max(0, a[i] - maxBribes); j < i; j++)
                    if (a[j] > a[i]) minBribes++;
            }
            return minBribes;
        }

        public static int ValleysAndHills(int[] a)
        {
            //https://leetcode.com/problems/wiggle-subsequence/
            if( a.Length < 1)
                return 0;
            int count = 1; // count is 1 because we need to add the very last hill/valley
            bool valley = true;
            bool hill = true;
            for (int i = 0; i < a.Length-1; ++i)
            {
                if (a[i+1] - a[i] > 0)
                {
                    //increasing slope
                    if (valley)
                    {
                        //found local valley
                        count++;
                        valley = false;
                        hill = true;
                    }

                }
                else if (a[i+1] - a[i] < 0)
                {
                    //decreasing slope
                    if (hill)
                    {
                        //found local hill
                        count++;
                        valley = true;
                        hill = false;
                    }
                }

            }

            return count;
        }

        public static int AdjacentCoins(int[] a)
        {
            int n = a.Length;
            int result = 0;

            //First pass thru finds max adj coins
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i] == a[i + 1] )
                    result = result + 1;
            }

            int r = -1;
            // change this from r = 0 to r = -1;

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                if (i > 0)
                {
                    if (a[i - 1] != a[i])
                        count = count + 1 ;
                    else
                        count = count - 1 ;
                }
                if (i < n - 1)
                {
                    if (a[i + 1] != a[i])
                        count = count + 1 ;
                    else
                        count = count - 1;
                }
                r = Math.Max(r, count);
            }
            return result + r ;
        }
        public static string FindFirstDuplicateWordInString(string s)
        {
            char[] deliminters = new char[] { ',', '-', '.', ' ', '\t', '\\' };
            string[] words = s.Split(deliminters, StringSplitOptions.RemoveEmptyEntries);
            //string[] words = s.Split(deliminters);
            if (string.IsNullOrEmpty(s)) { return null; }

            HashSet<string> set = new HashSet<string>();
            foreach (string word in words)
            {
                if (set.Contains(word))
                {
                    return word;
                }
                else
                {
                    set.Add(word);
                }
            }

            return null;
        }

        public static int[] MergeKSortedArray(List<int[]> arrList)
        {
            //assumption: array elements in arrList are size n 
            //            k is the # of elements in arrList
            //run time o(nk)
            //space complexity(nk)
            /*
            if (arrList.Count < 2)
                return null;
            int[] mergedArray = arrList[0];
            for(int i = 1; i< arrList.Count; i++) 
            {
                mergedArray = MergeTwoSortedArray(mergedArray, arrList[i]);
            } */

            //solution 2: instead of merging each list 1 by 1, we can merge them 2 at a time
            //this will reduce the run time to o(nlogk)
            
            int k = 1;
        
            while(k < arrList.Count){
                for(int i = 0 ; i+k < arrList.Count ; i= i+ k*2){
                    arrList[i] = MergeTwoSortedArray(arrList[i], arrList[i+k]);
                }
                k = k * 2;       
            }

            return arrList[0];
             

            //return mergedArray;
        }

        /// <summary>
        ///        Given two ascendingly sorted arrays 'a' and 'b'.       
        ///        Return a merged array that is also ascendingly sorted
        /// </summary>

        public static int[] MergeTwoSortedArray(int[] a, int[] b)
        {

            //assumption size of a and b are the same - denoted by n
            //run time o(n)
            //space o(n)
            int[] mergedArray = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;

            while (j < a.Length && k < b.Length)
            {
                if (a[j] < b[k])
                {
                    mergedArray[i] = a[j];
                    j++;
                }
                else
                {
                    mergedArray[i] = b[k];
                    k++;
                }

                i++;
            }

            while (j < a.Length)
            {
                mergedArray[i] = a[j];
                i++;
                j++;
            }

            while (k < b.Length)
            {
                mergedArray[i] = b[k];
                i++;
                k++;
            }

            return mergedArray;

        }

        public static List<int> MergeTwoSortedList(List<int> a, List<int> b)
        {
            int j = 0, k = 0;
            List<int> solution = new List<int>(a.Count + b.Count);

            while (j < a.Count && k < b.Count)
            {
                if (a[j] < b[k])
                {
                    solution.Add(a[j]);
                    j++;
                }
                else
                {
                    solution.Add(b[k]);
                    k++;
                }
            }

            while (j < a.Count)
            {
                solution.Add(a[j]);
                j++;
            }

            while (k < b.Count)
            {
                solution.Add(b[k]);
                k++;
            }

            return solution;

        }

        public static int FindAllUnqiuePalindrome(string s)
        {
            int count = 0, n = s.Length;
            bool[,] dp = new bool [n,n];
            for (int d = 0; d < n; d++)
            {
                for (int i = 0; i + d < n; i++)
                {
                    int j = i + d;
                    if (s[i] == s[j])
                    {
                        dp[i,j] = (i + 1 >= j - 1) ? true : dp[i + 1, j - 1];
                        if (dp[i,j]) count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Determines whether or not an array has two numbers that add up to target sum
        /// </summary>
        /// <param name="a">array of ints</param>
        /// <param name="sum"></param>
        /// <returns>boolean</returns>
        public static bool FindTwoNumberThatAddUpToASum(int[] a, int sum)
        {
            HashSet<int> set = new HashSet<int>();

            foreach(int x in a)
            {
                if (set.Contains(x))
                {
                    return true;
                }
                else
                {
                    set.Add(sum - x);
                }
            }
            return false;

        }

        public static int[] FindTwoNumberThatAddUpToASumReturnIndex(int[] a, int sum)
        {
            // <index, value>
            Dictionary<int,int> map = new Dictionary<int,int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (map.ContainsKey(a[i]))
                {
                    return new int[] { map[a[i]], i };
                }
                else
                {
                    map.TryAdd(sum - a[i], i);
                }
            }
            return null;

        }

        public static int FindNumberOfSetsThatAddUpToASum(int[] a, int sum)
        {
            //use map as a way to memoize previous solutions
            IDictionary<string, int> map = new Dictionary<string, int>();
            return FindNumberOfSetsThatAddUpToASum_Dp(a, sum, a.Length - 1, map);
        }

        /*
         * https://www.youtube.com/watch?v=nqlNzOcnCfs
         Explaination: Given [2, 4, 6] we want to find all unique sets which has a sum = 6
                        {2, 4} , {6}
             */
        private static int FindNumberOfSetsThatAddUpToASum_Dp(int[] a, int sum, int i, IDictionary<string, int> map)
        {
            int val = 0;
            string key = sum.ToString() + ':' + i.ToString();
            if (map.ContainsKey(key)){
                return map[key];
            }
            if (sum == 0)
                return 1;
            else if (sum < 0 || i < 0)
                return 0;
            else if (sum < a[i])
                val = FindNumberOfSetsThatAddUpToASum_Dp(a, sum, i - 1, map);
            else
                val = FindNumberOfSetsThatAddUpToASum_Dp(a, sum - a[i], i - 1, map) 
                    + FindNumberOfSetsThatAddUpToASum_Dp(a, sum, i - 1, map);
            map[key] = val;

            return val;
        }

        
    }

}
