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

        //// Can also be done by stack
        // Push root to stack
        //While stack not empty map parent and node (left/right) and push node left or right to stack
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

        // Can be done by stack also, push nodes to stack rather than lis
        // t, no need to reverse
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

        List<List<int>> diagonal;
        public void diagonalPrint(TreeNode root)
        {
            if (root == null)
                return;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count() > 0)
            {
                int size = q.Count();
                List<int> answer = new List<int>();

                while (size > 0)
                {
                    TreeNode temp = q.Peek();
                    q.Dequeue();

                    // traversing each component;
                    while (temp != null)
                    {
                        answer.Add(temp.key);

                        if (temp.left != null)
                            q.Enqueue(temp.left);

                        temp = temp.right;
                    }
                }
                diagonal.Add(answer);
            }
        }

        public void MinumHeight()
        {
            if (root == null)
                Console.WriteLine("MinimumHeigth is " + 0);
            Console.WriteLine(FirstLeafNode(root, 1));

        }

        private int FirstLeafNode(TreeNode node, int level)
        {
            if (node.left == null && node.right == null)
            {
                return level;
            }

            if (node.left != null && node.right == null)
                return FirstLeafNode(node.left, level + 1);

            if (node.right != null && node.left == null)
                return FirstLeafNode(node.right, level + 1);

            int leftlev = FirstLeafNode(node.left, level + 1);
            int rightLeve = FirstLeafNode(node.right, level + 1);

            return Math.Min(leftlev, rightLeve);

        }

        public void DeepestleftNode()
        {
            int deepestLevelSoFar = 0;
            int level = 0;
            TreeNode deepestNode = root;
            Queue<TreeNode> q = new Queue<TreeNode>();

            q.Enqueue(root);

            while (q.Count() > 0)
            {
                int size = q.Count();
                level++;

                while (size > 0)
                {
                    var curr = q.Dequeue();

                    // TO DO Also check if current.left is a leaf
                    if (deepestLevelSoFar != level && curr.left != null)
                    {

                        deepestLevelSoFar = level;

                        deepestNode = curr.left;
                    }

                    if (curr.left != null)
                        q.Enqueue(curr.left);

                    if (curr.right != null)
                        q.Enqueue(curr.right);

                    size--;

                }

            }

            Console.WriteLine($"Deepest left Node is {deepestNode.key} ");

        }

        public List<List<int>> sumPaths = new List<List<int>>();

        public void PrintSumPaths(int k)
        {
            SumPath(root, k, new List<int>(), k);

            foreach (var item in sumPaths)
            {
                Console.WriteLine("Path");
                foreach (var path in item)
                {
                    Console.Write(path + "-->");
                }
            }
        }

        private void SumPath(TreeNode n, int sum, List<int> ls, int orignalSum)
        {
            if (n == null)
                return;

            ls.Add(n.key);

            if (n.key == sum)
            {
                sumPaths.Add(ls);

                //  SumPath(n.left, orignalSum, new List<int>(), orignalSum);
                //  SumPath(n.right, orignalSum, new List<int>(), orignalSum);
                // return;
                // return true;
            }

            else
            {
                SumPath(n.left, sum - n.key, new List<int>(ls), orignalSum);
                SumPath(n.right, sum - n.key, new List<int>(ls), orignalSum);
                // return;
            }

            SumPath(n.left, orignalSum, new List<int>(), orignalSum);
            SumPath(n.right, orignalSum, new List<int>(), orignalSum);

        }

        #region Largest Sum Tree
        int maxSum = int.MinValue;
        TreeNode maxNode = null;
        public TreeNode LargestSumTree(TreeNode node)
        {
            if (node == null)
                return maxNode;

            Sum(node);

           
            return maxNode;
        }

        private int Sum(TreeNode node)
        {
            if (node == null)
                return 0;

            int curreSum = node.key + Sum(node.left) + Sum(node.right);

            if (maxSum < curreSum)
            {
                maxSum = curreSum;

                maxNode = node;
            }

          //  maxSum = Math.Max(curreSum, maxSum);

            return curreSum;

        }

        #endregion

        #region Diameter
        int maxDiameter = int.MinValue;
        public int DiameterOfBinaryTree(TreeNode node)
        {

            if (node == null)
                return 0;

            Height(node);
            return maxDiameter;
        }

        private int Height(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = Height(node.left);
            int rightHeight = Height(node.right);

            maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);


            return Math.Max(leftHeight, rightHeight) + 1;
        }
        #endregion


        #region LCA

        TreeNode findLCA(int n1, int n2)
        {
            return findLCA(root, n1, n2);
        }

        // This function returns pointer to LCA
        // of two given values n1 and n2. This
        // function assumes that n1 and n2 are
        // present in Binary Tree
      public  TreeNode findLCA(TreeNode node, int n1, int n2)
        {

            // Base case
            if (node == null)
                return null;

            // If either n1 or n2 matches with
            // root's key, report the presence
            // by returning root (Note that if
            // a key is ancestor of other,
            // then the ancestor key becomes LCA
            if (node.key == n1 || node.key == n2)
                return node;

            // Look for keys in left and right subtrees
            TreeNode left_lca = findLCA(node.left, n1, n2);
            TreeNode right_lca = findLCA(node.right, n1, n2);

            // If both of the above calls return Non-NULL,
            // then one key is present in once subtree
            // and other is present in other, So this
            // node is the LCA
            if (left_lca != null && right_lca != null)
                return node;

            // Otherwise check if left subtree or
            // right subtree is LCA
            return (left_lca != null) ? left_lca : right_lca;
        }


      public void  Haspath(int k)
        {
            List<int> ls = new List<int>();

          var ex=  FindPath(root, k, ls);
        }



        private bool FindPath(TreeNode x, int v, List<int> path)
        {
            if (x == null)
                return false;

            path.Add(x.key);

            if (x.key == v)
            {
              //  path.Add(v);
                return true;

            }


            if (FindPath(x.left, v, (path)) || (FindPath(x.right, v, (path))))
                return true;

            path.Remove(x.key);
            return false;
}

        #endregion

    }

}

