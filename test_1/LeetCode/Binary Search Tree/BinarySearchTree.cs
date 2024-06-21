using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Binary_Search_Tree
{
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;
        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    internal class BST_Test
    {
        [Test]
        public void IsValidBST_test()
        {
            var tree = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            var res = new BinarySearchTree().IsValidBST_InOrder(tree);
            Assert.That(res, Is.EqualTo(true));
        }
    }

    internal class BinarySearchTree
    {
        public bool IsValidBST_Range_Recursive(TreeNode root)
        {
            return validate(root, null, null);
            bool validate(TreeNode root, int? low, int? high)
            {
                if (root == null) return true;
                if ((low != null && root.val <= low) || (high != null && root.val >= high)) return false;

                return validate(root.left, low, root.val) && validate(root.right, root.val, high);
            }
        }//Time Complexity: O(N) //Space Complexity: O(N)

        public bool IsValidBST_InOrder(TreeNode root)
        {
            if (root == null) return false;
            var stack = new Stack<TreeNode>();
            TreeNode prevleft = null;

            while (stack.Count != 0 || root != null)
            {
                //1.go to the leftmost leaf of the tree(smallest in the tree)
                //2.fill up the stack with the left children(once filled the stack will be in the desecending order)
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                //3. pop and comapre with the current left child val with prev left val(prevleft)
                root = stack.Pop();
                if (prevleft != null && root.val <= prevleft.val) return false;
                prevleft = root;

                //4. go to right tree of the current left to repeate the logic
                root = root.right;
            }

            return true;
        }

        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
        }
    }
}