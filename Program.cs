using CCIFinal.Array;
using CCIFinalLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            int lcs = DPLCS.LongestSubstringRecursive("kaist", "vikyais", 5, 7, 0);
            int mincoins = DynamicProgramming.MinCoinsToCoinSumDP(new int[] { 1, 2, 5 }, 8);
            int x = DynamicProgramming.MinCoinsToCoinSum(new int[] { 1, 2, 5 }, 8, 3);
            BackTracking.PrintSubset(new int[] { 2, 1, 3, 5, 4 }, 5, new List<int>());
            int p1 = DynamicProgramming.KnapsackDP(new int[] { 2, 1, 3, 5, 4 }, 4, new int[] { 10, 12, 2, 3, 5 }, 5);
            int profit =   DynamicProgramming.KanpSackMemoization(new int[] { 2,1,3, 5, 4 }, 4, new int[] {10, 12, 2,3,5 }, 5);
            int way3 = DynamicProgramming.NumberOfWaysToSumKRec(new int[] { 1, -2, 3, 4, 5, 6 }, 6, 6);
            int ways2 = Practice.NumberOfWaysToSumK(new int[] { 1, -2, 3, 4, 5, 6 },6, 6, 0);
            int ways = Practice.DPNumberOfWaysToSumK(new int[] { 1, 2, 3, 4, 5, 6 }, 6,  6);
            Stack<int> st = new Stack<int>();
            st.Push(3);
            st.Push(4);
            st.Push(1);
            st.Push(10);
            st.Push(8);
            st.Push(13);
            Practice.SortStack(st);
            Practice.IsValidBST();
          var result =  ArrayFunc.SubSetSumK(new int[] {1,2,3,4,5,6 }, 6);
            BackTracking.SolveMaze();
            BackTracking.SudoKuSolve(9);
           /// BackTracking.placeQueens(0, 4);
          BackTracking.NQueen(6);

            SlidingWindowFunctions();            
          
            //  StringHelper.PrintPermutation("abc", "");
            // LinkListFunctions();

            //LRUFunction();

            //HeapFunctions();

            //  ArrayFunctions();

            //MyQueueFunctions();

            // BinaryTreeFunctions();

            //  MyStack.NetGreaterElement(new int[] { 2,6,5,8,7,10});

            //   HashFunctions();

            Console.ReadLine();

        }

        private static void SlidingWindowFunctions()
        {
            SlidingWindow.LongestSubstringWithKUniqueChar("abacdefgh", 4);
            SlidingWindow.LongestSubstringWithoutRepeatingChar("abccdefxyzwrm");
            SlidingWindow.MaxTargetSumArray(new int[] { 4, 1, 1, 1, 1, 1, 3, 5 }, 5);
            SlidingWindow.MaxInAllSubArrayInWindow(new int[] { 1, 2, 5, 1, 2, 0, 5 }, 3);
            SlidingWindow.MaxSumSubArrayInKWindow(new int[] { 1, 2, 13, 4, 5, 2 }, 3);
        }

        private static void HashFunctions()
        {
            Hash h = new Hash();

            string x = Hash.GetKey("kghjkggh");
            int l1 = h.LongestConsecutiveSequenceNoOrder(new int[] { 1, 9, 3, 10, 4, 20, 19, 18, 17, 16 });

            int l = h.LongestIncreasingConsecutiveSubsequence(new int[] { 6, 7, 8, 3, 4, 5, 9, 10 });

            int p = h.LongestSubarrayDivisibleByK(new int[] { -2, 2, -5, 12, -11, -1, 7 }, 3);

            int q = h.MaxLen(new int[] { 1, 2, -2 });

            bool possible = h.CanAllArrayPairsDivisibleByK(new int[] { 92, 75, 65, 48, 45, 35 }, 10);

            Console.WriteLine("Longest subarray is " + p);
        }

        private static void BinaryTreeFunctions()
        {
            BinaryTree bt = new BinaryTree();
            bt.InsertNode(1);
            bt.InsertNode(2);
            bt.InsertNode(3);

            bt.InsertNode(4);
            bt.InsertNode(5);
            bt.InsertNode(6);


            BinaryTree tree = new BinaryTree();
            tree.root = new TreeNode(1);
            tree.root.left = new TreeNode(2);
            tree.root.right = new TreeNode(3);
            tree.root.left.left = new TreeNode(4);
            tree.root.right.left = new TreeNode(5);
            tree.root.right.right = new TreeNode(6);
            tree.root.right.left.right = new TreeNode(7);
            tree.root.right.right.right = new TreeNode(8);
            tree.root.right.left.right.left = new TreeNode(9);
            tree.root.right.right.right.right = new TreeNode(10);

            // bt.InsertNode(6);
            bt.InsertNode(7);
            //  bt.InsertNode(8);
            //    bt.InorderTraversal();
            //bt.DeleteDeepestNode();
            bt.InorderTraversal();
            //Console.WriteLine("By Stack");
            //   Console.WriteLine(bt.NthNode(3, bt.root));

            //   var x = bt.NodeParentMap(bt.root, null);

            //  var path = bt.PathFromRoot(5);

            //  bt.MinumHeight();

            //   tree.DeepestleftNode();
            //Console.WriteLine(bt.NthInorderstack(3));


            BinaryTree sumTree = new BinaryTree();

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(1);
            root.left.right.left = new TreeNode(1);
            root.right = new TreeNode(-1);
            root.right.left = new TreeNode(4);
            root.right.left.left = new TreeNode(1);
            root.right.left.right = new TreeNode(2);
            root.right.right = new TreeNode(5);
            root.right.right.right = new TreeNode(2);
            sumTree.root = root;

            //    sumTree.PrintSumPaths(5);

            BinaryTree btmax = new BinaryTree();
            TreeNode rootmaSum = new TreeNode(1);
            root.left = new TreeNode(-2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(-6);
            root.right.right = new TreeNode(2);

            var x = bt.LargestSumTree(root);

            BinaryTree bst = new BinaryTree();
            bst.InsertNode(4);
            bst.InsertNode(2);
            bst.InsertNode(5);

            bst.InsertNode(1);
            bst.InsertNode(3);
            bst.InsertNode(6);


            Console.WriteLine("IS BST " + bst.isBST(bst.root, int.MinValue, int.MaxValue));

            // bt.Inorderstack();
            List<int> levelNodes = new List<int>();
            bt.PrintNodesByLevelRec(bt.root, 4, levelNodes);



            //     bt.PrintLevelOrder(3);
            //  bt.printCurrentLevel(bt.root,  bt.HeightOfTree());

        }

        private static void MyQueueFunctions()
        {
            MyQueue mq = new MyQueue();
            mq.enQueue(3);
            mq.enQueue(2);
            mq.enQueue(4);

            mq.Sort();
            mq.Print();

            //  mq.Reverse();
            //mq.enQueue(4);
            //  mq.Print();
            //Console.WriteLine(mq.deQueue());
            //Console.WriteLine(mq.deQueue());
            //Console.WriteLine(mq.deQueue());
            //Console.WriteLine(mq.deQueue());
            //mq.Print();
        }

        private static void ArrayFunctions()
        {

            ArrayFunc.MissningDuplicateInN(new int[] { 2, 4, 1, 2, 2 });
            char c = (char)(1 + 'a');

            string s = string.Empty;

            s += c;

            int n = 1 + 'a';

            int[] a = new int[] { 6, 1, 4, 2, 7, 3, 8, 99, 39, 57, 43 }; ;
            int d = 2;
            int n1 = a.Length;

            ArrayFunc.QuickSort(a, 0, a.Length - 1);
            //  int pi = ArrayFunc.PivotIndex(a, 0, a.Length-1);

            //   ArrayFunc.SortHash(0, 1);

            ArrayFunc.Shuffle(a, 0, n);

            int[,] d2 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            ArrayFunc.leftRotate(a, 3, a.Length);

            ArrayFunc.RotateNew(a, 4);
            //   ArrayFunc.RotateMatrixElementClock(d2);
            // ArrayFunc.RowsTocolums(ref d2);
            //   ArrayFunc.Print2DArray(d2);

            int max = ArrayFunc.MaxCountInSorted(new int[] { 1, 1, 2, 3, 3, 3, 4 });

            ArrayFunc.findMinSum(a, 6);

            //  int p = ArrayFunc.COUN(a, 4);

            ArrayFunc.QucikSort(a, 0, a.Length - 1);

            Random r = new Random();
            int k = r.Next(0);

            ArrayFunc.KsortedArray(a, 3);



            int[] swapsR = ArrayFunc.RearrangeEvenGreaterThanOdd(a);
            //
            // int md = ArrayFunc.binarySearch(a, 0, a.Length-1, 3);
            //    int[] xy = RearrangeArray(a);

            //   int t = 3 %5;

            // a =    ArrayFunc.ReverseArray(a);

            var m = ArrayFunc.MovePositiveNegative(a);

            for (int i = 0; i < d; i++)
            {
                int temp = a[0];

                for (int j = 1; j < n; j++)
                {
                    a[j - 1] = a[j];
                }
                a[n - 1] = temp;

            }

            for (int x = 0; x < a.Length; x++)
            {
                Console.WriteLine(a[x]);
            }

            Console.Read();
        }

        private static void HeapFunctions()
        {
            Heap h1 = new Heap(1);
            h1.InsertInHeap(2);
            h1.InsertInHeap(1);
            h1.RemoveFromHeap();
            h1.InsertInHeap(1);
            h1.InsertInHeap(8);
            h1.InsertInHeap(6);
            h1.InsertInHeap(5);
            h1.InsertInHeap(10);
            h1.InsertInHeap(1);

            NewHeap h = new NewHeap(1);
            h.Push(2);
            h.Push(1);
            h.Pop();
            h.Push(1);
            h.Push(8);
            h.Push(6);
            h.Push(5);
            h.Push(10);
            h.Push(1);

            while (h._size > 0)
            {
                Console.WriteLine(h.Pop());
            }
        }

        private static void LRUFunction()
        {
            LRUCache lru = new LRUCache(2);

            lru.set(1, 1);
            lru.set(2, 2);
            lru.set(3, 3);
        }


        private static void LinkListFunctions()
        {
            LinkList ll = new LinkList();
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            ll.AddNode(4);
            ll.AddNode(6);
            ll.Print();
            // ll.RemoveDuplicateNonewList();
            //   ll.Print();
            // ll.ReverseList();
            ll.InsertSortedList(0);
            ll.Print();
        }




    }
}
