using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CCIFinal
{
    public class TreeNode
    {
        public TreeNode(int k)
        {
            key = k;
        }

        public int key;
        public TreeNode left, right;
        public TreeNode parent;
    }

    public class BinaryTree
    {

        public TreeNode root;

        int countNthNode;
        int nthNodeValue;
        public int NthNode(int n, TreeNode node)
        {
            if (n == countNthNode || node == null)
            {
                return nthNodeValue;
            }

            if (node.left != null)
                NthNode(n, node.left);

            countNthNode++;
            if (n == countNthNode)
                nthNodeValue = node.key;

            if (node.right != null)
                NthNode(n, node.right);

            return nthNodeValue;

        }


        public int NthInorderstack(int n)
        {
            if (root == null)
            {
                return -1;
            }
            int count = 0;


            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;

            // traverse the tree
            while (curr != null || s.Count > 0)
            {

                /* Reach the left most Node of the
                curr Node */
                while (curr != null)
                {
                    /* place pointer to a tree node on
                       the stack before traversing
                      the node's left subtree */
                    s.Push(curr);
                    curr = curr.left;
                }

                /* Current must be NULL at this point */
                curr = s.Pop();
                count++;

                if (count == n)
                {
                    return curr.key;
                }

                /* we have visited the node and its
                   left subtree.  Now, it's right
                   subtree's turn */
                curr = curr.right;
            }

            return -1;
        }

        public void InorderTraversal()
        {
            if (root == null)
                return;

            TraverseNode(root);
        }

        private void TraverseNode(TreeNode root)
        {
            if (root == null)
                return;

            TraverseNode(root.left);
            Console.WriteLine(root.key);
            TraverseNode(root.right);
        }

        public TreeNode InsertNode(int key)
        {
            if (root == null)
            {
                root = new TreeNode(key);
                return root;
            }
            Queue<TreeNode> qt = new Queue<TreeNode>();
            qt.Enqueue(root);

            while (qt.Count > 0)
            {
                var node = qt.Peek();

                qt.Dequeue();

                if (node.left == null)
                {
                    node.left = new TreeNode(key) { parent = node };

                    break;
                }
                else
                {
                    qt.Enqueue(node.left);
                }

                if (node.right == null)
                {
                    node.right = new TreeNode(key) { parent = node };
                    break;
                }
                else
                {
                    qt.Enqueue(node.right);
                }
            }

            return root;
        }

        public void printCurrentLevel(TreeNode root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.key + " ");
            }
            else if (level > 1)
            {
                printCurrentLevel(root.left, level - 1);
                printCurrentLevel(root.right, level - 1);
            }
        }

        public void PrintLevelOrder(int level)
        {
            int qlev = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                qlev++;
                int count = q.Count();

                while (count > 0 && qlev != level)
                {
                    var node = q.Peek();
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    q.Dequeue();
                    count--;
                }

                if (qlev == level)
                {
                    while (q.Count > 0)
                    {
                        Console.WriteLine(q.Dequeue().key);
                    }

                    break;
                }


            }

        }

        public void PrintNodesByLevelRec(TreeNode node, int level, List<int> a)
        {
            if (root == null)
                return;

            if (level == 1)
                a.Add(node.key);

            if (node.left != null)
                PrintNodesByLevelRec(node.left, level - 1, a);

            if (node.right != null)
                PrintNodesByLevelRec(node.right, level - 1, a);
        }

        public void Inorderstack()
        {
            if (root == null)
            {
                return;
            }


            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;

            // traverse the tree
            while (curr != null || s.Count > 0)
            {

                /* Reach the left most Node of the
                curr Node */
                while (curr != null)
                {
                    /* place pointer to a tree node on
                       the stack before traversing
                      the node's left subtree */
                    s.Push(curr);
                    curr = curr.left;
                }

                /* Current must be NULL at this point */
                curr = s.Pop();

                Console.WriteLine(curr.key + " ");

                /* we have visited the node and its
                   left subtree.  Now, it's right
                   subtree's turn */
                curr = curr.right;
            }
        }

        public int HeightOfTree()
        {
            return HeightFromNode(root);

        }

        private int HeightFromNode(TreeNode node)
        {
            if (node == null)
                return 0;

            int heightLeft = 1 + HeightFromNode(node.left);
            int heightRight = 1 + HeightFromNode(node.right);

            return Math.Max(heightLeft, heightRight);

        }

        public void DeleteDeepestNode()
        {
            Queue<TreeNode> qt = new Queue<TreeNode>();
            qt.Enqueue(root);

            TreeNode node = null;
            while (qt.Count > 0)
            {
                node = qt.Peek();

                qt.Dequeue();

                if (node.left != null)
                {
                    qt.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    qt.Enqueue(node.right);
                }
            }

            if (node.parent != null)
            {
                if (node.parent.right != null)
                {
                    node.parent.right = null;
                }
                else if (node.parent.left != null)
                {
                    node.parent.left = null;
                }
            }
            else
            {
                root = null;
            }
        }

        #region BST

        public bool isBST(TreeNode root, int min, int max)
        {
            // Base condition
            if (root == null)
                return true;

            // if left node exist then check it has
            // correct data or not i.e. left node's data
            // should be less than root's data
            if (root.key <= min || root.key >= max)
                return false;


            // check recursively for every node.
            return isBST(root.left, min, root.key) &&
                isBST(root.right, root.key, max);
        }

        static TreeNode prev;

        static Boolean isBSTUtil(TreeNode root)
        {
            // traverse the tree in inorder fashion and
            // keep track of prev node
            if (root != null)
            {
                if (!isBSTUtil(root.left))
                    return false;

                // Allows only distinct valued nodes
                if (prev != null &&
                    root.key <= prev.key)
                    return false;

                prev = root;

                return isBSTUtil(root.right);
            }
            return true;
        }

        #endregion

        Dictionary<int, TreeNode> nodeParent = new Dictionary<int, TreeNode>();
        public Dictionary<int, TreeNode> NodeParentMap(TreeNode node, TreeNode parent)
        {
            if (node != null && !nodeParent.ContainsKey(node.key))
                nodeParent.Add(node.key, parent);

            if (node.left != null)
                NodeParentMap(node.left, node);

            if (node.right != null)
                NodeParentMap(node.right, node);

            return nodeParent;

        }

        public List<int> PathFromRoot(int k)
        {
            List<int> path = new List<int>();
            NodeParentMap(root, null);

            path.Add(k);

            if (nodeParent.ContainsKey(k))
            {
                var parent = nodeParent[k];
                while (parent != null)
                {
                    path.Add(parent.key);
                    parent = nodeParent[parent.key];
                }

            }

            return path.ToArray().Reverse().ToList();
        }

    }
}
