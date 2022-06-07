using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Practice
{
    public class BinaryTree
    {
        public class Node
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int s)
            {
                value = s;
            }
        }

        public static bool IsValidBST(Node root)
        {

            return IsValidNode(root, int.MaxValue, int.MinValue);
        }

        private static bool IsValidNode(Node node, int max, int min)
        {
            if (node == null)
                return true;

            if (node.value >= max || node.value <= min)
                return false;

            return IsValidNode(node.left, node.value, min) && IsValidNode(node.right, max, node.value);
        }


        public static bool IsBst(Node root)
        {
            if (root == null)
                return true;

            Stack<Node> stck = new Stack<Node>();
            Node prev = null;

            // stck.Push(root);
            Node curr = root;

            while (curr != null || stck.Count > 0)
            {
                // curr = stck.Peek();

                while (curr != null)
                {
                    stck.Push(curr);
                    curr = curr.left;
                }

                curr = stck.Pop();

                if (prev != null && prev.value >= curr.value)
                    return false;

                prev = curr;

                curr = curr.right;

            }

            return true;


        }

        public static Node InsertNode(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (root.value > newNode.value)
                root.left = InsertNode(root.left, newNode);

            if (root.value < newNode.value)
                root.right = InsertNode(root.right, newNode);

            return root;
        }

        static int count = 0;

        public static int NthNodeDFS(Node root, int n)
        {
            Stack<Node> nodes = new Stack<Node>();

            nodes.Push(root);

            Node curr = root;

            while (curr != null || nodes.Count > 0)
            {
                while (curr != null)
                {
                    nodes.Push(curr);
                    curr = curr.left;
                }

                curr = nodes.Pop();

                count++;
                if (count == n)
                {
                    return curr.value;
                }

                curr = curr.right;

            }

            return -1;
        }

        // static int height = 0;
        public static int HeightOfTree(Node root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(HeightOfTree(root.left), HeightOfTree(root.right));
        }

        public static int MinHeightOfTree(Node root, int height)
        {

            if (root == null)
                return height;

            if (root.left == null && root.right != null)
                return MinHeightOfTree(root.right, height + 1);

            if (root.left != null && root.right == null)
                return MinHeightOfTree(root.left, height + 1);

            if (root.left == null & root.right == null)
                return height;

            return Math.Min(MinHeightOfTree(root.left, height + 1), MinHeightOfTree(root.right, height + 1));

        }


        public static List<List<Node>> sumpath = new List<List<Node>>();

        public static List<List<Node>> PrintSumPath(Node root, int k)
        {
            SumPath(new List<Node>(), root, k, 0);
            return sumpath;


        }

        public static void SumPath(List<Node> pathSoFar, Node node, int k, int sumSofar)
        {
            if (node == null)
                return;

            pathSoFar.Add(node);
            if (k == sumSofar)
            {
                sumpath.Add(pathSoFar);

            }
            else
            {
                SumPath(new List<Node>(pathSoFar), node.left, k, sumSofar + node.value);
                SumPath(new List<Node>(pathSoFar), node.right, k, sumSofar + node.value);
            }

            SumPath(new List<Node>(), node.left, k, sumSofar);
            SumPath(new List<Node>(), node.right, k, sumSofar);

        }

        public static Node LCA(Node root, Node n1, Node n2)
        {
            if (root == null)
                return null;

            if (n1 == root)
                return n1;

            if (n2 == root)
                return n2;

            Node lcaleft = LCA(root.left, n1, n2);
            Node lcaright = LCA(root.left, n1, n2);

            if (lcaleft != null && lcaright != null)
            {
                return root;
            }

            return (lcaleft != null) ? lcaleft : lcaright;
        }

    }
}
