using NUnit.Framework;

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
            public Node? Next { get; set; }
            public Node? Previous { get; set; }

            public Node(int val)
            {
                this.val = val;
                Previous = null;
                Next = null;
            }
        }

        private int size;
        private Node head, tail;

        public MyDLL()
        {
            size = 0;
            head = new Node(0);
            tail = new Node(0);
            head.Next = tail;
            tail.Previous = head;
        }

        public int Get(int index)
        {
            if (index >= size) return -1;
            if (index < size / 2)
            {
                int i = 0;
                var curr = head;
                while (i < index)
                {
                    curr = curr.Next;
                    i++;
                }

                return curr.val;
            }
            else
            {
                int i = size;
                var curr = tail;
                while (i > index)
                {
                    curr = curr.Previous;
                    i--;
                }

                return curr.val;
            }
        }

        public void AddAtHead(int val)
        {
            var newNode = new Node(val);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void AddAtTail(int val)
        {
            var newNode = new Node(val);
            tail.Next = newNode;
            tail = newNode;
            size++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index >= size) return;
            var newNode = new Node(val);
            Node curr;
            if (index < size / 2)
            {
                int i = 0;
                curr = head;
                while (i < index)
                {
                    curr = curr.Next;
                    i++;
                }
            }
            else
            {
                int i = size;
                curr = tail;
                while (i > index)
                {
                    curr = curr.Previous;
                    i--;
                }
            }
            var prev = curr.Previous;
            prev.Next = newNode;
            newNode.Previous = prev;
            newNode.Next = curr;
            curr.Previous = newNode;
            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= size) return;

            Node curr;
            if (index < size / 2)
            {
                int i = 0;
                curr = head;
                while (i < index)
                {
                    curr = curr.Next;
                    i++;
                }
            }
            else
            {
                int i = size;
                curr = tail;
                while (i > index)
                {
                    curr = curr.Previous;
                    i--;
                }
            }

            var prev = curr.Previous;
            var next = curr.Next;

            prev.Next = next;
            next.Previous = prev;
            size--;
        }
    }
}