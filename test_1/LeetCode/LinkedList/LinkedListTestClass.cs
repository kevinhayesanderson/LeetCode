using NUnit.Framework;

namespace LeetCode.LinkedList
{
    public class LinkedList<T>
    {
        private int _count;

        private Node _head;

        private Node _tail;

        public LinkedList()
        {
            _count = 0;
            _head = new Node(default);
            _tail = new Node(default);

            _head.Next = _tail;
            _head.Previous = null;
            _tail.Next = null;
            _tail.Previous = _head;
        }

        public int Count
        {
            get
            {
                if (_count < 0)
                {
                    _count = 0;
                }
                return _count;
            }
            private set
            {
                _count = value;
            }
        }

        public Node Head => _head;

        public Node Tail => _tail;

        public void AddAtHead(T t)
        {
            Node newNode = new Node(t);
            Count++;
            if (_head == null)
            {
                newNode.Next = null;
            }
            if (_head != null)
            {
                newNode.Next = _head;
                _head.Previous = newNode;
            }
            _head = newNode;
        }

        public void AddAtIndex(T t, int index)
        {
            if (index > Count)
                return;
            if (index == 0)
                AddAtHead(t);
            if (index == Count)
                AddAtTail(t);

            Node newNode = new Node(t);
            Count++;

            Node nodeAtIndexMinusOne = Head;
            int counter = 0;
            while (counter != (index - 1))
            {
                nodeAtIndexMinusOne = nodeAtIndexMinusOne.Next;
                counter++;
            }

            newNode.Next = nodeAtIndexMinusOne.Next;
            nodeAtIndexMinusOne.Next = newNode;
        }

        public void AddAtTail(T t)
        {
            Node newNode = new Node(t);
            Count++;
            if (_head == null)
            {
                _head = newNode;
                _head.Next = null;
                return;
            }
            Node lastNode = GetLastNode();
            lastNode.Next = newNode;
            newNode.Previous = lastNode;
            newNode.Next = null;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                return;
            }

            Node currNode = _head;
            if (index == 0)
            {
                _head = currNode.Next;
            }
            else
            {
                Node current = _head;
                Node pre = null;
                int counter = 0;
                while (counter != index)
                {
                    pre = current;
                    current = current.Next;
                    counter++;
                }
                pre.Next = current.Next;
                Count--;
            }
        }

        public T? Get(int index)
        {
            if (index < 0 || index >= Count)
                return default;

            Node currentNode = _head;
            if ((index + 1) < (_count - index))
            {
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
            }
            else
            {
                currentNode = _tail;
                for (int i = 0; i < _count - index; i++)
                {
                    currentNode = currentNode.Previous;
                }
            }

            return currentNode.Val;
        }

        private Node GetLastNode()
        {
            Node node = _head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node;
        }

        public class Node
        {
            public Node(T val)
            {
                Val = val;
                Previous = null;
                Next = null;
            }

            public Node? Next { get; set; }
            public Node? Previous { get; set; }
            public T Val { get; set; }
        }
    }

    internal class LinkedListTestClass
    {
        public static int[] CreateTestDataArray()
        {
            int length = 10;
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = i;
            }
            return array;
        }

        [Test]
        public void AddLastCountAndNextTest()
        {
            int[] testData = CreateTestDataArray();
            LinkedList<int> testLL = new LinkedList<int>();
            foreach (int i in testData)
            {
                testLL.AddAtTail(i);
                Assert.That(testLL.Tail.Val, Is.EqualTo(i));
            }

            Assert.That(testLL.Count, Is.EqualTo(testData.Length));

            CompareArrayToLinkedList(testData, testLL);
        }

        private void CompareArrayToLinkedList(int[] testData, LinkedList<int> testLL)
        {
            LinkedList<int>.Node currentNode = testLL.Head;

            for (int i = 0; i < testLL.Count; i++)
            {
                if (currentNode == null)
                {
                    Assert.That(i == testData.Length - 1);
                    break;
                }

                Assert.That(testData[i] == currentNode.Val);

                currentNode = currentNode.Next;
            }
        }
    }
}