using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class Practice
    {
        public static bool IsValidBST()
        {
            BinaryTree bst = new BinaryTree();
            bst.InsertNode(4);
            bst.InsertNode(2);
            bst.InsertNode(5);

            bst.InsertNode(1);
            bst.InsertNode(3);
            bst.InsertNode(6);

            PrintNodeLevel(bst.root, 1, 2);
            return IsValidNode(bst.root, int.MaxValue, int.MinValue);

        }

        private static bool IsValidNode(TreeNode node, int max, int min)
        {
            if (node == null)
                return true;

            // if left node exist then check it has
            // correct data or not i.e. left node's data
            // should be less than root's data
            if (node.key <= min || node.key >= max)
                return false;

            return IsValidNode(node.right, max, node.key) && IsValidNode(node.left, node.key, min);

        }



        private static void PrintNodeLevel(TreeNode node, int level, int k)
        {
            if (node == null)
                return;

            if (level == k)
                Console.WriteLine($"Node {node.key} at level {level}");

            PrintNodeLevel(node.left, level + 1, k);
            PrintNodeLevel(node.right, level + 1, k);


        }


        public static void SortStack(Stack<int> st)
        {
            int count = st.Count;

            if (st.Count == 1)
                return;

            //while (count > 0)
            //{
            int pop = st.Pop();
            SortStack(st);
            Insert(st, pop);
            //  count--;
            // }
        }

        private static void Insert(Stack<int> st, int i)
        {
            if (st.Count == 0)
            {
                st.Push(i);
                return;
            }

            if (st.Peek() > i)
            {
                int pop = st.Pop();
                Insert(st, i);
                st.Push(pop);
            }
            else
            {
                st.Push(i);
            }

        }

        private static int ways = 0;
        private static int[,] dp;


        //Does not work with -ve or 0 in it 
        public static int DPNumberOfWaysToSumK(int[] a, int n, int k)
        {
            dp = new int[n + 1, k + 1];

            for (int i = 0; i < k + 1; i++)
            {
                dp[0, i] = 0;
            }

            for (int i = 0; i < n + 1; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < k + 1; j++)
                {
                    if (a[i - 1] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }

                    else if (a[i - 1] <= j)
                    {
                        dp[i, j] = dp[i-1, j - a[i - 1]] + dp[i-1, j];
                    }
                }
            }

            return dp[n, k];

        }

        // Works with 0 and -ve numbers
        public static int NumberOfWaysToSumK(int[] a, int n, int k, int sofar)
        {
            if (n == 0)
                return ways;

            if (k == sofar + a[n - 1])
                ways++;

            if (sofar + a[n - 1] > k)
            {
                NumberOfWaysToSumK(a, n - 1, k, sofar);
            }
            else
            {
                NumberOfWaysToSumK(a, n - 1, k, sofar + a[n - 1]);
                NumberOfWaysToSumK(a, n - 1, k, sofar);
            }

            return ways;
        }


        private static int maxProfit = 0;

        public static int MaxProfitKnapSack(int[] wt, int[] values, int maxBagSize, int n)
        {

            if (n == 0)
                return maxProfit;

            if (wt[n - 1] > maxBagSize)
            {
                maxProfit = Math.Max(maxProfit, MaxProfitKnapSack(wt, values, maxBagSize, n - 1));
            }
            else
            {
                maxProfit = Math.Max(MaxProfitKnapSack(wt, values, maxBagSize - wt[n - 1], n - 1) + values[n - 1],
                                     MaxProfitKnapSack(wt, values, maxBagSize, n - 1));
            }

            return maxProfit;
        }

    }
}
