using System.Collections.Generic;

namespace LeetCode.HashSet
{
    public class Bucket_LL
    {
        private readonly LinkedList<int> container;

        public Bucket_LL()
        {
            container = new LinkedList<int>();
        }

        public void Delete(int key)
        {
            container.Remove(key);
        }

        public bool Exists(int key)
        {
            return container.Contains(key);
        }

        public void Insert(int key)
        {
            var node = container.Find(key);
            if (node == null)
            {
                container.AddFirst(key);
            }
        }
    }

    public class MyHashSet
    {
        private readonly Bucket_LL[] buckets;
        private readonly int keyRange;

        public MyHashSet()
        {
            keyRange = 769;
            buckets = new Bucket_LL[keyRange];
            for (int i = 0; i < keyRange; i++)
            {
                buckets[i] = new Bucket_LL();
            }
        }

        public void Add(int key)
        {
            int bucketIndex = Hash(key);
            buckets[bucketIndex].Insert(key);
        }

        public bool Contains(int key)
        {
            int bucketIndex = Hash(key);
            return buckets[bucketIndex].Exists(key);
        }

        public void Remove(int key)
        {
            int bucketIndex = Hash(key);
            buckets[bucketIndex].Delete(key);
        }

        protected int Hash(int key)
        {
            return key % keyRange;
        }
    }
}