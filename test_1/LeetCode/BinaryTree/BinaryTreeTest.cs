using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.BinaryTree
{
    public class BinaryTreeTest
    {
        public IList<int> PostorderTraversal_MorrisTraversal(TreeNode root)
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

        public IList<int> InorderTraversal_MorrisTraversal(TreeNode root)
        {
            var nodes = new List<int>();
            while (root != null)
            {
                if (root.left != null)
                {
                    TreeNode pre = root.left;
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
                    nodes.Add(root.val);
                    root = root.right;
                }
            }

            return nodes;
        }

        public List<int> PreorderTraversal_iterative(TreeNode root)
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

        public List<int> PreorderTraversal_MorrisTraversal(TreeNode root)
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

        public IList<int> PreorderTraversal_recursive(TreeNode root)
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

    public class TestClass
    {
        private BinaryTreeTest binaryTreeTest = new BinaryTreeTest();

        [Test]
        public void PostorderTraversal_MorrisTraversal_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = binaryTreeTest.PostorderTraversal_MorrisTraversal(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 3, 2, 1 }));
        }

        [Test]
        public void InorderTraversal_MorrisTraversal_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = binaryTreeTest.InorderTraversal_MorrisTraversal(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 3, 2 }));
        }

        [Test]
        public void PreorderTraversal_iterative_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = binaryTreeTest.PreorderTraversal_iterative(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }

        [Test]
        public void PreorderTraversal_recursive_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = binaryTreeTest.PreorderTraversal_recursive(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
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
    }
}