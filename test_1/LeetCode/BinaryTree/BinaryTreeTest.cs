using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.BinaryTree
{
    public class TestClass
    {
        BinaryTreeTest binaryTreeTest = new BinaryTreeTest();

        [Test]
        public void PreorderTraversal_recursive_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = binaryTreeTest.PreorderTraversal_recursive(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }


        [Test]
        public void preorderTraversal_iterative_test()
        {
            var tree = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var res = binaryTreeTest.PreorderTraversal_iterative(tree);
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTreeTest
    {
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

    }
}
