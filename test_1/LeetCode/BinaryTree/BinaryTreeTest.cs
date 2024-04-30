using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.BinaryTree
{
    public class BFS
    {
        public static IList<IList<int>> LevelOrder_Iterative(TreeNode root)
        {
            var levels = new List<IList<int>>();
            if (root == null) return levels;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;

            while (queue.Count != 0)
            {
                levels.Add(new List<int>());

                int level_length = queue.Count;
                for (int i = 0; i < level_length; ++i)
                {
                    var node = queue.Dequeue();
                    levels[level].Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                level++;
            }

            return levels;
        }

        public static IList<IList<int>> LevelOrder_Recursive(TreeNode root)
        {
            var levels = new List<IList<int>>();

            void helper(TreeNode node, int level)
            {
                //start the current level
                if (levels.Count == level)
                {
                    levels.Add(new List<int>());
                }

                //fulfil the current level
                levels[level].Add(node.val);

                if (node.left != null)
                    helper(node.left, level + 1);
                if (node.right != null)
                    helper(node.right, level + 1);
            }

            if (root == null) return levels;

            helper(root, 0);

            return levels;
        }
    }

    public class BottomUp
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root is null) return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        //DFS // Bottom up
        public int CountUnivalSubtrees(TreeNode root)
        {
            var count = 0;
            if (root == null) return count;

            bool dfs(TreeNode node)
            {
                if (node.left == null && node.right == null)
                {
                    count++;
                    return true;
                }

                var isUniVal = true;
                if (node.left != null)
                {
                    var left = dfs(node.left);
                    isUniVal = isUniVal && left && node.val == node.left.val;
                }

                if (node.right != null)
                {
                    var right = dfs(node.right);
                    isUniVal = isUniVal && right && node.val == node.right.val;
                }

                if (isUniVal) count++;

                return isUniVal;
            }

            dfs(root);

            return count;
        }
    }

    public class DFS
    {
        //left-root-right
        public static class InOrder
        {
            public static IList<int> InorderTraversal_MorrisTraversal(TreeNode root)
            {
                var nodes = new List<int>();
                while (root != null)
                {
                    if (root.left != null)
                    {
                        TreeNode pre = root.left;
                        //In current's left subtree, make current the right child of the rightmost node
                        while (pre.right != null && pre.right != root)
                        {
                            pre = pre.right;
                        }

                        if (pre.right == null)
                        {
                            pre.right = root;
                            root = root.left;
                        }
                        else
                        {
                            pre.right = null;
                            nodes.Add(root.val);
                            root = root.right;
                        }
                    }
                    else
                    {
                        nodes.Add(root.val); // current does not have left child//Add current’s value
                        root = root.right;
                    }
                }

                return nodes;
            }

            public static List<int> DFS_InOrder_MT(TreeNode root)
            {
                var values = new List<int>();
                if (root == null)
                    return values;
                while (root != null)
                {
                    if (root.left != null)
                    {
                        var original_left = root.left;
                        var rightmost = root.left; //rightmost leaf of the left subtree
                        while (rightmost.right != null)
                            rightmost = rightmost.right;
                        //rewire logic
                        rightmost.right = root;
                        root.left = null;
                        root = original_left;
                    }
                    else
                    {
                        values.Add(root.val);
                        root = root.right;
                    }
                }

                return values;
            }

            //Time Complexity O(n)
            //Space Complexity O(1)
        }

        //left-right-root
        public static class PostOrder
        {
            public static IList<int> PostorderTraversal_MorrisTraversal(TreeNode root)
            {
                var nodes = new List<int>();
                while (root != null)
                {
                    if (root.right != null)
                    {
                        TreeNode pre = root.right;
                        while (pre.left != null && pre.left != root)
                        {
                            pre = pre.left;
                        }

                        if (pre.left == null)
                        {
                            pre.left = root;
                            nodes.Insert(0, root.val);
                            root = root.right;
                        }
                        else
                        {
                            pre.left = null;
                            root = root.left;
                        }
                    }
                    else
                    {
                        nodes.Insert(0, root.val);
                        root = root.left;
                    }
                }
                return nodes;
            }
        }

        //root-left-right
        public static class PreOrder
        {
            public static List<int> PreorderTraversal_iterative(TreeNode root)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                List<int> output = new List<int>();
                if (root == null)
                {
                    return output;
                }

                stack.Push(root);
                while (stack.Count != 0)
                {
                    TreeNode node = stack.Pop();
                    output.Add(node.val);
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
                return output;
            }

            public static List<int> PreorderTraversal_MorrisTraversal(TreeNode root)
            {
                List<int> nodes = new List<int>();
                while (root != null)
                {
                    if (root.left != null) //one step left
                    {
                        //finding predecessor for root
                        TreeNode pre = root.left;
                        while (pre.right != null && pre.right != root)
                        {
                            pre = pre.right;
                        }
                        //found predecessor, right most on first left subtree

                        //if pre.right == null , create a cycle
                        if (pre.right == null)
                        {
                            pre.right = root;
                            nodes.Add(root.val);
                            root = root.left;
                        }
                        else // break the cycle, go to right subtree
                        {
                            pre.right = null;
                            root = root.right;
                        }
                    }
                    else //does not have a left child node, we simply add root's value to the resulting array, and move on to the right node.
                    {
                        nodes.Add(root.val);
                        root = root.right;
                    }
                }
                return nodes;
            }

            public static IList<int> PreorderTraversal_recursive(TreeNode root)
            {
                var nodes = new List<int>();
                if (root != null)
                {
                    nodes.Add(root.val);
                    if (root.left != null) nodes.AddRange(PreorderTraversal_recursive(root.left));
                    if (root.right != null) nodes.AddRange(PreorderTraversal_recursive(root.right));
                }
                return nodes;
            }
        }
    }

    public class TestClass
    {
        [Test]
        public void InorderTraversal_MorrisTraversal_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = DFS.InOrder.InorderTraversal_MorrisTraversal(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 3, 2 }));
        }

        [Test]
        public void LevelOrder_Recursive_test()
        {
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var res = BFS.LevelOrder_Recursive(tree);
            Assert.That(res, Is.EqualTo(new List<List<int>> { new List<int> { 3 }, new List<int> { 9, 20 }, new List<int> { 15, 7 } }));
        }

        [Test]
        public void MaxDepth_BU_test()
        {
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            var res = BottomUp.MaxDepth(tree);
            Assert.That(res, Is.EqualTo(3));
        }

        [Test]
        public void MaxDepth_TD_test()
        {
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            var res = TopDown.MaxDepth(tree);
            Assert.That(res, Is.EqualTo(3));
        }

        [Test]
        public void PostorderTraversal_MorrisTraversal_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = DFS.PostOrder.PostorderTraversal_MorrisTraversal(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 3, 2, 1 }));
        }

        [Test]
        public void PreorderTraversal_iterative_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = DFS.PreOrder.PreorderTraversal_iterative(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }

        [Test]
        public void PreorderTraversal_recursive_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = DFS.PreOrder.PreorderTraversal_recursive(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }
    }

    public class TopDown
    {
        public static bool IsSymmetric(TreeNode root)
        {
            bool IsMirror(TreeNode left, TreeNode right)
            {
                if (left == null && right == null) return true;
                if (left == null || right == null) return false;

                return (left.val == right.val)
                     && IsMirror(left.left, right.right)
                     && IsMirror(left.right, right.left);
            }

            if (root == null) return false;
            return IsMirror(root.left, root.right);
        }

        public static int MaxDepth(TreeNode root)
        {
            int depth = 0;
            if (root == null) return depth;

            void helper(TreeNode node, int level)
            {
                depth = Math.Max(depth, level);
                if (node.left == null && node.right == null) return;
                if (node.left != null) helper(node.left, level + 1);
                if (node.right != null) helper(node.right, level + 1);
            }

            helper(root, 1);

            return depth;
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            targetSum -= root.val;

            if ((root.left == null) && (root.right == null))
            {
                return targetSum == 0;
            }

            return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
        }
    }

    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode Create(int?[] array)
        {
            TreeNode node = null;
            for (int i = 0; i < array.Length; i = i + 2)
            {
                if (array[i].HasValue)
                    node = new TreeNode(array[i].Value);
                if (array[i + 1].HasValue)
                {
                    node.left = new TreeNode(array[i + 1].Value);
                }
                if (array[i + 2].HasValue)
                {
                    node.right = new TreeNode(array[i + 2].Value);
                }
            }

            return node;
        }
    }
}