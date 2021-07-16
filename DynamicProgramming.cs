using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class DynamicProgramming
    {

        // DP probem has following characteristic 
        // 1) There will be choice/decision
        // 2) Optimal problem - Max, Min - Backtracking is all solution 
        // 3) Repeatitive subproblem - Parent problem is recursion, multiple calls to same recusion
        // DP = Recursion + Store old result 


        // Uses recursion - can have stackoverflow issue
        public static int KnapSack(int[] wt, int maxW, int[] value, int n)
        {
            int max = int.MinValue;
            if (n == 0 || maxW == 0)
            {
                // Console.Write("Profit is zero");
                return 0;
            }

            if (wt[n - 1] > maxW)
                return KnapSack(wt, maxW, value, n - 1);

            if (wt[n - 1] <= maxW)
            {
                max = Math.Max(KnapSack(wt, maxW, value, n - 1),
                 KnapSack(wt, maxW - wt[n - 1], value, n - 1) + value[n - 1]);
            }

            return max;
        }

        #region KnapSack Memoization
        // Memoization we store results so no need to calucate them again 

        // Dimension on this is based on what are dynamic paramters
        // Here N will vary and maxW will vary for each recursion step
        private static int[,] memKnapSack;

        public static int KanpSackMemoization(int[] wt, int maxW, int[] value, int n)
        {
            // intialise with empty value
            memKnapSack = new int[n + 1, maxW + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= maxW; j++)
                {
                    memKnapSack[i, j] = -1;
                }
            }

            KnapSackMemSubProblem(wt, maxW, value, n);

            return memKnapSack[n, maxW];
        }

        private static int KnapSackMemSubProblem(int[] wt, int maxW, int[] value, int n)
        {

            // First thing to check if value already stored from previous recusion, return it.
            if (memKnapSack[n, maxW] != -1)
                return memKnapSack[n, maxW];

            //Very Important to take n-1 and not n
            if (wt[n - 1] > maxW)
            {
                return memKnapSack[n, maxW] = KnapSack(wt, maxW, value, n - 1);

            }

            if (wt[n - 1] <= maxW)
            {
                memKnapSack[n, maxW] = Math.Max(KnapSack(wt, maxW, value, n - 1),
                KnapSack(wt, maxW - wt[n - 1], value, n - 1) + value[n - 1]);
            }

            return memKnapSack[n, maxW];
        }

        #endregion

        #region KnapSack DP

        public static int KnapsackDP(int[] wt, int maxW, int[] value, int n)
        {
            int[,] dp = new int[n + 1, maxW + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i <= maxW; i++)
            {
                dp[0, i] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= maxW; j++)
                {
                    if (wt[i - 1] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - wt[i - 1]] + value[i - 1]);
                    }
                }
            }

            return dp[n, maxW];

        }



        #endregion


        public static bool HasSubsetWithSumKRec(int[] a, int k, int n)
        {
            if (n == 0)
                return false;

            if (k == 0)
                return true;

            if (a[n - 1] > k)
                return HasSubsetWithSumKRec(a, k, n - 1);

            return HasSubsetWithSumKRec(a, k - a[n - 1], n - 1) || HasSubsetWithSumKRec(a, k, n - 1);
        }


        public static int NumberOfWaysToSumKRec(int[] a, int n, int k)
        {

            // 2nd condition handles -ve numbers
            if (k == 0)
                return 1;

            if (n == 0)
                return 0;

            if (a[n - 1] > k)
                return NumberOfWaysToSumKRec(a, n - 1, k);


            return NumberOfWaysToSumKRec(a, n - 1, k) +
             NumberOfWaysToSumKRec(a, n - 1, k - a[n - 1]);

        }


        #region Coin change Recursive

        public static int NumbeOfWaysToCoinSum(int[] coins, int sum, int n)
        {


            if (n == 0)
                return 0;

            if (sum == 0)
                return 1;


            if (coins[n - 1] > sum)
                return NumbeOfWaysToCoinSum(coins, sum, n - 1);

            return NumbeOfWaysToCoinSum(coins, sum - coins[n - 1], n) + NumbeOfWaysToCoinSum(coins, sum, n - 1);
        }

        #endregion

        #region Coin change min coins  Recursive

        public static int MinCoinsToCoinSum(int[] coins, int sum, int n)
        {
            if (sum == 0)
                return 0;


            if (n == 0)
                return int.MaxValue;


            if (coins[n - 1] > sum)
                return MinCoinsToCoinSum(coins, sum, n - 1);

            return Math.Min(1 + MinCoinsToCoinSum(coins, sum - coins[n - 1], n), MinCoinsToCoinSum(coins, sum, n - 1));
        }

        #endregion


        #region Coin change min coins Dp

        public static int MinCoinsToCoinSumDP(int[] coins, int sum)
        {
            int[] dpmincoins = new int[sum + 1];

            for (int i = 0; i < dpmincoins.Length; i++)
            {
                dpmincoins[i] = int.MaxValue;
            }


            //Zero sum can be created with Zero coins
            dpmincoins[0] = 0;

            // For each sum we need to create
            for (int i = 0; i < dpmincoins.Length; i++)
            {
                //Try each coin 
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                        dpmincoins[i] = Math.Min(dpmincoins[i], 1 + dpmincoins[i - coins[j]]);
                }
            }

            return dpmincoins[sum] == int.MaxValue ? -1 : dpmincoins[sum];
        }

        #endregion


        #region Longest common substring recursive


       



        #endregion 
    }
}
