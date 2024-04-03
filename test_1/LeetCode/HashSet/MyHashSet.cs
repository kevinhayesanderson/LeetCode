using System.Collections.Generic;

namespace LeetCode.HashSet
{
    public class MyHashSet
    {
        private Bucket[] buckets;
        private int keyRange;

        public MyHashSet()
        {
            keyRange = 769;
            buckets = new Bucket[keyRange];
            for (int i = 0; i < keyRange; i++)
            {
                buckets[i] = new Bucket();
            }
        }

        protected int hash(int key)
        {
            return key % keyRange;
        }

        public void Add(int key)
        {
            int bucketIndex = hash(key);
            buckets[bucketIndex].insert(key);
        }

        public void Remove(int key)
        {
            int bucketIndex = hash(key);
            buckets[bucketIndex].delete(key);
        }

        public bool Contains(int key)
        {
            int bucketIndex = hash(key);
            return buckets[bucketIndex].exists(key);
        }
    }
    public class Bucket
    {
        LinkedList<int> container;

        public Bucket()
        {
            container = new LinkedList<int>();
        }

        public void insert(int key)
        {
            int index = indexOf(container, key);
            if (index != -1)
            {
                container.AddFirst(key);
            }

        }

        private int indexOf(LinkedList<int> ll, int key)
        {
            int i = 0;
            var head = ll.First;
            while (head != null)
            {
                if (head.Value == key)
                {
                    return i;
                }
                head = head.Next;
                i++;
            }
            return -1;
        }

        public void delete(int key)
        {
            container.Remove(key);
        }

        public bool exists(int key)
        {
            return container.Contains(key);
        }

    }
}
