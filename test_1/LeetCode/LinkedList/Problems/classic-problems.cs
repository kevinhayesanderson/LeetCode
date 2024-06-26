﻿using NUnit.Framework;

namespace LeetCode.LinkedList.Problems
{
    public class TestClass1
    {
        private classic_problems obj = new();

        [Test]
        public void ReverseListTest()
        {
            var node = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                }
            };
            node.next.next.next = new ListNode(4)
            {
                next = new ListNode(5)
            };

            var reverse = obj.ReverseList(node);
            Assert.That(reverse, Is.Not.Null);
        }

        [Test]
        public void OddEvenListTest()
        {
            var node = new ListNode(1)
            {
                next = new ListNode(2)
            };
            node.next.next = new ListNode(3);
            node.next.next.next = new ListNode(4)
            {
                next = new ListNode(5)
            };

            var reverse = obj.OddEvenList(node);
            Assert.That(reverse, Is.Not.Null);
        }
    }

    internal class classic_problems
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            var current = head;
            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode prev = null, curr = head;
            while (curr != null)
            {
                if (curr.val == val)
                {
                    if (prev != null)
                    {
                        prev.next = curr.next;
                        curr = prev.next;
                    }
                    else //head delete
                    {
                        head = head.next;
                        curr = head;
                    }
                }
                else
                {
                    prev = curr;
                    curr = curr.next;
                }
            }
            return head;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return null;
            ListNode odd = head,
                even = head.next, //tail pointer - which is moving
                evenHead = even; //head pointer
            while (even != null && even.next != null)
            {
                odd.next = even.next; //assign //eg: even.Next = 3;
                odd = odd.next; //move to next odd element //eg: odd = 1, odd.Next = 3;

                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return false;

            //find two halves
            ListNode endOffFirstHalf(ListNode head)
            {
                ListNode fast = head;
                ListNode slow = head;
                while (fast.next != null && fast.next.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                return slow;
            }

            //reversing the second half
            ListNode reverseList(ListNode head)
            {
                ListNode prev = null;
                ListNode curr = head;
                while (curr != null)
                {
                    var next = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = next;
                }
                return prev;
            }

            //1.find two halves
            ListNode firstHalfEnd = endOffFirstHalf(head);

            //2.reversing the second half
            ListNode secondHalfStart = reverseList(firstHalfEnd.next);

            //3.compare the two halves
            ListNode p1 = head;
            ListNode p2 = secondHalfStart;

            bool res = true;

            while (res && p2 != null)
            {
                if (p1.val != p2.val)
                {
                    res = false;
                }
                p1 = p1.next;
                p2 = p2.next;
            }

            //4.reverse the second half to intial state
            firstHalfEnd.next = reverseList(secondHalfStart);

            //return res
            return res;
        }

        //time complexity o(N)
        //time complexity o(1)
    }
}