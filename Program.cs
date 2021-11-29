using CCIFinal.Array;
using CCIFinal.Practice;
using CCIFinalLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static CCIFinal.Array.ArrayFunc;


namespace CCIFinal
{
    class Program
    {
        public static object PracticeHelper { get; private set; }

        static void Main(string[] args)
        {

            int k = ArrayFunc.MaxContinousSumPract(new int[] { -2, -3, 4, -1, -2, 1, 5, -3 }
);

            int bn = ArrayFunc.MaxContinousSumKandane(new int[] { -2, -3, 4, -1, -2, 1, 5, -3 });
            ArrayFunc.MovePositiveAndNegative(new int[] { 1, 2, -3, 0, -8, 6, 7, -9, 10, -7 });

            char[] str1 = "Geeksforgeeks".ToCharArray();
            char[] str2 = "1forgeeksgeeks".ToCharArray();

            // Function call
            if (StringHelper.areAnagram(str1, str2))
                Console.Write("The two strings are " +
                              "anagram of each other");
            else
                Console.Write("The two strings are " +
                              "not anagram of each other");


            HashFunctions();
            SlidingWindowFunctions();
            GraphFunctions();

            int profit = DynamicProgramming.MaxSteal(new int[] { 15, 7, 1, 20, 10, 2, 4 }, 7, 0);

            int[] c = SortHelper.MergeList(new int[] { 1, 5, 9 }, new int[] { 2, 3, 6, 10 });
            Console.WriteLine("Steps to End " + DynamicProgramming.MinStepToEnd(new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
            Console.Write(DPHelper.LIS(new int[] { 7, 7, 7, 7, 7, 7 }, 6));

            Console.WriteLine(DPHelper.LCSubString("vtcky", "vtcka", 5, 5, 0));
            Console.WriteLine(DPHelper.MinCoin(new int[] { 1, 2, 3 }, 5, 3));

            Console.WriteLine(DynamicProgramming.RodCuttingDP(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 5, 8, 9, 10, 17, 17, 20 }, 8, 8)
                );
            DPHelper.KnapSackParent(new int[] { 2, 4, 3, 8 }, new int[] { 10, 5, 9, 6 }, 6);
            SortingFunctions();
            StringFunctions();
            Console.WriteLine(Getuser("@JoeBloggs yo", 1));

            Console.WriteLine(fizzBuzz(9));
            Console.WriteLine(fizzBuzz(10));
            Console.WriteLine(fizzBuzz(15));
            Console.WriteLine(fizzBuzz(8));
            PracticeFuncations();

            BackTracking();




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

        private static void GraphFunctions()
        {
            Graph g = new Graph(7);
            //  g.PrintDijkastra();
            g.AddEdge(0, 1);
            g.AddEdge(1, 3);
            g.AddEdge(6, 0);
            g.AddEdge(5, 6);
            g.AddEdge(5, 2);
            g.AddEdge(6, 4);
            g.AddEdge(4, 1);
            g.AddEdge(3, 0);


            // g.ListAllPath(5, 1);
            //Console.WriteLine("Num Island " + g.NumIsland());

            Console.WriteLine("Has Cycle " + g.isCyclic());

            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            Console.WriteLine("Has Cycle " + graph.IsCycleDirectedGraph());



            // g.AddEdge(3, 3);

            Console.WriteLine("Has Cycle " + g.isCyclic());



            Graph g1 = new Graph(4);
            // Construct a graph
            g1.AddEdge(0, 3);
            g1.AddEdge(0, 1);
            g1.AddEdge(0, 2);
            g1.AddEdge(1, 3);
            g1.AddEdge(2, 0);
            g1.AddEdge(2, 1);

            Console.WriteLine("Has Path " + g1.HasPath(2, 3));

            Graph g2 = new Graph(4);

            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            g2.AddEdge(2, 3);
            // g2.AddEdge(3, 2);
            g2.AddEdge(0, 3);

            Console.WriteLine("Has Cycle " + g2.HasCycle());

            Console.WriteLine("Has Cycle Rec" + g2.HasCycleRec());

            Console.WriteLine("BFS all path");
            g1.BFSPath(2, 3);

            Console.WriteLine("Mother vertex is   " + g.MotherVertex());


            Console.Write("Following is Breadth First " +
                          "Traversal(starting from " +
                          "vertex 2)\n");


            g.BFSFromNode(2);

            Console.Write("Following is BFS New" +
                         "Traversal(starting from " +
                         "vertex 2)\n");

            g.BFSNew(2);


            Console.Write("Following is Depth First " +
                          "Traversal(starting from " +
                          "vertex 2)\n");
            g.DFS(2);

            Console.Write("Following is New Depth First " +
                          "Traversal(starting from " +
                          "vertex 2)\n");

            g.DFSNew(2);

        }

        private static void SortingFunctions()
        {
            int[] x = SortHelper.QuickSort(new int[] { 3, 1, 2, 8, 4, 19 }, 0, 5);
            int[] sorted = SortHelper.MergeSort(new int[] { 3, 1, 8, 4, 19, 10 }, 0, 5);
            int[] c = SortHelper.MergeSortedArray(new int[] { 1, 5, 9 }, new int[] { 2, 3, 6, 10 });
        }

        private static void PracticeFuncations()
        {
            int stairWays = DynamicProgramming.NumberOfWaysToNthStair(4);
            bool haskdiv = DynamicProgramming.HasSubsetDivK(new int[] { 1, 7, 3, 11 }, 5, 4, 0);
            DPHelper.PrintNthFabonaci(6);
            string palsub = DPHelper.LongestPalindromicSubstring("forgeeksskeegfor");
            int lcs = DPHelper.LCSDP("ghvikas", "vikuuy", 7, 6);
            int way3 = DynamicProgramming.NumberOfWaysToSumKRec(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 6);
            int num = DPHelper.SubSetSumDP(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 6);
            int p = DPHelper.KnapSackDP(new int[] { 2, 1, 3, 5, 4 }, new int[] { 10, 12, 2, 3, 5 }, 4, 5);
            int profit = DynamicProgramming.KanpSackMemoization(new int[] { 2, 1, 3, 5, 4 }, 4, new int[] { 10, 12, 2, 3, 5 }, 5);
            int p2 = DPHelper.KnapSackMemoization(new int[] { 2, 1, 3, 5, 4 }, new int[] { 10, 12, 2, 3, 5 }, 4, 5);
            int p1 = DPHelper.KnapSackRecursive(new int[] { 2, 1, 3, 5, 4 }, new int[] { 10, 12, 2, 3, 5 }, 4, 5);
        }

        private static void DPFunctions()
        {

            int lcs = DPLCS.LongestSubstringRecursive("kaist", "vikyais", 5, 7, 0);
            int mincoins = DynamicProgramming.MinCoinsToCoinSumDP(new int[] { 1, 2, 5 }, 8);
            int x = DynamicProgramming.MinCoinsToCoinSum(new int[] { 1, 2, 5 }, 8, 3);
            CCIFinal.BackTracking.PrintSubset(new int[] { 2, 1, 3, 5, 4 }, 5, new List<int>());
            int p1 = DynamicProgramming.KnapsackDP(new int[] { 2, 1, 3, 5, 4 }, 4, new int[] { 10, 12, 2, 3, 5 }, 5);
            int profit = DynamicProgramming.KanpSackMemoization(new int[] { 2, 1, 3, 5, 4 }, 4, new int[] { 10, 12, 2, 3, 5 }, 5);
            int way3 = DynamicProgramming.NumberOfWaysToSumKRec(new int[] { 1, -2, 3, 4, 5, 6 }, 6, 6);

        }

        private static void BackTracking()
        {
            CCIFinal.BackTracking.SolveMaze();
            CCIFinal.BackTracking.SudoKuSolve(9);
            CCIFinal.BackTracking.placeQueens(0, 4);
            CCIFinal.BackTracking.NQueen(6);
        }

        private static void SlidingWindowFunctions()
        {
            SlidingWindow.LongestSubstringWithKUniqueChar("abacdefgh", 4);
            SlidingWindow.LongestSubStringKUniqueChar("abacdefgh", 4);

            SlidingWindow.LongestSubstringWithoutRepeatingChar("abcbdebfxyzwrm");

            SlidingWindow.PracticeLongestSubstringWithoutRepeatingChar("abcbdebfxyzwrm");
            SlidingWindow.MaxTargetSumArray(new int[] { 4, 1, 1, 1, 1, 1, 3, 5 }, 5);
            SlidingWindow.MaxInAllSubArrayInWindow(new int[] { 1, 2, 5, 1, 2, 0, 5 }, 3);
            SlidingWindow.MaxSumSubArrayInKWindow(new int[] { 1, 2, 13, 4, 5, 2 }, 3);
            SlidingWindow.MaxSubArraySumInKWindow(new int[] { 1, 2, 13, 4, 5, 2 }, 3);
        }

        private static void HashFunctions()
        {
            Hash h = new Hash();

            string x = Hash.GetKey("kghjkggh");
            int l1 = h.LongestConsecutiveSequenceNoOrder(new int[] { 1, 9, 3, 10, 4, 20, 19, 18, 17, 16 });

            // no need to use hash for subarray
            int m = Hash.PracticeLongestIncreasingSubarray(new int[] { 2, 6, 7, 8, 3, 4, 5, 9, 10 });

            int l = h.LongestIncreasingConsecutiveSubsequence(new int[] { 2, 6, 7, 8, 3, 4, 5, 9, 10 });

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
            var t = ArrayFunc.MergeIntervals(new List<Interval>() { new Interval { Start = 1, End = 5 }, new Interval { Start = 3, End = 6 }, new Interval { Start = 2, End = 5 }, new Interval { Start = 4, End = 7 } });

            var result = ArrayFunc.SubSetSumK(new int[] { 1, 2, 3, 4, 5, 6 }, 6);
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


        private static void StringFunctions()
        {
            int minSwap = StringHelper.MinSwapToPalindrome("aabcb ");
            StringHelper.PrintPermutation("abc", "");
        }


        public static string fizzBuzz(int n)
        {
            // ans list


            bool divisibleBy3 = (n % 3 == 0);
            bool divisibleBy5 = (n % 5 == 0);

            string numAnsStr = "";

            if (divisibleBy3)
            {
                // Divides by 3, add Fizz
                numAnsStr += "Fizz";
            }

            if (divisibleBy5)
            {
                // Divides by 5, add Buzz
                numAnsStr += "Buzz";
            }


            if (numAnsStr == "")
            {
                // Not divisible by 3 or 5, add the number
                numAnsStr += Convert.ToString(n);
            }

            return numAnsStr;
        }


        public static string Getuser(string name, int index)
        {
            List<string> strName = new List<string>();

            if (string.IsNullOrEmpty(name))
                return "";

            string user = string.Empty;

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '@')
                {
                    i++;
                    while (i < name.Length && IsValidChar(name[i]))
                    {
                        user += name[i];
                        i++;
                    }

                    if (!string.IsNullOrEmpty(user))
                    {
                        strName.Add(user);
                    }
                    user = string.Empty;
                }
            }

            if (strName.Count >= index)
            {
                return strName[index - 1];
            }

            return string.Empty;
        }

        private static bool IsValidChar(char x)
        {
            if (x >= 48 && x <= 57)
                return true;

            if (x >= 65 && x <= 90)
                return true;

            if (x >= 97 && x <= 122)
                return true;

            if (x == '-')
                return true;

            if (x == '_')
                return true;

            return false;

        }


    }
}
