using NUnit.Framework;
using static LeetCode.Heaps.Heap;

namespace LeetCode.Heaps
{
    internal class HeapTest
    {
        [Test]
        public void MinHeapTest()
        {
            MinHeap minHeap = new(3);
            minHeap.add(3);
            minHeap.add(1);
            minHeap.add(2);
            Assert.Multiple(() =>
            {
                Assert.That(minHeap.toString(), Is.EqualTo("[1,3,2]"));
                Assert.That(minHeap.peek(), Is.EqualTo(1));
                Assert.That(minHeap.pop(), Is.EqualTo(1));
                Assert.That(minHeap.toString(), Is.EqualTo("[2,3]"));
            });
            minHeap.add(4);
            minHeap.add(5);
            Assert.That(minHeap.toString(), Is.EqualTo("[2,3,4]"));
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
}
