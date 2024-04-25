using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.LinkedList.Problems
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class TestClass
    {
        private two_pointer_technique obj = new two_pointer_technique();

        [Test]
        public void RemoveNthFromEnd_TwoPointerTest()
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

            obj.RemoveNthFromEnd_TwoPointer(node, 2);
        }
    }

    internal class two_pointer_technique
    {
        public bool HasCycle_Hashset(ListNode head)
        {
            var pointer = head;
            HashSet<ListNode> listNodes = new HashSet<ListNode>();

            while (pointer != null)
            {
                if (listNodes.Contains(pointer))
                {
                    return true;
                }
                listNodes.Add(pointer);
                pointer = pointer.next;
            }

            return false;
        }

        public bool HasCycle(ListNode head)
        {
            ListNode slowPointer = head, fastPointer = head;

            while (fastPointer != null && fastPointer.next != null)
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;

                if (slowPointer == fastPointer)
                {
                    return true;
                }
            }

            return false;
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode slowPointer = head, fastPointer = head;

            while (fastPointer != null && fastPointer.next != null)
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;
                if (slowPointer == fastPointer)
                {
                    return slowPointer;
                }
            }

            return null;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            var p1 = headA;
            var p2 = headB;

            while (p1 != p2)
            {
                p1 = p1 == null ? headB : p1.next;
                p2 = p2 == null ? headA : p2.next;
            }

            return p1;
        }

        // Note: In the case lists do not intersect, the pointers for A and B
        // will still line up in the 2nd iteration, just that here won't be
        // a common node down the list and both will reach their respective ends
        // at the same time. So pA will be NULL in that case.

        //Time complexity : O(N+M)
        //Space complexity : O(1)

        public ListNode RemoveNthFromEnd_TwoPass(ListNode head, int n)
        {
            if (head == null || head.next == null) return null;

            var p1 = head;

            int length = 0;
            while (p1 != null)
            {
                p1 = p1.next;
                length++;
            }

            // edge case - first node to remove
            if (length == n) return head.next;

            int nodeBeforeRemovedIndex = length - n - 1;
            p1 = head;
            for (var j = 0; j < nodeBeforeRemovedIndex; j++)
            {
                p1 = p1.next;
            }
            p1.next = p1.next.next;

            return head;
        }

        //Time complexity : O(L)
        //Space complexity : O(1)

        public ListNode RemoveNthFromEnd_TwoPointer(ListNode head, int n)
        {
            var curr = head;
            var nodeBeforeRemoved = head;

            int i = 0;
            while (curr != null)
            {
                // Only advances this pointer after n node
                if (i > n)
                {
                    nodeBeforeRemoved = nodeBeforeRemoved.next;
                }

                // Move first to the end, maintaining the gap
                curr = curr.next;
                i++;
            }

            // edge case - first node to remove
            if (i == n) return head.next;

            nodeBeforeRemoved.next = nodeBeforeRemoved.next.next;

            return head;
        }
    }
}