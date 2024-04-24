using NUnit.Framework;
using System;

namespace LeetCode.LinkedList.Problems
{
    public class DoublyListNode
    {
        private int val;
        private DoublyListNode next, prev;

        private DoublyListNode(int x)
        { val = x; }
    }

    public class TestClass2
    {
        [Test]
        public void MyDLLTest()
        {
            MyDLL myLinkedList = new MyDLL();
            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtTail(3);
            myLinkedList.AddAtIndex(1, 2);    // linked list becomes 1->2->3
            Assert.That(myLinkedList.Get(1), Is.EqualTo(2));              // return 2
            myLinkedList.DeleteAtIndex(1);    // now the linked list is 1->3
            Assert.That(myLinkedList.Get(1), Is.EqualTo(3));              // return 3
        }
    }

    public class MyDLL
    {
        public class Node
        {
            public readonly int val;
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(int val = 0)
            {
                this.val = val;
            }
        }

        private int size;
        private Node head, tail;

        public MyDLL()
        {
            size = 0;
            head = new Node(0); //sentinal
            tail = new Node(0); //sentinal
            head.Next = tail;
            tail.Prev = head;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size) return -1;
            Node curr = head;
            for (int i = 0; i <= index; i++)
            {
                curr = curr.Next;
            }
            return curr.val;
        }

        public void AddAtHead(int val)
        {
            AddAtIndex(0, val);
        }

        public void AddAtTail(int val)
        {
            AddAtIndex(size, val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > size) return;
            Node curr = head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.Next;
            }
            Node newNode = new Node(val);
            newNode.Next = curr.Next;
            newNode.Next.Prev = newNode;
            curr.Next = newNode;
            newNode.Prev = curr;
            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size) return;
            Node curr = head;
            for (int i = 0; i <= index; i++)
            {
                curr = curr.Next;
            }
            // delete curr;
            curr.Next.Prev = curr.Prev;
            curr.Prev.Next = curr.Next;
            size--;
        }
    }

    public class MyLinkedList_withoutSentinal
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode prev;

            public ListNode(int val = 0, ListNode next = null, ListNode prev = null)
            {
                this.val = val;
                this.next = next;
                this.prev = prev;
            }
        }

        private ListNode head;
        private ListNode tail;
        private int size;

        public MyLinkedList_withoutSentinal()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;

            ListNode curr = head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.next;
            }
            return curr.val;
        }

        public void AddAtHead(int val)
        {
            ListNode newnode = new ListNode(val);

            if (head == null)
            {
                head = newnode;
                tail = newnode;
            }
            else
            {
                newnode.next = head;
                head.prev = newnode;
                head = newnode;
            }
            size++;
            //  PrintLinkedList();
        }

        public void AddAtTail(int val)
        {
            ListNode newnode = new ListNode(val);

            if (head == null)
            {
                head = newnode;
                tail = newnode;
            }
            else
            {
                newnode.prev = tail;
                tail.next = newnode;
                tail = newnode;
            }
            size++;
            //  PrintLinkedList();
        }

        public void AddAtIndex(int index, int val)
        {
            //check the index first
            if (index < 0 || index > size)
                return;

            // Edge case
            if (index == 0)
            {
                AddAtHead(val);
            }
            else if (index == size)
            {
                AddAtTail(val);
            }
            else
            {
                ListNode curr = head;
                ListNode newnode = new ListNode(val);
                for (int i = 0; i < index; i++)
                {
                    curr = curr.next;
                }
                newnode.prev = curr.prev;
                newnode.next = curr;
                curr.prev.next = newnode;
                curr.prev = newnode;
                size++;
                //  PrintLinkedList();
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
                return;

            ListNode curr = head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.next;
            }

            //edge case
            if (curr.prev != null)
                curr.prev.next = curr.next;
            else
                head = curr.next;

            if (curr.next != null)
                curr.next.prev = curr.prev;
            else
                tail = curr.prev;

            size--;
            // PrintLinkedList();
        }

        public void PrintLinkedList()
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + "->");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}