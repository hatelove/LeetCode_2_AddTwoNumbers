using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = new ListNode(l1.val + l2.val);

            var l1HasNext = l1.next != null;
            var l2HasNext = l2.next != null;
            if (l1HasNext || l2HasNext)
            {
                var l1NextVal = l1HasNext ? l1.next.val : 0;
                var l2NextVal = l2HasNext ? l2.next.val : 0;
                result.next = new ListNode(l1NextVal + l2NextVal);
            }

            return result;
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