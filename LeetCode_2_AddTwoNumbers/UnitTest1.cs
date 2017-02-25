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

            var actual = new Solution().AddTwoNumbers(l1, l2);

            Assert.AreEqual(expected.val, actual.val);
        }

        [TestMethod]
        public void Test_All_ListNode_is_2_3()
        {
            var node = new ListNode(2);
            node.next = new ListNode(3);

            var actual = node.All();
            var expected = new List<int> { 2, 3 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [Ignore]
        [TestMethod]
        public void L1_is_5_4_and_L2_is_3_2_should_return_val_is_8_6()
        {
            var l1 = new ListNode(5);
            l1.next = new ListNode(4);

            var l2 = new ListNode(3);
            l2.next = new ListNode(2);

            var expected = new ListNode(8);
            expected.next = new ListNode(6);

            var actual = new Solution().AddTwoNumbers(l1, l2);

            //expected.All().ToExpectedObject().ShouldEqual(actual.All());
        }
    }

    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return new ListNode(l1.val + l2.val);
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