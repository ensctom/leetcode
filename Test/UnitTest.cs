using Xunit;
using impl;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using practice.DataStructure;
using static TestData.TestData;

namespace Test
{
    public class UnitTest
    {

        [Fact]
        public void FindFirstDuplicateWordInStringTest()
        {
            string input = "The The";
            Assert.Equal("The", Implementation.FindFirstDuplicateWordInString(s: input));

            input = "Hands-free headset for your hands";
            Assert.True(Implementation.FindFirstDuplicateWordInString(s: input) == null);

            input = "hands-free headset for your hands";
            Assert.Equal("hands", Implementation.FindFirstDuplicateWordInString(s: input));

            input = "fox jumped over the moon, box, fox, fence";
            Assert.Equal("fox", Implementation.FindFirstDuplicateWordInString(s: input));

            input = "How much wood. can a wood\\chuck chuck of a woodchuck could chuck wood?";
            Assert.Equal("wood", Implementation.FindFirstDuplicateWordInString(s: input));

            input = "";
            Assert.True(Implementation.FindFirstDuplicateWordInString(s: input) == null);
        }

        [Theory, ClassData(typeof(MergeTwoArrayTestData))]
        public void MergeTwoSortedArraysTest(int[] a, int[] b, int[] expected)
        {
            Assert.Equal(expected, Implementation.MergeTwoSortedArray(a, b));
        }

        [Theory, ClassData(typeof(MergeKArrayTestData))]
        public void MergeKSortedArraysTest(List<int[]> arrList, int[] expected)
        {
            Assert.Equal(expected, Implementation.MergeKSortedArray(arrList));
        }

        [Theory, ClassData(typeof(MergeTwoArrayTestData))]
        public void MergeTwoSortedListTest(int[] a, int[] b, int[] expected)
        {
            Assert.Equal(expected.Cast<int>().ToList(), Implementation.MergeTwoSortedList(a.Cast<int>().ToList(), b.Cast<int>().ToList()));
        }

        [Theory, ClassData(typeof(FindNumberOfSetsThatAddUpToASumTestData))]
        public void FindNumberOfSetsThatAddUpToASumTest(int[] a, int sum, int expectedSets)
        {
            Assert.Equal(expectedSets, Implementation.FindNumberOfSetsThatAddUpToASum(a, sum));
        }

        [Theory, ClassData(typeof(CoinAdjTestData))]
        public void CoinAdjTest(int[] a,int expectedResult)
        {
            Assert.Equal(expectedResult, Implementation.AdjacentCoins(a));
        }

        [Theory, ClassData(typeof(HillAndValleyTestData))]
        public void HillAndValleyTest(int[] a, int expectedResult)
        {
            Assert.Equal(expectedResult, Implementation.ValleysAndHills(a));
        }

        [Theory, ClassData(typeof(MinimumBribesTestData))]
        public void MinimumBribesTest(int[] a, int expectedResult)
        {
            Assert.Equal(expectedResult, Implementation.MinimumBribes(a));
        }

        [Theory, ClassData(typeof(MinimumSwapsTestData))]
        public void MinimumSwapsTest(int[] a, int expectedResult)
        {
            Assert.Equal(expectedResult, Implementation.MinimumSwaps(a));
        }

        [Theory, ClassData(typeof(LongestPalidromeTestData))]
        public void LongestPalindromeTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, Implementation.LongestPalidromicSubstringDP(s));
        }

        [Theory, ClassData(typeof(CountDistinctPalidromicSubstringTestData))]
        public void CountDistinctPalidromicSubstringTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, Implementation.CountDistinctPalidromicSubstringDP(s));
        }
     
        [Theory, ClassData(typeof(BuyAndSellStocksAsManyTimesTestData))]
        public void BuyAndSellStocksAsManyTimesTest(int[] a, int expectedMaxProfit)
        {
            Assert.Equal(expectedMaxProfit, Implementation.BuyAndSellStocksAsManyTimes(a));
        }

        [Theory, ClassData(typeof(NumberOfIslandTestData))]
        public void NumIslandTest(char[][] a, int numIsland)
        {
            Assert.Equal(numIsland, Implementation.NumIsland(a));
        }

        [Fact]
        public void MergeTest()
        {
            int[] nums1 = new int[] { 0 };
            int[] nums2 = new int[] { 1 };
            //Assert.Equal(new int[] { 1 }, Implementation.Merge(nums1, 0, nums2, 1));


        }

        [Fact]
        public void AddTwoNumbersTest()
        {
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(4);
            ListNode l3 = new ListNode(3);
            l1.next = l2;
            l2.next = l3;

            ListNode m1 = new ListNode(5);
            ListNode m2 = new ListNode(6);
            ListNode m3 = new ListNode(4);
            m1.next = m2;
            m2.next = m3;

            ListNode n1 = new ListNode(7);
            ListNode n2 = new ListNode(0);
            ListNode n3 = new ListNode(8);
            n1.next = n2;
            n2.next = n3;

            Assert.Equal(n1, Implementation.AddTwoNumbers(l1, m1));
        }

        [Fact]
        public void CustomHashMap()
        {
            CustomHashMap map = new CustomHashMap(3);
            map.Put(21);
            map.Put(2);
            map.Put(9);
            map.Put(19);
            map.Put(8);
            map.Put(1);
            //your output should be [ 1->null, 19-> 1-> null, 2->8-> null, 21->9->null, null, null]

            ListNode[] ans = new ListNode[6]
            {
                null,
                new LinkedList(new int[2] {19,1}).Head(),
                new LinkedList(new int[2] {2,8}).Head(),
                new LinkedList(new int[2] {21,9}).Head(),
                null,
                null,
            };

            for(int i = 0; i < ans.Length; i++)
            {
                ListNode ansNode = ans[i];
                ListNode implNode = map.list[i];
                if (ansNode == null)
                    Assert.Equal(ansNode, implNode);
                while ( ansNode != null)
                {
                    Assert.Equal(ansNode.val, implNode.val);
                    ansNode = ansNode.next;
                    implNode = implNode.next;
                }
            }

        }
    }
}
