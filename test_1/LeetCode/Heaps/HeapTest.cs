using NUnit.Framework;
using System.Collections.Generic;
using static LeetCode.Heaps.Heap;

namespace LeetCode.Heaps
{
    internal class HeapTest
    {
        [Test]
        public void MinHeapTest()
        {
            MinHeap minHeap = new(3);
            minHeap.Add(3);
            minHeap.Add(1);
            minHeap.Add(2);
            Assert.Multiple(() =>
            {
                Assert.That(minHeap.ToString(), Is.EqualTo("[1,3,2]"));
                Assert.That(minHeap.Peek(), Is.EqualTo(1));
                Assert.That(minHeap.Pop(), Is.EqualTo(1));
                Assert.That(minHeap.ToString(), Is.EqualTo("[2,3]"));
            });
            minHeap.Add(4);
            minHeap.Add(5);
            Assert.That(minHeap.ToString(), Is.EqualTo("[2,3,4]"));
        }

        [Test]
        public void MaxHeapTest()
        {
            MaxHeap maxheap = new(5);
            maxheap.add(1);
            maxheap.add(2);
            maxheap.add(3);
            Assert.Multiple(() =>
            {
                Assert.That(maxheap.toString(), Is.EqualTo("[3,1,2]"));
                Assert.That(maxheap.peek(), Is.EqualTo(3));
                Assert.That(maxheap.pop(), Is.EqualTo(3));
                Assert.That(maxheap.pop(), Is.EqualTo(2));
                Assert.That(maxheap.pop(), Is.EqualTo(1));
                Assert.That(maxheap.toString(), Is.EqualTo("No element!"));
            });
            maxheap.add(4);
            maxheap.add(5);
            Assert.That(maxheap.toString(), Is.EqualTo("[5,4]"));
        }
    }

    internal class DotNetPriorityQueue
    {
        [Test]
        public void Test()
        {
            //"array-backed quaternary min-heap"
            //each node in the heap has 4 children
            var queue = new PriorityQueue<string, int>(
            [
                ("A", 15),
                ("B", 7),
                ("C", 23),
                ("D",  2),
                ("E", 22),
            ]);


            string peekResult = queue.Peek(); // "D"


            if (queue.TryPeek(out string? result, out int priority))
            {
                // result = "D", priority = 2
            }


            string dequeueResult = queue.Dequeue(); // "D"


            if (queue.TryDequeue(out string? result2, out int priority2))
            {
                // result2 = "B", priority = 7
            }


            queue.Enqueue(element: "F", priority: 42);


            queue.EnqueueRange([("G", 3), ("H", 13)]);

            string dequeued1 = queue.DequeueEnqueue(element: "I", priority: 19); // "G"

            string dequeued2 = queue.EnqueueDequeue(element: "J", priority: 31); // "H"

            var unorderedItems = queue.UnorderedItems;

            var count = queue.Count;

            queue.Clear();

            var inverseComparer = Comparer<int>.Create((a, b) => 0 - a.CompareTo(b));
            var maxQueue = new PriorityQueue<string, int>(inverseComparer);

            queue.TrimExcess();
        }
    }
}
