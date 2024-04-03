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
        [Test]
        public void DetectCycleTest()
        {


            var node = new ListNode(3);
            node.next = new ListNode(2);
            n
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
                if(listNodes.Contains(pointer))
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
                slowPointer= slowPointer.next;
                fastPointer = fastPointer.next.next;
                if(slowPointer == fastPointer)
                {
                    return slowPointer;
                }
            }

            return null;
        }
    }
}