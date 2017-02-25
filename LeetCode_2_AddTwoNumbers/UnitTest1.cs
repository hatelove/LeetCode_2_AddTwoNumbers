using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LeetCode_2_AddTwoNumbers
{
    [TestClass]
    public class UnitTest1
    {
        //You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        //Output: 7 -> 0 -> 8

        [TestMethod]
        public void L1_is_1_and_L2_is_2_should_return_val_is_3()
        {
            var l1 = new ListNode(1);
            var l2 = new ListNode(2);

            var expected = new ListNode(3);

            AssertResult(l1, l2, expected);
        }

        private static void AssertResult(ListNode l1, ListNode l2, ListNode expected)
        {
            var actual = new Solution().AddTwoNumbers(l1, l2);

            expected.All().ToExpectedObject().ShouldEqual(actual.All());
        }

        [TestCategory("l1, l2 長度為1")]
        [TestMethod]
        public void Test_All_ListNode_is_2_3()
        {
            var node = CreateListNode(new int[] { 2, 3 });

            var actual = node.All();
            var expected = new List<int> { 2, 3 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestCategory("l1, l2 長度為2")]
        [TestCategory("沒進位")]
        [TestMethod]
        public void L1_is_5_4_and_L2_is_3_2_should_return_val_is_8_6()
        {
            var l1 = CreateListNode(new int[] { 5, 4 });

            var l2 = CreateListNode(new int[] { 3, 2 });

            var expected = CreateListNode(new int[] { 8, 6 });

            AssertResult(l1, l2, expected);
        }

        [TestCategory("l1, l2 長度不同")]
        [TestCategory("沒進位")]
        [TestMethod]
        public void L1_is_5_4_and_L2_is_3_should_return_8_4()
        {
            var l1 = CreateListNode(new int[] { 5, 4 });
            var l2 = CreateListNode(new int[] { 3 });

            var expected = CreateListNode(new int[] { 8, 4 });

            AssertResult(l1, l2, expected);
        }

        [TestCategory("進位")]
        [TestMethod]
        public void L1_is_6_2_and_L2_is_8_should_return_4_3()
        {
            var l1 = CreateListNode(new int[] { 6, 2 });
            var l2 = CreateListNode(new int[] { 8 });
            var expected = CreateListNode(new int[] { 4, 3 });

            AssertResult(l1, l2, expected);
        }

        [TestMethod]
        public void L1_is_6_2_and_L2_is_8_2_should_return_4_5()
        {
            var l1 = CreateListNode(new int[] { 6, 2 });
            var l2 = CreateListNode(new int[] { 8, 2 });
            var expected = CreateListNode(new int[] { 4, 5 });

            AssertResult(l1, l2, expected);
        }

        [TestCategory("最末位進位")]
        [TestMethod]
        public void L1_is_6_7_and_L2_is_2_3_should_return_8_0_1()
        {
            var l1 = CreateListNode(new int[] { 6, 7 });
            var l2 = CreateListNode(new int[] { 2, 3 });
            var expected = CreateListNode(new int[] { 8, 0, 1 });

            AssertResult(l1, l2, expected);
        }

        [TestMethod]
        public void L1_is_6_and_L2_is_7_should_return_3_1()
        {
            var l1 = CreateListNode(new int[] { 6 });
            var l2 = CreateListNode(new int[] { 7 });
            var expected = CreateListNode(new int[] { 3, 1 });
            AssertResult(l1, l2, expected);
        }

        private ListNode CreateListNode(int[] nums)
        {
            if (nums.Length == 0)
            {
                return null;
            }

            var result = new ListNode(nums[0]);

            var currentNode = result;
            for (int i = 1; i < nums.Length; i++)
            {
                currentNode.next = new ListNode(nums[i]);
                currentNode = currentNode.next;
            }

            return result;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Tuple<int, int> t = GetTwoDigits(l1, l2, 0);

            var result = new ListNode(t.Item2);
            var l1HasNext = l1.next != null;
            var l2HasNext = l2.next != null;

            if (l1HasNext || l2HasNext)
            {
                var tNext = GetTwoDigits(l1.next, l2.next, t.Item1);
                result.next = new ListNode(tNext.Item2);

                if (tNext.Item1 == 1)
                {
                    result.next.next = new ListNode(1);
                }
            }

            return result;
        }

        private Tuple<int, int> GetTwoDigits(ListNode l1, ListNode l2, int num)
        {
            var l1Val = l1 == null ? 0 : l1.val;
            var l2Val = l2 == null ? 0 : l2.val;
            var nodeVal = l1Val + l2Val + num;

            var item1 = nodeVal >= 10 ? 1 : 0;
            var item2 = nodeVal >= 10 ? nodeVal - 10 : nodeVal;
            return new Tuple<int, int>(item1, item2);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }

        public IEnumerable<int> All()
        {
            var result = new List<int> { this.val };
            if (next != null)
            {
                result.AddRange(next.All());
            }

            return result;
        }
    }
}