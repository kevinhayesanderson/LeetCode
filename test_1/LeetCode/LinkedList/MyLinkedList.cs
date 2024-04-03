using NUnit.Framework;

namespace LeetCode.LinkedList
{
    public class MyLinkedListTest
    {
        [Test]
        public void Test1()
        {
            var ll = new MyLinkedList();
            ll.AddAtHead(1);
            ll.AddAtTail(3);
            ll.AddAtIndex(1, 2);
            Assert.That(ll.Get(1), Is.EqualTo(2));
            ll.DeleteAtIndex(1);
            Assert.That(ll.Get(1), Is.EqualTo(3));
        }
    }

    public class MyLinkedList
    {
        public class Node
        {
            public Node(int value)
            {
                Value = value;
                Next = null;
            }

            public Node Next { get; set; }
            public int Value { get; set; }
        }

        private Node head = null;

        public MyLinkedList()
        {
        }

        public int Get(int index)
        {
            Node curr = head;

            while (index > 0)
            {
                if (curr == null)
                    return -1;

                curr = curr.Next;
                index--;
            }

            return curr == null ? -1 : curr.Value;
        }

        public void AddAtHead(int val)
        {
            Node node = new Node(val);

            if (head == null)
            {
                head = node;
                return;
            }

            node.Next = head;
            head = node;
        }

        public void AddAtTail(int val)
        {
            Node node = new Node(val);

            if (head == null)
            {
                head = node;
                return;
            }

            Node curr = head;

            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = node;
        }

        public void AddAtIndex(int index, int val)
        {
            Node curr = head, prev = null, node = new Node(val);

            while (index > 0)
            {
                if (curr == null)
                    return;

                prev = curr;
                curr = curr.Next;
                index--;
            }

            if (prev == null)
            {
                node.Next = head;
                head = node;
            }
            else
            {
                prev.Next = node;
                node.Next = curr;
            }
        }

        public void DeleteAtIndex(int index)
        {
            Node curr = head, prev = null;
            while (index > 0)
            {
                if (curr == null)
                    return;

                prev = curr;
                curr = curr.Next;
                index--;
            }

            if (prev == null)
            {
                head = head.Next;
            }
            else
            {
                prev.Next = curr?.Next;
            }
        }
    }

    /**
     * Your MyLinkedList object will be instantiated and called as such:
     * MyLinkedList obj = new MyLinkedList();
     * int param_1 = obj.Get(index);
     * obj.AddAtHead(val);
     * obj.AddAtTail(val);
     * obj.AddAtIndex(index,val);
     * obj.DeleteAtIndex(index);
     */
}